using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.userManager.OAusersmanage
{
    public partial class add : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.Model.USER_Users users_Model = new Dianda.Model.USER_Users();
        Dianda.BLL.USER_Users users_Bll = new Dianda.BLL.USER_Users();
        Dianda.COMMON.common commons = new Dianda.COMMON.common();

        Dianda.BLL.Document_Folder docfolder_bll = new Dianda.BLL.Document_Folder();
        Dianda.Model.Document_Folder docfolder_model = new Dianda.Model.Document_Folder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //在执行添加之前需要先对输入框进行校验。
                //this.Button_sumbit.Attributes.Add("onclick", "return check_value();");
                ShowDDLInfo();
                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 人事管理";
                //设置模板页中的管理值
                
            }
        }

        /// <summary>
        /// 初始化下拉列表的值
        /// </summary>
        protected void ShowDDLInfo()
        {
            try
            {
                //初始化下拉列表

                //部门下拉列表
                DataTable dt1 = new DataTable();
                string sql1 = " SELECT ID,NAME FROM USER_Groups WHERE (TAGS = '部门') AND (DELFLAG = 0)  GROUP BY ID,NAME ";
                dt1 = pageControl.doSql(sql1).Tables[0];

                CheckBox_DEPARTMENT.DataSource = dt1;
                CheckBox_DEPARTMENT.DataTextField = "NAME";
                CheckBox_DEPARTMENT.DataValueField = "ID";
                CheckBox_DEPARTMENT.DataBind();
                //for (int i = 0; i < dt1.Rows.Count; i++)
                //{
                //    string DepartName = dt1.Rows[i]["NAME"].ToString();
                //    string ID = dt1.Rows[i]["ID"].ToString();

                //    ListItem li = new ListItem(DepartName, ID);
                //    DDL_DEPARTMENT.Items.Add(li);

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

                }

                //状态
                DataTable dt3 = new DataTable();
                string sql3 = " SELECT ID, WorkStataName FROM USER_WorkStats_Base WHERE (DELFLAG = '0') ";
                dt3 = pageControl.doSql(sql3).Tables[0];

                for (int j = 0; j < dt3.Rows.Count; j++)
                {
                    string WorkStats = dt3.Rows[j]["WorkStataName"].ToString();
                    string ID = dt3.Rows[j]["ID"].ToString();
                    ListItem li = new ListItem(WorkStats, ID);
                    DDL_WorkStats.Items.Add(li);

                }

                //学历
                DataTable dt4 = new DataTable();
                string sql4 = " SELECT ID, EducationLevel FROM USER_EducationLevel_Base ";
                dt4 = pageControl.doSql(sql4).Tables[0];

                for (int t = 0; t < dt4.Rows.Count; t++)
                {
                    string EducationLevel = dt4.Rows[t]["EducationLevel"].ToString();
                    string ID = dt4.Rows[t]["ID"].ToString();
                    ListItem li = new ListItem(EducationLevel, ID);
                    DDL_EducationLevel.Items.Add(li);
                }
            }
            catch
            {
 
            }
        }

        /// <summary>
        /// 确定添加新用户组
        /// 1.添加新人员前要检测该用户组的名称是否已经在系统中注册，如果注册过了，则提醒用户重复，要求用户重新命名
        /// 2.添加该用户进数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_queding_Click(object sender, EventArgs e)
        {
            try
            {
                string username = TB_USERNAME.Text.ToString();//获取到用户名

                //检查该名称是否有了
                if (username != "")
                {
                    //检查是否有该用户组名称
                    bool checkName = pageControl.Exists_Name("USER_Users", "USERNAME", username, "ID", "");

                    if (checkName)
                    {
                        tag.Text = "该用户名已经存在，请修改！";
                    }
                    else
                    {
                        //部门ID
                        string DepartMentID = "";
                        //部门名称
                        string DepartMentName = "";
                        foreach (ListItem item in CheckBox_DEPARTMENT.Items)
                        {
                            if (item.Selected == true)
                            {
                                DepartMentID += item.Value + ",";
                                DepartMentName +=item.Text + ",";
                            }
                        }
                        if (DepartMentID != null && DepartMentID != "")
                        {
                            users_Model.ID = commons.GetGUID();//获取到GUID作为ID
                            //用户名
                            users_Model.USERNAME = TB_USERNAME.Text.ToString();
                            //密码
                            users_Model.PASSWORD = commons.GetMD5(TB_PASSWORD.Text.Trim());
                            //真实姓名
                            users_Model.REALNAME = TB_REALNAME.Text;
                            //性别
                            users_Model.SEX = RadioButtonList_SEX.SelectedValue.ToString();
                            //是否为项目经理
                            users_Model.IsManager = int.Parse(RadioButtonList_IsManager.SelectedValue.ToString());
                            //部门                   
                            users_Model.DepartMentID = DepartMentID.Remove(DepartMentID.LastIndexOf(","));
                            //部门名称
                            users_Model.DepartMentName = DepartMentName.Remove(DepartMentName.LastIndexOf(","));
                            //岗位
                            users_Model.StationID = DDL_Station.SelectedValue.ToString();
                            //联系电话
                            users_Model.TEL = TB_TEL.Text;
                            //移动电话
                            users_Model.TEMP1 = TextBox_TEMP1.Text;
                            //邮箱
                            users_Model.EMAIL = TB_EMAIL.Text;
                            //在职状态
                            users_Model.WorkStats = DDL_WorkStats.SelectedValue.ToString();
                            //入职时间 
                            if (null == TB_DatesEmployed.Value || TB_DatesEmployed.Value.ToString().Equals(""))
                            {
                                users_Model.DatesEmployed = null;

                            }
                            else
                            {
                                users_Model.DatesEmployed = Convert.ToDateTime(TB_DatesEmployed.Value.ToString());

                            }

                            //离职时间
                            if (null == TB_LeaveDates.Value || TB_LeaveDates.Value.ToString().Equals(""))
                            {
                                users_Model.LeaveDates = null;

                            }
                            else
                            {
                                //离职时间
                                users_Model.LeaveDates = Convert.ToDateTime(TB_LeaveDates.Value.ToString());
                            }
                            //生日
                            if (TB_BIRTHDAY.Value == null || TB_BIRTHDAY.Value.ToString().Equals(""))
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
                            //住址
                            users_Model.ADDRESS = TB_ADDRESS.Text.ToString();
                            //毕业学校
                            users_Model.GraduateSchool = TB_GraduateSchool.Text;
                            //专业
                            users_Model.Major = TB_Major.Text;
                            //工作履历
                            users_Model.TrackRecord = TB_TrackRecord.Text;
                            //时间
                            users_Model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
                            //工作组
                            string sql_groups = "SELECT ID FROM USER_Groups WHERE (ISMOREN = '1') AND (TAGS = '普通组')";
                            DataTable dt = pageControl.doSql(sql_groups).Tables[0];

                            users_Model.GROUPS = dt.Rows[0]["ID"].ToString();

                            //头像
                            users_Model.IMAGES = "";
                            //删除标记
                            users_Model.DELFLAG = 0;

                            users_Bll.Add(users_Model);
                            new ajax().UpdateUserRemoteInfoWithJAVAWebService(users_Model, EnumRemoteOperation.Import);
                            //人员信息添加成功以后，要向Document_Folder中添加一个当前用户的顶级档案目录

                            int docfolderid = docfolder_bll.GetMaxId();

                            docfolder_model.ID = docfolderid;
                            //目录名称
                            docfolder_model.FolderName = users_Model.USERNAME + "_" + users_Model.REALNAME;
                            //上级目录
                            docfolder_model.UpID = -1;
                            //文件夹的属性
                            docfolder_model.Types = "private";
                            //所属人ID
                            docfolder_model.UserID = users_Model.ID;
                            //是否共享
                            docfolder_model.IsShare = 0;
                            //删除标记
                            docfolder_model.DELFLAG = 0;
                            //当前时间
                            docfolder_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            //栏目的路径记录（用/来隔开）
                            docfolder_model.COLUMNSPATH = "-1/" + docfolder_model.ID;
                            //栏目显示的顺序
                            docfolder_model.SHUNXU = 0;
                            //栏目的路径名称
                            docfolder_model.PNAMES = "我的文档";
                            //当前文件夹中文件的大小
                            docfolder_model.SizeOf = "0";

                            docfolder_bll.Add(docfolder_model);


                            //人员信息添加成功以后，要向Document_Folder中默认添加一个收藏夹

                            docfolder_model.ID = docfolder_bll.GetMaxId();
                            //目录名称
                            docfolder_model.FolderName = "收藏夹";
                            //上级目录
                            docfolder_model.UpID = docfolderid;
                            //文件夹的属性
                            docfolder_model.Types = "private";
                            //所属人ID
                            docfolder_model.UserID = users_Model.ID;
                            //是否共享
                            docfolder_model.IsShare = 0;
                            //删除标记
                            docfolder_model.DELFLAG = 0;
                            //当前时间
                            docfolder_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            //栏目的路径记录（用/来隔开）
                            docfolder_model.COLUMNSPATH = "-1/" + docfolder_model.UpID + "/" + docfolder_model.ID;
                            //栏目显示的顺序
                            docfolder_model.SHUNXU = 0;
                            //栏目的路径名称
                            docfolder_model.PNAMES = "我的档案>收藏夹";
                            //当前文件夹中文件的大小
                            docfolder_model.SizeOf = "0";

                            docfolder_bll.Add(docfolder_model);
                           

                            tag.Text = "操作成功！";

                            string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx" + "\";</script>";


                            Response.Write(coutws);

                            //添加操作日志

                            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加人员信息", "添加" + users_Model.REALNAME + "(" + user_model.USERNAME + ")" + "成功");
                            //添加操作日志
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "key", "alert('请选择部门！')", true);
                        }
                    }
                }
            }
            catch
            {
                tag.Text = "操作失败，请重试！";
            }
        }

        /// <summary>
        /// 重置按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_chongzhi_Click(object sender, EventArgs e)
        {
            //用户名
            TB_USERNAME.Text = "";
            //密码
            TB_PASSWORD.Text = "";
            //姓名
            TB_REALNAME.Text = "";
            //联系电话
            TB_TEL.Text = "";
            //移动电话
            TextBox_TEMP1.Text = "";
            //邮箱
            TB_EMAIL.Text = "";
            //入职时间
            TB_DatesEmployed.Value = "";
            //离职时间
            TB_LeaveDates.Value = "";
            //生日
            TB_BIRTHDAY.Value = "";
            //籍贯
            TB_NativePlace.Text = "";
            //住址
            TB_ADDRESS.Text = "";
            //毕业学校
            TB_GraduateSchool.Text = "";
            //专业
            TB_Major.Text = "";
            //工作履历
            TB_TrackRecord.Text = "";

        }
    }
}
