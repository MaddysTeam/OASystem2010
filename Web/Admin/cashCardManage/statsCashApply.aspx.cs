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
    public partial class statsCashApply : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_Apply mCash_Apply = new Dianda.Model.Cash_Apply();
        BLL.Cash_Apply bCash_Apply = new Dianda.BLL.Cash_Apply();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // BindData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        protected void BindData()
        {
            try
            {
                DateTime dtBegin = new DateTime(Int32.Parse(txtBeginDate.Value.Split('-')[0]), Int32.Parse(txtBeginDate.Value.Split('-')[1]), Int32.Parse(txtBeginDate.Value.Split('-')[2]), 0, 0, 0);
                DateTime dtEnd = new DateTime(Int32.Parse(txtEndTime.Value.Split('-')[0]), Int32.Parse(txtEndTime.Value.Split('-')[1]), Int32.Parse(txtEndTime.Value.Split('-')[2]), 23, 59, 59);
                string strSQL = @"Select a.DateDay From (Select datename(yyyy, GetDateTime)+datename(mm, GetDateTime)+datename(dd, GetDateTime) as DateDay From Cash_Apply Where GetDateTime between '" + dtBegin + "' and '" + dtEnd + "') a Group By a.DateDay";
                DataTable dt = new DataTable();
                dt = pageControl.doSql(strSQL).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    this.DataList1.Visible = true;
                    this.DataList1.DataSource = dt;//指定GridView1的数据是dv
                    this.DataList1.DataBind();//将上面指定的信息绑定到GridView1上
                    tag.Text = "";
                }
                else
                {
                    this.DataList1.Visible = false;
                    tag.Text = "*没有符合条件的结果！";
                }
            }
            catch
            {

            }
        }





        /// <summary>
        ///点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_onclick(object sender, EventArgs e)
        {
            BindData();
        }



        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 ");
            DateTime dtBegin = new DateTime(Int32.Parse(txtBeginDate.Value.Split('-')[0]), Int32.Parse(txtBeginDate.Value.Split('-')[1]), Int32.Parse(txtBeginDate.Value.Split('-')[2]), 0, 0, 0);
            DateTime dtEnd = new DateTime(Int32.Parse(txtEndTime.Value.Split('-')[0]), Int32.Parse(txtEndTime.Value.Split('-')[1]), Int32.Parse(txtEndTime.Value.Split('-')[2]), 23, 59, 59);
            sbSql.Append(" AND GetDateTime between '" + dtBegin + "' and '" + dtEnd + "'");

            return sbSql.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
        //        {
        //            e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

        //            //HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
        //            string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
        //            string Statas = DataBinder.Eval(e.Row.DataItem, "Statas").ToString();

        //            //// string CONTENTS = DataBinder.Eval(e.Row.DataItem, "CONTENTS").ToString();
        //            //string NAME = DataBinder.Eval(e.Row.DataItem, "NAME").ToString();
        //            //string IsRead = DataBinder.Eval(e.Row.DataItem, "IsRead").ToString();
        //            //hid.Value = ID;
        //            ////e.Row.Cells[3].Text = CONTENTS;
        //            //e.Row.Cells[2].Text = "<a href='showHistory.aspx?id=" + ID + "' title='操作记录查看' target='_self' rel='gb_page_center[726,400]''>" + CardName + "</a>";
        //            if (Statas == "0")
        //            {
        //                e.Row.Cells[9].Text = "待审核";
        //            }
        //            else if (Statas == "1")
        //            {
        //                e.Row.Cells[9].Text = "审核通过";
        //            }
        //            else if (Statas == "2")
        //            {
        //                e.Row.Cells[9].Text = "审核不通过";
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                string DateDay = DataBinder.Eval(e.Item.DataItem, "DateDay").ToString();
                GridView GridView1 = new GridView();
                GridView1 = (GridView)e.Item.FindControl("GridView1");

                Label lblDate = new Label();
                lblDate = (Label)e.Item.FindControl("lblDate");
                lblDate.Text = DateDay.Substring(0, 4) + "-" + DateDay.Substring(4, 2) + "-" + DateDay.Substring(6, 2);
                Label lblStats = new Label();
                lblStats = (Label)e.Item.FindControl("lblStats");

                string strSQL = @"Select a.* From (Select datename(yyyy, GetDateTime)+datename(mm, GetDateTime)+datename(dd, GetDateTime) as DateDay,case Statas when 0 then '待审核' when 1 then '审核通过' when 2 then '审核不通过' end as StatasName,* From vCash_Apply) a Where DateDay='" + DateDay + "' and (Statas=0 or Statas=1)";
                DataTable dt = new DataTable();
                dt = pageControl.doSql(strSQL).Tables[0];
                double sum = 0;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        double d = double.Parse(dr["ApplyCount"].ToString());
                        sum += d;
                    }
                    lblStats.Text = "总计：" + sum.ToString();
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                }
                else
                {
                    GridView1.Visible = false;

                }

            }
        }
    }
}
