using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace Dianda.Web.Admin.SystemProjectManage.ProjectCheck
{
    public partial class check : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.COMMON.pageControl pageControl1 = new Dianda.COMMON.pageControl();
        Dianda.BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();
        Dianda.Model.Project_Projects project_model = new Dianda.Model.Project_Projects();

        Dianda.BLL.Document_File bDocumentfile = new Dianda.BLL.Document_File();
        Dianda.Model.Document_File mDocumentfile = new Dianda.Model.Document_File();


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //项目ID
                string ID = Request["ID"];
                ShowProjectInfo(ID);
                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 立项审核";
                //设置模板页中的管理值
            }

        }


        /// <summary>
        /// 显示项目详情
        /// </summary>
        /// <param name="id"></param>
        protected void ShowProjectInfo(string id)
        {
            try
            {
                DataTable DT = new DataTable();
                string sql = "SELECT * FROM vProject_Projects WHERE  ID = " + id;

                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    //项目名称
                    Label_ProjectName.Text = DT.Rows[0]["NAMES"].ToString();

                    //项目负责人
                    Label_LeaderID.Text = DT.Rows[0]["LeaderRealName"].ToString() + "[" + DT.Rows[0]["LeaderUserName"].ToString() + "]";
                    //预订经费
                    Label_CashTotal.Text = DT.Rows[0]["CashTotal"].ToString();
                    //申请人
                    Label_SendUserID.Text = DT.Rows[0]["SendUserRealName"].ToString() + "[" + DT.Rows[0]["SendUserUserName"].ToString() + "]";
                    //申请时间
                    Label_DATETIME.Text = Convert.ToDateTime(DT.Rows[0]["DATETIME"].ToString()).ToString("yyyy-MM-dd");
                    //预计开始时间
                    Label_StartTime.Text = Convert.ToDateTime(DT.Rows[0]["StartTime"].ToString()).ToString("yyyy-MM-dd");
                    //预计对束时间
                    Label_EndTime.Text = Convert.ToDateTime(DT.Rows[0]["EndTime"].ToString()).ToString("yyyy-MM-dd");
                    //项目概要
                    Label_Overviews.Text = DT.Rows[0]["Overviews"].ToString();
                    //资金卡
                    Label_CashCardID.Text = DT.Rows[0]["CardName"].ToString().Equals("") ? "暂无资金卡" : DT.Rows[0]["CardName"].ToString();
                    //参与部门
                    Label_DepartmentID.Text = DT.Rows[0]["DepartmentNames"].ToString();
                    //附件地址
                    if (null != DT.Rows[0]["Attachments"] && !DT.Rows[0]["Attachments"].ToString().Equals(""))
                    {
                        LB_fj.Text = "<a href='" + DT.Rows[0]["Attachments"].ToString() + "' target='_blank'>点击查看附件</a>";
                    }

                    //审核意见
                    string DoNote = DT.Rows[0]["DoNote"].ToString();

                    if (null != DoNote && !DoNote.Equals(""))
                    {
                        LB_CheckInfo.Text = DoNote;
                    }
                    else
                    {
                        LB_CheckInfo.Text = "";
                    }

                    //审批状态
                    string status = DT.Rows[0]["Status"].ToString();

                    if (null != status && !status.Equals("0"))
                    {
                        RadioButtonList_Check.SelectedValue = status;

                        if (status.Equals("1"))//说明是审核过的。
                        {
                            LB_CheckNotice.Text = "      : 该项目已经审核通过了，不能再进行重复审核！";
                            Button_sumbit.Enabled = false;
                        }
                        else
                        {
                            LB_CheckNotice.Text = "";
                            Button_sumbit.Enabled = true;
                        }

                    }
                    else
                    {
                        RadioButtonList_Check.SelectedValue = "1";
                    }

                    //项目的所在分类,Project_Columns中的ID
                    Session["ColumnsID"] = DT.Rows[0]["ColumnsID"].ToString();



                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 点击返回触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_goback_onclick(object sender, EventArgs e)
        {
            string page = Request["pageindex"].ToString();
            string status = Request["Status"].ToString();

            Response.Redirect("manage.aspx?pageindex=" + page + "&Status=" + status);
        }

        /// <summary>
        /// 点击确定触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_onclick(object sender, EventArgs e)
        {
            try 
            {
                string flag = "审核不通过";
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                //项目ID
                string ID = Request["ID"];
                project_model = project_bll.GetModel(int.Parse(ID));

                //审批结果
                string Status = RadioButtonList_Check.SelectedValue;

                if (!(TB_DoNote.Text.ToString().Equals("")))
                {
                    //审批意见
                    project_model.DoNote = project_model.DoNote + user_model.REALNAME + "(" + user_model.USERNAME + "): " + DateTime.Now + "</br>   " + TB_DoNote.Text.ToString() + "</br></br>";

                }
                if (!(Status.Equals("3")))//只有当这个审批人直接将此项目定为通过或是不通过时才去更新审批时间和状态及审批人
                {
                    //审批时间
                    project_model.ReadTime = DateTime.Now;
                    //审批人员
                    project_model.DoUserID = user_model.ID;
                    //审批结果
                    project_model.Status = int.Parse(Status);


                    project_bll.Update(project_model);

                    //******************在移交了项目审批人之后。还需要将自己的审核意见更改过来，并且将Isturn改成已经审核过了

                    string sql_checkuser = " UPDATE Project_ShenheList SET Isturn = 2 ,Status = " + Status + ", Infors = Infors + '" + TB_DoNote.Text.ToString() + "</br>' WHERE (ProjectID = " + project_model.ID + ") AND (UserID = '" + user_model.ID + "') ";

                    pageControl.doSql(sql_checkuser);

                }
                else//如果是转交给别的人。则需要往Project_ShenheList里加一条记录
                {
                    //审批结果
                    project_model.Status = 0;
                    //审批人
                    project_model.DoUserID = DDL_CheckUserList.SelectedValue.ToString();//改成新的审批人

                    project_bll.Update(project_model);

                    //******************如果此审批者将此项目转给了其他人，则要根据所选择的移交审批人，将此项目发送给这个人,即向Project_ShenheList加条记录
                    Dianda.BLL.Project_ShenheList Shenhe_bll = new Dianda.BLL.Project_ShenheList();
                    Dianda.Model.Project_ShenheList Shenhe_model = new Dianda.Model.Project_ShenheList();

                    //在添加记录之前先检查是不是有该条记录了
                    //做这一步的目的是：在立项时已经根据当时所选择的审批人往Project_ShenheList里加了一条记录
                    //如果第一次移交给另一个人，而这个人审批时发现不属于自己审批，又转回给第一个人，
                    //这样如果再添加就会出现同一个项目，同一个审批人出现多条数据了。
                   
                    string sqlwhere = "(ProjectID = " + project_model.ID + ") AND (UserID = '" + DDL_CheckUserList.SelectedValue.ToString() + "') ";

                    List<Dianda.Model.Project_ShenheList> Li = Shenhe_bll.GetModelList(sqlwhere);

                    if(Li.Count>0)
                    {

                        string sql_changecheckuser = " UPDATE Project_ShenheList SET Isturn = 1 ,Status=0 WHERE " + sqlwhere;

                        pageControl.doSql(sql_changecheckuser);

                    }else
                    {
                        //ID
                        Shenhe_model.ID = Shenhe_bll.GetMaxId();
                        //需要审核的项目ID
                        Shenhe_model.ProjectID = project_model.ID;
                        //审核人的ID
                        Shenhe_model.UserID = DDL_CheckUserList.SelectedValue.ToString();
                        //审核状态（新建默认时默认为0：待审核）
                        Shenhe_model.Status = 0;
                        //是否到当前的用户审核:0表示未到；1表示到；2表示已经审核过
                        Shenhe_model.Isturn = 1;
                        //审核意见
                        Shenhe_model.Infors = "";

                        //向Project_ShenheList加条记录
                        Shenhe_bll.Add(Shenhe_model);
                    }

                    //******************在移交了项目审批人之后。还需要将自己的审核意见更改过来，并且将Isturn改成已经审核过了

                    string sql_checkuser = " UPDATE Project_ShenheList SET Isturn = 2 ,Status=0,Infors = Infors + '" + TB_DoNote.Text.ToString() + "</br>' WHERE (ProjectID = " + project_model.ID + ") AND (UserID = '" + user_model.ID + "') ";
                    
                    pageControl.doSql(sql_checkuser);

                    ////******************项目移交给别人审核后，需要将原来在Project_Project中的审核人改成新的审核人

                    //string sql_changechecker = " UPDATE Project_Projects SET Status = 0,DoUserID='" + DDL_CheckUserList.SelectedValue.ToString() + "' WHERE (ID = " + project_model.ID + ")";

                    //pageControl1.doSql(sql_changechecker);

                    flag = "移交审核";

                }

                if (Status.Equals("1"))//表示审批通过
                {
                    flag = "审核通过";
                    if (project_model.CashCardID == 0)//如果资金卡为0，表示新建资金卡
                    {
                        string sql = " UPDATE Cash_Message SET Status = 1 WHERE (ProjectID = " + project_model.ID + ")";
                        pageControl.doSql(sql);

                    }

                    //项审批成功以后，要向Document_Folder中添加一个当前用户的顶级档案目录
                    Dianda.Model.Document_Folder docfolder_model = new Dianda.Model.Document_Folder();
                    Dianda.BLL.Document_Folder docfolder_bll = new Dianda.BLL.Document_Folder();
                    int id=docfolder_bll.GetMaxId();
                    docfolder_model.ID =id;
                    //目录名称
                    docfolder_model.FolderName = project_model.NAMES;
                    //上级目录
                    docfolder_model.UpID = 38;
                    //文件夹的属性
                    docfolder_model.Types = "public";
                    //是否共享
                    docfolder_model.IsShare = 0;
                    //创建的用户
                    docfolder_model.UserID = user_model.ID;
                    //删除标记
                    docfolder_model.DELFLAG = 0;
                    //当前时间
                    docfolder_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    //栏目的路径记录（用/来隔开）
                    docfolder_model.COLUMNSPATH = "-1/38/" + docfolder_model.ID;
                    //项目ID
                    docfolder_model.ProjectID = int.Parse(ID);
                    //栏目显示的顺序
                    docfolder_model.SHUNXU = 0;
                    //栏目的路径名称
                    docfolder_model.PNAMES = "项目文档>" + project_model.NAMES;
                    //当前文件夹中文件的大小
                    docfolder_model.SizeOf = "0";

                    docfolder_bll.Add(docfolder_model);

                    if (null != project_model.Attachments && !(project_model.Attachments.ToString().Equals("")))
                    {
                        setAttachmentsToDocument(user_model.ID, id.ToString(), project_model.Attachments.ToString());//将立项申请时的上传附件保存到项目的目录中

                    }                    
                    
                    //项审批成功以后往信息栏目表中添加一条记录
                    Dianda.BLL.News_ColumnsExt columnsext = new Dianda.BLL.News_ColumnsExt();

                    columnsext.addCloumns(project_model.NAMES, "PROJECT",project_model.ID.ToString(),2);

                }

                //给业务申请者发信息
                Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

                mFaceShowMessage.DATETIME = DateTime.Now;
                mFaceShowMessage.FromTable = "项目审核";
                mFaceShowMessage.IsRead = 0;
                mFaceShowMessage.NewsID = null;
                mFaceShowMessage.NewsType = "项目审核";
                mFaceShowMessage.ReadTime = null;
                mFaceShowMessage.DELFLAG = 0;
                mFaceShowMessage.ProjectID = project_model.ID;
                mFaceShowMessage.Receive = project_model.SendUserID.ToString();
                mFaceShowMessage.URLS = "<a href='/Admin/personalProjectManage/OAproject/manage.aspx?projectstatus=1' target='_self' title='项目审核：审核时间" + DateTime.Now.ToString() + "'>" + project_model.NAMES.ToString() + "  " + flag + "</a> (" + user_model.REALNAME + ")";

                bFaceShowMessage.Add(mFaceShowMessage);
                //给业务申请者发信息

                if (Status.Equals("3"))
                {
                    //如果项目的审批者将此项目重新转移交给了另一个审批者，那么则需要发二个提示信息，一是新的项目审批者，第二个就是原来的项目审批者
                    
                    //给新的项目审批者发送信息

                    mFaceShowMessage.DATETIME = DateTime.Now;
                    mFaceShowMessage.FromTable = "立项申请";
                    mFaceShowMessage.IsRead = 0;
                    mFaceShowMessage.NewsID = null;
                    mFaceShowMessage.NewsType = "立项申请";
                    mFaceShowMessage.ReadTime = null;
                    mFaceShowMessage.DELFLAG = 0;
                    mFaceShowMessage.ProjectID = project_model.ID;
                    mFaceShowMessage.Receive = DDL_CheckUserList.SelectedValue.ToString();
                    //mFaceShowMessage.URLS = "<a href='/Admin/personalProjectManage/OAproject/manage.aspx?projectstatus=1' target='_self' title='项目移交：移交时间" + DateTime.Now.ToString() + "'>" + project_model.NAMES.ToString() + " (移交审核)</a>";
                    mFaceShowMessage.URLS = "<a href='/Admin/SystemProjectManage/ProjectCheck/check.aspx?ID=" + project_model.ID.ToString() + "&pageindex=1&Status=0' target='_self' title='移交审核：移交时间" + DateTime.Now.ToString() + "'>" + project_model.NAMES.ToString() + "  移交审核</a>  (" + user_model.REALNAME + ")";

                    bFaceShowMessage.Add(mFaceShowMessage);
                    //给新的项目审批者发送信息


                }

                //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "&Status=" + Request["Status"] + "\";</script>";


                //Response.Write(coutws);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入列表页面');javascript:location='manage.aspx?pageindex=" + Request["pageindex"] + "&Status=" + Request["Status"] + "';</script>", false);

                //添加操作日志

                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "系统项目管理", "审核" + flag + project_model.NAMES + "项目" + "：成功！");

                //添加操作日志

            }
            catch
            {
 
            }
        }
        /// <summary>
        /// 将立项申请时的上传附件保存到项目的目录中
        /// </summary>
        /// <param name="folderid"></param>
        /// <param name="filepath"></param>
        private void setAttachmentsToDocument(string userid,string folderid, string filepath)
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
                    mDocumentfile.FileName = "立项上传的附件." + types;
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

        /// <summary>
        /// 根据审批的结果动态的显示移交的接受者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButtonList_Check_Change(object sender, EventArgs e)
        {
            try
            {
                //审批结果
                string check = RadioButtonList_Check.SelectedValue.ToString();
                //如果选择的是移交给其他人。。则要显示出可以接受的人。
                if (check.Equals("3"))
                {
                    DDL_CheckUserList.Visible = true;

                    //根据这个项目的所属分类，找出可以审批此项的管理人员信息

                    string sql3 = " SELECT *  FROM Project_Columns WHERE ID = '" + Session["ColumnsID"].ToString() + "'";

                    DataTable dt_checkuser = pageControl.doSql(sql3).Tables[0];
                    DDL_CheckUserList.Items.Clear();
                    if (dt_checkuser.Rows.Count > 0)
                    {
                        //如果项目管理人员不为空
                        if (null != dt_checkuser.Rows[0]["UserID"] && !(dt_checkuser.Rows[0]["UserID"].ToString().Equals("")))
                        {
                            string[] CheckUserId = dt_checkuser.Rows[0]["UserID"].ToString().Split(',');
                            string[] CheckUserName = dt_checkuser.Rows[0]["UserInfos"].ToString().Split(',');

                            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                            for (int k = 0; k < CheckUserId.Length; k++)
                            {
                                //转移给其他审批时不能再次转移给自己。所以如果是自己的ID号刚不往可审批的管理人员下拉列表中放
                                if (!(CheckUserId[k].ToString().Equals(user_model.ID)))
                                {
                                    ListItem li = new ListItem(CheckUserName[k].ToString(), CheckUserId[k].ToString());
                                    DDL_CheckUserList.Items.Add(li);
                                }
                            }

                            Button_sumbit.Enabled = true;
                        }
                        else
                        {
                            ListItem li = new ListItem("暂无其他可供选择的审批人", "");
                            DDL_CheckUserList.Items.Add(li);

                            Button_sumbit.Enabled = false;
                        }
                    }
                    else
                    {
                        ListItem li = new ListItem("暂无其他可供选择的审批人", "");
                        DDL_CheckUserList.Items.Add(li);

                        Button_sumbit.Enabled = false;
                    }

                }
                else
                {
                    DDL_CheckUserList.Visible = false;
                }
            }
            catch
            { }
        }

    }
}
