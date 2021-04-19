using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.userManager.OAusersmanage
{
    public partial class manage : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.Model.USER_Users users_model = new Dianda.Model.USER_Users();
        Dianda.BLL.USER_Users users_bll = new Dianda.BLL.USER_Users();

        Dianda.BLL.Document_Folder docfolder_bll = new Dianda.BLL.Document_Folder();
        Dianda.Model.Document_Folder docfolder_model = new Dianda.Model.Document_Folder();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //部门
                string Depart = "";
                //工作状态
                string Workstatus = "";
                string pageindex = null;//这里是为分页服务的

                Depart = Request["depart"];
                Workstatus = Request["workstatus"];
                pageindex = Request["pageindex"];


                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    setRowCout(Depart, Workstatus);//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    count = dtrowsHidden.Value.ToString();
                }
                else
                {
                    count = "0";
                }
                int countint = int.Parse(count);

                if (pageindex == null || pageindex == "")
                {
                    pageindex = "1";
                }

                int pageindex_int = int.Parse(pageindex);
                //显示下拉列表中的值
                ShowDdlInfo();

                ShowUsersList(pageindex_int, Depart, Workstatus);

                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 人事管理";
                //设置模板页中的管理值
            }
        }
        /// <summary>
        /// 根据条件查询人员信息列表
        /// </summary>
        /// <param name="pageindex">页码</param>
        /// <param name="depart">部门</param>
        /// <param name="workstatus">工作状态</param>
        protected void ShowUsersList(int pageindex, string depart, string workstatus)
        {
            try
            {
                DataTable DT = new DataTable();
                string sqlWhere1 = "1=1";

                if (null != depart && depart != "")
                {
                    sqlWhere1 = sqlWhere1 + " and DepartMentID like '%" + depart + "%'  AND (DELFLAG = 0) ";
                }
                if (null != workstatus && workstatus != "")
                {
                    sqlWhere1 = sqlWhere1 + " and WorkStats = '" + workstatus + "' AND (DELFLAG = 0) ";
                }


                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                DT = pageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "vUSER_Users", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中

                    GridView1.Visible = true;
                    GridView1.DataSource = DT;//指定GridView1的数据是DT
                    pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    notice.Text = "";
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！请选择筛选条件！";
                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    Button_modify.Enabled = false;
                    Button_delete.Enabled = false;
                    if (alltiaoshuInt > 0)
                    {
                        ShowUsersList(pageindex - 1, depart, workstatus);
                    }

                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        /// <param name="depart">部门</param>
        /// <param name="workstatus">工作状态</param>
        private void setRowCout(string depart, string workstatus)
        {
            try
            {
                DataTable DT = new DataTable();
                string sql = "SELECT * FROM vUSER_Users WHERE 1=1  AND (DELFLAG = 0)";
                if (null != depart && depart != "")
                {
                    sql = sql + " and DepartMentID like '%" + depart + "%'";
                }
                if (null != workstatus && workstatus != "")
                {
                    sql = sql + " and WorkStats = '" + workstatus + "'";
                }
                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    dtrowsHidden.Value = DT.Rows.Count.ToString();
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
        /// 当分页控件中的“第一页”“第二页”...发生时，触发下面的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageChange_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
            pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值
            string depart = DDL_Depart.SelectedValue.ToString();
            string workstatus = DDL_Status.SelectedValue.ToString();
            setRowCout(depart, workstatus);
            ShowUsersList(page, depart, workstatus);//调用显示

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
            string depart = DDL_Depart.SelectedValue.ToString();
            string workstatus = DDL_Status.SelectedValue.ToString();
            setRowCout(depart, workstatus);
            ShowUsersList(page, depart, workstatus);//调用显示

        }

        /// <summary>
        /// 部门下拉列表选择的值发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Depart_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_add.Enabled = true;
            Button_delete.Enabled = true;
            Button_modify.Enabled = true;
            string depart = ((DropDownList)sender).SelectedValue.ToString();
            string workstatus = DDL_Status.SelectedValue.ToString();
            setRowCout(depart, workstatus);
            ShowUsersList(1, depart, workstatus);//调用显示

        }

        /// <summary>
        /// 状态下拉列表选择的值发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_add.Enabled = true;
            Button_delete.Enabled = true;
            Button_modify.Enabled = true;

            string workstatus = ((DropDownList)sender).SelectedValue.ToString();
            string depart = DDL_Depart.SelectedValue.ToString();
            setRowCout(depart, workstatus);
            ShowUsersList(1, depart, workstatus);//调用显示

        }

        /// <summary>
        /// 显示下拉列表中的值
        /// </summary>
        protected void ShowDdlInfo()
        {
            try
            {
                string depart = Request["depart"];
                string status = Request["workstatus"];

                DataTable dt1 = new DataTable();

                string sql1 = " SELECT ID,NAME FROM USER_Groups WHERE (TAGS = '部门') AND (DELFLAG = 0) GROUP BY ID,NAME ";

                dt1 = pageControl.doSql(sql1).Tables[0];

                ListItem li1 = new ListItem("全部", "");
                DDL_Depart.Items.Add(li1);

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string DepartName = dt1.Rows[i]["NAME"].ToString();
                    string ID = dt1.Rows[i]["ID"].ToString();

                    ListItem li = new ListItem(DepartName, ID);
                    DDL_Depart.Items.Add(li);

                    if (ID.Equals(depart))
                    {
                        li.Selected = true;
                    }
                }

                DataTable dt2 = new DataTable();
                string sql2 = " SELECT ID, WorkStataName FROM USER_WorkStats_Base WHERE (DELFLAG = '0') ";
                dt2 = pageControl.doSql(sql2).Tables[0];

                ListItem li2 = new ListItem("全部", "");
                DDL_Status.Items.Add(li2);

                for (int k = 0; k < dt2.Rows.Count; k++)
                {
                    string WorkStats = dt2.Rows[k]["WorkStataName"].ToString();
                    string ID = dt2.Rows[k]["ID"].ToString();
                    ListItem li = new ListItem(WorkStats, ID);
                    DDL_Status.Items.Add(li);

                    if (ID.Equals(status))
                    {
                        li.Selected = true;
                    }
                }

            }
            catch
            {

            }
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
            catch
            {
            }
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
                        HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

                        if (cb1.Checked)
                        {
                            Response.Redirect("modify.aspx?ID=" + hid.Value.ToString() + "&pageindex=" + pageindexHidden.Value.ToString() + "&depart=" + DDL_Depart.SelectedValue.ToString() + "&workstatus=" + DDL_Status.SelectedValue.ToString());
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
                        HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

                        if (cb1.Checked)
                        {
                            //获取到当前人员的基本信息
                            users_model = users_bll.GetModel(hid.Value.ToString());
                            //将删除标记设为1
                            users_model.DELFLAG = 1;

                            users_bll.Update(users_model);
                          
                            new ajax().UpdateUserRemoteInfoWithJAVAWebService(users_model, EnumRemoteOperation.Edit);

                            //添加操作日志

                            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "删除人员信息", "删除" + users_model.REALNAME + "(" + user_model.USERNAME + ")" + "成功");

                            //添加操作日志
                        }
                    }

                    //tag.Text = "操作成功！";

                    // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "&depart=" + DDL_Depart.SelectedValue.ToString() + "&workstatus=" + DDL_Status.SelectedValue.ToString() + "\";</script>";
                    // Response.Write(coutws);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入我的列表页面');javascript:location='manage.aspx?pageindex=" + Request["pageindex"] + "&depart=" + DDL_Depart.SelectedValue.ToString() + "&workstatus=" + DDL_Status.SelectedValue.ToString() + "';</script>", false);

                }

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
                    //部门或岗位的ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;

                    //是否为项目经理
                    string IsManager = DataBinder.Eval(e.Row.DataItem, "IsManager").ToString();

                    if (int.Parse(IsManager) == 1)
                    {
                        e.Row.Cells[8].Text = "<font color='red'>是</font>";
                    }
                    else if (int.Parse(IsManager) == 9)
                    {
                        e.Row.Cells[8].Text = "临时项目经理";
                    }
                    else
                    {
                        e.Row.Cells[8].Text = "否";
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 点击新增按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_add_onclick(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx");
        }
        /// <summary>
        /// 给用户创建文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Model.USER_Users> userlist = users_bll.GetModelList("DELFLAG=0 and ID not in(select UserID from Document_Folder where DELFLAG=0 and userid is not null)");
                if (userlist.Count > 0)
                {
                    for (int i = 0; i < userlist.Count; i++)
                    {
                        //人员信息添加成功以后，要向Document_Folder中添加一个当前用户的顶级档案目录

                        int docfolderid = docfolder_bll.GetMaxId();

                        docfolder_model.ID = docfolderid;
                        //目录名称
                        docfolder_model.FolderName = userlist[i].USERNAME + "_" + userlist[i].REALNAME;
                        //上级目录
                        docfolder_model.UpID = -1;
                        //文件夹的属性
                        docfolder_model.Types = "private";
                        //所属人ID
                        docfolder_model.UserID = userlist[i].ID;
                        //是否共享
                        docfolder_model.IsShare = 0;
                        //删除标记
                        docfolder_model.DELFLAG = 0;
                        //当前时间
                        docfolder_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        //栏目的路径记录（用/来隔开）
                        docfolder_model.COLUMNSPATH = "-1/" + docfolder_model.ID;
                        //栏目显示的顺序
                        docfolder_model.SHUNXU = 0;
                        //栏目的路径名称
                        docfolder_model.PNAMES = "我的文档";
                        //当前文件夹中文件的大小
                        docfolder_model.SizeOf = "0";

                        docfolder_bll.Add(docfolder_model);


                        //人员信息添加成功以后，要向Document_Folder中默认添加一个收藏夹

                        docfolder_model.ID = docfolder_bll.GetMaxId();
                        //目录名称
                        docfolder_model.FolderName = "收藏夹";
                        //上级目录
                        docfolder_model.UpID = docfolderid;
                        //文件夹的属性
                        docfolder_model.Types = "private";
                        //所属人ID
                        docfolder_model.UserID = userlist[i].ID;
                        //是否共享
                        docfolder_model.IsShare = 0;
                        //删除标记
                        docfolder_model.DELFLAG = 0;
                        //当前时间
                        docfolder_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        //栏目的路径记录（用/来隔开）
                        docfolder_model.COLUMNSPATH = "-1/" + docfolder_model.UpID + "/" + docfolder_model.ID;
                        //栏目显示的顺序
                        docfolder_model.SHUNXU = 0;
                        //栏目的路径名称
                        docfolder_model.PNAMES = "我的档案>收藏夹";
                        //当前文件夹中文件的大小
                        docfolder_model.SizeOf = "0";

                        docfolder_bll.Add(docfolder_model);
                    }
                }



            }
            catch
            {

            }
        }
    }
}
