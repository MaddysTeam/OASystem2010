using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAtask
{
    public partial class add : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pagecontrol = new Dianda.COMMON.pageControl();
        Dianda.Model.Project_Projects project_model = new Dianda.Model.Project_Projects();
        Dianda.BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        Dianda.Model.Project_Task task_model = new Dianda.Model.Project_Task();
        Dianda.BLL.Project_Task task_bll = new Dianda.BLL.Project_Task();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //显示参与人员信息
                ShowCheckBoxList();
            }

            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "项目 > 我的项目 > 任务管理 > 新增任务 ";
            //设置模板页中的管理值
        }

        /// <summary>
        /// 初始化复选框参与人员信息
        /// </summary>
        protected void ShowCheckBoxList()
        {
            try
            {
                //显示可供参与的人员信息 。
                DataTable dt_dep = new DataTable();

               // project_model = project_bll.GetModel(Convert.ToInt16(Session["Work_ProjectId"]));
                
               // string departID =commons.makeSqlIn(project_model.DepartmentID.ToString(),',');

                //string sql1 = " SELECT ID, USERNAME, REALNAME,REALNAME + '（' + USERNAME +'）' AS NEWNAME FROM USER_Users WHERE  (DELFLAG = 0)  AND (DepartMentID IN " + departID + ")";

                string sql1 = " SELECT ID, USERNAME, REALNAME,REALNAME + '（' + USERNAME +'）' AS NEWNAME FROM USER_Users WHERE  (DELFLAG = 0)  AND (ID IN (SELECT UserID FROM Project_UserList WHERE (ProjectID = " + Convert.ToInt16(Session["Work_ProjectId"]) + ") AND (Status = 1)))";
                
                 dt_dep = pagecontrol.doSql(sql1).Tables[0];

                 if (dt_dep.Rows.Count > 0)
                 {
                     CB_usersID.DataSource = dt_dep.DefaultView;
                     CB_usersID.DataTextField = "NEWNAME";
                     CB_usersID.DataValueField = "ID";
                     CB_usersID.DataBind();
                 }
                 else
                 {
                     CB_usersID.Enabled = false;
                     LB_notice.Visible = true;
                     Button_sumbit.Enabled = false;
                 }

                //显示父任务
                 DataTable DT_task = new DataTable();
                 string sql2 = "SELECT ID,NAMES FROM Project_Task WHERE (DELFLAG = 0)  AND ProjectID = " + Convert.ToInt16(Session["Work_ProjectId"]) + " AND IsFather = 1 ";

                DT_task = pagecontrol.doSql(sql2).Tables[0];

                ListItem li = new ListItem("--无--","0");
                DDL_UpID.Items.Add(li);

                if (DT_task.Rows.Count>0)
                {
                    for (int i = 0; i < DT_task.Rows.Count;i++ )
                    {
                        string name = DT_task.Rows[i]["NAMES"].ToString();
                        string id = DT_task.Rows[i]["ID"].ToString();

                        ListItem li1 = new ListItem(name, id);
                        DDL_UpID.Items.Add(li1);
                    }
                }
                //状态
                RadioButtonList_status.SelectedValue = "0";
                //有无子任务
                RadioButtonList_IsFather.SelectedValue = "0";
                //上传文档
                RadioButtonList_doc.SelectedValue = "0";
            }
            catch
            {
                CB_usersID.Enabled = false;
                LB_notice.Visible = true;
            }
        }


        /// <summary>
        /// 点击全选框时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox_choose_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox CheckBox_Alltemp = (CheckBox)sender;
                if (CheckBox_Alltemp.Checked)//全选
                {
                    grievSearch(true);
                    CB_usersID.Enabled = false;
                }
                else//全不选
                {
                    grievSearch(false);
                    CB_usersID.Enabled = true;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        ///根据条件给值
        /// </summary>
        /// <param name="isCheck"></param>
        private void grievSearch(bool isCheck)
        {
            try
            {
                int rows = CB_usersID.Items.Count;
                if (rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        CB_usersID.Items[i].Selected = isCheck;
                    }
                }

            }
            catch
            {
            }
        }

        /// <summary>
        /// 确定添加新任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                project_model = project_bll.GetModel(Convert.ToInt16(Session["Work_ProjectId"]));

                string taskname = NAME.Text.ToString();
                //检查是否有该用户组名称
                bool checkName = pagecontrol.Exists_TaskName("Project_Task", "NAMES", taskname, "ID", "", Convert.ToInt16(Session["Work_ProjectId"]));
                    if (checkName)
                    {
                        tag.Text = "该任务标题已经存在，请修改！";
                    }else
                    {
                        //ID
                        task_model.ID = task_bll.GetMaxId();
                        //项目ID
                        task_model.ProjectID = Convert.ToInt16(Session["Work_ProjectId"]);
                        //任务标题
                        task_model.NAMES = taskname;
                        //删除标记录
                        task_model.DELFLAG = 0;
                        //状态
                        task_model.Status = int.Parse(RadioButtonList_status.SelectedValue.ToString());

                        string time = TB_StartTime.Value.ToString()+" 00:00:00";
                        //if (time == DateTime.Now.ToShortDateString())
                        //{
                        //    time += " " + DateTime.Now.ToString("HH:mm:ss");
                        //}
                        //else
                        //{
                        //    time += " 00:00:00";
                        //}
                        //开始时间
                        task_model.StartTime = Convert.ToDateTime(time);
                        //结束时间
                        task_model.EndTime = Convert.ToDateTime(TB_EndTime.Value.ToString()+" 23:59:59");
                        //任务描述
                        task_model.Overviews = Overviews.Text.ToString();
                        //任务的发布时间
                        task_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        //发布这个任务的用户的ID
                        Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                        task_model.SendUserID = user_model.ID;

                        string userids = "";
                        string usernames = "";
                        for (int i = 0; i < CB_usersID.Items.Count; i++)
                        {
                            if (CB_usersID.Items[i].Selected == true)
                            {
                                userids = userids + CB_usersID.Items[i].Value + ",0" + ";";

                                if (usernames.Equals(""))
                                {
                                    usernames = CB_usersID.Items[i].Text;
                                }
                                else
                                {
                                    usernames = usernames + "; " + CB_usersID.Items[i].Text;
                                }

                                //给参与此任务的用户发信息

                                Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                                BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();
                                mFaceShowMessage.DATETIME = DateTime.Now;
                                mFaceShowMessage.FromTable = "项目任务";
                                mFaceShowMessage.IsRead = 0;
                                mFaceShowMessage.NewsID = null;
                                mFaceShowMessage.NewsType = "项目任务";
                                mFaceShowMessage.ReadTime = null;
                                mFaceShowMessage.Receive = CB_usersID.Items[i].Value;
                                mFaceShowMessage.DELFLAG = 0;
                                mFaceShowMessage.ProjectID = project_model.ID;
                                mFaceShowMessage.URLS = "<a href='/Admin/personalProjectManage/OAtask/manage.aspx?ID=" + task_model.ProjectID + "' target='_self' title='新建任务：新建时间" + DateTime.Now.ToString() + "'>新建任务：" + taskname + "</a>  " + project_model.NAMES + "  (" + user_model.REALNAME + ")";
                                bFaceShowMessage.Add(mFaceShowMessage);

                                //给参与此任务的用户发信息

                            }
                        }
                        //参与的用户的ID
                        try
                        {
                            task_model.UserIDs = userids.Substring(0, userids.Length - 1);
                        }
                        catch
                        {
                            tag.Text = "请至少选择一个参与人员！";
                            return;
                        }
                        
                        //参与人员名称：真实姓名+'（'+用户名＋‘）’；
                        task_model.UserInfo = usernames;

                        if (!DDL_UpID.SelectedValue.ToString().Equals(""))
                        {
                            //父任务
                            task_model.UpID = int.Parse(DDL_UpID.SelectedValue.ToString());
                        }
                        else
                        {
                            //父任务
                            task_model.UpID = 0;
                        }

                        //是否可建子任务
                        task_model.IsFather = int.Parse(RadioButtonList_IsFather.SelectedValue.ToString());

                        //上传文档
                        task_model.CompleteType = int.Parse(RadioButtonList_doc.SelectedValue.ToString());

                        task_bll.Add(task_model);

                        //tag.Text = "操作成功！";

                        //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?ID=" + project_model.ID+ "\";</script>";


                        //Response.Write(coutws);

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入列表页面');javascript:location='manage.aspx?ID=" + project_model.ID +"&status=" + Request.QueryString["status"].ToString()+"';</script>", false);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入列表页面');javascript:location='manage.aspx?ID=" + project_model.ID +"';</script>", false);

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入我的项目页面');javascript:location='manage.aspx?projecttype=4&projectStatus=0';</script>", false);



                        //添加操作日志

                        Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                        bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "项目中新增任务", project_model.NAMES+"项目"+task_model.NAMES+"任务:添加成功！");
                        //添加操作日志

                    }
            }
            catch
            {
                tag.Text = "操作失败，请重试！";
            }
        }

        /// <summary>
        /// 返回触发按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx?ID=" + Session["Work_ProjectId"] + "&status=" + Request.QueryString["status"].ToString());
        }

        /// <summary>
        /// 父任务改变触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_UpID_Change(object sender, EventArgs e)
        {
            string upid = DDL_UpID.SelectedValue.ToString();

            for (int j = 0; j < CB_usersID.Items.Count; j++)
            {
                CB_usersID.Items[j].Selected = false;
            }
            CheckBox_choose.Checked = false;

            if (upid.Equals(""))
            {
                NAME.Text = "";
                TB_StartTime.Value = "";
                TB_EndTime.Value = "";
                grievSearch(false);
                Overviews.Text = "";
                //状态
                RadioButtonList_status.SelectedValue = "0";
                //有无子任务
                RadioButtonList_IsFather.SelectedValue = "0";

            }
            else
            {
                string id = DDL_UpID.SelectedValue.ToString();

                DataTable dt = new DataTable();

                string sql = " SELECT * FROM Project_Task WHERE  ID ='"+id+"'";

                dt = pagecontrol.doSql(sql).Tables[0];

                if (dt.Rows.Count>0)
                {
                    //任务名称
                    NAME.Text = dt.Rows[0]["NAMES"].ToString()+"_1";
                    //开始时间
                    TB_StartTime.Value = Convert.ToDateTime(dt.Rows[0]["StartTime"].ToString()).ToString("yyyy-MM-dd");
                    //结束时间
                    TB_EndTime.Value = Convert.ToDateTime(dt.Rows[0]["EndTime"].ToString()).ToString("yyyy-MM-dd");
                    //任务描述
                    Overviews.Text = dt.Rows[0]["Overviews"].ToString();
                    //状态 *(状态不需要带入)
                    //RadioButtonList_status.SelectedValue = dt.Rows[0]["Status"].ToString();
                    //有无子任务
                    RadioButtonList_IsFather.SelectedValue = dt.Rows[0]["IsFather"].ToString();
                    //是否上传文档
                    RadioButtonList_doc.SelectedValue = dt.Rows[0]["CompleteType"].ToString();
                    //参与人员
                    string UserIDs = dt.Rows[0]["UserIDs"].ToString();

                    //因为在任务表中部门以‘;’分开。故以‘;’将其分割,切割后的格式为:   "用户ID号"+","+"0"
                    string[] UserIDsInfo = UserIDs.Split(';');
                    int checknum = 0;
                    for (int i = 0; i < CB_usersID.Items.Count; i++)
                    {
                        for (int j = 0; j < UserIDsInfo.Length; j++)
                        {
                            string[] uid = UserIDsInfo[j].Split(',');

                            if (uid[0].ToString().Equals(CB_usersID.Items[i].Value.ToString()))
                            {
                                CB_usersID.Items[i].Selected = true;
                                checknum = checknum + 1;
                            }
                        }
                    }
                    //如果所有的参与人员都选中了，则将“全部”的复选框选中
                    if (checknum == CB_usersID.Items.Count)
                    {
                        CheckBox_choose.Checked = true;
                    }
                }

            }
        }

    }
}
