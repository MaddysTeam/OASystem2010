using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.SystemProjectManage.ProjectInfo
{
    public partial class proleftmenu : System.Web.UI.UserControl
    {
        Model.userPower mUserPower = new Dianda.Model.userPower();//用户的权限实体类
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    mUserPower = (Model.userPower)Session["Session_Power"];
                    JudgeMenu(mUserPower.menuRole.ToString());
                }
            }
            catch
            { }
         
        }
        /// <summary>
        /// 判断才菜单的权限
        /// </summary>
        /// <param name="menusession"></param>
        private void JudgeMenu(string menusession)
        {
            try
            {
                if (menusession.Length > 0)
                {
                    string[] menuarray = menusession.Split(';');
                    for (int i = 0; i < menuarray.Length; i++)
                    {
                        string menuName = menuarray[i].ToString();
                        if (menuName == "menu_systongji")
                        {
                            menu_systongji.Visible = true;
                        }
                        if (menuName == "menu_ProjectColumns")
                        {
                            menu_ProjectColumns.Visible = true;
                        }

                        if (menuName == "menu_ProjectList")//项目信息列表的权限
                        {
                            menu_ProjectList.Visible = true;
                        }
                        if (menuName == "menu_ProjectShenHe")//项目审核的权限
                        {
                            menu_ProjectShenHe.Visible = true;
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}