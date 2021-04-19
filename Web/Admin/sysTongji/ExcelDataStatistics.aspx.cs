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
using System.Text;

namespace Dianda.Web.Admin.sysTongji
{
	public partial class ExcelDataStatistics : System.Web.UI.Page
	{
		Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();

		string year { get; set; }
		string toyear { get; set; }
		string month { get; set; }
		string tomonth { get; set; }
		int num = 0;

		#region 付全文  2014-2-11  页面初始化加载
		/// <summary>
		/// 页面初始化加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_Users"] == null)
			{
				string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
				Response.Write(coutws);
				return;
			}
			if (!Page.IsPostBack)
			{
				string time = this.Request.QueryString["time"].ToString();
				ParseTime(time);
				string changeyear = string.Empty;
				if (!string.IsNullOrEmpty(year))
					changeyear += ChangeYear(year);
				if (!string.IsNullOrEmpty(year) && !string.IsNullOrEmpty(toyear))
					changeyear = changeyear + "-" + ChangeYear(toyear);
				this.lblYear.Text = changeyear;
				bindDataToGV();
				this.lblCount.Text = pageControl.doSql("select count(1) from dbo.USER_Users").Tables[0].Rows[0][0].ToString();
				if (this.GridView1.Rows.Count == 0)
				{
					Response.Write("没有符合条件的数据！");
				}
				else
				{
					//导出Excel
					exportExcel();
				}
			}
		}
		#endregion

		#region 解析时间
		private void ParseTime(string time)
		{
			string[] t = time.Split('-');
			year = t[0];
			if (year.Length == 6)
				month = year.Substring(4);
			toyear = t[1];
			if (toyear.Length == 6)
				tomonth = toyear.Substring(4);
		}

		private string ChangeYear(string year)
		{
			switch (year.Length)
			{
				case 4:
					return year + "年";
				case 6:
					return year.Substring(0, 4) + "年" + Convert.ToInt32(year.Substring(4, 2)).ToString() + "月";
				default:
					return string.Empty;
			}
		}
		#endregion

