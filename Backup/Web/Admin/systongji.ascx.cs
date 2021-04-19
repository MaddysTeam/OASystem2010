using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin
{
    public partial class systongji : System.Web.UI.UserControl
    {
        COMMON.pageControl visitlog = new Dianda.COMMON.pageControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getSystemVisitNum();
                  //  getCourseVisitNum(GridView_courseVisit);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 获取到平台的访问统计
        /// </summary>
        /// <param name="gv"></param>
        private void getSystemVisitNum()
        {
            try
            {
                Label_nums.Text =visitlog.getVisitlog();
            }
            catch
            {
            }
        }
 
        
    }
}