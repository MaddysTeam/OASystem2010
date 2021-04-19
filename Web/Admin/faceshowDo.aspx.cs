using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin
{
	public partial class faceshowDo : System.Web.UI.Page
	{
		BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();
		Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			try
			{

				string indexnum = Request["ID"];
				mFaceShowMessage = bFaceShowMessage.GetModel(int.Parse(indexnum));
				if (mFaceShowMessage != null)
				{
					mFaceShowMessage.IsRead = 1;
					mFaceShowMessage.ReadTime = DateTime.Now;
					bFaceShowMessage.Update(mFaceShowMessage);
				}
			}
			catch
			{
			}
		}
	}
}
