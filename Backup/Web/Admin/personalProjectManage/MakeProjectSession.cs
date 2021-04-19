using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;

namespace Dianda.Web.Admin.personalProjectManage
{
    public class MakeProjectSession
    {
        COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        COMMON.common common = new Dianda.COMMON.common();
        Model.USER_Users mUser = new Dianda.Model.USER_Users();//加载用户的实体类

        /// <summary>
        /// 根据用户的ID，或取到该用户所管理的所有项目的列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void getMyProjectList(Page e)
        {
          
            try
            {
                mUser = (Model.USER_Users)e.Session["USER_Users"];//实例化
                //负责的项目
                //string sql1 = " SELECT ID,NAMES FROM vProject_Projects WHERE LeaderID='" + mUser.ID + "' and DELFLAG=0  and (Status=1 or Status=3 or Status=5) ";
                //string sql1 = " SELECT ID,NAMES,DELFLAG,Status FROM vProject_Projects WHERE LeaderID='" + mUser.ID + "' and (Status=1 or Status=3 or Status=5) ";

                //由于在我的项目中需要添加一个已删除的项目，所以在加载项目时也需要将删除的显示出来，故作以上修改（and DELFLAG=0 删除了）--早于2011-02-17
                string sql1 = " SELECT ID,NAMES,DELFLAG,Status FROM vProject_Projects WHERE (SendUserID='" + mUser.ID + "' OR LeaderID='" + mUser.ID + "') and (Status=1 or Status=3 or Status=5) ";
                //由于项目的创建人的权限，现在比项目负责人的权限还要大，所以要修改2011-02-17 唐春龙
                DataTable dt1 = pageControl.doSql(sql1).Tables[0];

                //参与的项目
                // string sql2 = " SELECT  ID,NAMES FROM  vProject_Projects WHERE  DELFLAG=0 and id in(select Projectid from Project_UserList where userid='" + mUser.ID + "' and status='1') ";
                string sql2 = " SELECT  ID,NAMES,DELFLAG,Status  FROM  vProject_Projects WHERE id in(select Projectid from Project_UserList where userid='" + mUser.ID + "' and status='1')  and (Status=1 or Status=3 or Status=5)";
                //由于在我的项目中需要添加一个已删除的项目，所以在加载项目时也需要将删除的显示出来，故作以上修改（DELFLAG=0 and 删除了）

                DataTable dt2 = pageControl.doSql(sql2).Tables[0];

                //合并两个相同结构的DATATABLE
                DataTable Newdt = common.CombineTheSameDatatable(dt1, dt2);
                //将一个DATATABLE中的重复项去除掉
                if (null != Newdt)
                {
                    Newdt = common.makeDistinceTable(Newdt, "ID");
                    e.Session["Project_Projects"] = Newdt;
                }
            }
            catch
            {
            }
        }
    }
}
