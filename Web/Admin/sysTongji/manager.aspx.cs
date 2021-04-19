using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.sysTongji
{
    public partial class manager : System.Web.UI.Page
    {
        COMMON.pageControl dosqls = new Dianda.COMMON.pageControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目汇总";
                    //设置模板页中的管理值
                    Model.USER_Users user_model = new Dianda.Model.USER_Users();
                    user_model = (Model.USER_Users)Session["USER_Users"];//实例化
                    makeTreeByUserid(user_model, "");
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据当前用户，查找该用户的管理范围内项目列表
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="expID"></param>
        public void makeTreeByUserid(Model.USER_Users usermodel, string expID)
        {
            try
            {
                //DataTable dtw=new DataTable();
                //dtw =dosqls.doSql("select ID,UpID,Names,COLUMNSPATH,TYPES from Project_Columns where  DELFLAG=0 order by COLUMNSPATH").Tables[0];//先找出当前用户的管理项目的分类的列表
                //if (dtw.Rows.Count > 0)
                //{
                //    TreeView2.DataSource = dtw;
                //    TreeView2.DataBind();
                //}


                TreeView tview = TreeView1;
                string userinforslike = usermodel.REALNAME.ToString() + "(" + usermodel.USERNAME.ToString() + ")";

                string sqls = "select ID,UpID,Names,COLUMNSPATH,TYPES from Project_Columns where UserInfos like '%" + userinforslike + "%' and DELFLAG=0 order by COLUMNSPATH";//先找出当前用户的管理项目的分类的列表
                string sqls2 = "select ID,NAMES,status,columnsID,delflag from Project_Projects where columnsID in(select ID from Project_Columns where UserInfos like '%" + userinforslike + "%' and DELFLAG=0) and status in('1','3','5') order by status ASC,delflag asc";//在找出该用户管理栏目下面的所有项目

                DataTable dtc = dosqls.doSql(sqls).Tables[0];//栏目的列表
                DataTable dtp = dosqls.doSql(sqls2).Tables[0];//项目的列表
                if (dtc != null)
                {
                    if (dtc.Rows.Count > 0)
                    {
                        tview.Nodes.Clear();
                        TreeNode n = new TreeNode();

                        TreeNode t1 = new TreeNode();
                        t1.Text = usermodel.REALNAME.ToString() + "(" + usermodel.USERNAME.ToString() + ")管理的项目分类/规划";
                        t1.Value = "1";
                        tview.Nodes.Add(t1);
                        for (int i = 0; i < dtc.Rows.Count; i++)
                        {
                            TreeNode t = new TreeNode();
                            t.Text = dtc.Rows[i]["Names"].ToString() + "[" + dtc.Rows[i]["TYPES"].ToString() + "]";
                            t.Value = dtc.Rows[i]["ID"].ToString();
                            if (dtp.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtp.Rows.Count; j++)
                                {
                                    if (dtp.Rows[j]["columnsID"].ToString() == dtc.Rows[i]["ID"].ToString())
                                    {
                                        string status = dtp.Rows[j]["status"].ToString();// 1表示正常运行中,0表示待审核，2表示审核不通过，3暂停，4表示草稿箱中，5表示完成
                                        string delflags = dtp.Rows[j]["delflag"].ToString();
                                        if (delflags == "1")
                                        {
                                            status = "删除";
                                        }
                                        else
                                        {
                                            if (status == "1")
                                            {
                                                status = "运行";
                                            }
                                            if (status == "3")
                                            {
                                                status = "暂停";
                                            }
                                            if (status == "5")
                                            {
                                                status = "完成";
                                            }
                                        }
                                        TreeNode t2 = new TreeNode();
                                        t2.Text = dtp.Rows[j]["NAMES"].ToString() + "[" + status + "]";
                                        t2.Value = dtp.Rows[j]["ID"].ToString();
                                        TreeNode tt1 = new TreeNode();
                                        TreeNode tt2 = new TreeNode();
                                        TreeNode tt3 = new TreeNode();
                                        TreeNode tt4 = new TreeNode();
                                        TreeNode tt5 = new TreeNode();
                                        TreeNode tt6 = new TreeNode();

                                        tt1.Text = "项目任务";
                                        tt1.Value = dtp.Rows[j]["ID"].ToString() + "_1";

                                        tt2.Text = "项目文档";
                                        tt2.Value = dtp.Rows[j]["ID"].ToString() + "_2";

                                        tt3.Text = "项目资源";
                                        tt3.Value = dtp.Rows[j]["ID"].ToString() + "_3";

                                        //tt4.Text = "项目消息";
                                        //tt4.Value = dtp.Rows[j]["ID"].ToString() + "_4";

                                        tt5.Text = "项目经费";
                                        tt5.Value = dtp.Rows[j]["ID"].ToString() + "_5";

                                        tt6.Text = "项目成员";
                                        tt6.Value = dtp.Rows[j]["ID"].ToString() + "_6";

                                        t2.ChildNodes.Add(tt1);
                                        t2.ChildNodes.Add(tt2);
                                        t2.ChildNodes.Add(tt3);
                                       // t2.ChildNodes.Add(tt4);
                                        t2.ChildNodes.Add(tt5);
                                        t2.ChildNodes.Add(tt6);

                                        t.ChildNodes.Add(t2);
                                    }
                                }
                            }
                            t1.ChildNodes.Add(t); //tview.Nodes.Add(t);
                            
                        }
                    }
                }
                tview.ExpandDepth = 2;

            }
            catch
            {
            }

        }
        /// <summary>
        /// 当节点被点击后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
             string strValue = this.TreeView1.SelectedNode.Value;
            //setColoumnsSon(strValue, false, "0");
             setColoumnsSon(strValue);
           
             this.TreeView1.SelectedNode.Expand();
        }
        /// <summary>
        /// 展开树传递过来的资源
        /// </summary>
        /// <param name="values"></param>
        private void setColoumnsSon(string values)
        {
            try
            {
                //只对"项目任务_1";"项目文档_2"；"项目资源_3";"项目消息_4"; "项目经费_5"; "项目成员_6"；进行数据的处理
                if (values.Contains("_1") || values.Contains("_2") || values.Contains("_3") || values.Contains("_4") || values.Contains("_5") || values.Contains("_6"))
                {
                    string[] arrays = values.Split('_');
                    if (values.Contains("_6"))
                    {
                        usermember1.showDepartment(arrays[0].ToString());
                        controls_Show("maincontrol");//只显示主窗口
                        usermember1.Visible = true;
                        projectTask1.Visible = false;
                        projectApply1.Visible = false;
                        cashApply1.Visible = false;
                    }
                    if(values.Contains("_2"))
                    {
                       
                        controls_Show("docmain");//只显示项目文档
                        documents1.makeTreeByProjectid(arrays[0].ToString(), "");

                        usermember1.Visible = false;
                        projectTask1.Visible = false;
                        projectApply1.Visible = false;
                        cashApply1.Visible = false;
                        this.TreeView1.SelectedNode.Parent.Selected = true;
                        //设置模板页中的管理值
                        (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目统计 > 项目文档";
                        //设置模板页中的管理值
                    }
                    if (values.Contains("_1"))//项目任务
                    {
                       
                        projectTask1.ShowTaskList(arrays[0].ToString());
                        controls_Show("maincontrol");//只显示主窗口
                        usermember1.Visible = false;
                        projectTask1.Visible = true;
                        projectApply1.Visible = false;
                        cashApply1.Visible = false;
                    }
                    if (values.Contains("_3"))//项目资源呢
                    {

                        projectApply1.ShowApplyList("orderSignet",arrays[0].ToString());
                        controls_Show("maincontrol");//只显示主窗口
                        usermember1.Visible = false;
                        projectTask1.Visible = false;
                        projectApply1.Visible = true;
                        cashApply1.Visible = false;
                    }
                     if (values.Contains("_5"))//项目经费
                    {

                        cashApply1.showlist(arrays[0].ToString());
                        controls_Show("maincontrol");//只显示主窗口
                        usermember1.Visible = false;
                        projectTask1.Visible = false;
                        projectApply1.Visible = false;
                        cashApply1.Visible = true;
                    }
                   
                }

            }
            catch
            {
            }
        }
        /// <summary>
        /// 对下载控件的操作
        /// </summary>
        /// <param name="foldeid"></param>
        /// <param name="filesid"></param>
        public void downloads_control(string foldeid, string filesid)
        {
            controls_Show("downloadcmain");//只显示下载窗口
            downloads1.downloadscontrols(foldeid, filesid);
        }
        /// <summary>
        /// 几组控件的显示控制
        /// //types:downloadcmain下载控件的显示;docmain文档控件的显示;maincontrol主窗口的显示
        /// </summary>
        /// <param name="foldeid"></param>
        /// <param name="filesid"></param>
        public void controls_Show(string types)
        {
            try
            {
                //types:downloadcmain下载控件的显示;docmain文档控件的显示;maincontrol主窗口的显示
                if (types == "downloadcmain")
                {
                    downloadcmain.Visible = true;
                    docmain.Visible = false;
                    maincontrol.Visible = false;
                    cashApply1.Visible = false;
                }
                if (types == "docmain")
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目统计 > 项目文档";
                    //设置模板页中的管理值
                    downloadcmain.Visible = false;
                    docmain.Visible = true;
                    maincontrol.Visible = false;
                    cashApply1.Visible = false;
                }
                if (types == "maincontrol")
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目统计";
                    //设置模板页中的管理值
                    downloadcmain.Visible = false;
                    docmain.Visible = false;
                    maincontrol.Visible = true;
                    cashApply1.Visible = false;
                }
            }
            catch
            {
            }
        }

        protected void LinkButton_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/SystemProjectManage/ProjectInfo/manage.aspx");
        }
    }
}
