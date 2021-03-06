using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.budgetManage.department
{
	public partial class addChild : System.Web.UI.Page
	{
		Dianda.COMMON.fileUploads fileup = new Dianda.COMMON.fileUploads();
		COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
		Model.Budget budgetModel = new Dianda.Model.Budget();
		BLL.Budget budgetBll = new Dianda.BLL.Budget();
		BllExt.Groups groups_bllext = new Dianda.BllExt.Groups();
		COMMON.common common = new COMMON.common();

		public string ParentId
		{
			get
			{
				if (ViewState["ParentId"] != null)
					return ViewState["ParentId"].ToString();
				return "1";
			}
			set { ViewState["ParentId"] = value; }
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

				//加载所属项目列表
				ShowParentBudgetList(userid);
				//加载预算审批人
				ShowAssignCheckerList();

				ShowDepartments();

				ShowManagers();

				//说明是编辑过来的
				if (null != Request["ID"] && !Request["ID"].ToString().Equals(""))
				{
					ShowInitInfor(common.cleanXSS(Request["ID"].ToString()));
				}
				else // 新增
				{
					ParentId = Request["parentId"];

					//显示详细插件
					budgetDetails.main("");
				}


			}
			else
			{
				budgetDetails.main("");
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

				ParentId = budgetModel.ParentId.ToString();

				TB_Code.Text = budgetModel.Code;
				//预算名称
				TB_BudgetName.Text = budgetModel.BudgetName;
				//报告审批人
				DDL_AssignChecker.SelectedValue = budgetModel.ApproverIDs;
				if (!budgetModel.ParentId.ToString().Equals("9999"))
				{
					DDL_Budget.SelectedValue = budgetModel.ParentId.ToString();
				}

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

				//显示详细插件
				budgetDetails.Balance = budgetModel.Balance.ToString();
				budgetDetails.LimitNums = budgetModel.LimitNums.ToString();
				budgetDetails.main(budgetModel.ID.ToString());
			}
			catch (Exception e)
			{
			}
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
				bool isModify = null != Request["ID"] && !Request["ID"].ToString().Equals("");

				if (isModify)//表示是修改
				{
					budgetModel = budgetBll.GetModel(int.Parse(Request["ID"].ToString()));
				}
				else
				{
					//ID
					budgetModel.ID = budgetBll.GetMaxId();
				}
				//else//新建
				//{

				if (TB_Code.Text == "")
				{
					tag.Text = "必须填写项目编号！";
					return;
				}

				budgetModel.Code = TB_Code.Text;

				budgetModel.BudgetName = TB_BudgetName.Text;

				if (HID_Department.Value == "")
				{
					tag.Text = "必须选择部门！";
					return;
				}

				budgetModel.DepartmentIDs = HID_Department.Value;

				if (HID_Manager.Value == "")
				{
					tag.Text = "必须选择负责人！";
					return;
				}

				budgetModel.ManagerIDs = HID_Manager.Value;

				//父预算ID
				budgetModel.ParentId = int.Parse(DDL_Budget.SelectedValue);
				//指定审批人
				budgetModel.ApproverIDs = DDL_AssignChecker.SelectedValue.ToString();
				budgetModel.BudgetType = 1;
				budgetModel.StartTime = DateTime.Parse(TB_StartDateTime.Value);
				budgetModel.EndTime = DateTime.Parse(TB_EndDateTime.Value);
				//申请时间
				budgetModel.DATETIME = DateTime.Now;

				//将父项目预算id放入 子项目预算明细用户控件
				budgetDetails.main(budgetModel.ID.ToString());

				// 提交预算明细用户控件数据
				this.budgetDetails.Submit();

				budgetModel.Balance = decimal.Parse(budgetDetails.Balance);

				if (isModify)
				{
					budgetBll.Update(budgetModel);
				}
				else
				{
					//新增时可用余额=项目预算
					budgetModel.YEBalance = budgetModel.Balance;

					//新增子项目预算
					budgetBll.Add(budgetModel);
				}

				//    /*给业务申请者发信息*/
				//    Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
				//    BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

				//    mFaceShowMessage.DATETIME = DateTime.Now;
				//    mFaceShowMessage.FromTable = "预算申请";
				//    mFaceShowMessage.IsRead = 0;
				//    mFaceShowMessage.NewsID = null;
				//    mFaceShowMessage.NewsType = "预算申请";
				//    mFaceShowMessage.ReadTime = null;
				//    mFaceShowMessage.DELFLAG = 0;
				//    mFaceShowMessage.ProjectID = cashorder_model.ProjectID;
				//    mFaceShowMessage.Receive = cashorder_model.Checker.ToString();
				//    mFaceShowMessage.URLS = ((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME.ToString() + ")提交预算申请<a href='/Admin/budgetManage/budgetmanage.aspx?Status=" + cashorder_model.Status.ToString() + "&role=manager' target='_self' title='提交时间:" + DateTime.Now + "'>  点击处理</a>";
				//    bFaceShowMessage.Add(mFaceShowMessage);
				//    /*给业务申请者发信息*/
				//}

				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在返回部门预算编辑页面\"); location.href = \"add.aspx?ID="+ ParentId + "\";</script>";
				Response.Write(coutws);
			}
			catch
			{ }
		}

		/// <summary>
		/// 点击返回触发事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_cancel_click(object sender, EventArgs e)
		{
			string redirectUrl = "<script language=\"javascript\" type=\"text/javascript\">location.href = \"add.aspx?ID=" + ParentId + "\";</script>";
			Response.Write(redirectUrl);
		}


		protected void BTN_Departmetn_Click(object sender, EventArgs e)
		{
			DepartIdChanged();

			if (Request["ID"] != null)
				ShowInitInfor(common.cleanXSS(Request["ID"].ToString()));
		}


		/// <summary>
		/// 加载所属预算
		/// </summary>
		protected void ShowParentBudgetList(string userid)
		{
			try
			{
				DataTable DT = new DataTable();
				//我负责的预算
				//string sql1 = " SELECT * FROM budget WHERE  (charindex('"+ common.SafeString(userid) + "',ManagerIDs)>0)";

				string sql1 = " SELECT * FROM budget WHERE  ( ParentId is null or ParentId = 0)";

				DT = pageControl.doSql(sql1).Tables[0];

				if (DT.Rows.Count > 0)
				{
					DDL_Budget.DataSource = DT;
					DDL_Budget.DataValueField = "ID";
					DDL_Budget.DataTextField = "BudgetName";
					DDL_Budget.DataBind();
				}
				else
				{
					ListItem li = new ListItem("-暂无可选项目-", "");
					// DDL_Project.Items.Add(li);
				}
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
		/// 部门进行切换的时候，要做人员列表的切换
		/// </summary>
		private void DepartIdChanged()
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


		private void ShowManagers()
		{
			DataTable dt = new DataTable();
			//string sql = "SELECT ID,[Name] FROM USER_Groups WHERE DELFLAG=0 group by ID,[Name]";
			string sql = " SELECT [REALNAME], [ID] FROM [vUSER_Users]";
			dt = pageControl.doSql(sql).Tables[0];
			if (dt.Rows.Count > 0)
			{
				this.DP_Manager.DataSource = dt;
				this.DP_Manager.DataTextField = "REALNAME";
				this.DP_Manager.DataValueField = "ID";
				this.DP_Manager.DataBind();

				//ListItem li = new ListItem("-全部-", "9999");
				//li.Selected = true;
				//DP_Department.Items.Insert(0, li);
			}
			else
			{
				ListItem li = new ListItem("-暂无可选人员-", "");
				DP_Manager.Items.Insert(0, li);
			}
		}

	}
}