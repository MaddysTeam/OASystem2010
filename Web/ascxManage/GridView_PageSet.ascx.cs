using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dianda.Web.ascxManage
{
    public partial class GridView_PageSet : System.Web.UI.UserControl
    {
        #region
        [Browsable(true)]
        private int _widthCommons = 600;//本页控件的宽度
        /// <summary>
        /// 设置控件宽度
        /// </summary>
        public int Width
        {
            get
            {
                if (ViewState["Width"] == null)
                { return _widthCommons; }
                else
                {
                    return int.Parse(ViewState["Width"].ToString());
                }
            }
            set { ViewState["Width"] = value; }
        }
        /// <summary>
        /// 设置控件点击与切换时触发的方法
        /// </summary>
        public event EventHandler Change_Click;

        /// <summary>
        /// 分页控件对应的ID
        /// </summary>
        public string Gridviewid
        {
            get
            {
                return ViewState["Gridviewid"].ToString();
            }
            set
            {
                ViewState["Gridviewid"] = value;
            }
        }

        /// <summary>
        /// 每页显示数目
        /// </summary>
        public int PageSize
        {
            get
            {
                return (int)ViewState["PageSize"];
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }
        /// <summary>
        /// 计算总条数的字段名称
        /// </summary>
        public string CountIndex
        {
            get { return ViewState["CountIndex"].ToString(); }
            set { ViewState["CountIndex"] = value; }
        }
        /// <summary>
        /// 要查询的表名
        /// </summary>
        public string TableNames
        {
            get { return ViewState["TableNames"].ToString(); }
            set { ViewState["TableNames"] = value; }
        }
        /// <summary>
        /// 需要查询的列全部为(*)
        /// </summary>
        public string ReFieldsStr
        {
            get { return ViewState["ReFieldsStr"].ToString(); }
            set { ViewState["ReFieldsStr"] = value; }
        }
        /// <summary>
        /// 排序字段(必须!支持多字段不用加order by)
        /// </summary>
        public string OrderString
        {
            get { return ViewState["OrderString"].ToString(); }
            set { ViewState["OrderString"] = value; }
        }
        /// <summary>
        /// 条件语句(不用加where)
        /// </summary>
        public string WhereString
        {
            get { return ViewState["WhereString"].ToString(); }
            set { ViewState["WhereString"] = value; }
        }

        /// <summary>
        /// 第几页
        /// </summary>
        public int pageindex
        {
            get
            {
                if (ViewState["pageindex"] == null) { return 0; }
                else
                {
                    return int.Parse(ViewState["pageindex"].ToString());
                }
            }
            set { ViewState["pageindex"] = value; }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LinkButton_Frist.Text = Resources.pageSet_res.LinkButton_Frist.ToString();
                LinkButton_Previous.Text = Resources.pageSet_res.LinkButton_Previous.ToString();
                LinkButton_Next.Text = Resources.pageSet_res.LinkButton_Next.ToString();
                LinkButton_End.Text = Resources.pageSet_res.LinkButton_End.ToString();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 获得数据
        /// </summary>
        /// <param name="pageindex">第几页</param>
        public void SetDataBind(int pageindex)
        {
            SetPageControl SetPageControl = new SetPageControl();
            object[] object_DT = SetPageControl.GetData(TableNames, ReFieldsStr, OrderString, WhereString, PageSize, pageindex, CountIndex);
            GridView DL = new GridView();
            DL = GetGridView();

            if (((DataTable)object_DT[0]).Rows.Count > 0)
            {
                DL.DataSource = object_DT[0];
                DL.DataBind();
                DL.Visible = true;
            }
            else
            {
                DL.Visible = false;
            }
            this.pageindex = pageindex;
            int count_all = (int)object_DT[1];
            linkbutvalue(count_all);
            if (Width != _widthCommons)
            {
                table1.Width = Width.ToString();
            }
        }
        //点击切换页数
        protected void LinkButton_Change_Click(object sender, EventArgs e)
        {
            Control ct = (Control)sender;
            if (ct is LinkButton)
            {
                LinkButton lk = (LinkButton)ct;
                SetDataBind(int.Parse(lk.CommandArgument));
            }
            else if (ct is DropDownList)
            {
                DropDownList dp = (DropDownList)ct;
                SetDataBind(int.Parse(dp.SelectedValue));
            }
            if (Change_Click != null)
            {
                Change_Click(sender, e);
            }
        }
        /// <summary>
        /// 根据ID获取GridView
        /// </summary>
        /// <returns></returns>
        private GridView GetGridView()
        {
            Control ctr = this.Parent;
            //while (ctr.Parent != null)
            //{
            ctr = ctr.Parent;
            // }
            string id = ViewState["Gridviewid"].ToString();
            GridView dl = (GridView)ctr.FindControl(id);
            return dl;

        }
        /// <summary>
        /// 设置控件属性
        /// </summary>
        private void linkbutvalue(int count_all)
        {
            int page_count = 0;
            if (count_all != 0)
            {
                if (count_all % PageSize == 0)
                {
                    page_count = Convert.ToInt32(count_all / PageSize);
                }
                else
                {
                    page_count = Convert.ToInt32(count_all / PageSize) + 1;
                }
            }
            page_count = (page_count == 0 ? 1 : page_count);
            if (pageindex == 1)
            {
                LinkButton_Frist.Enabled = false;
                LinkButton_Previous.Enabled = false;
            }
            else
            {
                LinkButton_Frist.Enabled = true;
                LinkButton_Previous.Enabled = true;
            }
            if (pageindex == page_count)
            {
                LinkButton_End.Enabled = false;
                LinkButton_Next.Enabled = false;
            }
            else
            {
                LinkButton_End.Enabled = true;
                LinkButton_Next.Enabled = true;
            }
            if (page_count == 0 || page_count == 1)
            {
                //LinkButton_Frist.Visible = false;
                //LinkButton_End.Visible = false;
                //LinkButton_Next.Visible = false;
                //LinkButton_Previous.Visible = false;
                table1.Visible = false;
            }
            else
            {
                table1.Visible = true;
            }
            LinkButton_Frist.CommandArgument = "1";
            LinkButton_End.CommandArgument = page_count.ToString();
            LinkButton_Next.CommandArgument = (pageindex + 1).ToString();
            LinkButton_Previous.CommandArgument = (pageindex - 1).ToString();

            Label_PageIndex.Text = Resources.pageSet_res.Label_PageIndex_name.Replace("[pageindex]", pageindex.ToString()).ToString();
            // "当前：第<span style='color:red'>" + pageindex + "</span>页";
            Label_All.Text = Resources.pageSet_res.Label_All_name.Replace("[count_all]", count_all.ToString()).ToString().Replace("[page_count]", page_count.ToString());
            // "共有：<span style='color:red'>" + count_all + "</span>条记录 共：<span style='color:red'>" + page_count + "</span>页";
            DropDownList_ChangPage.Items.Clear();
            for (int i = 0; i < page_count; i++)
            {
                ListItem ls = new ListItem(Resources.pageSet_res.ls_name.Replace("[i]", (i + 1).ToString()).ToString(), (i + 1).ToString());
                //"第" + (i + 1) + "页"
                DropDownList_ChangPage.Items.Add(ls);
            }
            DropDownList_ChangPage.SelectedValue = pageindex.ToString();
        }
    }
    public class SetPageControl
    {

        /// <summary>
        /// 根据条件得到数据集和总数目
        /// </summary>
        /// <param name="TableName">需要查询的表名</param>
        /// <param name="ReFieldsStr">需要查询的列全部为(*)</param>
        /// <param name="OrderString">排序字段(必须!支持多字段不用加order by)</param>
        /// <param name="WhereString">条件语句(不用加where)</param>
        /// <param name="PageSize">每页多少条记录</param>
        /// <param name="PageIndex">指定当前为第几页</param>
        /// <param name="CountIndex">计算总条数的关键字段名称</param>
        /// <returns>返回一个DataTable和总共数目</returns>
        public object[] GetData(string TableName, string ReFieldsStr, string OrderString, string WhereString, int PageSize, int PageIndex, string CountIndex)
        {
            string SQL_CON = ConnectionString;
            using (SqlConnection cnn = new SqlConnection(SQL_CON))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cnn.Open();
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "getpage";
                        setcon(cmd, TableName, ReFieldsStr, OrderString, WhereString, PageSize, PageIndex, CountIndex);
                        DataSet DS = new DataSet();
                        SqlDataAdapter Da = new SqlDataAdapter(cmd);
                        Da.Fill(DS);
                        int retn = int.Parse(cmd.Parameters["@TotalRecord"].Value.ToString());
                        return new object[] { DS.Tables[0], retn };

                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        cnn.Close();
                        return new object[] { new DataTable(), 0 };
                        // throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="TableName">数据表名称（视图名称）</param>
        /// <param name="ReFieldsStr"></param>
        /// <param name="OrderString"></param>
        /// <param name="WhereString"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        private void setcon(SqlCommand cmd, string TableName, string ReFieldsStr, string OrderString, string WhereString, int PageSize, int PageIndex, string CountIndex)
        {
            //设置存储过程计算总条数的字段
            SqlParameter prm0 = new SqlParameter();
            prm0.ParameterName = "@CountIndex";
            prm0.SqlDbType = SqlDbType.VarChar;
            prm0.Size = 50;
            prm0.Value = CountIndex;
            prm0.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm0);
            //设置存储过程参数
            SqlParameter prm = new SqlParameter();
            prm.ParameterName = "@TableName";
            prm.SqlDbType = SqlDbType.VarChar;
            prm.Size = 50;
            prm.Value = TableName;
            prm.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm);
            //设置存储过程参数
            SqlParameter prm1 = new SqlParameter();
            prm1.ParameterName = "@ReFieldsStr";
            prm1.SqlDbType = SqlDbType.VarChar;
            prm1.Size = 200;
            prm1.Value = ReFieldsStr;
            prm1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm1);
            //设置存储过程参数
            SqlParameter prm2 = new SqlParameter();
            prm2.ParameterName = "@OrderString";
            prm2.SqlDbType = SqlDbType.VarChar;
            prm2.Size = 200;
            prm2.Value = OrderString;
            prm2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm2);
            //设置存储过程参数
            SqlParameter prm3 = new SqlParameter();
            prm3.ParameterName = "@WhereString";
            prm3.SqlDbType = SqlDbType.VarChar;
            prm3.Size = 1000;
            prm3.Value = WhereString;
            prm3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm3);
            //设置存储过程参数
            SqlParameter prm4 = new SqlParameter();
            prm4.ParameterName = "@PageSize";
            prm4.SqlDbType = SqlDbType.Int;
            prm4.Size = 50;
            prm4.Value = PageSize;
            prm4.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm4);
            //设置存储过程参数
            SqlParameter prm5 = new SqlParameter();
            prm5.ParameterName = "@PageIndex";
            prm5.SqlDbType = SqlDbType.VarChar;
            prm5.Size = 50;
            prm5.Value = PageIndex;
            prm5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(prm5);
            //设置存储过程参数
            SqlParameter prm6 = new SqlParameter();
            prm6.ParameterName = "@TotalRecord";
            prm6.SqlDbType = SqlDbType.VarChar;
            prm6.Size = 50;
            prm6.Value = null;
            prm6.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(prm6);
        }
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                //string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                //if (ConStringEncrypt == "true")
                //{
                // _connectionString = DESEncrypt.Decrypt(_connectionString);
                //}
                return _connectionString;
            }
        }
    }
}