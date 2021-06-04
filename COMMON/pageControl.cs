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

using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.COMMON
{
    public class pageControl
    {
        common commons = new common();
        /// <summary>
        /// 分页的跳转函数 
        /// </summary>
        /// <param name="pageindex">要跳转到的页码</param>
        /// <param name="dtCount">信息的总共条数</param>
        /// <param name="DropDownList2">做页码跳转的下拉框</param>
        /// <param name="pagesize">每页的条数</param>
        /// <param name="FirstPage">第一页的控件</param>
        /// <param name="NextPage">下一页的控件</param>
        /// <param name="PreviousPage">上一页的控件</param>
        /// <param name="LastPage">最后一页的控件</param>
        /// <param name="Label_showInfo">显示当前分页信息的控件</param>
        public void SetSelectPage(int pageindex, int dtCount, DropDownList DropDownList2, int pagesize, LinkButton FirstPage, LinkButton NextPage, LinkButton PreviousPage, LinkButton LastPage, Label Label_showInfo)
        {
            try
            {
                DropDownList D1 = new DropDownList();
                D1 = DropDownList2;
                int totallCount = dtCount;
                int yushu = totallCount % pagesize;
                int allpagecount = 0;
                if (yushu > 0)
                {
                    allpagecount = (totallCount / pagesize) + 1;
                }
                else
                {
                    allpagecount = (totallCount / pagesize);
                }

                D1.Items.Clear();
                for (int i = 1; i <= allpagecount; i++)
                {//从1开始循环到页的最大数量
                    ListItem L1 = new ListItem();
                    if (i == (pageindex))
                    {
                        L1.Selected = true;
                    }
                    else
                    {
                        L1.Selected = false;
                    }
                    L1.Text = "第" + i.ToString() + "页";
                    L1.Value = i.ToString();
                    D1.Items.Add(L1);//填充到下拉列表
                }


                D1.SelectedValue = pageindex.ToString();

                FirstPage.Visible = true;
                NextPage.Visible = true;
                PreviousPage.Visible = true;
                LastPage.Visible = true;
                //如果是第一页,不显示第一页按钮和上一页按钮
                if (pageindex == 1)
                {
                    FirstPage.Visible = false;
                    PreviousPage.Visible = false;
                }
                //如果是最后一页,不显示最后页和下一页的按钮
                if (pageindex == allpagecount)
                {
                    NextPage.Visible = false;
                    LastPage.Visible = false;
                }
                //如果只有一页,则不显示所有按钮
                if (dtCount == 1)
                {
                    FirstPage.Visible = false;
                    PreviousPage.Visible = false;
                    NextPage.Visible = false;
                    LastPage.Visible = false;
                }
                FirstPage.CommandArgument = "1";
                NextPage.CommandArgument = Convert.ToString(pageindex + 1);
                PreviousPage.CommandArgument = Convert.ToString(pageindex - 1);
                LastPage.CommandArgument = Convert.ToString(allpagecount);
                Label LB1 = new Label();
                LB1 = Label_showInfo;
                LB1.Text = "共有" + dtCount.ToString() + "条记录&nbsp;&nbsp;共有" + allpagecount.ToString() + "页&nbsp;&nbsp;当前页：第" + (pageindex) + "页";
            }
            catch
            {
            }
        }
        /// <summary>
        ///分页获取数据列表
        /// </summary>
        /// <param name="strWhere">过滤的SQL</param>
        /// <param name="page">当前要显示的页数</param>
        /// <param name="pageSize">每页显示多少条信息</param>
        /// <param name="rePageSize">当前页要显示多少条记录，如果不是最后一页，则显示pageSize条，如果是最后一页，则显示rePageSize条</param>
        /// <param name="allNewsRows">当前记录集有多少条记录</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_Common(string strWhere, int page, int pageSize, int allNewsRows, string tableName, string orderString)
        {

            //判断当前页要显示多少记录
            int alltiaoshuInt = allNewsRows;
            int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//获取到还有多少条记录

            int rePageSizeCan = 0;
            if (rePageSize1 > pageSize)//如果剩余的条数大于一页显示的数据，则下面要显示的条数就是一页可以显示的条数
            {
                rePageSizeCan = pageSize;
            }
            else//如果剩余的条数小于一页显示的条数，则显示剩余的数据条数，例如一页显示10条，还剩下9条记录，则就显示9条记录
            {
                if (rePageSize1 > 0)//如果显示的是大于0的并且小于一页显示的总条数的，则是下面的结果
                {
                    rePageSizeCan = rePageSize1;
                }
                else//如果是删除操作，有可能删除的是最后一条记录，则要显示该页前一页的数据
                {
                    page = page - 1;
                    rePageSizeCan = pageSize;
                }
            }
            //判断当前页要显示多少记录

            return GetList_FenYe(strWhere, page, pageSize, rePageSizeCan, tableName, orderString);
        }
        /// <summary>
        ///分页获取数据列表
        /// </summary>
        /// <param name="strWhere">过滤的SQL</param>
        /// <param name="page">当前要显示的页数</param>
        /// <param name="pageSize">每页显示多少条信息</param>
        /// <param name="rePageSize">当前页要显示多少条记录，如果不是最后一页，则显示pageSize条，如果是最后一页，则显示rePageSize条</param>
        /// <param name="allNewsRows">当前记录集有多少条记录</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_NewID(string strWhere, int page, int pageSize, int allNewsRows, string tableName, string orderString)
        {

            //判断当前页要显示多少记录
            int alltiaoshuInt = allNewsRows;
            int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//获取到还有多少条记录

            int rePageSizeCan = 0;
            if (rePageSize1 > pageSize)//如果剩余的条数大于一页显示的数据，则下面要显示的条数就是一页可以显示的条数
            {
                rePageSizeCan = pageSize;
            }
            else//如果剩余的条数小于一页显示的条数，则显示剩余的数据条数，例如一页显示10条，还剩下9条记录，则就显示9条记录
            {
                if (rePageSize1 > 0)//如果显示的是大于0的并且小于一页显示的总条数的，则是下面的结果
                {
                    rePageSizeCan = rePageSize1;
                }
                else//如果是删除操作，有可能删除的是最后一条记录，则要显示该页前一页的数据
                {
                    page = page - 1;
                    rePageSizeCan = pageSize;
                }
            }
            //判断当前页要显示多少记录

            return GetList_FenYe_NewID_dosql(strWhere, page, pageSize, rePageSizeCan, tableName, orderString);
        }
        /// <summary>
        ///分页获取数据列表
        /// </summary>
        /// <param name="strWhere">过滤的SQL</param>
        /// <param name="page">当前要显示的页数</param>
        /// <param name="pageSize">每页显示多少条信息</param>
        /// <param name="rePageSize">当前页要显示多少条记录，如果不是最后一页，则显示pageSize条，如果是最后一页，则显示rePageSize条</param>
        /// <param name="allNewsRows">当前记录集有多少条记录</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_CommonByJiwei(string strWhere, int page, int pageSize, int allNewsRows, string tableName, string orderString)
        {

            //判断当前页要显示多少记录
            int alltiaoshuInt = allNewsRows;
            int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//获取到还有多少条记录

            int rePageSizeCan = 0;
            if (rePageSize1 > pageSize)//如果剩余的条数大于一页显示的数据，则下面要显示的条数就是一页可以显示的条数
            {
                rePageSizeCan = pageSize;
            }
            else//如果剩余的条数小于一页显示的条数，则显示剩余的数据条数，例如一页显示10条，还剩下9条记录，则就显示9条记录
            {
                if (rePageSize1 > 0)//如果显示的是大于0的并且小于一页显示的总条数的，则是下面的结果
                {
                    rePageSizeCan = rePageSize1;
                }
                else//如果是删除操作，有可能删除的是最后一条记录，则要显示该页前一页的数据
                {
                    page = page - 1;
                    rePageSizeCan = pageSize;
                }
            }
            //判断当前页要显示多少记录

            return GetList_FenYe_ByJiwei(strWhere, page, pageSize, rePageSizeCan, tableName, orderString);
        }
        /// <summary>
        /// 根据输入的条件。判断当前要显示的页码数
        /// </summary>
        /// <param name="page">输入的页数</param>
        /// <param name="pageSize">每页能显示多少记录</param>
        /// <param name="allNewsRows">现在总共还有多少记录</param>
        /// <returns></returns>
        public int pageindex(int page, int pageSize, int allNewsRows)
        {
            int coutw = 0;
            try
            {
                //判断当前页要显示多少记录
                int alltiaoshuInt = allNewsRows;
                int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//获取到还有多少条记录
                if (rePageSize1 > pageSize)//如果剩余的条数大于一页显示的数据，则下面要显示的条数就是一页可以显示的条数
                {
                    coutw = page;
                }
                else//如果剩余的条数小于一页显示的条数，则显示剩余的数据条数，例如一页显示10条，还剩下9条记录，则就显示9条记录
                {
                    if (rePageSize1 > 0)//如果显示的是大于0的并且小于一页显示的总条数的，则是下面的结果
                    {
                        coutw = page;
                    }
                    else//如果是删除操作，有可能删除的是最后一条记录，则要显示该页前一页的数据
                    {
                        coutw = page - 1;
                    }
                }
                //判断当前页要显示多少记录
            }
            catch
            {
                coutw = page;
            }
            return coutw;
        }
        /// <summary>
        ///分页获取数据列表
        /// </summary>
        /// <param name="strWhere">过滤的SQL</param>
        /// <param name="page">当前要显示的页数</param>
        /// <param name="pageSize">每页显示多少条信息</param>
        /// <param name="rePageSize">当前页要显示多少条记录，如果不是最后一页，则显示pageSize条，如果是最后一页，则显示rePageSize条</param>
        /// <returns></returns>
        public DataSet GetList_FenYe(string strWhere, int page, int pageSize, int rePageSize, string tableName, string orderString)
			{
            StringBuilder strSql = new StringBuilder();
            if (pageSize == rePageSize)
            {
                strSql.Append("select * from( select top " + pageSize + " * from(select top " + pageSize * page + " * ");
            }
            else
            {
                strSql.Append("select * from( select top " + rePageSize + " * from(select top " + pageSize * page + " * ");
            }
            strSql.Append(" FROM " + tableName + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append("  order by " + orderString + " desc) as a order by " + orderString + ")as b order by " + orderString + " desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        ///通过构建一个排序的标记位，来实现排序功能
        /// </summary>
        /// <param name="strWhere">过滤的SQL</param>
        /// <param name="page">当前要显示的页数</param>
        /// <param name="pageSize">每页显示多少条信息</param>
        /// <param name="rePageSize">当前页要显示多少条记录，如果不是最后一页，则显示pageSize条，如果是最后一页，则显示rePageSize条</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_NewID_dosql(string strWhere, int page, int pageSize, int rePageSize, string tableName, string orderString)
        {
            StringBuilder strSql = new StringBuilder();
            //select * from (SELECT row_number() OVER (ORDER BY name desc,id asc) AS rowId, ID, NAME FROM   News_News) as newTableName WHERE     rowId BETWEEN 2 AND 4
            int fromnum = 0;
            int tonum = 0;
            fromnum = ((page-1) * pageSize) + 1;
            tonum = (fromnum + rePageSize) - 1;

            string sql = "select * from (SELECT row_number() OVER (ORDER BY " + orderString + ") AS rowId,*  FROM " + tableName + " where 1=1 and " + strWhere + ") as newTableName WHERE     rowId BETWEEN " + fromnum + " AND " + tonum;          
                 
          
            return DbHelperSQL.Query(sql.ToString());
        }


        
        /// <summary>
        /// 返回查询的DATASET
        /// </summary>
        /// <param name="sqlstring"></param>
        /// s
        /// 
        /// <returns></returns>
        public DataSet doSql(string sqlstring)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = DbHelperSQL.Query(sqlstring.ToString());
                // 20100818 -w-添加
                if (ds == null || ds.Tables[0] == null)
                {
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                }
                // 20100818 -w-添加
            }
            catch
            {
            }
            return ds;
        }
        /// <summary>
        /// 根据表的名字和要统计的字段名称，及统计的条件，返回结果集的条数。
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="tableName">表的名称</param>
        /// <param name="coutChar">要统计的字段名称</param>
        /// <returns></returns>
        public int tableRowCout(string strWhere, string tableName, string coutChar)
        {
            StringBuilder strSql = new StringBuilder();
            int coutw = 0;
            try
            {
                strSql.Append("select count(" + coutChar + ") as numbs from " + tableName + " ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(strSql.ToString());
                DataTable coutwdt = ds.Tables[0];
                if (coutwdt.Rows.Count > 0)
                {
                    coutw = int.Parse(coutwdt.Rows[0]["numbs"].ToString());
                }
                else
                {
                    coutw = 0;
                }
            }
            catch
            {
                coutw = 0;
            }
            return coutw;
        }

        /// <summary>
        ///分页获取数据列表 author jiwei 
        ///传入的排序条件可以是任意的，但传入的排序条件必须符合规则，
        ///2个以及以上的排序条件
        ///比如：orderString="ISFIRST,DESC;CREATETIME,DESC"
        ///1个排序条件
        ///比如：orderString="CREATETIME,DESC"
        /// </summary>
        /// <param name="strWhere">过滤的SQL</param>
        /// <param name="page">当前要显示的页数</param>
        /// <param name="pageSize">每页显示多少条信息</param>
        /// <param name="rePageSize">当前页要显示多少条记录，如果不是最后一页，则显示pageSize条，如果是最后一页，则显示rePageSize条</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_ByJiwei(string strWhere, int page, int pageSize, int rePageSize, string tableName, string orderString)
        {
            StringBuilder strSql = new StringBuilder();
            if (pageSize == rePageSize)
            {
                strSql.Append("select * from( select top " + pageSize + " * from(select top " + pageSize * page + " * ");
            }
            else
            {
                strSql.Append("select * from( select top " + rePageSize + " * from(select top " + pageSize * page + " * ");
            }
            strSql.Append(" FROM " + tableName + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            string ordercontent1 = "";
            string ordercontent2 = "";
            if (null != orderString && orderString.Trim() != "")
            {
                string[] ordersArray = orderString.Split(';');//分割排序条件字符串，得到排序条件数组
                for (int i = 0; i < ordersArray.Length; i++)
                {
                    string orders = ordersArray[i];
                    string[] perOrder = orders.Split(',');
                    if (perOrder.Length == 2)
                    {
                        string orderstr = perOrder[0];
                        string orderdes = perOrder[1];
                        if (i > 0)
                        {
                            ordercontent1 = ordercontent1 + ",";
                            ordercontent2 = ordercontent2 + ",";
                        }
                        ordercontent1 = ordercontent1 + orderstr + " " + orderdes;
                        //升序，第二次orderby的时候需要反序
                        if (orderdes == "asc" || orderdes == "ASC")
                        {
                            ordercontent2 = ordercontent2 + orderstr + " desc";
                        }
                        else if (orderdes == "desc" || orderdes == "DESC")//降序，第二次orderby的时候需要反序
                        {
                            ordercontent2 = ordercontent2 + orderstr + " asc";
                        }
                        else
                        {//其他情况，抛出异常 
                            throw new Exception("排序参数传递出错！");
                        }
                    }
                    else
                    {
                        throw new Exception("排序参数传递出错！");

                    }

                }

            }


            strSql.Append("  order by " + ordercontent1 + " ) as a order by " + ordercontent2 + ")as b order by " + ordercontent1 + " ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 构造树状菜单
        /// </summary>
        /// <param name="DT">原始的数据集</param>
        /// <param name="PID">父节点字段的名称</param>
        /// <param name="ColumnsPath">栏目的路径字段名称</param>
        /// <param name="Name">栏目显示的名称字段名称</param>
        /// <returns></returns>
        public DataTable makeTree(DataTable DT, string PID, string ColumnsPath, string Name)
        {

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                string parentid = DT.Rows[i][PID].ToString();
                string path = DT.Rows[i][ColumnsPath].ToString();
                if (parentid != "-1")
                {
                    string kg = null;
                    for (int x = 0; x < (path.Length) / 32; x++)
                    {
                        kg += "　";
                    }
                    DT.Rows[i][Name] = kg + "|--" + DT.Rows[i][Name].ToString();
                }
            }
            return DT;
        }

        /// <summary>
        ///根据传过来的SQLSTRING执行查询，获取到DT
        /// </summary>
        ///<param name="sqlstring">拼接好的SQL</param>
        /// <returns></returns>
        public DataSet GetDataSetBySql(string sqlstring)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(sqlstring);
            return DbHelperSQL.Query(strSql.ToString());
        }

        ////////////////////////////////////////////////////////以下为学生信息管理专用分页方法/////////////////////////////////////////////////


        /// <summary>
        ///分页获取数据列表
        /// </summary>
        /// <param name="strWhere">过滤的SQL</param>
        /// <param name="page">当前要显示的页数</param>
        /// <param name="pageSize">每页显示多少条信息</param>
        /// <param name="rePageSize">当前页要显示多少条记录，如果不是最后一页，则显示pageSize条，如果是最后一页，则显示rePageSize条</param>
        /// <param name="allNewsRows">当前记录集有多少条记录</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_Common2(string strWhere, int page, int pageSize, int allNewsRows, string tableName, string orderString)
        {

            //判断当前页要显示多少记录
            int alltiaoshuInt = allNewsRows;
            int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//获取到还有多少条记录

            int rePageSizeCan = 0;
            if (rePageSize1 > pageSize)//如果剩余的条数大于一页显示的数据，则下面要显示的条数就是一页可以显示的条数
            {
                rePageSizeCan = pageSize;
            }
            else//如果剩余的条数小于一页显示的条数，则显示剩余的数据条数，例如一页显示10条，还剩下9条记录，则就显示9条记录
            {
                if (rePageSize1 > 0)//如果显示的是大于0的并且小于一页显示的总条数的，则是下面的结果
                {
                    rePageSizeCan = rePageSize1;
                }
                else//如果是删除操作，有可能删除的是最后一条记录，则要显示该页前一页的数据
                {
                    page = page - 1;
                    rePageSizeCan = pageSize;
                }
            }
            //判断当前页要显示多少记录

            return GetList_FenYe2(strWhere, page, pageSize, rePageSizeCan, tableName, orderString);
        }


        /// <summary>
        ///分页获取数据列表
        /// </summary>
        /// <param name="strWhere">过滤的SQL</param>
        /// <param name="page">当前要显示的页数</param>
        /// <param name="pageSize">每页显示多少条信息</param>
        /// <param name="rePageSize">当前页要显示多少条记录，如果不是最后一页，则显示pageSize条，如果是最后一页，则显示rePageSize条</param>
        /// <returns></returns>
        public DataSet GetList_FenYe2(string strWhere, int page, int pageSize, int rePageSize, string tableName, string orderString)
        {
            StringBuilder strSql = new StringBuilder();
            if (pageSize == rePageSize)
            {
                strSql.Append("select *  from( select top " + pageSize + " * from(select top " + pageSize * page + " * from (select gradecode ");
            }
            else
            {
                strSql.Append("select * from( select top " + rePageSize + " * from(select top " + pageSize * page + " * from (select gradecode ");
            }
            strSql.Append(" FROM " + tableName + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append("GROUP BY gradecode  ) as a order by " + orderString + " desc)c order by " + orderString + ")as b    order by " + orderString + " desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }





        /// <summary>
        ///分页获取数据列表
        /// </summary>
        /// <param name="strWhere">过滤的SQL</param>
        /// <param name="page">当前要显示的页数</param>
        /// <param name="pageSize">每页显示多少条信息</param>
        /// <param name="rePageSize">当前页要显示多少条记录，如果不是最后一页，则显示pageSize条，如果是最后一页，则显示rePageSize条</param>
        /// <param name="allNewsRows">当前记录集有多少条记录</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_Common3(string strWhere, int page, int pageSize, int allNewsRows, string tableName, string orderString)
        {

            //判断当前页要显示多少记录
            int alltiaoshuInt = allNewsRows;
            int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//获取到还有多少条记录

            int rePageSizeCan = 0;
            if (rePageSize1 > pageSize)//如果剩余的条数大于一页显示的数据，则下面要显示的条数就是一页可以显示的条数
            {
                rePageSizeCan = pageSize;
            }
            else//如果剩余的条数小于一页显示的条数，则显示剩余的数据条数，例如一页显示10条，还剩下9条记录，则就显示9条记录
            {
                if (rePageSize1 > 0)//如果显示的是大于0的并且小于一页显示的总条数的，则是下面的结果
                {
                    rePageSizeCan = rePageSize1;
                }
                else//如果是删除操作，有可能删除的是最后一条记录，则要显示该页前一页的数据
                {
                    page = page - 1;
                    rePageSizeCan = pageSize;
                }
            }
            //判断当前页要显示多少记录

            return GetList_FenYe3(strWhere, page, pageSize, rePageSizeCan, tableName, orderString);
        }


        /// <summary>
        ///分页获取数据列表
        /// </summary>
        /// <param name="strWhere">过滤的SQL</param>
        /// <param name="page">当前要显示的页数</param>
        /// <param name="pageSize">每页显示多少条信息</param>
        /// <param name="rePageSize">当前页要显示多少条记录，如果不是最后一页，则显示pageSize条，如果是最后一页，则显示rePageSize条</param>
        /// <returns></returns>
        public DataSet GetList_FenYe3(string strWhere, int page, int pageSize, int rePageSize, string tableName, string orderString)
        {
            StringBuilder strSql = new StringBuilder();
            if (pageSize == rePageSize)
            {
                strSql.Append("select *  from( select top " + pageSize + " * from(select top " + pageSize * page + " * from (select gradecode,TERM,ISREGIST");
            }
            else
            {
                strSql.Append("select * from( select top " + rePageSize + " * from(select top " + pageSize * page + " * from (select gradecode,TERM,ISREGIST");
            }
            strSql.Append(" FROM " + tableName + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append("GROUP BY gradecode,TERM,ISREGIST ) as a order by " + orderString + " desc)c order by " + orderString + ")as b    order by " + orderString + " desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }







        /// <summary>
        /// 根据表的名字和要统计的字段名称，及统计的条件，返回结果集的条数。
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="tableName">表的名称</param>
        /// <param name="coutChar">要统计的字段名称</param>
        /// <returns></returns>
        public int tableRowCout2(string strWhere, string tableName, string coutChar)
        {
            StringBuilder strSql = new StringBuilder();
            int coutw = 0;
            try
            {
                if (strWhere.Trim() == "")
                {

                    strSql.Append("select count(" + coutChar + ") as numbs from (select gradecode from " + tableName + " group by gradecode)b");
                }
                else
                {
                    strSql.Append("select count(" + coutChar + ") as numbs from (select gradecode from " + tableName + " where " + strWhere + "  group by gradecode)b");
                }
                DataSet ds = new DataSet();
                ds = DbHelperSQL.Query(strSql.ToString());
                DataTable coutwdt = ds.Tables[0];
                if (coutwdt.Rows.Count > 0)
                {
                    coutw = int.Parse(coutwdt.Rows[0]["numbs"].ToString());
                }
                else
                {
                    coutw = 0;
                }
            }
            catch
            {
                coutw = 0;
            }
            return coutw;
        }


        ////////////////////////////////////////////////////////以上为学生信息管理专用分页方法/////////////////////////////////////////////////
        /// <summary>
        /// 添加网站的访问日志
        /// </summary>
        public void writeVisitLog()
        {
            try
            {
                string sql = "insert into SYS_VISIT(IP,DATETIME,DELFLAG) VALUES('" + commons.GetClientIpAddress("") + "','" + DateTime.Now + "','0')";
                doSql(sql);

            }
            catch
            {
            }
        }
        /// <summary>
        /// 获取到当前平台被访问的次数
        /// </summary>
        /// <returns></returns>
        public string getVisitlog()
        {
            string coutw = "";
            try
            {
                string sql = "select count(id) as nums from SYS_VISIT where delflag='0'";
                DataTable dt = doSql(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    coutw = dt.Rows[0]["nums"].ToString();
                }
                else
                {
                    coutw = "0";
                }
            }
            catch
            {
            }
            return coutw;
        }


        /// <summary>
        /// 判断某表的某一字段值是否存在了。
        /// </summary>
        /// <param name="tabaleName">表名</param>
        /// <param name="columnName">字段名</param>
        /// <param name="columnValue">字段值</param>
        /// <param name="keyName">主健名</param>
        /// <param name="keyValue">主健值</param>
        /// <returns></returns>
        public bool Exists_Name(string tabaleName, string columnName, string columnValue, string keyName, string keyValue)
        {
            bool coutw = false;
            try
            {
                string sql = "";
                if (keyValue != "" && keyValue != null)
                {
                    sql = "select count(1) as nums from " + tabaleName + " where " + columnName + "='" + columnValue + "' and " + keyName + "<>'" + keyValue + "' and DELFLAG='0'";
                }
                else
                {
                    sql = "select count(1)  as nums  from " + tabaleName + " where " + columnName + "='" + columnValue + "'  and DELFLAG='0'";
                }
                DataTable dt = doSql(sql).Tables[0];
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
        /// 判断某表的某一字段值是否存在了。
        /// </summary>
        /// <param name="tabaleName">表名</param>
        /// <param name="columnName">字段名</param>
        /// <param name="columnValue">字段值</param>
        /// <param name="keyName">主健名</param>
        /// <param name="keyValue">主健值</param>
        /// <returns></returns>
        public bool Exists_TaskName(string tabaleName, string columnName, string columnValue, string keyName, string keyValue,int projectid)
        {
            bool coutw = false;
            try
            {
                string sql = "";
                if (keyValue != "" && keyValue != null)
                {
                    sql = "select count(1) as nums from " + tabaleName + " where " + columnName + "='" + columnValue + "' and " + keyName + "<>'" + keyValue + "' and DELFLAG='0' and ProjectID="+projectid;
                }
                else
                {
                    sql = "select count(1)  as nums  from " + tabaleName + " where " + columnName + "='" + columnValue + "'  and DELFLAG='0' and ProjectID="+projectid;
                }
                DataTable dt = doSql(sql).Tables[0];
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
    }
}

