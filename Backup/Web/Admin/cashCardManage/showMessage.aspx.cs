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
    public partial class showMessage : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_Message mCash_Message = new Dianda.Model.Cash_Message();
        BLL.Cash_Message bCash_Message = new Dianda.BLL.Cash_Message();
        Dianda.COMMON.common common = new Dianda.COMMON.common();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string count = dtrowsHidden.Value.ToString();
                ddlIsRead.SelectedValue = "0";
                if (count.Length == 0)
                {
                    setRowCout();//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    count = dtrowsHidden.Value.ToString();
                }
                else
                {
                    count = "0";
                }
                int countint = int.Parse(count);
                string pageindex = null;//这里是为分页服务的
                if (pageindex == null || pageindex == "")
                {
                    pageindex = "1";
                }
                int pageindex_int = int.Parse(pageindex);
                BindData(pageindex_int);
                divGv.Visible = true;
                divsend.Visible = false;
            }
        }

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout()
        {
            try
            {
                string strSQL = "SELECT ID FROM vCash_Message WHERE " + SQLCondition();
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
                dt = pageControl.GetList_FenYe_Common(SQLCondition(), pageindex, GridView1.PageSize, alltiaoshuInt, "vCash_Message", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (dt.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";

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
                        cb.Checked = isCheck;
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 ");
            sbSql.Append(" and IsRead=" + this.ddlIsRead.SelectedValue);

            //sbSql.Append("ORDER BY ID ");
            return sbSql.ToString();
        }

        /// <summary>
        /// 切换是否已读下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlIsRead_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRowCout();
            BindData(1);
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
                    string CardName = DataBinder.Eval(e.Row.DataItem, "CardName").ToString();

                    //// string CONTENTS = DataBinder.Eval(e.Row.DataItem, "CONTENTS").ToString();
                    //string NAME = DataBinder.Eval(e.Row.DataItem, "NAME").ToString();
                    string IsRead = DataBinder.Eval(e.Row.DataItem, "IsRead").ToString();
                    string SendUserName = DataBinder.Eval(e.Row.DataItem, "SendUserName").ToString();
                    string SendRealName = DataBinder.Eval(e.Row.DataItem, "SendRealName").ToString();
                    //hid.Value = ID;
                    ////e.Row.Cells[3].Text = CONTENTS;
                    //e.Row.Cells[0].Text = "<a href=\"javascript:window.showModalDialog('showMessageDetail.aspx?id=" + ID + "&pageindex=" + pageindexHidden.Value + "','','dialogWidth=726px;dialogHeight=400px');window.close();\" title='查看详细' target='_self' >" + CardName + "(新建通知)" + "</a>";
                    e.Row.Cells[2].Text = SendUserName + "[" + SendRealName + "]";

                    if (IsRead == "1")
                    {
                        e.Row.Cells[3].Text = "已读";
                    }
                    else
                    {
                        e.Row.Cells[3].Text = "未读";
                    }

                    Label lb_budget = (Label)e.Row.FindControl("LB_budget");

                    string BudgetList = DataBinder.Eval(e.Row.DataItem, "BudgetList").ToString();

                    //lb_budget.Text = "<a href='" + BudgetList + "' target='_blank'>点击查看</a>";

                    if (BudgetList.Contains('@'))
                    {
                        string[] budget = BudgetList.Split('@');

                        lb_budget.Text = "<a href='" + budget[budget.Length - 1].ToString() + "' target='_blank'>点击查看</a>";
                    }
                    else
                    {
                        lb_budget.Text = "<a href='" + BudgetList + "' target='_blank'>点击查看</a>";
                    }
                }
            }
            catch
            {
            }
        }
        //链接
        /// <summary>
        /// 查看详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lk = (LinkButton)sender;
                BindData2(lk.CommandArgument.ToString());
                divGv.Visible = false;
                divsend.Visible = true;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 查看详情
        /// </summary>
        /// <param name="id"></param>
        private void BindData2(string id)
        {
            DataTable dt = new DataTable();
            string strSQL = "Select * From vCash_Message Where ID=" + id;
            dt = pageControl.doSql(strSQL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataList1.Visible = true;
                DataList1.DataSource = dt.DefaultView;
                DataList1.DataBind();
            }
            else
            {
 
            }
        }

        /// <summary>
        /// 把未读的条目直接改为已阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_YY_Click(object sender, EventArgs e)
        {
            //得到button传递的值，拆分成数组
            string _str = ((Button)sender).CommandArgument.ToString();
            string[] _str_arr = _str.Split(',');
            string _id = _str_arr[0].ToString();
            string _CardName = _str_arr[1].ToString();

            //调用已有的对象
            Model.Cash_Message mCash_Message = new Dianda.Model.Cash_Message();
            BLL.Cash_Message bCash_Message = new Dianda.BLL.Cash_Message();
            try
            {
                mCash_Message = new Dianda.Model.Cash_Message();
                mCash_Message = bCash_Message.GetModel(Int32.Parse(_id));
                mCash_Message.IsRead = 1;
                mCash_Message.ReadTime = DateTime.Now;
                mCash_Message.DoNotes = "";
                mCash_Message.DoUserID = ((Model.USER_Users)Session["USER_Users"]).USERNAME;
                bCash_Message.Update(mCash_Message);

                //添加操作日志
                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "阅读了" + _CardName, "确定阅读" + _CardName + ":已阅");

                setRowCout();
                BindData(1);
                divGv.Visible = true;
                divsend.Visible = false;   
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
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string ProjectID = DataBinder.Eval(e.Item.DataItem, "ProjectID").ToString();

            string ProjectName = DataBinder.Eval(e.Item.DataItem, "ProjectName").ToString();
            Label Lab_Project = (Label)e.Item.FindControl("Lab_Project");
            if (ProjectID.Equals("9999"))
            {
                //项目名称
                Lab_Project.Text = "暂无所属项目";
            }
            else
            {
                //项目名称
                Lab_Project.Text = ProjectName;
            }

            //预算报告路径地址
            string BudgetList = DataBinder.Eval(e.Item.DataItem, "BudgetList").ToString();
            //预算报告名称
            string BudgetName = DataBinder.Eval(e.Item.DataItem, "BudgetName").ToString();

            Label LB_budget = (Label)e.Item.FindControl("LB_budget");

            LB_budget.Text = "<a href='" + BudgetList + "' target='_blank'>" + BudgetName + "</a>";

        }
        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
        //        {
        //            e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");


        //            string DoType = DataBinder.Eval(e.Row.DataItem, "DoType").ToString();
        //            if (DoType == "1")
        //            {
        //                e.Row.Cells[3].Text = "增加";
        //            }
        //            else if (DoType == "2")
        //            {
        //                e.Row.Cells[3].Text = "减少";
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        ///// <summary>
        /////点击确定按钮触发的事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void Button_sumbit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        mCash_Message = new Dianda.Model.Cash_Message();
        //        mCash_Message = bCash_Message.GetModel(Int32.Parse(HiddenField_ID.Value));
        //        mCash_Message.IsRead = 1;
        //        mCash_Message.ReadTime = DateTime.Now;
        //        mCash_Message.DoNotes = this.txtDoNotes.Text.Trim();
        //        mCash_Message.DoUserID = ((Model.USER_Users)Session["USER_Users"]).USERNAME;
        //        bCash_Message.Update(mCash_Message);

        //        //添加操作日志
        //        Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
        //        Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
        //        bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "对" + this.lblCardName.Text + "资金卡通知阅读", "确定阅读" + this.lblCardName.Text + "资金卡通知:成功");
        //        //添加操作日志
        //        setRowCout();
        //        BindData(1);

        //        divGv.Visible = true;
        //        divsend.Visible = false;    
         
        //    }
        //    catch
        //    {

        //    }
        //}

        /// <summary>
        /// 点击取消按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "window.returnValue = 'refresh';parent.parent.location.reload();", true); 
            divGv.Visible = true;
            divsend.Visible = false;
        }


    }
}
