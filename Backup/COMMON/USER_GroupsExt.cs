using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.IO;
using System.Data.OleDb;
 
namespace Dianda.COMMON
{
    /// <summary>
    /// 用户组表的扩展方法
    /// </summary>
   public class USER_GroupsExt
    {
       COMMON.pageControl pagecontrols = new pageControl();
        /// <summary>
        /// 名称是否存在
        /// </summary>
        /// <param name="Name">输入的名字</param>
        /// <param name="ID">如果是添加，则ID为空；如果是修改，则ID不为空</param>
        /// <returns>存在则返回true,不存在则返回false</returns>
       public bool Exists_Name(string NAME, string ID)
       {
           bool coutw = false;
           try
           {
               string sql = "";
               if (ID != "" && ID != null)
               {
                   sql = "select count(1) as nums from USER_Groups where NAME='" + NAME + "' and ID<>'" + ID + "' and DELFLAG='0'";


               }
               else
               {
                   sql = "select count(1)  as nums  from USER_Groups where NAME='" + NAME + "'  and DELFLAG='0'";
               }

               DataTable dt = pagecontrols.doSql(sql).Tables[0];
               if (dt.Rows.Count > 0)
               {
                   if (dt.Rows[0]["nums"].ToString() != "0" && dt.Rows[0]["nums"].ToString() != "" && dt.Rows[0]["nums"].ToString() != null)
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
        ///获取指定ID的用户组信息
        ///ID是一个带‘，’的组的组合串
        /// </summary>
        public DataTable getGroupsById(string ID)
        {
            DataTable DT = new DataTable();
            string[] IDS = ID.Split(',');
            string IDString = "  ID IN(";
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
            IDString = IDString + ")  AND DelFlag='0'";
            try
            {
                string sqls = "select ID,NAME,CONTENTS,ROLE,DELFLAG,ISMOREN FROM USER_Groups where " + IDString;
                DT = pagecontrols.doSql(sqls).Tables[0];
            }
            catch
            {

            }
            return DT;
        }
        /// <summary>
        /// 将指定ID的用户组设置为默认用户组
        /// <param name="ID">用户指定为默认组的ID</param>
        /// </summary>
        public void UpdateISMOREN(string ID)
        {
            if (ID != "")
            {
                string sql = "update USER_Groups set ISMOREN=0";
                string sql2 = "update USER_Groups set ISMOREN=1 where ID='"+ID+"'";

                pagecontrols.doSql(sql);
                pagecontrols.doSql(sql2);
            }

        }
    }
}
