using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.presonPlan
{
    public partial class moban : System.Web.UI.Page
    {
        Dianda.BLL.Personal_Notepad notepadBll = new Dianda.BLL.Personal_Notepad();
        Dianda.BLL.Personal_Plan PlanPersonalBll = new Dianda.BLL.Personal_Plan();
        Dianda.BLL.Project_Task TaskBll = new Dianda.BLL.Project_Task();
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
            try
            {
                if (!IsPostBack)
                {
                    //获得项目ID
                    Session["Work_ProjectId"] = "10";
                    Session["User_users"] = "1";
                    SelectList(Session["User_users"].ToString());
                    ClassProject(Session["Work_ProjectId"].ToString());
                    PersonProjectShow(Session["User_users"].ToString());
                    
                }
                string Name = "新增个人计划";
                Label_AddPersonProject.Text = "<a href=\"javascript:window.showModalDialog('add.aspx','','dialogWidth=715px;dialogHeight=250px');\">" + Name + "</a>";

                string strName = "新增便签条";
                Label_AddNote.Text = "<a href=\"javascript:window.showModalDialog('addNote.aspx','','dialogWidth=715px;dialogHeight=250px');\">" + strName + "</a>";

                string strMost = "更多便签详情...";
                Label_best.Text = "<a href=\"javascript:window.showModalDialog('NoteDetail.aspx','','dialogWidth=715px;dialogHeight=250px');\">" + strMost + "</a>";
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 查询所有的新建便签
        /// </summary>
        private void SelectList(string NoteId)
        {
            DataTable dt = new DataTable();

            dt = notepadBll.GetList(5, "delflag = '0' and id='" + NoteId + "'", "DATETIME DESC").Tables[0];
            if (dt != null)
            {
                GridVie_NoteDetial.DataSource = dt;
                GridVie_NoteDetial.DataBind();
            }
            else
            { 
              
            }
        }


        ///<summary>
        ///查询部门任务
        ///</summary>
        private void ClassProject(string ProjectId)
        {
               
            DataTable dt = new DataTable();
            //通过ID查询部门状态是0并且不等于21
            dt = TaskBll.GetList(5, "delflag='0' and Status <>  2  and id='" + ProjectId + "'", "StartTime asc").Tables[0];
            GridView_ClassProject.DataSource = dt;
            GridView_ClassProject.DataBind();
        }

        /// <summary>
        /// 查询出个人任务
        /// </summary>
        private void PersonProjectShow(string PersonId)
        {
            DataTable dt = new DataTable();
            //通过ID查询出状态是0并且不等于的2
            dt = PlanPersonalBll.GetList(5, "Delflag = '0' and Status <> 2 and  id = '" + PersonId + "'", "StartTime asc").Tables[0];
            GridView_PresonProject.DataSource = dt;
            GridView_PresonProject.DataBind();
        }


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            //获得传进来的用户ID
            string strId = Session["User_users"].ToString();
            DataTable dt = new DataTable();
            //获得选中的时间
            string strdateTime = Calendar1.SelectedDate.ToString();
            //通过ID获得用户在这个时间内的任务
            string strsql = "select top 5 * from Personal_plan where '" + strdateTime + "' between StartTime and endTime and delflag ='0' and Status <> 2 and UserId = '" + strId + "' order by StartTime asc ";
            dt = pageControl.doSql(strsql).Tables[0];
            GridView_PresonProject.DataSource = dt;
            GridView_PresonProject.DataBind();
        }
    }
}