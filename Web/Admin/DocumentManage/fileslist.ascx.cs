using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Dianda.Web.Admin.DocumentManage
{
	public partial class fileslist : System.Web.UI.UserControl
	{
		COMMON.common commons = new Dianda.COMMON.common();
		BLL.Document_Folder bdf = new Dianda.BLL.Document_Folder();
		COMMON.pageControl pcdosql = new Dianda.COMMON.pageControl();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
			}
		}
		/// <summary>
		/// 文件夹列表是否要显示
		/// </summary>
		/// <param name="isshow"></param>
		public void isShowFolderList(bool isshow)
		{
			try
			{
				GridView1.Visible = isshow;
			}
			catch
			{
			}
		}
		/// <summary>
		/// 获取当前文件的数量
		/// </summary>
		/// <returns></returns>
		public int getFileListnum()
		{
			if (GridView2.Rows.Count > 0)
			{
				return GridView2.Rows.Count;
			}
			else
			{
				return 0;
			}
		}
		/// <summary>
		/// 根据传过来的文件夹的ID值，遍历文件夹及其下级子文件夹的目录
		/// </summary>
		/// <param name="folderlist"></param>
		public void ShowFoldes(string folderlist, string fileList)
		{
			try
			{
				DataTable dtAll = new DataTable();//用来接收汇总后文件夹的数据
				DataTable dtAllfile = new DataTable();//用来接收汇总后的文件的数据
				string sqlinfile = commons.makeSqlIn(fileList, ';');
				string sqlin = commons.makeSqlIn(folderlist, ';');
				DataTable dt = new DataTable();
				if (folderlist.Length > 1)
				{
					dt = bdf.GetList(" DELFLAG='0' and  ID IN " + sqlin).Tables[0];
				}
				if (fileList.Length > 1)
				{
					string sqlfile = "select * from vDocument_File where DELFLAG='0' and id in" + sqlinfile;
					dtAllfile = pcdosql.doSql(sqlfile).Tables[0];//获取到被选择的文件的数据集合
				}
				if (dt.Rows.Count > 0)
				{
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						string paths = dt.Rows[i]["COLUMNSPATH"].ToString();
						//用循环的方式构建DT（文件夹）
						DataTable dt1 = bdf.GetList(" DELFLAG='0' and COLUMNSPATH LIKE '" + paths + "%'").Tables[0];
						if (dt1.Rows.Count > 0)
						{
							dtAll = commons.CombineTheSameDatatable(dt1, dtAll);
						}

						//处理文件的
						string sqlfile2 = "select * from vDocument_File where DELFLAG='0' and COLUMNSPATH LIKE '" + paths + "%'";
						DataTable dtf2 = pcdosql.doSql(sqlfile2).Tables[0];
						if (dtf2.Rows.Count > 0)
						{
							dtAllfile = commons.CombineTheSameDatatable(dtf2, dtAllfile);
						}

					}
					dtAll = commons.makeDistinceTable(dtAll, "COLUMNSPATH");//将重复的数据处理掉

					dtAllfile = commons.makeDistinceTable(dtAllfile, "ID");//将重复的数据处理掉

					if (dtAll.Rows.Count > 0)
					{
						GridView1.DataSource = dtAll;
						GridView1.DataBind();
						GridView1.Visible = true;
					}
					else
					{
						GridView1.Visible = false;
					}


				}
				if (dtAllfile.Rows.Count > 0)
				{
					GridView2.DataSource = dtAllfile;
					GridView2.DataBind();
					GridView2.Visible = true;
				}
				else
				{
					GridView2.Visible = false;
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// 获取到当前要删除的文件的列表，返回{文件夹的ID组合串、文件的ID组合串}
		/// </summary>
		/// <returns></returns>
		public string[] GetDeleteList()
		{
			string[] coutw = { "0", "0" };
			try
			{
				//先从G1中找
				int g1 = GridView1.Rows.Count;
				string g1string = "";
				for (int i = 0; i < g1; i++)
				{
					HiddenField hid = (HiddenField)GridView1.Rows[i].Cells[0].FindControl("HiddenField_ID");
					g1string = g1string + hid.Value.ToString() + ";";//文件夹

				}
				coutw[0] = g1string;
				//再从G2中找
				string g2string = "";
				int g2 = GridView2.Rows.Count;
				for (int i = 0; i < g2; i++)
				{
					HiddenField hid = (HiddenField)GridView2.Rows[i].Cells[0].FindControl("HiddenField_ID");
					g2string = g2string + hid.Value.ToString() + ";";//文件
				}
				coutw[1] = g2string;
			}
			catch
			{

			}
			return coutw;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
				{
					e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
					e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

					string Sizeof = DataBinder.Eval(e.Row.DataItem, "Sizeof").ToString();
					if (Sizeof.Length > 3)
					{
						double sizeofd = double.Parse(Sizeof);
						sizeofd = Math.Round(sizeofd / 1024, 2);
						e.Row.Cells[2].Text = sizeofd.ToString() + "M";
					}
					if (Sizeof.Length > 7)
					{
						double sizeofd = double.Parse(Sizeof);
						sizeofd = Math.Round(sizeofd / 1024 / 1024, 2);
						e.Row.Cells[2].Text = sizeofd.ToString() + "G";
					}
				}
			}
			catch
			{ }
		}
	}
}