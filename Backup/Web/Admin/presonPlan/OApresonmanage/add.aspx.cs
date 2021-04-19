using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.presonPlan.OApresonmanage
{
    public partial class add : System.Web.UI.Page
    {
        Dianda.Model.Personal_Plan personalModel = new Dianda.Model.Personal_Plan();
        Dianda.COMMON.common commonId = new Dianda.COMMON.common();
        Dianda.BLL.Personal_Plan personalBll = new Dianda.BLL.Personal_Plan();
        Model.USER_Users userModel = new Dianda.Model.USER_Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["statue"]!= null)
                {

                    Labeltext.Text = "添加成功！请继续添加！";
                   
                }
                //设置开始结束时间为当前时间
                TB_DateTime.Value = DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day;
                TB_DateTime1.Value = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            }
           
        }
        //保存并关闭
        protected void Button_add_Click(object sender, EventArgs e)
        {
            try
            {
                 userModel= (Dianda.Model.USER_Users)Session["USER_Users"];
                //string SY_DATUM ="";
                string dateTime = TB_DateTime.Value.ToString();
                string dateTime1 = TB_DateTime1.Value.ToString();
                //日期
                personalModel.DATETIME = Convert.ToDateTime(dateTime);
                //标题
                personalModel.NAMES = TextBox_Title.Text.ToString();
                //内容
                //personalModel.Overviews = TextBox_Content.Text.ToString();
                //获得开始时间
                string startTime = dateTime + " " + ddl_Part.SelectedValue.ToString() + ":" + ddl_second.SelectedValue.ToString() + ":00";
               //获得结束时间
                string endTime = dateTime1 + " " + ddl_Part1.SelectedValue.ToString() + ":" + ddl_second1.SelectedValue.ToString() + ":00";
                if (checkDate(startTime, endTime))
                {
                    personalModel.StartTime = Convert.ToDateTime(startTime);
                    personalModel.EndTime = Convert.ToDateTime(endTime);
                    //计划状态;
                    personalModel.Status = 0;
                    //状态
                    personalModel.DELFLAG = 0;
                    //时间
                    personalModel.DATETIME = DateTime.Now;
                    personalModel.UserID = userModel.ID.ToString();
                    personalBll.Add(personalModel);
                    //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('添加成功');location.href='Test.aspx';", true);
                   
                    //添加操作日志
                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加人员", "添加成功");
                    Response.Redirect("Test.aspx");
                }
                else
                {
                   // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('您输入的开始时间和结束时间前后有误！请重新操作！');", true);
                    this.Labeltext.Text = "您输入的时间前后有误！请重新操作！";
                }
            }
            catch (Exception)
            {
                //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('添加失败！请重新操作！');", true);
                this.Labeltext.Text = "添加失败！请重新操作！";
            }
        }
        //返回按钮
        protected void Button_back_Click(object sender, EventArgs e)
        {

            Response.Redirect("Test.aspx");
        }
        /// <summary>
        /// 对开始时间和结束时间进行判断，开始时间不能大于结束时间，两个时间都不能为空
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        private bool  checkDate(string startTime, string endTime)
        {
            bool coutw = false;
            try
            {
                if (startTime.Length > 0 && endTime.Length>0)
                {
                    if (DateTime.Parse(startTime) >= DateTime.Parse(endTime))
                    {
                        coutw = false;
                    }
                    else
                    {
                        coutw = true;
                    }
                }
                else
                {
                    coutw = false;
                }
            }
            catch
            {
            }
            return coutw;
        }
        //添加并继续
        protected void Button_goon_Click(object sender, EventArgs e)
        {
            try
            {
                userModel = (Dianda.Model.USER_Users)Session["USER_Users"];
                //string SY_DATUM ="";
                string dateTime = TB_DateTime.Value.ToString();
                string dateTime1 = TB_DateTime1.Value.ToString();
                //日期
                personalModel.DATETIME = Convert.ToDateTime(dateTime);
                //标题
                personalModel.NAMES = TextBox_Title.Text.ToString();
                //内容
                //personalModel.Overviews = TextBox_Content.Text.ToString();
                //获得开始时间
                string startTime = dateTime + " " + ddl_Part.SelectedValue.ToString() + ":" + ddl_second.SelectedValue.ToString() + ":00";
                //获得结束时间
                string endTime = dateTime1 + " " + ddl_Part1.SelectedValue.ToString() + ":" + ddl_second1.SelectedValue.ToString() + ":00";
                if (checkDate(startTime, endTime))
                {
                    personalModel.StartTime = Convert.ToDateTime(startTime);
                    personalModel.EndTime = Convert.ToDateTime(endTime);
                    //计划状态;
                    personalModel.Status = 0;
                    //状态
                    personalModel.DELFLAG = 0;
                    //时间
                    personalModel.DATETIME = DateTime.Now;
                    personalModel.UserID = userModel.ID.ToString();
                    personalBll.Add(personalModel);
                    //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('添加成功');location.href='Test.aspx';", true);

                    //添加操作日志
                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加人员", "添加成功");
                    Response.Redirect("add.aspx?statue=0");
                }
                else
                {
                    // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('您输入的开始时间和结束时间前后有误！请重新操作！');", true);
                    this.Labeltext.Text = "您输入的时间前后有误！请重新操作！";
                }
            }
            catch (Exception)
            {
                //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('添加失败！请重新操作！');", true);
                this.Labeltext.Text = "添加失败！请重新操作！";
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
                //具体业务描述：
                //开始时间如果为：8点30分至11点30分，结束时间自动设置为：11点30分 
                //开始时间如果为：13点至30分至16点30，结束时间自动设置为：16点30分 
                //开始时间：其它时段，结束时间：开始时间基础上加2小时


                //开始日期 天
                string  begindate =TB_DateTime.Value.ToString();
                //开始日期 时
                string beginhour = ddl_Part.SelectedValue.ToString();
                //开始日期 秒
                string beginsecond = ddl_second.SelectedValue.ToString();

                DateTime begintime = Convert.ToDateTime(begindate+" "+beginhour+":"+beginsecond);

                DateTime begintime1 = Convert.ToDateTime(begindate+" 08:30");
                DateTime begintime2 = Convert.ToDateTime(begindate+" 11:30");
                DateTime begintime3 = Convert.ToDateTime(begindate+" 13:30");
                DateTime begintime4 = Convert.ToDateTime(begindate+" 16:30");

                DateTime endtime = begintime.AddHours(2);

                //结束日期 天
                TB_DateTime1.Value = endtime.Year.ToString()+"-"+endtime.Month.ToString()+"-"+endtime.Day.ToString();

                if(begintime1<=begintime&&begintime<begintime2)
                {
                    //结束日期 时
                    ddl_Part1.SelectedValue = "11";
                    //结束日期 秒
                    ddl_second1.SelectedValue = "30";

                }
                else if (begintime3 <= begintime && begintime < begintime4)
                {
                    //结束日期 时
                    ddl_Part1.SelectedValue = "16";
                    //结束日期 秒
                    ddl_second1.SelectedValue = "30";
                }else
                {
                    //结束日期 时
                    ddl_Part1.SelectedValue = endtime.Hour.ToString().Length < 2 ? "0" + endtime.Hour.ToString() : endtime.Hour.ToString();
                    //结束日期 秒
                    ddl_second1.SelectedValue = endtime.Minute.ToString().Length< 2 ? "0" + endtime.Minute.ToString() : endtime.Minute.ToString();


                }
            }
            catch
            { }
        }
    }
}
