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
        /// ����ID��GUID��
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
        //����ID��GU��


        /// <summary>
        /// ��ȡ���6λ������
        /// </summary>


        public string GetPwd()
        {
            Guid g = Guid.NewGuid();
            string g1 = g.ToString();
            string g2 = g1.Substring(0, 6);
            return g2;
        }
        //��ȡ���6λ������

        /// <summary>
        /// ����MD5���ܵ�11λ������
        /// </summary>

        public string GetMD5(string PWD)
        {
            string PWD_1 = SafeString(PWD);
            string PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PWD_1, "MD5").Substring(0, 11).ToString();
            return PassWord;
        }
        //����MD5���ܵ�11λ������


        /// <summary>
        ///�ַ�����ȡ����
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
        //�ַ�����ȡ����




        /// <summary>
        ///����00:40��ʽ��ʱ�任�������40���ʽ������:TYPEsΪ "00:00"��00��40ת��Ϊ40��Ϊ"00"��40ת��Ϊ00��40
        /// </summary>


        //����00:40��ʽ��ʱ�任�������40���ʽ������
        public string TimeChange(string time, string types)
        {
            string TimeString = "";
            double temp = 0;
            try
            {
                if (types == "00:00")//��00��40ת��Ϊ40
                {
                    string[] TimeStringArray = time.Split(':');
                    for (int loop = TimeStringArray.Length - 1; loop > -1; loop--)
                    {
                        temp = temp + Convert.ToDouble(TimeStringArray[loop]) * (System.Math.Pow(60, TimeStringArray.Length - loop - 1));
                    }
                    TimeString = temp.ToString();
                }
                else if (types == "00")//��40ת��Ϊ00��40
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





        //����00:40��ʽ��ʱ�任�������40���ʽ������
        /// <summary>
        /// ����ȡ��ֵ���а�ȫ�Դ���
        /// </summary>
        /// <param name="olderString">��ȡ��ֵ</param>
        /// <param name="length">��������£�ֵӦ���Ƕ೤���������ֵ�ĳ��ȴ�����������Ϊ0</param>
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


        //////////////////////��ֹSQLע���ͨ�ú���
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
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "exec", "", 1, -1, CompareMethod.Text);// newString.Replace("%3B �뵱�룻", "");
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
        /// �������Ĳ�����ʽ
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
        /// ȥ����������������ַ�
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
        ///��ȡ�ͻ��˵�IP��ַ
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
        ///���EMAIL�ĸ�ʽ�Ƿ���ȷ
        ///</summary>
        public bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        /// <summary>
        /// �ַ����и����SELECT IN ���ַ���
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
        /// ��ȡϵͳ���õ��ϴ������Ĵ�С
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
        /// ��ȡ��ϵͳ�п����ϴ����ļ���������(�����ִ�Сд)
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
        /// ɾ��DATATABLE�е�ָ����
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
        /// �ϲ�������ͬ�ṹ��DATATABLE
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
        /// ��һ��DATATABLE�е��ظ���ȥ����
        /// </summary>
        /// <param name="DataTable1">���ݼ�1</param>
        /// <param name="tagNAME">ָ����Ψһ������</param>
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
                       //����
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
        /// ������֤���룬����TRUE,FALSE
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
                return false;//������֤
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//ʡ����֤
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//������֤
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
                return false;//У������֤
            }
            return true;//����GB11643-1999��׼
        }

        private bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//������֤
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//ʡ����֤
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//������֤
            }
            return true;//����15λ���֤��׼
        }



        //�����ṹ��ͬ��DT�ϲ�
        /// <summary>
        /// �������в�ͬ��DataTable�ϲ���һ���µ�DataTable
        /// </summary>
        /// <param name="dt1">��1</param>
        /// <param name="dt2">��2</param>
        /// <param name="DTName">�ϲ����µı���</param>
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
            dt3.TableName = DTName; //����DT������
            return dt3;
        }
        /// <summary>
        /// ��Ӣ�ĵ�����ת��Ϊ���ĵ��������
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
                    coutw = "������";
                }
                else if (englishweeklow == "monday")
                {
                    coutw = "����һ";
                }
                else if (englishweeklow == "tuesday")
                {
                    coutw = "���ڶ�";
                }
                else if (englishweeklow == "wednesday")
                {
                    coutw = "������";
                }
                else if (englishweeklow == "thursday")
                {
                    coutw = "������";
                }
                else if (englishweeklow == "friday")
                {
                    coutw = "������";
                }
                else if (englishweeklow == "saturday")
                {
                    coutw = "������";
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
        /// ��ԭ��2009-09-01 12��00��00����ʽ�ĳ� 2009-09-01��ʽ
        /// </summary>
        /// <param name="olderTime">�ϵ�ʱ��</param>
        /// <returns>ת�����ʱ���ʽ</returns>
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
        /// ��ԭ��2009-09-01 12��00��00����ʽ�ĳ� 2009-09-01��ʽ
        /// </summary>
        /// <param name="olderTime">�ϵ�ʱ��</param>
        /// <returns>ת�����ʱ���ʽ</returns>
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
        ///����������֮���ʱ���죩
        /// </summary>
        /// <param name="DateTime1">�������</param>
        /// <param name="DateTime2">С������</param>
        /// <returns></returns>
        public string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            // dateDiff = ts.Days.ToString() + "��" + ts.Hours.ToString() + "Сʱ" + ts.Minutes.ToString() + "����" + ts.Seconds.ToString() + "��";
            dateDiff = ts.Days.ToString();
            return dateDiff;
        }
        /// <summary>
        ///����������֮���ʱ��Сʱ��
        /// </summary>
        /// <param name="DateTime1">�������</param>
        /// <param name="DateTime2">С������</param>
        /// <returns></returns>
        public int HourDiff(DateTime DateTime1, DateTime DateTime2)
        {
            int dateDiff = 0;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            // dateDiff = ts.Days.ToString() + "��" + ts.Hours.ToString() + "Сʱ" + ts.Minutes.ToString() + "����" + ts.Seconds.ToString() + "��";
            dateDiff =ts.Days*24+ts.Hours;
            return dateDiff;
        }
        /// <summary>
        /// ��theStander����Ϊģ�壬�Ƚ�compareOne�Ƿ�͸��������
        /// </summary>
        /// <param name="theStander">ģ������</param>
        /// <param name="compareOne">���Ƚ�����</param>
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
        ///  ��ȡ���������types=1��ʾ2009-06-06 ��������2��ʾ2009-06-06��3��ʾ2009-06-06 00:00:00��4��2009��06��06�� ������
        /// </summary>
        /// <param name="types">types=1��ʾ2009-06-06 ��������2��ʾ2009-06-06��3��ʾ2009-06-06 00:00:00</param>
        /// <returns>types=1��ʾ2009-06-06 ��������2��ʾ2009-06-06��3��ʾ2009-06-06 00:00:00��4��2009��06��06�� ������</returns>
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
                    coutw = dtime.Year.ToString() + "��" + dtime.Month.ToString() + "��" + dtime.Day.ToString() + "�� " + WeekToChinese(dtime.DayOfWeek.ToString());
                }
            }
            catch
            {
                coutw = "NULL";
            }
            return coutw;

        }
        /// <summary>
        /// �������ʱ��ת���������ڵ��ַ���
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
                coutw = dt.Year.ToString() + "��" + dt.Month.ToString() + "��" + dt.Day.ToString() + "�� " + weeks;
            }
            catch
            {
            }

            return coutw;

        }
        /// <summary>
        /// �����ַ��������и��ϳ�select in ('fasd','fadsf')��in����
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
                    //���Ҫ������ַ������һλҲ�Ƿָ����ַ�������ǰ����ȥ����
                    string lastchar = strings.Substring(strings.Length - 1, 1);
                    if (lastchar == spitWhat.ToString())
                    {
                        strings = strings.Substring(0, strings.Length - 1);
                    }

                    string[] arrays = strings.Split(spitWhat);
                    //�����ַ����еĿ�ֵ
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
                    //�����ַ����еĿ�ֵ

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
        /// �û���ȫ����֤����
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
                return "(������:" + rndNum1 + "��" + rndNum2 + "�Ľ����)";
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// ��gridview�ؼ�����excel������ݡ�
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="FileName"></param>
        public void ToExcel(Control ctl, string FileName)//��һ��������Gridview�ؼ����󣬵ڶ�����Ҫ����ΪExcel���ļ���
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
        /// ��������ǵ��ڶ��ٺ����
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

        ////////////���ܽ��ܺ���
        /// <summary>
        /// ���ܷ���
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public string Encrypt(string pToEncrypt, string sKey) //���ܷ���
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //���ַ����ŵ�byte������  
            //ԭ��ʹ�õ�UTF8���룬�Ҹĳ�Unicode�����ˣ�����  
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //byte[]  inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);  

            //�������ܶ������Կ��ƫ����  
            //ԭ��ʹ��ASCIIEncoding.ASCII������GetBytes����  
            //ʹ�����������������Ӣ���ı�  
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
        /// ���ܷ���  
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

            //�������ܶ������Կ��ƫ��������ֵ��Ҫ�������޸�  
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get  the  decrypted  data  back  from  the  memory  stream  
            //����StringBuild����CreateDecryptʹ�õ��������󣬱���ѽ��ܺ���ı����������  
            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        ////////////���ܽ��ܺ���
        

    }

}

