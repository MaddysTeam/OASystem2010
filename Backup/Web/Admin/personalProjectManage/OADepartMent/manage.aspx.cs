using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Dianda.Web.Admin.personalProjectManage.OADepartMent
{
    public partial class manage : System.Web.UI.Page
    {
        BLL.USER_Groups bug = new Dianda.BLL.USER_Groups();
        COMMON.pageControl pagedosql = new Dianda.COMMON.pageControl();
        COMMON.common commonId = new Dianda.COMMON.common();     
        BLL.Project_UserList projectuserListBll = new Dianda.BLL.Project_UserList();
        Model.Project_UserList projectUserListModel = new Dianda.Model.Project_UserList();
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Project_Projects mProjects = new Dianda.Model.Project_Projects();
        BLL.Project_Projects bProjects = new Dianda.BLL.Project_Projects();
        Model.USER_Users mUser = new Dianda.Model.USER_Users();
        Dianda.BLL.Project_ProjectsExt BProject_Status = new Dianda.BLL.Project_ProjectsExt();
        Dianda.Model.Project_Projects project_model = new Dianda.Model.Project_Projects();
        Dianda.BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();
        BLL.USER_Users bUSER_Users = new Dianda.BLL.USER_Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    showDepartment(Session["Work_ProjectId"].ToString());

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

                    BindData(pageindex_int);

                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "项目 > 我的项目 > 人员分配";
                    //设置模板页中的管理值
                    CheckboxShowUser.Visible = false;
                    DDL_COLUMN.Visible = false;
                    Tr_3.Visible = false;
                    ShowUser.Visible = true;
                    mUser = (Model.USER_Users)Session["USER_Users"];//实例化
                    mProjects = bProjects.GetModel(int.Parse(Session["Work_ProjectId"].ToString()));//得到项目ID
                    if (mUser.ID == mProjects.LeaderID || mUser.ID == mProjects.SendUserID.ToString())
                    {
                        Button1.Visible = true;
                        Button2.Visible = true;
                        if (mUser.ID == mProjects.SendUserID.ToString())
                        {
                            Button3.Visible = true;
                        }
                        else
                        {
                            Button3.Visible = false;
                        }
                    }
                    else
                    {
                        Button1.Visible = false;
                        Button2.Visible = false;
                        Button3.Visible = false;
                    }
                    //项目状态
                    bool Project_Status = BProject_Status.ProjectStatus(Session["Work_ProjectId"].ToString());
                    //根据项目状态设置页面按钮状态  
                    if (Project_Status == false)
                    {
                        Button1.Enabled = Project_Status;
                        Button2.Enabled = Project_Status;
                        Button3.Enabled = Project_Status;

                    }
                }
            }
            catch (Exception)
            {
            }

        }
     
        /// <summary>
        /// 按部门将所有的用户呈现，并且将已经选择的用户selectUser在列表上显示出来
        /// </summary>
        /// <param name="selectUser"></param>
        public void showDepartment(string projectId)
        {
            try
            {
                //获取到部门ID
                mProjects = bProjects.GetModel(int.Parse(projectId));
                //通过方法 用逗号把部门ID分开
                string strdepartmentId = commonId.makeSqlIn(mProjects.DepartmentID, ',');
                //查询出部门中status =1 并且delflag=0 的用户
                string sql = "SELECT  * FROM vProject_UserList WHERE (DELFLAG = '0') and status='1'and ProjectID='" + projectId + "' ORDER BY DepartMentID";
                DataTable dt1 = pagedosql.doSql(sql).Tables[0];
                //通过部门ID 查看部门里有多少人员
                string[] strdepartmentId_arr = mProjects.DepartmentID.Split(',');
                string strsql = "";
                for (int i = 0; i < strdepartmentId_arr.Length; i++)
                {
                    if (strsql == "")
                    {
                        strsql = "select id,realName,userName,'" + strdepartmentId_arr[i] + "' departmentid from USER_Users where departmentid like '%" + strdepartmentId_arr[i] + "%'";
                    }
                    else
                    {
                        strsql += " union select id,realName,userName,'" + strdepartmentId_arr[i] + "'departmentid from USER_Users where departmentid like '%" + strdepartmentId_arr[i] + "%'";
                    }
                }             
                DataTable dt = pagedosql.doSql(strsql).Tables[0];
                //Session["temp_UserAllUser_session"] = dt;
                //Session["temp_SelectUser_session"] = dt1;
                //查询出传进来的部门ID
                DataTable dt2 = new DataTable();
                dt2 = bug.GetList(" TAGS='部门' and DELFLAG='0' and id in " + strdepartmentId + " order by ISMOREN").Tables[0];
                shareForUser1.showDepartment(dt1, dt, dt2);

            }
            catch
            {
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                //获得传过来的ID 
                string strId = Session["Work_ProjectId"].ToString();
                ArrayList al = shareForUser1.getSelectUser();//用户的ID
                addUser(strId, al);
                //添加操作日志
                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加人员", "添加成功");
                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");location.href='manage.aspx';</script>";
                Response.Write(coutws);
            }
            catch (Exception)
            {
            }

        }
        /// <summary>
        /// 将用户添加到项目
        /// </summary>
        /// <param name="strUserId"></param>
        /// <param name="al"></param>
        protected void addUser(string ProjectId, ArrayList al)
        {
            try
            {
                //先清除用户
                DelUser(ProjectId);
                for (int i = 0; i < al.Count; i++)
                {
                    if (al[i] != null && al[i].ToString() != "")
                    {
                        projectUserListModel.DATETIME = DateTime.Now;
                        projectUserListModel.ProjectID = int.Parse(ProjectId);
                        projectUserListModel.UserID = al[i].ToString();
                        projectUserListModel.Status = 1;

                        projectuserListBll.Add(projectUserListModel);
                    }
                }
            }
            catch (Exception)
            {
            }

        }
        //清空当前项目ID
        protected void DelUser(string ProjectId)
        {
            try
            {
                string strsql = "Delete from Project_userList where projectID ='" + ProjectId + "'";
                pagedosql.doSql(strsql);
            }
            catch (Exception)
            {
            }
        }
        //绑定人员列表
        protected void BindData(int pageindex)
        {
            try
            {
                string sqlWhere1 = "(DELFLAG = '0') and status='1'and ProjectID='" + Session["Work_ProjectId"].ToString() + "'";

                DataTable DT = new DataTable();

                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                DT = pageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "vProject_UserList", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中

                    GridView1.Visible = true;
                    GridView1.DataSource = DT;//指定GridView1的数据是DT
                    pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    LB_name.Text = "";
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    GridView1.Visible = false;
                    LB_name.Text = "*没有符合条件的结果！";
                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    if (alltiaoshuInt > 0)
                    {
                        BindData(pageindex - 1);
                    }

                }



            }
            catch
            {

            }
        }
        //编辑人员按钮
        protected void Button1_Click(object sender, EventArgs e)
        {
            CheckboxShowUser.Visible = true;
            DDL_COLUMN.Visible = false;
            Tr_3.Visible = false;
            ShowUser.Visible = false;
        }
        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout()
        {
            try
            {
                DataTable DT = new DataTable();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                string sendid = "";
                if (null != user_model)
                {
                    sendid = user_model.ID;
                }
                else
                {
                    sendid = "1";
                }
                string sqlWhere = "SELECT * FROM vProject_UserList WHERE (DELFLAG = '0') and status='1'and ProjectID='" + Session["Work_ProjectId"].ToString() + "'";

                DT = pageControl.doSql(sqlWhere).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    dtrowsHidden.Value = DT.Rows.Count.ToString();
                }
                else
                {
                    dtrowsHidden.Value = "0";
                }

              
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
            BindData(page);//调用显示

        }
        /// <summary>
        /// 当分页控件中的下拉菜单触发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
            setRowCout();
            BindData(page);//调用显示

        }
        //编辑部门
        protected void Button2_Click(object sender, EventArgs e)
        {
            CheckboxShowUser.Visible = false;
            DDL_COLUMN.Visible = true;
            Tr_3.Visible = false;
            ShowUser.Visible = false;
            //显示可供参与的部门信息 。
            project_model = project_bll.GetModel(int.Parse(Session["Work_ProjectId"].ToString()));
            DataTable dt_dep = new DataTable();
            string sql1 = " SELECT ID, NAME FROM USER_Groups WHERE (DELFLAG = 0) AND (TAGS = '部门') ORDER BY ISMOREN ";
            dt_dep = pagedosql.doSql(sql1).Tables[0];             
            if (dt_dep.Rows.Count > 0)
            {
                CB_DepartmentID.DataSource = dt_dep.DefaultView;
                CB_DepartmentID.DataTextField = "NAME";
                CB_DepartmentID.DataValueField = "ID";
                CB_DepartmentID.DataBind();

                //在项目表中的部门字段
                string DepartmentID = project_model.DepartmentID.ToString();

                //因为在项目表中部门以‘，’分开。故以‘，’将其分割
                string[] Department = DepartmentID.Split(',');

                for (int i = 0; i < dt_dep.Rows.Count; i++)
                {
                    for (int j = 0; j < Department.Length; j++)
                    {
                        if (Department[j].ToString() == CB_DepartmentID.Items[i].Value.ToString())
                        {
                            CB_DepartmentID.Items[i].Selected = true;
                        }
                    }
                }
            }
            else//因为参与部门是非空项，所以如果没有可供参与的部门的话，是不可以进行项目的申请的。
            {
                CB_DepartmentID.Enabled = false;
                Button_sumbit2.Enabled = false;
            }
        }
        //编辑部门确定
        protected void Button_sumbit2_Click(object sender, EventArgs e)
        {
            //修改部门ID
            project_model = project_bll.GetModel(int.Parse(Session["Work_ProjectId"].ToString()));
            //是否刷新用户数据列表(可能造成误删！)
            if (CheckBox1.Checked)
            {
                //创建SQL语句
                StringBuilder sql_dep = new StringBuilder("delete from project_userlist where projectid='" + Session["Work_ProjectId"].ToString() + "'");
                //获得参加项目的部门ID
                string dep = project_model.DepartmentID;
                //创建一个数字，指示是否是有值变更
                int sum = 0;
                //循环所有的部门
                for (int i = 0; i < CB_DepartmentID.Items.Count; i++)
                {
                    //判断是否是变更的值
                    if (dep.Contains(CB_DepartmentID.Items[i].Value))
                    {
                        //判断是否是去除有过的部门
                        if (CB_DepartmentID.Items[i].Selected == false)
                        {
                            //判断是否是首次
                            if (sum== 0)
                            {
                                sum += 1;
                                sql_dep.Append(" and ID in(select ID from vproject_userlist where ");
                                sql_dep.Append(" departmentid like '%" + CB_DepartmentID.Items[i].Value + "%'");
                            }
                            else
                            {
                                sum += 1;
                                sql_dep.Append(" or departmentid like '%" + CB_DepartmentID.Items[i].Value + "%'");
                            }                           
                        }
                    }
                }
                //当发生有部门去除时
                if (sum!=0)
                {
                    sql_dep.Append(")");
                    pageControl.doSql(sql_dep.ToString());
                }
              
            }          
            //参与部门           
            project_model.DepartmentID = "";
            //参与部门名称
            project_model.DepartmentNames = "";
            for (int i = 0; i < CB_DepartmentID.Items.Count; i++)
            {
                if (CB_DepartmentID.Items[i].Selected == true)
                {
                    project_model.DepartmentID = project_model.DepartmentID + CB_DepartmentID.Items[i].Value + ",";

                    project_model.DepartmentNames = project_model.DepartmentNames + CB_DepartmentID.Items[i].Text + ",";
                }
            }
            /* 截掉最后一个逗号*/
            if (project_model.DepartmentID.Length > 0)
            {
                project_model.DepartmentID = project_model.DepartmentID.Substring(0, project_model.DepartmentID.Length - 1);
                project_model.DepartmentNames = project_model.DepartmentNames.Substring(0, project_model.DepartmentNames.Length - 1);
            }
            //修改项目
            project_bll.Update(project_model);
            //添加操作日志
            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加部门", "添加成功");
            string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");location.href='manage.aspx';</script>";
            Response.Write(coutws);
        }      
        //编辑项目负责人
        protected void Button3_Click(object sender, EventArgs e)
        {
            CheckboxShowUser.Visible = false;
            DDL_COLUMN.Visible = false;
            Tr_3.Visible = true;
            ShowUser.Visible = false;
            //显示项目负责人下拉列表
            DataTable dt = new DataTable();
            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
            string sql = " SELECT ID,DepartMentID, USERNAME, REALNAME FROM USER_Users WHERE (DELFLAG = 0) AND (IsManager = 1 or IsManager = 9)  AND (WorkStats = 1) ORDER BY REALNAME,ID ";
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();                   
                    string REALNAME = dt.Rows[i]["REALNAME"].ToString();
                    string USERNAME = dt.Rows[i]["USERNAME"].ToString();
                    ListItem li = new ListItem(REALNAME + "(" + USERNAME + ")", ID);
                    DropDownList_UserAdmin.Items.Add(li);
                    if (user_model.ID.Equals(ID))
                    {
                        li.Selected = true;
                    }
                }             
            }
            else//因为项目负责人是非空项，如果没有项目负责人的话是不可以进行项目的申请的。
            {
                ListItem li = new ListItem("没有可选项目负责人", "");
                DropDownList_UserAdmin.Items.Add(li);               
            }
            project_model = project_bll.GetModel(int.Parse(Session["Work_ProjectId"].ToString()));
            Label_UserAdmin.Text = bUSER_Users.GetModel(project_model.LeaderID).REALNAME + "(" + bUSER_Users.GetModel(project_model.LeaderID).USERNAME + ")";

        }
        //项目负责人确定按钮
        protected void Button4_Click(object sender, EventArgs e)
        {
            project_model = project_bll.GetModel(int.Parse(Session["Work_ProjectId"].ToString()));
            project_model.LeaderID = DropDownList_UserAdmin.SelectedValue.ToString();
            project_bll.Update(project_model);

            //添加操作日志
            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加项目创建人", "添加成功");
            string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");location.href='manage.aspx';</script>";
            Response.Write(coutws);
        }
        //返回
        protected void Button7_Click(object sender, EventArgs e)
        {
            string coutws = "<script language=\"javascript\" type=\"text/javascript\">location.href='manage.aspx';</script>";
            Response.Write(coutws);
        }
        //选则刷新用户列表
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Label_Tag1.Visible = CheckBox1.Checked;
        }


    }
}

