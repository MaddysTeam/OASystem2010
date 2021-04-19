using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAtask
{
    public partial class manage : System.Web.UI.Page
    {
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();
        Dianda.Model.Project_Projects project_model = new Dianda.Model.Project_Projects();
        Dianda.Model.Project_Task task_model = new Dianda.Model.Project_Task();
        Dianda.BLL.Project_Task task_bll = new Dianda.BLL.Project_Task();
        Dianda.BLL.Project_ProjectsExt BProject_Status = new Dianda.BLL.Project_ProjectsExt();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //设置项目状态
                if (Request.QueryString["status"] == null)
                {
                    DDL_Status.SelectedValue = "";
                }
                else
                {
                    DDL_Status.SelectedValue = Request.QueryString["status"].ToString();
                }
                //项目ID
                string projectid = Request["ID"];
                if (projectid != null && projectid != "")//如果项目的ID存在，则做切换
                {
                    projectid = commons.RequestSafeString(projectid.ToString(), 50);
                    Session["Work_ProjectId"] = projectid;
                }
                Session["Session_Project_linkshow"] = "LinkButton_task";//定义过来后要显示任务的按钮

                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];


                //判断此项目的项目负责人是否为现在操作的人员（因为操作人员可分为“项目负责人”和“项目参与人员”）
                //如果不是项目负责人在操作，则不能进行新增，编辑，删除的相关操作
                string sql = " SELECT LeaderID,SendUserID FROM Project_Projects where ID= " + Session["Work_ProjectId"];

                DataTable DT_leaderID = new DataTable();

                DT_leaderID = pageControl.doSql(sql).Tables[0];

                if (DT_leaderID.Rows.Count > 0)
                {
                    string LeaderID = DT_leaderID.Rows[0]["LeaderID"].ToString();
                    string SendUserID=DT_leaderID.Rows[0]["SendUserID"].ToString();
                    if (!LeaderID.Equals(user_model.ID) && !SendUserID.Equals(user_model.ID))//说明不是项目负责人
                    {
                        Button_add.Visible = false;
                        Button_modify.Visible = false;
                        Button_delete.Visible = false;
                        //这里设这个session是为了“设为已完成”，“设为进行中”，“设为延期”三个功能用的
                        //因为项目负责人进行以上三个功能操作时只需要改变相应任务中的status即可
                        //而项目参与人员则必须同时修改掉UserIDs中对应着自己的ID号的status
                        Session["isProjectLeader"] = false;
                    }
                    else
                    {
                        Session["isProjectLeader"] = true;
                    }
                }
                //以上

                string pageindex = null;//这里是为分页服务的

                pageindex = Request["pageindex"];


                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    setRowCout();//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    count = dtrowsHidden.Value.ToString();
                }
                else
                {
                    count = "0";
                }
                int countint = int.Parse(count);

                if (pageindex == null || pageindex == "")
                {
                    pageindex = "1";
                }

                int pageindex_int = int.Parse(pageindex);

                ShowTaskList(pageindex_int);
                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "项目 > 我的项目 > 任务管理 > 任务列表 ";
                //设置模板页中的管理值

                //if (null != Request["status"])
                //{
                //    for (int i = 0; i < DDL_Status.Items.Count; i++)
                //    {
                //        if (DDL_Status.Items[i].Value.ToString().Equals(Request["status"].ToString()))
                //        {
                //            DDL_Status.Items[i].Selected = true;
                //        }
                //    }
                //}
                //项目状态
                bool Project_Status = BProject_Status.ProjectStatus(Session["Work_ProjectId"].ToString());
                //根据项目状态设置页面按钮状态
                if (Project_Status == false)
                {
                    Button_add.Enabled = Project_Status;
                    Button_modify.Enabled = Project_Status;
                    Button_delete.Enabled = Project_Status;
                    Button_setfinish.Enabled = Project_Status;
                    Button_setpostpone.Enabled = Project_Status;
                }
            }       
                
            
        }
        /// <summary>
        /// 显示项目下的任务
        /// </summary>
        protected void ShowTaskList(int pageindex)
        {
            try
            {
                DataTable DT = new DataTable();
                string sqlWhere1 = "";
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                if (DDL_Status.SelectedValue.ToString().Equals(""))
                {
                     sqlWhere1 = "DELFLAG=0 and ProjectID=" + Session["Work_ProjectId"];
                }
                else
                {
                     sqlWhere1 = "DELFLAG=0 and ProjectID=" + Session["Work_ProjectId"] + " and Status=" + DDL_Status.SelectedValue;

                }
                //必须是登陆者参与的项目或者登陆者自己创建的项目登陆者才能看到。
               // sqlWhere1 = sqlWhere1 + " AND  (UserInfo LIKE '%" + user_model.REALNAME + "（" + user_model.USERNAME + "）" + "%' OR SendUserID ='" + user_model.ID + "') ";

                //根据2010年12月14日的需求，要所有人都能看到任务，但是没有参与的人员，则不给可以选择的按钮
                HiddenField_userid.Value = user_model.ID;
                HiddenField_userinfo.Value = user_model.REALNAME + "（" + user_model.USERNAME + "）";
                
                
                sqlWhere1 = sqlWhere1;

                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                DT = pageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "Project_Task", "StartTime").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中

                    GridView1.Visible = true;
                    GridView1.DataSource = DT;//指定GridView1的数据是DT
                    pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    notice.Text = "";
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                    Button_modify.Enabled = true;
                    Button_delete.Enabled = true;
                    Button_setfinish.Enabled = true;
                    Button_setpostpone.Enabled = true;
                    //设置项目操作按钮状态
                    if (DDL_Status.SelectedValue == "0")
                    {

                    }
                    else if (DDL_Status.SelectedValue == "2")
                    {
                        Button_setfinish.Enabled = false;
                        Button_modify.Enabled = false;
                        Button_setpostpone.Enabled = false;
                    }
                    else
                    {
                        Button_setpostpone.Enabled = false;
                    }
                   
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！请选择筛选的条件！";
                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    Button_modify.Enabled = false;
                    Button_delete.Enabled = false;
                    Button_setfinish.Enabled = false;
                    //Button_setunderway.Enabled = false;
                    Button_setpostpone.Enabled = false;
                    if (alltiaoshuInt > 0 && pageindex>1)
                    {
                        ShowTaskList(pageindex - 1);
                    }
                }
            }
            catch
            {
                GridView1.Visible = false;
                notice.Text = "*进入任务列表时发生错误！";
                pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                Button_modify.Enabled = false;
                Button_delete.Enabled = false;
            }
        }

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout()
        {
            try
            {
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                string sqlWhere1 = "";
                if (DDL_Status.SelectedValue.ToString().Equals(""))
                {
                    sqlWhere1 = "DELFLAG=0 and ProjectID=" + Session["Work_ProjectId"];
                }
                else
                {
                    sqlWhere1 = "DELFLAG=0 and ProjectID=" + Session["Work_ProjectId"] + "and Status=" + DDL_Status.SelectedValue;

                }
                //必须是登陆者参与的项目或者登陆者自己创建的项目登陆者才能看到。
               // sqlWhere1 = sqlWhere1 + " AND  (UserInfo LIKE '%" + user_model.REALNAME + "（" + user_model.USERNAME + "）" + "%' OR SendUserID ='"+user_model.ID+"') ";
                //根据2010年12月14日的需求，要所有人都能看到任务，但是没有参与的人员，则不给可以选择的按钮

                DataTable DT = new DataTable();

                int count = pageControl.tableRowCout(sqlWhere1, "Project_Task", "ID");

                dtrowsHidden.Value = count.ToString();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 当分页控件中的“第一页”“第二页”...发生时，触发下面的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageChange_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
            pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值
            setRowCout();
            ShowTaskList(page);//调用显示

        }
        /// <summary>
        /// 当分页控件中的下拉菜单触发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
            pageindexHidden.Value = page.ToString();
            setRowCout();
            ShowTaskList(page);//调用显示

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
                }
                else//全不选
                {
                    grievSearch(false);
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
                int rows = GridView1.Rows.Count;
                if (rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                        if (cb.Enabled)
                        {
                            cb.Checked = isCheck;
                        }
                    }
                }

            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    //部门或岗位的ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();

                    string UserInfo = DataBinder.Eval(e.Row.DataItem, "UserInfo").ToString();
                    string SendUserID = DataBinder.Eval(e.Row.DataItem, "SendUserID").ToString();

                    hid.Value = ID;

                    //任务状态
                    string Status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                    switch (Status)
                    {
                        case "0":
                            e.Row.Cells[5].Text = "待办";
                            break;
                        case "1":
                            e.Row.Cells[5].Text = "进行中";
                            break;
                        case "2":
                            e.Row.Cells[5].Text = "完成";
                            break;
                        case "3":
                            e.Row.Cells[5].Text = "<font color='red'>暂停</font>";
                            break;
                    }

                    //是否需要上传文档
                    string CompleteType = DataBinder.Eval(e.Row.DataItem, "CompleteType").ToString();
                    LinkButton lb_doc = (LinkButton)e.Row.Cells[7].FindControl("LinkButton_doc");
                    if (CompleteType.Equals("0"))
                    {
                        lb_doc.Visible = false;
                    }
                    else
                    {
                        lb_doc.Text = "上传";
                        lb_doc.Visible = true;
                    }

                    //根据当前用户的信息，判断这个任务是否可以让这个用户选择
                    string userids = HiddenField_userid.Value.ToString();
                    string userinfosw = HiddenField_userinfo.Value.ToString();
                    bool isshow = false;
                    if (UserInfo.Contains(userinfosw) || SendUserID == userids)
                    {
                        isshow = true;
                    }
                    CheckBox cbx = (CheckBox)e.Row.Cells[0].FindControl("CheckBox_choose");
                    if (isshow)
                    {
                        cbx.Enabled = true;
                    }
                    else
                    {
                        cbx.Enabled = false;
                        lb_doc.Text = "您不是参与者";
                        lb_doc.Visible = true;
                        lb_doc.Enabled=false;
                    }

                }
            }
            catch
            { }
        }

        /// <summary>
        /// 点击新增按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_doc_onclick(object sender, EventArgs e)
        {
            Session["Session_Project_linkshow"] = "LinkButton_doc";
            Response.Redirect("/Admin/DocumentManage/manage.aspx");
        }

        /// <summary>
        /// 点击新增按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_add_onclick(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx?status=" + DDL_Status.SelectedValue);
        }

        /// <summary>
        /// 点击编辑触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_modify_onclick(object sender, EventArgs e)
        {
            //选择编辑的条数只能为一条
            int num = 0;
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if (cb.Checked)
                    {
                        num = num + 1;
                    }
                }

                if (num == 0)
                {
                    tag.Text = "请选择一条数据进行编辑！";

                }
                else if (num > 1)
                {
                    tag.Text = "编辑时最多只能选择一条数据！";
                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

                        if (cb1.Checked)
                        {
                            Response.Redirect("modify.aspx?ID=" + hid.Value.ToString() + "&pageindex=" + pageindexHidden.Value.ToString() + "&status=" + DDL_Status.SelectedValue);
                        }
                    }
                }

            }

        }


        /// <summary>
        /// 点击删除按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_delete_onclick(object sender, EventArgs e)
        {
            int num = 0;
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if (cb.Checked)
                    {
                        num = num + 1;
                    }
                }

                if (num == 0)
                {
                    tag.Text = "删除时最少选择一条数据！";

                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

                        if (cb1.Checked)
                        {
                            //获取到当前任务的基本信息
                            task_model = task_bll.GetModel(int.Parse(hid.Value.ToString()));
                            //将删除标记设为1
                            task_model.DELFLAG = 1;

                            task_bll.Update(task_model);

                            //添加操作日志

                            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "项目中删除任务", project_model.NAMES + "项目" + task_model.NAMES + "任务:删除成功！");

                            //添加操作日志
                        }
                    }
                    //tag.Text = "操作成功！";
                    //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在返回列表页面\"); location.href = \"manage.aspx?pageindex=" + pageindexHidden.Value.ToString() + "&ID=" + Request["ID"].ToString() + "\";</script>";
                    //Response.Write(coutws);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入我的项目页面');javascript:location='manage.aspx?pageindex=" + pageindexHidden.Value.ToString() + "&ID=" + Request["ID"].ToString() + "&status=" + DDL_Status.SelectedValue+"';</script>", false);
                }

            }

        }

        /// <summary>
        /// 点击设为已完成按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_setfinish_onclick(object sender, EventArgs e)
        {
            try
            {
                int num = 0;
                int rows = GridView1.Rows.Count;
                string flag = "";
                string action = ((Button)sender).CommandArgument.ToString();
                if (rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                        if (cb.Checked)
                        {
                            num = num + 1;
                        }
                    }

                    if (num == 0)
                    {
                        if (action.Equals("1"))//设为进行中
                        {
                            flag = "待办";
                        }
                        else if (action.Equals("2"))
                        {
                            flag = "完成";
                        }
                        else if (action.Equals("3"))
                        {
                            flag = "暂停";
                        }

                        tag.Text = "设为" + flag + "时最少选择一条数据！";

                    }
                    else
                    {
                        tag.Text = "";
                        for (int j = 0; j < rows; j++)
                        {
                            CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                            HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

                            if (cb1.Checked)
                            {
                                //获取到当前任务的基本信息
                                task_model = task_bll.GetModel(int.Parse(hid.Value.ToString()));
                                //任务的状态
                                task_model.Status = int.Parse(action);
                                //组员更新时间
                                task_model.ReadTime = Convert.ToDateTime(DateTime.Now.ToString());

                                if (!(bool)Session["isProjectLeader"])//如果不是项目负责人
                                {
                                    Model.USER_Users user_model1 = (Model.USER_Users)Session["USER_Users"];
                                    string userid = "";
                                    string[] userids = task_model.UserIDs.Split(';');
                                    for (int i = 0; i < userids.Length; i++)
                                    {
                                        string[] uid = userids[i].Split(',');
                                        if (uid[0].ToString().Equals(user_model1.ID))
                                        {
                                            uid[1] = action;
                                        }
                                        userid = userid + uid[0] + "," + uid[1] + ";";
                                    }
                                    //将对应的userid的后面的状态也更改掉
                                    task_model.UserIDs = userid.Substring(0, userid.Length - 1);
                                }

                                task_bll.Update(task_model);

                                //添加操作日志

                                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "项目任务设为" + flag, project_model.NAMES + "项目" + task_model.NAMES + "任务:设置" + flag + "成功！");

                                //添加操作日志
                            }
                        }
                        //tag.Text = "操作成功！";
                        //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在返回列表页面\"); location.href = \"manage.aspx?pageindex=" + pageindexHidden.Value.ToString() + "&ID=" + Request["ID"].ToString() + "\";</script>";
                        //Response.Write(coutws);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入项目任务页面');javascript:location='manage.aspx?pageindex=" + pageindexHidden.Value.ToString() + "&ID=" + Request["ID"].ToString() + "&status=" + DDL_Status.SelectedValue + "';</script>", false);

                    }

                }
            }
            catch
            {
                int pageint = 1;
                if (pageindexHidden.Value.ToString() != "")
                {
                    pageint = int.Parse(pageindexHidden.Value.ToString());
                }
                ShowTaskList(pageint);
            }

        }
        /// <summary>
        /// 任务状态切换激发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            tag.Text = "";
            setRowCout();
            ShowTaskList(1);
            if (DDL_Status.SelectedValue == "0")
            {

            }
            else if (DDL_Status.SelectedValue == "2")
            {
                Button_setfinish.Enabled = false;
                Button_modify.Enabled = false;
                Button_setpostpone.Enabled = false;
            }
            else
            {
                Button_setpostpone.Enabled = false;
            }
            //项目状态
            bool Project_Status = BProject_Status.ProjectStatus(Session["Work_ProjectId"].ToString());
            //根据项目状态设置页面按钮状态
            if (Project_Status == false)
            {
                Button_add.Enabled = Project_Status;
                Button_modify.Enabled = Project_Status;
                Button_delete.Enabled = Project_Status;
                Button_setfinish.Enabled = Project_Status;
                Button_setpostpone.Enabled = Project_Status;
            }
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string substing(object e)
        {
            string str = "";
            string str1 = e.ToString();
            if (str1.Contains(";"))
            {
                str = str1.Remove(str1.IndexOf(";")) + "...";
              
            }
            else if (str1.Contains(","))
            {
                str = str1.Remove(str1.IndexOf(",")) + "...";
            }
            else
            {
                str = str1;
            }
            return str;
        }
       
       
    }
}
