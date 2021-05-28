﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.budgetManage.department
{
   public partial class showHistoryAll : System.Web.UI.Page
   {
		#region 参数
		public string PageRole
		{
			get
			{
				if (ViewState["PageRole"] != null)
					return ViewState["PageRole"].ToString();
				return "";
			}
			set { ViewState["PageRole"] = value; }
		}
		public string snm
		{
			get
			{
				if (ViewState["snm"] != null)
					return ViewState["snm"].ToString();
				return "";
			}
			set { ViewState["snm"] = value; }
		}
		public string nowPaging
		{
			get
			{
				if (ViewState["nowPaging"] != null)
					return ViewState["nowPaging"].ToString();
				return "1";
			}
			set { ViewState["nowPaging"] = value; }
		}

		public int pageSize = 20;

		#endregion

		Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
		Model.Cash_Apply_History mCash_Apply_History = new Dianda.Model.Cash_Apply_History();
		BLL.Cash_Apply_History bCash_Apply_History = new Dianda.BLL.Cash_Apply_History();
		BLL.Cash_CardsDetail bllCash_CardsDetail = new Dianda.BLL.Cash_CardsDetail();
		COMMON.common common = new COMMON.common();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//判断当前页面是从哪个入口进来的，PageRole=manage是可以进行操作，如果不是则只能查看 2012-4-13修改
				if (Request["PageRole"] != null)
					PageRole = common.cleanXSS(Request["PageRole"].ToString());

				if (Request["snm"] != null)
					snm = common.cleanXSS(Request["snm"].ToString());

				this.txtJF.Text = snm;

				if (Request["nowPaging"] != null)
					nowPaging = common.cleanXSS(Request["nowPaging"].ToString());

				BindData();

				if (null != Request["role"] && Request["role"].ToString().Equals("manager"))
				{
					td_left.Visible = false;
					/*设置模板页中的管理值*/
					//(Master.FindControl("Label_navigation") as Label).Text = "经费 > 资金卡查询 > 资金卡汇总统计";
					/*设置模板页中的管理值*/
				}
				else
				{
					td_left.Visible = true;
					/*设置模板页中的管理值*/
					(Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 > 部门预算汇总统计";
					/*设置模板页中的管理值*/
				}

				switch (PageRole)
				{
					case "viewer":
						OAleftmenu_Show1.Visible = true;
						break;
					default:    //付全文    2013-4-16   其他权限人员无记账功能
						this.ViewState["showHistoryGoto"] = 1;
						break;
				}
			}
		}

		protected void BindData()
		{
			try
			{
				string swhere = " 1=1 ";
				//swhere += string.Format(" and budgetName like %{0}%",this.txtJF);
				DataTable DT = new DataTable();
				DT = new COMMON.common().GetDatePaging(pageSize, int.Parse(nowPaging), "vBudget_Department_Statistical", "*", "ID", swhere, "", "", "");
				this.GridView2.DataSource = DT;
				this.GridView2.DataBind();

				common.GroupRows(GridView2, 10, 10);
				common.GroupRows(GridView2, 10, 11);
				common.GroupRows(GridView2, 10, 12);
				//ShowPaging(sqlAll);

			}
			catch
			{ }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			//try
			//{
			//	if (e.Row.RowType == DataControlRowType.DataRow)
			//	{
			//		e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
			//		e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

			//		DataRowView drv = (DataRowView)e.Row.DataItem;

			//		((Label)e.Row.FindControl("labID")).Text = (((int.Parse(nowPaging) - 1) * pageSize) + (e.Row.RowIndex + 1)).ToString();
			//		((Label)e.Row.FindControl("BalanceAll")).Text = drv.Row["OldbalanceAll"].ToString();

			//		if (drv.Row["CardID"] != null && drv.Row["CardID"] != System.DBNull.Value)
			//		{
			//			DataTable DT = new DataTable();
			//			string strSQL = "Select * From vCash_Apply_History Where CashCertificateID=" + common.SafeString(drv.Row["CardID"].ToString());
			//			DT = pageControl.doSql(strSQL).Tables[0];
			//			if (DT.Rows.Count > 0)
			//			{
			//				decimal lwf = 0;
			//				decimal cf = 0;
			//				decimal zlf = 0;
			//				decimal hwf = 0;
			//				decimal jtf = 0;
			//				decimal qt = 0;
			//				decimal ed = Convert.ToDecimal(drv.Row["OldbalanceAll"]);


			//				for (int i = 0; i < DT.Rows.Count; i++)
			//				{
			//					if (DT.Rows[i]["ControlInfo"] != null)
			//					{
			//						string cif = DT.Rows[i]["ControlInfo"].ToString();
			//						string[] _arr = cif.Split('|');
			//						if (_arr.Length > 0)
			//						{
			//							for (int j = 0; j < _arr.Length; j++)
			//							{
			//								string[] a = _arr[j].Split(',');
			//								if (a.Length == 3)
			//								{
			//									switch (a[1])
			//									{
			//										case "劳务费":
			//											lwf += decimal.Parse(a[2]);
			//											break;
			//										case "餐费":
			//											cf += decimal.Parse(a[2]);
			//											break;
			//										case "资料费":
			//											zlf += decimal.Parse(a[2]);
			//											break;
			//										case "会务费":
			//											hwf += decimal.Parse(a[2]);
			//											break;
			//										case "交通费":
			//											jtf += decimal.Parse(a[2]);
			//											break;
			//										case "其他":
			//											qt += decimal.Parse(a[2]);
			//											break;
			//										default:
			//											break;

			//									}

			//								}

			//							}

			//						}

			//					}

			//				}

			//				((Label)e.Row.FindControl("labJKF")).Text = lwf.ToString();
			//				((Label)e.Row.FindControl("labCF")).Text = cf.ToString();
			//				((Label)e.Row.FindControl("labZLF")).Text = zlf.ToString();
			//				((Label)e.Row.FindControl("labHWF")).Text = hwf.ToString();
			//				((Label)e.Row.FindControl("labJTF")).Text = jtf.ToString();
			//				((Label)e.Row.FindControl("labQT")).Text = qt.ToString();
			//				((Label)e.Row.FindControl("labSYHJ")).Text = (lwf + cf + zlf + hwf + jtf + qt).ToString();
			//				((Label)e.Row.FindControl("BalanceAll")).Text = (ed + lwf + cf + zlf + hwf + jtf + qt).ToString();

			//			}
			//		}
			//		else
			//		{
			//			((Label)e.Row.FindControl("BalanceAll")).Text = "0";
			//		}


			//	}
			//}
			//catch
			//{
			//}
		}


		public string ReturnStr(string Val)
		{
			return decimal.Parse(Val) < 0 ? "<font color='red'>" + Val + "</font>" : Val;
		}


		private void ShowPaging(string sql)
		{
			DataTable dt = pageControl.doSql(sql).Tables[0];
			int totalCount = dt.Rows.Count;
			if (totalCount == 0)
			{
				tabUsGridPaging.Visible = false;
				return;
			}
			else
			{
				tabUsGridPaging.Visible = true;
			}
			int totalPage = 0;
			if (pageSize != 0)
			{
				if ((totalCount % pageSize) > 0)
					totalPage = (totalCount / pageSize) + 1;
				else
					totalPage = (totalCount / pageSize) + 0;
			}
			else
			{
				totalPage = 0;
			}

			if (int.Parse(nowPaging) == 1)
				this.homePage.Visible = false;
			else
				this.homePage.Visible = true;

			if (int.Parse(nowPaging) - 1 < 1)
				this.firstPage.Visible = false;
			else
				this.firstPage.Visible = true;

			if (int.Parse(nowPaging) + 1 > totalPage)
				this.nextPage.Visible = false;
			else
				this.nextPage.Visible = true;

			if (int.Parse(nowPaging) >= totalPage)
				this.lastPage.Visible = false;
			else
				this.lastPage.Visible = true;

			this.totalRecord.Text = "共" + totalCount + "条";
			this.totalPage.Text = "共" + totalPage + "页";
			this.nowPage.Text = "当前第" + nowPaging + "页";

			this.targetPage.Items.Clear();
			for (int i = 1; i <= totalPage; i++)
			{
				ListItem li = new ListItem(i.ToString(), i.ToString());
				if (i == int.Parse(nowPaging))
					li.Selected = true;
				this.targetPage.Items.Add(li);
			}
		}

		protected void btnSelect_Click(object sender, EventArgs e)
		{
			Response.Redirect("showHistoryAll.aspx?PageRole=" + PageRole + "&nowPaging=1&snm=" + this.txtJF.Text.Trim());
		}

		protected void homePage_Click(object sender, EventArgs e)
		{
			Response.Redirect("showHistoryAll.aspx?PageRole=" + PageRole + "&nowPaging=1&snm=" + this.txtJF.Text.Trim());
		}

		protected void firstPage_Click(object sender, EventArgs e)
		{
			int p = int.Parse(nowPaging);
			Response.Redirect("showHistoryAll.aspx?PageRole=" + PageRole + "&nowPaging=" + (p - 1).ToString() + "&snm=" + this.txtJF.Text.Trim());
		}

		protected void nextPage_Click(object sender, EventArgs e)
		{
			int p = int.Parse(nowPaging);
			Response.Redirect("showHistoryAll.aspx?PageRole=" + PageRole + "&nowPaging=" + (p + 1).ToString() + "&snm=" + this.txtJF.Text.Trim());
		}

		protected void lastPage_Click(object sender, EventArgs e)
		{
			int p = int.Parse(this.targetPage.Items[targetPage.Items.Count - 1].Value);
			Response.Redirect("showHistoryAll.aspx?PageRole=" + PageRole + "&nowPaging=" + p.ToString() + "&snm=" + this.txtJF.Text.Trim());
		}

		protected void targetPage_SelectedIndexChanged(object sender, EventArgs e)
		{
			int p = int.Parse(this.targetPage.SelectedValue);
			Response.Redirect("showHistoryAll.aspx?PageRole=" + PageRole + "&nowPaging=" + p.ToString() + "&snm=" + this.txtJF.Text.Trim());
		}

		protected void btnReport_Click(object sender, EventArgs e)
		{

			DataTable DT = new DataTable();
			DT = pageControl.doSql("select * from vDepartment_Budget_Statistical").Tables[0];

			DataTable dt = DT;
			this.GridView2.DataSource = dt;
			this.GridView2.DataBind();
			this.GridView2.Visible = true;

			Response.Clear();
			Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode("部门经费统计" + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls", Encoding.UTF8).ToString());
			Response.Charset = "gb2312";
			Response.ContentType = "application/ms-excel";
			this.EnableViewState = false;
			System.IO.StringWriter stringWrite = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
			GridView2.RenderControl(htmlWrite);
			string strExcel = stringWrite.ToString();
			//去除超链接 
			strExcel = Regex.Replace(strExcel, "<a (.*?)>", "", RegexOptions.Compiled);
			strExcel = Regex.Replace(strExcel, "</a>", "");
			Response.Write(strExcel);
			Response.End();
		}

		public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
		{
			// Confirms that an HtmlForm control is rendered for
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{

		}
	}
}