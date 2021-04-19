using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Dianda.BllExt
{
    public partial class Cash_Account_Subscription
    {
        public float getSubscription(string sql)
        {
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return float.Parse(obj.ToString());
            }
        }

        public bool OperationAccount(string _str, string ReadDate, string _type)
        {
            if (string.IsNullOrEmpty(_str))
                return false;

            string[] Arr = _str.Split(',');

            string AccountID = "";
            float Tol = 0, DifferenceValue = 0;
            string Sql = "";
            //把相同账号的金额加起来
            for (int i = 0; i < Arr.Length; i++)
            {
                string[] str = Arr[i].Split('|');
                    if (AccountID != str[0])
                    {
                        if (AccountID != "")
                        {
                            Sql = "exec getSubscription " + AccountID + "," + Tol.ToString() + ",'" + ReadDate + "','" + _type + "'";
                            DifferenceValue = getSubscription(Sql);
                            if (DifferenceValue < 0)
                                return false;
                        }
                        Tol = 0;
                        AccountID = str[0];
                    }
                    Tol += float.Parse(str[1]);
            }

            Sql = "exec getSubscription " + AccountID + "," + Tol.ToString() + ",'" + ReadDate + "','" + _type + "'";
            DifferenceValue = getSubscription(Sql);

            if (_type == "0" && DifferenceValue < 0)
                return false;
            else if (_type == "1" && DifferenceValue == -1)
                return false;
            else if (_type == "2" && DifferenceValue == -1)
                return false;

            return true;
        }
    }
}
