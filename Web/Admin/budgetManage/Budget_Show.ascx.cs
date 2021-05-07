using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.budgetManage
{
	public partial class Budget_Show : System.Web.UI.UserControl
	{
		Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();

		private static string _id;

		public string id
		{
			get { return _id; }
			set { _id = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			if (!IsPostBack)
			{
				// string id = Request["id"].ToString();
				BindData();
			}
		}

		public void BindData()
		{
			DataTable dt = new DataTable();
			string strSQL = "Select * From vCash_Cards Where id=" + _id;
			dt = pageControl.doSql(strSQL).Tables[0];
			if (dt.Rows.Count > 0)
			{
				this.lblCardName.Text = dt.Rows[0]["CardName"].ToString();
				this.lblCardNum.Text = dt.Rows[0]["CardNum"].ToString();
				this.lblCardholderRealName.Text = dt.Rows[0]["CardholderRealName"].ToString();
				this.lblDepartmentName.Text = dt.Rows[0]["DepartmentName"].ToString();
				this.lblProjectName.Text = dt.Rows[0]["ProjectName"].ToString();
				this.lblLimitNums.Text = dt.Rows[0]["LimitNums"].ToString();
				this.lblApproverRealName.Text = dt.Rows[0]["ApproverRealName"].ToString();
				this.lblStatas.Text = dt.Rows[0]["Statas"].ToString();
				//这里是不是多复制了？
				this.lblCardName.Text = dt.Rows[0]["CardName"].ToString();
				this.lblCardName.Text = dt.Rows[0]["CardName"].ToString();
				this.lblCardName.Text = dt.Rows[0]["CardName"].ToString();
				this.lblCardName.Text = dt.Rows[0]["CardName"].ToString();
				this.lblCardName.Text = dt.Rows[0]["CardName"].ToString();
				this.lblCardName.Text = dt.Rows[0]["CardName"].ToString();
			}
		}
	}
}