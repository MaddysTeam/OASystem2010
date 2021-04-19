using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin
{
    public partial class department_Index : System.Web.UI.Page
    {
        Model.USER_Users modelUser = new Dianda.Model.USER_Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "部门主页";

                //wult 2011-2-15 alter
                //进入部门主页时显示下面两个控件
                DropDownList Master_DDList_BMXZ = (Master.FindControl("Master_DDList_BMXZ") as DropDownList);
                Master_DDList_BMXZ.Visible = true;
                /*设置模板页中的管理值*/
            }
        }
    }
}
