using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
namespace Dianda.Web.Admin.budgetManage
{
    public partial class manage : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.BLL.Document_File bDocumentfile = new Dianda.BLL.Document_File();
        Dianda.Model.Document_File mDocumentfile = new Dianda.Model.Document_File();
        Model.Project_Projects project_model = new Dianda.Model.Project_Projects();
        BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string role = Request["role"].ToString();

                if (role.Equals("manager"))//可以审批
                {
                    if (null != Request["Status"] && !Request["Status"].ToString().Equals(""))
                    {
                        DDL_Status.SelectedValue = Request["Status"];//表明是从审核页面返回的。
                    }
                    else
                    {
                        DDL_Status.SelectedValue = "0";//表明从大菜单点下来的。
                    }

                    DDL_Status.Enabled = true;

                    Button_check.Visible = true;

                   // Button_checkfalse.Visible = true;

                }
                else
                {
                    DDL_Status.SelectedValue = "1";//秘书和财务只能查看审核通过的预算表单

                    DDL_Status.Enabled = false;

                    Button_check.Visible = false;

                    //Button_checkfalse.Visible = false;
                }

                string pageindex = null;//这里是为分页服务的

                pageindex = Request["pageindex"];

                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    setRowCout(DDL_Status.SelectedValue.ToString());//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
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

