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
		public string LimitNums
		{
			get
			{
				if (TB_LimitNums.Text.Trim() != "")
					return TB_LimitNums.Text.Trim();
				return "0";
			}
			set { TB_LimitNums.Text = value; }
		}
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

		Model.Cash_CardsDetail modelCardsDetail = new Dianda.Model.Cash_CardsDetail();
		BLL.Cash_CardsDetail bllCardDetail = new Dianda.BLL.Cash_CardsDetail();//加载资金卡的明细列表
		BllExt.StaticFactory_CASH bllextSF = new Dianda.BllExt.StaticFactory_CASH();//加载静态数据
		Model.Cash_Cards Cards_model = new Dianda.Model.Cash_Cards();
		BLL.Cash_Cards Cards_bll = new Dianda.BLL.Cash_Cards();

		COMMON.pageControl pagecontrol = new Dianda.COMMON.pageControl();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			AjaxPro.Utility.RegisterTypeForAjax(typeof(Budget_DetailMX), this.Page);
		}

		public void main(string CardID)
		{
			if (!string.IsNullOrEmpty(CardID))
			{
				hideID.Value = CardID;
				TB_LimitNums.Enabled = false;
			}
			else
			{
				TB_LimitNums.Enabled = false;
			}
			ScriptManager.RegisterStartupScript(this, GetType(), "key", "Show()", true);
		}
		/// <summary>
		/// 根据资金卡的ID，获取到资金卡明细的列表
		/// </summary>
		/// <param name="CardID"></param>
		private void showList(string CardID)
		{
			try
			{
				if (!string.IsNullOrEmpty(CardID))
				{
					Cards_model = Cards_bll.GetModel(int.Parse(CardID));
					TB_Balance.Text = Cards_model.Balance.ToString();
					TB_LimitNums.Text = Cards_model.LimitNums.ToString();
				}
			}
			catch
			{
			}
		}

		[AjaxPro.AjaxMethod]
		public DataTable First_Read(string _CardID)
		{
			DataTable dt = new DataTable();
			try
			{
				if (string.IsNullOrEmpty(_CardID))
					_CardID = "0";

				string sql = "select * from Cash_CardsDetail where CardID=" + _CardID;

				dt = pagecontrol.doSql(sql).Tables[0];
			}
			catch { }

			return dt;
		}

		public void Submit(int carid)
		{
			try
			{
				string DelDetailID = hideDelDetailID.Value;
				if (!string.IsNullOrEmpty(DelDetailID.Replace(",", "")))
				{
					string sql = "delete Cash_CardsDetail where id in (" + DelDetailID + ")";
					pagecontrol.doSql(sql);
				}

				char _charsplit = ',';
				string[] CardsDetail = Request.Form["CardsDetail"].Split(_charsplit);
				string[] DetailName = Request.Form["DetailName"].Split(_charsplit);
				string[] balance = Request.Form["balance"].Split(_charsplit);
				string[] Unit = Request.Form["Unit"].Split(_charsplit);
				string[] RowsNum = Request.Form["RowsNum"].Split(_charsplit);
				string[] KYbalance = Request.Form["KYbalance"].Split(_charsplit);

				for (int i = 0; i < DetailName.Length; i++)
				{
					if (!string.IsNullOrEmpty(DetailName[i]))
					{
						string typename = Request.Form["typename" + RowsNum[i]];
						string b = string.IsNullOrEmpty(balance[i]) ? "0" : balance[i];
						decimal _balance = decimal.Parse(b);
						decimal _unit = decimal.Parse(Unit[i]);
						_balance = _balance * _unit;

						if (string.IsNullOrEmpty(CardsDetail[i]))
						{
							modelCardsDetail.CardID = carid;
							modelCardsDetail.DetailName = DetailName[i];
							modelCardsDetail.Unit = int.Parse(Unit[i]);
							modelCardsDetail.TypesName = typename;
							modelCardsDetail.Oldbalance = _balance;
							modelCardsDetail.Balance = _balance;
							modelCardsDetail.KYbalance = _balance;

							bllCardDetail.Add(modelCardsDetail);
						}
						else
						{
							modelCardsDetail = bllCardDetail.GetModel(int.Parse(CardsDetail[i]));
							modelCardsDetail.CardID = carid;
							modelCardsDetail.DetailName = DetailName[i];
							modelCardsDetail.Unit = int.Parse(Unit[i]);
							modelCardsDetail.TypesName = typename;

							//编辑时，预算金额不变，还是最初始的值，但是可用金额有可能被调整了。。那么当前余额也要对应增加或减少
							//当前余额 (可用金额调整额度是多少，就要在原来的当前余额基础上加减多少)
							if (CJ > 0)
							{
								//首先获得可用金额调整的差值
								decimal cz = _balance - decimal.Parse(KYbalance[i]);
								modelCardsDetail.Balance = modelCardsDetail.Balance + cz;
							}
							else
							{
								//首先获得可用金额调整的差值
								decimal cz = decimal.Parse(KYbalance[i]) - _balance;
								modelCardsDetail.Balance = modelCardsDetail.Balance - cz;
							}
							modelCardsDetail.KYbalance = _balance;

							bllCardDetail.Update(modelCardsDetail);
						}

					}
				}
			}
			catch { }
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