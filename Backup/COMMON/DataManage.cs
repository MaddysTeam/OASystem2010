using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

namespace Dianda.COMMON
{
    /// <summary>
    /// DataManage 的摘要说明zheng
    /// </summary>
    public class DataManager
    {
        private SqlConnection myConnection;
        public DataManager()
        {

            String dsn = System.Configuration.ConfigurationManager.AppSettings["conn_Default"];
            myConnection = new SqlConnection(dsn);
        }

        public void fillds(DataSet ds, string tableName, string sqlSentence)
        {
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            myAdapter.TableMappings.Add("Table", tableName);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(sqlSentence, myConnection);
            myCommand.CommandType = CommandType.Text;
            myAdapter.SelectCommand = myCommand;
            myAdapter.Fill(ds);
            myConnection.Close();
        }

        public void filldt(DataTable dt, string sqlSentence)
        {
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(sqlSentence, myConnection);
            myCommand.CommandType = CommandType.Text;
            myAdapter.SelectCommand = myCommand;
            myAdapter.Fill(dt);
            myConnection.Close();
        }


        public string[] GetStringMore(int count, string sqlSentence)
        {
            SqlCommand myCmd1 = new SqlCommand(sqlSentence, myConnection);
            myCmd1.Connection.Open();
            string[] str = new string[count];
            SqlDataReader myReader = myCmd1.ExecuteReader();
            myReader.Read();
            try
            {
                for (int i = 0; i < count; i++)
                {
                    str[i] = myReader[i].ToString();
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                myReader.Close();
                myCmd1.Connection.Close();
            }
            return str;
        }


        public string GetString(string sqlSentence)
        {
            SqlCommand myCmd1 = new SqlCommand(sqlSentence, myConnection);
            myCmd1.Connection.Open();

            SqlDataReader myReader = myCmd1.ExecuteReader();

            myReader.Read();
            string str = null;

            try
            {
                str = myReader[0].ToString();
            }
            catch
            {
                myReader.Close();
                myCmd1.Connection.Close();
                return "null";
            }
            while (myReader.Read())
            {
                str = str + "," + myReader[0].ToString();
            }
            myReader.Close();
            myCmd1.Connection.Close();
            return str;
        }
        public string T_UNITINFO_DISTRICT(string UNITID)
        {
            string coutW = "";
            if (UNITID == "0" || UNITID == "" || UNITID == null)
            {
                coutW = "30";
            }
            else
            {
                string sql = "select DISTRICTID from T_UNITINFO where ID='" + UNITID + "'";
                DataTable infoshow = new DataTable();
                filldt(infoshow, sql);
                int dtcount = infoshow.Rows.Count;
                if (dtcount == 0)
                {
                    coutW = "30";
                }
                else
                {
                    DataRow R = infoshow.Rows[0];
                    coutW = R["DISTRICTID"].ToString();
                }
            }
            return coutW;
        }

        public string UpdateData(int type, string sqlSentence)
        {
            string re = null;
            SqlCommand myCmd1 = new SqlCommand(sqlSentence, myConnection);
            myCmd1.Connection.Open();
            if (type == 1)
            {
                re = myCmd1.ExecuteNonQuery().ToString();
            }
            if (type == 2)
            {
                re = myCmd1.ExecuteScalar().ToString();
            }
            myCmd1.Connection.Close();
            return re;
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
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, ">", "", 1, -1, CompareMethod.Text);// newString.Replace(">", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "&", "", 1, -1, CompareMethod.Text);// newString.Replace("&", "&amp;");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "%", "", 1, -1, CompareMethod.Text);// newString.Replace("%", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "select", "", 1, -1, CompareMethod.Text);//newString.Replace("select", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "insert", "", 1, -1, CompareMethod.Text);//newString.Replace("insert", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "update", "", 1, -1, CompareMethod.Text);// newString.Replace("update", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "delete", "", 1, -1, CompareMethod.Text);// newString.Replace("delete", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "create", "", 1, -1, CompareMethod.Text);// newString.Replace("create", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "drop", "", 1, -1, CompareMethod.Text);// newString.Replace("drop", "");
                    newString = Microsoft.VisualBasic.Strings.Replace(newString, "delcare", "", 1, -1, CompareMethod.Text);// newString.Replace("delcare", "");
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



        ////////////////////////
    }
}
