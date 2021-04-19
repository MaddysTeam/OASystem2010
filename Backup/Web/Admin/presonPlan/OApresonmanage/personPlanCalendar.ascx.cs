using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Dianda.Web.Admin.presonPlan.OApresonmanage
{
    public partial class personPlanCalendar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strName = "新增个人计划";
            Label_AddPersonProject.Text = "<a href=\"javascript:window.showModalDialog('add.aspx','','dialogWidth=715px;dialogHeight=250px');\">" + strName + "</a>";
        }

        private void ShowPerson()
        { 
        }
    }
}