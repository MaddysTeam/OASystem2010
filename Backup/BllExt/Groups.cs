using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dianda.BllExt
{
   public class Groups
    {
       COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();

       /// <summary>
       /// 获取有领导身份的用户名单
       /// </summary>
       /// <returns></returns>
       public DataTable getLeaderList()
       {
           DataTable dt = new DataTable();

           try
           {
               //TEMP=1表示是领导
               string sql = "SELECT *,REALNAME+'('+USERNAME+')' as USERINFO FROM USER_Users WHERE (TEMP3 <> '') AND (TEMP3 IS NOT NULL) AND (TEMP3 = '1')";

               dt = pageControl.doSql(sql).Tables[0];
           }
           catch
           {
 
           }

           return dt;
       }
    }
}
