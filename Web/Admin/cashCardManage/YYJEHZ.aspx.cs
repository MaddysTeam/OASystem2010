using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Dianda.Web.Admin.cashCardManage
{
	public partial class YYJEHZ : System.Web.UI.Page
	{
		BLL.YYJEHZ bYYJEHZ = new Dianda.BLL.YYJEHZ();

		protected void Page_Load(object sender, EventArgs e)
		{

			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			if (!IsPostBack)
			{
				ShowList();
			}
		}
		/// <summary>
		/// 显示全部
		/// </summary>
		public void ShowList()
		{
			DataTable dt = bYYJEHZ.GetYYJEHZ();

			GridView1.DataSource = dt;
			GridView1.DataBind();

			DDList_RQ.DataSource = dt;
			DDList_RQ.DataTextField = "GetDateTime";
			DDList_RQ.DataValueField = "GetDateTime";
			DDList_RQ.DataBind();

			DDList_RQ.Items.Remove(DDList_RQ.Items.FindByText("合计"));
			DDList_RQ.Items.Insert(0, new ListItem("全部", ""));
		}

		protected void DDList_RQ_SelectedIndexChanged(object sender, EventArgs e)
		{
			string RQ = DDList_RQ.SelectedValue.ToString();
			DataTable dt = null;
			if (RQ == "")
			{
				dt = bYYJEHZ.GetYYJEHZ();
			}
			else
			{
				dt = bYYJEHZ.GetYYJEHZ(RQ);
			}

			GridView1.DataSource = dt;
			GridView1.DataBind();
		}
	}
}
