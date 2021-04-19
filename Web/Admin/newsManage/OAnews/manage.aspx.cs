using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.newsManage.OAnews
{
    public partial class manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["PARENTID"] != null && !String.IsNullOrEmpty(Request["PARENTID"]))
                {
                    if (Request["PARENTID"] == "5")
                    {
                        /*设置模板页中的管理值*/
                        (Master.FindControl("Label_navigation") as Label).Text = "消息 > 通知公告 ";
                        /*设置模板页中的管理值*/
                        

                    }
                    else if (Request["PARENTID"] == "4")
                    {
                        /*设置模板页中的管理值*/
                        (Master.FindControl("Label_navigation") as Label).Text = "消息 > 个人消息 ";
                        /*设置模板页中的管理值*/

                    }
                    else if (Request["PARENTID"] == "3")
                    {
                        /*设置模板页中的管理值*/
                        (Master.FindControl("Label_navigation") as Label).Text = "消息 > 部门消息 ";
                        /*设置模板页中的管理值*/

                    }
                    
                }
                //标题文字
                if (Request.Params["status"] != null && !String.IsNullOrEmpty(Request["status"]))
                {
                    if (Request["status"] == "1")
                    {
                        LabelTitle.Text = "发件箱";
                    }
                    else
                    {
                        LabelTitle.Text = "收件箱";
                    }

                }
                else
                {
                    if (Request.Params["PARENTID"].ToString().Equals("5"))
                    {
                        LabelTitle.Text = "发件箱";
                    }else
                    {
                        LabelTitle.Text = "收件箱";
                    }
                }
            }
        }
    }
}
