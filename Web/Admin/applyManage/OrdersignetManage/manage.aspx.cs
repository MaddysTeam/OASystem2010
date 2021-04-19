using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.applyManage.OrdersignetManage
{
    public partial class manage : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.Model.userPower mUserPower = new Dianda.Model.userPower();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string pageindex = null;//这里是为分页服务的
                string projectstatus = "";

                //使用mUserPower.isYinReader该项
                mUserPower = (Model.userPower)Session["Session_Power"];
                if (mUserPower.isYinLeader.Equals("1"))
                {
                    HField_YYQX.Value = mUserPower.isYinLeader;
                    Button_check.Visible = true;
                }

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

                if (null != Request["Status"])
                {
                    for (int i = 0; i < DDL_Status.Items.Count; i++)
                    {
                        if (DDL_Status.Items[i].Value.ToString().Equals(Request["Status"].ToString()))
                        {
                            DDL_Status.Items[i].Selected = true;
                        }
                    }
                }

            }

            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 用印管理 ";
            //设置模板页中的管理值

        }


        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout(string status)
        {
            try
            {
                DataTable DT = new DataTable();
                mUserPower = (Model.userPower)Session["Session_Power"];


                string sql = "SELECT * FROM vProject_Apply_OrderSignet WHERE DELFLAG = 0 and PDEL=0";

                if (mUserPower.isYinLeader.Equals("1") || status == "0" || status == "3")
                {
                    sql += " and DoUserID='" + mUserPower.userid + "'";
                }
                //if ((null != status && status.Equals("0")) || null != status && status.Equals("3"))
                //{
                //    sql = sql + " AND Status=" + status;

                //}
                //else
                //{
                //    sql = sql + " AND (Status=1 or Status=2)";
                //}

                if (null != status)
                {
                    sql = sql + " AND Status=" + status;
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
        ///显示待审核的项目列表信息 
        /// </summary>
        /// <param name="pageindex"></param>
        protected void ShowListInfo(int pageindex, string status)
        {
            try
            {
                DataTable DT = new DataTable();

                mUserPower = (Model.userPower)Session["Session_Power"];

                string sqlWhere1 = " DELFLAG = 0 and PDEL=0";
                if (mUserPower.isYinLeader.Equals("1") || status == "0" || status == "3")
                {
                    sqlWhere1 += " and DoUserID='" + mUserPower.userid + "'";
                }
                //if ((null != status && status.Equals("0")) || null != status && status.Equals("3"))
                //{
                //    sqlWhere1 = sqlWhere1 + " AND Status=" + status;

                //}
                //else
                //{
                //    sqlWhere1 = sqlWhere1 + " AND (Status=1 or Status=2)";
                //}

                if (null != status)
                {
                    sqlWhere1 = sqlWhere1 + " AND Status=" + status;
                }

                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                DT = pageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "vProject_Apply_OrderSignet", "ID").Tables[0];
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
                        ShowListInfo(pageindex - 1, status);
                    }

                }
            }
            catch
            {

            }
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

        /// <summary>
        /// 状态筛选触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Status_Changed(object sender, EventArgs e)
        {

            string status = DDL_Status.SelectedValue;
            string YYQX = HField_YYQX.Value;

            setRowCout(status);
            ShowListInfo(1, status);//调用显示

            if (status.ToString().Equals("4"))//审核不能过或者已完成的，就不需要再显示“审核”扭钮了。
            {
                //Button_check.Enabled = false;
                Button_check.Visible = false;
            }
            else
            {
               //Button_check.Enabled = true;
                //有权限的用户或者是在已审批的情况下按钮可见
                if (YYQX.Equals("1") || status.ToString().Equals("1"))
                {
                    Button_check.Visible = true;

                    if (status.ToString().Equals("1"))//审核通过时右边显示的是“完成”按钮
                    {
                        Button_check.Text = "完成";
                    }
                    else
                    {
                        Button_check.Text = "审批";
                    }
                }
                else
                {
                    Button_check.Visible = false;
                }
            }
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
                        HiddenField hstatus = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_Status");

                        if (cb1.Checked)
                        {
                            Response.Redirect("check.aspx?ID=" + hid.Value.ToString() + "&pageindex=" + pageindexHidden.Value.ToString() + "&Status=" + DDL_Status.SelectedValue + "&H_status=" + hstatus.Value);
                        }
                    }
                }

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
                    HiddenField hstatus = (HiddenField)e.Row.FindControl("Hid_Status");
                    //业务申请的ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;
                    hstatus.Value = "";

                    //项目状态
                    string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                    //附件地址
                    string Attachments = DataBinder.Eval(e.Row.DataItem, "Attachments").ToString();

                    switch (status)
                    {
                        case "0":
                            e.Row.Cells[7].Text = "待审核";
                            break;
                        case "1":
                            e.Row.Cells[7].Text = "已审核";
                            hstatus.Value = "1";
                            break;
                        case "3":
                            e.Row.Cells[7].Text = "<font color='red'>挂起</font>";
                            break;
                        case "4":
                            e.Row.Cells[7].Text = "已完成";
                            break;
                    }

                    //申请人用户名
                    string SendUserUserName = DataBinder.Eval(e.Row.DataItem, "SendUserName").ToString();
                    //申请人真实姓名
                    string SendUserRealName = DataBinder.Eval(e.Row.DataItem, "SendRealName").ToString();
                    //申请人
                    e.Row.Cells[6].Text = SendUserRealName + "[" + SendUserUserName + "]";

                    if (null != Attachments && !Attachments.Equals(""))
                    {
                        e.Row.Cells[8].Text = "<a href='" + Attachments + "' target='_blank'>点击下载</a>";
                    }
                    else
                    {
                        e.Row.Cells[8].Text = "无";
                    }
                    //申请人真实姓名
                    string Overviews = DataBinder.Eval(e.Row.DataItem, "Overviews").ToString();
                    Overviews = string.IsNullOrEmpty(Overviews) == true ? "无" : Overviews;
                    e.Row.Cells[4].Text = "<a href=\"#\" title='用途：" + Overviews + "'>" + e.Row.Cells[4].Text + "</a>";
                }
            }
            catch
            {

            }
        }

    }
}
