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

namespace Dianda.Web.Admin.DocumentManage
{
	public partial class uploadfilesups : System.Web.UI.Page
	{
		COMMON.fileUploads cfup = new Dianda.COMMON.fileUploads();//通用上传判断
		Model.USER_Users user_model = new Dianda.Model.USER_Users();
		BLL.Document_FolderExt bdFExt = new Dianda.BLL.Document_FolderExt();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			try
			{
				string jscript = "function UploadComplete(){" + ClientScript.GetPostBackEventReference(Label_type, "") + "};";
				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "FileCompleteUpload", jscript, true);

				FlashUpLoad1.QueryParameters = string.Format("User={0}", FormsAuthentication.HashPasswordForStoringInConfigFile("Beniao", "MD5"));
				if (!IsPostBack)
				{

					string filetypes = cfup.getAllowFileType();//获取支持上传的文件的类型
					FlashUpLoad1.FileTypes = cfup.getAllowFileType_Up();
					FlashUpLoad1.FileTypeDescription = filetypes;
					Label_type.Text = filetypes;
					HiddenField_uid.Value = Request["ID"];
				}
			}
			catch
			{
			}
		}
	}
}
