using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.personalProjectManage.OANews
{
    public partial class UcNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 发件箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Send_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx?status=1");
        }
        /// <summary>
        /// 收件箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Receive_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx?status=2");
        }
    }
}