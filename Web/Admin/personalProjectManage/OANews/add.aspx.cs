using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.personalProjectManage.OANews
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                this.ucadd1.foritems = "PROJECT";
                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "项目 > 我的项目 > 信息发布 > 新建信息 ";
                /*设置模板页中的管理值*/
            }
        }
    }
}
