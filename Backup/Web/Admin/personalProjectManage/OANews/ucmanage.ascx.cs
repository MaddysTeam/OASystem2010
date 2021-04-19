using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OANews
{
    public partial class ucmanage : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.Model.News_News mNews_News = new Dianda.Model.News_News();
        BLL.News_News bNews_News = new Dianda.BLL.News_News();
        Model.News_LimitUser mNews_LimitUser = new Dianda.Model.News_LimitUser();
        BLL.News_LimitUser bNews_LimitUser = new Dianda.BLL.News_LimitUser();
        Model.Project_Projects mProject_Projects = new Dianda.Model.Project_Projects();
        BLL.Project_Projects bProject_Projects = new Dianda.BLL.Project_Projects();
        Dianda.BLL.Project_ProjectsExt BProject_Status = new Dianda.BLL.Project_ProjectsExt();

        private static string _projectid;
        private static string _boxtype;//1发件箱,2收件箱

        public string projectid
        {
            get { return _projectid; }
            set { _projectid = value; }
        }

        public string boxtype
        {
            get { return _boxtype; }
            set { _boxtype = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目ID
                projectid = Session["Work_ProjectId"].ToString();
                if (Request.Params["status"] != null && !String.IsNullOrEmpty(Request["status"]))
                {
                    _boxtype = Request["status"];
                    if (Request["status"] == "1")
                    {
                        DropDownList3.SelectedValue = "1";
                    }
                    else
                    {
                        DropDownList3.SelectedValue = "0";
                    }
                }
                else
                {
                    _boxtype = "2";
                    DropDownList3.SelectedValue = "0";
                }

                //GetddlMailBox();
                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    if (_boxtype == "1")
                    {
                        setRowCout1();//发件箱
                    }
                    else
                    {
                        setRowCout();//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    }
                    count = dtrowsHidden.Value.ToString();
                }
                else
                {
                    count = "0";
                }
                int countint = int.Parse(count);
                string pageindex = null;//这里是为分页服务的
                if (pageindex == null || pageindex == "")
                {
                    pageindex = "1";
                }
                int pageindex_int = int.Parse(pageindex);
                if (_boxtype == "1")
                {
                    this.Button_add.Visible = true;
                    this.Button_modify.Visible = true;
                    BindData1(pageindex_int);//发件箱
                }
                else
                {
                    this.Button_add.Visible = false;
                    this.Button_modify.Visible = false;
                    BindData(pageindex_int);//发件箱
                }
                //项目状态
                bool Project_Status = BProject_Status.ProjectStatus(Session["Work_ProjectId"].ToString());
                //根据项目状态设置页面按钮状态
                if (Project_Status == false)
                {
                    Button_add.Enabled = Project_Status;
                    Button_modify.Enabled = Project_Status;
                    Button_delete.Enabled = Project_Status;
                }
            }
        }

        //protected void GetddlMailBox()
        //{

        //    ListItem li = new ListItem("信息发布箱", "1");
        //    this.ddlMailBox.Items.Add(li);
        //    li = new ListItem("信息接收箱", "2");
        //    this.ddlMailBox.Items.Add(li);

        //    if (Request.Params["status"] != null && !String.IsNullOrEmpty(Request["status"]))
        //    {
        //        _boxtype = Request["status"];
        //    }
        //    else
        //    {
        //        _boxtype = "2";
        //    }
        //}


        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout()
        {
            try
            {
                string strSQL = "SELECT * FROM vNews_LimitUser WHERE " + SQLCondition();
                DataTable dt = new DataTable();
                dt = pageControl.doSql(strSQL).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    dtrowsHidden.Value = dt.Rows.Count.ToString();
                }
                else
                {
                    dtrowsHidden.Value = "0";
                }
            }
            catch
            {
            }
        }



        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout1()//信息发布箱
        {
            try
            {
                string strSQL = "SELECT * FROM vNews_News1 WHERE " + SQLCondition1();
                DataTable dt = new DataTable();
                dt = pageControl.doSql(strSQL).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    dtrowsHidden.Value = dt.Rows.Count.ToString();
                }
                else
                {
                    dtrowsHidden.Value = "0";
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        protected void BindData1(int pageindex)//信息发送箱
        {
            try
            {
                //string strSQL = "SELECT * FROM vNews_News WHERE " + SQLCondition();
                DataTable dt = new DataTable();
                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                dt = pageControl.GetList_FenYe_Common(SQLCondition1(), pageindex, GridView1.PageSize, alltiaoshuInt, "vNews_News1", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (dt.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    Button_delete.Enabled = true;
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";


                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件

                    GridView2.Visible = false;
                }
                else
                {
                    GridView1.Visible = false;
                    Button_delete.Enabled = false;
                    notice.Text = "*没有符合条件的结果！";

                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    if (alltiaoshuInt > 0)
                    {
                        BindData(pageindex - 1);
                    }

                    GridView2.Visible = false;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        protected void BindData(int pageindex)
        {
            try
            {
                //string strSQL = "SELECT * FROM vNews_News WHERE " + SQLCondition();
                DataTable dt = new DataTable();
                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                dt = pageControl.GetList_FenYe_Common(SQLCondition(), pageindex, GridView1.PageSize, alltiaoshuInt, "vNews_LimitUser", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (dt.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    Button_delete.Enabled = true;
                    GridView2.Visible = true;
                    GridView2.DataSource = dt;//指定GridView1的数据是dv
                    GridView2.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件

                    GridView1.Visible = false;
                }
                else
                {
                    GridView2.Visible = false;
                    Button_delete.Enabled = false;
                    notice.Text = "*没有符合条件的结果！";

                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    if (alltiaoshuInt > 0)
                    {
                        BindData(pageindex - 1);
                    }
                    GridView1.Visible = false;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 当分页控件中的“第一页”“第二页”...发生时，触发下面的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageChange_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
            pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值
            setRowCout();
            BindData(page);//调用显示

        }
        /// <summary>
        /// 当分页控件中的下拉菜单触发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
            pageindexHidden.Value = page.ToString();
            setRowCout();
            BindData(page);//调用显示

        }

        /// <summary>
        /// 点击全选框时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox_choose_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox CheckBox_Alltemp = (CheckBox)sender;
                if (CheckBox_Alltemp.Checked)//全选
                {
                    grievSearch(true);
                }
                else//全不选
                {
                    grievSearch(false);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        ///根据条件给值
        /// </summary>
        /// <param name="isCheck"></param>
        private void grievSearch(bool isCheck)
        {
            try
            {
                if (this.GridView1.Visible)
                {
                    int rows = GridView1.Rows.Count;
                    if (rows > 0)
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                            cb.Checked = isCheck;
                        }
                    }
                }
                else if (this.GridView2.Visible)
                {
                    int rows = GridView2.Rows.Count;
                    if (rows > 0)
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            CheckBox cb = (CheckBox)GridView2.Rows[i].Cells[0].FindControl("CheckBox_choose");
                            cb.Checked = isCheck;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 点击新增按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_add_onclick(object sender, EventArgs e)
        {
            mProject_Projects = new Dianda.Model.Project_Projects();
            mProject_Projects = bProject_Projects.GetModel(Int32.Parse(_projectid));

            Response.Redirect("add.aspx?&pageindex=" + pageindexHidden.Value + "&status=" + _boxtype.ToString() + "&parentname=" + mProject_Projects.NAMES);
        }

        /// <summary>
        /// 点击编辑按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_modify_onclick(object sender, EventArgs e)
        {
            //选择编辑的条数只能为一条
            int num = 0;
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if (cb.Checked)
                    {
                        num = num + 1;
                    }
                }

                if (num == 0)
                {
                    tag.Text = "请选择一条数据进行编辑！";

                }
                else if (num > 1)
                {
                    tag.Text = "编辑时最多只能选择一条数据！";
                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
                        string id = GridView1.DataKeys[j]["ID"].ToString();
                        string ForItems = GridView1.DataKeys[j]["ForItems"].ToString();
                        string PARENTID = GridView1.DataKeys[j]["PARENTID"].ToString();
                        string LimitsChooseID = GridView1.DataKeys[j]["LimitsChoose"].ToString();

                        if (cb1.Checked)
                        {
                            Response.Redirect("modify.aspx?id=" + id + "&ForItems=" + ForItems + "&PARENTID=" + PARENTID + "&LimitsChooseID=" + LimitsChooseID + "&pageindex=" + pageindexHidden.Value + "&status=" + _boxtype.ToString());
                            // this.H_ModifyID.Value = hid.Value;
                            //BindModifyData(hid.Value);
                            //this.div2.Visible = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 点击删除按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_delete_onclick(object sender, EventArgs e)
        {
            if (_boxtype == "1")//信息发布箱
            {
                int num = 0;
                int rows = GridView1.Rows.Count;
                if (rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                        if (cb.Checked)
                        {
                            num = num + 1;
                        }
                    }
                    if (num == 0)
                    {
                        tag.Text = "删除时最少选择一条数据！";

                    }
                    else
                    {
                        tag.Text = "";
                        for (int j = 0; j < rows; j++)
                        {
                            CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                            // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
                            string id = GridView1.DataKeys[j]["ID"].ToString();
                            if (cb1.Checked)
                            {
                                bNews_News.Delete(Int32.Parse(id));
                                tag.Text = "操作成功！";
                                // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";
                                //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx\";</script>";
                                //Response.Write(coutws);

                                // 添加操作日志
                                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "删除信息" /*Request["tags"].ToString()*/, "删除成功");
                            }
                        }
                    }
                }

                setRowCout1();
                BindData1(1);//调用显示
            }
            else if (_boxtype == "2")//信息接收箱
            {
                int num = 0;
                int rows = GridView2.Rows.Count;
                if (rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        CheckBox cb = (CheckBox)GridView2.Rows[i].Cells[0].FindControl("CheckBox_choose");
                        if (cb.Checked)
                        {
                            num = num + 1;
                        }
                    }

                    if (num == 0)
                    {
                        tag.Text = "删除时最少选择一条数据！";

                    }
                    else
                    {
                        tag.Text = "";
                        for (int j = 0; j < rows; j++)
                        {
                            CheckBox cb1 = (CheckBox)GridView2.Rows[j].Cells[0].FindControl("CheckBox_choose");
                            // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
                            string id = GridView2.DataKeys[j]["ID"].ToString();
                            if (cb1.Checked)
                            {
                                List<Dianda.Model.News_LimitUser> lmNews_LimitUser = new List<Dianda.Model.News_LimitUser>();
                                lmNews_LimitUser = bNews_LimitUser.GetModelList("UserID='" + ((Model.USER_Users)Session["USER_Users"]).ID + "' and NewsID=" + id);
                                if (lmNews_LimitUser.Count > 0)
                                {
                                    foreach (Dianda.Model.News_LimitUser model in lmNews_LimitUser)
                                    {
                                        bNews_LimitUser.Delete(model.ID);
                                    }
                                }
                                tag.Text = "操作成功！";
                                // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";
                                //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx\";</script>";
                                //Response.Write(coutws);

                                // 添加操作日志
                                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "删除信息" /*Request["tags"].ToString()*/, "删除成功");
                            }
                        }
                    }
                }

                setRowCout();
                BindData(1);//调用显示
            }



        }

        //protected void ddlMailBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (_boxtype == "1")//信息发布箱
        //    {
        //        setRowCout1();
        //        BindData1(1);//调用显示
        //    }
        //    else if (_boxtype == "2")//信息接收箱
        //    {
        //        setRowCout();
        //        BindData(1);//调用显示
        //    }

        //}

        /// <summary>
        /// 发件箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Button_Send_onclick(object sender, EventArgs e)
        //{
        //    this.Button_add.Visible = true;
        //    this.Button_modify.Visible = true;
        //    _boxtype = "1";
        //    setRowCout1();
        //    BindData1(1);//调用显示
        //}

        /// <summary>
        /// 收件箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Button_Receive_onclick(object sender, EventArgs e)
        //{
        //    this.Button_add.Visible = false;
        //    this.Button_modify.Visible = false;
        //    _boxtype = "2";
        //    setRowCout();
        //    BindData(1);//调用显示
        //}

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        //protected string SQLCondition()
        //{
        //    StringBuilder sbSql = new StringBuilder();
        //    sbSql.Append(" 1=1 ");
        //    // 学期
        //    if (_boxtype == "1")//信息发布
        //    {
        //        sbSql.Append(" AND WRITER ='" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + "' ");
        //    }
        //    else if (_boxtype == "2")//信息接收
        //    {
        //        sbSql.Append(" AND ID in (Select distinct(NewsID) From News_LimitUser Where UserID='" + ((Model.USER_Users)Session["USER_Users"]).ID + "') ");
        //    }
        //    sbSql.Append("AND DELFLAG=0 ");
        //    //sbSql.Append("ORDER BY ID ");
        //    return sbSql.ToString();
        //}
        protected string SQLCondition()//信息接收箱
        {
            mProject_Projects = new Dianda.Model.Project_Projects();
            mProject_Projects = bProject_Projects.GetModel(Int32.Parse(_projectid));

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 ");
            if (_boxtype == "2")//信息接收
            {
                sbSql.Append(" AND UserID='" + ((Model.USER_Users)Session["USER_Users"]).ID + "' ");
            }
            sbSql.Append(" AND PARENTNAME='" + mProject_Projects.NAMES + "'");
            //sbSql.Append("ORDER BY ID ");
            return sbSql.ToString();
        }


        protected string SQLCondition1()//信息发布箱
        {
            mProject_Projects = new Dianda.Model.Project_Projects();
            mProject_Projects = bProject_Projects.GetModel(Int32.Parse(_projectid));

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 ");
            if (_boxtype == "1")//信息发布
            {
                sbSql.Append(" AND WRITER ='" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + "' ");
            }
            sbSql.Append(" AND PARENTNAME='" + mProject_Projects.NAMES + "'");
            //sbSql.Append("ORDER BY ID ");
            return sbSql.ToString();
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
                    // string CONTENTS = DataBinder.Eval(e.Row.DataItem, "CONTENTS").ToString();
                    string NAME = DataBinder.Eval(e.Row.DataItem, "NAME").ToString();
                    string LimitsChoose = DataBinder.Eval(e.Row.DataItem, "LimitsChoose").ToString();
                    hid.Value = ID;
                    //e.Row.Cells[3].Text = CONTENTS;
                    e.Row.Cells[1].Text = "<a href=\"javascript:window.showModalDialog('../../newsManage/OAnews/show.aspx?id=" + ID + " ','','dialogWidth=726px;dialogHeight=400px');\" title='查看详细' target='_self'>" + NAME + "</a>";
                    if (LimitsChoose == "1")//1-本部门成员、2-全员、3-项目组成员
                    {
                        e.Row.Cells[3].Text = "本部门成员";
                    }
                    else if (LimitsChoose == "2")
                    {
                        e.Row.Cells[3].Text = "全员";
                    }
                    else if (LimitsChoose == "3")
                    {
                        e.Row.Cells[3].Text = "项目组成员";
                    }
                }
            }
            catch
            {
            }
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
                    // string CONTENTS = DataBinder.Eval(e.Row.DataItem, "CONTENTS").ToString();
                    string NAME = DataBinder.Eval(e.Row.DataItem, "NAME").ToString();
                    string IsRead = DataBinder.Eval(e.Row.DataItem, "IsRead").ToString();
                    string LimitsChoose = DataBinder.Eval(e.Row.DataItem, "LimitsChoose").ToString();
                    hid.Value = ID;
                    //e.Row.Cells[3].Text = CONTENTS;
                    e.Row.Cells[1].Text = "<a href=\"javascript:window.showModalDialog(' ../../newsManage/OAnews/show.aspx?id=" + ID + " ','','dialogWidth=726px;dialogHeight=400px');\" title='查看详细' target='_self'>" + NAME + "</a>";
                    if (IsRead == "1")
                    {
                        e.Row.Cells[3].Text = "是";
                    }
                    else
                    {
                        e.Row.Cells[3].Text = "否";
                    }
                    if (LimitsChoose == "1")//1-本部门成员、2-全员、3-项目组成员
                    {
                        e.Row.Cells[5].Text = "本部门成员";
                    }
                    else if (LimitsChoose == "2")
                    {
                        e.Row.Cells[5].Text = "全员";
                    }
                    else if (LimitsChoose == "3")
                    {
                        e.Row.Cells[5].Text = "项目组成员";
                    }
                }
            }
            catch
            {
            }
        }
        ////发件箱
        //protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    tag.Text = "";
        //    this.Button_add.Visible = true;
        //    this.Button_modify.Visible = true;
        //    RadioButton1.Checked = false;
        //    RadioButton2.Checked = true;
        //    _boxtype = "1";
        //    setRowCout1();
        //    BindData1(1);//调用显示
           
        //}
        ////收件箱
        //protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    tag.Text = "";
        //    this.Button_add.Visible = false;
        //    this.Button_modify.Visible = false;
        //    RadioButton2.Checked = false;
        //    RadioButton1.Checked = true;
        //    _boxtype = "2";
        //    setRowCout();
        //    BindData(1);//调用显示
            
        //}




        //收发件项转换触发事件
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //收件箱时
            if (DropDownList3.SelectedValue == "0")
            {
                tag.Text = "";
                this.Button_add.Visible = false;
                this.Button_modify.Visible = false;
                _boxtype = "2";
                setRowCout();
                BindData(1);//调用显示
            }
            //发件箱
            else
            {
                tag.Text = "";
                this.Button_add.Visible = true;
                this.Button_modify.Visible = true;
                _boxtype = "1";
                setRowCout1();
                BindData1(1);//调用显示
            }
            //项目状态
            bool Project_Status = BProject_Status.ProjectStatus(Session["Work_ProjectId"].ToString());
            //根据项目状态设置页面按钮状态
            if (Project_Status == false)
            {
                Button_add.Enabled = Project_Status;
                Button_modify.Enabled = Project_Status;
                Button_delete.Enabled = Project_Status;
            }
        }
    }
}