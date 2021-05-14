﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Dianda.Web.Admin.budgetManage.department
{
	public partial class list : System.Web.UI.Page
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

		public int ParentId
		{
			get
			{
				if (ViewState["ParentId"] != null)
					return int.Parse(ViewState["ParentId"].ToString());
				return 0;
			}
			set { ViewState["ParentId"] = value; }
		}
		#endregion

	
		COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
		Model.Budget budget_model = new Dianda.Model.Budget();
		BLL.Budget budget_bll = new Dianda.BLL.Budget();
		BLL.USER_Groups groups_bll = new Dianda.BLL.USER_Groups();
		Model.USER_Users user_model = new Dianda.Model.USER_Users();
		COMMON.common common = new COMMON.common();


		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				////======初始化年份下拉列表 by guanzhq on 2012年3月20日======
				//showYears(DropDownList_year, DateTime.Now.Year.ToString());

				PageRole = Request["role"];

				string count = dtrowsHidden.Value.ToString();
				if (count.Length == 0)
				{
					setRowCout();//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
					count = dtrowsHidden.Value.ToString();
				}
				if (string.IsNullOrEmpty(count))
				{
					count = "0";
				}
				int countint = int.Parse(count);

				string pageindex = null;//这里是为分页服务的
				pageindex = Request["pageindex"];
				if (pageindex == null || pageindex == "")
				{
					pageindex = "1";
				}
				int pageindex_int = int.Parse(pageindex);

				//获取父预算下拉列表
				BindParentBudgetDropdownList();

				BindData(pageindex_int, ParentId);
				
			}
		}

		/// <summary>
		///  绑定父预算下拉列表
		/// </summary>
		private void BindParentBudgetDropdownList()
		{
			DataTable dt = new DataTable();
			string sql = "SELECT ID,[BUDGETNAME] FROM BUDGET WHERE PARENTID=0 group by ID,[BUDGETNAME]";
			dt = pageControl.doSql(sql).Tables[0];
			if (dt.Rows.Count > 0)
			{

				DDL_PARENT_BUDGET.DataSource = dt;
				DDL_PARENT_BUDGET.DataTextField = "BUDGETNAME";
				DDL_PARENT_BUDGET.DataValueField = "ID";
				DDL_PARENT_BUDGET.DataBind();

				ListItem li = new ListItem("-全部-", "9999");
				li.Selected = true;
				DDL_PARENT_BUDGET.Items.Insert(0, li);

			}
		}

		/// <summary>
		/// 获取到当前数据集中总共有多少条记录
		/// </summary>
		private void setRowCout()
		{
			try
			{
				user_model = (Model.USER_Users)Session["USER_Users"];
				string strSQL = "select * from vBudget_List where 1=1 ";
				if (ParentId > 0)
				{
					strSQL += "parentId=" + ParentId;
				}
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

		protected void DDL_parent_budget_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (this.DDL_Status.SelectedValue == "1" || this.DDL_Status.SelectedValue == "")
			//{
			//    this.Button_sumbit.Enabled = false;
			//    Button_modify.Enabled = false;
			//}
			//else
			//{
			//    this.Button_sumbit.Enabled = true;
			//    Button_modify.Enabled = true;
			//}

			ParentId = int.Parse(this.DDL_PARENT_BUDGET.SelectedValue);
			setRowCout();
			BindData(1, ParentId);//调用显示
		}

		protected void BindData(int pageindex, int parentId)
		{
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(" 1=1 ");
				if (parentId > 0)
				{
					sb.Append(" and parentId=");
					sb.Append(parentId);
				}

				DataTable dt = new DataTable();
				string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
				int alltiaoshuInt = int.Parse(allTiaoshu);
				dt = pageControl.GetList_FenYe_Common(sb.ToString(), pageindex, GridView1.PageSize, alltiaoshuInt, "vBudget_List", "ADDTIME").Tables[0];
				pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
				if (dt.Rows.Count > 0)
				{
					//""表示全部，0待审，1审核通过，2审核不通过
					//if (this.DDL_Status.SelectedValue == "1" || this.DDL_Status.SelectedValue == "")
					//if (this.DDL_Status.SelectedValue == "1")
					//{
					//	this.Button_sumbit.Enabled = false;
					//	Button_modify.Enabled = false;
					//	Button_check.Enabled = false;
					//}
					//else
					//{
					//	this.Button_sumbit.Enabled = true;
					//	Button_modify.Enabled = true;
					//	Button_check.Enabled = true;
					//}
					// Button_reset.Enabled = true;
					GridView1.Visible = true;
					GridView1.DataSource = dt;//指定GridView1的数据是dv
					GridView1.DataBind();//将上面指定的信息绑定到GridView1上
					notice.Text = "";

					int parentBudgetNameIndex = 5, parentBalanceIndex = 6, parentYEBalanceIndex = 7;
					common.GroupRows(GridView1, parentBudgetNameIndex);
					common.GroupRows(GridView1, parentBalanceIndex);
					common.GroupRows(GridView1, parentYEBalanceIndex);

					pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
					pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件

					//汇总统计值
					//Label_money1.Text = daishenhe.ToString();
					//Label_money2.Text = tongguo.ToString();
					//Label_money3.Text = weitongguo.ToString();string.Format("{0:N}", 250000)
					//Label_money1.Text = string.Format("{0:N}", daishenhe).Split('.')[1].ToString().Equals("00") ? string.Format("{0:N}", daishenhe).Split('.')[0].ToString() : string.Format("{0:N}", daishenhe);
					//Label_money2.Text = string.Format("{0:N}", tongguo).Split('.')[1].ToString().Equals("00") ? string.Format("{0:N}", tongguo).Split('.')[0].ToString() : string.Format("{0:N}", tongguo);//这样是防止出现科学记数法
					//Label_money3.Text = string.Format("{0:N}", weitongguo).Split('.')[1].ToString().Equals("00") ? string.Format("{0:N}", weitongguo).Split('.')[0].ToString() : string.Format("{0:N}", weitongguo);

					//div_total.Visible = true;
				}
				else
				{
					//Button_sumbit.Enabled = false;
					//Button_modify.Enabled = false;
					//Button_check.Enabled = false;
					//div_total.Visible = false;
					// Button_reset.Enabled = false;
					GridView1.Visible = false;
					notice.Text = "*没有符合条件的结果！";

					pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
					if (alltiaoshuInt > 0)
					{
						BindData(pageindex - 1,parentId);
					}
				}
			}
			catch(Exception e)
			{

			}
		}


		/// <summary>
		/// 点击新增按钮触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_add_onclick(object sender, EventArgs e)
		{
			Response.Redirect("add.aspx");
		}

		/// <summary>
		///点击修改按钮触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_modify_onclick(object sender, EventArgs e)
		{
			//选择编辑的条数只能为一条
			int num = 0;
			int rows = GridView1.Rows.Count;
			if (rows > 0)
			{
				for (int i = 0; i < rows; i++)
				{
					CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
					if (cb.Checked)
					{
						num = num + 1;
					}
				}

				if (num == 0)
				{
					tag.Text = "请选择一条要操作的纪录！";

				}
				else if (num > 1)
				{
					tag.Text = "编辑时只能选择一条记录进行操作！";
				}
				else
				{
					for (int j = 0; j < rows; j++)
					{
						CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
						string id = GridView1.DataKeys[j]["ID"].ToString();

						if (cb1.Checked)
						{
							//Response.Redirect("addbudget.aspx?pageindex=" + pageindexHidden.Value + "&Status=" + DDL_Status.SelectedValue.ToString() + "&ID=" + id);
							Response.Redirect("addChild.aspx?pageindex=" + pageindexHidden.Value + "&ID=" + id);
						}
					}
				}
			}
		}


		/// <summary>
		/// 点击删除按钮触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button_delete_onclick(object sender, EventArgs e)
		{
			int num = 0;
			int rows = GridView1.Rows.Count;
			if (rows > 0)
			{
				for (int i = 0; i < rows; i++)
				{
					CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
					if (cb.Checked)
					{
						num = num + 1;
					}
				}

				if (num == 0)
				{
					tag.Text = "注销时最少选择一条数据！";

				}
				else
				{
					tag.Text = "";
					for (int j = 0; j < rows; j++)
					{
						CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
						// HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
						string id = GridView1.DataKeys[j]["ID"].ToString();
						if (cb1.Checked)
						{
							budget_model = new Dianda.Model.Budget();
							budget_model = budget_bll.GetModel(Int32.Parse(id));
							budget_model.Statas = 0;
							budget_bll.Update(budget_model);

							tag.Text = "操作成功！";
							// string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";


							// 添加操作日志
							Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
							Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
							bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "删除部门子项目预算" + budget_model.Code /*Request["tags"].ToString()*/, "删除部门子项目预算成功");

							string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";
							Response.Write(coutws);
						}
					}
				}
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
			setRowCout();
			BindData(page, ParentId);//调用显示

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
			setRowCout();
			BindData(page, ParentId);//调用显示
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
					//grievSearch(true);
				}
				else//全不选
				{
					//grievSearch(false);
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
					//e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
					//e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

					//HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
					string id = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
					string budgetName = DataBinder.Eval(e.Row.DataItem, "BudgetName").ToString();
					//string time = DataBinder.Eval(e.Row.DataItem, "EndTime").ToString();
					//string CardNum = DataBinder.Eval(e.Row.DataItem, "CardNum").ToString();
					string parentBudgetName = DataBinder.Eval(e.Row.DataItem, "ParentBudgetName").ToString();
					//string BudgetList = DataBinder.Eval(e.Row.DataItem, "BudgetList").ToString();
					//string SFOrderName = DataBinder.Eval(e.Row.DataItem, "SFOrderName").ToString();
					//string Notes = DataBinder.Eval(e.Row.DataItem, "NOTES").ToString();
					//if (!string.IsNullOrEmpty(time))
					//{
					//	DateTime dtime = new DateTime();
					//	//获取当前资金卡的到期日期                
					//	dtime = DateTime.Parse(time);
					//	//判断是否过期
					//	if (DateTime.Parse(DateTime.Now.ToLongDateString()) > dtime)
					//	{
					//		e.Row.Cells[12].Text = "<span style='color:Red'>已过期</span>";
					//	}
					//}
					//e.Row.Cells[2].Text = "<a href=\"javascript:window.showModalDialog('showHistory.aspx?id=" + ID + "','','dialogWidth=726px;dialogHeight=400px');\" title='" + CardNum + "'>" + CardName + "</a>";

					e.Row.Cells[2].Text = "<a href='showHistory.aspx?id=" + id + "&PageRole=" + PageRole + "' title='" + budgetName + "'>" + budgetName + "</a>";
					if (parentBudgetName.Equals(""))
					{
						e.Row.Cells[5].Text = "--";
					}
					else
					{
						e.Row.Cells[5].Text = parentBudgetName;
					}

					//e.Row.Cells[10].Text = "<a href='" + BudgetList + "' target='_blank'>" + SFOrderName + "</a>";
				}
			}
			catch
			{
			}
		}

		///// <summary>
		///// 显示年份的数据 by guanzhq on 2012年3月20日
		///// </summary>
		///// <param name="dl"></param>
		///// <param name="years"></param>
		//private void showYears(DropDownList dl, string years)
		//{
		//    dl.Items.Clear();
		//    DateTime dt = DateTime.Now;
		//    for (int i = 2000; i < dt.Year + 5; i++)
		//    {
		//        ListItem li = new ListItem();
		//        li.Value = i.ToString();
		//        li.Text = i.ToString() + "年";
		//        dl.Items.Add(li);
		//    }
		//    if (!String.IsNullOrEmpty(years))
		//    {
		//        dl.SelectedValue = years;
		//    }
		//} }
		//    catch
		//    { }
		//}
		/// <summary>
		/// 年份选择改变 by guanzhq on 2012年3月20日
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DropDownList_year_SelectedIndexChanged(object sender, EventArgs e)
		{
			// setRowCout();
			//BindData(1);//调用显示
		}

	}
}
