using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Dianda.COMMON;
using static Dianda.Model.Budget;

namespace Dianda.Web.Admin.budgetManage
{
	public partial class List : System.Web.UI.Page
	{
		Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
		Dianda.BLL.Document_File bDocumentfile = new Dianda.BLL.Document_File();
		Dianda.Model.Document_File mDocumentfile = new Dianda.Model.Document_File();
		Model.Project_Projects project_model = new Dianda.Model.Project_Projects();
		BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();
		USER_Ext userExt = new USER_Ext();
		Model.Budget budget_model = new Dianda.Model.Budget();
		//string tempUserId = "201010291338251A007";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{

				string role = Request["role"].ToString();

				string pageindex = null;//这里是为分页服务的

				pageindex = Request["pageindex"];

				//string count = dtrowsHidden.Value.ToString();
				//if (count.Length == 0)
				//{
				//	setRowCout();
				//	count = dtrowsHidden.Value.ToString();
				//}
				//else
				//{
				//	count = "0";
				//}
				//int countint = int.Parse(count);



				if (pageindex == null || pageindex == "")
				{
					pageindex = "1";
				}

				int pageindex_int = int.Parse(pageindex);

				setRowCout();

				ShowListInfo(pageindex_int);


			}

			//设置模板页中的管理值
			(Master.FindControl("Label_navigation") as Label).Text = "经费 > 项目经费管理 ";
			//设置模板页中的管理值
		}


		/// <summary>
		/// 获取到当前数据集中总共有多少条记录
		/// </summary>
		private void setRowCout()
		{
			try
			{
				Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
				DataTable DT = new DataTable();

				string sql = "select * from vBudget_Child_List where CHARINDEX('{0}', ManagerIDs)> 0 or CHARINDEX('{1}', ParentManagerIDs)> 0";
				sql = string.Format(sql, user_model.ID, user_model.ID);
				DT = pageControl.doSql(sql).Tables[0];
				if (DT.Rows.Count > 0)
				{
					dtrowsHidden.Value = DT.Rows.Count.ToString();
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

		/// <summary>
		///显示待审核的项目列表信息 
		/// </summary>
		/// <param name="pageindex"></param>
		protected void ShowListInfo(int pageindex)
		{
			try
			{
				DataTable DT = new DataTable();
				Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

				string sqlWhere1 = string.Format(" CHARINDEX('{0}', ManagerIDs)> 0 or CHARINDEX('{1}', ParentManagerIDs)> 0", user_model.ID, user_model.ID);

				//string role = Request["role"].ToString();

				string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
				int alltiaoshuInt = int.Parse(allTiaoshu);
				DT = pageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "vBudget_Child_List", "ADDTIME").Tables[0];
				pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
				if (DT.Rows.Count > 0)
				{
					//当获取到的数据集不为空的时候，显示在GridView1中
					GridView1.Visible = true;
					GridView1.DataSource = DT;//指定GridView1的数据是DT
					pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
					GridView1.DataBind();//将上面指定的信息绑定到GridView1上
										 //Button_check.Enabled = true;
										 //Button_checkfalse.Enabled = true;
					tag.Text = "";
					pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
					notice.Text = "";
					pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
				}
				else
				{
					GridView1.Visible = false;
					notice.Text = "*没有符合条件的结果！";
					pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
													//Button_check.Enabled = false;
													//Button_checkfalse.Enabled = false;
					if (alltiaoshuInt > 0)
					{
						ShowListInfo(pageindex - 1);
					}

				}
			}
			catch(Exception e)
			{

			}
		}

		/// <summary>
		/// 点击全选框时触发事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void CheckBox_choose_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				CheckBox CheckBox_Alltemp = (CheckBox)sender;
				if (CheckBox_Alltemp.Checked)//全选
				{
					grievSearch(true);
				}
				else//全不选
				{
					grievSearch(false);
				}
			}
			catch
			{
			}
		}

		/// <summary>
		///根据条件给值
		/// </summary>
		/// <param name="isCheck"></param>
		private void grievSearch(bool isCheck)
		{
			try
			{
				int rows = GridView1.Rows.Count;
				if (rows > 0)
				{
					for (int i = 0; i < rows; i++)
					{
						CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
						cb.Checked = isCheck;
					}
				}
			}
			catch
			{
			}
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
													// string status = DDL_Status.SelectedValue;
			setRowCout();
			ShowListInfo(page);//调用显示

		}
		/// <summary>
		/// 当分页控件中的下拉菜单触发时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
		{
			int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
			pageindexHidden.Value = page.ToString();
			// string status = DDL_Status.SelectedValue;
			setRowCout();
			ShowListInfo(page);//调用显示

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
					e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9';");
					e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

					string ManagerIds = DataBinder.Eval(e.Row.DataItem, "ManagerIds").ToString();
					e.Row.Cells[3].Text = userExt.GetUserRealNamesByIds(ManagerIds,',');

					string budgetName = DataBinder.Eval(e.Row.DataItem, "BudgetName").ToString();
					string parentBudgetName = DataBinder.Eval(e.Row.DataItem, "ParentBudgetName").ToString();
					string budgetId = DataBinder.Eval(e.Row.DataItem, "id").ToString();
					string parentId = DataBinder.Eval(e.Row.DataItem, "parentId").ToString();

					Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
					string parentMangerIds = DataBinder.Eval(e.Row.DataItem, "parentManagerIds").ToString();
					
					int budgetType = (int)DataBinder.Eval(e.Row.DataItem, "budgetType");
					if (budgetType == (int)BudgetTypeEnum.department)
					{
						e.Row.Cells[0].Text = "<a target='blank' href='department/showHistory.aspx?id=" + budgetId + "' title='" + budgetName + "'>" + budgetName + "</a>";
					}
					else
					{
						e.Row.Cells[0].Text = "<a target='blank' href='todo/showHistory.aspx?id=" + budgetId + "' title='" + budgetName + "'>" + budgetName + "</a>";
					}

					bool isParentBudgetManage = parentMangerIds.IndexOf(user_model.ID) >= 0;
					if (parentBudgetName.Equals(""))
					{
						e.Row.Cells[6].Text = "--";
					}
					else if(isParentBudgetManage)
					{
						e.Row.Cells[6].Text = "<a target='blank' href='department/showParent.aspx?id=" + parentId + "' title='" + parentBudgetName + "'>" + parentBudgetName + "</a>"; // parentBudgetName;
					}

					//HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
					//Label lb_budget = (Label)e.Row.FindControl("LB_budget");


					////业务申请的ID
					//string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
					//hid.Value = ID;


					////项目创建人用户名
					//string SendUserUserName = DataBinder.Eval(e.Row.DataItem, "SendUserUserName").ToString();
					////项目创建人真实姓名
					//string SendUserRealName = DataBinder.Eval(e.Row.DataItem, "SendUserRealName").ToString();
					////项目创建人
					//e.Row.Cells[2].Text = SendUserRealName + "[" + SendUserUserName + "]";


					////项目负责人用户名
					//string LeaderUserName = DataBinder.Eval(e.Row.DataItem, "LeaderUserName").ToString();
					////项目负责人真实姓名
					//string LeaderRealName = DataBinder.Eval(e.Row.DataItem, "LeaderRealName").ToString();
					////项目负责人
					//e.Row.Cells[3].Text = LeaderRealName + "[" + LeaderUserName + "]";

					////领导在审批预算表单后重新填写的预算经费
					//string ProjectCash = DataBinder.Eval(e.Row.DataItem, "TEMP2").ToString();

					//string BudgetList = DataBinder.Eval(e.Row.DataItem, "BudgetList").ToString();

					////if (!Request["role"].Equals("manager") && !ProjectCash.Equals(""))
					//if (!ProjectCash.Equals(""))
					//{
					//	if (ProjectCash.Substring(ProjectCash.Length - 2, 2).Equals("万元"))
					//	{
					//		e.Row.Cells[4].Text = (Convert.ToDecimal(ProjectCash.Substring(0, ProjectCash.Length - 2)) * 10000).ToString();
					//	}
					//	else
					//	{
					//		e.Row.Cells[4].Text = ProjectCash.Substring(0, ProjectCash.Length - 1);
					//	}
					//}


					////if (!Request["role"].Equals("manager") && BudgetList.Contains('@'))
					//if (BudgetList.Contains('@'))
					//{
					//	string[] budget = BudgetList.Split('@');

					//	lb_budget.Text = "<a href='" + budget[budget.Length - 1].ToString() + "' target='_blank'>点击查看</a>";
					//}
					//else
					//{
					//	lb_budget.Text = "<a href='" + BudgetList + "' target='_blank'>点击查看</a>";
					//}


				}
			}
			catch
			{

			}
		}

		/// <summary>
		/// 状态下拉列表改变时触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DDL_Status_Changed(object sender, EventArgs e)
		{
			setRowCout();
			ShowListInfo(1);//调用显示
		}


	}
}
