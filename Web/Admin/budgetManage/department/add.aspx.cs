using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Dianda.Web.Admin.budgetManage
{
	public partial class add : System.Web.UI.Page
	{
		Dianda.COMMON.fileUploads fileup = new Dianda.COMMON.fileUploads();
		COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
		Model.Budget budgetModel = new Dianda.Model.Budget();
		BLL.Budget budgetBll = new Dianda.BLL.Budget();
		BllExt.Groups groups_bllext = new Dianda.BllExt.Groups();
		COMMON.common common = new COMMON.common();

		public int pageSize = 200;
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

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
				string userid = "1";
				if (null != user_model)
				{
					userid = user_model.ID.ToString();
				}

				//加载预算审批人
				ShowAssignCheckerList();

				string id = Request["ID"];
				//    //说明是编辑过来的
				if (!string.IsNullOrEmpty(id))
				{
					ShowInitInfor(common.cleanXSS(id));

					BindChildBudgetList(int.Parse(id));
					
					//        LB_file.Visible = true;

					//        //设置模板页中的管理值
					//        (Master.FindControl("Label_navigation") as Label).Text = "经费 > 预算申请 > 编辑申请 ";
					//        //设置模板页中的管理值
				}
				else
				{
					//        LB_file.Visible = false;
					//        //设置模板页中的管理值
					//        (Master.FindControl("Label_navigation") as Label).Text = "经费 > 预算申请 > 新建申请 ";
					//        //设置模板页中的管理值

					LB_BudgetLimit.Text = "0万元";
				}

				// 显示部门
				ShowDepartments();

			    // 显示部门人员
				ShowUserWhenDepartmentChanged();

			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ID"></param>
		protected void ShowInitInfor(string ID)
		{
			try
			{
				budgetModel = budgetBll.GetModel(int.Parse(ID));
				TB_Code.Text = budgetModel.Code;
				//预算名称
				TB_BudgetName.Text = budgetModel.BudgetName;
				//报告审批人
				DDL_AssignChecker.SelectedValue = budgetModel.ApproverIDs;

				if (!budgetModel.DepartmentIDs.Equals("9999"))
				{
					HID_Department.Value = budgetModel.DepartmentIDs;
				}

				if (!budgetModel.ManagerIDs.Equals("9999"))
				{
					HID_Manager.Value = budgetModel.ManagerIDs;
				}

				if (budgetModel.StartTime != null)
				{
					TB_StartDateTime.Value = budgetModel.StartTime.Value.ToString("yyyy-MM-dd");
				}

				if (budgetModel.EndTime != null)
				{
					TB_EndDateTime.Value = budgetModel.EndTime.Value.ToString("yyyy-MM-dd");
				}


				Button_sumbit.Text = "编辑";
				//所属项目
				//if (null != cashorder_model.ProjectID && !cashorder_model.ProjectID.ToString().Equals("9999"))
				//{
				//    RBL_project.SelectedValue = "1";
				//    DDL_Project.Visible = true;
				//    DDL_Project.SelectedValue = cashorder_model.ProjectID.ToString();
				//}
				//else
				//{
				//    RBL_project.SelectedValue = "0";
				//    DDL_Project.Visible = false;
				//}
				////预算金额
				//TB_BudgetAmount.Text = budgetModel.LimitNums.ToString();
				////预算金额单位
				//RB_BudgetAmount.SelectedValue = cashorder_model.BAUNIT.ToString().Equals("万元") ? "1" : "0";


			}
			catch
			{ }
		}

		/// <summary>
		/// 加载预算审批人
		/// </summary>
		protected void ShowAssignCheckerList()
		{
			try
			{
				DataTable DT = groups_bllext.getLeaderList();
				if (DT.Rows.Count > 0)
				{
					DDL_AssignChecker.DataSource = DT;
					DDL_AssignChecker.DataValueField = "ID";
					DDL_AssignChecker.DataTextField = "REALNAME";
					DDL_AssignChecker.DataBind();
				}
				else
				{
					ListItem li = new ListItem("-暂无可选审批人-", "");
					DDL_AssignChecker.Items.Add(li);
					Button_sumbit.Enabled = false;
				}

			}
			catch
			{ }

		}
		/// <summary>
		/// 有无所属项目切换
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void RBL_project_change(object sender, EventArgs e)
		{
			//string isexit = RBL_project.SelectedValue.ToString();
			//if (isexit.Equals("0"))
			//{
			//    DDL_Project.Visible = false;
			//}
			//else
			//{
			//    DDL_Project.Visible = true;
			//}
		}


		/// <summary>
		/// 确定事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_sumbit_click(object sender, EventArgs e)
		{
			try
			{
				Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

				string id = Request["ID"];
				if (!string.IsNullOrEmpty(id))//表示是修改
				{
					budgetModel = budgetBll.GetModel(int.Parse(id));
					if (budgetModel == null)
						throw new NullReferenceException("没有该预算！");

					budgetModel.Code = this.TB_Code.Text;
					budgetModel.BudgetName = this.TB_BudgetName.Text;
					budgetModel.DepartmentIDs = this.HID_Department.Value;
					budgetModel.ManagerIDs = this.HID_Manager.Value;

					//指定审批人
					budgetModel.ApproverIDs = DDL_AssignChecker.SelectedValue.ToString();
					budgetModel.BudgetType = 1;
					budgetModel.StartTime = DateTime.Parse(this.TB_StartDateTime.Value);
					budgetModel.EndTime = DateTime.Parse(this.TB_EndDateTime.Value);
					budgetModel.DATETIME = DateTime.Now;

					budgetBll.Update(budgetModel);

					string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入部门预算列表页面\"); location.href = \"list.aspx\";</script>";
					Response.Write(coutws);
				}
				else//新建
				{
					budgetModel.Code = this.TB_Code.Text;
					budgetModel.BudgetName = this.TB_BudgetName.Text;
					budgetModel.DepartmentIDs = this.HID_Department.Value;
					budgetModel.ManagerIDs = this.HID_Manager.Value;
					//ID
					budgetModel.ID = budgetBll.GetMaxId();
					//指定审批人
					budgetModel.ApproverIDs = DDL_AssignChecker.SelectedValue.ToString();
					budgetModel.BudgetType = 1;
					budgetModel.StartTime = DateTime.Parse(this.TB_StartDateTime.Value);
					budgetModel.EndTime = DateTime.Parse(this.TB_EndDateTime.Value);
					//申请时间
					budgetModel.DATETIME = DateTime.Now;

					budgetBll.Add(budgetModel);

					string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入子项目页面\"); location.href = \"addChild.aspx\";</script>";
					Response.Write(coutws);
				}

			}
			catch(Exception en)
			{ }
		}

		/// <summary>
		/// 点击返回触发事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_cancel_click(object sender, EventArgs e)
		{
         //string page = Request["pageindex"].ToString();
         //string status = Request["Status"].ToString();

         //Response.Redirect("budgetmanage.aspx?pageindex=" + page + "&Status=" + status);

         Response.Redirect("list.aspx");
      }

		protected void BTN_Departmetn_Click(object sender, EventArgs e)
		{
			ShowUserWhenDepartmentChanged();
		}

		protected void BTN_ChildBudget_Edit_Click(object sender, EventArgs e)
		{

		}

		protected void BTN_ChildBudget_Delete_Click(object sender, EventArgs e)
		{

		}


		/// <summary>
		/// 部门进行切换的时候，要做人员列表的切换
		/// </summary>
		private void ShowUserWhenDepartmentChanged()
		{
			//绑定人员列表
			DP_Manager.Items.Clear();
			DataTable dtuser = new DataTable();
			string[] departIdArray = this.HID_Department.Value.Split(',');
			string departIds = "";
			for (int i = 0; i < departIdArray.Length; i++)
			{
				if (i == departIdArray.Length - 1)
				{
					departIds += "'" + departIdArray[i] + "'";
				}
				else
				{
					departIds += "'" + departIdArray[i] + "',";
				}
			}
			dtuser = pageControl.doSql("select ID,USERNAME,REALNAME from USER_Users where DepartMentID in (" + departIds + ") and WorkStats='1' and DELFLAG=0").Tables[0];
			if (dtuser.Rows.Count > 0)
			{

				for (int i = 0; i < dtuser.Rows.Count; i++)
				{
					string ApplyUserName = dtuser.Rows[i]["REALNAME"].ToString() + "(" + dtuser.Rows[i]["USERNAME"].ToString() + ")";
					string ID = dtuser.Rows[i]["ID"].ToString();

					ListItem li = new ListItem(ApplyUserName, ID);
					DP_Manager.Items.Add(li);

				}
			}
			else
			{
				ListItem li = new ListItem("本部门无人员", "0");
				DP_Manager.Items.Add(li);
				DP_Manager.Enabled = false;
			}
		}

		private void ShowDepartments()
		{
			DataTable dt = new DataTable();
			//string sql = "SELECT ID,[Name] FROM USER_Groups WHERE DELFLAG=0 group by ID,[Name]";
			string sql = " SELECT DepartmentName, DepartmentID FROM vCash_Cards GROUP BY DepartmentName, DepartmentID";
			dt = pageControl.doSql(sql).Tables[0];
			if (dt.Rows.Count > 0)
			{
				this.DP_Department.DataSource = dt;
				this.DP_Department.DataTextField = "DepartmentName";
				this.DP_Department.DataValueField = "DepartmentID";
				this.DP_Department.DataBind();

				ListItem li = new ListItem("-全部-", "9999");
				li.Selected = true;
				DP_Department.Items.Insert(0, li);
			}
			else
			{
				ListItem li = new ListItem("-暂无可选部门-", "");
				DP_Department.Items.Insert(0, li);
			}
		}

        private void BindChildBudgetList(int parentId)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(" 1=1 ");
			sb.Append(" and parentId= ");
			sb.Append(parentId);

			DataTable DT = new DataTable();
			DT = new COMMON.common().GetDatePaging(pageSize, int.Parse(nowPaging), "vBudget_User_Apply", "*", "ID", sb.ToString(), "", "", "");
			this.GridView2.DataSource = DT;
			this.GridView2.DataBind();
		}

		protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				//e.Row.Cells[5].Text = "<a href='showParent.aspx?id=" + parentId + "&PageRole=" + PageRole + "' title='" + parentBudgetName + "'>" + parentBudgetName + "</a>"; // parentBudgetName;
			}
		}
	}
}
