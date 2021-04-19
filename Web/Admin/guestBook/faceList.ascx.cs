using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Dianda.Web.Admin.guestBook
{
	public partial class faceList : System.Web.UI.UserControl
	{
		Dianda.COMMON.pageControl PageControl = new Dianda.COMMON.pageControl();// new COMMON.pageControl();//引入通用操作类
		Dianda.COMMON.common commons = new Dianda.COMMON.common();
		BLL.GUESTBOOK_MAIN bbook = new Dianda.BLL.GUESTBOOK_MAIN();
		Model.GUESTBOOK_MAIN mbook = new Dianda.Model.GUESTBOOK_MAIN();

		protected void Page_Load(object sender, EventArgs e)
		{

			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
			try
			{
				if (!Page.IsPostBack)
				{

					setRowCout("");
					ShowKcList(1, "");
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// 根据当前页的搜索条件、留言属于那个模块、模块中信息的ID
		/// </summary>
		/// <param name="key">搜索条件</param>
		/// <param name="FROMS">从那个模块来的</param>
		/// <param name="PID">信息模块的ID</param>
		private void setRowCout(string key)
		{
			try
			{
				DataTable dt = new DataTable();
				string sqlwhere1 = "";
				sqlwhere1 = sqlWhere(key);
				int count = PageControl.tableRowCout(sqlwhere1, "GUESTBOOK_MAIN", "ID");
				if (count > 0)
				{
					dtrowsHidden.Value = count.ToString();
				}
			}
			catch
			{
			}
		}
		/// <summary>
		/// 根据当前页的搜索条件、留言属于那个模块、模块中信息的ID
		/// </summary>
		/// <param name="key">搜索条件</param>
		/// <param name="FROMS">从那个模块来的</param>
		/// <param name="PID">信息模块的ID</param>
		private string sqlWhere(string key)
		{
			string coutw = " delflag='0' and STATUS='1'";
			if (key == null || key.Length == 0)
			{
				coutw = coutw;
			}
			else
			{
				coutw = coutw + " and  (CONTENTS like '%" + key + "%' or WRITER like '%" + key + "%' or RE_CONTENTS like '%" + key + "%')";
			}
			return coutw;
		}
		/// <summary>
		/// 分页显示
		/// </summary>
		/// <param name="pageindex">页码</param>
		/// <param name="keys">搜索条件</param>
		protected void ShowKcList(int pageindex, string KeySel)//分页显示符合条件的内容
		{
			DataTable DT = new DataTable();
			string sqlWhere1 = "";
			sqlWhere1 = sqlWhere(KeySel);
			string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
			if (allTiaoshu == "" || allTiaoshu == null)
			{
				allTiaoshu = "0";
			}
			int alltiaoshuInt = int.Parse(allTiaoshu);
			DT = PageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "GUESTBOOK_MAIN", "DATETIME").Tables[0];//用带有分页功能的列表进行显示
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
				notice.Text = "";
				pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
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
			string KeySel = "";// TextBox_KEYS.Text.ToString();
			ShowKcList(page, KeySel);//调用显示
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
			string KeySel = "";// TextBox_KEYS.Text.ToString();
			ShowKcList(page, KeySel);//调用显示
		}

		/// <summary>
		/// 当GridView1绑定完毕数据集后，可以通过RowDataBound事件给该GRIDVIEW中数据做切合实际的转换
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
			{
				e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#F4F4F4'");
				e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

			}
		}

		protected void Button_search_Click(object sender, EventArgs e)
		{
			try
			{
				int page = 1;
				pageindexHidden.Value = page.ToString();
				string KeySel = TextBox_KEYS.Text.ToString();
				if (KeySel.Length > 0)
				{
					KeySel = KeySel.Trim();
				}

				setRowCout(KeySel);

				ShowKcList(1, KeySel);//调用显示
			}
			catch
			{
			}
		}
	}
}
