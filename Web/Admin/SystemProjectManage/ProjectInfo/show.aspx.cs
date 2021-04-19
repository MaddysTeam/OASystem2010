using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.SystemProjectManage.ProjectInfo
{
	public partial class show : System.Web.UI.Page
	{
		Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			if (!IsPostBack)
			{
				//项目ID
				string ID = Request["ID"];
				ShowProjectInfo(ID);
			}
		}


		/// <summary>
		/// 显示项目详情
		/// </summary>
		/// <param name="id"></param>
		protected void ShowProjectInfo(string id)
		{
			try
			{
				DataTable DT = new DataTable();
				string sql = "SELECT * FROM vProject_Projects WHERE  ID = " + id + " select CardName from dbo.Cash_Cards where ProjectID=" + id;

				DataSet set = new DataSet();
				set = pageControl.doSql(sql);
				DT = set.Tables[0];
				if (DT.Rows.Count > 0)
				{
					//项目名称
					Label_ProjectName.Text = DT.Rows[0]["NAMES"].ToString();
					//项目状态
					string Status = DT.Rows[0]["Status"].ToString();
					//删除标记
					string DELFLAG = DT.Rows[0]["DELFLAG"].ToString();

					if (DELFLAG.Equals("1"))
					{
						Label_Status.Text = "<font color='red'>已删除</font>";
					}
					else
					{
						switch (Status)
						{
							case "0":
								Label_Status.Text = "待审核";
								break;
							case "1":
								Label_Status.Text = "运行中";
								break;
							case "2":
								Label_Status.Text = "<font color='red'>审核不通过</font>";
								break;
							case "3":
								Label_Status.Text = "暂停";
								break;
							case "4":
								Label_Status.Text = "草稿箱中";
								break;
							case "5":
								Label_Status.Text = "已完成";
								break;
						}
					}

					//项目负责人
					Label_LeaderID.Text = DT.Rows[0]["LeaderRealName"].ToString() + "[" + DT.Rows[0]["LeaderUserName"].ToString() + "]";

					//经费单位
					string dw = DT.Rows[0]["CashTotal"].ToString();

					if (DT.Rows[0]["CashDw"] != null && DT.Rows[0]["CashDw"].ToString().Equals("万元"))
					{
						if (DT.Rows[0]["CashTotal"] == null || DT.Rows[0]["CashTotal"].ToString().Equals(""))
						{
							Label_CashTotal.Text = "";
						}
						else
						{
							//预计经费
							Label_CashTotal.Text = (Convert.ToDecimal(DT.Rows[0]["CashTotal"].ToString()) / 10000).ToString() + "万元";
						}
					}
					else
					{
						if (DT.Rows[0]["CashTotal"] == null || DT.Rows[0]["CashTotal"].ToString().Equals(""))
						{
							Label_CashTotal.Text = "";
						}
						else
						{
							//预计经费
							Label_CashTotal.Text = DT.Rows[0]["CashTotal"].ToString() + "元";
						}
					}

					//申请人
					Label_SendUserID.Text = DT.Rows[0]["SendUserRealName"].ToString() + "[" + DT.Rows[0]["SendUserUserName"].ToString() + "]";
					//申请时间
					Label_DATETIME.Text = Convert.ToDateTime(DT.Rows[0]["DATETIME"].ToString()).ToString("yyyy-MM-dd");
					//预计开始时间
					Label_StartTime.Text = Convert.ToDateTime(DT.Rows[0]["StartTime"].ToString()).ToString("yyyy-MM-dd");
					//预计对束时间
					Label_EndTime.Text = Convert.ToDateTime(DT.Rows[0]["EndTime"].ToString()).ToString("yyyy-MM-dd");
					//所属项目
					string ColumnsNames = DT.Rows[0]["ColumnsNames"].ToString();
					if (string.IsNullOrEmpty(ColumnsNames))
					{
						ColumnsNames = "暂无";
					}
					Lab_ColNames.Text = ColumnsNames;
					//项目概要
					Label_Overviews.Text = DT.Rows[0]["Overviews"].ToString();
					//资金卡                  
					DataTable dt2 = new DataTable();
					dt2 = set.Tables[1];
					for (int i = 0; i < dt2.Rows.Count; i++)
					{
						if (i < dt2.Rows.Count - 1)
						{
							Label_CashCardID.Text += dt2.Rows[i]["CardName"].ToString() + "，";
						}
						else { Label_CashCardID.Text += dt2.Rows[i]["CardName"].ToString(); }
					}
					//参与部门
					Label_DepartmentID.Text = DT.Rows[0]["DepartmentNames"].ToString();
					//审核人
					if (DT.Rows[0]["DoUserRealName"].ToString().Equals(""))
					{
						Label_DoUserID.Text = "";
					}
					else
					{
						Label_DoUserID.Text = DT.Rows[0]["DoUserRealName"].ToString() + "[" + DT.Rows[0]["DoUserUserName"].ToString() + "]";
					}
					//审核时间
					Label_ReadTime.Text = Convert.ToDateTime(DT.Rows[0]["ReadTime"].ToString()).ToString("yyyy-MM-dd");
					//审核意见
					Label_DoNote.Text = DT.Rows[0]["DoNote"].ToString();

					//附件地址
					if (null != DT.Rows[0]["Attachments"] && !DT.Rows[0]["Attachments"].ToString().Equals(""))
					{
						LB_fj.Text = "<a href='" + DT.Rows[0]["Attachments"].ToString() + "' target='_blank'>点击查看附件</a>";
					}
					else
					{
						td_fj.Visible = false;
						td_note.ColSpan = 2;
					}
				}
			}
			catch
			{

			}
		}
	}
}
