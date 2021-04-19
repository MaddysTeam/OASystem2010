using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Dianda.Web
{
	public partial class Default : Dianda.Web.OLPage
	{
		COMMON.pageControl visitlog = new Dianda.COMMON.pageControl();

		COMMON.fileUploads fileup = new Dianda.COMMON.fileUploads();
		Model.Cash_Apply modelCash_Apply = new Dianda.Model.Cash_Apply();
		BLL.Cash_Apply bllCash_Apply = new Dianda.BLL.Cash_Apply();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			if (!IsPostBack)
			{
				Response.Redirect("login.aspx");
			}
		}




	}
}
