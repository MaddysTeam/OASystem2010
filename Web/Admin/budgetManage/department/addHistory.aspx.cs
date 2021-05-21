using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.budgetManage.department
{
	public partial class addHistory : System.Web.UI.Page
	{
		public string PageStr
		{
			get
			{
				if (ViewState["PageStr"] != null)
					return ViewState["PageStr"].ToString();
				return null;
			}
			set { ViewState["PageStr"] = value; }
		}
		Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
		Model.Budget_User_Apply budgetUserApply = new Model.Budget_User_Apply();
		Model.Budget_Apply_History budgetApplyHistory = new Dianda.Model.Budget_Apply_History();
		BLL.Budget_User_Apply budgetUserApplyBll = new BLL.Budget_User_Apply();
		BLL.Budget_Apply_History budgetApplyHistoryBll = new Dianda.BLL.Budget_Apply_History();
		Model.Budget budget = new Dianda.Model.Budget();
		BLL.Budget budgetBll = new Dianda.BLL.Budget();
		BLL.Budget_Detail budgetDetailBll = new Dianda.BLL.Budget_Detail();
		Dianda.COMMON.common common = new COMMON.common();

		const string _PageAdd = "/admin/personalProjectManage/OACashApply/add.aspx";
		const string _PageAdd1 = "/Admin/budgetManage/showHistory.aspx";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//this.ucshow1.id = Request["id"];
				Read_Data(common.cleanXSS(Request["id"].ToString()));
				this.Button_sumbit.Visible = true;

				ShowDDLControlInfo(common.cleanXSS(Request["id"].ToString()));
				/*设置模板页中的管理值*/
				(Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 > 部门预算管理 > 记帐";
				/*设置模板页中的管理值*/

				if (Request["PageStr"] != null)
					PageStr = Request["PageStr"];

				if (PageStr == "add")
					Button_sumbit0.Visible = false;
			}
		}

		/// <summary>
		/// 显示预算经费调整说明
		/// </summary>
		protected void ShowDDLControlInfo(string budgetID)
		{
			try
			{
				DataTable dt = new DataTable();
				//string sql = " SELECT * FROM VCash_ControlInfo WHERE CardID='"+cardid+"' ORDER BY ID ";

				dt = budgetDetailBll.GetList("BudgetID='" + budgetID + "'").Tables[0];

				if (dt.Rows.Count > 0)
				{
					GridView1.DataSource = dt;
					GridView1.DataBind();
				}
				else
				{
					GridView1.Visible = false;
					tag.Text = "没有可供的调整说明";
				}

			}
			catch
			{ }
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

				//经费调整说明
				string NAME = "";
				decimal money = 0;
				//登录用户
				Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
				budgetUserApply.RoundNO = Guid.NewGuid().ToString();

				foreach (GridViewRow item in GridView1.Rows)
				{
					Label la = (Label)item.FindControl("Label_Name");
					TextBox tx = (TextBox)item.FindControl("txtBalance");
					Label lb = (Label)item.FindControl("LB_Balance");
					HiddenField HF_DetailID = (HiddenField)item.FindControl("HF_DetailID");
					string ID = GridView1.DataKeys[item.RowIndex].Value.ToString();
					string cashmoney = "";

					Model.Budget_Detail budgetDetail = new Dianda.Model.Budget_Detail();
					BLL.Budget_Detail budgetDetailBll = new Dianda.BLL.Budget_Detail();
					budgetDetail = budgetDetailBll.GetModel(int.Parse(HF_DetailID.Value));

					if (rblDoType.SelectedValue == "2")
					{
						//if (double.Parse(tx.Text.ToString()) > double.Parse(lb.Text.ToString()))
						//{
						//    tag.Text = la.Text + "减少的金额不能大于可用金额！";
						//    tag2.Text = la.Text + "减少的金额不能大于可用金额！";
						//    return;
						//}

						if (decimal.Parse(tx.Text) == 0)
						{
							cashmoney = tx.Text;
						}
						else
						{
							cashmoney = "-" + tx.Text;
						}
						//在原来该细目的可用金额基础上减去输入的值　
						budgetDetail.KYbalance = Decimal.Parse(budgetDetail.KYbalance.ToString()) - Decimal.Parse(tx.Text.ToString());
						//budgetDetail.Balance = Decimal.Parse(budgetDetail.Balance.ToString()) - Decimal.Parse(tx.Text.ToString());
						budgetDetailBll.Update(budgetDetail);
					}
					else
					{
						cashmoney = tx.Text;
						//在原来该细目的可用金额基础上加上输入的值　
						budgetDetail.KYbalance = Decimal.Parse(budgetDetail.KYbalance.ToString()) + Decimal.Parse(tx.Text.ToString());
						//budgetDetail.Balance = Decimal.Parse(budgetDetail.Balance.ToString()) + Decimal.Parse(tx.Text.ToString());
						budgetDetailBll.Update(budgetDetail);
					}

					//记录用户记账明细
					budgetUserApply.BudgetID = budgetDetail.BudgetID;
					budgetUserApply.DetailID = budgetDetail.ID;
					budgetUserApply.DetailName = budgetDetail.DetailName;
					budgetUserApply.DoUserID = user_model.ID;
					budgetUserApply.Balance = this.rblDoType.SelectedValue == "1" ?
						Decimal.Parse(tx.Text) :
						Decimal.Parse(tx.Text) * -1;
					budgetUserApply.AddTime = DateTime.Now;
					budgetUserApplyBll.Add(budgetUserApply);

					//拼接controlInfo 
					NAME += ID + "," + la.Text + "," + cashmoney + "|";
					money += decimal.Parse(tx.Text);

				}
				NAME = NAME.Remove(NAME.LastIndexOf("|"));
				if (String.IsNullOrEmpty(NAME))
				{
					tag.Text = "调整说明不能为空，请填写调整说明！";
					tag2.Text = "调整说明不能为空，请填写调整说明！";
					return;
				}
				// budget = new Dianda.Model.Budget();
				budget = budgetBll.GetModel(Int32.Parse(common.cleanXSS(Request["ID"])));//Cash_Cards的ID)
				budgetApplyHistory = new Dianda.Model.Budget_Apply_History();
				budgetApplyHistory.BudgetID = Int32.Parse(common.cleanXSS(Request["ID"]));//Cash_Cards的ID
																						  //mCash_Apply_History.ControlInfo = this.txtControlInfo.Text;
																						  //资金调整说明
				budgetApplyHistory.ControlInfo = NAME;
				if (this.rblDoType.SelectedValue == "1")//增加
				{
					budgetApplyHistory.Balance = Decimal.Parse(this.lblBalance.Text) + money;
				}
				else//减少
				{
					budgetApplyHistory.Balance = Decimal.Parse(this.lblBalance.Text) - money;
				}
				budgetApplyHistory.DATETIME = DateTime.Now;
				budgetApplyHistory.DoUser = ((Model.USER_Users)Session["USER_Users"]).USERNAME;
				budgetApplyHistory.DoType = rblDoType.SelectedValue == "1" ? "增加" + money + "元" : "减少" + money + "元";
				budgetApplyHistory.NOTES = TextBox1.Text;
				budgetApplyHistoryBll.Add(budgetApplyHistory);

				string oldLimitNums = budget.LimitNums.ToString();
				//要在对应的资金卡中增加或是减少的可用金额
				//if (this.rblDoType.SelectedValue == "1")//增加
				//{
				//budget.YEBalance = (budget.YEBalance + money);
				//mCash_Cards.TEMP0 = mCash_Cards.TEMP0 + "&nbsp;&nbsp;" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "，增加" + money + "元，可用金额由" + oldLimitNums + "元调整为" + mCash_Cards.LimitNums + "元<br> ";
				//}
				//else//减少
				//{
				//budget.YEBalance = (budget.YEBalance - money);
				//mCash_Cards.TEMP0 = mCash_Cards.TEMP0 + "&nbsp;&nbsp;" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "，减少" + money + "元，可用金额由" + oldLimitNums + "元调整为" + mCash_Cards.LimitNums + "元<br> ";
				//}
				budgetBll.Update(budget);
				//this.ucshow1.BindData();
				Read_Data(common.cleanXSS(Request["id"].ToString()));

				/*给业务申请者发信息*/
				//Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
				//BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

				//mFaceShowMessage.DATETIME = DateTime.Now;
				//mFaceShowMessage.FromTable = "经费";
				//mFaceShowMessage.IsRead = 0;
				//mFaceShowMessage.NewsID = null;
				//mFaceShowMessage.NewsType = "经费";
				//mFaceShowMessage.ReadTime = null;
				//mFaceShowMessage.Receive = mCash_Cards.CardholderID;
				//mFaceShowMessage.DELFLAG = 0;
				//mFaceShowMessage.URLS = ((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME.ToString() + ")调整了您的资金卡[" + mCash_Cards.CardName + "]！<a href='/Admin/cashCardManage/showHistory.aspx?id=" + Request["ID"] + "' target='_self' title='操作记录查看'>点击查看</a>";
				//bFaceShowMessage.Add(mFaceShowMessage);
				/*给业务申请者发信息*/

				tag.Text = "操作成功！";
				tag2.Text = "操作成功！";

				//添加操作日志
				Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
				bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "资金卡调整", "资金卡" + ((rblDoType.SelectedValue == "1") ? "增加" : "减少") + money + "成功");
				//添加操作日志

				if (((Button)sender).ID == "Button_sumbit")
				{
					string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入明细页面\"); ";
					if (PageStr == "add")
						coutws += "location.href = \"" + _PageAdd1 + ReturnCS() + "\";</script>";
					else
						coutws += "location.href = \"showHistory.aspx?id=" + common.cleanXSS(Request["id"]) + "&PageRole=manage\";</script>";
					Response.Write(coutws);
				}
				else
				{
					//foreach (GridViewRow item1 in GridView1.Rows)
					//{                        
					//    TextBox tx = (TextBox)item1.FindControl("txtBalance");
					//    tx.Text = "0";

					//}
					ShowDDLControlInfo(common.cleanXSS(Request["id"]));
					TextBox1.Text = "";
					//tag.Text = "";
				}

			}
			catch (Exception ex)
			{
				tag.Text = "操作失败，请重试！";
				tag2.Text = "操作失败，请重试！";
			}
		}

		/// <summary>
		/// 点击取消按钮触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_cancel_Click(object sender, EventArgs e)
		{
			// Response.Write("<script>history.back()</script>");
			//if (PageStr == "add")
			//   Response.Redirect(_PageAdd + ReturnCS());
			//else
			Response.Redirect("showHistory.aspx?id=" + Request["id"] + "&role=manage");
		}
		public string ReturnCS()
		{
			string str = "?1=1";
			if (Request["key"] != null)
				str += "&key=" + Request["key"];
			if (Request["ApplyID"] != null)
				str += "&ApplyID=" + Request["ApplyID"];
			if (Request["pageindex"] != null)
				str += "&pageindex=" + Request["pageindex"];
			if (Request["status"] != null)
				str += "&status=" + Request["status"];
			if (Request["parentpage"] != null)
				str += "&parentpage=" + Request["parentpage"];
			if (Request["date"] != null)
				str += "&date=" + Request["date"];

			return str;
		}
		protected void Read_Data(string _id)
		{
			try
			{
				DataTable dt = new DataTable();
				string strSQL = "Select * From vBudget_List Where id=" + common.SafeString(_id);
				dt = pageControl.doSql(strSQL).Tables[0];
				if (dt.Rows.Count > 0)
				{
					lblBudgetName.Text = "《" + dt.Rows[0]["BudgetName"].ToString() + "》的预算经费信息";
					lblBudgetCode.Text = dt.Rows[0]["Code"].ToString();
					//lblCardholderRealName.Text = dt.Rows[0]["CardholderRealName"].ToString();
					//lblDepartmentName.Text = dt.Rows[0]["DepartmentName"].ToString();
					if (null != dt.Rows[0]["ParentBudgetName"] && !dt.Rows[0]["ParentBudgetName"].ToString().Equals(""))
					{
						lblParentBudget.Text = dt.Rows[0]["ParentBudgetName"].ToString();
					}
					else
					{
						lblParentBudget.Text = "暂无所属项目";
					}

					lblBalance.Text = dt.Rows[0]["Balance"].ToString();
					//lblApproverRealName.Text = dt.Rows[0]["ApproverRealName"].ToString();
					//lblStatas.Text = dt.Rows[0]["Statas"].ToString();
					string startTime = string.IsNullOrEmpty(dt.Rows[0]["StartTime"].ToString()) ? "" : DateTime.Parse(dt.Rows[0]["StartTime"].ToString()).ToLongDateString();
					string endTime = string.IsNullOrEmpty(dt.Rows[0]["EndTime"].ToString()) ? "" : DateTime.Parse(dt.Rows[0]["EndTime"].ToString()).ToLongDateString();
					lblStartEndDate.Text = string.Format("{0} - {1}", startTime, endTime);


					//所属专项资金
					//LB_SpecialFundsName.Text = dt.Rows[0]["SpecialFundsName"].ToString();
					//所属预算报告
					//LB_SFOrderName.Text = "<a href='" + dt.Rows[0]["BudgetList"].ToString() + "' target='_blank'>" + dt.Rows[0]["SFOrderName"].ToString() + "</a>";
				}
			}
			catch
			{
			}
		}

		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
				{
					string[] CarDetailsArr = null;
					if (Request["CarDetails"] != null)
						CarDetailsArr = Request["CarDetails"].Split(':');
					int RowIndex = e.Row.RowIndex + 1;
					TextBox TB = (TextBox)e.Row.FindControl("txtBalance");
					if (CarDetailsArr != null)
						if (CarDetailsArr[RowIndex] != null)
							TB.Text = CarDetailsArr[RowIndex];

					Label lb = (Label)e.Row.FindControl("LB_Balance");

					string Balance = DataBinder.Eval(e.Row.DataItem, "Balance").ToString();
					decimal money = decimal.Parse(Balance);
					if (money < 0)
						lb.ForeColor = System.Drawing.Color.Red;
				}
			}
			catch { }
		}
	}
}
