using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace Dianda.Web.Admin.sysTongji
{
    public partial class DataStatistics : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();

        #region 付全文  2014-2-11  页面初始化加载
        /// <summary>
        /// 页面初始化加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindDataToddlYear();
            }
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 统计管理 ";
        } 
        #endregion

        #region 付全文  2014-2-11  绑定年份
        /// <summary>
        /// 绑定年份
        /// </summary>
        private void bindDataToddlYear()
        {
            DataTable dt = pageControl.doSql("select distinct CONVERT(varchar(4) , [DATETIME], 112 ) as [year] from FaceShowMessage  order by [year]").Tables[0];
            this.ddlYear.DataSource = dt;
            this.ddlYear.DataTextField = "year";
            this.ddlYear.DataValueField = "year";
            this.ddlYear.DataBind();
            this.ddltoYear.DataSource = dt;
            this.ddltoYear.DataTextField = "year";
            this.ddltoYear.DataValueField = "year";
            this.ddltoYear.DataBind();
        } 
        #endregion

        #region 付全文  2014-2-11  统计按钮
        /// <summary>
        /// 统计按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            string year = this.ddlYear.SelectedValue;
            string month = this.ddlMonth.SelectedValue;
            string toyear = this.ddltoYear.SelectedValue;
            string tomonth = this.ddltoMonth.SelectedValue;
            int Iyear = Convert.ToInt32(year);
            int Imonth = Convert.ToInt32(month);
            int Itoyear = Convert.ToInt32(toyear);
            int Itomonth = Convert.ToInt32(tomonth);

            bool flag = true;
            string time = year;
            if (Iyear == Itoyear)
            {
                if (Imonth > Itomonth)
                {
                    flag = false;
                    Response.Write("<script>alert('同年起始月份不能大于结束月份！')</script>");
                }
                else
                {
                    if (month != "-1" && tomonth == "-1" || month == "-1" && tomonth != "-1")
                    {
                        flag = false;
                        Response.Write("<script>alert('起始月份和结束月份必须同时选择！')</script>");
                    }
                    if (month != "-1")
                        time += month;
                    time = time + "-" + toyear;
                    if (tomonth != "-1")
                        time += tomonth;
                }
            }
            else if (Iyear < Itoyear)
            {
                if (month != "-1" && tomonth == "-1" || month == "-1" && tomonth != "-1")
                {
                    flag = false;
                    Response.Write("<script>alert('起始月份和结束月份必须同时选择！')</script>");
                }
                if (month != "-1")
                    time += month;
                time = time + "-" + toyear;
                if (tomonth != "-1")
                    time += tomonth;  
            }
            else
            {
                flag = false;
                Response.Write("<script>alert('起始年份不能大于结束年份！')</script>");
            }

            if(flag)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "open", "window.open('ExcelDataStatistics.aspx?time=" + time + "');", true);
        } 
        #endregion
    }
}
