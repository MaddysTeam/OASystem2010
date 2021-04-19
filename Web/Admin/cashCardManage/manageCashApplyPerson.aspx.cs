using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class manageCashApplyPerson : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.COMMON.common common = new Dianda.COMMON.common();
        Model.Cash_Apply mCash_Apply = new Dianda.Model.Cash_Apply();
        BLL.Cash_Apply bCash_Apply = new Dianda.BLL.Cash_Apply();
        BllExt.Cash_Account_Subscription bllextCash_Account_Subscription = new Dianda.BllExt.Cash_Account_Subscription();

        private static string _projectid;

        public string projectid
        {
            get { return _projectid; }
            set { _projectid = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                //项目ID
                GetddlStatas();
                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    setRowCout();//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    count = dtrowsHidden.Value.ToString();
                }
                if (count.Length == 0)
                {
                    count = "0";
                }
                int countint = int.Parse(count);
                string pageindex = null;//这里是为分页服务的
                pageindex = Request["pageindex"];
                if (pageindex == null || pageindex == "")
                {
                    pageindex = "1";
                }
                int pageindex_int = int.Parse(pageindex);
                BindData(pageindex_int);

                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "经费 > 预约经费 ";
                /*设置模板页中的管理值*/

            }
        }

        protected void GetddlStatas()
        {
            ddlStatas.Items.Add(new ListItem("全部", ""));
            ListItem li = new ListItem("待审核", "0");
            this.ddlStatas.Items.Add(li);
            li = new ListItem("审核通过", "1");
            this.ddlStatas.Items.Add(li);
            li = new ListItem("审核不通过", "2");
            this.ddlStatas.Items.Add(li);
            this.ddlStatas.Items.Add(new ListItem("审核完成", "3"));

            if (Request.Params["status"] != null && !String.IsNullOrEmpty(Request["status"]))
            {
                this.ddlStatas.SelectedValue = Request["status"];
            }
            else
            {
                this.ddlStatas.SelectedValue = "0";
            }
        }

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout()
        {
            try
            {
                string strSQL = "SELECT ID FROM vCash_Apply2 WHERE " + SQLCondition();
                DataTable dt = new DataTable();
                dt = pageControl.doSql(strSQL).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    dtrowsHidden.Value = dt.Rows.Count.ToString();
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
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        protected void BindData(int pageindex)
        {
            try
            {
                //string strSQL = "SELECT * FROM vNews_News WHERE " + SQLCondition();
                DataTable dt = new DataTable();
                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                dt = pageControl.GetList_FenYe_Common(SQLCondition(), pageindex, GridView1.PageSize, alltiaoshuInt, "vCash_Apply2", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (dt.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    if (this.ddlStatas.SelectedValue != "")
                    {
                        Button_sumbit.Enabled = true;
                    }
                    // Button_reset.Enabled = true;
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    Button_sumbit.Enabled = false;
                    // Button_reset.Enabled = false;
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！请选择筛选条件！";

                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    if (alltiaoshuInt > 0)
                    {
                        BindData(pageindex - 1);
                    }
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
            setRowCout();
            BindData(page);//调用显示

        }
        /// <summary>
        /// 当分页控件中的下拉菜单触发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
            pageindexHidden.Value = page.ToString();
            setRowCout();
            BindData(page);//调用显示

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
                        if (cb.Enabled == true)
                        {
                            cb.Checked = isCheck;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 点击新增按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_add_onclick(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/personalProjectManage/OACashApply/add.aspx?&pageindex=" + pageindexHidden.Value + "&status=" + this.ddlStatas.SelectedValue + "&parentpage=manageCashApplyPerson");
        }

        /// <summary>
        ///点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_onclick(object sender, EventArgs e)
        {
            //选择编辑的条数只能为一条
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
                    tag.Text = "请选择要操作的纪录！";

                }
                else
                {
                    tag.Text = "";
                    string info = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
                        string id = GridView1.DataKeys[j]["ID"].ToString();
                        string ApplierRealName = GridView1.DataKeys[j]["ApplierRealName"].ToString();
                        string GetDateTime = GridView1.DataKeys[j]["GetDateTime"].ToString();
                        string ApplyCount = GridView1.DataKeys[j]["ApplyCount"].ToString();
                        string Str = GridView1.DataKeys[j]["Temp1"].ToString();

                        if (cb1.Checked)
                        {
                            bllextCash_Account_Subscription.OperationAccount(Str, GetDateTime, "2");
                            bCash_Apply.Delete(Int32.Parse(id));
                            info += ("(" + ApplierRealName + "申请额度" + ApplyCount + "在" + GetDateTime + ")");
                            tag.Text = "操作成功！";
                            // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";
                        }
                    }

                    // 添加操作日志
                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "撤销经费预约", "撤销预约" + info + "的经费预约：成功");

                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manageCashApplyPerson.aspx\";</script>";
                    Response.Write(coutws);
                }
            }
        }



        protected void ddlStatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlStatas.SelectedValue == "1" || this.ddlStatas.SelectedValue == "")
            {
                this.Button_sumbit.Enabled = false;
            }
            else
            {
                this.Button_sumbit.Enabled = true;
            }
            setRowCout();
            BindData(1);//调用显示
        }

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1  and PDEL=0");
            if (this.ddlStatas.SelectedValue != "9999" && this.ddlStatas.SelectedValue != "")
            {
                sbSql.Append(" AND Statas =" + this.ddlStatas.SelectedValue);
            }
            sbSql.Append(" AND ApplierUserName ='" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + "'");
            //sbSql.Append("ORDER BY ID ");
            return sbSql.ToString();
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
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    //HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    string Statas = DataBinder.Eval(e.Row.DataItem, "Statas").ToString();

                    string datatime = DataBinder.Eval(e.Row.DataItem, "GetDateTime").ToString();
                    string Attribute = DataBinder.Eval(e.Row.DataItem, "Attribute").ToString();

                    if (Attribute == "0")
                        e.Row.Cells[3].Text = "资金卡";
                    else
                        e.Row.Cells[3].Text = "专项资金";

                    if (datatime.Contains(" 10:00:00"))
                    {
                        e.Row.Cells[4].Text = Convert.ToDateTime(datatime).ToString("yyyy-MM-dd").ToString() + " 上午";
                    }
                    else
                    {
                        e.Row.Cells[4].Text = Convert.ToDateTime(datatime).ToString("yyyy-MM-dd").ToString() + " 下午";
                    }

                    //// string CONTENTS = DataBinder.Eval(e.Row.DataItem, "CONTENTS").ToString();
                    //string NAME = DataBinder.Eval(e.Row.DataItem, "NAME").ToString();
                    //string IsRead = DataBinder.Eval(e.Row.DataItem, "IsRead").ToString();
                    //hid.Value = ID;
                    ////e.Row.Cells[3].Text = CONTENTS;
                    //e.Row.Cells[2].Text = "<a href='showHistory.aspx?id=" + ID + "' title='操作记录查看' target='_self' rel='gb_page_center[726,400]''>" + CardName + "</a>";
                    
                    if (Statas == "0")
                    {
                        e.Row.Cells[8].Text = "待审核";
                    }
                    else if (Statas == "1")
                    {
                        e.Row.Cells[8].Text = "审核通过";
                    }
                    else if (Statas == "2")
                    {
                        e.Row.Cells[8].Text = "<font color='red'>审核不通过</font>";
                    }
                    else if (Statas == "3")
                    {
                        CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("CheckBox_choose");
                        cb.Enabled = false;
                        e.Row.Cells[8].Text = "审核完成";
                    }
                }
            }
            catch
            {
            }
        }
    }
}
