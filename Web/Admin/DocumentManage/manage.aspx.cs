using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Reflection;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class manage : System.Web.UI.Page
    {
        COMMON.pageControl pagecontrols = new Dianda.COMMON.pageControl();
        BLL.Document_File bdf = new Dianda.BLL.Document_File();
        COMMON.common commons = new Dianda.COMMON.common();
        Model.USER_Users user_model = new Dianda.Model.USER_Users();
        BLL.Document_FolderExt bdfExt = new Dianda.BLL.Document_FolderExt();
        BLL.Document_Folder bdFolder = new Dianda.BLL.Document_Folder();
        Model.Document_Folder mdFolder = new Dianda.Model.Document_Folder();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["USER_Users"] != null)
                    {
                        string pagenames = "文档";

                        user_model = (Model.USER_Users)Session["USER_Users"];//实例化
                        string tp = Request["tp"];
                        string types = Request["types"];//如果是1，则说明是个人的档案
                        if (types != null && types == "1")
                        {
                            Session["Session_Project_linkshow"] = null;
                            Session["Work_ProjectId"] = null;//当个人点击这边过来的时候，则初始化SESSION
                        }

                        //用来判断是否是项目中的档案管理
                        if (Session["Session_Project_linkshow"] != null)
                        {
                            projectControl1.Visible = true;
                            tp = "1";
                            loadTree_Public(user_model.ID.ToString(), Request["CID"]);//加载项目的树,并且要约束只能显示当前项目的数据
                            pagenames = "项目 > 我的项目 > 项目文档 > 文档列表";

                            //根据当前项目的ID获取当前项目的状态，以此来确定是否要显示功能按钮2010-11-1
                            BLL.Project_ProjectsExt bPext = new Dianda.BLL.Project_ProjectsExt();
                            bool isShow = bPext.ProjectStatus(Session["Work_ProjectId"].ToString());
                            LinkButton_addcolumns.Enabled = isShow;
                            LinkButton_add.Enabled = isShow;
                            LinkButton_modify.Enabled = isShow;
                            LinkButton_DEL.Enabled = isShow;

                            //根据当前项目的ID获取当前项目的状态，以此来确定是否要显示功能按钮2010-11-1
                        }
                        else
                        {
                            LinkButton_addcolumns.Enabled = true;
                            LinkButton_add.Enabled = true;
                            LinkButton_modify.Enabled = true;
                            LinkButton_DEL.Enabled = true;


                            projectControl1.Visible = false;

                            if (tp == null || tp == "")
                            {
                                //loadTree_Public(user_model.ID.ToString(), Request["CID"]);//加载项目的树
                                loadTree_Private(user_model.ID.ToString(), Request["CID"]);// 加载个人的树
                                // loadTree_System(user_model.ID.ToString(), Request["CID"]);//加载共享文档的树
                            }
                            if (tp == "1")
                            {
                                //loadTree_Private(user_model.ID.ToString(), "");// 加载个人的树
                                loadTree_Public(user_model.ID.ToString(), Request["CID"]);//加载项目的树
                                //   loadTree_System(user_model.ID.ToString(), "");//加载共享文档的树
                                pagenames = "文档 > 项目文档";
                            }
                            if (tp == "0")
                            {
                                // loadTree_Public(user_model.ID.ToString(), "");//加载项目的树
                                loadTree_Private(user_model.ID.ToString(), Request["CID"]);// 加载个人的树
                                //  loadTree_System(user_model.ID.ToString(), "");//加载共享文档的树
                                pagenames = "文档 > 我的文档";
                            }
                            if (tp == "2")
                            {
                                //loadTree_Private(user_model.ID.ToString(), "");// 加载个人的树
                                // loadTree_Public(user_model.ID.ToString(), "");//加载项目的树
                                loadTree_System(user_model.ID.ToString(), Request["CID"]);//加载共享文档的树
                                pagenames = "文档 > 共享文档";
                            }
                        }

                        //用来判断是否是项目中的档案管理
                        ButtonShow(tp);//按钮的控制
                        //设置模板页中的管理值
                        (Master.FindControl("Label_navigation") as Label).Text = pagenames;
                        //设置模板页中的管理值

                        ////用模板页控制当前页面的权限
                        //Page p = this.Parent.Page;
                        //Type pageType = p.GetType();
                        //MethodInfo mi = pageType.GetMethod("JudgeButton");
                        //mi.Invoke(p, new object[] {});
                        ////用模板页控制当前页面的权限
                    }
                    else
                    {
                    }
                }
            }
            catch
            {
            }
        }
















        /// <summary>
        /// 当分页控件中的下拉菜单触发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        string TJ1 = "and ( status is null or Status=1)";
        protected void DropDownList_keys_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                user_model = (Model.USER_Users)Session["USER_Users"];//实例化

                string keys = DropDownList_keys.SelectedValue.ToString();
                treelist1.TJ = "and ( status is null or Status=" + keys + ")";
                //if (treelist1.TJ.ToString() == "and ( status is null or Status=-1)" ){ treelist1.TJ = ""; }
                if (treelist1.TJ.ToString() == "and ( status is null or Status=-1)") { TJ1 = ""; }
                else { TJ1 = "and ( status is null or Status=" + keys + ")"; }

                treelist1.makeTreeByProjectid(user_model.ID, "public", Request["CID"], "1");


            }
            catch
            {

            }

        }











        /// <summary>
        /// 根据页卡的不同，做操作功能的显示和隐藏
        /// </summary>
        /// <param name="tp"></param>
        public void ButtonShow(string tp)
        {
            if (tp == "" || tp == null || tp == "0")
            {
                //个人的
                LinkButton_share.Visible = true;
                LinkButton_cancelshare.Visible = true;
                LinkButton_transfer.Visible = false;
                LinkButton_modify.Visible = true;
                LinkButton_DEL.Visible = true;
                LinkButton_add.Visible = true;
                LinkButton_addcolumns.Visible = true;
            }
            if (tp == "1")
            {
                //项目的
                LinkButton_share.Visible = false;
                LinkButton_cancelshare.Visible = false;
                LinkButton_transfer.Visible = true;
                LinkButton_modify.Visible = true;
                LinkButton_DEL.Visible = true;
                LinkButton_add.Visible = true;
                LinkButton_addcolumns.Visible = true;
            }
            if (tp == "2")
            {
                //共享文档的
                LinkButton_share.Visible = false;
                LinkButton_cancelshare.Visible = false;
                LinkButton_transfer.Visible = true;
                LinkButton_modify.Visible = false;
                LinkButton_DEL.Visible = false;
                LinkButton_add.Visible = false;
                LinkButton_addcolumns.Visible = false;
            }
        }
        /// <summary>
        /// 加载个人的树
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="types"></param>
        /// <param name="projectid"></param>
        public void loadTree_Private(string userid, string CID)
        {
            try
            {
                this.treelist1.makeTreeByUserid(userid, "private", "", CID, "0");
            }
            catch
            {
            }
        }
        /// <summary>
        /// 加载项目的树
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="types"></param>
        /// <param name="projectid"></param>
        public void loadTree_Public(string userid, string CID)
        {
            try
            {
                this.treelist1.makeTreeByProjectid(userid, "public", CID, "1");
            }
            catch
            {
            }
        }
        /// <summary>
        /// 加载共享文档的树
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="types"></param>
        /// <param name="projectid"></param>
        public void loadTree_System(string userid, string CID)
        {
            try
            {
                this.treelist1.makeTreeBySystem(userid, CID, "2");
            }
            catch
            {
            }
        }

        /// <summary>
        /// 根据栏目的上级目录，获取其子目录，仅仅到一级子目录
        /// </summary>
        /// <param name="upid"></param>
        public void showSonFolder(string upid, bool isProject, string tp)
        {
            try
            {
                //if (upid == null)
                //{
                //    GridView3.Visible = false;
                //    GridView1.Visible = false;
                //    GridView2.Visible = false;
                //}
                //else
                //{
                HiddenField_foldID.Value = upid;
                //如果tp=2 则表示要显示站内共享给当前用户的所有的文件，不显示文件夹
                DataTable dt = new DataTable();

                if (tp != "2")
                {
                    if (tp == "1" || isProject)
                    {
                        tp = "1";
                    }
                    else if (tp == "0" || tp == null || tp == "" || !isProject)
                    {
                        tp = "0";
                    }
                    GridView3.Visible = false;
                    GridView1.Visible = true;
                    GridView2.Visible = true;
                }
                else if (tp == "2")
                {
                    tp = "2";
                    GridView3.Visible = true;
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    HiddenField_upid.Value = upid;
                }
                ButtonShow(tp);//控制按钮

                HiddenField_tp.Value = tp;//表示页卡


                ///加载这个目录的子目录
                string sql = "";//
                if (tp == "1")
                {
                    user_model = (Model.USER_Users)Session["USER_Users"];//实例化
                    string projectid = "";
                    if (Session["Work_ProjectId"] != null)
                    {
                        projectid = Session["Work_ProjectId"].ToString();
                    }
                    if (projectid.Length > 0)
                    {
                        sql = "select * from  vDocument_Folder where Types='public' and  (UpID='" + upid + "') and ProjectID='" + projectid + "' and DELFLAG='0' and UpID<>'-1'" + TJ1 + "  order by COLUMNSPATH";
                    }
                    else
                    {
                        sql = "select * from  vDocument_Folder where Types='public' and  (UpID='" + upid + "') and DELFLAG='0' and UpID<>'-1' and (ProjectID in(select id from Project_Projects where leaderid='" + user_model.ID.ToString() + "') or ProjectID in(select Projectid from Project_UserList where userid='" + user_model.ID.ToString() + "' and status='1')  or projectid='0') AND (PDEL=0 OR PDEL IS NULL) " + TJ1 + " order by COLUMNSPATH";
                    }
                }
                else if (tp == "0")
                {
                    sql = "select * from  vDocument_Folder where Types='private' and  (UpID='" + upid + "') and DELFLAG='0' " + TJ1 + " order by COLUMNSPATH";
                }
                else if (tp == "2")
                {
                    //通过传过来的放出共享的用户的ID，和当前用户的SESSION中的用户ID，获取到指定用户共享给当前用户的所有文件
                    user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                    dt = bdfExt.ShareFileTable(user_model.ID, upid);//获取共享出来的文件

                }
                if (tp != "2")
                {
                    dt = pagecontrols.doSql(sql).Tables[0];
                    string isshowhead = "1";//0表示隐藏，1表示显示

                    if (dt.Rows.Count > 0)
                    {
                        isshowhead = "0";
                        GridView3.Visible = false;
                        this.GridView1.Visible = true;
                        this.GridView1.DataSource = dt;//指定GridView1的数据是dv
                        this.GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                        if (isProject)
                        {
                            GridView1.Columns[4].Visible = false;
                        }
                        else
                        {
                            GridView1.Columns[4].Visible = false;
                        }
                    }
                    else
                    {
                        isshowhead = "1";
                        GridView3.Visible = false;
                        this.GridView1.Visible = false;
                    }
                    ///加载这个目录的子文件
                    HiddenField_FolderID.Value = upid;
                    // setRowCout(upid);

                    HiddenField_showhead.Value = isshowhead;//0表示隐藏，1表示显示
                    ShowList(1, upid);
                }
                else if (tp == "2")
                {
                    if (dt.Rows.Count > 0)
                    {
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        GridView3.Visible = true;

                        GridView1.Visible = false;
                        GridView2.Visible = false;
                    }
                    else
                    {
                        GridView3.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                    }
                }
                // }

            }
            catch
            {
                GridView3.Visible = false;
                GridView1.Visible = false;
                GridView2.Visible = false;
            }
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
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
        /// 文件的全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox_choose_CheckedChanged2(object sender, EventArgs e)
        {
            try
            {
                CheckBox CheckBox_Alltemp = (CheckBox)sender;
                setAllCheck(GridView2, CheckBox_Alltemp.Checked);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 文件的全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox_choose_CheckedChanged3(object sender, EventArgs e)
        {
            try
            {
                CheckBox CheckBox_Alltemp = (CheckBox)sender;
                setAllCheck(GridView3, CheckBox_Alltemp.Checked);
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
        protected void ShowList(int pageindex, string FolderID)
        {
            try
            {
                DataTable DT = new DataTable();
                string sqlWhere1 = makesql(FolderID);
                // string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                // int alltiaoshuInt = int.Parse(allTiaoshu);
                // DT = pagecontrols.GetList_FenYe_Common(sqlWhere1, pageindex, GridView2.PageSize, alltiaoshuInt, "Document_File", "DATETIME").Tables[0];
                //  pageindex = pagecontrols.pageindex(pageindex, GridView2.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                // DT = bdf.GetList(sqlWhere1 + " order by DATETIME DESC").Tables[0];
                string sqls = "select * from vDocument_File where " + sqlWhere1 + "  order by DATETIME DESC";
                DT = pagecontrols.doSql(sqls).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中

                    GridView2.Visible = true;
                    GridView2.DataSource = DT;//指定GridView1的数据是DT
                    pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据

                    if (HiddenField_showhead.Value == "0")
                    {
                        this.GridView2.ShowHeader = false;
                    }
                    else if (HiddenField_showhead.Value == "1")
                    {
                        this.GridView2.ShowHeader = true;
                    }
                    else
                    {
                        this.GridView2.ShowHeader = false;
                    }
                    GridView2.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";
                }
                else
                {
                    this.GridView2.ShowHeader = false;
                    GridView2.Visible = false;
                    notice.Text = "";
                }
            }
            catch
            {
                this.GridView2.ShowHeader = false;
                //  pageControlShow.Visible = false;
            }
        }
        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        //private void setRowCout(string FolderID)
        //{
        //    try
        //    {
        //        DataTable DT = new DataTable();
        //        string sql =makesql(FolderID);
        //        int count = pagecontrols.tableRowCout(sql, "Document_File", "ID");

        //        if (count > 0)
        //        {
        //            dtrowsHidden.Value = count.ToString();
        //        }
        //        else
        //        {
        //            dtrowsHidden.Value = "0";
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        /// <summary>
        /// 当分页控件中的“第一页”“第二页”...发生时，触发下面的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void PageChange_Click(object sender, EventArgs e)
        //{
        //    int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
        //    pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值

        //    setRowCout(HiddenField_FolderID.Value.ToString());
        //    ShowList(page, HiddenField_FolderID.Value.ToString());//调用显示

        //}
        ///// <summary>
        /// 当分页控件中的下拉菜单触发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
        //    pageindexHidden.Value = page.ToString();

        //    setRowCout(HiddenField_FolderID.Value.ToString());
        //    ShowList(page, HiddenField_FolderID.Value.ToString());//调用显示

        //}
        /// <summary>
        /// 新建目录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_addcolumns_Click(object sender, EventArgs e)
        {
            try
            {
                //<a href='addtreeND.aspx?userid=" + userid + "&tp=1'  target='_self' title='档案管理> 新建目录'>新建目录</a>"
                //先获取到当前是那个
                user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                string userid = user_model.ID.ToString();
                string tp = Request["tp"];
                if (tp == "" || tp == null)
                {
                    tp = "0";
                }
                string upid = HiddenField_foldID.Value.ToString();
                Response.Redirect("addtreeND.aspx?userid=" + userid + "&tp=" + tp + "&upid=" + upid + "");
            }
            catch
            {
            }
        }

        /// <summary>
        /// 编辑功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_modify_Click(object sender, EventArgs e)
        {

            //从数据集合中获取到要处理的那个条目
            string[] doarray = getDoarray();
            if (doarray[0] != "")
            {
                string url = "";
                if (doarray[1].ToString() == "1")//文件夹
                {
                    url = "modifyFolder.aspx?ID=" + doarray[0].ToString() + "&tp=" + HiddenField_tp.Value.ToString();
                }
                if (doarray[1].ToString() == "2")//文件
                {
                    url = "modifyFiles.aspx?ID=" + doarray[0].ToString() + "&tp=" + HiddenField_tp.Value.ToString();
                }
                Response.Redirect(url);
            }
        }
        /// <summary>
        /// 编辑共享
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_share_Click(object sender, EventArgs e)
        {
            //从数据集合中获取到要处理的那个条目
            string[] doarray = getDoarray();
            if (doarray[0] != "")
            {
                string url = "";
                if (doarray[1].ToString() == "1")//文件夹
                {
                    url = "shareFolder.aspx?ID=" + doarray[0].ToString() + "&tp=" + HiddenField_tp.Value.ToString();
                }
                if (doarray[1].ToString() == "2")//文件
                {
                    url = "shareFiles.aspx?ID=" + doarray[0].ToString() + "&tp=" + HiddenField_tp.Value.ToString();
                }
                Response.Redirect(url);
            }
        }
        /// <summary>
        /// 取消共享
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_share_cancel_Click(object sender, EventArgs e)
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


                    //处理数据
                    string foldersqlin = commons.makeSqlIn(folderid, ';');
                    string sqlFolder = "update Document_Folder set IsShare='0' where ID in" + foldersqlin;//处理文件夹的共享--文件夹本身
                    string sqlFolderShare = "delete from Document_Folder_Share where FolderID in" + foldersqlin;//处理文件夹之前共享给的用户信息
                    string sqlFilesqlin = commons.makeSqlIn(fileid, ';');
                    string sqlFile = "update Document_File set IsShare='0' where ID in" + sqlFilesqlin;//处理文件的共享--文件本身
                    string sqlFileShare = "delete from Document_File_Share where FileID in" + sqlFilesqlin;//处理文件之前共享给的用户信息

                    pagecontrols.doSql(sqlFolder);
                    pagecontrols.doSql(sqlFolderShare);
                    pagecontrols.doSql(sqlFile);
                    pagecontrols.doSql(sqlFileShare);
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('操作完毕！')", true);
                    //将列表中被选择的项，都置为正常
                    resetGridView("1");//取消共享
                    user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                    //写日志
                    BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                    bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理取消共享", "取消共享成功");
                    //写日志
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('没有可以操作的数据！')", true);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 删除所选的项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_share_del_Click(object sender, EventArgs e)
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
                    Response.Redirect("delSource.aspx?foldeid=" + folderid + "&fileid=" + fileid + "&tp=" + HiddenField_tp.Value.ToString());

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('没有可以操作的数据！')", true);
                }
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
                    Response.Redirect("downloads.aspx?foldeid=" + folderid + "&fileid=" + fileid + "&tp=" + HiddenField_tp.Value.ToString());

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('没有可以操作的数据！')", true);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_add_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("uploadfiles.aspx?tp=" + HiddenField_tp.Value.ToString() + "&upid=" + HiddenField_foldID.Value.ToString());
            }
            catch
            {
            }
        }




        /// <summary>
        /// 将所选的条目收藏到自己的档案中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_transfer_Click(object sender, EventArgs e)
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
                    //如果是tp=2过来的，则要把共享文件的用户的ID，传出去
                    string tp = HiddenField_tp.Value.ToString();
                    string upid = HiddenField_upid.Value.ToString();
                    if (tp == "2")
                    {
                        upid = "&CID=" + upid;
                    }


                    Response.Redirect("transfer.aspx?foldeid=" + folderid + "&fileid=" + fileid + "&tp=" + tp + upid);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('没有可以操作的数据！')", true);
                }
            }
            catch
            {
            }
        }



        /// <summary>
        /// 将列表中勾选上的项的属性值进行更新
        /// <param name="types">操作的类型：1表示取消共享；</param>
        /// </summary>
        private void resetGridView(string types)
        {
            try
            {
                //先从G1中找
                int g1 = GridView1.Rows.Count;
                for (int i = 0; i < g1; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if (cb.Checked)
                    {
                        if (types == "1")
                        {
                            GridView1.Rows[i].Cells[5].Text = "正常";//第4列隐藏的是项目的名称
                        }
                    }
                }
                //再从G2中找
                int g2 = GridView2.Rows.Count;
                for (int i = 0; i < g2; i++)
                {
                    CheckBox cb = (CheckBox)GridView2.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if (cb.Checked)
                    {
                        if (types == "1")
                        {
                            GridView2.Rows[i].Cells[5].Text = "正常";
                        }
                    }
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
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('每次仅能对1个条目进行操作！" + coutw + "')", true);
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
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('请至少选择一条您要操作的记录！')", true);
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
                string tp = HiddenField_tp.Value.ToString();

                if (tp != "2")
                {
                    //先从G1中找

                    int g1 = GridView1.Rows.Count;
                    string g1string = "";
                    if (GridView1.Visible)
                    {
                        for (int i = 0; i < g1; i++)
                        {
                            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                            HiddenField hid = (HiddenField)GridView1.Rows[i].Cells[0].FindControl("Hid_ID");
                            if (cb.Checked)
                            {
                                g1string = g1string + hid.Value.ToString() + ",1" + ";";//文件夹
                            }
                        }
                    }
                    //再从G2中找
                    string g2string = "";
                    int g2 = GridView2.Rows.Count;
                    if (GridView2.Visible)
                    {
                        for (int i = 0; i < g2; i++)
                        {
                            CheckBox cb = (CheckBox)GridView2.Rows[i].Cells[0].FindControl("CheckBox_choose");
                            HiddenField hid = (HiddenField)GridView2.Rows[i].Cells[0].FindControl("Hid_ID");
                            if (cb.Checked)
                            {
                                g2string = g2string + hid.Value.ToString() + ",2" + ";";//文件
                            }
                        }
                    }
                    coutw = g1string + ";" + g2string;
                }
                else if (tp == "2")
                {
                    //再从G3中找
                    string g3string = "";
                    int g3 = GridView3.Rows.Count;
                    if (GridView3.Visible)
                    {
                        for (int i = 0; i < g3; i++)
                        {
                            CheckBox cb = (CheckBox)GridView3.Rows[i].Cells[0].FindControl("CheckBox_choose");
                            HiddenField hid = (HiddenField)GridView3.Rows[i].Cells[0].FindControl("Hid_ID");
                            if (cb.Checked)
                            {
                                g3string = g3string + hid.Value.ToString() + ",2" + ";";//文件
                            }
                        }
                    }
                    coutw = g3string;
                }
                coutw = makestring(coutw);
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


    }
}
