using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.presonPlan.OApresonmanage
{
	public partial class NoteDetail : System.Web.UI.Page
	{
		Dianda.COMMON.pageControl PageControl = new Dianda.COMMON.pageControl();
		Dianda.Model.USER_Users UserModel = new Dianda.Model.USER_Users();
		Dianda.Model.Personal_Notepad notePadModel = new Dianda.Model.Personal_Notepad();
		Dianda.BLL.Personal_Notepad notePadBll = new Dianda.BLL.Personal_Notepad();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			try
			{
				if (!IsPostBack)
				{
					string pageindex = null;//分页服务

					try
					{
						pageindex = Request["pageindex"];
					}
					catch
					{
					}
					string count = dtrowsHidden.Value.ToString();
					if (count.Length == 0)
					{
						setRowCout();
						count = dtrowsHidden.Value.ToString();
					}
					else
					{
						count = "0";
					}
					if (count == null || count == "")
					{
						count = "0";
					}
					int countInt = int.Parse(count);
					if (pageindex == null || pageindex == "")
					{
						pageindex = "1";
					}
					int pageindexInd = int.Parse(pageindex);
					ShowKcList(pageindexInd);
				}
			}
			catch
			{
			}
		}



		/// <summary>
		/// 获取到当前数据集中总共有多少条记录
		/// </summary>
		private void setRowCout()
		{
			try
			{
				UserModel = (Dianda.Model.USER_Users)Session["USER_Users"];
				DataTable dt = new DataTable();
				string sqlwhere1 = " delflag='0' and UserID = '" + UserModel.ID + "'";

				// dt = NewsBll.GetAllList(sqlwhere1).Tables[0];
				int count = PageControl.tableRowCout(sqlwhere1, "Personal_Notepad", "UserID");
				// int count = dt.Rows.Count;
				if (count > 0)
				{
					dtrowsHidden.Value = count.ToString();
				}
			}
			catch
			{
			}
		}

		private void ShowKcList(int pageindex)
		{
			try
			{
				DataTable DT = new DataTable();
				UserModel = (Dianda.Model.USER_Users)Session["USER_Users"];
				string sqlWhere1 = " delflag='0' and UserID='" + UserModel.ID + "'";
				string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
				if (allTiaoshu == "" || allTiaoshu == null)
				{
					allTiaoshu = "0";
				}
				int alltiaoshuInt = int.Parse(allTiaoshu);
				// DT =RoleBll.GetList_FenYe(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt).Tables[0];//用带有分页功能的列表进行显示
				DT = PageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "Personal_Notepad", "DATETIME").Tables[0];//用带有分页功能的列表进行显示
				pageindex = PageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
				if (DT.Rows.Count > 0)
				{
					//当获取到的数据集不为空的时候，显示在GridView1中
					GridView1.Visible = true;
					GridView1.DataSource = DT;//指定GridView1的数据是DT
					pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
					GridView1.DataBind();//将上面指定的信息绑定到GridView1上

					PageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
					notice.Text = "";
					pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
				}
				else
				{
					GridView1.Visible = false;
					notice.Text = "*没有符合条件的结果！";
					pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
				}
			}
			catch (Exception)
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
			try
			{
				int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
				pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值
				ShowKcList(page);
			}
			catch (Exception)
			{
			}
			//ShowKcList(page, keys, KeySel);//调用显示
		}


		/// <summary>
		/// 当分页控件中的下拉菜单触发时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
				pageindexHidden.Value = page.ToString();
				ShowKcList(page);
			}
			catch (Exception)
			{
			}

			//ShowKcList(page, keys, KeySel);//调用显示
		}
		protected void LinkButton_Del_Click1(object sender, EventArgs e)
		{
			//获得ID
			try
			{
				string strId = ((ImageButton)sender).CommandArgument.ToString();

				//通过ID获得实体类
				notePadModel = notePadBll.GetModel(int.Parse(strId));
				//定义物理删除
				int Delflag = 1;
				notePadModel.DELFLAG = Delflag;
				//删除后更新
				notePadBll.Update(notePadModel);
				Label_notice.Text = "删除成功!";

				setRowCout();
				ShowKcList(int.Parse(pageindexHidden.Value.ToString()));
				Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
				Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

				bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "删除人员信息", "删除" + user_model.REALNAME + "(" + user_model.USERNAME + ")" + "成功");
			}
			catch (Exception)
			{
				Label_notice.Text = "删除失败!";
			}
		}
		//返回按钮
		protected void Get_Back_Click(object sender, EventArgs e)
		{
			Response.Redirect("Test.aspx");
		}
		//截取字符串
		public string substr(object str)
		{
			string substr2 = Convert.ToString(str);
			if (substr2.Length > 10)
			{
				substr2 = substr2.Remove(10) + "...";
			}
			return substr2;
		}
	}
}
