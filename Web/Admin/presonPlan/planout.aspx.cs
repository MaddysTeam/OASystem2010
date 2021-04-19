using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.presonPlan
{
	public partial class planout : System.Web.UI.Page
	{
		COMMON.pageControl pcs = new Dianda.COMMON.pageControl();
		protected void Page_Load(object sender, EventArgs e)
		{

			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			if (!IsPostBack)
			{
				if (Session["USER_Users"] != null)
				{
					outExcel();
					ToExcel(GridView1);
				}
				else
				{
					Response.Write("没有符合条件的数据！");
				}
			}
		}
		/// <summary>
		/// 导出EXCEL
		/// </summary>
		private void outExcel()
		{
			try
			{
				string sql = "select * from vCoutPlanList";
				GridView1.DataSource = pcs.doSql(sql).Tables[0];
				GridView1.DataBind();
			}
			catch
			{
				GridView1.Visible = false;
				Response.Write("没有符合条件的数据！");

			}
		}
		public bool ToExcel(System.Web.UI.Control ctl)
		{
			try
			{
				HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=Excel.xls");
				HttpContext.Current.Response.Charset = "UTF-8";
				HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
				HttpContext.Current.Response.ContentType = "application/ms-excel";//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
				ctl.Page.EnableViewState = false;
				System.IO.StringWriter tw = new System.IO.StringWriter();
				System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
				ctl.RenderControl(hw);
				HttpContext.Current.Response.Write(tw.ToString());
				HttpContext.Current.Response.End();
				return true;
			}
			catch (Exception e)
			{
				//  _errormsg = e.Message;
				return false;
			}
		}
		public override void VerifyRenderingInServerForm(Control control)
		{
			base.VerifyRenderingInServerForm(control);
		}
	}
}
