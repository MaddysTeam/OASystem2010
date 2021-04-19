using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace Dianda.Web.Admin.personalProjectManage.OAproject
{
    public partial class add : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pagecontrol = new Dianda.COMMON.pageControl();
        Dianda.BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();
        Dianda.Model.Project_Projects project_model = new Dianda.Model.Project_Projects();
        Dianda.Model.Cash_Message cashmessage_model = new Dianda.Model.Cash_Message();
        Dianda.BLL.Cash_Message cashmessage_bll = new Dianda.BLL.Cash_Message();
        Dianda.COMMON.FileControl FCL = new Dianda.COMMON.FileControl();
        Dianda.COMMON.fileUploads fileup = new Dianda.COMMON.fileUploads();

        Dianda.Model.FaceShowMessage mFaceshowMessage = new Dianda.Model.FaceShowMessage();
        Dianda.BLL.FaceShowMessage bFaceshowMessage = new Dianda.BLL.FaceShowMessage();


        Dianda.BLL.Document_File bDocumentfile = new Dianda.BLL.Document_File();
        Dianda.Model.Document_File mDocumentfile = new Dianda.Model.Document_File();


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //初始化下拉列表的值
                ShowDDLInfo();
                //根据所选择的项目负责人来动态的选择默认的部门,选中后并且设置为不可用
                SetCB_DepartmentID();
                //新建项目创建人控件
                Add_NewLeader1.Visible = false;
            }

            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "项目 > 新建项目 ";
            //设置模板页中的管理值
        }

        /// <summary>
        /// 初始化下拉列表的值
        /// </summary>
        protected void ShowDDLInfo()
        {
            try
            {
                string CashflagID = "";

                //显示项目负责人下拉列表
                DataTable dt = new DataTable();

                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                string sql = " SELECT ID,DepartMentID, USERNAME, REALNAME FROM USER_Users WHERE (DELFLAG = 0) AND (IsManager = 1 or IsManager = 9)  AND (WorkStats = 1) ORDER BY REALNAME,ID ";

                dt = pagecontrol.doSql(sql).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string ID = dt.Rows[i]["ID"].ToString();
                        string DepartMentID = dt.Rows[i]["DepartMentID"].ToString();
                        string REALNAME = dt.Rows[i]["REALNAME"].ToString();
                        string USERNAME = dt.Rows[i]["USERNAME"].ToString();

                        ListItem li = new ListItem(REALNAME + "(" + USERNAME + ")", ID + "|" + DepartMentID);
                        DDL_LeaderID.Items.Add(li);

                        if (user_model.ID.Equals(ID))
                        {
                            li.Selected = true;
                        }
                    }
                    CashflagID = dt.Rows[0]["ID"].ToString();
                }
                else//因为项目负责人是非空项，如果没有项目负责人的话是不可以进行项目的申请的。
                {
                    ListItem li = new ListItem("没有可选项目负责人", "");
                    DDL_LeaderID.Items.Add(li);

                    DDL_LeaderID.Enabled = false;
                    Button_applyfor.Enabled = false;
                    //Button_reset.Enabled = false;
                    Button_draft.Enabled = false;
                }


                //显示可供参与的部门信息 。
                DataTable dt_dep = new DataTable();
                string sql1 = " SELECT ID, NAME FROM USER_Groups WHERE (DELFLAG = 0) AND (TAGS = '部门') ORDER BY ISMOREN ";
                dt_dep = pagecontrol.doSql(sql1).Tables[0];

                if (dt_dep.Rows.Count>0)
                {
                    CB_DepartmentID.DataSource = dt_dep.DefaultView;
                    CB_DepartmentID.DataTextField = "NAME";
                    CB_DepartmentID.DataValueField = "ID";
                    CB_DepartmentID.DataBind();

                }
                else//因为参与部门是非空项，所以如果没有可供参与的部门的话，是不可以进行项目的申请的。
                {
                    CB_DepartmentID.Enabled = false;
                    Label_dep.Visible = true;
                    Button_applyfor.Enabled = false;
                   // Button_reset.Enabled = false;
                    Button_draft.Enabled = false;
                }

                //根据项目负责人来动态显示资金卡下拉列表
                //if (!CashflagID.Equals(""))
                //{
                //    SetDDL_CashCardID(CashflagID);
                //}


                //显示所属分类的下拉列表
                DataTable dt_col = new DataTable();
                //string sql2 = " SELECT *  FROM Project_Columns WHERE (DELFLAG = 0) AND (UpID <> 0) order by COLUMNSPATH";
                string sql2 = " SELECT *  FROM Project_Columns WHERE (DELFLAG = 0) order by COLUMNSPATH";

                dt_col = pagecontrol.doSql(sql2).Tables[0];

                //if (dt_col.Rows.Count>0)
                //{
                //    for (int i = 0; i < dt_col.Rows.Count;i++ )
                //    {
                //        ListItem li = new ListItem(dt_col.Rows[i]["Names"].ToString(), dt_col.Rows[i]["ID"].ToString());
                //        DDL_COLUMN.Items.Add(li);
                //    }
                if (dt_col.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_col.Rows.Count; i++)
                    {
                        string parentid = dt_col.Rows[i]["UpID"].ToString();
                        string path = dt_col.Rows[i]["COLUMNSPATH"].ToString();
                         
                        if (parentid != "0")
                        {
                            string kg = null;
                            int lens = path.Split('/').Length;
                            for (int x = 0; x < lens; x++)
                            {
                                kg += "··";
                            }
                            dt_col.Rows[i]["Names"] = kg + "|--" + dt_col.Rows[i]["Names"].ToString() + "  [ " + dt_col.Rows[i]["TYPES"].ToString()+" ]";
                        }
                        ListItem L1 = new ListItem();
                        L1.Text = dt_col.Rows[i]["Names"].ToString();
                        L1.Value = dt_col.Rows[i]["ID"].ToString();
                        DDL_COLUMN.Items.Add(L1);
                    }


                    //根据所属分类动态的显示这个分类的管理人，此管理即作为项目的审核人，供项目创建者来选择。

                    string sql3 = " SELECT *  FROM Project_Columns WHERE ID = '" + DDL_COLUMN.SelectedValue.ToString() + "'";

                    DataTable dt_checkuser = pagecontrol.doSql(sql3).Tables[0];
                    if (dt_checkuser.Rows.Count > 0)
                    {
                        //如果项目管理人员不为空
                        if (null != dt_checkuser.Rows[0]["UserID"] && !(dt_checkuser.Rows[0]["UserID"].ToString().Equals("")))
                        {
                            string[] CheckUserId = dt_checkuser.Rows[0]["UserID"].ToString().Split(',');
                            string[] CheckUserName = dt_checkuser.Rows[0]["UserInfos"].ToString().Split(',');

                            for (int k = 0; k < CheckUserId.Length; k++)
                            {
                                ListItem L = new ListItem(CheckUserName[k].ToString(), CheckUserId[k].ToString());
                                DDL_CheckUserID.Items.Add(L);
                            }

                            LB_CheckUserInfo.Visible = false;
                        }
                        else
                        {
                            
                            ListItem L = new ListItem("暂无可供选择的审批人", "");
                            DDL_CheckUserID.Items.Add(L);

                            LB_CheckUserInfo.Visible = true;
                            Button_applyfor.Enabled = false;
                            Button_draft.Enabled = false;
                        }
                    }
                    else
                    {
                        ListItem L = new ListItem("暂无可供选择的审批人", "");
                        DDL_CheckUserID.Items.Add(L);

                        LB_CheckUserInfo.Visible = true;
                        Button_applyfor.Enabled = false;
                        Button_draft.Enabled = false;
                    }

                }else
                {
                    ListItem li = new ListItem("暂无可选分类","");
                    DDL_COLUMN.Items.Add(li);

                    ListItem L = new ListItem("暂无可供选择的审批人", "");
                    DDL_CheckUserID.Items.Add(L);


                    DDL_COLUMN.Enabled = false;
                    DDL_CheckUserID.Enabled = false;
                    Button_applyfor.Enabled = false;
                    Button_draft.Enabled = false;
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 根据项目负责人来动态显示资金卡下拉列表
        /// </summary>
        /// <param name="CashflagID"></param>
        //protected void SetDDL_CashCardID(string CashflagID)
        //{
        //    DataTable dt3 = new DataTable();

        //    string sql2 = " SELECT ID, CardNum, CardName, LimitNums FROM Cash_Cards WHERE (CardholderID = '" + CashflagID + "') ";
        //    dt3 = pagecontrol.doSql(sql2).Tables[0];

        //    if (dt3.Rows.Count > 0)
        //    {
        //        DDL_CashCardID.Enabled = true;
        //        DDL_CashCardID.Items.Clear();
        //        for (int j = 0; j < dt3.Rows.Count; j++)
        //        {
        //            string ID = dt3.Rows[j]["ID"].ToString();
        //            string CardNum = dt3.Rows[j]["CardNum"].ToString();
        //            string CardName = dt3.Rows[j]["CardName"].ToString();
        //            string LimitNums = dt3.Rows[j]["LimitNums"].ToString();

        //            string showinfo = CardName + "[" + CardNum + "," + LimitNums + "]";

        //            ListItem li = new ListItem(showinfo, ID);
        //            DDL_CashCardID.Items.Add(li);

        //        }


        //        Button_applyfor.Enabled = true;
        //        Button_reset.Enabled = true;
        //        Button_draft.Enabled = true;

        //    }
        //    else
        //    {
        //        DDL_CashCardID.Items.Clear();
        //        ListItem li = new ListItem("暂无可选资金卡", "");
        //        DDL_CashCardID.Items.Add(li);
        //        DDL_CashCardID.Enabled = false;
        //        Button_applyfor.Enabled = false;
        //        Button_reset.Enabled = false;
        //        Button_draft.Enabled = false;
        //    }
        //}

        /// <summary>
        /// 资金卡选择切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void RB_NewAddCashCard_CheckedChanged(object sender, EventArgs e)
        //{
        //        RB_CashCardID.Checked = false;

        //        RB_NewAddCashCard.Checked = true;

        //        div_cash.Visible = true;

        //        Button_applyfor.Enabled = true;
        //        Button_reset.Enabled = true;
        //        Button_draft.Enabled = true;
        //}


        /// <summary>
        /// 资金卡选择切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void RB_CashCardID_CheckedChanged(object sender, EventArgs e)
        //{
        //    RB_CashCardID.Checked = true;

        //    RB_NewAddCashCard.Checked = false;

        //    div_cash.Visible = false;
        //}

        /// <summary>
        /// 点击申请触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_applyfor_Click(object sender, EventArgs e)
        {
            try
            {
                string projectName = NAME.Text.ToString();

                //检查是否有该项目名称
                bool checkName = pagecontrol.Exists_Name("Project_Projects", "NAMES", projectName, "ID", "");
                if (checkName)
                {
                    tag.Text = "该项目名称已经存在，请修改！";
                }
                else
                {
                    //string content = FCL.UpFile(_FileUp, "/AllFileUp/fileup");
                    if (FileUpload1.FileName.Length>2)
                    {
                        string[] content = fileup.UpFile_COMMONS(FileUpload1, "/AllFileUp/fileup", "");
                        //1-成功；0-失败；2-类型不支持；3-大小不符合;文件的路径；文件名称；文件类型；图标；大小；操作结果
                        if (content[0] == "0")
                        {
                            tag.Text = "文件上传失败，请重新上传！";
                            return;
                        }
                        else if (content[0] == "2")
                        {
                            tag.Text = "系统不允许此类文件上传,文件上传失败，请重新上传！";
                            return;
                        }
                        else if (content[0] == "3")
                        {
                            tag.Text = "文件上传大小不符合，文件上传失败，请重新上传！";
                            return;
                        }

                        project_model.Attachments = content[1];

                    }

                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                    int statusflag = Convert.ToInt32(((Button)sender).CommandArgument.ToString());//获取到触发源
                    //ID
                    int ids = project_bll.GetMaxId();
                    project_model.ID =ids;
                    //项目类型
                    project_model.ProjectType = int.Parse(RL_ProjectType.SelectedValue.ToString());
                    //项目名称
                    project_model.NAMES = NAME.Text.ToString();
                    //删除标记
                    project_model.DELFLAG = 0;
                    //状态
                    if (RL_ProjectType.SelectedValue.ToString().Equals("1"))
                    {
                        project_model.Status = statusflag;
                    }
                    else
                    {
                        project_model.Status = 1;//项目状态设置为正常运行的项目
                    }
                    //项目负责人
                    //project_model.LeaderID = DDL_LeaderID.SelectedValue.ToString();
                    if (CheckBox_Newleader.Checked == true)
                    {
                        if (Session["new_leaderid"] != null && Session["new_leaderid"] !="")
                        {
                            project_model.LeaderID = Session["new_leaderid"].ToString();
                        }
                        else
                        {
                            tag.Text = "未设置项目创建人！无法新建项目！";
                            return;
                        }
                    }
                    else
                    {
                        string[] Leader = DDL_LeaderID.SelectedValue.ToString().Split('|');
                        project_model.LeaderID = Leader[0].ToString();
                    }
                    //参与部门
                    project_model.DepartmentID = "";
                    //参与部门名称
                    project_model.DepartmentNames = "";
                    for (int i = 0; i < CB_DepartmentID.Items.Count; i++)
                    {
                        if (CB_DepartmentID.Items[i].Selected == true)
                        {
                            project_model.DepartmentID = project_model.DepartmentID + CB_DepartmentID.Items[i].Value + ",";

                            project_model.DepartmentNames = project_model.DepartmentNames + CB_DepartmentID.Items[i].Text + ",";
                        }
                    }
                    /* 截掉最后一个逗号*/
                    if (project_model.DepartmentID.Length > 0)
                    {
                        project_model.DepartmentID = project_model.DepartmentID.Substring(0, project_model.DepartmentID.Length - 1);
                        project_model.DepartmentNames = project_model.DepartmentNames.Substring(0, project_model.DepartmentNames.Length - 1);
                    }

                    //项目预计起始时间
                    project_model.StartTime = Convert.ToDateTime(TB_StartTime.Value.ToString());
                    //项目预计结束时间
                    project_model.EndTime = Convert.ToDateTime(TB_EndTime.Value.ToString());
                    //预计经费
                    if (RL_ProjectType.SelectedValue.ToString().Equals("1"))//当项目类型为正常项目时才有预计经费项
                    {
                        //审核的用户ID
                        project_model.DoUserID = DDL_CheckUserID.SelectedValue.ToString();

                        if (!CashTotal.Text.ToString().Equals(""))
                        {
                            if (RB_cashtotal.SelectedValue.ToString().Equals("1"))//表示经费单位选择的是万元
                            {
                                //经费额度存放的是元
                                project_model.CashTotal = Convert.ToDecimal(CashTotal.Text.ToString()) * 10000;
                                //经费单位
                                project_model.CashDw = "万元";
                            }
                            else
                            {
                                project_model.CashTotal = Convert.ToDecimal(CashTotal.Text.ToString());
                                //经费单位
                                project_model.CashDw = "元";
                            }

                        }
                    }
                    else
                    {
                        //审核的用户ID
                        project_model.DoUserID = "";
                    }
                    //资金卡选择
                    project_model.CashCardID = 0;
                    //if (RB_CashCardID.Checked == true)//如果选择的是资金卡则设为资金卡的ID；
                    //{
                    //    project_model.CashCardID = Int16.Parse(DDL_CashCardID.SelectedValue.ToString());
                    //}
                    //else//如果选择的是新建资金卡则设为0,并且需要向cash_message表中加一条记录
                    //{
                    //    project_model.CashCardID = 0;
                    //    //资金卡名称(暂时写的留空)
                    //    cashmessage_model.CardName = "";
                    //    //持卡人
                    //    cashmessage_model.CardholderID = DDL_LeaderID.SelectedValue;
                    //    //项目的ID
                    //    cashmessage_model.ProjectID = project_model.ID;
                    //    //初始金额
                    //    cashmessage_model.LimitNums = Convert.ToDecimal(TB_LimitNums.Text.ToString());
                    //    //填写的时间
                    //    cashmessage_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToString());
                    //    //发出这个消息的用户的ID
                    //    cashmessage_model.SendUserID = user_model.ID;
                    //    //备注说明
                    //    cashmessage_model.Notes = TB_Notes.Text.ToString();
                    //    //是否已经阅读
                    //    cashmessage_model.IsRead = 0;
                    //    //消息的状态
                    //    cashmessage_model.Status = 0;

                    //    Session["Cash_Message_temps"] = cashmessage_model;

                    //    //向信息表中添加一条新建资金卡的记录
                    //    cashmessage_bll.Add(cashmessage_model);

                    //}
                    //项目概要
                    project_model.Overviews = Overviews.Value.ToString();
                    //申请时间
                    project_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToString());
                    //申请的用户的ID
                    project_model.SendUserID = user_model.ID;
                    //所属分类
                    project_model.ColumnsID =int.Parse(DDL_COLUMN.SelectedValue);

                    //向项目表中添加
                    project_bll.Add(project_model);

                    //******************在项目申请成功以后将项目负责人默认为项目组成员,即向Project_UserList加条记录

                    Dianda.BLL.Project_UserList project_userlist_bll = new Dianda.BLL.Project_UserList();
                    Dianda.Model.Project_UserList project_userlist_model = new Dianda.Model.Project_UserList();

                   // project_userlist_model.ID = project_userlist_bll.GetMaxId();

                    //项目ID
                    project_userlist_model.ProjectID = ids; // project_model.ID;
                    //项目组成员
                    project_userlist_model.UserID = project_model.LeaderID;
                    //状态
                    project_userlist_model.Status = 1;
                    //时间
                    project_userlist_model.DATETIME = DateTime.Now;

                    //向Project_UserList加条记录
                    project_userlist_bll.Add(project_userlist_model);
                    //再将项目的创建者添加到项目组成员列表中--唐春龙2011-02-17
                    project_userlist_model.ProjectID = ids;
                    project_userlist_model.UserID = project_model.SendUserID.ToString();
                    project_userlist_model.Status = 1;
                    project_userlist_model.DATETIME = DateTime.Now;
                    project_userlist_bll.Add(project_userlist_model);

                    //******************在项目申请成功以后要根据所选择的项目审批人，将此项目发送给这个人,即向Project_ShenheList加条记录
                    //如果项目类型是“正常项目”才做如下操作
                    if(RL_ProjectType.SelectedValue.ToString().Equals("1"))
                    {
                        Dianda.BLL.Project_ShenheList Shenhe_bll = new Dianda.BLL.Project_ShenheList();
                        Dianda.Model.Project_ShenheList Shenhe_model = new Dianda.Model.Project_ShenheList();

                        //ID
                        Shenhe_model.ID = Shenhe_bll.GetMaxId();
                        //需要审核的项目ID
                        Shenhe_model.ProjectID = project_model.ID;
                        //审核人的ID
                        Shenhe_model.UserID = DDL_CheckUserID.SelectedValue.ToString();
                        //审核状态（新建默认时默认为0：待审核）
                        Shenhe_model.Status = 0;
                        //是否到当前的用户审核:0表示未到；1表示到；2表示已经审核过
                        Shenhe_model.Isturn = 1;
                        //审核意见
                        Shenhe_model.Infors = "";

                        //向Project_ShenheList加条记录
                        Shenhe_bll.Add(Shenhe_model);
                    }
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入我的项目页面');javascript:location='manage.aspx?projecttype=4&projectStatus=0';</script>", false);


                    if (statusflag==4)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入立项草稿箱页面');javascript:location='manage.aspx?projectStatus=4';</script>", false);

                    }
                    else
                    {
                        if (RL_ProjectType.SelectedValue.ToString().Equals("0"))//临时项目
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入我的项目页面');javascript:location='manage.aspx?projectStatus=1';</script>", false);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入我的项目页面');javascript:location='manage.aspx?projectStatus=0';</script>", false);
                        }
                    }
                    //清空Session new_leaderid
                    Session["new_leaderid"] = "";

                    //添加操作日志
                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加立项申请", "添加"+project_model.NAMES+"项目申请成功");
                    //添加操作日志

                    //tag.Text = "操作成功! 点击“返回”按钮进入我的项目页面！";
                    //addproject.Visible = false;
                  //  goback.Visible = true;

                    //添加立项申请的前台提醒信息
                    mFaceshowMessage.DATETIME = DateTime.Now;
                    mFaceshowMessage.FromTable = "立项申请";
                    mFaceshowMessage.IsRead = 0;
                    mFaceshowMessage.NewsType = "立项申请";
                    mFaceshowMessage.Receive = project_model.DoUserID.ToString();
                    mFaceshowMessage.DELFLAG = 0;
                    mFaceshowMessage.ProjectID = project_model.ID;
                    mFaceshowMessage.URLS = "<a href='/Admin/SystemProjectManage/ProjectCheck/check.aspx?ID=" + ids.ToString() + "&pageindex=1&Status=0' target='_self' title='新建项目：提交时间" + DateTime.Now.ToString() + "'>新建项目：" + NAME.Text.ToString() + "</a> (" + user_model.REALNAME + ")";
                    bFaceshowMessage.Add(mFaceshowMessage);

                    //如果是个人或者是临时项目的话，就没有审批一环了。所以就直接在创建项目时建一个档案目录
                    if(RL_ProjectType.SelectedValue.ToString().Equals("0"))
                    {
                        //项审批成功以后，要向Document_Folder中添加一个当前用户的顶级档案目录
                        Dianda.Model.Document_Folder docfolder_model = new Dianda.Model.Document_Folder();
                        Dianda.BLL.Document_Folder docfolder_bll = new Dianda.BLL.Document_Folder();
                        int id = docfolder_bll.GetMaxId();
                        docfolder_model.ID = id;
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
                        docfolder_model.ProjectID = ids;
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

                        columnsext.addCloumns(project_model.NAMES, "PROJECT", project_model.ID.ToString(), 2);
                    }



                }
            }
            catch
            {
                tag.Text = "立项过程中发生错误，请检查输入项是否正确！";
            }
        }

        /// <summary>
        /// 点击重置触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Button_reset_Click(object sender, EventArgs e)
        //{
            
        //    NAME.Text = "";

        //    for (int i = 0; i < CB_DepartmentID.Items.Count; i++)
        //    {
        //        if (CB_DepartmentID.Items[i].Selected == true)
        //        {
        //            CB_DepartmentID.Items[i].Selected = false;
        //        }
        //    }
        //    TB_StartTime.Value = "";
        //    TB_EndTime.Value = "";
        //    CashTotal.Text = "";
        //    RB_CashCardID.Checked = true;
        //    RB_NewAddCashCard.Checked = false;
        //    Overviews.Value= "";
        //    div_cash.Visible = false;
        //    TB_LimitNums.Text = "";
        //    TB_Notes.Text = "";
        //}
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
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/person_Index.aspx");
        }

        /// <summary>
        /// 根据项目负责人来动态显示资金卡下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void DDL_LeaderID_Changed(object sender, EventArgs e)
        //{
        //    string ID = DDL_LeaderID.SelectedValue.ToString();
        //    SetDDL_CashCardID(ID);
        //}

        /// <summary>
        /// 立项草稿箱触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_DraftBox_Click(object sender, EventArgs e)
        {
           // Response.Redirect("manage.aspx?projecttype=4&projectstatus=4");
            Response.Redirect("manage.aspx?projectstatus=4");
        }


        /// <summary>
        /// 根据所选择的项目负责人来动态的选择默认的部门,选中后并且设置为不可用
        /// </summary>
        protected void SetCB_DepartmentID()
        {
            try
            {
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                string deptid = DDL_LeaderID.SelectedValue.Split('|')[1].ToString();//项目负责人的部门ID
                string credid = user_model.DepartMentID.ToString();//项目创建者的部门ID
                string deptall = deptid + "," + credid;//所有部门的合集
                for (int i = 0; i < CB_DepartmentID.Items.Count; i++)
                {
                    //下面做的目的是要将上一次默认选上的并且不可用的部门恢复成正常情况。
                    CB_DepartmentID.Items[i].Selected = false;
                    CB_DepartmentID.Items[i].Enabled = true;

                    //部门的ID
                    string id = CB_DepartmentID.Items[i].Value.ToString();
                    //所选择的项目负责人所属的部门ID和创建者的ID

                    if (deptall.Contains(id))
                    {
                        CB_DepartmentID.Items[i].Selected = true;
                        CB_DepartmentID.Items[i].Enabled = false;

                    }
                }
            }
            catch
            {
 
            }
        }

        /// <summary>
        /// 项目负责人下拉列表触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_LeaderID_Changed(object sender, EventArgs e)
        {
            try
            {
                SetCB_DepartmentID();
            }
            catch
            {
 
            }
        }

        /// <summary>
        /// 根据所属分类下拉列表的改变来改变后面详细信息的显示与否，如果是总项目，则需要显示此分类的详细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_COLUMN_Changed(object sender , EventArgs e)
        {
            try
            {
                //选择的所属分类
                string column = DDL_COLUMN.SelectedItem.Text.ToString();

                if (column.Contains("规划"))
                {
                    LB_COLUMNINFO.Text = "<a href=\"javascript:window.showModalDialog('show.aspx?ID=" + DDL_COLUMN.SelectedValue.ToString() + "','','dialogWidth=726px;dialogHeight=400px');\" target='_self' style='text-decoration: none' title='总项目分类详细信息''>显示该总项目详细</a>";
                    LB_COLUMNINFO.Visible = true;
                }
                else
                {
                    LB_COLUMNINFO.Text = "";
                    LB_COLUMNINFO.Visible = false;
                }

                //根据所属分类动态的显示这个分类的管理人，此管理即作为项目的审核人，供项目创建者来选择。

                string sql3 = " SELECT *  FROM Project_Columns WHERE ID = '" + DDL_COLUMN.SelectedValue.ToString() + "'";

                DataTable dt_checkuser = pagecontrol.doSql(sql3).Tables[0];
                DDL_CheckUserID.Items.Clear();
                if (dt_checkuser.Rows.Count > 0)
                {
                    //如果项目管理人员不为空
                    if (null != dt_checkuser.Rows[0]["UserID"] && !(dt_checkuser.Rows[0]["UserID"].ToString().Equals("")))
                    {
                        string[] CheckUserId = dt_checkuser.Rows[0]["UserID"].ToString().Split(',');
                        string[] CheckUserName = dt_checkuser.Rows[0]["UserInfos"].ToString().Split(',');

                        for (int k = 0; k < CheckUserId.Length; k++)
                        {
                            ListItem li = new ListItem(CheckUserName[k].ToString(), CheckUserId[k].ToString());
                            DDL_CheckUserID.Items.Add(li);
                        }
                        LB_CheckUserInfo.Visible = false;
                        Button_applyfor.Enabled = true;
                        Button_draft.Enabled = true;
                    }
                    else
                    {
                        ListItem li = new ListItem("暂无可供选择的审批人", "");
                        DDL_CheckUserID.Items.Add(li);

                        LB_CheckUserInfo.Visible = true;
                        Button_applyfor.Enabled = false;
                        Button_draft.Enabled = false;
                    }
                }
                else
                {
                    ListItem li = new ListItem("暂无可供选择的审批人", "");
                    DDL_CheckUserID.Items.Add(li);

                    LB_CheckUserInfo.Visible = true;
                    Button_applyfor.Enabled = false;
                    Button_draft.Enabled = false;
                }
            }
            catch
            { }
        }


        /// <summary>
        /// 项目类型改变时所触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RL_ProjectType_Change(object sender, EventArgs e)
        {
            try
            {
                if(RL_ProjectType.SelectedValue.ToString().Equals("0"))
                {
                    //项目审批人
                    div_CheckUserID.Visible = false;
                    //预算经费
                    div_CashTotal.Visible = false;
                    //保存到草稿
                    Button_draft.Visible = false;

                }else
                {
                    //项目审批人
                    div_CheckUserID.Visible = true;
                    //预算经费
                    div_CashTotal.Visible = false;
                    //保存到草稿
                    Button_draft.Visible = true;
                }
            }
            catch
            {
 
            }
        }
        //选择新建项目创建人是触发
        protected void CheckBox_Newleader_CheckedChanged(object sender, EventArgs e)
        {
            Add_NewLeader1.Visible = CheckBox_Newleader.Checked;
            Label_NewLeader.Visible = CheckBox_Newleader.Checked;
            if (CheckBox_Newleader.Checked == true)
            {
                DDL_LeaderID.Enabled = false;
            }
            else { DDL_LeaderID.Enabled = true; }
        }

    }
}
