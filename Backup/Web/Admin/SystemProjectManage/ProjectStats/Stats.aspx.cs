using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.SystemProjectManage.ProjectStats
{
    public partial class Stats : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
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

                    //初始化项目下拉列表
                    GetddlProjectID();

                }
                catch
                {
                }
            }
        }

        private void GetddlProjectID()
        {
            DataTable dt = new DataTable();
            string sql = "Select NAMES,ID From Project_Projects Where DELFLAG=0 and  [Status]=1";//项目的状态 1表示正常运行中,0表示待审核，2表示审核不通过，3暂停，4表示草稿箱中，5表示完成
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.ddlProjectID.DataSource = dt;
                this.ddlProjectID.DataTextField = "NAMES";
                this.ddlProjectID.DataValueField = "ID";
                this.ddlProjectID.DataBind();



            }
        }

        /// <summary>
        /// 重置按钮的样式
        /// </summary>
        private void reSetLinkbutton()
        {
            try
            {
                LinkButton_fee.CssClass = "ProjectPanal";
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
        /// 按项目筛选触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string projectid = this.ddlProjectID.SelectedValue.ToString();
            Session["Work_ProjectId"] = projectid;
            string urls = Request.RawUrl;

            //if (urls.Contains("/Admin/personalProjectManage/OAtask/manage.aspx"))
            //{
            //    urls = "/Admin/personalProjectManage/OAtask/manage.aspx";
            //}
            //Response.Redirect(urls);
        }
    }
}
