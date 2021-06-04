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
using Maticsoft.DBUtility;//�����������
namespace Dianda.COMMON
{
    public class pageControl
    {
        common commons = new common();
        /// <summary>
        /// ��ҳ����ת���� 
        /// </summary>
        /// <param name="pageindex">Ҫ��ת����ҳ��</param>
        /// <param name="dtCount">��Ϣ���ܹ�����</param>
        /// <param name="DropDownList2">��ҳ����ת��������</param>
        /// <param name="pagesize">ÿҳ������</param>
        /// <param name="FirstPage">��һҳ�Ŀؼ�</param>
        /// <param name="NextPage">��һҳ�Ŀؼ�</param>
        /// <param name="PreviousPage">��һҳ�Ŀؼ�</param>
        /// <param name="LastPage">���һҳ�Ŀؼ�</param>
        /// <param name="Label_showInfo">��ʾ��ǰ��ҳ��Ϣ�Ŀؼ�</param>
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
                {//��1��ʼѭ����ҳ���������
                    ListItem L1 = new ListItem();
                    if (i == (pageindex))
                    {
                        L1.Selected = true;
                    }
                    else
                    {
                        L1.Selected = false;
                    }
                    L1.Text = "��" + i.ToString() + "ҳ";
                    L1.Value = i.ToString();
                    D1.Items.Add(L1);//��䵽�����б�
                }


                D1.SelectedValue = pageindex.ToString();

