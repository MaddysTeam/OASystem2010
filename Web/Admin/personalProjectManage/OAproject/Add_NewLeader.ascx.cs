using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Dianda.Web.Admin.personalProjectManage.OAproject
{
    public partial class Add_NewLeader : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.Model.USER_Users users_Model = new Dianda.Model.USER_Users();
        Dianda.BLL.USER_Users users_Bll = new Dianda.BLL.USER_Users();
        Dianda.COMMON.common commons = new Dianda.COMMON.common();

        Dianda.BLL.Document_Folder docfolder_bll = new Dianda.BLL.Document_Folder();
        Dianda.Model.Document_Folder docfolder_model = new Dianda.Model.Document_Folder();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 确定添加新建项目负责人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = TextBox_UserName.Text.ToString();//获取到用户名

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
                        users_Model.ID = commons.GetGUID();//获取到GUID作为ID
                        Session["new_leaderid"] = users_Model.ID;
                        //用户名
                        users_Model.USERNAME = TextBox_UserName.Text.ToString();
                        //密码
                        users_Model.PASSWORD = commons.GetMD5(TextBox_Pwd.Text.Trim());
                        //真实姓名
                        users_Model.REALNAME = TextBox_Rlname.Text;
                        //性别
                        users_Model.SEX = RadioButtonList_Sex.SelectedValue.ToString();
                        //是否为项目经理
                        users_Model.IsManager = 9;                    
                        //部门                   
                        users_Model.DepartMentID = ConfigurationManager.AppSettings["departmentid_temp"];
                        //部门名称
                        string sql_groups = "SELECT ID,name FROM USER_Groups WHERE id='" + ConfigurationManager.AppSettings["departmentid_temp"] + "'";
                        DataTable dt = pageControl.doSql(sql_groups).Tables[0];
                        users_Model.DepartMentName = dt.Rows[0]["name"].ToString();
                        //岗位
                        users_Model.StationID = ConfigurationManager.AppSettings["positionid_temp"];
                        //联系电话
                        users_Model.TEL = "";
                        //移动电话
                        users_Model.TEMP1 = "";
                        //邮箱
                        users_Model.EMAIL = "text@126.com";
                        //在职状态
                        users_Model.WorkStats = "1";
                        //籍贯
                        users_Model.NativePlace = "上海";
                        //学历
                        users_Model.EducationLevel = "4";                     
                        //时间
                        users_Model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
                        //工作组                       
                        users_Model.GROUPS = ConfigurationManager.AppSettings["manageid_temp"];
                        //删除标记
                        users_Model.DELFLAG = 0;
                        users_Bll.Add(users_Model);
                        tag.Text = "操作成功！";                       

                        //添加操作日志
                        Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                        Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                        bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加人员信息", "添加" + users_Model.REALNAME + "(" + user_model.USERNAME + ")" + "成功");
                        
                        Label la = (Label)this.Parent.Parent.FindControl("Label_NewLeader");
                        la.Text ="--["+ TextBox_Rlname.Text + "(" + TextBox_UserName.Text + ")]";
                       
                    }
                }
            }
            catch
            {
                tag.Text = "操作失败，请重试！";
            }
        }
        //返回
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;         
        }
    }
}