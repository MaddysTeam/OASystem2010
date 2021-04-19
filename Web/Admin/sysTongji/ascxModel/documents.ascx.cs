using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Reflection;

namespace Dianda.Web.Admin.sysTongji.ascxModel
{
    public partial class documents : System.Web.UI.UserControl
    {
        BLL.Document_Folder bDF = new Dianda.BLL.Document_Folder();//加载栏目的列表树
        COMMON.common commons = new Dianda.COMMON.common();
        BLL.Document_FolderExt bdFExt = new Dianda.BLL.Document_FolderExt();
        Model.USER_Users user_model = new Dianda.Model.USER_Users();
        COMMON.pageControl pagecontrols = new Dianda.COMMON.pageControl();
        Model.Document_Folder mdFolder = new Dianda.Model.Document_Folder();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 根据当前的项目的ID获取到统计的数据
        /// </summary>
        /// <param name="projectid"></param>
        private void tongji(string projectid)
        {
            try
            {
                string sql1 = "select count(ID) as nums from Document_Folder where Types='public' and ProjectID='" + projectid + "' and DELFLAG='0'";//该项目共有多少个栏目，
                string sql2 = "SELECT COUNT(ID) AS nums, SUM(Sizeof) AS sizeoftotal FROM  Document_File where FolderID in(select id from Document_Folder where Types='public' and ProjectID='" + projectid + "' and DELFLAG='0') and DELFLAG=0";//统计出有多少商品和商品总大小
                DataTable dt1 = pagecontrols.doSql(sql1).Tables[0];
                string coutw = "";
                if (dt1.Rows.Count > 0)
                {
                    coutw = "此项目中共有&nbsp;" + dt1.Rows[0]["nums"].ToString() + "&nbsp;个文档目录！<br/>";
                    DataTable dt2 = pagecontrols.doSql(sql2).Tables[0];
                    if (dt2.Rows.Count > 0)
                    {
                        coutw = coutw + "此项目中共有&nbsp;" + dt2.Rows[0]["nums"].ToString() + "&nbsp;个文件！<br/>";
                        coutw = coutw + "此项目中文件共&nbsp;" + dt2.Rows[0]["sizeoftotal"].ToString() + "&nbsp;K";
                    }
                }
                Label_tongji.Text = coutw;
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据文件的属性是项目的还是个人的，还有用户的ID，项目的ID获取到列表
        /// </summary>
        /// <param name="userid">用户的ID</param>
        /// <param name="types">文件的归类：public是项目的文件夹；private是个人的文件夹</param>
        /// <param name="projectid">项目的ID(select in ('0','ds')的方式)</param>
        /// <param name="expID">如果有要展开的节点，则直接展开</param>
        /// <param name="tp">要展开的页卡的号头</param>
        /// <param name="TreeView2">先显示的目录树</param>
        public void makeTreeByProjectid(string projectid, string expID)
        {
            TreeView tview = TreeView2;
            try
            {
                HiddenField_projectid.Value = projectid;
                tongji(projectid);//统计
                //根据用户的ID，获取到当前用户参与的项目ID集合

                DataTable DTColumns = bdFExt.makeProjectFolder(projectid);
               
                // 有子栏目,则显示树
                if (DTColumns.Rows.Count > 0)
                {
                    tview.Nodes.Clear();
                    TreeNode n = new TreeNode();
                    for (int i = 0; i < DTColumns.Rows.Count; i++)
                    {
                        TreeNode t = new TreeNode();
                        string isshare = DTColumns.Rows[i]["IsShare"].ToString();//是否共享
                        string issharestring = "";
                        if (isshare == "1")
                        {
                            issharestring = "";
                        }
                        t.Text = DTColumns.Rows[i]["FolderName"].ToString() + issharestring;
                        t.Value = DTColumns.Rows[i]["ID"].ToString();
                        if (DTColumns.Rows[i]["UpID"].ToString() != "38")
                        {
                            string _s = DTColumns.Rows[i]["COLUMNSPATH"].ToString().Remove(DTColumns.Rows[i]["COLUMNSPATH"].ToString().IndexOf("/" + DTColumns.Rows[i]["ID"].ToString()));
                            while (_s.StartsWith("-1/38/"))
                            {
                                _s = _s.Substring(6);
                            }
                            n = tview.FindNode(_s);
                            n.ChildNodes.Add(t);
                            if (expID != "")
                            {
                                t.Expanded = nodeIsExp(t.Value.ToString(), expID);
                            }

                        }
                        else
                        {
                            setColoumnsSon(t.Value.ToString(), projectid);//当出现根栏目时，显示根栏目的下级数据
                            tview.Nodes.Add(t);
                        }
                    }
                }
            }
            catch
            {
            }
            tview.ExpandAll();
        }
        /// <summary>
        /// 判断当前的节点是否在路径中
        /// </summary>
        /// <param name="id"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool nodeIsExp(string id, string path)
        {
            bool coutw = false;
            try
            {
                //将PATH中的所有节点都展开
                string[] patharray = path.Split('/');
                for (int i = 0; i < patharray.Length; i++)
                {
                    if (id == patharray[i].ToString())
                    {
                        coutw = true;
                        break;
                    }
                }
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 当节点被点击后树2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TreeView1_SelectedNodeChanged2(object sender, EventArgs e)
        {
            string strValue = this.TreeView2.SelectedNode.Value;
            setColoumnsSon(strValue, HiddenField_projectid.Value.ToString());
            this.TreeView2.SelectedNode.Expand();
        }
        /// <summary>
        /// 将指定的栏目的列表加载出来
        /// </summary>
        /// <param name="folderid"></param>
        public void setColoumnsSon(string folderid,string projectid)
        {
            showFoldelist(folderid, projectid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");
                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    string FolderName = DataBinder.Eval(e.Row.DataItem, "FolderName").ToString();
                    LinkButton LinkButton_FOLDER = (LinkButton)e.Row.Cells[1].FindControl("LinkButton_FOLDER");
                    LinkButton_FOLDER.Text = FolderName;
                    hid.Value = ID;
                    //上级栏目的ID为0的文件夹都不能操作
                    string upid = DataBinder.Eval(e.Row.DataItem, "upid").ToString();
                    if (upid == "0")
                    {
                        CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("CheckBox_choose");
                        cb.Checked = false;
                        cb.Enabled = false;
                        cb.Visible = false;
                        // e.Row.Cells[0].Text = "固";
                        e.Row.Visible = false;

                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");
                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;
                    string Sizeof = DataBinder.Eval(e.Row.DataItem, "Sizeof").ToString();
                    if (Sizeof.Length > 3)
                    {
                        double sizeofd = double.Parse(Sizeof);
                        sizeofd = Math.Round(sizeofd / 1024, 2);
                        e.Row.Cells[4].Text = sizeofd.ToString() + "M";
                    }
                    if (Sizeof.Length > 7)
                    {
                        double sizeofd = double.Parse(Sizeof);
                        sizeofd = Math.Round(sizeofd / 1024 / 1024, 2);
                        e.Row.Cells[4].Text = sizeofd.ToString() + "G";
                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 点击全选框时触发事件(目录的全选)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox_choose_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox CheckBox_Alltemp = (CheckBox)sender;
                setAllCheck(GridView1, CheckBox_Alltemp.Checked);
                setAllCheck(GridView2, CheckBox_Alltemp.Checked);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据指定的控件和要显示确定与否设置控件的状态
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="ischeck"></param>
        private void setAllCheck(GridView gv, bool ischeck)
        {
            try
            {
                int i = gv.Rows.Count;
                for (int j = 0; j < i; j++)
                {
                    CheckBox cb = (CheckBox)gv.Rows[j].Cells[0].FindControl("CheckBox_choose");
                    cb.Checked = ischeck;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据指定的目录的ID，构造这个目录下面的SQL
        /// </summary>
        /// <param name="FolderID"></param>
        /// <returns></returns>
        private string makesql(string FolderID)
        {
            string sql = "";
            try
            {
                if (FolderID.Length > 0)
                {
                    sql = " FolderID='" + FolderID + "' and DELFLAG='0'";
                }
                else
                {
                    sql = " DELFLAG='999'";
                }
            }
            catch
            {
                sql = " DELFLAG='999'";
            }
            return sql;
        }
        /// <summary>
        /// 根据条件查询人员信息列表
        /// </summary>
        /// <param name="pageindex">页码</param>
        /// <param name="depart">部门</param>
        /// <param name="workstatus">工作状态</param>
        protected void ShowList(string FolderID)
        {
            try
            {
                DataTable DT = new DataTable();
                string sqlWhere1 = makesql(FolderID);
                string sqls = "select * from vDocument_File where " + sqlWhere1 + "  order by DATETIME DESC";
                DT = pagecontrols.doSql(sqls).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    if (GridView1.Visible)
                    {
                        GridView2.ShowHeader = false;
                    }
                    else
                    {
                        GridView2.ShowHeader = true;
                    }
                    this.GridView2.Visible = true;
                    this.GridView2.DataSource = DT;//指定GridView1的数据是DT
                    this.GridView2.DataBind();//将上面指定的信息绑定到GridView1上
                 
                }
                else
                {
                    this.GridView2.Visible = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据上级文档的ID和项目的ID，获取到当前栏目的列表
        /// </summary>
        /// <param name="FolderID"></param>
        /// <param name="projectid"></param>
        protected void showFoldelist(string FolderID, string projectid)
        {
            try
            {
                string sql = "select * from  vDocument_Folder where Types='public' and  (UpID='" + FolderID + "') and ProjectID='" + projectid + "' and DELFLAG='0' and UpID<>'-1' order by COLUMNSPATH";
                DataTable  dt = pagecontrols.doSql(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                  
                    this.GridView1.Visible = true;
                    this.GridView1.DataSource = dt;//指定GridView1的数据是dv
                    this.GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    this.GridView1.Columns[4].Visible = false;
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    this.GridView1.Visible = false;
                }
                ///加载这个目录的子文件
                HiddenField_FolderID.Value = FolderID;
                // setRowCout(upid);
                ShowList(FolderID);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 批量下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_downs_Click(object sender, EventArgs e)
        {
            try
            {
                //从数据集合中获取到要处理的那个条目
                ArrayList doarray = getDoarray_duo();
                string folderid = "";//文件夹的ID
                string fileid = "";//文件的ID
                if (doarray != null && doarray.Count > 0)
                {
                    //对于要取消共享的条目进行操作
                    for (int i = 0; i < doarray.Count; i++)
                    {
                        string[] doarrays = doarray[i].ToString().Split(',');
                        if (doarrays[1].ToString() == "1")
                        {
                            folderid = folderid + doarrays[0].ToString() + ";";//要处理的文件夹的ID
                        }
                        if (doarrays[1].ToString() == "2")
                        {
                            fileid = fileid + doarrays[0].ToString() + ";";//要处理的文件的ID
                        }
                    }
                   // Response.Redirect("downloads.aspx?foldeid=" + folderid + "&fileid=" + fileid);
                    setParent(folderid, fileid);//调用父页面中的下载控制函数
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('没有可以操作的数据！')", true);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 获取要处理的条目的数组
        /// </summary>
        /// <returns></returns>
        private string[] getDoarray()
        {
            string[] coutw2 = { "", "" };
            try
            {
                string choosestring = getChoose();
                string[] items = choosestring.Split(';');
                if (items.Length != 2 || choosestring.Length == 0)
                {
                    string coutw = "";
                    if (choosestring.Length == 0)
                    {
                        coutw = "请选择一条您要操作的条目！";
                    }
                    else
                    {
                        coutw = "您刚才选择了" + (items.Length - 1).ToString() + "条！";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('每次仅能对1个条目进行操作！" + coutw + "')", true);
                }
                else
                {
                    string doitems = "";
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].ToString().Length > 0)
                        {
                            doitems = items[i].ToString();
                            break;
                        }
                    }
                    //从数据集合中获取到要处理的那个条目
                    string[] doarray = doitems.Split(',');
                    coutw2 = doarray;
                }
            }
            catch
            {
            }
            return coutw2;
        }
        /// <summary>
        /// 获取操作多个记录的文件夹和文件数据
        /// </summary>
        /// <returns></returns>
        private ArrayList getDoarray_duo()
        {
            ArrayList al = new ArrayList();
            try
            {
                string choosestring = getChoose();
                string[] items = choosestring.Split(';');
                if (items.Length > 1)
                {
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].ToString().Trim().Length > 2)
                        {
                            al.Add(items[i]);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('请至少选择一条您要操作的记录！')", true);
                }
            }
            catch
            {
            }
            return al;
        }

        /// <summary>
        /// 获取到当前已经选择的项的ID值及类型
        /// </summary>
        /// <returns></returns>
        private string getChoose()
        {
            string coutw = "";
            try
            {
                //先从G1中找
                int g1 = GridView1.Rows.Count;
                string g1string = "";
                for (int i = 0; i < g1; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    HiddenField hid = (HiddenField)GridView1.Rows[i].Cells[0].FindControl("Hid_ID");
                    if (cb.Checked)
                    {
                        g1string = g1string + hid.Value.ToString() + ",1" + ";";//文件夹
                    }
                }
                //再从G2中找
                string g2string = "";
                int g2 = GridView2.Rows.Count;
                for (int i = 0; i < g2; i++)
                {
                    CheckBox cb = (CheckBox)GridView2.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    HiddenField hid = (HiddenField)GridView2.Rows[i].Cells[0].FindControl("Hid_ID");
                    if (cb.Checked)
                    {
                        g2string = g2string + hid.Value.ToString() + ",2" + ";";//文件
                    }
                }
                coutw = g1string + ";" + g2string;
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 将构建的选中的项处理一次
        /// </summary>
        /// <param name="older"></param>
        /// <returns></returns>
        private string makestring(string older)
        {
            string coutw = "";
            try
            {
                string[] olarray = older.Split(';');
                for (int i = 0; i < olarray.Length; i++)
                {
                    if (olarray[i].ToString().Length > 0)
                    {
                        coutw = coutw + olarray[i].ToString() + ";";
                    }
                }

            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 栏目的切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_FOLDER_Click(object sender, EventArgs e)
        {
            try
            {
                string fid = ((LinkButton)sender).CommandArgument.ToString();
                showFoldelist(fid, HiddenField_projectid.Value.ToString());
            }
            catch
            {
            }
        }
        /// <summary>
        /// 调用父页面的操作
        /// </summary>
        /// <param name="folderid"></param>
        /// <param name="fileids"></param>
        private void setParent(string folderid, string fileids)
        {
            Page p = this.Parent.Page;
            Type pageType = p.GetType();
            MethodInfo mi = pageType.GetMethod("downloads_control");
            mi.Invoke(p, new object[] { folderid, fileids});
        }
        /// <summary>
        /// 返回主窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Page p = this.Parent.Page;
            Type pageType = p.GetType();
            MethodInfo mi = pageType.GetMethod("controls_Show");
            mi.Invoke(p, new object[] { "maincontrol" });
        }

    }
}