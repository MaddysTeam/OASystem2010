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
    public partial class manageCashCard : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_Cards mCash_Cards = new Dianda.Model.Cash_Cards();
        BLL.Cash_Cards bCash_Cards = new Dianda.BLL.Cash_Cards();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "经费 > 资金卡查询 ";
                /*设置模板页中的管理值*/
                string count = dtrowsHidden.Value.ToString();
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
                // SetCardMessage();
                BindData(pageindex_int);

            }
        }

        //private void SetCardMessage()
        //{
        //    string strSQL = "SELECT ID FROM Cash_Message WHERE IsRead=0";
        //    DataTable dt = new DataTable();
        //    dt = pageControl.doSql(strSQL).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        this.lblshowMessage.Text = "<a onclick=\"window.open('showMessage.aspx', '_blank', 'height=550, width=800, top=200, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')\" class=\"zjk_tongz\"> 新设资金卡通知(" + dt.Rows.Count + ")</a>";
        //        // this.Button_Message.Text = "新设资金卡通知(" + dt.Rows.Count + ")";
        //    }
        //    else
        //    {
        //        this.lblshowMessage.Text = "<a onclick=\"window.open('showMessage.aspx', '_blank', 'height=550, width=800, top=200, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')\"> 新设资金卡通知</a>";
        //    }
        //}

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout()
        {
            try
            {
                string strSQL = "SELECT ID FROM vCash_Cards WHERE " + SQLCondition();
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
                dt = pageControl.GetList_FenYe_Common(SQLCondition(), pageindex, GridView1.PageSize, alltiaoshuInt, "vCash_Cards", "ID").Tables[0];
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

        ///// <summary>
        ///// 点击新设资金卡通知按钮触发的事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void Button_Message_onclick(object sender, EventArgs e)
        //{
        //    Response.Write("<script>window.open('showMessage.aspx', '_blank', 'height=400, width=600, top=400, left=400, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')</script>");
        //}

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 ");
            if (DDL_SF.SelectedValue.ToString().Equals("0"))
            {
                sbSql.Append(" AND CardholderUserName ='" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + "' ");

            }else if(DDL_SF.SelectedValue.ToString().Equals("1"))
            {
                sbSql.Append(" AND AssignChecker ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "' ");
            }
            else if (DDL_SF.SelectedValue.ToString().Equals("2"))
            {
                sbSql.Append(" AND CheckerHistory like '%;" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ":%'");
            }
            return sbSql.ToString();
        }

        /// <summary>
        /// 筛选条件发生改变时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_SF_Change(object sender, EventArgs e)
        {
            try
            {
                if (DDL_SF.SelectedValue.ToString().Equals("0"))
                {
                    LB_SF.Text = "作为资金卡的持卡人所拥有的资金卡！";

                }else if(DDL_SF.SelectedValue.ToString().Equals("1"))
                {
                    LB_SF.Text = "作为经费审批人的预算报告所对应的资金卡！";
                }
                else if (DDL_SF.SelectedValue.ToString().Equals("2"))
                {
                    LB_SF.Text = "作为预算审批人审批过的预算报告所对应的资金卡！";
                }

                setRowCout();
                BindData(1);
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
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    //HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    string CardName = DataBinder.Eval(e.Row.DataItem, "CardName").ToString();
                    string CardNum = DataBinder.Eval(e.Row.DataItem, "CardNum").ToString();

                    string BudgetList = DataBinder.Eval(e.Row.DataItem, "BudgetList").ToString();
                    string SFOrderName = DataBinder.Eval(e.Row.DataItem, "SFOrderName").ToString();
                    
                    //e.Row.Cells[1].Text = "<a href='showHistory.aspx?id=" + ID + "&role=manager' title='" + CardNum + "'>" + CardName + "</a>";

                    e.Row.Cells[1].Text = "<a href='showHistory.aspx?id=" + ID + "&role=manager'>" + CardName + "</a>";

                    e.Row.Cells[7].Text = "<a href='" + BudgetList + "' target='_blank'>" + SFOrderName + "</a>";
                }
            }
            catch
            {
            }
        }
    }
}
