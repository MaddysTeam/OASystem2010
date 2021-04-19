using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Dianda.Web.Admin
{
    public partial class ucProjectUserList : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();//引入通用操作类
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        Model.USER_Users modelUser = new Dianda.Model.USER_Users();//T

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        public void BindData()
        {
            try
            {
                string strSQL = "SELECT * FROM vUSER_Users WHERE " + SQLCondition();
                DataTable dt = new DataTable();
                dt = pageControl.doSql(strSQL).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition()
        {
            try
            {
                modelUser = (Model.USER_Users)Session["USER_Users"];
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("  DepartMentID like '%" + modelUser.TEMP4.ToString() + "%' and WorkStats='1' order by REALNAME ");//在职
                return sbSql.ToString();
            }
            catch
            {
                return "1=2";
            }
          
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
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");
                }
            }
            catch
            {
            }
        }
    }
}