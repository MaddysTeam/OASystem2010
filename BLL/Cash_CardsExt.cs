using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;

namespace Dianda.BLL
{
    public class Cash_CardsExt : Cash_Cards
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CardName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cash_Cards");
            strSql.Append(" where CardName='" + CardName + "'");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录(name,id)
        /// </summary>
        public bool Exists(string CardName, string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cash_Cards");
            strSql.Append(" where CardName='" + CardName + "' and id<>" + ID);
            return DbHelperSQL.Exists(strSql.ToString());
        }
    }
}
