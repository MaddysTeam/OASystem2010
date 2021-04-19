using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web
{
	public partial class modifypwd : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
		}


		/// <summary>
		/// 当点击修改密码时触发事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_submit_onclick(object sender, EventArgs e)
		{
			try
			{
				COMMON.common commons = new Dianda.COMMON.common();
				//获取到登陆人员的基本信息
				Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

				BLL.USER_Users user_bll = new Dianda.BLL.USER_Users();

				//登陆用户的原始密码（即登陆密码）
				string oldpwd = user_model.PASSWORD.ToString();
				//用户输入的旧密码
				string pwd1 = commons.GetMD5(TB_OLDPWD.Text.ToString().Trim());
				//用户输入的新密码
				string newpwd = commons.GetMD5(TB_NEWPWD1.Text.ToString().Trim());

				//如果旧密码输入的是正确的，则修改密码
				if (pwd1.Equals(oldpwd))
				{
					user_model.PASSWORD = newpwd;

					user_bll.Update(user_model);


					string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"密码修改成功! \");window.close();</script>";

					Response.Write(coutws);

					//添加操作日志
					Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
					bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "修改密码", user_model.REALNAME + "(" + user_model.USERNAME + ")" + "密码修改成功");
					//添加操作日志

				}
				else
				{
					Label_tag.Text = "对不起，您的旧密码输入不正确! 请重新输入";
					TB_OLDPWD.Text = "";
					TB_OLDPWD.Focus();
				}

			}
			catch
			{
				Label_tag.Text = "对不起，密码修改过程中发生错误！请稍后再试";
			}

		}
	}
}
