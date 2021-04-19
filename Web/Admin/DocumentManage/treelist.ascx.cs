using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class treelist : System.Web.UI.UserControl
    {
        BLL.Document_Folder bDF = new Dianda.BLL.Document_Folder();//加载栏目的列表树
        COMMON.common commons = new Dianda.COMMON.common();
        BLL.Document_FolderExt bdFExt = new Dianda.BLL.Document_FolderExt();
        Model.USER_Users user_model = new Dianda.Model.USER_Users();

        public string TJ
        {
            get
            {
                if (ViewState["TJ"] != null)
                    return ViewState["TJ"].ToString();
                return null;
            }
            set { ViewState["TJ"] = value; }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string TabPanel22 = "";
                TabPanel22 = Request["tp"];
                if (Session["Session_Project_linkshow"] != null)
                {
                    if (TabPanel22 != null)
                    {
                        TabPanel22 = "1";
                        TabPanel_my.Visible = false;
                        TabPanel_share.Visible = false;
                    }
                    else
                    {
                        TabPanel22 = "1";
                        TabPanel_my.Visible = false;
                        TabPanel_share.Visible = false;
                    }
                }




                if (TabPanel22 == null || TabPanel22 == "" || TabPanel22 == "0")
                {
                    TabContainer_listtree.ActiveTabIndex = 0;
                }
                else
                {
                    TabContainer_listtree.ActiveTabIndex = int.Parse(TabPanel22);
                }

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
        public void makeTreeByUserid(string userid, string types, string projectid, string expID, string tp)
        {
            try
            {
                TreeView tview = TreeView1;
                DataTable DTColumns = bdFExt.makeFolder(userid, types, projectid);
                string selectid = "";
                if (expID != null && expID != "")
                {
                    string[] expids = expID.Split('/');
                    if (expids.Length > 0)
                    {
                        selectid = expids[expids.Length - 1].ToString();
                    }
                }

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
                        if (DTColumns.Rows[i]["UpID"].ToString() != "-1")
                        {
                            string _s = DTColumns.Rows[i]["COLUMNSPATH"].ToString().Remove(DTColumns.Rows[i]["COLUMNSPATH"].ToString().IndexOf("/" + DTColumns.Rows[i]["ID"].ToString()));
                            while (_s.StartsWith("-1/"))
                            {
                                _s = _s.Substring(3);
                            }
                            n = tview.FindNode(_s);
                            n.ChildNodes.Add(t);
                            if (expID != "")
                            {
                                t.Expanded = nodeIsExp(t.Value.ToString(), expID);
                                if (t.Value.ToString() == selectid)
                                {
                                    t.Selected = true;
                                    setColoumnsSon(selectid, false, tp);//加载窗体
                                }
                            }
                        }
                        else
                        {
                            //t.Text = t.Text.ToString() + "&nbsp;&nbsp;<a href='addtreeND.aspx?userid=" + userid + "&tp=0'  target='_self' title='档案管理> 新建目录'>新建目录</a>";
                            setColoumnsSon(t.Value.ToString(), false, tp);//当出现根栏目时，显示根栏目的下级数据
                            tview.Nodes.Add(t);
                            if (selectid == "" || selectid == null)
                            {
                                t.Selected = true;
                            }
                            if (t.Value.ToString() == selectid)
                            {
                                t.Selected = true;
                            }

                        }
                    }

                    tview.ExpandDepth = 2;
                }
                //else
                //{
                //    setColoumnsSon(null, false, tp);//如果没有数据，则清除右边的列表
                //}
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
        public void makeTreeByProjectid(string userid, string types, string expID, string tp)
        {
            try
            {
                //根据用户的ID，获取到当前用户参与的项目ID集合
                string projectid = "";
                if (Session["Work_ProjectId"] != null)
                {
                    projectid = Session["Work_ProjectId"].ToString();
                }
                TreeView tview = TreeView2;

                DataTable DTColumns = bdFExt.makeFolder1(userid, types, projectid, TJ);
                string selectid = "";
                if (expID != null && expID != "")
                {
                    string[] expids = expID.Split('/');
                    if (expids.Length > 0)
                    {
                        selectid = expids[expids.Length - 1].ToString();
                    }
                }
                tview.Nodes.Clear();

                // 有子栏目,则显示树
                if (DTColumns.Rows.Count > 0)
                {
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
                        if (DTColumns.Rows[i]["UpID"].ToString() == "38")
                        {
                            //项目的状态 1表示正常运行中,0表示待审核，2表示审核不通过，3暂停，4表示草稿箱中，5表示完成
                            string status = DTColumns.Rows[i]["Status"].ToString();
                            if (status != "1")
                            {
                                if (status == "3")
                                {
                                    status = "[暂停]";
                                }
                                else if (status == "5")
                                {
                                    status = "[完成]";
                                }
                                else
                                {
                                    status = "";
                                }
                            }
                            else
                            {
                                status = "";
                            }
                            issharestring = issharestring + status;

                        }

                        t.Text = DTColumns.Rows[i]["FolderName"].ToString() + issharestring;


                        t.Value = DTColumns.Rows[i]["ID"].ToString();
                        if (DTColumns.Rows[i]["UpID"].ToString() != "-1")
                        {
                            string _s = DTColumns.Rows[i]["COLUMNSPATH"].ToString().Remove(DTColumns.Rows[i]["COLUMNSPATH"].ToString().IndexOf("/" + DTColumns.Rows[i]["ID"].ToString()));
                            while (_s.StartsWith("-1/"))
                            {
                                _s = _s.Substring(3);
                            }
                            n = tview.FindNode(_s);
                            n.ChildNodes.Add(t);
                            if (expID != "")
                            {
                                t.Expanded = nodeIsExp(t.Value.ToString(), expID);
                                if (t.Value.ToString() == selectid)
                                {
                                    t.Selected = true;
                                    setColoumnsSon(selectid, true, tp);//加载窗体
                                }
                            }
                        }
                        else
                        {
                            //t.Text = t.Text.ToString() + "&nbsp;&nbsp;<a href='addtreeND.aspx?userid=" + userid + "&tp=1'  target='_self' title='档案管理> 新建目录'>新建目录</a>";
                            setColoumnsSon(t.Value.ToString(), true, tp);//当出现根栏目时，显示根栏目的下级数据
                            tview.Nodes.Add(t);
                            if (selectid == "" || selectid == null)
                            {
                                t.Selected = true;
                            }
                            if (t.Value.ToString() == selectid)
                            {
                                t.Selected = true;
                            }

                        }
                    }
                    tview.ExpandDepth = 2;
                    tview.Nodes[0].Expanded = true;
                }
                //else
                //{
                //    tview.Nodes.Clear();
                //    setColoumnsSon(null, false, tp);//如果没有数据，则清除右边的列表
                //}
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
        public void makeTreeBySystem(string userid, string expID, string tp)
        {
            try
            {
                //根据用户的ID，获取到当前用户参与的项目ID集合

                TreeView tview = TreeView3;
                DataTable DTColumns = bdFExt.makeFolder(userid, "", "");
                string selectid = "";

                if (expID != null && expID != "")
                {
                    string[] expids = expID.Split('/');
                    if (expids.Length > 0)
                    {
                        selectid = expids[expids.Length - 1].ToString();
                    }
                }

                TreeNode t1 = new TreeNode();
                t1.Text = "共享文档";
                t1.Value = userid;
                tview.Nodes.Add(t1);
                bool isdo = false;//是否做过栏目的显示
                // 有子栏目,则显示树
                if (DTColumns.Rows.Count > 0)
                {
                    //tview.Nodes.Clear();
                    TreeNode n = new TreeNode();
                    for (int i = 0; i < DTColumns.Rows.Count; i++)
                    {
                        TreeNode t = new TreeNode();

                        t.Text = DTColumns.Rows[i]["realname"].ToString() + "[" + DTColumns.Rows[i]["username"].ToString() + "]";
                        t.Value = DTColumns.Rows[i]["userid"].ToString();
                        if (DTColumns.Rows[i]["shareForuser"].ToString() != "0")
                        {
                            string _s = DTColumns.Rows[i]["paths"].ToString().Remove(DTColumns.Rows[i]["paths"].ToString().IndexOf("/" + DTColumns.Rows[i]["userid"].ToString()));
                            string startwith = userid + "/";
                            while (_s.StartsWith(startwith))
                            {
                                _s = _s.Substring(startwith.Length);
                            }
                            n = tview.FindNode(_s);
                            n.ChildNodes.Add(t);
                            if (expID != "" && expID != null)
                            {
                                t.Expanded = nodeIsExp(t.Value.ToString(), expID);
                                if (t.Value.ToString() == selectid)
                                {
                                    t.Selected = true;
                                    setColoumnsSon(selectid, false, tp);//加载窗体
                                    isdo = true;
                                }
                            }
                        }
                        else
                        {
                            t.Text = t.Text.ToString();
                            setColoumnsSon(t.Value.ToString(), false, tp);//当出现根栏目时，显示根栏目的下级数据
                            isdo = true;
                            tview.Nodes.Add(t);
                            if (selectid == "" || selectid == null)
                            {
                                t.Selected = true;
                            }
                            if (t.Value.ToString() == selectid)
                            {
                                t.Selected = true;
                            }
                        }
                    }

                    tview.ExpandDepth = 2;
                }

                if (!isdo)//没有加载过列表，则初始化一个
                {
                    setColoumnsSon(userid, false, tp);//如果没有数据，则清除右边的列表
                }
            }
            catch
            {
            }

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
        /// 当节点被点击后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            string strValue = this.TreeView1.SelectedNode.Value;
            setColoumnsSon(strValue, false, "0");
            this.TreeView1.SelectedNode.Expand();
        }
        /// <summary>
        /// 当节点被点击后树2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TreeView1_SelectedNodeChanged2(object sender, EventArgs e)
        {
            string strValue = this.TreeView2.SelectedNode.Value;
            setColoumnsSon(strValue, true, "1");
            this.TreeView2.SelectedNode.Expand();
        }
        /// <summary>
        /// 当节点被点击后树3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TreeView1_SelectedNodeChanged3(object sender, EventArgs e)
        {
            string strValue = this.TreeView3.SelectedNode.Value;
            setColoumnsSon(strValue, false, "2");
            this.TreeView3.SelectedNode.Expand();
        }

        /// <summary>
        /// 加载主窗口中的列表
        /// </summary>
        /// <param name="fatherID"></param>
        public void setColoumnsSon(string fatherID, bool isProject, string tp)
        {
            try
            {
                Page p = this.Parent.Page;
                Type pageType = p.GetType();
                MethodInfo mi = pageType.GetMethod("showSonFolder");
                mi.Invoke(p, new object[] { fatherID, isProject, tp });
            }
            catch
            {
            }
        }
        /// <summary>
        /// 当页卡的选择项发生变化后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TabContainer_listtree_ActiveTabChanged(object sender, EventArgs e)
        {
            string cid = "";
            if (TabContainer_listtree.ActiveTabIndex.ToString() == "2")
            {
                user_model = (Model.USER_Users)Session["USER_Users"];//实例化
                cid = "&CID=" + user_model.ID.ToString();
            }
            Response.Redirect("manage.aspx?tp=" + TabContainer_listtree.ActiveTabIndex.ToString() + cid);
        }

    }
}