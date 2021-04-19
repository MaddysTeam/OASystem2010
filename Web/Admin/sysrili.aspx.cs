using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin
{
    public partial class sysrili : System.Web.UI.Page
    {
        BLL.Term_Diary btdiary = new Dianda.BLL.Term_Diary();
        Dianda.Model.USER_Users userModel = new Dianda.Model.USER_Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<Model.Term_Diary> mtdiary = btdiary.GetModelList("DELFLAG=0 AND isWork=1");
                    if (mtdiary.Count > 0)
                    {
                        starttime.Value = mtdiary[0].FirstWeek.Value.ToString("yyyy-MM-dd");
                        endtime.Value=mtdiary[0].LastWeek.Value.ToString("yyyy-MM-dd");
                    }
                    (Master.FindControl("Label_navigation") as Label).Text = " 管理 > 学期管理";
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 设置当前的学期开始时间和结束时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_queding_Click(object sender, EventArgs e)
        {
            string coutw = "";
            try
            {
              
                string starttimes = starttime.Value.ToString();//开始时间
                string endtimess = endtime.Value.ToString();
                if (starttimes.Length > 0 && endtimess.Length > 0)
                {
                    DateTime starttimedate = DateTime.Parse(starttimes);
                    DateTime endtimedate = DateTime.Parse(endtimess);
                    if (starttimedate>= endtimedate)
                    {
                        coutw = "*失败！设置的时间中，开始时间不能大于等于结束时间！";
                    }
                    else
                    {
                        //判断开始时间是不是星期一，判断结束时间星期天
                        if (starttimedate.DayOfWeek.ToString() != "Monday")
                        {
                            coutw = "*失败！设置的时间中，开始时间必须是一个星期中的星期一！";
                        }
                        else
                        {
                            if (endtimedate.DayOfWeek.ToString() != "Sunday")
                            {
                                coutw = "*失败！设置的时间中，结束时间必须是一个星期中的星期天！";
                            }
                            else
                            {
                                //可以添加
                                   List<Model.Term_Diary> mtdiary = btdiary.GetModelList("DELFLAG=0 AND isWork=1");
                                   if (mtdiary.Count > 0)
                                   {
                                       mtdiary[0].FirstWeek = starttimedate;
                                       mtdiary[0].LastWeek = endtimedate;
                                       btdiary.Update(mtdiary[0]);
                                       coutw = "*成功！";
                                   }
                                   else
                                   {
                                       userModel = (Model.USER_Users)Session["USER_Users"];//实例化
                                       mtdiary[0].FirstWeek = starttimedate;
                                       mtdiary[0].LastWeek = endtimedate;
                                       mtdiary[0].CONTENTS = "";
                                       mtdiary[0].DATETIME = DateTime.Now;
                                       mtdiary[0].DELFLAG = 0;
                                       mtdiary[0].isWork = 1;
                                       mtdiary[0].UserID = userModel.USERNAME.ToString();
                                       btdiary.Add(mtdiary[0]);
                                       coutw = "*成功！";
                                   }
                            }
                        }
                    }
                }
                else
                {
                    coutw = "*失败！请输入开始时间和结束时间！";
                }
            }
            catch
            {
            }
            Label_notice.Text = coutw;
        }
    }
}