                ShowListInfo(pageindex_int, DDL_Status.SelectedValue.ToString());


            }

            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 预算管理 ";
            //设置模板页中的管理值
        }


        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout(string status)
        {
            try
            {
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                DataTable DT = new DataTable();

                string sql = " SELECT * FROM vProject_Budget WHERE (BudgetList <> '') AND (BudgetList IS NOT NULL) AND (DELFLAG = 0) AND (Status = 1) ";

                string role = Request["role"].ToString();
                //如果是领导进入的预算管理，那么他只能看属于自己审批的项目的预算情况，如果是秘书或是财务的话，那么他们则能看到所有审批通过的预算管理情况。
                if (role.Equals("manager"))
                {
                    sql = sql + " AND (DoUserID = '" + user_model.ID + "') ";
                }

                sql = sql + " AND (TEMP1 = '" + status + "') ";

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
        ///显示待审核的项目列表信息 
        /// </summary>
        /// <param name="pageindex"></param>
        protected void ShowListInfo(int pageindex,string status)
        {
            try
            {
                DataTable DT = new DataTable();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                string sqlWhere1 = " (BudgetList <> '') AND (BudgetList IS NOT NULL) AND (DELFLAG = 0) AND (Status = 1) ";

                string role = Request["role"].ToString();

                //如果是领导进入的预算管理，那么他只能看属于自己审批的项目的预算情况，如果是秘书或是财务的话，那么他们则能看到所有审批通过的预算管理情况。
                if (role.Equals("manager"))
                {
                    sqlWhere1 = sqlWhere1 + " AND (DoUserID = '" + user_model.ID + "') ";
                }

                sqlWhere1 = sqlWhere1 + " AND (TEMP1 = '" + status + "') ";

                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                DT = pageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "vProject_Budget", "DATETIME").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    GridView1.Visible = true;
                    GridView1.DataSource = DT;//指定GridView1的数据是DT
                    pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    Button_check.Enabled = true;
                    //Button_checkfalse.Enabled = true;
                    tag.Text = "";
                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    notice.Text = "";
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    Button_check.Enabled = false;
                    //Button_checkfalse.Enabled = false;
                    if (alltiaoshuInt > 0)
                    {
                        ShowListInfo(pageindex - 1, status);
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
        /// 当分页控件中的“第一页”“第二页”...发生时，触发下面的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageChange_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
            pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值
            string status = DDL_Status.SelectedValue;
            setRowCout(status);
            ShowListInfo(page, status);//调用显示

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
            string status = DDL_Status.SelectedValue;
            setRowCout(status);
            ShowListInfo(page, status);//调用显示

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
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    Label lb_budget = (Label)e.Row.FindControl("LB_budget");


                    //业务申请的ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;


                    //项目创建人用户名
                    string SendUserUserName = DataBinder.Eval(e.Row.DataItem, "SendUserUserName").ToString();
                    //项目创建人真实姓名
                    string SendUserRealName = DataBinder.Eval(e.Row.DataItem, "SendUserRealName").ToString();
                    //项目创建人
                    e.Row.Cells[2].Text = SendUserRealName + "[" + SendUserUserName + "]";


                    //项目负责人用户名
                    string LeaderUserName = DataBinder.Eval(e.Row.DataItem, "LeaderUserName").ToString();
                    //项目负责人真实姓名
                    string LeaderRealName = DataBinder.Eval(e.Row.DataItem, "LeaderRealName").ToString();
                    //项目负责人
                    e.Row.Cells[3].Text = LeaderRealName + "[" + LeaderUserName + "]";

                    //领导在审批预算表单后重新填写的预算经费
                    string ProjectCash = DataBinder.Eval(e.Row.DataItem, "TEMP2").ToString();

                    string BudgetList = DataBinder.Eval(e.Row.DataItem, "BudgetList").ToString();

                    //if (!Request["role"].Equals("manager") && !ProjectCash.Equals(""))
                    if (!ProjectCash.Equals(""))
                    {
                        if (ProjectCash.Substring(ProjectCash.Length-2,2).Equals("万元"))
                        {
                            e.Row.Cells[4].Text = (Convert.ToDecimal(ProjectCash.Substring(0, ProjectCash.Length - 2))*10000).ToString();
                        }
                        else
                        {
                            e.Row.Cells[4].Text = ProjectCash.Substring(0, ProjectCash.Length-1);
                        }
                    }


                    //if (!Request["role"].Equals("manager") && BudgetList.Contains('@'))
                    if (BudgetList.Contains('@'))
                    {
                        string[] budget = BudgetList.Split('@');

                        lb_budget.Text = "<a href='" + budget[budget.Length-1].ToString() + "' target='_blank'>点击查看</a>";
                    }
                    else
                    {
                        lb_budget.Text = "<a href='" + BudgetList + "' target='_blank'>点击查看</a>";
                    }


                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 状态下拉列表改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Status_Changed(object sender, EventArgs e)
        {
            string status = DDL_Status.SelectedValue;

            setRowCout(status);
            ShowListInfo(1, status);//调用显示
        }

        /// <summary>
        /// 审核通过/审核不通过时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_check_onclick(object sender,EventArgs e)
        {
            //选择审批的条数只能为一条
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
                    tag.Text = "请选择一条数据进行审核！";

                }
                else if (num > 1)
                {
                    tag.Text = "审核时最多只能选择一条数据！";

                }
                else
                {
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");


                        if (cb1.Checked)
                        {
                            Response.Redirect("check.aspx?ID=" + hid.Value.ToString() + "&pageindex=" + pageindexHidden.Value.ToString() + "&Status=" + DDL_Status.SelectedValue.ToString() + "&role=manager");
                        }

                        //if (cb1.Checked)
                        //{
                        //    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                        //    project_model = project_bll.GetModel(int.Parse(hid.Value));

                        //    //预算表单是否审核通过：0或空待审核,1表示审核通过，2表示审核不通过
                        //    project_model.TEMP1 = "1";

                        //    string sql = "SELECT ID FROM Document_Folder WHERE (ProjectID = '" + hid.Value + "') AND (UpID = 38)  and delflag='0'";
                        //    DataTable dt = pageControl.doSql(sql).Tables[0];

                        //    if (dt.Rows.Count > 0)
                        //    {
                        //        string id = dt.Rows[0]["ID"].ToString();
                        //        //如果审核通过将上传的预算表单保存到项目的目录中
                        //        if (null != project_model.BudgetList && !(project_model.BudgetList.ToString().Equals("")))
                        //        {
                        //            setAttachmentsToDocument(user_model.ID, id, project_model.BudgetList.ToString());
                        //        }
                        //    }

                        //    project_bll.Update(project_model);

                        //    //添加操作日志

                        //    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                        //    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "预算管理", project_model.NAMES+" 预约表单" + flag);

                        //    //添加操作日志

                        //}


                    }

                }

            }
        }

        /// <summary>
        /// 将立项申请时的上传附件保存到项目的目录中
        /// </summary>
        /// <param name="folderid"></param>
        /// <param name="filepath"></param>
        private void setAttachmentsToDocument(string userid, string folderid, string filepath)
        {
            try
            {
                if (filepath.Contains('.'))
                {
                    //
                    try
                    {
                        System.IO.FileInfo f = new FileInfo(this.Page.Server.MapPath(filepath));
                        long filesize = f.Length;
                        if (filesize > 0)
                        {
                            filesize = filesize / 1024;
                            mDocumentfile.Sizeof = filesize;
                        }
                    }
                    catch
                    {
                    }
                    //

                    string[] filearray = filepath.Split('/');
                    string types = filearray[filearray.Length - 1].Split('.')[1];
                    mDocumentfile.DATETIME = DateTime.Now;
                    mDocumentfile.DELFLAG = 0;
                    mDocumentfile.FileName = "项目预算表单." + types;
                    mDocumentfile.FilePath = filepath;
                    mDocumentfile.FileType = types;
                    mDocumentfile.FolderID = int.Parse(folderid);
                    mDocumentfile.Icon = types;
                    mDocumentfile.IsShare = 0;
                    mDocumentfile.UserID = userid;

                    bDocumentfile.Add(mDocumentfile);

                }
            }
            catch
            {
            }
        }

    }
}