                FirstPage.Visible = true;
                NextPage.Visible = true;
                PreviousPage.Visible = true;
                LastPage.Visible = true;
                //����ǵ�һҳ,����ʾ��һҳ��ť����һҳ��ť
                if (pageindex == 1)
                {
                    FirstPage.Visible = false;
                    PreviousPage.Visible = false;
                }
                //��������һҳ,����ʾ���ҳ����һҳ�İ�ť
                if (pageindex == allpagecount)
                {
                    NextPage.Visible = false;
                    LastPage.Visible = false;
                }
                //���ֻ��һҳ,����ʾ���а�ť
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
                LB1.Text = "����" + dtCount.ToString() + "����¼&nbsp;&nbsp;����" + allpagecount.ToString() + "ҳ&nbsp;&nbsp;��ǰҳ����" + (pageindex) + "ҳ";
            }
            catch
            {
            }
        }
        /// <summary>
        ///��ҳ��ȡ�����б�
        /// </summary>
        /// <param name="strWhere">���˵�SQL</param>
        /// <param name="page">��ǰҪ��ʾ��ҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��������Ϣ</param>
        /// <param name="rePageSize">��ǰҳҪ��ʾ��������¼������������һҳ������ʾpageSize������������һҳ������ʾrePageSize��</param>
        /// <param name="allNewsRows">��ǰ��¼���ж�������¼</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_Common(string strWhere, int page, int pageSize, int allNewsRows, string tableName, string orderString)
        {

            //�жϵ�ǰҳҪ��ʾ���ټ�¼
            int alltiaoshuInt = allNewsRows;
            int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//��ȡ�����ж�������¼

            int rePageSizeCan = 0;
            if (rePageSize1 > pageSize)//���ʣ�����������һҳ��ʾ�����ݣ�������Ҫ��ʾ����������һҳ������ʾ������
            {
                rePageSizeCan = pageSize;
            }
            else//���ʣ�������С��һҳ��ʾ������������ʾʣ�����������������һҳ��ʾ10������ʣ��9����¼�������ʾ9����¼
            {
                if (rePageSize1 > 0)//�����ʾ���Ǵ���0�Ĳ���С��һҳ��ʾ���������ģ���������Ľ��
                {
                    rePageSizeCan = rePageSize1;
                }
                else//�����ɾ���������п���ɾ���������һ����¼����Ҫ��ʾ��ҳǰһҳ������
                {
                    page = page - 1;
                    rePageSizeCan = pageSize;
                }
            }
            //�жϵ�ǰҳҪ��ʾ���ټ�¼

            return GetList_FenYe(strWhere, page, pageSize, rePageSizeCan, tableName, orderString);
        }
        /// <summary>
        ///��ҳ��ȡ�����б�
        /// </summary>
        /// <param name="strWhere">���˵�SQL</param>
        /// <param name="page">��ǰҪ��ʾ��ҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��������Ϣ</param>
        /// <param name="rePageSize">��ǰҳҪ��ʾ��������¼������������һҳ������ʾpageSize������������һҳ������ʾrePageSize��</param>
        /// <param name="allNewsRows">��ǰ��¼���ж�������¼</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_NewID(string strWhere, int page, int pageSize, int allNewsRows, string tableName, string orderString)
        {

            //�жϵ�ǰҳҪ��ʾ���ټ�¼
            int alltiaoshuInt = allNewsRows;
            int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//��ȡ�����ж�������¼

            int rePageSizeCan = 0;
            if (rePageSize1 > pageSize)//���ʣ�����������һҳ��ʾ�����ݣ�������Ҫ��ʾ����������һҳ������ʾ������
            {
                rePageSizeCan = pageSize;
            }
            else//���ʣ�������С��һҳ��ʾ������������ʾʣ�����������������һҳ��ʾ10������ʣ��9����¼�������ʾ9����¼
            {
                if (rePageSize1 > 0)//�����ʾ���Ǵ���0�Ĳ���С��һҳ��ʾ���������ģ���������Ľ��
                {
                    rePageSizeCan = rePageSize1;
                }
                else//�����ɾ���������п���ɾ���������һ����¼����Ҫ��ʾ��ҳǰһҳ������
                {
                    page = page - 1;
                    rePageSizeCan = pageSize;
                }
            }
            //�жϵ�ǰҳҪ��ʾ���ټ�¼

            return GetList_FenYe_NewID_dosql(strWhere, page, pageSize, rePageSizeCan, tableName, orderString);
        }
        /// <summary>
        ///��ҳ��ȡ�����б�
        /// </summary>
        /// <param name="strWhere">���˵�SQL</param>
        /// <param name="page">��ǰҪ��ʾ��ҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��������Ϣ</param>
        /// <param name="rePageSize">��ǰҳҪ��ʾ��������¼������������һҳ������ʾpageSize������������һҳ������ʾrePageSize��</param>
        /// <param name="allNewsRows">��ǰ��¼���ж�������¼</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_CommonByJiwei(string strWhere, int page, int pageSize, int allNewsRows, string tableName, string orderString)
        {

            //�жϵ�ǰҳҪ��ʾ���ټ�¼
            int alltiaoshuInt = allNewsRows;
            int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//��ȡ�����ж�������¼

            int rePageSizeCan = 0;
            if (rePageSize1 > pageSize)//���ʣ�����������һҳ��ʾ�����ݣ�������Ҫ��ʾ����������һҳ������ʾ������
            {
                rePageSizeCan = pageSize;
            }
            else//���ʣ�������С��һҳ��ʾ������������ʾʣ�����������������һҳ��ʾ10������ʣ��9����¼�������ʾ9����¼
            {
                if (rePageSize1 > 0)//�����ʾ���Ǵ���0�Ĳ���С��һҳ��ʾ���������ģ���������Ľ��
                {
                    rePageSizeCan = rePageSize1;
                }
                else//�����ɾ���������п���ɾ���������һ����¼����Ҫ��ʾ��ҳǰһҳ������
                {
                    page = page - 1;
                    rePageSizeCan = pageSize;
                }
            }
            //�жϵ�ǰҳҪ��ʾ���ټ�¼

            return GetList_FenYe_ByJiwei(strWhere, page, pageSize, rePageSizeCan, tableName, orderString);
        }
        /// <summary>
        /// ����������������жϵ�ǰҪ��ʾ��ҳ����
        /// </summary>
        /// <param name="page">�����ҳ��</param>
        /// <param name="pageSize">ÿҳ����ʾ���ټ�¼</param>
        /// <param name="allNewsRows">�����ܹ����ж��ټ�¼</param>
        /// <returns></returns>
        public int pageindex(int page, int pageSize, int allNewsRows)
        {
            int coutw = 0;
            try
            {
                //�жϵ�ǰҳҪ��ʾ���ټ�¼
                int alltiaoshuInt = allNewsRows;
                int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//��ȡ�����ж�������¼
                if (rePageSize1 > pageSize)//���ʣ�����������һҳ��ʾ�����ݣ�������Ҫ��ʾ����������һҳ������ʾ������
                {
                    coutw = page;
                }
                else//���ʣ�������С��һҳ��ʾ������������ʾʣ�����������������һҳ��ʾ10������ʣ��9����¼�������ʾ9����¼
                {
                    if (rePageSize1 > 0)//�����ʾ���Ǵ���0�Ĳ���С��һҳ��ʾ���������ģ���������Ľ��
                    {
                        coutw = page;
                    }
                    else//�����ɾ���������п���ɾ���������һ����¼����Ҫ��ʾ��ҳǰһҳ������
                    {
                        coutw = page - 1;
                    }
                }
                //�жϵ�ǰҳҪ��ʾ���ټ�¼
            }
            catch
            {
                coutw = page;
            }
            return coutw;
        }
        /// <summary>
        ///��ҳ��ȡ�����б�
        /// </summary>
        /// <param name="strWhere">���˵�SQL</param>
        /// <param name="page">��ǰҪ��ʾ��ҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��������Ϣ</param>
        /// <param name="rePageSize">��ǰҳҪ��ʾ��������¼������������һҳ������ʾpageSize������������һҳ������ʾrePageSize��</param>
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
        ///ͨ������һ������ı��λ����ʵ��������
        /// </summary>
        /// <param name="strWhere">���˵�SQL</param>
        /// <param name="page">��ǰҪ��ʾ��ҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��������Ϣ</param>
        /// <param name="rePageSize">��ǰҳҪ��ʾ��������¼������������һҳ������ʾpageSize������������һҳ������ʾrePageSize��</param>
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
        /// ���ز�ѯ��DATASET
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
                // 20100818 -w-���
                if (ds == null || ds.Tables[0] == null)
                {
                    DataTable dt = new DataTable();
                    ds.Tables.Add(dt);
                }
                // 20100818 -w-���
            }
            catch
            {
            }
            return ds;
        }
        /// <summary>
        /// ���ݱ�����ֺ�Ҫͳ�Ƶ��ֶ����ƣ���ͳ�Ƶ����������ؽ������������
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <param name="tableName">�������</param>
        /// <param name="coutChar">Ҫͳ�Ƶ��ֶ�����</param>
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
        ///��ҳ��ȡ�����б� author jiwei 
        ///�����������������������ģ����������������������Ϲ���
        ///2���Լ����ϵ���������
        ///���磺orderString="ISFIRST,DESC;CREATETIME,DESC"
        ///1����������
        ///���磺orderString="CREATETIME,DESC"
        /// </summary>
        /// <param name="strWhere">���˵�SQL</param>
        /// <param name="page">��ǰҪ��ʾ��ҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��������Ϣ</param>
        /// <param name="rePageSize">��ǰҳҪ��ʾ��������¼������������һҳ������ʾpageSize������������һҳ������ʾrePageSize��</param>
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
                string[] ordersArray = orderString.Split(';');//�ָ����������ַ������õ�������������
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
                        //���򣬵ڶ���orderby��ʱ����Ҫ����
                        if (orderdes == "asc" || orderdes == "ASC")
                        {
                            ordercontent2 = ordercontent2 + orderstr + " desc";
                        }
                        else if (orderdes == "desc" || orderdes == "DESC")//���򣬵ڶ���orderby��ʱ����Ҫ����
                        {
                            ordercontent2 = ordercontent2 + orderstr + " asc";
                        }
                        else
                        {//����������׳��쳣 
                            throw new Exception("����������ݳ���");
                        }
                    }
                    else
                    {
                        throw new Exception("����������ݳ���");

                    }

                }

            }


            strSql.Append("  order by " + ordercontent1 + " ) as a order by " + ordercontent2 + ")as b order by " + ordercontent1 + " ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// ������״�˵�
        /// </summary>
        /// <param name="DT">ԭʼ�����ݼ�</param>
        /// <param name="PID">���ڵ��ֶε�����</param>
        /// <param name="ColumnsPath">��Ŀ��·���ֶ�����</param>
        /// <param name="Name">��Ŀ��ʾ�������ֶ�����</param>
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
                        kg += "��";
                    }
                    DT.Rows[i][Name] = kg + "|--" + DT.Rows[i][Name].ToString();
                }
            }
            return DT;
        }

        /// <summary>
        ///���ݴ�������SQLSTRINGִ�в�ѯ����ȡ��DT
        /// </summary>
        ///<param name="sqlstring">ƴ�Ӻõ�SQL</param>
        /// <returns></returns>
        public DataSet GetDataSetBySql(string sqlstring)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(sqlstring);
            return DbHelperSQL.Query(strSql.ToString());
        }

        ////////////////////////////////////////////////////////����Ϊѧ����Ϣ����ר�÷�ҳ����/////////////////////////////////////////////////


        /// <summary>
        ///��ҳ��ȡ�����б�
        /// </summary>
        /// <param name="strWhere">���˵�SQL</param>
        /// <param name="page">��ǰҪ��ʾ��ҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��������Ϣ</param>
        /// <param name="rePageSize">��ǰҳҪ��ʾ��������¼������������һҳ������ʾpageSize������������һҳ������ʾrePageSize��</param>
        /// <param name="allNewsRows">��ǰ��¼���ж�������¼</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_Common2(string strWhere, int page, int pageSize, int allNewsRows, string tableName, string orderString)
        {

            //�жϵ�ǰҳҪ��ʾ���ټ�¼
            int alltiaoshuInt = allNewsRows;
            int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//��ȡ�����ж�������¼

            int rePageSizeCan = 0;
            if (rePageSize1 > pageSize)//���ʣ�����������һҳ��ʾ�����ݣ�������Ҫ��ʾ����������һҳ������ʾ������
            {
                rePageSizeCan = pageSize;
            }
            else//���ʣ�������С��һҳ��ʾ������������ʾʣ�����������������һҳ��ʾ10������ʣ��9����¼�������ʾ9����¼
            {
                if (rePageSize1 > 0)//�����ʾ���Ǵ���0�Ĳ���С��һҳ��ʾ���������ģ���������Ľ��
                {
                    rePageSizeCan = rePageSize1;
                }
                else//�����ɾ���������п���ɾ���������һ����¼����Ҫ��ʾ��ҳǰһҳ������
                {
                    page = page - 1;
                    rePageSizeCan = pageSize;
                }
            }
            //�жϵ�ǰҳҪ��ʾ���ټ�¼

            return GetList_FenYe2(strWhere, page, pageSize, rePageSizeCan, tableName, orderString);
        }


        /// <summary>
        ///��ҳ��ȡ�����б�
        /// </summary>
        /// <param name="strWhere">���˵�SQL</param>
        /// <param name="page">��ǰҪ��ʾ��ҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��������Ϣ</param>
        /// <param name="rePageSize">��ǰҳҪ��ʾ��������¼������������һҳ������ʾpageSize������������һҳ������ʾrePageSize��</param>
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
        ///��ҳ��ȡ�����б�
        /// </summary>
        /// <param name="strWhere">���˵�SQL</param>
        /// <param name="page">��ǰҪ��ʾ��ҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��������Ϣ</param>
        /// <param name="rePageSize">��ǰҳҪ��ʾ��������¼������������һҳ������ʾpageSize������������һҳ������ʾrePageSize��</param>
        /// <param name="allNewsRows">��ǰ��¼���ж�������¼</param>
        /// <returns></returns>
        public DataSet GetList_FenYe_Common3(string strWhere, int page, int pageSize, int allNewsRows, string tableName, string orderString)
        {

            //�жϵ�ǰҳҪ��ʾ���ټ�¼
            int alltiaoshuInt = allNewsRows;
            int rePageSize1 = alltiaoshuInt - (page - 1) * pageSize;//��ȡ�����ж�������¼

            int rePageSizeCan = 0;
            if (rePageSize1 > pageSize)//���ʣ�����������һҳ��ʾ�����ݣ�������Ҫ��ʾ����������һҳ������ʾ������
            {
                rePageSizeCan = pageSize;
            }
            else//���ʣ�������С��һҳ��ʾ������������ʾʣ�����������������һҳ��ʾ10������ʣ��9����¼�������ʾ9����¼
            {
                if (rePageSize1 > 0)//�����ʾ���Ǵ���0�Ĳ���С��һҳ��ʾ���������ģ���������Ľ��
                {
                    rePageSizeCan = rePageSize1;
                }
                else//�����ɾ���������п���ɾ���������һ����¼����Ҫ��ʾ��ҳǰһҳ������
                {
                    page = page - 1;
                    rePageSizeCan = pageSize;
                }
            }
            //�жϵ�ǰҳҪ��ʾ���ټ�¼

            return GetList_FenYe3(strWhere, page, pageSize, rePageSizeCan, tableName, orderString);
        }


        /// <summary>
        ///��ҳ��ȡ�����б�
        /// </summary>
        /// <param name="strWhere">���˵�SQL</param>
        /// <param name="page">��ǰҪ��ʾ��ҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��������Ϣ</param>
        /// <param name="rePageSize">��ǰҳҪ��ʾ��������¼������������һҳ������ʾpageSize������������һҳ������ʾrePageSize��</param>
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
        /// ���ݱ�����ֺ�Ҫͳ�Ƶ��ֶ����ƣ���ͳ�Ƶ����������ؽ������������
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <param name="tableName">�������</param>
        /// <param name="coutChar">Ҫͳ�Ƶ��ֶ�����</param>
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


        ////////////////////////////////////////////////////////����Ϊѧ����Ϣ����ר�÷�ҳ����/////////////////////////////////////////////////
        /// <summary>
        /// �����վ�ķ�����־
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
        /// ��ȡ����ǰƽ̨�����ʵĴ���
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
        /// �ж�ĳ���ĳһ�ֶ�ֵ�Ƿ�����ˡ�
        /// </summary>
        /// <param name="tabaleName">����</param>
        /// <param name="columnName">�ֶ���</param>
        /// <param name="columnValue">�ֶ�ֵ</param>
        /// <param name="keyName">������</param>
        /// <param name="keyValue">����ֵ</param>
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
        /// �ж�ĳ���ĳһ�ֶ�ֵ�Ƿ�����ˡ�
        /// </summary>
        /// <param name="tabaleName">����</param>
        /// <param name="columnName">�ֶ���</param>
        /// <param name="columnValue">�ֶ�ֵ</param>
        /// <param name="keyName">������</param>
        /// <param name="keyValue">����ֵ</param>
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

