using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.budgetManage.department
{
	public partial class showParent : System.Web.UI.Page
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

				string id = Request["id"].ToString();

				//显示部门子项目预算的基本信息
				ShowInitInfo(id);

				BindData(id);

				if (null != Request["role"] && Request["role"].ToString().Equals("manager"))
				{
					td_left.Visible = false;
					/*设置模板页中的管理值*/
					(Master.FindControl("Label_navigation") as Label).Text = "经费 > 部门预算查询 > 父项目经费明细";
					/*设置模板页中的管理值*/
				}
				else
				{
					td_left.Visible = true;
					/*设置模板页中的管理值*/
					(Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 > 部门预算管理 > 父项目经费明细";
					/*设置模板页中的管理值*/
				}

			}
		}


		protected void ShowInitInfo(string ID)
		{
			try
			{
				string sql = " SELECT BudgetName,Code FROM vBudget_Department_List WHERE parentId='" + common.SafeString(ID) + "' order by id";
				DataTable DT = new DataTable();
				DT = pageControl.doSql(sql).Tables[0];
				if (DT.Rows.Count > 0)
				{
					//预算名称
					LB_Name.Text = DT.Rows[0]["BudgetName"].ToString();
					//预算经费编号
					LB_BudgetCode.Text = DT.Rows[0]["Code"].ToString();
				}
				else
				{
					//LB_MSG.Text = "暂无该父项目经费明细的相关信息！";
				}
			}
			catch (Exception e)
			{
			}
		}

		private void BindData(string id)
		{
			string parentBudgetSql = "select DetailName,Balance,RealSpend, Balance + RealSpend as CurrentBalance from vBudget_Parent_Detail where parentId=" + common.SafeString(id);
			DataTable DT = new DataTable();
			DT = pageControl.doSql(parentBudgetSql).Tables[0];
			DList_ParentBudgetDetail.DataSource = DT;
			DList_ParentBudgetDetail.DataBind();


			string childBudgetSql = "select * from vBudget_Child_Apply_Detail where parentId=" + common.SafeString(id);
			DT = new DataTable();
			DT = pageControl.doSql(childBudgetSql).Tables[0];
			DList_ChildBudgetDetail.DataSource = DT;
			DList_ChildBudgetDetail.DataBind();
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
			//付全文    2013-4-18   修改返回逻辑
			//if (this.ViewState["showHistoryGoto"] == null)
			//{
			//   if (null != Request["role"] && Request["role"].ToString().Equals("manager"))
			//   {
			//      Response.Redirect("/Admin/cashCardManage/manageCashCard.aspx");
			//   }
			//   else
			//   {
			//      Response.Redirect("manage.aspx?role=" + PageRole + "&pageindex=" + Request["pageindex"]);
			//   }
			//}
			//else
			//{
			//   this.Response.Redirect("../person_Index.aspx");
			//}

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

		protected void DList_YSJE_ItemDataBound(object sender, DataListItemEventArgs e)
		{
			decimal YSJE = 0;
			//decimal.TryParse(Lab_YSJE.Text.Trim(), out YSJE);
			decimal Oldbalance = 0;
			decimal.TryParse(DataBinder.Eval(e.Item.DataItem, "Oldbalance").ToString(), out Oldbalance);
			//Lab_YSJE.Text = (YSJE + Oldbalance).ToString();
		}

		protected void DList_DQYE_ItemDataBound(object sender, DataListItemEventArgs e)
		{
			decimal DQYE = 0;
			//decimal.TryParse(Lab_DQYE.Text.Trim(), out DQYE);
			decimal Balance = 0;
			decimal.TryParse(DataBinder.Eval(e.Item.DataItem, "Balance").ToString(), out Balance);
			//Lab_DQYE.Text = (DQYE + Balance).ToString();
		}

		protected void DList_KYJE_ItemDataBound(object sender, DataListItemEventArgs e)
		{
			//decimal KYJE = 0;
			//decimal.TryParse(Lab_KYJE.Text.Trim(), out KYJE);
			//decimal limitNums = 0;
			//decimal.TryParse(DataBinder.Eval(e.Item.DataItem, "LimitNums").ToString(), out limitNums);
			//Lab_KYJE.Text = limitNums.ToString();// (KYJE + KYbalance).ToString();
		}
	}
}
