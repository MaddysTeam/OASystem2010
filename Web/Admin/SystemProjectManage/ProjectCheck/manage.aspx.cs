using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace Dianda.Web.Admin.SystemProjectManage.ProjectCheck
{
    public partial class manage : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();

        Hashtable Project_Cash_Cards_ht = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string pageindex = null;//这里是为分页服务的
                string projectstatus = "";

                pageindex = Request["pageindex"];
                projectstatus = Request["Status"];

                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    if (null != projectstatus && !projectstatus.Equals(""))
                    {
                        setRowCout(projectstatus);//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    }
                    else
                    {
                        setRowCout("0");//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    }
                    count = dtrowsHidden.Value.ToString();
                }
                else
                {
                    count = "0";
                }
                int countint = int.Parse(count);

                if (pageindex == null || pageindex == "")
                {
                    pageindex = "1";
                }

                int pageindex_int = int.Parse(pageindex);

                if (null == projectstatus || projectstatus.Equals(""))
                {
                    projectstatus = "0";
                }
                ShowListInfo(pageindex_int, projectstatus);

            }

            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 ";
            //设置模板页中的管理值
        }

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout(string status)
        {
            try
            {
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                DataTable DT = new DataTable();

                string sql = "SELECT * FROM vProject_Projects WHERE DELFLAG = 0 ";

                if (null != status && !status.Equals(""))
                {
                    if(status.Equals("9"))
                    {
                       sql = sql + " AND (ID IN (SELECT ProjectID FROM Project_ShenheList WHERE (UserID = '" + user_model .ID+ "') AND (Isturn = 2) AND (Status = 0))) ";

                    }
                    else//如果查看的是待审或是不通的项目,只有在新建项目时所选择的审核人才能查看这些项目
                    {
                      sql = sql + " AND Status=" + status;
                      //只有在新建项目时所选择的审核人才能查看这些项目
                      sql = sql + " AND (DoUserID = '" + user_model.ID + "')";
                    }
                }
                else
                {
                    sql = sql + " AND (Status=0 or Status=2)";
                    //只有在新建项目时所选择的审核人才能查看这些项目
                    sql = sql + " AND (DoUserID = '" + user_model.ID + "')";
                }

                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    dtrowsHidden.Value = DT.Rows.Count.ToString();
                }
                else
                {
                    dtrowsHidden.Value = "0";
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 当分页控件中的“第一页”“第二页”...发生时，触发下面的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageChange_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
            pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值
            string status = DDL_Status.SelectedValue;
            setRowCout(status);
            ShowListInfo(page, status);//调用显示

        }
        /// <summary>
        /// 当分页控件中的下拉菜单触发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
            string status = DDL_Status.SelectedValue;
            setRowCout(status);
            ShowListInfo(page, status);//调用显示

        }



        /// <summary>
        /// 点击全选框时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox_choose_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox CheckBox_Alltemp = (CheckBox)sender;
                if (CheckBox_Alltemp.Checked)//全选
                {
                    grievSearch(true);
                }
                else//全不选
                {
                    grievSearch(false);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        ///根据条件给值
        /// </summary>
        /// <param name="isCheck"></param>
        private void grievSearch(bool isCheck)
        {
            try
            {
                int rows = GridView1.Rows.Count;
                if (rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                        cb.Checked = isCheck;
                    }
                }

            }
            catch
            {
            }
        }

        //添加一个资金卡表
        public void get_Cash_Cards()
        {
            if (Session["Project_Cash_Cards"] == null)
            {
                string sql = "SELECT ID, CardNum, CardName, ProjectID FROM Cash_Cards where statas=1 and projectid is not null";

                DataTable dt = pageControl.doSql(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //创建哈希表
                    Hashtable Cash_Cards = new Hashtable();
                    //循环dt表
                    foreach (DataRow _row in dt.Rows)
                    {
                        string _ProjectID = _row["ProjectID"].ToString();
                        string _CardName = _row["CardName"].ToString();
                        //查找哈希表中是否存在这个ProjectID，存在的话修改，不存在的话添加
                        if (!Cash_Cards.Contains(_ProjectID))
                        {
                            Cash_Cards.Add(_ProjectID, _CardName);
                        }
                        else
                        {
                            //重新赋值
                            string _str = (string)Cash_Cards[_ProjectID] + "," + _CardName;
                            Cash_Cards.Remove(_ProjectID);
                            Cash_Cards.Add(_ProjectID, _str);

                        }
                    }
                    Session["Project_Cash_Cards"] = Cash_Cards;
                    Project_Cash_Cards_ht = Cash_Cards;
                }
            }
            else
            {
                Project_Cash_Cards_ht = (Hashtable)Session["Project_Cash_Cards"];
            }
        }

        /// <summary>
        ///显示待审核的项目列表信息 
        /// </summary>
        /// <param name="pageindex"></param>
        protected void ShowListInfo(int pageindex, string status)
        {
            try
            {
                get_Cash_Cards();

                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                DataTable DT = new DataTable();
                string sqlWhere1 = " DELFLAG = 0 ";

                if (null != status && !status.Equals(""))
                {
                    if (status.Equals("9"))
                    {
                        sqlWhere1 = sqlWhere1 + " AND (ID IN (SELECT ProjectID FROM Project_ShenheList WHERE (UserID = '" + user_model.ID + "') AND (Isturn = 2) AND (Status = 0))) ";

                    }
                    else//如果查看的是待审或是不通的项目,只有在新建项目时所选择的审核人才能查看这些项目
                    {
                        sqlWhere1 = sqlWhere1 + " AND Status=" + status;
                        //只有在新建项目时所选择的审核人才能查看这些项目
                        sqlWhere1 = sqlWhere1 + " AND (DoUserID = '" + user_model.ID + "')";
                    }
                }
                else
                {
                    sqlWhere1 = sqlWhere1 + " AND (Status=0 or Status=2)";
                    //只有在新建项目时所选择的审核人才能查看这些项目
                    sqlWhere1 = sqlWhere1 + " AND (DoUserID = '" + user_model.ID + "')";
                }

                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                DT = pageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "vProject_Projects", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中

                    GridView1.Visible = true;
                    GridView1.DataSource = DT;//指定GridView1的数据是DT
                    pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    Button_check.Enabled = true;
                    tag.Text = "";

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    notice.Text = "";
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    Button_check.Enabled = false;
                    if (alltiaoshuInt > 0)
                    {
                        ShowListInfo(pageindex - 1,status);
                    }

                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    //项目的ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;

                    //项目状态
                    string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                    if (DDL_Status.SelectedValue.ToString().Equals("9"))
                    {
                        //项目审核人真实姓名
                        string DoUserRealName = DataBinder.Eval(e.Row.DataItem, "DoUserRealName").ToString();
                        //项目审核人用户名
                        string DoUserUserName = DataBinder.Eval(e.Row.DataItem, "DoUserUserName").ToString();

                        e.Row.Cells[8].Text = "<font color='red'>已移交到：" + DoUserRealName + "[" + DoUserUserName + "]" + "</font>";
                    }
                    else
                    {
                        switch (status)
                        {
                            case "0":
                                e.Row.Cells[8].Text = "待审核";
                                break;
                            case "2":
                                e.Row.Cells[8].Text = "<font color='red'>审核不通过</font>";
                                break;

                        }
                    }

                    //项目名称
                    string names = DataBinder.Eval(e.Row.DataItem, "NAMES").ToString();

                    //附件地址
                    string Attachments = DataBinder.Eval(e.Row.DataItem, "Attachments").ToString();

                    if (null != Attachments && !Attachments.Equals(""))
                    {
                        e.Row.Cells[1].Text = "&nbsp;&nbsp;"+ names+" <img src='/Admin/images/OAimages/fj.jpg' border='0'>";

                    }
                    else
                    {
                        e.Row.Cells[1].Text = names;

                    }

                    //立项申请人用户名
                    string SendUserUserName = DataBinder.Eval(e.Row.DataItem, "SendUserUserName").ToString();
                    //立项申请人真实姓名
                    string SendUserRealName = DataBinder.Eval(e.Row.DataItem, "SendUserRealName").ToString();
                    //立项申请人
                    e.Row.Cells[2].Text = SendUserRealName + "[" + SendUserUserName + "]";

                    //项目负责人用户名
                    string LeaderUserName = DataBinder.Eval(e.Row.DataItem, "LeaderUserName").ToString();
                    //项目负责人真实姓名
                    string LeaderRealName = DataBinder.Eval(e.Row.DataItem, "LeaderRealName").ToString();
                    //项目负责人
                    e.Row.Cells[3].Text = LeaderRealName + "[" + LeaderUserName + "]";

                    //开始时间
                    string StartTime = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StartTime").ToString()).ToString("yyyy-MM-dd");
                    //结束时间
                    string EndTime = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "EndTime").ToString()).ToString("yyyy-MM-dd");
                    e.Row.Cells[6].Text = StartTime + "</br>" + EndTime;


                    //项目资金卡
                    string MessageStr = "";
                    if (Project_Cash_Cards_ht.Contains(ID))
                    {
                        MessageStr = (string)Project_Cash_Cards_ht[ID];
                    }
                    else
                    {
                        MessageStr = "新建资金卡";
                    }
                    e.Row.Cells[5].Text = "<a  href='#' title='[资金卡情况]：" + MessageStr + "'>资金卡详细</a>";
                    //string CardName = DataBinder.Eval(e.Row.DataItem, "CardName").ToString();

                    //e.Row.Cells[7].Text = CardName.Equals("") ? "新建资金卡" : CardName; 
                }
            }
            catch
            {

            }
        }

        protected void DDL_Status_Changed(object sender, EventArgs e)
        {

            string status = DDL_Status.SelectedValue;
            if (status.Equals("9"))
            {
                Button_check.Visible = false;
            }
            else
            {
                Button_check.Visible = true;
            }
            setRowCout(status);
            ShowListInfo(1,status);//调用显示
        }

        /// <summary>
        /// 点击审批按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_check_onclick(object sender, EventArgs e)
        {
            //选择审批的条数只能为一条
            int num = 0;
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if (cb.Checked)
                    {
                        num = num + 1;
                    }
                }

                if (num == 0)
                {
                    tag.Text = "请选择一条数据进行审批！";


                }
                else if (num > 1)
                {
                    tag.Text = "审批时最多只能选择一条数据！";

                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

                        if (cb1.Checked)
                        {
                            Response.Redirect("check.aspx?ID=" + hid.Value.ToString() + "&pageindex=" + pageindexHidden.Value.ToString() + "&Status=" + DDL_Status.SelectedValue);
                        }
                    }
                }

            }

        }

    }
}
