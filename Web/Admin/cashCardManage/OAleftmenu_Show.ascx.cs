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
	public partial class OAleftmenu_Show : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
		}
	}
}