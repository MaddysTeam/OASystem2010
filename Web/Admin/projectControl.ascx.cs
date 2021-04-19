using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin
{
    public partial class projectControl : System.Web.UI.UserControl
    {
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        Model.USER_Users mUser = new Dianda.Model.USER_Users();//加载用户的实体类
        BLL.Project_Projects bllProject = new Dianda.BLL.Project_Projects();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //ProjectPanal_1(正常的状态)、ProjectPanal_2(被选中的状态)
                    if (Session["Session_Project_linkshow"] != null)
                    {
                        reSetLinkbutton();// 重置按钮的样式
                        ((LinkButton)this.FindControl(Session["Session_Project_linkshow"].ToString())).CssClass = "ProjectPanal_2";
                    }
                    Web.Admin.personalProjectManage.MakeProjectSession makeprojectsession = new Dianda.Web.Admin.personalProjectManage.MakeProjectSession();
                    makeprojectsession.getMyProjectList(this.Page);

                    //初始化项目下拉列表
                    DataTable dt_project = (DataTable)Session["Project_Projects"];

                    if (dt_project.Rows.Count > 0)
                    {
                        bool isshowWu = false;//是否显示无这个项目
                        
                        mUser = (Model.USER_Users)Session["USER_Users"];//实例化
                        List<Model.Project_Projects> modelistProject = bllProject.GetModelList("(NAMES='无' or NAMES='日常项目' or  NAMES='-无-') and  DELFLAG=0 and LeaderID='" + mUser.ID.ToString()+ "'");
                        
                        if (modelistProject.Count > 0)
                        {
                            isshowWu = true;
                        }

                        for (int i = 0; i < dt_project.Rows.Count; i++)
                        {
                            //项目名称
                            string projectName = dt_project.Rows[i]["NAMES"].ToString();
                            //项目ID
                            string projectID = dt_project.Rows[i]["ID"].ToString();
                            if (projectName == "无" || projectName == "日常项目" || projectName == "-无-")
                            {
                                if (isshowWu)
                                {
                                    ListItem li = new ListItem(projectName, projectID);

                                    DropDownList_myProject.Items.Add(li);

                                    if (Session["Work_ProjectId"] != null)
                                    {
                                        if (li.Value.Equals(Session["Work_ProjectId"].ToString()))
                                        {
                                            li.Selected = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ListItem li = new ListItem(projectName, projectID);

                                DropDownList_myProject.Items.Add(li);

                                if (Session["Work_ProjectId"] != null)
                                {
                                    if (li.Value.Equals(Session["Work_ProjectId"].ToString()))
                                    {
                                        li.Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    setProjectStatusName(Session["Work_ProjectId"].ToString());//设置项目的状态
                }
                catch(Exception ex)
                {
                }
            }
        }
        /// <summary>
        /// 重置按钮的样式
        /// </summary>
        private void reSetLinkbutton()
        {
            try
            {
                LinkButton_apply.CssClass = "ProjectPanal";
                LinkButton_doc.CssClass = "ProjectPanal";
                LinkButton_fee.CssClass = "ProjectPanal";
                LinkButton_news.CssClass = "ProjectPanal";
                LinkButton_person.CssClass = "ProjectPanal";
                LinkButton_task.CssClass = "ProjectPanal";
            }
            catch
            {
            }
        }
        /// <summary>
        /// 项目任务的触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_task_Click(object sender, EventArgs e)
        {
            Session["Session_Project_linkshow"] = "LinkButton_task";
            Response.Redirect("/Admin/personalProjectManage/OAtask/manage.aspx");
        }
        /// <summary>
        /// 项目经费触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_fee_Click(object sender, EventArgs e)
        {
            Session["Session_Project_linkshow"] = "LinkButton_fee";
            Response.Redirect("/Admin/personalProjectManage/OACashApply/manageCashApply.aspx");
        }
        /// <summary>
        /// 业务申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_apply_Click(object sender, EventArgs e)
        {
            Session["Session_Project_linkshow"] = "LinkButton_apply";

            Response.Redirect("/Admin/personalProjectManage/OAapply/manage.aspx");
        }
        /// <summary>
        /// 项目文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_doc_Click(object sender, EventArgs e)
        {
            Session["Session_Project_linkshow"] = "LinkButton_doc";
            Response.Redirect("/Admin/DocumentManage/manage.aspx");
        }
        /// <summary>
        /// 信息发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_news_Click(object sender, EventArgs e)
        {
            Session["Session_Project_linkshow"] = "LinkButton_news";
            Response.Redirect("/Admin/personalProjectManage/OANews/manage.aspx");
        }
        /// <summary>
        /// 人员分配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_person_Click(object sender, EventArgs e)
        {
            Session["Session_Project_linkshow"] = "LinkButton_person";
            Response.Redirect("/Admin/personalProjectManage/OADepartMent/manage.aspx");
        }

        /// <summary>
        /// 按项目筛选触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_myProject_change(object sender, EventArgs e)
        {
            try
            {
                string oldsession = Session["Work_ProjectId"].ToString();
                string projectid = commons.RequestSafeString(DropDownList_myProject.SelectedValue.ToString(), 50);
                Session["Work_ProjectId"] = projectid;
                setProjectStatusName(projectid);//设置项目的状态
                string urls = Request.RawUrl;

                //项目任务
                if (urls.Contains("/Admin/personalProjectManage/OAtask/"))
                {
                    urls = "/Admin/personalProjectManage/OAtask/manage.aspx";
                }//项目经费
                else if (urls.Contains("/Admin/personalProjectManage/OACashApply/"))
                {
                    urls = "/Admin/personalProjectManage/OACashApply/manageCashApply.aspx";
                }//项目资源
                else if (urls.Contains("/Admin/personalProjectManage/OAapply/"))
                {
                    urls = "/Admin/personalProjectManage/OAapply/manage.aspx";
                }//项目消息
                else if (urls.Contains("/Admin/personalProjectManage/OANews/"))
                {
                    urls = "/Admin/personalProjectManage/OANews/manage.aspx";
                }//项目文档
                else if (urls.Contains("/Admin/DocumentManage/"))
                {
                    urls = "/Admin/DocumentManage/manage.aspx";
                }//人员分配
                else if (urls.Contains("/Admin/personalProjectManage/OADepartMent/"))
                {
                    urls = "/Admin/personalProjectManage/OADepartMent/manage.aspx";
                }


                Response.Redirect(urls);
                // Response.Redirect("/Admin/personalProjectManage/OAtask/manage.aspx");
            }
            catch
            {
            }
        }

        /// <summary>
        ///设置项目的状态
        /// </summary>
        private void setProjectStatusName(string projectid)
        {
            try
            {
                //根据项目的ID获取到当前的项目的状态名称
                BLL.Project_ProjectsExt bProject = new Dianda.BLL.Project_ProjectsExt();
                string projcetStatusName = bProject.getProjectStautsName(projectid);
                if (!projcetStatusName.Contains("运行中"))
                {
                    Label_statusname.Text = "项目状态：" + projcetStatusName;
                }
                //根据项目的ID获取到当前的项目的状态名称
            }
            catch
            {
            }
        }

    }
}