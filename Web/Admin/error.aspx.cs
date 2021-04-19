using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "系统提示页";
                    //设置模板页中的管理值
                }
            }
            catch
            {
            }
        }
    }
}
