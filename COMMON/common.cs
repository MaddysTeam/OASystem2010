using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;
 
namespace Dianda.COMMON
{
    public class common
    {

        ////////////////////////
        /// <summary>
        /// 构造ID的GUID码
        /// </summary>


        public string GetGUID()
        {
            Guid g = Guid.NewGuid();
            string g1 = g.ToString();
            // string g2 = g1.Substring(0,30);
            DateTime dt = DateTime.Now;
            string g1befor = dt.Year.ToString() + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");
            return g1befor+g1;
        }
        //构造ID的GU码


        /// <summary>
        /// 获取随机6位数密码
        /// </summary>


        public string GetPwd()
        {
            Guid g = Guid.NewGuid();
            string g1 = g.ToString();
            string g2 = g1.Substring(0, 6);
            return g2;
        }
        //获取随机6位数密码

        /// <summary>
        /// 构造MD5加密的11位加密码
        /// </summary>

        public string GetMD5(string PWD)
        {
            string PWD_1 = SafeString(PWD);
            string PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PWD_1, "MD5").Substring(0, 11).ToString();
            return PassWord;
        }
        //构造MD5加密的11位加密码


        /// <summary>
        ///字符串截取函数
        /// </summary>


        public string MakeStringLength(string StringW, int Len)
        {
            string doString = "";
            try
            {
                doString = System.Text.RegularExpressions.Regex.Replace(StringW, "<[^>]*>", "").ToString();

                if (doString.Length > Len)
                {
                    doString = doString.Substring(0, Len) + "...";
                }
            }
            catch
            {
            }

            return doString;
        }
        //字符串截取函数




        /// <summary>
        ///根据00:40格式的时间换算成以秒40秒格式的数据:TYPEs为 "00:00"将00：40转化为40；为"00"将40转化为00：40
        /// </summary>


        //根据00:40格式的时间换算成以秒40秒格式的数据
        public string TimeChange(string time, string types)
        {
            string TimeString = "";
            double temp = 0;
            try
            {
                if (types == "00:00")//将00：40转化为40
                {
                    string[] TimeStringArray = time.Split(':');
                    for (int loop = TimeStringArray.Length - 1; loop > -1; loop--)
                    {
                        temp = temp + Convert.ToDouble(TimeStringArray[loop]) * (System.Math.Pow(60, TimeStringArray.Length - loop - 1));
                    }
                    TimeString = temp.ToString();
                }
                else if (types == "00")//将40转化为00：40
                {
                    Int64 HOURS = 0;
                    Int64 Minute = 0;
                    Int64 Seconds = 0;
                    Int64 times = Convert.ToInt64(time);
                    HOURS = times / 3600;
                    if (HOURS != 0)// have hours 
                    {
                        //  HOURS = HOURS;//hours
                        times = times - HOURS * 3600;
                        Minute = times / 60;
                        if (Minute != 0)//have Minute
                        {
                            // Minute = Minute;//minute
                            times = times - Minute * 60;
                            Seconds = times;
                        }
                        if (Minute == 0)
                        {
                            Minute = 0;
                            Seconds = times;
                        }
                        TimeString = HOURS.ToString() + ":" + Minute.ToString() + ":" + Seconds.ToString();
                    }
                    else if (HOURS == 0)
                    {
                        HOURS = 0;
                        Minute = times / 60;
                        if (Minute != 0)//have Minute
                        {
                            // Minute = Minute;//minute
                            times = times - Minute * 60;
                            Seconds = times;
                        }
                        if (Minute == 0)
                        {
                            Minute = 0;
                            Seconds = times;

                        }
                        TimeString = Minute.ToString() + ":" + Seconds.ToString();
                    }



                }
            }
            catch
            {
                TimeString = "";
            }
            return TimeString;
        }

        //





        //根据00:40格式的时间换算成以秒40秒格式的数据
        /// <summary>
        /// 将获取的值进行安全性处理
        /// </summary>
        /// <param name="olderString">获取的值</param>
        /// <param name="length">正常情况下，值应该是多长，如果不做值的长度处理，这里设置为0</param>
        /// <returns></returns>
        public string RequestSafeString(string olderString, int lengths)
        {
            string coutw = "";
            try
            {
                olderString = olderString.Trim();
                olderString = SafeString(olderString);
                if (lengths == 0)
                {
                  
                }
                else
                {
                    if (olderString.Length > lengths)
                    {
                        olderString = olderString.Substring(0, lengths);

                    }
                }
                coutw = olderString;
            }
            catch
            {
                coutw = "";
            }
            return coutw;
        }


