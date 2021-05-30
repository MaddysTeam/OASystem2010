using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.budgetManage.department
{
	public partial class showHistory : System.Web.UI.Page
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

		public string BudgetID {
			get
			{
				if (ViewState["BudgetId"] != null)
					return ViewState["BudgetId"].ToString();
				return "";
			}
			set { ViewState["BudgetId"] = value; }
		}


		#endregion

		Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
		Model.Budget_Apply_History budget_Apply_History = new Dianda.Model.Budget_Apply_History();
		BLL.Budget_Apply_History bBudget_Apply_History = new Dianda.BLL.Budget_Apply_History();
		BLL.Budget_Detail budget_DetailBll = new Dianda.BLL.Budget_Detail();
		COMMON.common common = new COMMON.common();

		string hztotal = "";
		string hzActionBalance = "0";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//判断当前页面是从哪个入口进来的，PageRole=manage是可以进行操作，如果不是则只能查看 2012-4-13修改
				if (Request["PageRole"] != null)
					PageRole = common.cleanXSS(Request["PageRole"].ToString());

				BudgetID = Request["id"].ToString();

				//显示部门子项目预算的基本信息
				ShowInitInfo(BudgetID);

				BindSummaryData(BudgetID);

				SetRowCount(BudgetID);

				BindDetailData(BudgetID);

				if (null != Request["role"] && Request["role"].ToString().Equals("manager"))
				{
					td_left.Visible = false;
					Button_jz.Visible = false;
					//Button_cancel.Visible = false;
					/*设置模板页中的管理值*/
					(Master.FindControl("Label_navigation") as Label).Text = "经费 > 部门预算查询 > 子项目预算明细";
					/*设置模板页中的管理值*/
				}
				else
				{
					td_left.Visible = true;
					Button_jz.Visible = true;
					//Button_cancel.Visible = true;
					/*设置模板页中的管理值*/
					(Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 > 部门预算管理 > 子项目预算明细";
					/*设置模板页中的管理值*/
				}

				switch (PageRole)
				{
					case "viewer":
						OAleftmenu_Show1.Visible = true;
						ShowButton(false);
						break;
					case "manage":
						OAleftmenu1.Visible = true;
						ShowButton(true);
						break;
					default:    //付全文    2013-4-16   其他权限人员无记账功能
						this.Button_jz.Visible = false;
						this.ViewState["showHistoryGoto"] = 1;
						break;
				}
			}
		}

		public void ShowButton(bool b)
		{
			Button_jz.Visible = b;
		}

		protected void ShowInitInfo(string ID)
		{
			try
			{
				string sql = " SELECT * FROM vBudget_Department_List WHERE id='" + common.SafeString(ID) + "' order by id";
				DataTable DT = new DataTable();
				DT = pageControl.doSql(sql).Tables[0];
				if (DT.Rows.Count > 0)
				{
					//预算名称
					LB_Name.Text = DT.Rows[0]["BudgetName"].ToString();
					//所属项目
					LB_ParentBudget.Text = DT.Rows[0]["ParentBudgetName"].ToString();
					//项目负责人
					LB_Managers.Text = DT.Rows[0]["ManagerIds"].ToString();
					//审批人
					LB_Approver.Text = DT.Rows[0]["Approver"].ToString();
					//预算经费编号
					LB_BudgetCode.Text = DT.Rows[0]["Code"].ToString();
					//预算经费
					LB_LimitNumbers.Text = DT.Rows[0]["Balance"].ToString();
					//总余额
					LB_YEBalance.Text = DT.Rows[0]["KYBalance"].ToString();
					//预算开始时间
					LB_StartTime.Text = DT.Rows[0]["StartTime"].ToString();
					//预算结束时间
					LB_EndTime.Text = DT.Rows[0]["EndTime"].ToString();
					//所属专项资金
					//LB_SpecialFundsName.Text = DT.Rows[0]["SpecialFundsName"].ToString();
					//所属帐户
					//LB_AccountName.Text = DT.Rows[0]["AccountName"].ToString();
					//所属预算报告
					//LB_SFOrderName.Text = "<a href='" + DT.Rows[0]["BudgetList"].ToString() + "' target='_blank'>" + DT.Rows[0]["SFOrderName"].ToString() + "</a>";

					//LB_Info.Text = "&nbsp;可用金额调整情况：<br>" + DT.Rows[0]["TEMP0"].ToString();


					//DList_YSJE.DataSource = DT;
					//DList_YSJE.DataBind();
					//DList_YSJE.RepeatColumns = DT.Rows.Count;

					//DList_KYJE.DataSource = DT;
					//DList_KYJE.DataBind();
					//DList_KYJE.RepeatColumns = DT.Rows.Count;

					//DList_DQYE.DataSource = DT;
					//DList_DQYE.DataBind();
					//DList_DQYE.RepeatColumns = DT.Rows.Count;
				}
				else
				{
					LB_MSG.Text = "暂无该预算的相关信息！";
				}
			}
			catch (Exception e)
			{
			}
		}

		private void BindSummaryData(string id)
		{
			string strSQL = string.Format(@"Select '总计' as Title, LabourBudget,MeetingBudget,BussinessTripBudget,BussinessBudget,GovBudget,PublishBudget,OtherBudget
				From vBudget_Child_Apply_Detail  Where id={0} 
                union all
                Select '预算金额' as Title, LabourBudget,MeetingBudget,BussinessTripBudget,BussinessBudget,GovBudget,PublishBudget,OtherBudget
				From vBudget_Child_Detail  Where id={0}", common.SafeString(id));

			DataTableCollection dtc = pageControl.doSql(strSQL).Tables;
			DataTable dt = new DataTable();
			if (dtc != null && dtc.Count > 0)
			{
				dt = dtc[0];
				DataRow currentBalanceRow = dt.NewRow(); // 余额 = 可用- 记账总额
				currentBalanceRow[0] = "当前余额";
				double applyValue = 0, balance = 0;
				for (int i = 1; i < dt.Columns.Count; i++)
				{
					applyValue = double.Parse(dt.Rows[0][i].ToString());
					balance= double.Parse(dt.Rows[0][i].ToString());
					if(applyValue<0)
						currentBalanceRow[i] = double.Parse(dt.Rows[1][i].ToString()) + double.Parse(dt.Rows[0][i].ToString());
					else
						currentBalanceRow[i] = double.Parse(dt.Rows[1][i].ToString()) - double.Parse(dt.Rows[0][i].ToString());
				}

				dt.Rows.Add(currentBalanceRow);
			}

			GV_Summary.DataSource = dt;
			GV_Summary.DataBind();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
				{
					e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
					e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

					string NOTES = DataBinder.Eval(e.Row.DataItem, "NOTES").ToString();

					//调整说明
					//6,研讨,0|7,撰稿,-0.4|8,餐饮,0|9,资料,-800|10,差旅,0|11,邮资,-0.2|12,办公,-0.4|13,奖励,0|14,维护,0|15,其他,-200
					string ControlInfo = DataBinder.Eval(e.Row.DataItem, "ControlInfo").ToString();

					string[] ControlInfos = ControlInfo.Split('|');
					int k = 1;
					if (ControlInfos.Length > 0)
					{
						for (int i = 0; i < ControlInfos.Length; i++)
						{
							string[] cash = ControlInfos[i].Split(',');
							if (cash.Length > 0)
							{
								k++;
								e.Row.Cells[i + 1].Text = cash[2].ToString().Equals("0") ? "-" : cash[2].ToString();
								hztotal = hztotal + e.Row.Cells[i + 1].Text + ",";
							}
						}
						hztotal = hztotal.Substring(0, hztotal.Length - 1) + "|";
					}

					string DoType = DataBinder.Eval(e.Row.DataItem, "DoType").ToString();
					string ActionBalance = "";
					if (DoType.Contains("增加"))
					{
						ActionBalance = DoType.Replace("增加", "+").Replace("元", "");
					}
					else
					{
						ActionBalance = DoType.Replace("减少", "-").Replace("元", "");
					}
					// e.Row.Cells[k].Text = ActionBalance;
					e.Row.Cells[k].Text = "<a href='#' title='" + NOTES + "' style='text-decoration: none'>" + ActionBalance + "</a>";
					//合计操作总额
					hzActionBalance = (decimal.Parse(hzActionBalance) + decimal.Parse(ActionBalance)).ToString();
				}
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
			this.Response.Redirect("list.aspx?role=manage");
		}

		/// <summary>
		/// 记帐
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_jz_Click(object sender, EventArgs e)
		{
			Response.Redirect("addHistory.aspx?id=" + common.cleanXSS(Request["id"]));

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
			SetRowCount(BudgetID);
			BindDetailData(BudgetID,page);
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
			SetRowCount(BudgetID);
			BindDetailData(BudgetID, page);
		}

		/// <summary>
		/// 获取到当前数据集中总共有多少条记录
		/// </summary>
		private void SetRowCount(string id)
		{
			try
			{
				string strSQL = "SELECT ID FROM vBudget_User_Apply WHERE BudgetID="+common.SafeString(id);
				DataTable dt = new DataTable();
				dt = pageControl.doSql(strSQL).Tables[0];

				if (dt.Rows.Count > 0)
				{
					dtrowsHidden.Value = dt.Rows.Count.ToString();
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

		private void BindDetailData(string id, int pageIndex = 1)
		{
			DataTable dt = new DataTable();
			string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
			int alltiaoshuInt = int.Parse(allTiaoshu);
			dt = pageControl.GetList_FenYe_Common(" BudgetId=" + id, pageIndex, GV_Summary.PageSize, alltiaoshuInt, "vBudget_User_Apply", "AddTime").Tables[0];
			pageIndex = pageControl.pageindex(pageIndex, GV_Summary.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
			if (dt.Rows.Count > 0)
			{
				string rowNumberCol = "PX";
				dt.Columns.Add(rowNumberCol, typeof(string));
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					dt.Rows[i][rowNumberCol] = i + 1;
				}

				GV_Details.Visible = true;
				GV_Details.DataSource = dt;
				GV_Details.DataBind();
				LB_MSG.Text = "";

				pageControl.SetSelectPage(pageIndex, int.Parse(dtrowsHidden.Value.ToString()), DDL_ToPage, GV_Details.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
				pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
			}
			else
			{
				GV_Details.Visible = false;
				notice.Text = "该预算经费暂无记帐的操作记录！";
			}
		}

	}
}
