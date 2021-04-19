using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Dianda.Web.Admin.presonPlan.OApresonmanage
{
    public partial class Test : System.Web.UI.Page
    {
        Model.Personal_Notepad mNotepad = new Dianda.Model.Personal_Notepad();
        BLL.Personal_Notepad bNotepad = new Dianda.BLL.Personal_Notepad();
        Model.Personal_Plan mPlan = new Dianda.Model.Personal_Plan();
        BLL.Personal_Plan bPlan = new Dianda.BLL.Personal_Plan();
        BLL.Project_Task bTask = new Dianda.BLL.Project_Task();
        Model.USER_Users userModel = new Dianda.Model.USER_Users();
        BLL.USER_Users usersBll = new Dianda.BLL.USER_Users();

        COMMON.common commons = new Dianda.COMMON.common();
        COMMON.pageControl pagedosql = new Dianda.COMMON.pageControl();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    if (Session["isDepartment"] != null)
                    {
                        if (Session["isDepartment"].ToString() == "部门")
                        {
                           // this.divNote.Visible = false;
                        }
                        else
                        {
                           // this.divNote.Visible = true;
                        }
                    }
                    //当在部门首页时
                    if (Session["index_pages"] == null)
                    {
                        TabContainer.ActiveTabIndex = 0;
                        TabPanel_PersonProject.Visible = true;
                    }
                    else
                    {
                        TabContainer.ActiveTabIndex = 1;
                        TabPanel_PersonProject.Visible = false;
                    }
                    //开始被隐藏起来的那个下拉菜单的数据
                    showyear();//显示年份
                    DateTime dtime = DateTime.Now;
                    int year = dtime.Year;
                    int months = dtime.Month;
                    DropDownList_year.SelectedValue = year.ToString();
                    DropDownList_month.SelectedValue = months.ToString();
                    //显示年份和月份

                    show(System.DateTime.Now.Date);//显示当前日期的数据
                    //ShowFriendlyLink();

                }
           
                //string Name = "新增个人计划";
                Label_addProject.Text = "<a href='add.aspx' target='_self' ><img src='/Admin/images/OAimages/ico_add.jpg'></a>";

                string strMost = "更多";
                //label_most.Text = "<a href ='NoteDetail.aspx' target='_self'  class='right_a'>" + strMost + "</a>";

                //string strAddNote = "新增标签";
                //Label_addNote.Text = "<a href ='addNote.aspx' target='_self' ><img src='/Admin/images/OAimages/ico_add.jpg'></a>";
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 显示友情链接
        /// </summary>
        //protected void ShowFriendlyLink()
        //{
        //    try
        //    {
        //        string sql = " SELECT * FROM Friendly_Link where DELFLAG=0 ";
        //        DataTable DT = new DataTable();

        //        DT = pagedosql.doSql(sql).Tables[0];

        //        if (DT.Rows.Count>0)
        //        {
        //            GridVie_FriendlyLink.Visible = true;
        //            GridVie_FriendlyLink.DataSource = DT;
        //            GridVie_FriendlyLink.DataBind();

        //        }else
        //        {
        //            GridVie_FriendlyLink.Visible = false;
        //        }
        //    }
        //    catch
        //    {
 
        //    }
        //}

        protected void GridVie_FriendlyLink_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //连接名称
                string Name = DataBinder.Eval(e.Row.DataItem, "Name").ToString();
                //连接地址
                string Link = DataBinder.Eval(e.Row.DataItem, "Link").ToString();

                Label lb = (Label)e.Row.FindControl("LB_links");
                lb.Text = "<a href='" + Link + "' target='_blank' style= 'text-decoration:none;color:White;'>" + Name + "</a>";
            }
            catch
            { }
        }
        /// <summary>
        ///  //切换到下个月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton_nextMouth_Click(object sender, ImageClickEventArgs e)
        {
            //切换到下个月
            try
            {
                DateTime nowss = Convert.ToDateTime(H_time.Value.ToString()).AddMonths(1);
                show(nowss);

            }
            catch
            {
            }
        }
        /// <summary>
        ///  //切换到上个月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton_preMouth_Click(object sender, ImageClickEventArgs e)
        {
            //切换到上个月
            try
            {
                DateTime nowss = Convert.ToDateTime(H_time.Value.ToString()).AddMonths(-1);
                show(nowss);

            }
            catch
            {
            }
        }
        /// <summary>
        /// 显示当前天的信息
        /// </summary>
        /// <param name="todayss"></param>
        private void show(DateTime todayss)
        {
            try
            {
                DateTime todays = todayss;// System.DateTime.Now.Date;
                Label_now.Text =commons.makeDateToDateAndWeek(todayss.ToString());
                Calendar1.VisibleDate = todays;
                Calendar1.SelectedDate = System.DateTime.Now.Date;
                setZhouci(todayss.ToString());

                string nextMoth = todays.AddMonths(1).Year.ToString() + "年" + "-" + todays.AddMonths(1).Month.ToString() + "月";
                string preMoth = todays.AddMonths(-1).Year.ToString() + "年" + "-" + todays.AddMonths(-1).Month.ToString() + "月";
                ImageButton_left.AlternateText = "切换到" + preMoth;
                ImageButton_right.AlternateText = "切换到" + nextMoth;
                string thedays = todays.Year.ToString() + "-" + todays.Month.ToString() + "-" + todays.Day.ToString();
                H_time.Value = todayss.ToString();

                userModel = (Dianda.Model.USER_Users)Session["USER_Users"];
                string userid = userModel.ID;
                string strDateTime = DateTime.Now.ToString();
                //ShowNote(userid);
                ShowPersonProject(userid, thedays);
                ShowClassProject(userModel.REALNAME, userModel.USERNAME, thedays);
                 
            }
            catch
            {
            }
        }

        /// <summary>
        /// 显示年的列表
        /// </summary>
        private void showyear()
        {
            try
            {
                DateTime dtime = DateTime.Now;
                int year = dtime.Year;
                DropDownList_year.Items.Clear();
                for (int i = year - 5; i < year + 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = i.ToString() + "年";
                    li.Value = i.ToString();
                    DropDownList_year.Items.Add(li);
                }
            }
            catch
            {
            }
        }

        ///// <summary>
        ///// 查看自己的便签条
        ///// </summary>
        ///// <param name="strId"></param>
        //protected void ShowNote(string strId)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();

        //        dt = bNotepad.GetList(2, "delflag = '0' and UserId='" + strId + "'", "ID DESC").Tables[0];
        //        if (dt != null)
        //        {
        //            GridVie_NoteDetial.DataSource = dt;
        //            GridVie_NoteDetial.DataBind();
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        /// <summary>
        /// 通过ID获得自己个人计划
        /// </summary>
        /// <param name="PersonId"></param>
        protected void ShowPersonProject(string PersonId, string strDateTime)
        {
            try
            {
                DataTable dt = new DataTable();
                //通过ID查询出状态是0并且不等于的2
                string strDateTimeStart =DateTime.Parse(strDateTime).ToString("yyyy-MM-dd") + " 23:59:00";
                string strDateTimeEnd = DateTime.Parse(strDateTime).ToString("yyyy-MM-dd") + " 00:00:00";
                dt = bPlan.GetList(5, "Delflag = '0' and Status <> 2 and  UserID = '" + PersonId + "' and '" + strDateTimeStart + "' > StartTime and '" + strDateTimeEnd + "'< endTime", "StartTime asc").Tables[0];
                if (dt != null)
                {
                    GridView_PresonProject.DataSource = dt;
                    GridView_PresonProject.DataBind();
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 获取当前用户在选定的月份中的个人计划列表
        /// </summary>
        /// <param name="PersonId"></param>
        protected void ShowPersonProject_month(string PersonId, string months)
        {
            try
            {
                DataTable dt = new DataTable();
                DateTime selectTime = DateTime.Parse(months);
                DateTime nexttime = selectTime.AddMonths(1);

                //通过ID查询出状态是0并且不等于的2
                dt = bPlan.GetList("Delflag = '0' and Status <> 2 and  UserID = '" + PersonId + "' and  StartTime>'" + selectTime.ToString() + "' and  endTime<'" + nexttime.ToString() + "'  order by StartTime asc").Tables[0];
                if (dt != null)
                {
                    GridView_PresonProject.DataSource = dt;
                    GridView_PresonProject.DataBind();
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 获取当前用户在选定的月份中的部门任务列表
        /// </summary>
        /// <param name="strRealName"></param>
        /// <param name="strUserName"></param>
        /// <param name="strDateTime"></param>
        protected void ShowClassProject_month(string strRealName, string strUserName, string months)
        {
            try
            {
                DataTable dt = new DataTable();
                DateTime selectTime = DateTime.Parse(months);
                DateTime nexttime = selectTime.AddMonths(1);

                string strsql = "select top 5 * from vProject_Task where Pro_DELFLAG='0' and Pro_Status=1 and  StartTime>'" + selectTime.ToString() + "' and  endTime<'" + nexttime.ToString() + "'  and delflag = '0' and Status <> 2 and userInfo Like '%" + strRealName + "(" + strUserName + ")" + "%' order by StartTime asc";
                dt = pagedosql.doSql(strsql).Tables[0];

                if (dt != null)
                {
                    GridView_ClassProject.DataSource = dt;
                    GridView_ClassProject.DataBind();
                }
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// 显示部门任务
        /// </summary>
        /// <param name="strRealName"></param>
        /// <param name="strUserName"></param>
        /// <param name="strDateTime"></param>
        protected void ShowClassProject(string strRealName, string strUserName, string strDateTime)
        {
            try
            {
                DataTable dt = new DataTable();
                string strsql = "select top 5 * from vProject_Task where Pro_DELFLAG='0' and Pro_Status=1 and '" + strDateTime + "' between StartTime and endTime and delflag = '0' and Status <> 2 and userInfo Like '%" + strRealName + "(" + strUserName + ")" + "%' order by StartTime asc";
                dt = pagedosql.doSql(strsql).Tables[0];

                if (dt != null)
                {
                    GridView_ClassProject.DataSource = dt;
                    GridView_ClassProject.DataBind();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 点击时发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                
                Dianda.Model.USER_Users userModel = (Dianda.Model.USER_Users)Session["USER_Users"];
                string strId = userModel.ID;
                string strDateTime = Calendar1.SelectedDate.ToString();
                string strRalName = userModel.REALNAME.ToString();
                string strUserName = userModel.USERNAME.ToString();
                
                ShowPersonProject(strId, strDateTime);
                ShowClassProject(strRalName, strUserName, strDateTime);
                Calendar1.SelectedDayStyle.Font.Bold = true;//.CssClass = "todayCell_yes";
            }
            catch (Exception)
            {
            }


        }
        /// <summary>
        /// 处理每天的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            //1--无状态、2--无状态并选中、3--个人计划未选中、4--个人计划并选中、5--项目计划未选中、6--项目计划并选中
            //7--个人计划和项目计划未选中、8--个人计划和项目计划并选中、9无状态的当天、10--个人计划的当天、11--项目计划的当天、12--个人计划和项目计划的当天
            if (e.Day.IsOtherMonth)
            {
                e.Cell.Controls.Clear();
            }
            else
            {
                int coutw = isRenwu(e.Day.Date.ToString(), e.Day.IsToday, e.Day.IsSelected);
                string cssname = "dayCell_" + coutw.ToString();
                e.Cell.CssClass = cssname;
            }
        }

        /// <summary>
        /// 显示对应的周次
        /// </summary>
        /// <param name="selectDay"></param>
        private void setZhouci(string selectDay)
        {
            try
            {
                string selectday = selectDay;// Calendar1.SelectedDate.ToString();
                string coutw = coutZhouci(selectday);
                string[] coutwarray = coutw.Split(',');
                int trNum = coutwarray.Length;
                string coutTr = "<table  cellpadding=\"0\" cellspacing=\"0\" bgcolor='#114880'>";
                for (int j = 0; j < trNum; j++)
                {
                    if (coutwarray[j].ToString() != "" && coutwarray[j].ToString() != null)
                    {
                        coutTr = coutTr + "<tr><td class='weekbak'  align='center'>" + coutwarray[j].ToString() + "</td></tr>";
                    }
                }
                coutTr = coutTr + "</table>";
                Label_coutzhouci.Text = coutTr;
            }
            catch
            {
                Label_coutzhouci.Text = "<table><tr><td>&nbsp;</td></tr></table>";
            }
        }

        /// <summary>
        /// 根据当前的选择时间，输出用","隔开的周次字符串
        /// </summary>
        /// <param name="selectDay"></param>
        /// <returns></returns>
        public string coutZhouci(string selectDay)
        {
            string coutzhoucistring = "";
            string coutw = getZhouciArray(selectDay);
            string[] coutwa = coutw.Split(',');
            string t1 = "";

            for (int i = 0; i < coutwa.Length; i++)
            {
                if (i < coutwa.Length - 1)
                {
                    if (coutwa[i].ToString() == coutwa[i + 1].ToString())
                    {
                        t1 = t1;
                    }
                    else
                    {
                        t1 = t1 + coutwa[i].ToString() + ",";
                    }
                }
                else
                {
                    if (coutwa[i].ToString() == coutwa[i - 1].ToString())
                    {
                        t1 = t1;
                    }
                    else
                    {
                        t1 = t1 + coutwa[i].ToString() + ",";
                    }
                }

            }
            string[] t2 = t1.Split(',');

            for (int j = 0; j < t2.Length; j++)
            {

                if (t2[j].ToString() != "" && t2[j].ToString() != null)
                {
                    if (t2[j].ToString().Contains("放假"))
                    {
                        coutzhoucistring = coutzhoucistring + "放假,";
                    }
                    else
                    {
                        coutzhoucistring = coutzhoucistring + t2[j].ToString() + ",";
                    }
                }

            }
            string sql_right = coutzhoucistring.Substring(coutzhoucistring.Length - 1, 1);
            string sql_left = coutzhoucistring.Substring(0, 1);
            if (sql_left == ",")
            {
                coutzhoucistring = coutzhoucistring.Substring(1, coutzhoucistring.Length - 1);//把第一个，给切割掉
            }
            if (sql_right == ",")
            {
                coutzhoucistring = coutzhoucistring.Substring(0, coutzhoucistring.Length - 1);//把最后一个，给切割掉
            }
            return coutzhoucistring;
        }


        /// <summary>
        /// 根据当前的选择的时间，返回由“，”隔开的周次字符串
        /// </summary>
        /// <param name="selectDay"></param>
        /// <returns></returns>
        public string getZhouciArray(string selectDay)
        {
            string coutw = "";
            try
            {
                string[] firstlashcontent = getFirt_LastWeek();//获取当前的学期的开始时间和结束时间，以及学期介绍

                DateTime dtselect = Convert.ToDateTime(selectDay);
                string yearss = dtselect.Year.ToString();
                string months = dtselect.Month.ToString();
                //判断该月有几天
                int daysNum = DateTime.DaysInMonth(int.Parse(yearss), int.Parse(months));

                for (int i = 1; i <=daysNum; i++)
                {
                    string todayss = yearss + "-" + months + "-" + i.ToString();
                    string zhoucim = getZhouCi(firstlashcontent[0].ToString(), firstlashcontent[1].ToString(), todayss);
                    if (zhoucim == "放假")
                    {

                        zhoucim = zhoucim + GetWeekOfYear(Convert.ToDateTime(todayss)).ToString();
                    }
                    coutw = coutw + zhoucim + ",";// getZhouCi(firstlashcontent[0].ToString(), firstlashcontent[1].ToString(), todayss) + ",";
                }

                // DateTime.DaysInMonth( dtselect.
            }
            catch
            {

            }
            return coutw;
        }

        /// <summary>
        /// 获取当前学期的开始星期和结束星期
        /// </summary>
        /// <returns>{"开始时间","结束时间","说明"}</returns>
        public string[] getFirt_LastWeek()
        {
            string[] coutw = { "0", "0", "0" };
            try
            {
                //1获取到当前的工作学期，isWork=1的，获取它的第一周开始时间
                DataTable dt = new DataTable();
                dt = getWorkDiary();
                string firstweek = "";
                string lastweek = "";
                string content = "";
                if (dt.Rows.Count > 0)
                {
                    firstweek = dt.Rows[0]["FirstWeek"].ToString();//本学期的第一周时间
                    lastweek = dt.Rows[0]["LastWeek"].ToString();//本学期的最后以后时间
                    content = dt.Rows[0]["CONTENTS"].ToString();//学期的名称
                    coutw[0] = firstweek;
                    coutw[1] = lastweek;
                    coutw[2] = content;
                }
                else
                {
                    coutw[0] = "0";
                    coutw[1] = "0";
                    coutw[2] = "0";
                }
            }
            catch
            {
                coutw[0] = "0";
                coutw[1] = "0";
                coutw[2] = "0";
            }
            return coutw;
        }
        /// <summary>
        /// 根据当前学期的第一周和当前的时间，计算出日历的周次
        /// </summary>
        /// <param name="firsWeek"></param>
        /// <param name="todays"></param>
        /// <returns></returns>
        public string getZhouCi(string firsWeek, string lastWeek, string todays)
        {
            string coutw = "";
            try
            {
                //2 获取本学期一周对应的全年的周次
                DateTime firstDt = Convert.ToDateTime(firsWeek);
                DateTime lastDt = Convert.ToDateTime(lastWeek);
                DateTime todaysDt = Convert.ToDateTime(todays);

                if (todaysDt > lastDt || todaysDt < firstDt)
                {
                    coutw = "放假";
                }
                else
                {
                    string diff = commons.DateDiff(firstDt, todaysDt);
                    int diffint = int.Parse(diff);
                    int zhouciben = diffint / 7;
                    double zhouci = diffint / 7;
                    double zhoucibendouble = Convert.ToDouble(zhouciben);
                    if (zhouci - zhoucibendouble > 0)
                    {
                        zhouciben = zhouciben + 2;
                    }
                    else
                    {
                        zhouciben = zhouciben + 1;
                    }
                    coutw = zhouciben.ToString();
                }

            }
            catch
            {
                coutw = "放假";
            }
            return coutw;


        }
        /// <summary>
        /// 获取到当前的工作学期
        /// </summary>
        /// <returns></returns>
        public DataTable getWorkDiary()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "";
                sql = "select * from Term_Diary WHERE DELFLAG = '0' and isWork='1' order by FirstWeek desc";
                dt = pagedosql.doSql(sql).Tables[0];
            }
            catch
            {
            }
            return dt;
        }


        /// <summary>
        /// 获取某一日期是该年中的第几周
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns>该日期在该年中的周数</returns>
        private int GetWeekOfYear(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        //截取字符串
        public string substr(object str)
        {
            string substr2 = Convert.ToString(str);
            if (substr2.Length > 15)
            {
                substr2 = substr2.Remove(15) + "...";
            }
            return substr2;
        }
        /// <summary>
        /// 当月份进行触发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dianda.Model.USER_Users userModel = (Dianda.Model.USER_Users)Session["USER_Users"];
                string strId = userModel.ID;
                string months = DropDownList_year.SelectedItem.Value.ToString() + "-" + DropDownList_month.SelectedItem.Value.ToString() + "-01 00:00:00";

                string strDateTime = Calendar1.SelectedDate.ToString();
                string strRalName = userModel.REALNAME.ToString();
                string strUserName = userModel.USERNAME.ToString();
                ShowPersonProject_month(strId, months);
                ShowClassProject_month(strRalName, strUserName, months);
                //  Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('fada');hide();", true);
                ScriptManager.RegisterStartupScript(this.UpdatePanel, this.GetType(), "updateScript", "hide();", true);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 选项卡发生变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TabContainer_ActiveTabChanged(object sender, EventArgs e)
        {
            int idexs = TabContainer.ActiveTabIndex;
            if (idexs == 1)
            {
                Label_addProject.Visible = false;
            }
            else
            {
                Label_addProject.Visible = true;
            }
            
            ScriptManager.RegisterStartupScript(this.UpdatePanel, this.GetType(), "updateScript", "initStatus();", true);

        }
        /// <summary>
        /// 获取当天是否有任务
        /// </summary>
        /// <returns></returns>
        private int isRenwu(string days,bool isDangtian,bool isselect)
        {
            //1--无状态、2--无状态并选中、3--个人计划未选中、4--个人计划并选中、5--项目计划未选中、6--项目计划并选中
            //7--个人计划和项目计划未选中、8--个人计划和项目计划并选中、9无状态的当天、10--个人计划的当天、11--项目计划的当天、12--个人计划和项目计划的当天
            int coutw = 0;
            try
            {
                bool isxiangm = false;
                bool isgeren = false;

                Dianda.Model.USER_Users userModel = (Dianda.Model.USER_Users)Session["USER_Users"];
                //项目的任务
                DataTable dt = new DataTable();
                //通过ID查询出状态是0并且不等于的2
                if (days.Length>11)
                {
                    DateTime dts = DateTime.Parse(days);
                    string Years = dts.Year.ToString();

                    string Months = dts.Month.ToString();
                    if (Months.Length == 1)
                    {
                        Months = "0" + Months;
                    }
                    string Days2 = dts.Day.ToString();
                    if (Days2.Length == 1)
                    {
                        Days2 = "0" + Days2;
                    }

                    days = Years + "/" + Months + "/" + Days2;
                }
                 
                //个人计划
                dt = bPlan.GetList(1, "Delflag = '0' and Status <> 2 and  UserID = '" + userModel.ID.ToString() + "' and '" + days + "' BETWEEN CONVERT(varchar(10), StartTime, 111) AND  CONVERT(varchar(10), EndTime, 111)", "StartTime asc").Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    isxiangm = true;
                }
                else
                {
                    isxiangm = false;
                }

                //项目任务
                DataTable dt2 = new DataTable();
                string strsql = "select top 1 * from vProject_Task where Pro_DELFLAG='0' and Pro_Status=1 and '" + days + "' between  CONVERT(varchar(10), StartTime, 111) AND  CONVERT(varchar(10), EndTime, 111) and delflag = '0' and Status <> 2 and userInfo Like '%" + userModel.REALNAME.ToString() + "(" + userModel.USERNAME.ToString() + ")" + "%' order by StartTime asc";
                dt = pagedosql.doSql(strsql).Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    isgeren = true;
                }
                else
                {
                    isgeren = false;
                }

                //开始组合判断
                if (!isselect)//不是选中的那天
                {
                    if (isDangtian)//是当天
                    {
                        if (isxiangm)//是项目的
                        {
                            coutw = 11;
                            if (isgeren)//是个人的
                            {
                                coutw = 12;
                            }
                        }
                        else if (isgeren)//是个人的
                        {
                            coutw = 10;
                            if (isxiangm)//是项目的
                            {
                                coutw = 12;
                            }
                        }
                        else//无状态的
                        {
                            coutw = 9;
                        }
                    }
                    else//不是今天
                    {
                        if (isxiangm)//是项目的
                        {
                            coutw = 5;
                            if (isgeren)//是个人的
                            {
                                coutw = 7;
                            }
                        }
                        else if (isgeren)//是个人的
                        {
                            coutw = 3;
                            if (isxiangm)//是项目的
                            {
                                coutw = 7;
                            }
                        }
                        else//无状态的
                        {
                            coutw = 1;
                        }
                    }
                }
                else//当前被选中
                {
                    if (!isDangtian)//不是当天
                    {
                        if (isxiangm)//是项目的
                        {
                            coutw = 6;
                            if (isgeren)//是个人的
                            {
                                coutw = 8;
                            }
                        }
                        else if (isgeren)//是个人的
                        {
                            coutw = 4;
                            if (isxiangm)//是项目的
                            {
                                coutw = 8;
                            }
                        }
                        else//无状态的
                        {
                            coutw = 2;
                        }
                    }
                    else//是当天
                    {
                        if (isxiangm)//是项目的
                        {
                            coutw = 11;
                            if (isgeren)//是个人的
                            {
                                coutw = 12;
                            }
                        }
                        else if (isgeren)//是个人的
                        {
                            coutw = 10;
                            if (isxiangm)//是项目的
                            {
                                coutw = 12;
                            }
                        }
                        else//无状态的
                        {
                            coutw = 9;
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
