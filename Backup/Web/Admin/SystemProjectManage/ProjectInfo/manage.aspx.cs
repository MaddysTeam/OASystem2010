using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace Dianda.Web.Admin.SystemProjectManage.ProjectInfo
{
    public partial class manage : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.BLL.Project_Projects projects_bll = new Dianda.BLL.Project_Projects();
        Dianda.Model.Project_Projects projects_model = new Dianda.Model.Project_Projects();
        Model.userPower mUserPower = new Dianda.Model.userPower();//用户的权限实体类

        Hashtable Project_Cash_Cards_ht = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                 mUserPower = (Model.userPower)Session["Session_Power"];
                 JudgeMenu(mUserPower.menuRole.ToString());//判断列表显示
                 
            }
            catch
            {
            }

            if (!IsPostBack)
            {

                string pageindex = null;//这里是为分页服务的

                pageindex = Request["pageindex"];


                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    setRowCout("","","","","");//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
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

                ShowListInfo(pageindex_int,"","","","","");

            }

            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 ";
            //设置模板页中的管理值
        }

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        /// <param name="projectname">项目名称</param>
        /// <param name="leadername">项目负责人</param>
        /// <param name="depart">部门</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        private void setRowCout(string projectname,string leadername,string depart,string starttime,string endtime)
        {
            try
            {
                DataTable DT = new DataTable();
                string sql = "SELECT * FROM vProject_Projects WHERE  (Status=1 or Status=3 or Status=5) and DELFLAG = 0 ";
                
                //项目名称
                if (null != projectname && !projectname.Equals(""))
                {
                    sql = sql + " AND NAMES LIKE '%" + projectname + "%' ";
                }

                //项目负责人
                if (null != leadername && !leadername.Equals(""))
                {
                    sql = sql + " AND ( LeaderRealName LIKE '%" + leadername + "%' OR LeaderUserName LIKE '%" + leadername + "%')";
                }

                //参与部门
                if (null != depart && !depart.Equals(""))
                {
                    sql = sql + " AND DepartmentNames LIKE '%" + depart + "%' ";
                }

                //开始时间
                if (null != starttime && !starttime.Equals(""))
                {
                    sql = sql + " AND StartTime >='" + Convert.ToDateTime(starttime)+"'";
                }

                //结束时间
                if (null != endtime && !endtime.Equals(""))
                {
                    sql = sql + " AND EndTime <='" + Convert.ToDateTime(endtime)+"'";
                }

                DT = pageControl.doSql(sql).Tables[0];

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
            if (HF_search.Value.ToString().Equals("true"))
            {
                //项目名称
                string projectname = TB_name.Text.ToString();
                //项目负责人
                string leadername = TB_leader.Text.ToString();
                //参与部门
                string depart = TB_depart.Text.ToString();
                //开始时间
                string starttime = TB_starttime.Value.ToString();
                //结束时间
                string endtime = TB_endtime.Value.ToString();

                setRowCout(projectname, leadername, depart, starttime, endtime);
                ShowListInfo(page, projectname, leadername, depart, starttime, endtime);

            }
            else
            {
                setRowCout("", "", "", "", "");
                ShowListInfo(page, "", "", "", "", "");//调用显示
            }

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

            if (HF_search.Value.ToString().Equals("true"))
            {
                //项目名称
                string projectname = TB_name.Text.ToString();
                //项目负责人
                string leadername = TB_leader.Text.ToString();
                //参与部门
                string depart = TB_depart.Text.ToString();
                //开始时间
                string starttime = TB_starttime.Value.ToString();
                //结束时间
                string endtime = TB_endtime.Value.ToString();

                setRowCout(projectname, leadername, depart, starttime, endtime);
                ShowListInfo(page, projectname, leadername, depart, starttime, endtime);

            }
            else
            {
                setRowCout("", "", "", "", "");
                ShowListInfo(page, "", "", "", "", "");//调用显示
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
                        cb.Checked = isCheck;
                    }
                }

            }
            catch
            {
            }
        }

        //添加一个资金卡表
        public void get_Cash_Cards()
        {
            if (Session["Project_Cash_Cards"] == null)
            {
                string sql = "SELECT ID, CardNum, CardName, ProjectID FROM Cash_Cards where statas=1 and projectid is not null";

                DataTable dt =  pageControl.doSql(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //创建哈希表
                    Hashtable Cash_Cards = new Hashtable();
                    //循环dt表
                    foreach (DataRow _row in dt.Rows)
                    {
                        string _ProjectID = _row["ProjectID"].ToString();
                        string _CardName = _row["CardName"].ToString();
                        //查找哈希表中是否存在这个ProjectID，存在的话修改，不存在的话添加
                        if (!Cash_Cards.Contains(_ProjectID))
                        {
                            Cash_Cards.Add(_ProjectID, _CardName);
                        }
                        else
                        {
                            //重新赋值
                            string _str = (string)Cash_Cards[_ProjectID]+","+_CardName;
                            Cash_Cards.Remove(_ProjectID);
                            Cash_Cards.Add(_ProjectID, _str);

                        }
                    }
                    Session["Project_Cash_Cards"] = Cash_Cards;
                    Project_Cash_Cards_ht = Cash_Cards;
                }
            }
            else
            {
                Project_Cash_Cards_ht = (Hashtable)Session["Project_Cash_Cards"];
            }
        }

        /// <summary>
        /// 显示项目的列表信息
        /// </summary>
        /// <param name="pageindex">页码</param>
        /// <param name="projectname">项目名称</param>
        /// <param name="leadername">项目负责人</param>
        /// <param name="depart">参与部门</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">对束时间</param>
        protected void ShowListInfo(int pageindex, string projectname, string leadername, string depart, string starttime, string endtime)
        {
            try
            {
                get_Cash_Cards();

                DataTable DT = new DataTable();
                string sqlWhere1 = " (Status=1 or Status=3 or Status=5) and DELFLAG = 0 ";

                //项目名称
                if (null != projectname && !projectname.Equals(""))
                {
                    sqlWhere1 = sqlWhere1 + " AND NAMES LIKE '%" + projectname + "%' ";
                }

                //项目负责人
                if (null != leadername && !leadername.Equals(""))
                {
                    sqlWhere1 = sqlWhere1 + " AND ( LeaderRealName LIKE '%" + leadername + "%' OR LeaderUserName LIKE '%" + leadername + "%' )";
                }

                //参与部门
                if (null != depart && !depart.Equals(""))
                {
                    sqlWhere1 = sqlWhere1 + " AND DepartmentNames LIKE '%" + depart + "%' ";
                }

                //开始时间
                if (null != starttime && !starttime.Equals(""))
                {
                    sqlWhere1 = sqlWhere1 + " AND StartTime >='" + Convert.ToDateTime(starttime)+"'";
                }

                //结束时间
                if (null != endtime && !endtime.Equals(""))
                {
                    sqlWhere1 = sqlWhere1 + " AND EndTime <='" + Convert.ToDateTime(endtime)+"'";
                }

                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                DT = pageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "vProject_Projects", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中

                    GridView1.Visible = true;
                    GridView1.DataSource = DT;//指定GridView1的数据是DT
                    pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    Button_modify.Enabled = true;
                    Button_delete.Enabled = true;
                    Button_projectsearch.Enabled = true;
                    tag.Text = "";

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    notice.Text = "";
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    Button_modify.Enabled = false;
                    Button_delete.Enabled = false;
                    Button_projectsearch.Enabled = false;
                    if (alltiaoshuInt > 0)
                    {
                        ShowListInfo(pageindex - 1, projectname, leadername, depart, starttime, endtime);
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
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    //项目的ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;

                    //项目名称
                    string names = DataBinder.Eval(e.Row.DataItem, "names").ToString();

                    //附件地址
                    string Attachments = DataBinder.Eval(e.Row.DataItem, "Attachments").ToString();

                    //项目的类型：0表示临时项目；1表示正常项目 
                    string ProjectType = DataBinder.Eval(e.Row.DataItem, "ProjectType").ToString();
                    string typenames = "";
                    if (ProjectType == "0")
                    {
                        typenames = "临时项目";
                    }
                    else
                    {
                        typenames = "普通项目";
                    }


                    if (null != Attachments && !Attachments.Equals(""))
                    {
                        // e.Row.Cells[1].Text = "<table><tr><td width='16' align='center'><img src='/Admin/images/OAimages/fj.jpg' border='0'></td><td align='left'><a href='show.aspx?ID=" + ID + "' target='_self' rel='gb_page_center[726,400]' title='项目详细信息''>" + names + "</a></td></tr></table>";
                        e.Row.Cells[1].Text = "<table><tr><td width='16' align='center'><img src='/Admin/images/OAimages/fj.jpg' border='0'></td><td align='left'><a href='#' Url='show.aspx?ID=" + ID + "'  onclick='funOpen(this)'  title='项目详细信息:" + typenames + "''>" + names + "</a></td></tr></table>";
                        // Url="Course/ShowPageCourse.aspx?ID=<%# Eval("ID") %>" title='查看详细' onclick="funOpen(this)" 
                    }
                    else
                    {
                        e.Row.Cells[1].Text = "<table><tr><td width='13'></td><td align='left'><a href='#' Url='show.aspx?ID=" + ID + "'  onclick='funOpen(this)'  title='项目详细信息:" + typenames + "''>" + names + "</a></td></tr></table>";

                    }

                    //项目状态
                    string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                    switch (status)
                    {
                        case "1":
                            e.Row.Cells[8].Text = "正常运行中";
                            break;
                        case "3":
                            e.Row.Cells[8].Text = "暂停";
                            break;
                        case "5":
                            e.Row.Cells[8].Text = "已完成";
                            break;
                    }

                    //立项申请人用户名
                    string SendUserUserName = DataBinder.Eval(e.Row.DataItem, "SendUserUserName").ToString();
                    //立项申请人真实姓名
                    string SendUserRealName = DataBinder.Eval(e.Row.DataItem, "SendUserRealName").ToString();
                    //立项申请人
                    e.Row.Cells[2].Text = SendUserRealName + "[" + SendUserUserName + "]";

                    //项目负责人用户名
                    string LeaderUserName = DataBinder.Eval(e.Row.DataItem, "LeaderUserName").ToString();
                    //项目负责人真实姓名
                    string LeaderRealName = DataBinder.Eval(e.Row.DataItem, "LeaderRealName").ToString();
                    //项目负责人
                    e.Row.Cells[3].Text = LeaderRealName + "[" + LeaderUserName + "]";

                    //开始时间
                    string StartTime = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StartTime").ToString()).ToString("yyyy-MM-dd");
                    //结束时间
                    string EndTime = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "EndTime").ToString()).ToString("yyyy-MM-dd");
                    e.Row.Cells[6].Text = StartTime + "</br>" + EndTime;

                    //项目资金卡
                    string MessageStr = "";
                    if (Project_Cash_Cards_ht.Contains(ID))
                    {
                        MessageStr = (string)Project_Cash_Cards_ht[ID];
                    }
                    else
                    {
                        MessageStr = "新建资金卡";
                    }
                    e.Row.Cells[5].Text = "<a  href='#' title='[资金卡情况]：" + MessageStr + "'>资金卡详细</a>";
                    //string CardName = DataBinder.Eval(e.Row.DataItem, "CardName").ToString();

                    //e.Row.Cells[7].Text = CardName.Equals("") ? "新建资金卡" : CardName;


                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 点击项目搜索按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_projectsearch_onclick(object sender, EventArgs e)
        {
            search.Visible = true;
            HF_search.Value = "true";

        }

        /// <summary>
        /// 点击项目搜索按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_close_onclick(object sender, EventArgs e)
        {
            search.Visible = false;
            HF_search.Value = "false";

        }

        /// <summary>
        /// 点击搜索按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_search_onclick(object sender, EventArgs e)
        {
            try
            {
                //项目名称
                string projectname = TB_name.Text.ToString();
                //项目负责人
                string leadername = TB_leader.Text.ToString();
                //参与部门
                string depart = TB_depart.Text.ToString();
                //开始时间
                string starttime = TB_starttime.Value.ToString();
                //结束时间
                string endtime = TB_endtime.Value.ToString();

                setRowCout(projectname,leadername,depart,starttime,endtime);
                ShowListInfo(1, projectname, leadername, depart, starttime, endtime);
            }
            catch
            {

            }
        }
        /// <summary>
        /// 点击返回全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_viewall_onclick(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx");
        }


        /// <summary>
        /// 点击编辑按钮触发的事件
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

                    if (HF_search.Value.ToString().Equals("true"))
                    {
                        search.Visible = true;
                    }
                    else
                    {
                        search.Visible = false;
                    }

                }
                else if (num > 1)
                {
                    tag.Text = "编辑时最多只能选择一条数据！";

                    if (HF_search.Equals("true"))
                    {
                        search.Visible = true;
                    }
                    else
                    {
                        search.Visible = false;
                    }

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
                            Response.Redirect("modify.aspx?ID=" + hid.Value.ToString() + "&pageindex=" + pageindexHidden.Value.ToString());
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

                    if (HF_search.Value.ToString().Equals("true"))
                    {
                        search.Visible = true;
                    }
                    else
                    {
                        search.Visible = false;
                    }

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
                            //获取到当前项目的基本信息
                            projects_model = projects_bll.GetModel(int.Parse(hid.Value.ToString()));
                            //将删除标记设为1
                            projects_model.DELFLAG = 1;

                            projects_bll.Update(projects_model);


                            //同时删除faceshowmessage中的projectid = ID,的数据，同时置DELFLAG=1;

                            Dianda.BLL.Project_ProjectsExt projectsExt = new Dianda.BLL.Project_ProjectsExt();

                            string sqlwhere = " ProjectID = '" + hid.Value.ToString() + "'";

                            projectsExt.DeleteTableData(sqlwhere, "FaceShowMessage");

                            //添加操作日志

                            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "系统项目管理", "删除" + projects_model.NAMES+ "项目成功");

                            //添加操作日志
                        }
                    }

                    //tag.Text = "操作成功！";

                    //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"]  + "\";</script>";
                    //Response.Write(coutws);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入我的项目页面');javascript:location='manage.aspx?pageindex=" + pageindexHidden.Value.ToString() + "';</script>", false);
                }

            }

        }
                /// <summary>
        /// 判断才菜单的权限
        /// </summary>
        /// <param name="menusession"></param>
        private void JudgeMenu(string menusession)
        {
            try
            {
                if (menusession.Length > 0)
                {
                    string[] menuarray = menusession.Split(';');
                    for (int i = 0; i < menuarray.Length; i++)
                    {
                        string menuName = menuarray[i].ToString();
                        
                        if (menuName == "menu_ProjectList")//项目信息列表的权限
                        {
                            showProject.Visible = true;
                            noProject.Visible = false;
                        }
                        
                    }

                }
            }
            catch
            {
            }
        }
      

    }
}
