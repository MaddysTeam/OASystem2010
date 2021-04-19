using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DOC_transport
{
    public partial class docToIndexShow : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl PageControl = new Dianda.COMMON.pageControl();// new COMMON.pageControl();//引入通用操作类
        BLL.DOC_transport_To DOC_transport_ToBll = new Dianda.BLL.DOC_transport_To();//引入发件箱的操作类
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ShowKcList();
                }
            }
            catch
            {
            }
        }
  
        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="pageindex">页码</param>
        /// <param name="keys">搜索条件</param>
        protected void ShowKcList()
        {
            try
            {
                if (Session["USERID_SYSUSER"].ToString().Length>0)
                {
                    DataTable DT = new DataTable();
                    string sqlWhere1 = "select top 6 * from DOC_transport_To where TOUSER='" + Session["USERNAME_SYSUSER"].ToString() + "' and  delflag='0' order by ISREAD ASC,DATETIME DESC";
                    DT = PageControl.doSql(sqlWhere1).Tables[0];

                    if (DT.Rows.Count > 0)
                    {
                        //当获取到的数据集不为空的时候，显示在GridView1中
                        GridView1.Visible = true;
                        GridView1.DataSource = DT;//指定GridView1的数据是DT
                        GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                        notice.Text = "";
                    }
                    else
                    {
                        GridView1.Visible = false;
                        notice.Text = "*您暂时没有文件可以访问！";
                    }
                }
            }
            catch
            {
            }
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
               // e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#F4F4F4'");
               // e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");
                string FROMUSER = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FROMUSER"));//获取到列表中的每条记录的ID
                string ISREADS = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ISREAD"));//是否已经阅读
                string READTIMES = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "READTIME"));//阅读的时间
                string FILEPATH = DataBinder.Eval(e.Row.DataItem, "FILEPATH").ToString();
                string TITLE = DataBinder.Eval(e.Row.DataItem, "TITLES").ToString();

                string titletem = commons.MakeStringLength(TITLE, 28);
                if (FILEPATH.Length > 0)
                {
                    e.Row.Cells[1].Text = "<a href='" + FILEPATH + "'  title='" + TITLE + "[点击下载附件]'  target='_blank'>" + titletem + "</a>";
                    e.Row.Cells[3].Text = "<img src='/Admin/images/doctofrom/HAVE.gif'/>";
                }
                else
                {
                    e.Row.Cells[1].Text = "<a  title='" + TITLE + "[无附件]' target='_blank'>" + titletem + "</a>";
                    e.Row.Cells[3].Text = "<img src='/Admin/images/doctofrom/HAVENO.gif'/>";
                }
              
            }
        }
    }
}
