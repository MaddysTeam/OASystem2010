using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web
{
    public partial class login : System.Web.UI.Page
    {
        Model.USER_Users mUser = new Dianda.Model.USER_Users();//加载用户的实体类
        BLL.USER_Users bUser = new Dianda.BLL.USER_Users();//加载用户的操作类
        Model.userPower mUserPower = new Dianda.Model.userPower();//用户的权限实体类
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.COMMON.common common = new Dianda.COMMON.common();
        BLL.USER_Groups bugroups = new Dianda.BLL.USER_Groups();
        Model.USER_Groups mugroups = new Dianda.Model.USER_Groups();
        protected void Page_Load(object sender, EventArgs e)
        {
            string dos = null;//接受退出的指令
            string tag = null;//接受系统异常退出后的指令 0表示没有权限；1表示异常退出
            try
            {
              
                dos = Request["do"];
                tag = Request["tag"];

                if (dos == "logout")
                {
                    Session["USER_Users"] = null;
                    Session["IsSecretary"] = null;
                }
                else
                {
                    mUser = (Model.USER_Users)Session["USER_Users"];//实例化
                    if (mUser.ID.ToString()!="" && mUser.USERNAME.ToString() != "")
                    {

                        string url = "/Admin/person_Index.aspx";
                        Response.Redirect(url);
                    }
                }
            }
            catch
            {

            }
        }
        
        //点击进入登陆
        protected void ImageButton_login_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["isDepartment"] = "个人";

                string TextBox_username_1 = TextBox_username.Text.ToString();
                string TextBox_pwd_1 = TextBox_pwd.Text.ToString();
                COMMON.common commonse = new Dianda.COMMON.common();

                string username = commonse.SafeString(TextBox_username_1);
                string pwd = commonse.SafeString(TextBox_pwd_1);

                List<Model.USER_Users> muserlist = bUser.GetModelList(" USERNAME='" + username + "' and PASSWORD='" + commonse.GetMD5(pwd) + "' and DELFLAG=0");
                if (muserlist.Count > 0)
                {
                    //说明登录成功
                    mUser = muserlist[0];
                    //设置Session["USER_Users"]中的TEMP4为用户的当前默认部门（为了在部门首页上做部门的切换使用）。
                    string departments = mUser.DepartMentID.ToString();
                    if (departments.Contains(","))
                    {
                        string[] dearray = departments.Split(',');
                        mUser.TEMP4 = dearray[0].ToString();
                    }
                    else
                    {
                        mUser.TEMP4 = departments;
                    }
                    Session["USER_Users"] = mUser;
                    Session["LoginID"] = mUser.ID.ToString();

                    //*************************如果登陆成功，需要获取该登陆者负责或参与的项目,    modify by wangjh on 2010-11-02 begin
                    Web.Admin.personalProjectManage.MakeProjectSession makeprojectsession = new Dianda.Web.Admin.personalProjectManage.MakeProjectSession();
                    makeprojectsession.getMyProjectList(this);
                   
                   // //负责的项目
                   // //string sql1 = " SELECT ID,NAMES FROM vProject_Projects WHERE LeaderID='" + mUser.ID + "' and DELFLAG=0  and (Status=1 or Status=3 or Status=5) ";
                   // string sql1 = " SELECT ID,NAMES,DELFLAG,Status FROM vProject_Projects WHERE LeaderID='" + mUser.ID + "' and (Status=1 or Status=3 or Status=5) ";
                   // //由于在我的项目中需要添加一个已删除的项目，所以在加载项目时也需要将删除的显示出来，故作以上修改（and DELFLAG=0 删除了）

                   // DataTable dt1 = pageControl.doSql(sql1).Tables[0];

                   // //参与的项目
                   //// string sql2 = " SELECT  ID,NAMES FROM  vProject_Projects WHERE  DELFLAG=0 and id in(select Projectid from Project_UserList where userid='" + mUser.ID + "' and status='1') ";
                   // string sql2 = " SELECT  ID,NAMES,DELFLAG,Status  FROM  vProject_Projects WHERE id in(select Projectid from Project_UserList where userid='" + mUser.ID + "' and status='1') ";
                   // //由于在我的项目中需要添加一个已删除的项目，所以在加载项目时也需要将删除的显示出来，故作以上修改（DELFLAG=0 and 删除了）

                   // DataTable dt2 = pageControl.doSql(sql2).Tables[0];

                   // //合并两个相同结构的DATATABLE
                   // DataTable Newdt = common.CombineTheSameDatatable(dt1,dt2);
                   // //将一个DATATABLE中的重复项去除掉
                   // if (null != Newdt)
                   // {
                   //     Newdt = common.makeDistinceTable(Newdt, "ID");

                   //     Session["Project_Projects"] = Newdt;
                   // }


                    //*************************如果登陆成功，需要获取该登陆者负责或参与的项目,   modify by wangjh on 2010-11-02 end

                    //写日志
                    BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                    bslog.addlogs(mUser.REALNAME.ToString() + "(" + mUser.USERNAME.ToString() + ")", "登录系统", "登录系统:成功");
                    //写日志
                    //根据用户的用户组来生成用户的权限数据

                    ///构造用户的全部权限
                   DataTable sessionData= sessionPower(mUser.ID.ToString());
                   string[] arrays = getPowerSession(sessionData, mUser.ID.ToString());
                   mUserPower.specialRole = arrays[3].ToString();
                   mUserPower.buttomID = arrays[2].ToString();
                   mUserPower.menuRole = arrays[1].ToString();
                   mUserPower.pageurl = arrays[0].ToString();
                   mUserPower.userid = mUser.ID.ToString();
                   mUserPower.isYinLeader = arrays[4].ToString(); //"0";//表示该用户是用印管理的领导（根据特定的权限点来判断该用户是否是领导）                 
                   Session["Session_Power"] = mUserPower;
                   //付全文    2013-4-16   消息权限
                   string strSql = "select roles from user_role where name='消息-取消通知公告' and Types='菜单权限' and delflag =0";
                   DataTable dt = pageControl.doSql(strSql).Tables[0];
                   string roles = null;
                   foreach (DataRow row in dt.Rows)
                   {
                       roles = row["roles"].ToString();
                   }
                   Session["Session_Role"] = roles;
                   ///构造用户的全部权限


                    string url = "/Admin/person_Index.aspx";
                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">location.href='" + url + "';</script>";
                    Response.Write(coutws);
                }
                else
                {
                    //登录失败
                    Session["USER_Users"] = "";
                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"登录失败，请核实您的用户名和密码\");location.href='login.aspx';</script>";
                    Response.Write(coutws);
                }

            }
            catch
            {
                //登录失败
                Session["USER_Users"] = "";
                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"登录失败，请核实您的用户名和密码\");location.href='login.aspx';</script>";
                Response.Write(coutws);
            }
        }
        /// <summary>
        /// 根据用户的ID，获取到当前用户的所有权限
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        private DataTable sessionPower(string userid)
        {
            DataTable dt1 = new DataTable();
            try
            {
                mUser = bUser.GetModel(userid);
                if (mUser != null)
                {
                    string department = mUser.DepartMentID.ToString();//部门的ID
                    string gangwei = mUser.StationID.ToString();//岗位的ID
                    string spacialrole = mUser.GROUPS.ToString();
                  
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();
                    dt1 = getRoles(department);
                    dt2 = getRoles(gangwei);
                    dt3 = getRoles(spacialrole);
                

                    dt1 = common.CombineTheSameDatatable(dt1, dt2);
                    dt1 = common.CombineTheSameDatatable(dt1, dt3);
                    dt1 = common.makeDistinceTable(dt1, "ID");

                    //新建一个Session，判断是不是秘书
                    DataTable Isdt = bugroups.GetList("id in ('" + spacialrole.Replace(",", "','") + "') and Name = '秘书' and tags='普通组'").Tables[0];
                    if (Isdt.Rows.Count > 0)
                        Session["IsSecretary"] = "1";
                    else
                        Session["IsSecretary"] = "0";
                }
            }
            catch
            {
            }
            return dt1;
        }
        /// <summary>
        /// 根据传递的数据集合构建3种SESSION的值
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string[] getPowerSession(DataTable dt,string userid)
        {
            string[] coutw ={"","","","",""};//页面的权限,菜单的权限，按钮的权限,个人首页上的审批提醒权限,是否是用印管理的领导
            try
            {
                string pagesession = "";
                string menusession = "";
                string buttonsession = "";
                string shenpisession = "";
                string isYinLeadersession = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Types"].ToString() == "页面权限")
                    {
                        pagesession = pagesession + dt.Rows[i]["Roles"].ToString() + ";";

                        ///Admin/cashCardManage/manageCashApply.aspx-财务管理-预约情况列表--“经费预约”
                        ///Admin/SystemProjectManage/ProjectCheck/manage.aspx-项目管理-立项审核-列表--“立项申请”
                        ///Admin/applyManage/OrderfoodManage/manage.aspx-管理-订饭管理列表--“客饭预定”
                        ///Admin/applyManage/OrdercarManage/manage.aspx-管理-车辆管理-列表--“车辆预定”
                        ///Admin/applyManage/OrderroomManage/manage.aspx-管理-会议室管理-列表--“会议室预定”
                        ///Admin/applyManage/OrdersignetManage/manage.aspx-管理- 用印管理-列表--“印章申请”
                        if (dt.Rows[i]["Roles"].ToString().Contains("/Admin/cashCardManage/manageCashApply.aspx"))
                        {
                            shenpisession = shenpisession + " NewsType='经费预约' or";
                        }
                        if (dt.Rows[i]["Roles"].ToString().Contains("/Admin/SystemProjectManage/ProjectCheck/manage.aspx"))
                        {
                            shenpisession = shenpisession + " (NewsType='立项申请' and  Receive='" + userid + "')  or";
                        }
                        if (dt.Rows[i]["Roles"].ToString().Contains("/Admin/applyManage/OrderfoodManage/manage.aspx"))
                        {
                            shenpisession = shenpisession + " NewsType='客饭预定' or";
                        }
                        if (dt.Rows[i]["Roles"].ToString().Contains("/Admin/applyManage/OrdercarManage/manage.aspx"))
                        {
                            shenpisession = shenpisession + " NewsType='车辆预定' or";
                        }
                        if (dt.Rows[i]["Roles"].ToString().Contains("/Admin/applyManage/OrderroomManage/manage.aspx"))
                        {
                            shenpisession = shenpisession + " NewsType='会议室预定' or";
                        }
                        if (dt.Rows[i]["Roles"].ToString().Contains("/Admin/applyManage/OrdersignetManage/manage.aspx"))
                        {
                            shenpisession = shenpisession + " (NewsType='印章申请' and  Receive='" + userid + "')  or";
                        }

                    }
                    if (dt.Rows[i]["Types"].ToString() == "菜单权限")
                    {
                        menusession = menusession + dt.Rows[i]["Roles"].ToString() + ";";
                    }
                    if (dt.Rows[i]["Types"].ToString() == "按钮权限")
                    {
                        buttonsession = buttonsession + dt.Rows[i]["upRoles"].ToString() + "," + dt.Rows[i]["Roles"].ToString() + ";";
                    }
                    if (dt.Rows[i]["Roles"].ToString().Contains("isYinLeader_1"))
                    {
                        isYinLeadersession = "1";
                    }
                }
                if (shenpisession.Length > 0)
                {
                    //处理这个条件，使之成为可以直接放在SQL中语句
                    if (shenpisession.Substring(shenpisession.Length - 2, 2) == "or")
                    {
                        shenpisession = shenpisession.Substring(0, shenpisession.Length - 2);
                    }
                    shenpisession = "(" + shenpisession + ")";
                }
                coutw[0] = pagesession;
                coutw[1] = menusession;
                coutw[2] = buttonsession;
                coutw[3] = shenpisession;
                coutw[4] = isYinLeadersession;
            }
            catch
            {
            }
            return coutw;
        }

      

        /// <summary>
        /// 根据用户组的ID获取到权限列表
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        private DataTable getRoles(string groupid)
        {
            DataTable dt = new DataTable();
            try
            {
                if (groupid.Contains(","))
                {
                    string[] groupids = groupid.Split(',');
                    for (int i = 0; i < groupids.Length; i++)
                    {
                        if (groupids[i].ToString().Length > 0)
                        {
                            DataTable dt1=getRolesSig(groupids[i].ToString());
                            dt = common.CombineTheSameDatatable(dt1, dt);
                        }
                    }
                    dt = common.makeDistinceTable(dt, "ID");
                }
                else
                {
                    dt = getRolesSig(groupid);
                }
            }
            catch
            {
            }
            return dt;
        }
        /// <summary>
        /// 根据用户组的ID，获取到当个用户组的
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        private DataTable getRolesSig(string groupid)
        {
            DataTable coutw = new DataTable();
            try
            {
                groupid = common.RequestSafeString(groupid, 50);
                mugroups = bugroups.GetModel(groupid);
                if (mugroups != null)
                {
                    //根据找到的用户组，找出所有的权限点
                    string rolelist = mugroups.ROLE.ToString();
                    string sqlin = "";
                    string sql = "";
                    if (rolelist.Contains(","))
                    {
                      sqlin = common.makeSqlIn(rolelist, ',');
                      sql = "select ID,Roles,Types,upRoles from vUSER_Role where DELFLAG='0' AND ID in " + sqlin;
                      coutw = pageControl.doSql(sql).Tables[0];
                    }
                    else
                    {
                        if (rolelist.Length > 0)
                        {
                            sql = "select ID,Roles,Types,upRoles from vUSER_Role where DELFLAG='0' AND ID='" + rolelist+"'";
                            coutw = pageControl.doSql(sql).Tables[0];
                        }
                    }
                }
            }
            catch
            {
            }
            return coutw;
        }
    }
}
