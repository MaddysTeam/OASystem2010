using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.budgetManage.todo
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

				//if (Request["nowPaging"] != null)
				//	nowPaging = common.cleanXSS(Request["nowPaging"].ToString());

				SetRowCount();

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
					(Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 > 待办预算汇总统计";
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

		protected void BindData(int pageIndex=1)
		{
			try
			{
				string swhere = " 1=1 ";
				if (!string.IsNullOrEmpty(txtJF.Text))
				{
					swhere += string.Format(" and BudgetName like '%{0}%'", txtJF.Text);
				}

				string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
				int alltiaoshuInt = int.Parse(allTiaoshu);
				DataTable dt = new DataTable();
				dt = pageControl.GetList_FenYe_Common(swhere, pageIndex, GridView2.PageSize, alltiaoshuInt, "vBudget_Todo_Statistical", "AddTime").Tables[0];
				pageIndex = pageControl.pageindex(pageIndex, GridView2.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
																								
				if (dt.Rows.Count > 0)
				{
					string rowNumberCol = "PX";
					dt.Columns.Add(rowNumberCol, typeof(string));
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						dt.Rows[i][rowNumberCol] = i + 1;
					}

					GridView2.Visible = true;
					GridView2.DataSource = dt;
					GridView2.DataBind();
					LB_MSG.Text = "";

					//common.GroupRows(GridView2, 10, 10);
					//common.GroupRows(GridView2, 10, 11);
					//common.GroupRows(GridView2, 10, 12);

					pageControl.SetSelectPage(pageIndex, int.Parse(dtrowsHidden.Value.ToString()), DDL_ToPage, GridView2.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
					pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
				}

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

		/// <summary>
		/// 当分页控件中的“第一页”“第二页”...发生时，触发下面的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void PageChange_Click(object sender, EventArgs e)
		{
			int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
			pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值
			SetRowCount();
			BindData(page);
		}

		/// <summary>
		/// 当分页控件中的下拉菜单触发时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DDL_ToPage_SelectedIndexChanged(object sender, EventArgs e)
		{
			int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
			pageindexHidden.Value = page.ToString();
			SetRowCount();
			BindData(page);
		}


		
		protected void btnReport_Click(object sender, EventArgs e)
		{

			DataTable DT = new DataTable();
			DT = pageControl.doSql("select * from vBudget_Todo_Statistical").Tables[0];

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
			BindData(1);
		}


		/// <summary>
		/// 获取到当前数据集中总共有多少条记录
		/// </summary>
		private void SetRowCount()
		{
			try
			{
				int count = pageControl.tableRowCout("","vBudget_Todo_Statistical","1");

				if (count > 0)
				{
					dtrowsHidden.Value = count.ToString();
				}
				else
				{
					dtrowsHidden.Value = "0";
				}
			}
			catch
			{
			}
		}

	}
}