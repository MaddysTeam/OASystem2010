using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.userManager.OAusersmanage
{
    public partial class modify : System.Web.UI.Page
    {
        Dianda.BLL.USER_Users users_Bll = new Dianda.BLL.USER_Users();
        Dianda.Model.USER_Users users_Model = new Dianda.Model.USER_Users();
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.COMMON.common commons = new Dianda.COMMON.common();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //获取到人员信息的ID
                string ID = Request["ID"].ToString();
                //显示人员的详细信息
                ShowUsersInfo(ID);

                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 人事管理";
                //设置模板页中的管理值
            }
        }

        protected void ShowUsersInfo(string id)
        {
            try
            {
                //获取到人员的详细信息
                users_Model = users_Bll.GetModel(id);

                //姓名
                TB_Name.Text =check(users_Model.REALNAME);
                //联系电话
                TB_TEL.Text = check(users_Model.TEL);
                //移动电话
                TextBox_TEMP1.Text = check(users_Model.TEMP1);
                //邮箱
                TB_EMAIL.Text = check(users_Model.EMAIL);
                //入职时间
                TB_DatesEmployed.Value = check2(users_Model.DatesEmployed);
                //离职时间
                TB_LeaveDates.Value =check2(users_Model.LeaveDates);
                //生日
                TB_BIRTHDAY.Value = check2(users_Model.BIRTHDAY);
                //籍贯
                TB_NativePlace.Text = check(users_Model.NativePlace);
                //住址
                TB_ADDRESS.Text = check(users_Model.ADDRESS);
                //毕业学校
                TB_GraduateSchool.Text = check(users_Model.GraduateSchool);
                //专业
                TB_Major.Text = check(users_Model.Major);
                //工作履历
                TB_TrackRecord.Text = check(users_Model.TrackRecord);

                //初始化下拉列表

                //部门下拉列表
                DataTable dt1 = new DataTable();
                string sql1 = " SELECT ID,NAME FROM USER_Groups WHERE (TAGS = '部门') AND (DELFLAG = 0)  GROUP BY ID,NAME ";
                dt1 = pageControl.doSql(sql1).Tables[0];
                CheckBox_DEPARTMENT.DataSource = dt1;
                CheckBox_DEPARTMENT.DataTextField = "NAME";
                CheckBox_DEPARTMENT.DataValueField = "ID";
                CheckBox_DEPARTMENT.DataBind();
                //获取部门信息
                string[] Depart = users_Model.DepartMentID.Split(',');
                //将部门信息导出部门选项中
                foreach (ListItem item in CheckBox_DEPARTMENT.Items)
                {
                    for (int i = 0; i < Depart.Length; i++)
                    {
                        if (Depart[i] == item.Value)
                        {
                            item.Selected = true;
                        }
                    }
                }
                //for (int i = 0; i < dt1.Rows.Count; i++)
                //{
                //    string DepartName = dt1.Rows[i]["NAME"].ToString();
                //    string ID = dt1.Rows[i]["ID"].ToString();

                //    ListItem li = new ListItem(DepartName, ID);
                //    DDL_DEPARTMENT.Items.Add(li);

                //    if (ID.Equals(users_Model.DepartMentID))
                //    {
                //        li.Selected = true;
                //    }
                //}

                //岗位下拉列表
                DataTable dt2 = new DataTable();
                string sql2 = " SELECT ID,NAME FROM USER_Groups WHERE (TAGS = '岗位') AND (DELFLAG = 0)  GROUP BY ID,NAME ";
                dt2 = pageControl.doSql(sql2).Tables[0];

                for (int k = 0; k < dt2.Rows.Count; k++)
                {
                    string Station = dt2.Rows[k]["NAME"].ToString();
                    string ID = dt2.Rows[k]["ID"].ToString();

                    ListItem li = new ListItem(Station, ID);
                    DDL_Station.Items.Add(li);

                    if (ID.Equals(users_Model.StationID))
                    {
                        li.Selected = true;
                    }
                }

                //状态
                DataTable dt3 = new DataTable();
                string sql3 = " SELECT ID, WorkStataName FROM USER_WorkStats_Base WHERE (DELFLAG = '0') ";
                dt3 = pageControl.doSql(sql3).Tables[0];

                for (int j = 0; j < dt3.Rows.Count;j++ )
                {
                    string WorkStats = dt3.Rows[j]["WorkStataName"].ToString();
                    string ID = dt3.Rows[j]["ID"].ToString();
                    ListItem li = new ListItem(WorkStats, ID);
                    DDL_WorkStats.Items.Add(li);

                    if (ID.Equals(users_Model.WorkStats))
                    {
                        li.Selected = true;
                    }
                }

                //性别
                for (int i = 0; i < RadioButtonList_SEX.Items.Count; i++)
                {
                    if (RadioButtonList_SEX.Items[i].Value.Equals(users_Model.SEX))
                    {
                        RadioButtonList_SEX.Items[i].Selected = true;
                    }
                }

                //是否为项目经理
                RadioButtonList_IsManager.SelectedValue = users_Model.IsManager.ToString();

                //学历
                DataTable dt4 = new DataTable();
                string sql4 = " SELECT ID, EducationLevel FROM USER_EducationLevel_Base ";
                dt4 = pageControl.doSql(sql4).Tables[0];

                for (int t = 0; t < dt4.Rows.Count;t++ )
                {
                    string EducationLevel = dt4.Rows[t]["EducationLevel"].ToString();
                    string ID = dt4.Rows[t]["ID"].ToString();
                    ListItem li = new ListItem(EducationLevel,ID);
                    DDL_EducationLevel.Items.Add(li);

                    if(ID.Equals(users_Model.EducationLevel))
                    {
                        li.Selected = true;
                    }
                }

            }
            catch
            {
                Response.Write("<script>alert('出错！')</script>");
            }
        }
        //验证一般对象属性是否存在
        public string check(object user)
        {
            string str = "";
            try
            {
                if (null != user)
                {

                    str = user.ToString();
                }
            }

            catch (Exception)
            {
            }

            return str;
        }
        //验证时间对象属性是否存在
        public string check2(object user)
        {
            string str = "";
            try
            {
                if (null != user)
                {
                    str = DateTime.Parse(user.ToString()).ToString("yyyy-MM-dd"); 

                }
            }

            catch (Exception)
            {
            }

            return str;
        }
        /// <summary>
        /// 返回按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx?pageindex=" + Request["pageindex"].ToString() + "&depart=" + Request["depart"].ToString() + "&workstatus=" + Request["workstatus"].ToString());
        }

        /// <summary>
        /// 点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_queding_Click(object sender, EventArgs e)
        {
            //try
            //{
                //部门ID
                string DepartMentID = "";
                //部门名称
                string DepartMentName = "";
                foreach (ListItem item in CheckBox_DEPARTMENT.Items)
                {
                    if (item.Selected == true)
                    {
                        DepartMentID += item.Value + ",";
                        DepartMentName += item.Text + ",";
                    }
                }
                if (DepartMentID != null && DepartMentID != "")
                {
                    string ID = Request["ID"];//获取到当前要修改的人员的ID
                    //获取到人员的详细信息
                    users_Model = users_Bll.GetModel(ID);

                    //姓名
                    users_Model.REALNAME = TB_Name.Text.ToString();
                    //性别
                    users_Model.SEX = RadioButtonList_SEX.SelectedValue.ToString();
                    //是否为项目经理
                    users_Model.IsManager = int.Parse(RadioButtonList_IsManager.SelectedValue.ToString());
                    //联系电话
                    users_Model.TEL = TB_TEL.Text;
                    //移动电话
                    users_Model.TEMP1 = TextBox_TEMP1.Text;
                    //邮箱
                    users_Model.EMAIL = TB_EMAIL.Text;
                    //入职时间
                    if (null == TB_DatesEmployed.Value || TB_DatesEmployed.Value.ToString() == "")
                    {
                        users_Model.DatesEmployed = null;
                    }
                    else
                    {
                        users_Model.DatesEmployed = Convert.ToDateTime(TB_DatesEmployed.Value.ToString());
                    }
                    //离职时间
                    if (null == TB_LeaveDates.Value || TB_LeaveDates.Value.ToString() == "")
                    {
                        users_Model.LeaveDates = null;
                    }
                    else
                    {
                        users_Model.LeaveDates = Convert.ToDateTime(TB_LeaveDates.Value.ToString());
                    }//生日
                    if (null == TB_BIRTHDAY.Value || TB_BIRTHDAY.Value.ToString().Equals(""))
                    {
                        users_Model.BIRTHDAY = "";
                    }
                    else
                    {
                        users_Model.BIRTHDAY = TB_BIRTHDAY.Value.ToString();
                    }
                    //籍贯
                    users_Model.NativePlace = TB_NativePlace.Text;
                    //学历
                    users_Model.EducationLevel = DDL_EducationLevel.SelectedValue.ToString();
                    //毕业学校
                    users_Model.GraduateSchool = TB_GraduateSchool.Text;
                    //专业
                    users_Model.Major = TB_Major.Text;
                    //住址
                    users_Model.ADDRESS = TB_ADDRESS.Text;
                    //工作履历
                    users_Model.TrackRecord = TB_TrackRecord.Text;
                    //部门                   
                    users_Model.DepartMentID = DepartMentID.Remove(DepartMentID.LastIndexOf(","));
                    //部门名称
                    users_Model.DepartMentName = DepartMentName.Remove(DepartMentName.LastIndexOf(","));
                    //岗位
                    users_Model.StationID = DDL_Station.SelectedValue.ToString();
                    //在职状态
                    users_Model.WorkStats = DDL_WorkStats.SelectedValue.ToString();

                    users_Bll.Update(users_Model);
                    new ajax().UpdateUserRemoteInfoWithJAVAWebService(users_Model, EnumRemoteOperation.Edit);
                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"].ToString() + "&depart=" + Request["depart"].ToString() + "&workstatus=" + Request["workstatus"].ToString() + "\";</script>";
                    Response.Write(coutws);

                    //添加操作日志

                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "编辑人员信息", "编辑" + user_model.REALNAME + "(" + user_model.USERNAME + ")" + "成功");

                    //添加操作日志
                }
                else
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "key", "alert('请选择部门！')", true);
                }
            //}
            //catch
            //{
            //    tag.Text = "操作失败，请重试！";
            //}
        }

        /// <summary>
        /// 点击新增按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_Click(object sender, EventArgs e)
        {
            string ID = Request["ID"];//获取到当前要修改的人员的ID
            //获取到人员的详细信息
            users_Model = users_Bll.GetModel(ID);

            //将用户的密码重新置成最初始的密码
            users_Model.PASSWORD = commons.GetMD5("123456");

            users_Bll.Update(users_Model);

            tag.Text = "重置成功！密码被重置成原始密码！";
        }
    }
}
