using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.cashCardManage
{
	public partial class showMessageDetail : System.Web.UI.Page
	{
		Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
		Dianda.COMMON.common common = new Dianda.COMMON.common();
		Model.Cash_Message mCash_Message = new Dianda.Model.Cash_Message();
		BLL.Cash_Message bCash_Message = new Dianda.BLL.Cash_Message();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
				return;
			}
			if (!IsPostBack)
			{
				string id = common.RequestSafeString(Request["id"].ToString(), 50);
				BindData(id);
			}
		}


		private void BindData(string id)
		{
			DataTable dt = new DataTable();
			string strSQL = "Select * From vCash_Message Where ID=" + common.SafeString(id);
			dt = pageControl.doSql(strSQL).Tables[0];
			if (dt.Rows.Count > 0)
			{
				lblCardName.Text = dt.Rows[0]["CardName"].ToString();
				lblCardholderRealName.Text = dt.Rows[0]["CardholderRealName"].ToString();
				lblDepartmentName.Text = dt.Rows[0]["DepartmentName"].ToString();
				lblProjectName.Text = dt.Rows[0]["ProjectName"].ToString();
				lblLimitNums.Text = dt.Rows[0]["LimitNums"].ToString();
				lblApproverRealName.Text = dt.Rows[0]["ApproverRealName"].ToString();
				lblDATETIME.Text = dt.Rows[0]["DATETIME"].ToString();
				if (dt.Rows[0]["IsRead"].ToString() == "0")
				{
					lblIsRead.Text = "未读";
				}
				else
				{
					lblIsRead.Text = "已读";
				}

				lblReadTime.Text = dt.Rows[0]["ReadTime"].ToString();
				lblDoUserID.Text = dt.Rows[0]["DoUserID"].ToString();
				txtDoNotes.Text = dt.Rows[0]["DoNotes"].ToString();
			}
		}

		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
				{
					e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
					e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");


					string DoType = DataBinder.Eval(e.Row.DataItem, "DoType").ToString();
					if (DoType == "1")
					{
						e.Row.Cells[3].Text = "增加";
					}
					else if (DoType == "2")
					{
						e.Row.Cells[3].Text = "减少";
					}
				}
			}
			catch
			{
			}
		}

		/// <summary>
		///点击确定按钮触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_sumbit_Click(object sender, EventArgs e)
		{
			try
			{
				mCash_Message = new Dianda.Model.Cash_Message();
				mCash_Message = bCash_Message.GetModel(Int32.Parse(Request["id"].ToString()));
				mCash_Message.IsRead = 1;
				mCash_Message.ReadTime = DateTime.Now;
				mCash_Message.DoNotes = this.txtDoNotes.Text.Trim();
				mCash_Message.DoUserID = ((Model.USER_Users)Session["USER_Users"]).USERNAME;
				bCash_Message.Update(mCash_Message);

				//添加操作日志
				Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
				Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
				bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "对" + this.lblCardName.Text + "资金卡通知阅读", "确定阅读" + this.lblCardName.Text + "资金卡通知:成功");
				//添加操作日志
				this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "key", "window.close();window.showModalDialog('showMessage.aspx','','dialogWidth=726px;dialogHeight=400px');window.location=window.location", true);
			}
			catch
			{

			}
		}

		/// <summary>
		/// 点击取消按钮触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_cancel_Click(object sender, EventArgs e)
		{
			//Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "window.returnValue = 'refresh';parent.parent.location.reload();", true); 
			this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "key", "window.close();window.showModalDialog('showMessage.aspx','','dialogWidth=726px;dialogHeight=400px');window.location=window.location", true);
		}
	}
}
