using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.presonPlan.OApresonmanage
{
	public partial class addNote : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
		}

		protected void Button_add_Click(object sender, EventArgs e)
		{
			//便签实体类
			Dianda.Model.Personal_Notepad notepadModel = new Dianda.Model.Personal_Notepad();
			//便签操作类
			Dianda.BLL.Personal_Notepad notepadBll = new Dianda.BLL.Personal_Notepad();
			//通用操作类
			Dianda.COMMON.common commonId = new Dianda.COMMON.common();
			try
			{
				if (TextBox_noteContent.Text.Equals("") || TextBox_noteContent.Text.Equals("便签内容不能为空"))
				{
					Label_notice.Text = "便签内容不能为空";
				}
				else
				{
					Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

					//便签内容
					notepadModel.NAMES = TextBox_noteContent.Text.ToString();
					//便签状态
					notepadModel.DELFLAG = 0;
					//建立便签时间
					notepadModel.DATETIME = DateTime.Now;
					//用户ID
					notepadModel.UserID = user_model.ID.ToString();
					//添加数据到数据库
					notepadBll.Add(notepadModel);

					//添加到日志`
					Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();

					bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加便签", "添加成功");
					// Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "location.href='test.aspx';alert('添加成功');", true);
					Label_notice.Text = "添加成功!";
				}
			}
			catch (Exception)
			{
				// Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "altert('添加失败');parent.parent.location.reload();", true);
				Label_notice.Text = "添加失败!";
			}
		}
		//取消按钮
		protected void Button_quxiao_Click(object sender, EventArgs e)
		{
			Response.Redirect("Test.aspx");
			// Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "parent.parent.location.reload();parent.parent.GB_hide();", true);
		}
	}
}
