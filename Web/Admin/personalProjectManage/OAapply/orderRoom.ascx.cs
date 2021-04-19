using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAapply
{
    public partial class orderRoom : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pagecontrol = new Dianda.COMMON.pageControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //初始化页面属性值
                ShowDDLInfo();
                //会议室信息列表
                ShowListInfo();

                Button_Check.Attributes.Add("onclick", "setHFClick();SetValue('true','0');");
            }
        }


        /// <summary>
        /// 初始化页面属性值
        /// </summary>
        protected void ShowDDLInfo()
        {
            try
            {
                //初始化小时
                for (int k = 8; k < 24; k++)
                {
                    ListItem L_hour1 = new ListItem(k.ToString().Length > 1 ? k.ToString() : "0" + k.ToString(), k.ToString().Length > 1 ? k.ToString() : "0" + k.ToString());
                    ListItem L_hour2 = new ListItem(k.ToString().Length > 1 ? k.ToString() : "0" + k.ToString(), k.ToString().Length > 1 ? k.ToString() : "0" + k.ToString());
                    DDL_hour11.Items.Add(L_hour1);

                    DDL_hour21.Items.Add(L_hour2);

                    if (k==2)
                    {
                        L_hour2.Selected = true;
                    }
                }
                //初始化分
                //for (int j = 0; j < 60; j++)
                //{
                //    ListItem L_hour11 = new ListItem(j.ToString().Length > 1 ? j.ToString() : "0" + j.ToString(), j.ToString().Length > 1 ? j.ToString() : "0" + j.ToString());
                //    ListItem L_hour12 = new ListItem(j.ToString().Length > 1 ? j.ToString() : "0" + j.ToString(), j.ToString().Length > 1 ? j.ToString() : "0" + j.ToString());
                //    DDL_minute11.Items.Add(L_hour11);
                //    DDL_minute21.Items.Add(L_hour12);

                //    if (j == 59)
                //    {
                //        L_hour12.Selected = true;
                //    }
                //}

            }
            catch
            {

            }
        }

        /// <summary>
        /// 会议室列表
        /// </summary>
        protected void ShowListInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM Project_RoomList WHERE (DELFLAG = 0)";

                dt = pagecontrol.doSql(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是DT
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上

                }
                else
                {
                    GridView1.Visible = false;
                    Button_Check.Enabled = false;
                    notice.Text = "*暂无可供预订的会议室信息！";
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
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    //车辆ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;

                    RadioButton rb = (RadioButton)e.Row.FindControl("RadioButton_choose");
                    if (rb != null)
                    {
                        //把选中行的RowIndex也传过去，提交后在服务器端取值时用
                        rb.Attributes.Add("onclick", "onClientClick('" + rb.ClientID + "','" + ID + "')");
                    }

                }
            }
            catch
            { }
        }


        /// <summary>
        /// 点击检查是否可预订触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Check_Click(object sender, EventArgs e)
        {
            try
            {
                 
                //父页面上的提示信息控件
                Label lb_tag = (Label)this.Parent.FindControl("tag");

                if (null == TB_orderroomtime.Value || TB_orderroomtime.Value.Equals(""))
                {
                    lb_tag.Text = "会议时间不能为空！";
                    return;
                }

                //预订开始时间
                DateTime DD1 = Convert.ToDateTime(TB_orderroomtime.Value.ToString());
                DateTime DD1_1 = DD1.AddSeconds(-1);
                DateTime DD1_2 = DD1.AddDays(1);

                string st = TB_orderroomtime.Value.ToString() + " " + DDL_hour11.Text.ToString() + ":" + DDL_minute11.Text.ToString() + ":00";
                string et = TB_ordertime2.Value.ToString() + " " + DDL_hour21.Text.ToString() + ":" + DDL_minute21.Text.ToString() + ":00";

                if (Convert.ToDateTime(DD1.ToString("yyyy-MM-dd")) < Convert.ToDateTime(DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")))
                {
                    lb_tag.Text = "会议室必须提前二天预订，请电话联系相关人员！";
                    return;
                }

                if (Convert.ToDateTime(st) > Convert.ToDateTime(et))
                {
                    lb_tag.Text = "会议开始时间不能大于结束时间！";
                    return;
                }

                if (GridView1.Rows.Count > 0)
                {
                    lb_tag.Text = "";

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {

                        RadioButton rb = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("RadioButton_choose");
                        rb.Enabled = true;

                        GridView1.Rows[i].Cells[3].Text = "";
                        HiddenField HF = (HiddenField)GridView1.Rows[i].Cells[0].FindControl("Hid_ID");
                        string roomid = HF.Value.ToString();

                        DataTable dt = new DataTable();
                        string sql = "SELECT Project_Apply_orderRoom.StartTime,Project_Apply_orderRoom.EndTime,CONVERT(varchar(100),Project_Apply_orderRoom.StartTime,23) as StartTime1, " +
                            " CONVERT(varchar(100),Project_Apply_orderRoom.EndTime,23) as EndTime1," +
                            " CONVERT(varchar(100),Project_Apply_orderRoom.StartTime,24) as StartTime2, " +
                            " CONVERT(varchar(100),Project_Apply_orderRoom.EndTime,24) as EndTime2 " +
                            " ,Project_Apply.Status FROM Project_Apply_orderRoom LEFT OUTER JOIN " +
                                     "  Project_Apply ON Project_Apply_orderRoom.ApplyID = Project_Apply.ID " +
                                     " WHERE (Project_Apply.DELFLAG = 0) AND (Project_Apply.AppType='orderRoom') " +
                                     " AND (Project_Apply.Status in ('0','1')) AND (Project_Apply_orderRoom.RoomID=" + roomid + ") " +
                                     " AND ( " +
                                     " ('" + st + "' >= Project_Apply_orderRoom.StartTime and '" + st + "' < Project_Apply_orderRoom.EndTime) " +
                                     " OR ('" + et + "' >= Project_Apply_orderRoom.StartTime and '" + et + "' < Project_Apply_orderRoom.EndTime) " +
                                     " OR ('" + st + "' < Project_Apply_orderRoom.StartTime and '" + et + "' >= Project_Apply_orderRoom.EndTime)) ";
                                     //" AND (Project_Apply_orderRoom.StartTime >'" + DD1_1 + "')" +
                                     //" AND (Project_Apply_orderRoom.StartTime <'" + DD1_2 + "')" +
                                     //" AND (Project_Apply_orderRoom.EndTime >'" + DD1_1 + "')" +
                                     //" AND (Project_Apply_orderRoom.EndTime <'" + DD1_2 + "')";

                        dt = pagecontrol.doSql(sql).Tables[0];
                        //判断当前的时间是否是可以预约的
                        int isAccpet = 0;//可以申请时的累加值
                        int tablerows = 0;//对比对象的行值
                        DateTime stimeC = DateTime.Parse(st);//开始时间
                        DateTime etimeD = DateTime.Parse(et);//结束时间
                        //判断当前的时间是否是可以预约的

                        if (dt.Rows.Count > 0)
                        {
                            tablerows = dt.Rows.Count;//对比对象的行值

                            for (int k = 0; k < dt.Rows.Count; k++)
                            {
                                DateTime stimeDoA = DateTime.Parse(dt.Rows[k]["StartTime"].ToString());//开始时间
                                DateTime etimeDoB = DateTime.Parse(dt.Rows[k]["EndTime"].ToString());//结束时间
                                //可以申请的时间段
                                if (stimeC <=stimeDoA && etimeD <= stimeDoA)
                                {
                                    isAccpet = isAccpet+1;
                                }
                                else if (stimeC >= etimeDoB && etimeD >=etimeDoB)
                                {
                                    isAccpet = isAccpet + 1;
                                }
                                //可以申请的时间段
                                string StartHour = dt.Rows[k]["StartTime2"].ToString();
                                string EndHour = dt.Rows[k]["EndTime2"].ToString();
                                string Status = dt.Rows[k]["Status"].ToString();
                                string stausname = "<font color='red'>己被预订</font>";
                                if (Status == "0")
                                {
                                    stausname = "<font color='blue'>待审中</font>";
                                }
                                string message = "<font color='red'>" + StartHour.Substring(0, StartHour.Length - 3) + "-" + EndHour.Substring(0, EndHour.Length - 3) +stausname+ "</font></br>";

                                GridView1.Rows[i].Cells[3].Text = GridView1.Rows[i].Cells[3].Text + message;
                            }
                            if (isAccpet >= tablerows)
                            {
                                GridView1.Rows[i].Cells[3].Text = "空闲";
                            }
                            else
                            {
                                GridView1.Rows[i].Cells[3].Text = "<font color='red'>已被预订</font>";
                            }
                        }
                        else
                        {
                            GridView1.Rows[i].Cells[3].Text = "空闲";
                            isAccpet =1;
                        }


                        if (isAccpet >= tablerows)
                        {
                            rb.Enabled = true;
                         
                        }
                        else
                        {
                            rb.Enabled = false;
                            rb.Checked = false;
                        }
                    }
                }
            }
            catch
            {

            }
        }
        //2此验证
        public bool setvalue()
        {
            try
            {
                //父页面上的提示信息控件
                Label lb_tag = (Label)this.Parent.FindControl("tag");

                if (null == TB_orderroomtime.Value || TB_orderroomtime.Value.Equals(""))
                {
                    lb_tag.Text = "会议时间不能为空！";
                    return false;
                }

                //预订开始时间
                DateTime DD1 = Convert.ToDateTime(TB_orderroomtime.Value.ToString());
                DateTime DD1_1 = DD1.AddSeconds(-1);
                DateTime DD1_2 = DD1.AddDays(1);

                string st = TB_orderroomtime.Value.ToString() + " " + DDL_hour11.Text.ToString() + ":" + DDL_minute11.Text.ToString() + ":00";
                string et = TB_ordertime2.Value.ToString() + " " + DDL_hour21.Text.ToString() + ":" + DDL_minute21.Text.ToString() + ":00";

                if (Convert.ToDateTime(DD1.ToString("yyyy-MM-dd")) < Convert.ToDateTime(DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")))
                {
                    lb_tag.Text = "会议室必须提前二天预订，请电话联系相关人员！";
                    return false;
                }

                if (Convert.ToDateTime(st) > Convert.ToDateTime(et))
                {
                    lb_tag.Text = "会议开始时间不能大于结束时间！";
                    return false;
                }

                if (GridView1.Rows.Count > 0)
                {
                    lb_tag.Text = "";

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {

                        RadioButton rb = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("RadioButton_choose");
                        rb.Enabled = true;

                        GridView1.Rows[i].Cells[3].Text = "";
                        HiddenField HF = (HiddenField)GridView1.Rows[i].Cells[0].FindControl("Hid_ID");
                        string roomid = HF.Value.ToString();

                        DataTable dt = new DataTable();
                        string sql = "SELECT Project_Apply_orderRoom.StartTime,Project_Apply_orderRoom.EndTime,CONVERT(varchar(100),Project_Apply_orderRoom.StartTime,23) as StartTime1, " +
                            " CONVERT(varchar(100),Project_Apply_orderRoom.EndTime,23) as EndTime1," +
                            " CONVERT(varchar(100),Project_Apply_orderRoom.StartTime,24) as StartTime2, " +
                            " CONVERT(varchar(100),Project_Apply_orderRoom.EndTime,24) as EndTime2 " +
                            " ,Project_Apply.Status FROM Project_Apply_orderRoom LEFT OUTER JOIN " +
                                     "  Project_Apply ON Project_Apply_orderRoom.ApplyID = Project_Apply.ID " +
                                     " WHERE (Project_Apply.DELFLAG = 0) AND (Project_Apply.AppType='orderRoom') " +
                                     " AND (Project_Apply.Status in ('0','1')) AND (Project_Apply_orderRoom.RoomID=" + roomid + ")" +
                                     " AND (Project_Apply_orderRoom.StartTime >'" + DD1_1 + "')" +
                                     " AND (Project_Apply_orderRoom.StartTime <'" + DD1_2 + "')" +
                                     " AND (Project_Apply_orderRoom.EndTime >'" + DD1_1 + "')" +
                                     " AND (Project_Apply_orderRoom.EndTime <'" + DD1_2 + "')";

                        dt = pagecontrol.doSql(sql).Tables[0];
                        //判断当前的时间是否是可以预约的
                        int isAccpet = 0;//可以申请时的累加值
                        int tablerows = 0;//对比对象的行值
                        DateTime stimeC = DateTime.Parse(st);//开始时间
                        DateTime etimeD = DateTime.Parse(et);//结束时间
                        //判断当前的时间是否是可以预约的

                        if (dt.Rows.Count > 0)
                        {
                            tablerows = dt.Rows.Count;//对比对象的行值

                            for (int k = 0; k < dt.Rows.Count; k++)
                            {
                                DateTime stimeDoA = DateTime.Parse(dt.Rows[k]["StartTime"].ToString());//开始时间
                                DateTime etimeDoB = DateTime.Parse(dt.Rows[k]["EndTime"].ToString());//结束时间
                                //可以申请的时间段
                                if (stimeC <= stimeDoA && etimeD <= stimeDoA)
                                {
                                    isAccpet = isAccpet + 1;
                                }
                                else if (stimeC >= etimeDoB && etimeD >= etimeDoB)
                                {
                                    isAccpet = isAccpet + 1;
                                }
                                //可以申请的时间段
                                string StartHour = dt.Rows[k]["StartTime2"].ToString();
                                string EndHour = dt.Rows[k]["EndTime2"].ToString();
                                string Status = dt.Rows[k]["Status"].ToString();
                                string stausname = "<font color='red'>己被预订</font>";
                                if (Status == "0")
                                {
                                    stausname = "<font color='blue'>待审中</font>";
                                }
                                string message = "<font color='red'>" + StartHour.Substring(0, StartHour.Length - 3) + "-" + EndHour.Substring(0, EndHour.Length - 3) + stausname + "</font></br>";

                                GridView1.Rows[i].Cells[3].Text = GridView1.Rows[i].Cells[3].Text + message;
                            }
                            if (isAccpet >= tablerows)
                            {
                                GridView1.Rows[i].Cells[3].Text = "空闲";
                            }
                            else
                            {
                                GridView1.Rows[i].Cells[3].Text = "<font color='red'>己被预订</font>";
                            }
                        }
                        else
                        {
                            GridView1.Rows[i].Cells[3].Text = "空闲";
                            isAccpet = 1;
                        }


                        if (isAccpet >= tablerows)
                        {
                            rb.Enabled = true;
                        }
                        else
                        {
                            rb.Enabled = false;
                            rb.Checked = false;
                        }
                    }
                    Clear();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Clear()
        {
            HF_orderroomID.Value = "";
            foreach (GridViewRow item in GridView1.Rows)
            {
                ((RadioButton)item.FindControl("RadioButton_choose")).Checked = false;
                ((HiddenField)item.FindControl("Hid_ID")).Value = "";
            }
        }

        /// <summary>
        /// 返回会议时间
        /// </summary>
        public string orderroomtime
        {
            get
            {
                return TB_orderroomtime.Value.ToString();
            }
            set
            {
                TB_orderroomtime.Value = value;
            }
        }
        /// <summary>
        /// 返回订车结束时间
        /// </summary>
        public string ordercarendtime
        {
            get
            {
                return TB_ordertime2.Value.ToString();
            }
            set
            {
                TB_ordertime2.Value = value;
            }
        }
        /// <summary>
        /// 返回会议时间起始时间（时）
        /// </summary>
        public string starthour
        {
            get
            {
                return DDL_hour11.SelectedValue;
            }
            set
            {
                DDL_hour11.SelectedValue = value;
            }
        }

        /// <summary>
        /// 返回会议时间起始时间（分）
        /// </summary>
        public string startminute
        {
            get
            {
                return DDL_minute11.SelectedValue;
            }
            set
            {
                DDL_minute11.SelectedValue = value;
            }
        }

        /// <summary>
        /// 返回会议时间截止时间（时）
        /// </summary>
        public string endhour
        {
            get
            {
                return DDL_hour21.SelectedValue;
            }
            set
            {
                DDL_hour21.SelectedValue = value;
            }
        }

        /// <summary>
        /// 返回会议时间截止时间（分）
        /// </summary>
        public string endminute
        {
            get
            {
                return DDL_minute21.SelectedValue;
            }
            set
            {
                DDL_minute21.SelectedValue = value;
            }
        }

        /// <summary>
        /// 返回会议人数
        /// </summary>
        public string MeetingNum
        {
            get
            {
                return TB_MeetingNums.Text.ToString();
            }
            set
            {
                TB_MeetingNums.Text = value;
            }
        }
        /// <summary>
        /// 返回会议名称
        /// </summary>
        public string MeetingName
        {
            get
            {
                return TB_MeetingName.Text.ToString();
            }
            set
            {
                TB_MeetingName.Text = value;
            }
        }

        
        ///// <summary>
        ///// 返回会议名称
        ///// </summary>
        //public string MeetingAddress
        //{
        //    get
        //    {
        //        return TB_MeetingAddress.Text.ToString();
        //    }
        //    set
        //    {
        //        TB_MeetingAddress.Text = value;
        //    }
        //}

        /// <summary>
        /// 返回所选择会议室的ID
        /// </summary>
        public string RoomID
        {
            get
            {
                return HF_orderroomID.Value.ToString();
            }
            set
            {
                HF_orderroomID.Value = value;
            }
        }

        /// <summary>
        /// 返回会议地址
        /// </summary>
        public  CheckBoxList orderroomadress
        {
            get
            {
                
                return CheckBoxList1;
            }
            set
            {
                CheckBoxList1 = value;  
            }
        }

        /// <summary>
        /// 开始时间的小时改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_Part_change(object sender, EventArgs e)
        {
            try
            {
                //开始日期 天
                string begindate = TB_orderroomtime.Value.ToString();
                //开始日期 时
                string beginhour = DDL_hour11.SelectedValue.ToString();
                //开始日期 秒
                string beginsecond = DDL_minute11.SelectedValue.ToString();

                DateTime begintime = Convert.ToDateTime(begindate + " " + beginhour + ":" + beginsecond);

                DateTime endtime = begintime.AddHours(2);

                //结束日期 天
                TB_ordertime2.Value = endtime.Year.ToString() + "-" + endtime.Month.ToString() + "-" + endtime.Day.ToString();
                //结束日期 时
                DDL_hour21.SelectedValue = endtime.Hour.ToString().Length < 2 ? "0" + endtime.Hour.ToString() : endtime.Hour.ToString();
                //结束日期 秒
                DDL_minute21.SelectedValue = endtime.Minute.ToString().Length < 2 ? "0" + endtime.Minute.ToString() : endtime.Minute.ToString();

            }
            catch
            { }
        }
    }
}