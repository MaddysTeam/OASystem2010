using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAproject
{
    public partial class show : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowInfo(Request["ID"]);
            }
        }

        /// <summary>
        /// 根据传过来的分类ID，显示该分类的详细信息
        /// </summary>
        /// <param name="id"></param>
        protected void ShowInfo(string id)
        {
            try
            {
                string sql = "SELECT * FROM Project_Columns WHERE (ID = '"+id+"')";

                DataTable dt = new DataTable(); 

                dt = pageControl.doSql(sql).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    Label_columninfo.Text = dt.Rows[0]["INFORS"].ToString();
                }
                else
                {
                    Label_columninfo.Text = "没有找到对应的分类信息！";
                }
            }
            catch
            {
                Label_columninfo.Text = "没有找到对应的分类信息！";
            }
        }
    }
}
