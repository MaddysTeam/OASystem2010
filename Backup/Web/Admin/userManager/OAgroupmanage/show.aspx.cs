using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.userManager.OAgroupmanage
{
    public partial class show : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.Model.USER_Users users_Model = new Dianda.Model.USER_Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Response.Buffer = true;
                //Response.Expires = 0;
                string userid = Request["userid"].ToString();
                //显示人员的详细信息
                ShowUserInfo(userid);
            }
        }

        /// <summary>
        /// 显示人员的详细信息
        /// </summary>
        /// <param name="userid"></param>
        protected void ShowUserInfo(string userid)
        {
            try
            {
                string sql = "SELECT * FROM vUSER_Users WHERE ID = '" + userid + "'";//vUSER_Users为一个视图

                DataTable DT = new DataTable();

                DT = pageControl.doSql(sql).Tables[0];
                //姓名
                Label_Name.Text = DT.Rows[0]["REALNAME"].ToString();
                //性别
                Label_SEX.Text = DT.Rows[0]["SEX"].ToString();
                //部门
                Label_DEPARTMENT.Text = DT.Rows[0]["DepartMentName"].ToString();
                //岗位
                Label_Station.Text = DT.Rows[0]["StationName"].ToString();
                //联系电话
                Label_TEL.Text = DT.Rows[0]["TEL"].ToString();
                //移动电话
                Label_Temp1.Text = DT.Rows[0]["TEMP1"].ToString();
                //邮箱
                Label_EMAIL.Text = DT.Rows[0]["EMAIL"].ToString();
                //状态
                string WorkSatatName = "";

                switch (DT.Rows[0]["WorkStats"].ToString())
                {
                    case "1":
                        WorkSatatName = "在职";
                        break;
                    case "2":
                        WorkSatatName = "离职";
                        break;
                    case "3":
                        WorkSatatName = "停职";
                        break;
                    case "4":
                        WorkSatatName = "休假";
                        break;
                    case "5":
                        WorkSatatName = "其他";
                        break;
                }

                Label_WorkStats.Text = WorkSatatName;
                //入职时间
                Label_DatesEmployed.Text = Convert.ToDateTime(DT.Rows[0]["DatesEmployed"].ToString()).ToString("yyyy-MM-dd");
                if (null == DT.Rows[0]["LeaveDates"] || DT.Rows[0]["LeaveDates"].ToString().Equals(""))
                {
                    Label_LeaveDates.Text = "";
                }else
                {
                    //离职时间
                    Label_LeaveDates.Text = Convert.ToDateTime(DT.Rows[0]["LeaveDates"].ToString()).ToString("yyyy-MM-dd");
                }
                //生日
                Label_BIRTHDAY.Text = Convert.ToDateTime(DT.Rows[0]["BIRTHDAY"].ToString()).ToString("yyyy-MM-dd");
                //籍贯
                Label_NativePlace.Text = DT.Rows[0]["NativePlace"].ToString();
                //学历
                Label_EducationLevel.Text = DT.Rows[0]["EducationLevel"].ToString();
                //毕业学校
                Label_GraduateSchool.Text = DT.Rows[0]["GraduateSchool"].ToString();
                //专业
                Label_Major.Text = DT.Rows[0]["Major"].ToString();
                //工作履历
                Label_TrackRecord.Text = DT.Rows[0]["TrackRecord"].ToString();
            }
            catch
            { }
        }
    }
}
