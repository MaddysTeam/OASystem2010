using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Configuration;

namespace WBS001
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        Dianda.BLL.Personal_Plan bllPersonalPlan = new Dianda.BLL.Personal_Plan();
        Dianda.Model.Personal_Plan Personal_Plan_model = new Dianda.Model.Personal_Plan();
        Dianda.Model.USER_Users userModel = new Dianda.Model.USER_Users();
        Dianda.BLL.USER_Users usersBll = new Dianda.BLL.USER_Users();
        Dianda.COMMON.pageControl dosql = new Dianda.COMMON.pageControl();
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        
        [WebMethod(Description = "返回指定ID用户的在开始时间和结束时间范围内的个人计划、任务列表.0表示未开始；status=1表示进行中；2表示完成；3表示延期")]
        public string getDateInfo(string userId, string startDay1, string endData1)
        {
            string couw = "";
            try
            {
                DateTime startDay = DateTime.Parse(startDay1);
                DateTime endData = DateTime.Parse(endData1);
                //用户的计划包括个人计划和项目任务，而且数据
                userId = commons.RequestSafeString(userId, 50);
                startDay =DateTime.Parse(startDay.ToString("yyyy-MM-dd")+" 00:00:00");
                endData = DateTime.Parse(endData.ToString("yyyy-MM-dd") + " 23:59:59"); 
                DateTime s=DateTime.Parse(startDay.ToString("yyyy-MM-dd"));
                DateTime e= DateTime.Parse(endData.ToString("yyyy-MM-dd"));
                int i =int.Parse(commons.DateDiff(s, e));
                if (i >= 0)
                {
                    for (int j = 0; j <= i;j++)
                    {
                        DateTime s1 = DateTime.Parse(s.AddDays(j).ToString("yyyy-MM-dd") + " 00:00:00");
                        //DateTime e1 = DateTime.Parse(s.AddDays(j).ToString("yyyy-MM-dd") + " 23:59:59");
                        couw =couw+ "<day date=\"" + s.AddDays(j).ToString("yyyy-MM-dd") + "\">";
                        couw = couw + getPersonal_Plan(userId, s1);
                        couw = couw + getProject_Plan(userId, s1);
                        couw = couw + "</day>";
                    }
                }
            }
            catch
            {
            }
            return couw;
        }
        /// <summary>
        /// 返回指定ID用户的在开始时间和结束时间范围内的个人计划
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startDay"></param>
        /// <param name="endData"></param>
        /// <returns></returns>
        private string getPersonal_Plan(string userId, DateTime startDay)
        {
            string couw = "";
            try
            {
                    List<Dianda.Model.Personal_Plan> planlist = bllPersonalPlan.GetModelList("Delflag = '0' and Status <> 2 and  UserID = '" + userId + "' and  '" + startDay.ToString("yyyy-MM-dd") + "' BETWEEN CAST(CONVERT(varchar(10), StartTime, 120) + ' 00:00:00' AS datetime) AND CAST(CONVERT(varchar(10), EndTime, 120) + ' 23:59:59' AS datetime)   order by StartTime asc");
                    if (planlist != null && planlist.Count>0)
                    {
                         couw = "<plan>";
                        for (int i = 0; i < planlist.Count; i++)
                        {
                            couw = couw + "<info startTime=\"" + planlist[i].StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "\" endTime=\"" + planlist[i].EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "\" url=\"showPersonPlan.aspx?ID=" + planlist[i].ID.ToString() + "\"  PersonalId=\"" + planlist[i].ID.ToString() + "\"  status=\"" + planlist[i].Status.ToString() + "\">" + planlist[i].NAMES.ToString() + "</info>";
                        }
                        couw =couw+ "</plan>";
                    }
            }
            catch
            {
            }
            return couw;
        }
        /// <summary>
        /// 返回指定ID用户的在开始时间和结束时间范围内的项目任务
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startDay"></param>
        /// <param name="endData"></param>
        /// <returns></returns>
        private string getProject_Plan(string userId, DateTime startDay)
        {
            string couw = "";
            try
            {
            
                    userModel = usersBll.GetModel(userId);
                    if (userModel != null)
                    {
                        string sql = "select  * from vProject_Task where Pro_DELFLAG='0' and Pro_Status=1 and  '" + startDay.ToString("yyyy-MM-dd")+ "'  BETWEEN CAST(CONVERT(varchar(10), StartTime, 120) + ' 00:00:00' AS datetime) AND CAST(CONVERT(varchar(10), endTime, 120) + ' 23:59:59' AS datetime)  and delflag = '0' and Status <> 2 and userInfo Like '%" + userModel.REALNAME.ToString() + "(" + userModel.USERNAME.ToString() + ")" + "%' order by StartTime asc";
                        DataTable dt = dosql.doSql(sql).Tables[0];
                        if (dt != null&&dt.Rows.Count>0)
                        {
                            couw = "<task>";
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                couw = couw + "<info startTime=\"" + DateTime.Parse(dt.Rows[i]["StartTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "\" endTime=\"" + DateTime.Parse(dt.Rows[i]["endTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "\" url=\"/Admin/personalProjectManage/OAtask/manage.aspx?ID=" + dt.Rows[i]["ProjectID"].ToString() + "\" status=\"" + dt.Rows[i]["Status"].ToString() + "\">" + dt.Rows[i]["NAMES"].ToString() + "</info>";
                            }
                            couw = couw + "</task>";
                        }
                    }
                
            }
            catch
            {
            }
            return couw;
        }

        [WebMethod(Description = "根据登陆者的用户名和密码从OA中找到该登陆者的基本信息。<br>。<br>字段说明：<br>■string userName 用户名<br>■string pwd 密码<br>■string key 按约定的加密方法进行加密后的值")]
        public DataSet checkUser(string username, string pwd, string keys)
        {
            DataSet ds = new DataSet();
            try
            {
                username = commons.RequestSafeString(username, 50);
                pwd = commons.RequestSafeString(pwd, 50);
                pwd = commons.GetMD5(pwd);//加密
                string timenow = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " 00:00:00";
                string month = DateTime.Now.Month.ToString();
                if (month.Length == 1)
                {
                    month = "0" + month;
                }
                string days = DateTime.Now.Day.ToString();
                if (days.Length == 1)
                {
                    days = "0" + days;
                }
                string decryptTime = DateTime.Now.Year.ToString() + month + days;
                string keysnow = commons.Encrypt(timenow, decryptTime);

                //string keysnow = keys;

                if (keys == keysnow)
                {
                    ds = usersBll.GetList("USERNAME='" + username + "' and PASSWORD='" + pwd + "' and DELFLAG=0");
                }
                else
                {
                    ds = null;

                }
            }
            catch
            {
                ds = null;
            }
            return ds;
        }
        [WebMethod(Description = "根据输入的likeValue模糊查询用户信息。<br>字段说明：<br>■string likeValue 用户名、用户真实姓名模糊查询<br>■string key 按约定的加密方法进行加密后的值")]
        public DataSet getPerson(string likeValue, string keys)
        {
            DataSet ds = new DataSet();
            try
            {
                likeValue = commons.RequestSafeString(likeValue, 50);
                string timenow = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " 00:00:00";
                string month = DateTime.Now.Month.ToString();
                if (month.Length == 1)
                {
                    month = "0" + month;
                }
                string days = DateTime.Now.Day.ToString();
                if (days.Length == 1)
                {
                    days = "0" + days;
                }
                string decryptTime = DateTime.Now.Year.ToString() + month + days;
                string keysnow = commons.Encrypt(timenow, decryptTime);

                //string keysnow = keys;

                if (keys == keysnow)
                {
                    ds = usersBll.GetList("(USERNAME like '%" + likeValue + "%' or REALNAME like '%" + likeValue + "%') and DELFLAG=0");
                }
                else
                {
                    ds = null;

                }
            }
            catch
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "根据返回的ID，去更改个人计划")]
        public bool UpdatePersonal_Plan(string ID, string title, string starttime, string endtime, string userId)
        {
            bool couw = true;
            try
            {
                //表示修改
                if (null != ID && !ID.Equals(""))
                {
                    DateTime startDateTime = DateTime.Parse(starttime);
                    DateTime endDateTime = DateTime.Parse(endtime);

                    Personal_Plan_model = bllPersonalPlan.GetModel(int.Parse(ID));

                    //更新个人计划标题
                    Personal_Plan_model.NAMES = title;
                    //开始时间
                    Personal_Plan_model.StartTime = startDateTime;
                    //结束时间
                    Personal_Plan_model.EndTime = endDateTime;
                    //发布时间（修改时间）
                    Personal_Plan_model.DATETIME = DateTime.Now;

                    //更新计划
                    bllPersonalPlan.Update(Personal_Plan_model);
                }
                else
                {
                    DateTime startDateTime = DateTime.Parse(starttime);
                    DateTime endDateTime = DateTime.Parse(endtime);

                    //个人计划标题
                    Personal_Plan_model.NAMES = title;
                    //开始时间
                    Personal_Plan_model.StartTime = startDateTime;
                    //结束时间
                    Personal_Plan_model.EndTime = endDateTime;
                    //发布时间（添加时间）
                    Personal_Plan_model.DATETIME = DateTime.Now;
                    //状态
                    Personal_Plan_model.Status = 0;
                    //添加用户
                    Personal_Plan_model.UserID = userId;
                    //删除标记
                    Personal_Plan_model.DELFLAG = 0;
                    //计划描述
                    Personal_Plan_model.Overviews = "";

                    //添加计划
                    bllPersonalPlan.Add(Personal_Plan_model);
                }

            }
            catch
            {
                couw = false;
            }
            return couw;
        }
    }
}