        //////////////////////防止SQL注入的通用函数
        public string SafeString(string olderString)
        {
            string newString = "";
            string older = olderString;
            if (older.Length != 0)
            {
                try
                {
                    newString = Microsoft.VisualBasic.Strings.Replace(older, "'", "", 1, -1, CompareMethod.Text);// older.Replace("'", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "<", "", 1, -1, CompareMethod.Text);// newString.Replace("<", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "*", "", 1, -1, CompareMethod.Text);// newString.Replace("*", "");
                    //newString = Microsoft.VisualBasic.Strings.Replace(newString, "/", "", 1, -1, CompareMethod.Text);// newString.Replace("/", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "\\", "", 1, -1, CompareMethod.Text);// newString.Replace("\\", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, ">", "", 1, -1, CompareMethod.Text);// newString.Replace(">", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "&", "", 1, -1, CompareMethod.Text);// newString.Replace("&", "&amp;");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "%", "", 1, -1, CompareMethod.Text);// newString.Replace("%", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "select", "", 1, -1, CompareMethod.Text);//newString.Replace("select", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "insert", "", 1, -1, CompareMethod.Text);//newString.Replace("insert", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "update", "", 1, -1, CompareMethod.Text);// newString.Replace("update", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "delete", "", 1, -1, CompareMethod.Text);// newString.Replace("delete", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "create", "", 1, -1, CompareMethod.Text);// newString.Replace("create", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "drop", "", 1, -1, CompareMethod.Text);// newString.Replace("drop", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "declare", "", 1, -1, CompareMethod.Text);// newString.Replace("delcare", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "exec", "", 1, -1, CompareMethod.Text);// newString.Replace("%3B 想当与；", "");
                    //newString = Microsoft.VisualBasic.Strings.Replace(newString, "-", "", 1, -1, CompareMethod.Text);//newString.Replace("-", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "and", "", 1, -1, CompareMethod.Text);// newString.Replace("and", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "or", "", 1, -1, CompareMethod.Text);// newString.Replace("or", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "(", "", 1, -1, CompareMethod.Text);// newString.Replace("(", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, ")", "", 1, -1, CompareMethod.Text);// newString.Replace(")", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "\"", "", 1, -1, CompareMethod.Text);// newString.Replace("\"", "");
                }
                catch
                {
                }

            }
            else if (older.Length == 0)
            {
                newString = "";
            }
            return newString;
        }


        public static string CheckStr = "'|<|>|alert|script|(|)|\"";
        public static string[] list = CheckStr.Split('|');
        /// <summary>
        /// 检测请求的参数格式
        /// </summary>
        /// <param name="olderString"></param>
        /// <returns></returns>
        public bool CheckRequest(string olderString)
        {
            bool flag = true;
            for (int i = 0; i < CheckStr.Length; i++)
            {
                if (olderString.IndexOf(CheckStr[i]) > 0)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        /// <summary>
        /// 去除请求参数的敏感字符
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string cleanXSS(string value)
        {
                string newsstr = "";
                if (value.Length != 0)
                {
                    newsstr = value.Replace(" ", "");
                    newsstr = newsstr.Replace("alert", "");
                    newsstr = newsstr.Replace("script", "");
                    newsstr = newsstr.Replace("<", "");
                    newsstr = newsstr.Replace(">", "");
                    newsstr = newsstr.Replace("/", "");
                    newsstr = newsstr.Replace("(", "");
                    newsstr = newsstr.Replace(")", "");
                    newsstr = newsstr.Replace("\\", "");
                    newsstr = newsstr.Replace("\"", "");
                    newsstr = newsstr.Replace("\\\"", "");
                    newsstr = newsstr.Replace("'", "");
                    newsstr = newsstr.Replace("=", "");
                    newsstr = newsstr.Replace(":", "");
                    newsstr = newsstr.Replace("+", "");
                    newsstr = newsstr.Replace("{", "");
                    newsstr = newsstr.Replace("}", "");
                    newsstr = newsstr.Replace("toString", "");
                    newsstr = newsstr.Replace("aalertlert", "");
                    newsstr = newsstr.Replace("onmouseover", "");
                }
                else
                {
                    newsstr = "";
                }
                return newsstr;
            
        }


        ///<summary>
        ///获取客户端的IP地址
        ///</summary>
        public string GetClientIpAddress(string context)
        {
            string result = String.Empty;
            if (context == null)
            {
                return "000.000.000.000";
            }

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            return result;
        }


        ///<summary>
        ///检测EMAIL的格式是否正确
        ///</summary>
        public bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        /// <summary>
        /// 字符串切割组成SELECT IN 的字符串
        /// </summary>
        /// <param name="districtid"></param>
        /// <returns></returns>
        public string coutSelectIn(string districtid, char type)
        {
            string[] IDS = districtid.Split(type);
            string IDString = "(";
            for (int i = 0; i < IDS.Length; i++)
            {
                if (i == IDS.Length - 1)
                {
                    IDString = IDString + "'" + IDS[i].ToString() + "'";
                }
                else
                {
                    IDString = IDString + "'" + IDS[i].ToString() + "',";
                }
            }
            IDString = IDString + ")";
            return IDString;
        }
        /// <summary>
        /// 获取系统设置的上传附件的大小
        /// </summary>
        /// <returns></returns>
        public string getSysFileSize()
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings["fileSizeControl"].ToString();
            }
            catch
            {
                return "20";
            }
        }

