using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.newsManage.OAnews
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "消息 > 发布消息 ";
                /*设置模板页中的管理值*/
            }
        }
    }
}
