using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OACashApply
{
	public partial class showCardInfo : System.Web.UI.Page
	{
		Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
		Model.Cash_Apply_History mCash_Apply_History = new Dianda.Model.Cash_Apply_History();
		BLL.Cash_Apply_History bCash_Apply_History = new Dianda.BLL.Cash_Apply_History();
		COMMON.common common = new COMMON.common();
		string hztotal = "";
		string hzActionBalance = "0";

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
				string id = Request["id"].ToString();
				//显示资金卡的基本信息
				ShowInitInfo(id);
				BindData(id);
			}
		}

		protected void ShowInitInfo(string ID)
		{
			try
			{
				string sql = " SELECT * FROM vCash_CardsDetail WHERE CardID='" + ID + "' order by id";
				DataTable DT = new DataTable();
				DT = pageControl.doSql(sql).Tables[0];
				if (DT.Rows.Count > 0)
				{
					//资金卡名称
					LB_Name.Text = DT.Rows[0]["CardName"].ToString();
					//所属项目
					LB_Project.Text = DT.Rows[0]["ProjectName"].ToString();
					//持卡人
					LB_Holder.Text = DT.Rows[0]["HolderRealName"].ToString();
					//审批人
					LB_Checker.Text = DT.Rows[0]["CheckRealName"].ToString();
					//资金卡编号
					LB_CardNum.Text = DT.Rows[0]["CardNum"].ToString();
					//所属专项资金
					LB_SpecialFundsName.Text = DT.Rows[0]["SpecialFundsName"].ToString();
					//所属帐户
					LB_AccountName.Text = DT.Rows[0]["AccountName"].ToString();
					//所属预算报告
					LB_SFOrderName.Text = "<a href='" + DT.Rows[0]["BudgetList"].ToString() + "' target='_blank'>" + DT.Rows[0]["SFOrderName"].ToString() + "</a>";

					LB_Info.Text = "&nbsp;可用金额调整情况：<br>" + DT.Rows[0]["TEMP0"].ToString();

					DList_YSJE.DataSource = DT;
					DList_YSJE.DataBind();
					DList_YSJE.RepeatColumns = DT.Rows.Count;

					DList_KYJE.DataSource = DT;
					DList_KYJE.DataBind();
					DList_KYJE.RepeatColumns = DT.Rows.Count;

					DList_DQYE.DataSource = DT;
					DList_DQYE.DataBind();
					DList_DQYE.RepeatColumns = DT.Rows.Count;
				}
				else
				{
					LB_MSG.Text = "暂无该资金卡的相关信息！";
				}
			}
			catch
			{ }
		}

		private void BindData(string id)
		{
			DataTable DT = new DataTable();
			string strSQL = "Select * From vCash_Apply_History Where CashCertificateID=" + common.SafeString(id);
			DT = pageControl.doSql(strSQL).Tables[0];
			if (DT.Rows.Count > 0)
			{
				RowChangeCell(DT);

				LB_MSG.Text = "";
			}
			else
			{
				GridView1.Visible = false;
				notice.Text = "该资金卡暂无记帐的操作记录！";
			}
		}

		public void RowChangeCell(DataTable _dt)
		{
			try
			{
				DataTable Rdt = new DataTable();
				decimal[] Tol;

				//为Rdt添加列
				Rdt.Columns.Add(new DataColumn("PX", System.Type.GetType("System.String")));
				Rdt.Columns.Add(new DataColumn("DATETIME", System.Type.GetType("System.DateTime")));
				Rdt.Columns.Add(new DataColumn("Tol", System.Type.GetType("System.Decimal")));
				if (_dt.Rows.Count > 0)
				{
					string ControlInfo = _dt.Rows[0]["ControlInfo"].ToString();
					string[] arr = ControlInfo.Split('|');
					Tol = new decimal[arr.Length];  //总数列
															  //为每一个列赋值
					for (int i = 0; i < Tol.Length; i++)
					{
						Tol[i] = 0;
					}

					for (int i = 0; i < arr.Length; i++)
					{
						string[] a = arr[i].Split(',');

						Rdt.Columns.Add(new DataColumn(a[1], System.Type.GetType("System.Decimal")));
					}

					DataRow _dRow;
					int Rnum = 1;
					//为每行赋值
					foreach (DataRow ds in _dt.Rows)
					{
						_dRow = Rdt.NewRow();

						_dRow["PX"] = Rnum.ToString();
						_dRow["DATETIME"] = ds["DATETIME"];
						string[] _arr = ds["ControlInfo"].ToString().Split('|');
						for (int i = 0; i < _arr.Length; i++)
						{
							string[] a = _arr[i].Split(',');
							_dRow[a[1]] = decimal.Parse(a[2]);
							decimal D = 0;
							if (!string.IsNullOrEmpty(_dRow["Tol"].ToString()))
								D = decimal.Parse(_dRow["Tol"].ToString());
							_dRow["Tol"] = D + decimal.Parse(a[2]);
							Tol[i] = Tol[i] + decimal.Parse(a[2]);
						}

						Rdt.Rows.Add(_dRow);
						Rnum++;
					}

					//汇总值添加进表中,同时为gridview添加新列
					_dRow = Rdt.NewRow();
					_dRow["PX"] = "汇总";
					decimal dec = 0;
					for (int i = 3; i < Rdt.Columns.Count; i++)
					{
						dec += Tol[i - 3];
						_dRow[i] = Tol[i - 3];
						BoundField f = new BoundField();
						f.DataField = Rdt.Columns[i].ColumnName;
						f.HeaderText = Rdt.Columns[i].ColumnName;
						f.HeaderStyle.CssClass = "HeaderStyle11";
						f.ItemStyle.CssClass = "ItemStyle11";
						GridView1.Columns.Add(f);
					}
					_dRow["Tol"] = dec;
					Rdt.Rows.Add(_dRow);
					BoundField bf = new BoundField();
					bf.DataField = "Tol";
					bf.HeaderText = "总金额";
					bf.HeaderStyle.CssClass = "HeaderStyle12";
					bf.ItemStyle.CssClass = "ItemStyle12";
					GridView1.Columns.Add(bf);

					//最后添加时间列
					bf = new BoundField();
					bf.DataField = "DATETIME";
					bf.HeaderText = "时间";
					bf.HeaderStyle.CssClass = "HeaderStyle12";
					bf.ItemStyle.CssClass = "ItemStyle12";
					bf.DataFormatString = "{0:yyyy-MM-dd}";
					GridView1.Columns.Add(bf);
				}

				GridView1.Visible = true;
				GridView1.DataSource = Rdt;//指定GridView1的数据是dv
				GridView1.DataBind();//将上面指定的信息绑定到GridView1上
			}
			catch { }
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

		public string ReturnStr(string Val)
		{
			return decimal.Parse(Val) < 0 ? "<font color='red'>" + Val + "</font>" : Val;
		}

		protected void DList_YSJE_ItemDataBound(object sender, DataListItemEventArgs e)
		{
			decimal YSJE = 0;
			decimal.TryParse(Lab_YSJE.Text.Trim(), out YSJE);
			decimal Oldbalance = 0;
			decimal.TryParse(DataBinder.Eval(e.Item.DataItem, "Oldbalance").ToString(), out Oldbalance);
			Lab_YSJE.Text = (YSJE + Oldbalance).ToString();
		}

		protected void DList_DQYE_ItemDataBound(object sender, DataListItemEventArgs e)
		{
			decimal DQYE = 0;
			decimal.TryParse(Lab_DQYE.Text.Trim(), out DQYE);
			decimal Balance = 0;
			decimal.TryParse(DataBinder.Eval(e.Item.DataItem, "Balance").ToString(), out Balance);
			Lab_DQYE.Text = (DQYE + Balance).ToString();
		}

		protected void DList_KYJE_ItemDataBound(object sender, DataListItemEventArgs e)
		{
			decimal KYJE = 0;
			decimal.TryParse(Lab_KYJE.Text.Trim(), out KYJE);
			decimal KYbalance = 0;
			decimal.TryParse(DataBinder.Eval(e.Item.DataItem, "KYbalance").ToString(), out KYbalance);
			Lab_KYJE.Text = (KYJE + KYbalance).ToString();
		}
	}
}