        /// <summary>
        /// 获取到系统中可以上传的文件类型数组(不区分大小写)
        /// typeName=imagesArray|vodioArray_flah|vodioArray_wmp3|vodioArray_rm|filesArray
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public string[] getSysFileType(string typeName)
        {
            string[] imagesArray = { ".gif", ".jpg", ".jpeg", ".bmp", ".png", "psd" };
            string[] vodioArray_flah = { ".swf" };
            string[] vodioArray_wmp3 = { ".wmv", ".wma", ".mp3", ".mpg", ".mpeg", ".asf", ".mp4" };
            string[] vodioArray_rm = { ".avi", ".rmvb", ".rm" };
            string[] filesArray = { ".doc", ".htm", ".xls", ".html", ".mht", ".ppt", ".pdf", ".txt", ".docx", ".xlsx", ".rar", ".zip" };

            if (typeName == "imagesArray")
            {
                return imagesArray;
            }
            if (typeName == "vodioArray_flah")
            {
                return vodioArray_flah;
            }
            if (typeName == "vodioArray_wmp3")
            {
                return vodioArray_wmp3;
            }
            if (typeName == "vodioArray_rm")
            {
                return vodioArray_rm;
            }
            if (typeName == "filesArray")
            {
                return filesArray;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 删除DATATABLE中的指定行
        /// </summary>
        /// <param name="older"></param>
        /// <param name="rowi"></param>
        /// <returns></returns>
        public DataTable dataTabelDelRowi(DataTable older, int rowi)
        {
            DataTable newDataTable = older.Clone();
            try
            {
                object[] obj = new object[newDataTable.Columns.Count];
                for (int i = 0; i < older.Rows.Count; i++)
                {
                    if (i != rowi)
                    {
                        older.Rows[i].ItemArray.CopyTo(obj, 0);
                        newDataTable.Rows.Add(obj);
                    }

                }

                return newDataTable;
            }
            catch
            {
                return newDataTable;
            }
        }

        /// <summary>
        /// 合并两个相同结构的DATATABLE
        /// </summary>
        /// <param name="DataTable1"></param>
        /// <param name="DataTable2"></param>
        /// <returns></returns>
        public DataTable CombineTheSameDatatable(DataTable DataTable1, DataTable DataTable2)
        {
           
            DataTable tempdt = new DataTable();
            if (DataTable1 != null&&DataTable1.Rows.Count>0)
            {
                tempdt = DataTable1;
            }
            else
            {
                tempdt= DataTable2;
            }
            DataTable newDataTable = tempdt.Clone();
            try
            {
                object[] obj = new object[newDataTable.Columns.Count];

                if (null != DataTable1)
                {
                    for (int i = 0; i < DataTable1.Rows.Count; i++)
                    {
                        DataTable1.Rows[i].ItemArray.CopyTo(obj, 0);
                        newDataTable.Rows.Add(obj);
                    }
                }

                if (null != DataTable2)
                {
                    for (int i = 0; i < DataTable2.Rows.Count; i++)
                    {
                        DataTable2.Rows[i].ItemArray.CopyTo(obj, 0);
                        newDataTable.Rows.Add(obj);
                    }
                }
                return newDataTable;
            }
            catch
            {
                return newDataTable;
            }
        }
        /// <summary>
        /// 将一个DATATABLE中的重复项去除掉
        /// </summary>
        /// <param name="DataTable1">数据集1</param>
        /// <param name="tagNAME">指定的唯一建名称</param>
        /// <returns></returns>
        public DataTable makeDistinceTable(DataTable DataTable1,string tagNAME)
        {
            DataTable newDataTable = DataTable1.Clone();
            try
            {
              
                object[] obj = new object[newDataTable.Columns.Count];
                DataView dv = DataTable1.DefaultView;
                dv.Sort =tagNAME;
                string tagnamevalue = "";
                DataTable  DataTable2 = dv.ToTable();
                for (int i = 0; i < DataTable2.Rows.Count; i++)
                {
                   string tagnamevaluetemp = DataTable2.Rows[i][tagNAME].ToString();
                   if (tagnamevaluetemp == tagnamevalue)
                   {
                       //不做
                   }
                   else
                   {
                       DataTable2.Rows[i].ItemArray.CopyTo(obj, 0);
                       newDataTable.Rows.Add(obj);
                       tagnamevalue = tagnamevaluetemp;
                   }
                }
                return newDataTable;
            }
            catch
            {
                return newDataTable;
            }
        }
        /// <summary>
        /// 检测身份证号码，返回TRUE,FALSE
        /// </summary>
        /// <param name="sfz"></param>
        /// <returns></returns>
        public bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        private bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }



        //两个结构不同的DT合并
        /// <summary>
        /// 将两个列不同的DataTable合并成一个新的DataTable
        /// </summary>
        /// <param name="dt1">表1</param>
        /// <param name="dt2">表2</param>
        /// <param name="DTName">合并后新的表名</param>
        /// <returns></returns>
        private DataTable UniteDataTable(DataTable dt1, DataTable dt2, string DTName)
        {
            DataTable dt3 = dt1.Clone();
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                dt3.Columns.Add(dt2.Columns[i].ColumnName);
            }
            object[] obj = new object[dt3.Columns.Count];

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i].ItemArray.CopyTo(obj, 0);
                dt3.Rows.Add(obj);
            }

            if (dt1.Rows.Count >= dt2.Rows.Count)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            else
            {
                DataRow dr3;
                for (int i = 0; i < dt2.Rows.Count - dt1.Rows.Count; i++)
                {
                    dr3 = dt3.NewRow();
                    dt3.Rows.Add(dr3);
                }
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            dt3.TableName = DTName; //设置DT的名字
            return dt3;
        }
        /// <summary>
        /// 将英文的星期转化为中文的星期输出
        /// </summary>
        /// <param name="englishWeek"></param>
        /// <returns></returns>
        public string WeekToChinese(string englishWeek)
        {
            string coutw = "";
            string englishweeklow = englishWeek.ToLower();
            try
            {
                if (englishweeklow == "sunday")
                {
                    coutw = "星期日";
                }
                else if (englishweeklow == "monday")
                {
                    coutw = "星期一";
                }
                else if (englishweeklow == "tuesday")
                {
                    coutw = "星期二";
                }
                else if (englishweeklow == "wednesday")
                {
                    coutw = "星期三";
                }
                else if (englishweeklow == "thursday")
                {
                    coutw = "星期四";
                }
                else if (englishweeklow == "friday")
                {
                    coutw = "星期五";
                }
                else if (englishweeklow == "saturday")
                {
                    coutw = "星期六";
                }
                else
                {
                    coutw = englishWeek;
                }

            }
            catch
            {
                coutw = englishWeek;
            }
            return coutw;
        }
        /// <summary>
        /// 将原本2009-09-01 12：00：00的样式改成 2009-09-01样式
        /// </summary>
        /// <param name="olderTime">老的时间</param>
        /// <returns>转化后的时间格式</returns>
        public string ChangagedateTimeString(string olderTime)
        {
            string coutw = "";
            try
            {
                if (olderTime.Length > 0)
                {
                    DateTime dt = new DateTime();
                    dt = Convert.ToDateTime(olderTime);
                    string months = dt.Month.ToString();
                    string days = dt.Day.ToString();
                    if (months.Length == 1)
                    {
                        months = "0" + months;
                    }
                    if (days.Length == 1)
                    {
                        days = "0" + days;
                    }
                    coutw = dt.Year.ToString() + "-" + months + "-" + days;
                }
                else
                {
                    coutw = "0000-00-00";
                }
            }
            catch
            {
                coutw = "0000-00-00";
            }
            return coutw;
        }
        /// <summary>
        /// 将原本2009-09-01 12：00：00的样式改成 2009-09-01样式
        /// </summary>
        /// <param name="olderTime">老的时间</param>
        /// <returns>转化后的时间格式</returns>
        public string ChangagedateTimeString1(string olderTime)
        {
            string coutw = "";
            try
            {
                if (olderTime.Length > 0)
                {
                    DateTime dt = new DateTime();
                    dt = Convert.ToDateTime(olderTime);
                    string months = dt.Month.ToString();
                    string days = dt.Day.ToString();
                    if (months.Length == 1)
                    {
                        months = "0" + months;
                    }
                    if (days.Length == 1)
                    {
                        days = "0" + days;
                    }
                    coutw = dt.Year.ToString() + "-" + months + "-" + days;
                }
                else
                {
                    coutw = "0000-00-00";
                }
            }
            catch
            {
                coutw = "0000-00-00";
            }
            return coutw;
        }

        /// <summary>
        ///求两个日期之间的时间差（天）
        /// </summary>
        /// <param name="DateTime1">大的日期</param>
        /// <param name="DateTime2">小的日期</param>
        /// <returns></returns>
        public string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            // dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            dateDiff = ts.Days.ToString();
            return dateDiff;
        }
        /// <summary>
        ///求两个日期之间的时间差（小时）
        /// </summary>
        /// <param name="DateTime1">大的日期</param>
        /// <param name="DateTime2">小的日期</param>
        /// <returns></returns>
        public int HourDiff(DateTime DateTime1, DateTime DateTime2)
        {
            int dateDiff = 0;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            // dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            dateDiff =ts.Days*24+ts.Hours;
            return dateDiff;
        }
        /// <summary>
        /// 以theStander数组为模板，比较compareOne是否和该数组相等
        /// </summary>
        /// <param name="theStander">模板数组</param>
        /// <param name="compareOne">待比较数组</param>
        /// <returns></returns>
        public bool ArrayIsEquals(string[] theStander, string[] compareOne)
        {
            bool coutw = false;
            try
            {
                int m = 0;
                if (theStander.Length == compareOne.Length)
                {
                    for (int i = 0; i < theStander.Length; i++)
                    {

                        for (int j = 0; j < compareOne.Length; j++)
                        {
                            if (theStander[i].ToString() == compareOne[j].ToString())
                            {
                                m = m + 1;
                                break;
                            }
                            else
                            {
                                m = m + 0;
                            }
                        }
                    }
                    if (m == theStander.Length)
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

        /// <summary>
        ///  获取今天的日期types=1表示2009-06-06 星期六；2表示2009-06-06；3表示2009-06-06 00:00:00；4：2009年06月06日 星期六
        /// </summary>
        /// <param name="types">types=1表示2009-06-06 星期六；2表示2009-06-06；3表示2009-06-06 00:00:00</param>
        /// <returns>types=1表示2009-06-06 星期六；2表示2009-06-06；3表示2009-06-06 00:00:00；4：2009年06月06日 星期六</returns>
        public string getDays(string types)
        {
            string coutw = "";
            try
            {
                DateTime dtime = DateTime.Now;
                if (types == "1")
                {
                    coutw = dtime.Year.ToString() + "-" + dtime.Month.ToString() + "-" + dtime.Day.ToString() + " " + WeekToChinese(dtime.DayOfWeek.ToString());
                }
                else if (types == "2")
                {
                    coutw = dtime.Year.ToString() + "-" + dtime.Month.ToString() + "-" + dtime.Day.ToString();
                }
                else if (types == "3")
                {
                    coutw = dtime.Year.ToString() + "-" + dtime.Month.ToString() + "-" + dtime.Day.ToString() + " 00:00:00";
                }
                else if (types == "4")
                {
                    coutw = dtime.Year.ToString() + "年" + dtime.Month.ToString() + "月" + dtime.Day.ToString() + "日 " + WeekToChinese(dtime.DayOfWeek.ToString());
                }
            }
            catch
            {
                coutw = "NULL";
            }
            return coutw;

        }
        /// <summary>
        /// 将传入的时间转换成有星期的字符串
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string makeDateToDateAndWeek(string date)
        {
            string coutw = "";
            try
            {
                DateTime dt = DateTime.Parse(date);
                string weeks = WeekToChinese(dt.DayOfWeek.ToString());
                coutw = dt.Year.ToString() + "年" + dt.Month.ToString() + "月" + dt.Day.ToString() + "日 " + weeks;
            }
            catch
            {
            }

            return coutw;

        }
        /// <summary>
        /// 根据字符串进行切割，组合成select in ('fasd','fadsf')的in条件
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public string makeSqlIn(string strings, char spitWhat)
        {
            string coutw = "";
            try
            {
             
                if (strings.Length > 0)
                {   
                    //如果要处理的字符串最后一位也是分隔的字符，则提前将其去除掉
                    string lastchar = strings.Substring(strings.Length - 1, 1);
                    if (lastchar == spitWhat.ToString())
                    {
                        strings = strings.Substring(0, strings.Length - 1);
                    }

                    string[] arrays = strings.Split(spitWhat);
                    //消除字符串中的空值
                    string temp = "";
                    for (int j = 0; j < arrays.Length; j++)
                    {
                        if (arrays[j].Length > 0)
                        {
                            if (j == arrays.Length - 1)
                            {
                                temp = temp + arrays[j];
                            }
                            else
                            {
                                temp = temp + arrays[j] + ",";
                            }
                        }
                    }
                    string[] tempArrays = temp.Split(',');
                    //消除字符串中的空值

                    for (int i = 0; i < tempArrays.Length; i++)
                    {
                        if (i == tempArrays.Length - 1)
                        {
                            coutw = coutw + tempArrays[i].ToString();
                        }
                        else
                        {
                            coutw = coutw + tempArrays[i].ToString() + "','";
                        }
                    }
                    coutw = "('" + coutw + "')";
                }
                else
                {
                    coutw = "";
                }
            }
            catch
            {
                coutw = "";
            }
            return coutw;
        }

        /// <summary>
        /// 用户安全性验证操作
        /// </summary>
        /// <param name="GroupHash"></param>
        /// <returns></returns>
        public string GetSafeYanZ(Page e)
        {
            try
            {
                Random rnd = new Random();
                int rndNum1 = rnd.Next(10, 20);
                int rndNum2 = rnd.Next(0, 10);
                int yanzhengSession = rndNum1 + rndNum2;
                e.Session["yanzhengSession"] = yanzhengSession.ToString();
                return "(请输入:" + rndNum1 + "加" + rndNum2 + "的结果！)";
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 由gridview控件生成excel表格数据。
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="FileName"></param>
        public void ToExcel(Control ctl, string FileName)//第一个参数是Gridview控件对象，第二个是要保存为Excel的文件名
        {
            try 
            {
                HttpContext.Current.Response.Charset = "UTF-8";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=UTF-8>");
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + "" + FileName);
            ctl.Page.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            ctl.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
            }
            catch(Exception ex)
            {   
            }
        }
        /// <summary>
        /// 计算今天是等于多少毫秒的
        /// </summary>
        /// <returns></returns>
        public string TodayToMS()
        {
            string coutw = "";
            try
            {
                DateTime dt =DateTime.Now;
                coutw = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + dt.Millisecond.ToString();
            }
            catch
            {
            }
            return coutw;
        }

        ////////////加密解密函数
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public string Encrypt(string pToEncrypt, string sKey) //加密方法
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中  
            //原来使用的UTF8编码，我改成Unicode编码了，不行  
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //byte[]  inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);  

            //建立加密对象的密钥和偏移量  
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法  
            //使得输入密码必须输入英文文本  
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }


        /// <summary>
        /// 解密方法  
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put  the  input  string  into  the  byte  array  
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //建立加密对象的密钥和偏移量，此值重要，不能修改  
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get  the  decrypted  data  back  from  the  memory  stream  
            //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  
            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        ////////////加密解密函数
        

    }

}

