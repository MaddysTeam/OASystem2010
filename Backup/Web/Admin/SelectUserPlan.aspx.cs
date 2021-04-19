using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dianda.COMMON;
using System.Collections;

namespace Dianda.Web.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        pageControl pageControl = new pageControl();
        WBS001.Service1 Service = new WBS001.Service1();
        BLL.Personal_Plan_Limits BPerPlan = new Dianda.BLL.Personal_Plan_Limits();
        Model.Personal_Plan_Limits MperPlan = new Dianda.Model.Personal_Plan_Limits();
        Dianda.Model.USER_Users userModel = new Dianda.Model.USER_Users();
        BLL.USER_Groups bug = new Dianda.BLL.USER_Groups();
        Model.USER_Groups Groups = new Dianda.Model.USER_Groups();
        COMMON.pageControl pagedosql = new Dianda.COMMON.pageControl();
        COMMON.common commonId = new Dianda.COMMON.common();
        BLL.Project_UserList projectuserListBll = new Dianda.BLL.Project_UserList();
        Model.Project_UserList projectUserListModel = new Dianda.Model.Project_UserList();
       // Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Project_Projects mProjects = new Dianda.Model.Project_Projects();
        BLL.Project_Projects bProjects = new Dianda.BLL.Project_Projects();
        Model.USER_Users mUser = new Dianda.Model.USER_Users();

        BLL.Term_Diary blldiary = new Dianda.BLL.Term_Diary();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                //部门下拉列表
                DataTable dt1 = new DataTable();
                string sql1 = " SELECT ID,NAME FROM USER_Groups WHERE (TAGS = '部门') AND (DELFLAG = 0)  GROUP BY ID,NAME ";

                dt1 = pageControl.doSql(sql1).Tables[0];

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string DepartName = dt1.Rows[i]["NAME"].ToString();
                    string ID = dt1.Rows[i]["ID"].ToString();

                    ListItem li = new ListItem(DepartName, ID);
                    DDL_Department.Items.Add(li);

                }
                //绑定人员列表
                DataTable dtuser = new DataTable();
                dtuser = pageControl.doSql("select ID,USERNAME,REALNAME from USER_Users where DepartMentID='" + DDL_Department.SelectedValue.ToString() + "' and WorkStats='1' and DELFLAG=0").Tables[0];
                if (dtuser.Rows.Count > 0)
                {

                    for (int i = 0; i < dtuser.Rows.Count; i++)
                    {
                        string ApplyUserName = dtuser.Rows[i]["REALNAME"].ToString() + "(" + dtuser.Rows[i]["USERNAME"].ToString() + ")";
                        string ID = dtuser.Rows[i]["ID"].ToString();

                        ListItem li = new ListItem(ApplyUserName, ID);
                        User_DPList.Items.Add(li);

                    }
                }
                else
                {
                    ListItem li = new ListItem("本部门无人员", "0");
                    User_DPList.Items.Add(li);
                    User_DPList.Enabled = false;
                }
                ///处理默认选中值的问题：部门和人员，默认选中自己
                string departmentid = user_model.DepartMentID.ToString();
                string userids = user_model.ID.ToString();
                try
                {
                    string[] arraydepartid = departmentid.Split(',');

                    DDL_Department.SelectedValue = arraydepartid[0].ToString();
                    doDepartidChanged();//调用部门切换的函数，将当前选中的部门下的人员都列出来
                    User_DPList.SelectedValue = userids;
                }
                catch
                {
                }

                ///处理默认选中值的问题：部门和人员，默认选中自己


                Label1.Text = "";
          //      selectDate_start.setSelectDays(DateTime.Now);
               //selectDate_end.setSelectDays(DateTime.Now);

                (Master.FindControl("Label_navigation") as Label).Text = "查看他人个人计划 ";
                userModel = (Model.USER_Users)Session["USER_Users"];
                DataTable UserPlan = new DataTable();
                UserPlan = pagedosql.doSql("select count(*)as 'count' from Personal_Plan_Limits where userid='" + userModel.ID + "'").Tables[0];
                if (int.Parse(UserPlan.Rows[0]["count"].ToString()) > 0)
                {
                    showlist();
                }
                else
                {
                    MperPlan.APPLYUSERID = userModel.ID;
                    MperPlan.ISALL = 0;
                    MperPlan.USERID = userModel.ID;
                    BPerPlan.Add(MperPlan);
                    showlist();
                }
                //设置显示状态
                if (Request.QueryString["staue"] != null)
                {
                    if (Request.QueryString["staue"].ToString() == "1")
                    {
                        SelectTable.Visible = false;
                        CheckUser.Visible = true;
                        (Master.FindControl("Label_navigation") as Label).Text = "设置个人计划浏览权限";
                    }
                }
                else
                {
                    SelectTable.Visible = true;
                    CheckUser.Visible = false;
                    (Master.FindControl("Label_navigation") as Label).Text = "查看他人个人计划 ";
                }
            }
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = "";
                userModel = (Model.USER_Users)Session["USER_Users"];
                //MperPlan = BPerPlan.GetModel(int.Parse(User_DPList.SelectedValue));              
                DataTable DTUserMplan = new DataTable();
                DTUserMplan = pagedosql.doSql("select ISALL,APPLYUSERID from Personal_Plan_Limits where USERID='" + User_DPList.SelectedValue.ToString() + "'").Tables[0];
                if (DTUserMplan.Rows.Count > 0)
                {
                    string applyuserid =","+ DTUserMplan.Rows[0]["APPLYUSERID"].ToString()+",";//当前用户限定的访问范围
                    string isall = DTUserMplan.Rows[0]["ISALL"].ToString();//当前用户限定的访问范围总值
                    bool isselect=false;//标记当前用户是否有搜索该用户的权限
                    if (isall == "1")
                    {
                        isselect = true;
                    }
                    else
                    {
                        if (applyuserid.Contains(","+userModel.ID.ToString()+","))
                        {
                            isselect = true;
                        }
                    }


                    if (isselect)
                    {
                        DataTable DT = new DataTable();
                        string strDateTimeStart = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
                        string strDateTimeEnd = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";
                        string T_Sql = "select * from Personal_Plan where DELFLAG=0 and UserID='" + User_DPList.SelectedValue.ToString() + "'  and StartTime>='" + strDateTimeStart + "'  and endTime<='" + strDateTimeEnd + "'  order by DATETIME DESC";
                        DT = pageControl.doSql(T_Sql).Tables[0];

                        //Service.getDateInfo(User_DPList.SelectedValue.ToString(), "2011-05-29 00:00:00", "2011-06-03 23:59:59");
                        ///调用FLASH
                        showflash(User_DPList.SelectedValue.ToString(), strDateTimeStart, strDateTimeEnd);
                    }
                    else
                    {
                        Label1.Text = "*对不起，该用户未给您设置浏览权限!";
                        Label1.Style.Add("color", "red");
                       // GridView1.Visible = false;
                        Label_flash.Text = "";
                    }


                   
                }
                else
                {
                    Label1.Text = "*对不起，该用户未给您设置浏览权限!";
                    Label1.Style.Add("color", "red");
                   // GridView1.Visible = false;
                    Label_flash.Text = "";
                }

            }
            catch (Exception)
            {

                Label1.Text = "*对不起！无法为您无法获取用户的个人计划！";
                Label1.Style.Add("color", "red");
               // GridView1.Visible = false;
                Label_flash.Text = "";
            }

        }
        //部门发生改变时
        protected void DDL_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            doDepartidChanged();
        }
        /// <summary>
        /// 部门进行切换的时候，要做人员列表的切换
        /// </summary>
        public void doDepartidChanged()
        {
            Label1.Text = "";
            //绑定人员列表
            User_DPList.Items.Clear();
            DataTable dtuser = new DataTable();
            dtuser = pageControl.doSql("select ID,USERNAME,REALNAME from USER_Users where DepartMentID like '%" + DDL_Department.SelectedValue.ToString() + "%' and WorkStats='1' and DELFLAG=0").Tables[0];
            if (dtuser.Rows.Count > 0)
            {

                for (int i = 0; i < dtuser.Rows.Count; i++)
                {
                    string ApplyUserName = dtuser.Rows[i]["REALNAME"].ToString() + "(" + dtuser.Rows[i]["USERNAME"].ToString() + ")";
                    string ID = dtuser.Rows[i]["ID"].ToString();

                    ListItem li = new ListItem(ApplyUserName, ID);
                    User_DPList.Items.Add(li);

                }
            }
            else
            {
                ListItem li = new ListItem("本部门无人员", "0");
                User_DPList.Items.Add(li);
                User_DPList.Enabled = false;
            }
        }
        /// <summary>
        /// 调用FLASH显示用户的数据
        /// </summary>
        /// <param name="username"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        private void showflash(string username, string starttime, string endtime)
        {
            try
            {
                string theStartWeeks="";
                string loginUserId =  Session["LoginID"].ToString();
                List<Model.Term_Diary> diarylist = blldiary.GetModelList("DELFLAG=0 AND ISWORK='1'");
                if (diarylist.Count > 0)
                {
                    theStartWeeks = diarylist[0].FirstWeek.Value.ToString("yyyy-MM-dd")+" 00:00:00";
                }
                string urls = getWbsUrl();// Request.Url.Host;
                string coutw = "<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0\" width=\"950\" height=\"291\" id=\"calendar\" align=\"middle\"><param name=\"allowScriptAccess\" value=\"sameDomain\" /><param name=\"movie\" value=\"calendar.swf\" /><param name=\"flashVars\" value=\"useId=" + username + "&loginUserId=" + loginUserId + "&returnStartTime=" + starttime + "&returnEndTime=" + endtime + "&theStartWeek=" + theStartWeeks + "&url=" + urls + "\" /><param name=\"quality\" value=\"high\" /><param name=\"bgcolor\" value=\"#ffffff\" /><embed src=\"calendar.swf\" quality=\"high\" bgcolor=\"#ffffff\" width=\"950\" height=\"291\" name=\"calendar\" align=\"middle\" allowScriptAccess=\"sameDomain\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" /><param name='wmode' value='transparent'></object>";
                Label_flash.Text = coutw;
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据当前的系统的IP，获取到WEBS的IP:端口号
        /// </summary>
        /// <returns></returns>
        private string getWbsUrl()
        {
            string coutw = "";
            try
            {
                string localiphost = Request.Url.Host;
                string ips = HiddenField_ip.Value.ToString();
                string[] ipsarray = ips.Split(';');
                for (int i = 0; i < ipsarray.Length; i++)
                {
                    string[] arr = ipsarray[i].Split(',');
                    if (localiphost.Contains(arr[0].ToString()))
                    {
                        coutw = arr[1].ToString();
                        break;
                    }
                }
            }
            catch
            {
            }
            return coutw;
        }
        //状态绑定
        public string staue(object str)
        {
            string sta = str.ToString();
            if (sta == "0")
            {
                sta = "未开始";
            }
           else if (sta == "1")
            {
                sta = "进行中";
            }
          else if (sta == "2")
            {
                sta = "完成";
            }
          else if (sta == "3")
            {
                sta = "延期";
            }
            return sta;
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
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                string strId = user_model.ID;
                DelUser(strId);
                if (ALLCheck.Checked == true)
                {
                    Model.Personal_Plan_Limits MperPlan = new Dianda.Model.Personal_Plan_Limits();
                    MperPlan.USERID = user_model.ID;
                    MperPlan.APPLYUSERID = user_model.ID;
                    MperPlan.ISALL = 1;
                    BPerPlan.Add(MperPlan);
                }
                else
                {

                    ArrayList al = ShareForUser1.getSelectUser();
                    addUser(strId, al);

                }

                //添加操作日志
                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();               
                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加人员", "添加成功");
                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");location.href='SelectUserPlan.aspx?staue=1';</script>";
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
                Model.Personal_Plan_Limits plan = new Dianda.Model.Personal_Plan_Limits();
                plan.USERID = ProjectId;
                plan.ISALL = 0;
                plan.APPLYUSERID = "";
                for (int i = 0; i < al.Count; i++)
                {
                    if (al[i] != null && al[i].ToString() != "")
                    {
                        plan.APPLYUSERID += al[i].ToString()+",";
                       
                    }
                }
                plan.APPLYUSERID = plan.APPLYUSERID.Remove(plan.APPLYUSERID.LastIndexOf(","));
                BPerPlan.Add(plan);
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
                string strsql = "Delete from Personal_Plan_Limits where userid ='" + ProjectId + "'";
                pagedosql.doSql(strsql);
            }
            catch (Exception)
            {
            }
        }
        //设置浏览权限按钮
        protected void ButSet_Click(object sender, EventArgs e)
        {
            SelectTable.Visible = false;
            CheckUser.Visible = true;
            (Master.FindControl("Label_navigation") as Label).Text = "设置个人计划浏览权限 ";
        }
        //查看他人个人计划
        protected void Button2_Click(object sender, EventArgs e)
        {
            SelectTable.Visible = true;
            CheckUser.Visible = false;
            (Master.FindControl("Label_navigation") as Label).Text = "查看他人个人计划 ";
        }
        //全选CHECKBOX按钮
        protected void ALLCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ck = (CheckBox)sender;
            if (ck.Checked == true)
            {

                ((GridView)ShareForUser1.FindControl("GridView_grouplist")).Enabled = false;
            }
            else
            {
                ((GridView)ShareForUser1.FindControl("GridView_grouplist")).Enabled = true;
            }
        }

        //将数据添加到控件中
        public void showlist()
        {

            try
            {
                //获取到人员ID
                userModel = (Model.USER_Users)Session["USER_Users"];
                DataTable DTMplan = new DataTable();
                DTMplan = pagedosql.doSql("select APPLYUSERID from Personal_Plan_Limits where USERID='" + userModel.ID + "'").Tables[0];
                //通过方法 用逗号把部门ID分开
                string strapllyId = commonId.makeSqlIn(DTMplan.Rows[0]["APPLYUSERID"].ToString(), ',');
                //查询出部门中status =1 并且delflag=0 的用户
                string sql = "SELECT  * FROM USER_Users WHERE (DELFLAG = '0') and id in" + strapllyId + " ORDER BY DepartMentID";
                DataTable dt1 = pagedosql.doSql(sql).Tables[0];

                //通过部门ID 查看部门里有多少人员
                string strsql = "select * from USER_Users where (DELFLAG = '0')";
                DataTable dt = pagedosql.doSql(strsql).Tables[0];
                //查询出传进来的部门ID
                DataTable dt2 = new DataTable();
                dt2 = bug.GetList(" TAGS='部门' and DELFLAG='0'order by ISMOREN").Tables[0];
                ShareForUser1.showDepartment(dt1, dt, dt2);
                if (dt.Rows.Count > 0)
                {

                    ShareForUser1.Visible = true;
                }
                else
                {
                    ShareForUser1.Visible = false;
                }
                //查看是否为全部可见
                DataTable DTUserMplan = new DataTable();
                DTUserMplan = pagedosql.doSql("select ISALL from Personal_Plan_Limits where USERID='" + userModel.ID + "'").Tables[0];
                if (DTUserMplan.Rows[0]["ISALL"].ToString() == "1")
                {
                    ((GridView)ShareForUser1.FindControl("GridView_grouplist")).Enabled = false;
                    ALLCheck.Checked = true;
                }
                else
                {
                    ((GridView)ShareForUser1.FindControl("GridView_grouplist")).Enabled = true;
                    ALLCheck.Checked = false;
                }


            }
            catch
            {
            }
        }

        //返回主页
        protected void backToHome_Click1(object sender, EventArgs e)
        {
            Response.Redirect("person_Index.aspx");
        }

    }
}
