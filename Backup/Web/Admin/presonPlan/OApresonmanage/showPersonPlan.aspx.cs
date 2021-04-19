using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.presonPlan.OApresonmanage
{
    public partial class showPersonPlan : System.Web.UI.Page
    {
        Model.Personal_Plan mPlan = new Dianda.Model.Personal_Plan();
        Dianda.Model.Personal_Plan personalModel = new Dianda.Model.Personal_Plan();
        BLL.Personal_Plan bPlan = new Dianda.BLL.Personal_Plan();
        Model.USER_Users userModel = new Dianda.Model.USER_Users();
        Dianda.BLL.Personal_Plan personalBll = new Dianda.BLL.Personal_Plan();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string id = Request.QueryString["ID"];
                mPlan = new Dianda.Model.Personal_Plan();
                mPlan = bPlan.GetModel(Int32.Parse(id ));
                if (mPlan != null)
                {
                  
                    TextBox_Title.Text = mPlan.NAMES.ToString();
                    TB_DateTime.Value = DateTime.Parse(mPlan.StartTime.ToString()).ToString("yyyy-MM-dd");
                    ddl_Part.SelectedValue= pubstr(DateTime.Parse(mPlan.StartTime.ToString()).Hour.ToString());
                    ddl_second.SelectedValue = pubstr(DateTime.Parse(mPlan.StartTime.ToString()).Minute.ToString());
                    TB_DateTime1.Value = DateTime.Parse(mPlan.EndTime.ToString()).ToString("yyyy-MM-dd");
                    ddl_Part1.SelectedValue =pubstr(DateTime.Parse(mPlan.EndTime.ToString()).Hour.ToString());
                    ddl_second1.SelectedValue =pubstr(DateTime.Parse(mPlan.EndTime.ToString()).Minute.ToString());
                    //TextBox_Content.Text = mPlan.Overviews.ToString();
                    if (mPlan.DELFLAG == 0)
                    {
                        if (mPlan.Status == 0)
                        {
                          
                            RadioButton5.Checked = true;
                        }
                        else if (mPlan.Status == 1)
                        {
                           
                            RadioButton6.Checked = true;
                        }
                        else
                        {
                           
                            RadioButton7.Checked = true;
                        }
                    }
                    else
                    {
                       
                        RadioButton8.Checked = true;
                    }

                }
                else
                {
                  
                  
                   // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('对不起！没有您的信息！');location.href='Test.aspx';", true);
                    Labeltext.Text = "对不起！没有您的信息！";
                }


            }
        }
        /// <summary>
        /// 对开始时间和结束时间进行判断，开始时间不能大于结束时间，两个时间都不能为空
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        private bool checkDate(string startTime, string endTime)
        {
            bool coutw = false;
            try
            {
                if (startTime.Length > 0 && endTime.Length > 0)
                {
                    if (DateTime.Parse(startTime) >=DateTime.Parse(endTime))
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

        //更新
        protected void Button_update_Click1(object sender, EventArgs e)
        {
            try
            {
                userModel = (Dianda.Model.USER_Users)Session["USER_Users"];
                //string SY_DATUM ="";
                string dateTime = TB_DateTime.Value.ToString();
                string dateTime1 = TB_DateTime1.Value.ToString();
                personalModel = personalBll.GetModel(Int32.Parse(Request.QueryString["id"]));
                //日期
                personalModel.DATETIME = Convert.ToDateTime(dateTime);
                //标题
                personalModel.NAMES = TextBox_Title.Text.ToString();
                //内容
               //personalModel.Overviews = TextBox_Content.Text.ToString();
                //获得开始时间
                string startTime = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd") + " " + ddl_Part.SelectedValue.ToString() + ":" + ddl_second.SelectedValue.ToString() + ":00";
                //获得结束时间
                string endTime = Convert.ToDateTime(dateTime1).ToString("yyyy-MM-dd") + " " + ddl_Part1.SelectedValue.ToString() + ":" + ddl_second1.SelectedValue.ToString() + ":00";
                if (checkDate(startTime, endTime))
                {
                    personalModel.StartTime = Convert.ToDateTime(startTime);
                    personalModel.EndTime = Convert.ToDateTime(endTime);

                    //时间
                    personalModel.DATETIME = DateTime.Now;
                    personalModel.UserID = userModel.ID.ToString();
                    //计划状态;
                   
                    if (RadioButton6.Checked)
                    {
                        personalModel.Status = 1;
                    }
                    else if (RadioButton7.Checked)
                    {
                        personalModel.Status = 3;
                    }
                    else
                    {
                        personalModel.Status = 0;
                    }
                    //操作编辑
                    //状态
                    if (this.RadioButton8.Checked)
                    {
                        personalBll.Delete(Int32.Parse(Request.QueryString["id"]));
                       // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('删除成功');location.href='Test.aspx';", true);
                        //Labeltext.Text = "删除成功！请返回！";
                        Response.Redirect("Test.aspx");
                    }
                    else
                    {
                        personalBll.Update(personalModel);
                       // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('修改成功');location.href='Test.aspx';", true);
                       // Labeltext.Text = "修改成功！请返回！";
                        Response.Redirect("Test.aspx");
                    }
                    //添加操作日志
                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "修改人员", "修改成功");
                  
                   
                }
                else
                {
                    Labeltext.Text = "您输入的时间前后有误！请重新操作！";
                    // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('您输入的开始时间和结束时间前后有误！请重新操作！');", true);
                }
            }
            catch (Exception)
            {
               // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "alert('修改失败！请重新操作！');", true);
                Labeltext.Text = "修改失败！请重新操作！";
            }
        }
        //判断字符串长度
        public string pubstr(string str)
        {

            if (str.Length <= 1)
            {
                str = "0" + str;
            }

            return str;
        }
        //截取字符串
        public string substr(object str)
        {
            string substr2 = Convert.ToString(str);
            if (substr2.Length > 25)
            {
                substr2 = substr2.Remove(25) + "...";
            }
            return substr2;
        }
        //返回
        protected void Button_getback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Test.aspx");
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
                string begindate = TB_DateTime.Value.ToString();
                //开始日期 时
                string beginhour = ddl_Part.SelectedValue.ToString();
                //开始日期 秒
                string beginsecond = ddl_second.SelectedValue.ToString();

                DateTime begintime = Convert.ToDateTime(begindate + " " + beginhour + ":" + beginsecond);

                DateTime begintime1 = Convert.ToDateTime(begindate + " 08:30");
                DateTime begintime2 = Convert.ToDateTime(begindate + " 11:30");
                DateTime begintime3 = Convert.ToDateTime(begindate + " 13:30");
                DateTime begintime4 = Convert.ToDateTime(begindate + " 16:30");

                DateTime endtime = begintime.AddHours(2);

                //结束日期 天
                TB_DateTime1.Value = endtime.Year.ToString() + "-" + endtime.Month.ToString() + "-" + endtime.Day.ToString();

                if (begintime1 <= begintime && begintime < begintime2)
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
                }
                else
                {
                    //结束日期 时
                    ddl_Part1.SelectedValue = endtime.Hour.ToString().Length < 2 ? "0" + endtime.Hour.ToString() : endtime.Hour.ToString();
                    //结束日期 秒
                    ddl_second1.SelectedValue = endtime.Minute.ToString().Length < 2 ? "0" + endtime.Minute.ToString() : endtime.Minute.ToString();


                }
            }
            catch
            { }
        }
       
    }
}
