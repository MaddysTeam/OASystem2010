using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.personalProjectManage.OANews
{
    public partial class modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "项目 > 我的项目 > 信息发布 > 编辑信息 ";
                /*设置模板页中的管理值*/
            }
        }
    }
}
