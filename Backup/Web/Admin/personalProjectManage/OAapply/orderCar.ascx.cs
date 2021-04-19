using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAapply
{
    public partial class orderCar : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pagecontrol = new Dianda.COMMON.pageControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //初始化页面属性值
                ShowDDLInfo();
                //车辆信息列表
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
                for (int i = 0; i < 24;i++ )
                {
                    ListItem li1 = new ListItem(i.ToString().Length > 1 ? i.ToString() : "0" + i.ToString(), i.ToString().Length > 1 ? i.ToString() : "0" + i.ToString());
                    ListItem li2 = new ListItem(i.ToString().Length > 1 ? i.ToString() : "0" + i.ToString(), i.ToString().Length > 1 ? i.ToString() : "0" + i.ToString());
                    DDL_hour1.Items.Add(li1);

                    DDL_hour2.Items.Add(li2);

                    if(i==2)
                    {
                        li2.Selected = true;
                    }
                }
                //初始化分
                //for (int j = 0; j <= 55;j=j+5 )
                //{
                //    ListItem li12 = new ListItem(j.ToString().Length > 1 ? j.ToString() : "0" + j.ToString(), j.ToString().Length > 1 ? j.ToString() : "0" + j.ToString());
                //    ListItem li22 = new ListItem(j.ToString().Length > 1 ? j.ToString() : "0" + j.ToString(), j.ToString().Length > 1 ? j.ToString() : "0" + j.ToString());

                //    DDL_minute1.Items.Add(li12);
                //    DDL_minute2.Items.Add(li22);
                 
                //}
                //ListItem min = new ListItem("59","59");
                //DDL_minute1.Items.Add(min);
                //DDL_minute2.Items.Add(min);
                //DDL_minute1.SelectedValue = "00";
                //DDL_minute2.SelectedValue = "59";
              

            }
            catch
            {

            }
        }

        /// <summary>
        /// 车辆信息列表
        /// </summary>
        protected void ShowListInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM Project_CarList";

                dt = pagecontrol.doSql(sql).Tables[0];
                if(dt.Rows.Count>0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是DT
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上

                }else
                {
                    GridView1.Visible = false;
                    Button_Check.Enabled = false;
                    notice.Text = "*暂无可供预订的车辆信息！";
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

                if (null==TB_ordertime1.Value || TB_ordertime1.Value.Equals(""))
                {
                    lb_tag.Text = "用车时间不能为空！";
                    return;
                }              

                //预订开始时间
                DateTime DD1 = Convert.ToDateTime(TB_ordertime1.Value.ToString());
                //预订结束时间
                DateTime DD2 = Convert.ToDateTime(TB_ordertime2.Value.ToString());
                //如果用户订的是跨天的，比如时间是2011－06－30 23：00至2011－07－01 01：00
                //但下次如果再订的时候选择的是2011－06－30 21：00 至2011－06－30 22：00，那么这个时候是不能订的，因为在已
                //预订的信息的开始之前一个半小时，结束后的一个半小时都不能订，所以下面的日期要在2011－07－01 23：59：59秒，不然如果只加一天2011－07－01 00:00:00，则下面的SQL会找不到数据。    

                DateTime DD1_1 = DD1.AddDays(-1);
                DateTime DD1_2 = DD2.AddDays(2).AddSeconds(-1);

                string st = TB_ordertime1.Value.ToString()+" "+DDL_hour1.Text.ToString()+":"+DDL_minute1.Text.ToString()+":00";
                string et = TB_ordertime2.Value.ToString()+" "+DDL_hour2.Text.ToString()+":"+DDL_minute2.Text.ToString()+":00";

                if (Convert.ToDateTime(DD1.ToString("yyyy-MM-dd")) < Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")))
                {
                    lb_tag.Text = "车辆必须提前一天预订，请电话联系相关人员！";
                    return;

                }

                if(Convert.ToDateTime(st)>Convert.ToDateTime(et))
                {
                    lb_tag.Text = "用车开始时间不能大于结束时间！";
                    
                    return;
                }


                if (GridView1.Rows.Count > 0)
                {
                    lb_tag.Text = "";

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        RadioButton rb = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("RadioButton_choose");
                        rb.Enabled = true;

                        GridView1.Rows[i].Cells[5].Text = "";
                        HiddenField HF = (HiddenField)GridView1.Rows[i].Cells[0].FindControl("Hid_ID");
                        string carid = HF.Value.ToString();

                        DataTable dt = new DataTable();
                        string sql = "SELECT Project_Apply_orderCar.StartTime,Project_Apply_orderCar.EndTime,CONVERT(varchar(100),Project_Apply_orderCar.StartTime,23) as StartTime1, " +
                         " CONVERT(varchar(100),Project_Apply_orderCar.EndTime,23) as EndTime1," +
                         " CONVERT(varchar(100),Project_Apply_orderCar.StartTime,24) as StartTime2, " +
                         " CONVERT(varchar(100),Project_Apply_orderCar.EndTime,24) as EndTime2 " +
                         " FROM Project_Apply_orderCar LEFT OUTER JOIN " +
                                  "  Project_Apply ON Project_Apply_orderCar.ApplyID = Project_Apply.ID " +
                                  " WHERE (Project_Apply.DELFLAG = 0) AND (Project_Apply.AppType='orderCar') " +
                                  " AND (Project_Apply.Status in ('1','0')) AND (Project_Apply_orderCar.CarID=" + carid + ")" +
                                  " AND (((Project_Apply_orderCar.StartTime >'" + DD1_1 + "')" +
                                  " AND (Project_Apply_orderCar.EndTime <'" + DD1_2 + "'))" +
                                  " or ((Project_Apply_orderCar.EndTime >'" + DD1_1 + "')" +
                                  " AND (Project_Apply_orderCar.StartTime <'" + DD1_2 + "')))";

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
                                //这里加上1.5个小时的意思是在预订开始前的1.5个小时，以及结束时间后的1.5个小时这三个小时也是不能再插入预约的。
                                if (stimeC.AddHours(1.5) <= stimeDoA && etimeD.AddHours(1.5) <= stimeDoA)
                                {
                                    isAccpet = isAccpet + 1;
                                }
                                else if (stimeC >= etimeDoB.AddHours(1.5) && etimeD >= etimeDoB.AddHours(1.5))
                                {
                                    isAccpet = isAccpet + 1;
                                }
                                //可以申请的时间段

                                string StartHour = dt.Rows[k]["StartTime2"].ToString();
                                string EndHour = dt.Rows[k]["EndTime2"].ToString();
                                string message = "<font color='red'>"+StartHour.Substring(0, StartHour.Length - 3) + "-" + EndHour.Substring(0, EndHour.Length - 3) + "已被预订 </font></br>";

                                GridView1.Rows[i].Cells[5].Text = GridView1.Rows[i].Cells[5].Text + message;
                            }
                            if (isAccpet >= tablerows)
                            {
                                GridView1.Rows[i].Cells[5].Text = "空闲";
                            }
                            else
                            {
                                GridView1.Rows[i].Cells[5].Text = "<font color='red'>已被预订</font>";
                            }
                        }
                        else
                        {
                            GridView1.Rows[i].Cells[5].Text = "空闲";
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
                }
                //Clear();
            }
            catch
            {

            }
        }      


        /// <summary>
        /// 返回订车时间
        /// </summary>
        public string ordercartime
        {
            get
            {
                return TB_ordertime1.Value.ToString();
            }
            set
            {
                TB_ordertime1.Value = value;
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
        /// 返回订车时间起始时间（时）
        /// </summary>
        public string starthour
        {
            get
            {
                return DDL_hour1.SelectedValue;
            }
            set
            {
                DDL_hour1.SelectedValue = value;
            }
        }

        /// <summary>
        /// 返回订车时间起始时间（分）
        /// </summary>
        public string startminute
        {
            get
            {
                return DDL_minute1.SelectedValue;
            }
            set
            {
                DDL_minute1.SelectedValue = value;
            }
        }

        /// <summary>
        /// 返回订车时间截止时间（时）
        /// </summary>
        public string endhour
        {
            get
            {
                return DDL_hour2.SelectedValue;
            }
            set
            {
                DDL_hour2.SelectedValue = value;
            }
        }
        
        /// <summary>
        /// 返回订车时间截止时间（分）
        /// </summary>
        public string endminute
        {
            get
            {
                return DDL_minute2.SelectedValue;
            }
            set
            {
                DDL_minute2.SelectedValue = value;
            }
        }

        /// <summary>
        /// 返回乘车人数
        /// </summary>
        public string PeopleNum
        {
            get
            {
                return TB_PeopleNum.Text.ToString();
            }
            set
            {
                TB_PeopleNum.Text= value;
            }
        }

        /// <summary>
        /// 返回始发地
        /// </summary>
        public string FromAddress
        {
            get
            {
                return TB_FromAddress.Text.ToString();
            }
            set
            {
                TB_FromAddress.Text = value;
            }
        }

        /// <summary>
        /// 返回目的地
        /// </summary>
        public string ToAddress
        {
            get
            {
                return TB_ToAddress.Text.ToString();
            }
            set
            {
                TB_ToAddress.Text = value;
            }
        }

        /// <summary>
        /// 返回所选择车辆的ID
        /// </summary>
        public string CarID
        {
            get
            {
                return HiddenField1.Value.ToString();
            }
            set
            {
                HiddenField1.Value = value;
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
                string begindate = TB_ordertime1.Value.ToString();
                //开始日期 时
                string beginhour = DDL_hour1.SelectedValue.ToString();
                //开始日期 秒
                string beginsecond = DDL_minute1.SelectedValue.ToString();

                DateTime begintime = Convert.ToDateTime(begindate + " " + beginhour + ":" + beginsecond);

                DateTime endtime = begintime.AddHours(2);

                //结束日期 天
                TB_ordertime2.Value = endtime.Year.ToString() + "-" + endtime.Month.ToString() + "-" + endtime.Day.ToString();
                //结束日期 时
                DDL_hour2.SelectedValue = endtime.Hour.ToString().Length < 2 ? "0" + endtime.Hour.ToString() : endtime.Hour.ToString();
                //结束日期 秒
                DDL_minute2.SelectedValue = endtime.Minute.ToString().Length < 2 ? "0" + endtime.Minute.ToString() : endtime.Minute.ToString();

            }
            catch
            { }
        }

    }
}