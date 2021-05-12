using Dianda.Model;
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

namespace Dianda.Web.Admin.budgetManage
{
	public partial class Budget_DetailMX : System.Web.UI.UserControl
	{
		public string LimitNums = string.Empty;
		public string Balance
		{
			get
			{
				if (TB_Balance.Text.Trim() != "")
					return TB_Balance.Text.Trim();
				return "0";
			}
			set { TB_Balance.Text = value; }
		}
		public decimal CJ
		{
			get
			{
				if (ViewState["CJ"] != null)
					return decimal.Parse(ViewState["CJ"].ToString());
				return 0;
			}
			set { ViewState["CJ"] = value; }
		}

		Model.Budget_Detail budgetDetailModel = new Dianda.Model.Budget_Detail();
		BLL.Budget_Detail bllBudgetDetail = new Dianda.BLL.Budget_Detail();
		//BllExt.StaticFactory_CASH bllextSF = new Dianda.BllExt.StaticFactory_CASH();//加载静态数据
		Model.Budget budgetModel = new Dianda.Model.Budget();
		BLL.Budget budget_bll = new Dianda.BLL.Budget();

		COMMON.pageControl pagecontrol = new Dianda.COMMON.pageControl();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			AjaxPro.Utility.RegisterTypeForAjax(typeof(Dianda.Web.Admin.budgetManage.Budget_DetailMX), this.Page);	
		}

		public void main(string BudgetId)
		{
			if (!string.IsNullOrEmpty(BudgetId))
			{
				hideID.Value = BudgetId;
				//TB_LimitNums.Enabled = false;
			}
			else
			{
				//TB_LimitNums.Enabled = false;
			}
			ScriptManager.RegisterStartupScript(this, GetType(), "key", "Show()", true);
		}
		/// <summary>
		/// 根据预算ID，获取到预算明细的列表
		/// </summary>
		/// <param name="CardID"></param>
		private void showList(string budgetId)
		{
			try
			{
				if (!string.IsNullOrEmpty(budgetId))
				{
					budgetModel = budget_bll.GetModel(int.Parse(budgetId));
					TB_Balance.Text = budgetModel.Balance.ToString();
				   // TB_LimitNums.Text = budgetModel.LimitNums.ToString();
				}
			}
			catch
			{
			}
		}

		[AjaxPro.AjaxMethod]
		public DataTable First_Read(string budgetId)
		{
			DataTable dt = new DataTable();
			try
			{
				if (string.IsNullOrEmpty(budgetId))
					budgetId = "0";

				string sql = "select * from Budget_Detail where BudgetId=" + budgetId;

				dt = pagecontrol.doSql(sql).Tables[0];
			}
			catch(Exception e)
         {

         }

			return dt;
		}

		public void Submit()
		{
			try
			{
				string DelDetailID = hideDelDetailID.Value;
				int unit = 10000; // 单位：万元
				decimal totalBalance = 0;

				if (string.IsNullOrEmpty(hideID.Value))
					return; 

				int budgetId = int.Parse(hideID.Value);

				if (!string.IsNullOrEmpty(DelDetailID.Replace(",", "")))
				{
					string sql = "delete BudgetDetail where id in (" + DelDetailID + ")";
					pagecontrol.doSql(sql);
				}

				char _charsplit = ',';
				string[] BudgetsDetail = Request.Form["BudgetsDetail"].Split(_charsplit);
				string[] DetailName = Request.Form["DetailName"].Split(_charsplit);
				string[] balance = Request.Form["balance"].Split(_charsplit);
				//string[] Unit = Request.Form["Unit"].Split(_charsplit);
				string[] RowsNum = Request.Form["RowsNum"].Split(_charsplit);
				string[] KYbalance = Request.Form["KYbalance"].Split(_charsplit);

				for (int i = 0; i < DetailName.Length; i++)
				{
					if (!string.IsNullOrEmpty(DetailName[i]))
					{
						string typename = Request.Form["typename" + RowsNum[i]];
						string b = string.IsNullOrEmpty(balance[i]) ? "0" : balance[i];
						decimal _balance = decimal.Parse(b);
						_balance = _balance * unit;
						

						if (string.IsNullOrEmpty(BudgetsDetail[i]))
						{
							budgetDetailModel.BudgetID = budgetId;
							budgetDetailModel.DetailName = DetailName[i];
							budgetDetailModel.Unit = unit;
							//budgetDetailModel.TypesName = typename;
							budgetDetailModel.Oldbalance = _balance;
							budgetDetailModel.Balance = _balance;
							budgetDetailModel.KYbalance = _balance;

							bllBudgetDetail.Add(budgetDetailModel);
						}
						else
						{
							budgetDetailModel = bllBudgetDetail.GetModel(int.Parse(BudgetsDetail[i]));
							budgetDetailModel.BudgetID = budgetId;
							budgetDetailModel.DetailName = DetailName[i];
							budgetDetailModel.Unit = 10000; //int.Parse(Unit[i]);
															//budgetDetailModel.TypesName = typename;

							//编辑时，预算金额不变，还是最初始的值，但是可用金额有可能被调整了。。那么当前余额也要对应增加或减少
							//当前余额 (可用金额调整额度是多少，就要在原来的当前余额基础上加减多少)
							//if (CJ > 0)
							//{
							//	//首先获得可用金额调整的差值
							//	decimal cz = _balance - decimal.Parse(KYbalance[i]);
							//	budgetDetailModel.Balance = budgetDetailModel.Balance + cz;
							//}
							//else
							//{
							//	//首先获得可用金额调整的差值
							//	decimal cz = decimal.Parse(KYbalance[i]) - _balance;
							//	budgetDetailModel.Balance = budgetDetailModel.Balance - cz;
							//}

							//budgetDetailModel.KYbalance = _balance;

							budgetDetailModel.Balance = _balance;

							bllBudgetDetail.Update(budgetDetailModel);

							totalBalance += _balance;
						}
					}
				}

				this.Balance = totalBalance.ToString();
			}
			catch(Exception e) {
				return;
			}
		}

		/// <summary>
		/// 判断是否有明细
		/// </summary>
		/// <returns></returns>
		public bool ReturnTnF()
		{
			string DetailName = Request.Form["DetailName"];
			if (string.IsNullOrEmpty(DetailName))
				return false;

			return true;
		}
	}
}