		#region 付全文  2014-2-11  加载数据到GV
		/// <summary>
		/// 加载数据到GV
		/// </summary>
		/// <param name="year"></param>
		private void bindDataToGV()
		{
			StringBuilder sb = new StringBuilder();
			int Iyear = 0;
			int Itoyear = 0;
			int Imouth = 0;
			int Itomouth = 0;

			if (year.Length == 6)
			{
				Iyear = Convert.ToInt32(year.Substring(0, year.Length - 2));
				Itoyear = Convert.ToInt32(toyear.Substring(0, toyear.Length - 2));
				Imouth = Convert.ToInt32(month);
				Itomouth = Convert.ToInt32(tomonth);
				num = (Itoyear - Iyear) * 12 + Itomouth - Imouth;
			}
			else
			{
				Iyear = Convert.ToInt32(year);
				num = Convert.ToInt32(toyear) - Convert.ToInt32(year);
			}
			int index = year.Length;
			if (!year.Equals(toyear))
			{
				sb.Append("select tb1.name as FromTable,convert(varchar(10),isnull(tb2.cnt,0)) as cnt2,");
				for (int i = 3; i < num + 3; i++)
				{
					sb.Append("convert(varchar(10),isnull(tb" + i + ".cnt,0)) as cnt" + i + ",");
				}
				sb.Append("convert(varchar(10),isnull(tb2.cnt,0)");
				for (int i = 3; i < num + 3; i++)
				{
					sb.Append("+isnull(tb" + i + ".cnt,0)");
				}
				sb.Append(") as Total from (select distinct FromTable as name from FaceShowMessage)as tb1");
				for (int i = 2; i < num + 3; i++)
				{
					if (year.Length == 4)
					{
						sb.Append(" left join (select FromTable as name,count(distinct urls)as cnt  from FaceShowMessage  where delflag='0' and CONVERT(varchar(" + index + ") , [DATETIME], 112 )='" + (Iyear + i - 2) + "'  GROUP by CONVERT(varchar(" + index + ") , [DATETIME], 112 ),FromTable)as tb" + i + " on tb1.name = tb" + i + ".name");
						BoundField cnt = new BoundField();
						cnt.DataField = "cnt" + i;
						cnt.HeaderText = Imouth + "年";
						cnt.ShowHeader = true;
						cnt.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
						this.GridView1.Columns.Add(cnt);
					}
					else
					{
						string mm = string.Empty;
						if (Imouth < 10)
							mm = "0" + Imouth.ToString();
						else
							mm = Imouth.ToString();

						BoundField cnt = new BoundField();
						cnt.DataField = "cnt" + i;
						cnt.HeaderText = Imouth + "月";
						cnt.ShowHeader = true;
						cnt.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
						this.GridView1.Columns.Add(cnt);

						sb.Append(" left join (select FromTable as name,count(distinct urls)as cnt  from FaceShowMessage  where delflag='0' and CONVERT(varchar(" + index + ") , [DATETIME], 112 )='" + Iyear + "" + mm + "'  GROUP by CONVERT(varchar(" + index + ") , [DATETIME], 112 ),FromTable)as tb" + i + " on tb1.name = tb" + i + ".name");
						if (Imouth % 12 == 0)
						{
							Iyear += 1;
							Imouth = 0;
						}
						Imouth += 1;
					}
				}
				BoundField total = new BoundField();
				total.DataField = "Total";
				total.HeaderText = "合计";
				total.ShowHeader = true;
				total.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
				this.GridView1.Columns.Add(total);
			}
			else
			{
				BoundField cnt = new BoundField();
				cnt.DataField = "cnt";
				cnt.HeaderText = "cnt";
				cnt.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
				this.GridView1.Columns.Add(cnt);

				sb.Append("select FromTable,count(distinct urls) as cnt from FaceShowMessage ");
				sb.Append(" where delflag='0' and CONVERT(varchar(" + index + ") , [DATETIME], 112 )='" + year + "' ");
				sb.Append(" GROUP by CONVERT(varchar(" + index + ") , [DATETIME], 112 ),FromTable ");
				sb.Append(" order by FromTable, CONVERT(varchar(" + index + ") , [DATETIME], 112 ) ");
			}
			DataTable dt = pageControl.doSql(sb.ToString()).Tables[0];

			if (!year.Equals(toyear))
			{
				DataRow dr = dt.NewRow();
				if (year.Length == 4)
				{
					dr[0] = "年份";
					int y = Convert.ToInt32(year);
					for (int i = 1; i < num + 2; i++)
					{
						dr[i] = y + "年";
						y++;
					}
				}
				else
				{
					int y = Convert.ToInt32(year.Substring(0, year.Length - 2));
					dr[0] = "月份";
					int mh = Convert.ToInt32(month);
					for (int i = 1; i < num + 2; i++)
					{
						dr[i] = y + "年" + mh + "月";
						if (mh % 12 == 0)
						{
							y += 1;
							mh = 0;
						}
						mh++;
					}
				}
				dr[num + 2] = "合计";
				dt.Rows.InsertAt(dr, 0);
			}

			this.GridView1.DataSource = dt;
			this.GridView1.DataBind();
			this.GridView1.HeaderRow.Visible = false;
		}
		#endregion

		public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
		{
			// Confirms that an HtmlForm control is rendered for
		}

		#region 付全文  2014-2-11  table导出Excel
		/// <summary>
		/// table导出Excel
		/// </summary>
		private void exportExcel()
		{
			Response.Clear();
			Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode("教研室内网OA平台使用情况" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls", Encoding.UTF8).ToString());
			Response.Charset = "gb2312";
			Response.ContentType = "application/ms-excel";
			this.EnableViewState = false;
			System.IO.StringWriter stringWrite = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
			mxmk.RenderControl(htmlWrite);
			StringBuilder sb = new StringBuilder();
			sb.Append("<head><style type='text/css'>");
			sb.Append("#mxmk {border-right: 1px solid #a4a4a4;border-bottom: 1px solid #a4a4a4;} #mxmk th {border-left: 1px solid #a4a4a4;border-top: 1px solid #a4a4a4;} #mxmk td {border-left: 1px solid #a4a4a4;border-top: 1px solid #a4a4a4;}");
			sb.Append(".Gridview th{border-left: 1px solid #a4a4a4;border-top: 1px solid #a4a4a4;}.Gridview td {border-left: 1px solid #a4a4a4;border-top: 1px solid #a4a4a4;} ");
			sb.Append("</style></head><body>");
			sb.Append(stringWrite.ToString() + "</body>");
			Response.Write(sb.ToString());
			//Response.Write(stringWrite.ToString());
			Response.End();
			//HttpContext.Current.ApplicationInstance.CompleteRequest();
		}
		#endregion
	}
}
