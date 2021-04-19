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
    public partial class check : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Project_Projects project_model = new Dianda.Model.Project_Projects();
        BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();
        Dianda.Model.Cash_Message cashmessage_model = new Dianda.Model.Cash_Message();
        Dianda.BLL.Cash_Message cashmessage_bll = new Dianda.BLL.Cash_Message();
        Dianda.Model.Cash_Cards card_model = new Dianda.Model.Cash_Cards();
        Dianda.BLL.Cash_Cards card_bll = new Dianda.BLL.Cash_Cards();
        Dianda.BLL.Document_File bDocumentfile = new Dianda.BLL.Document_File();
        Dianda.Model.Document_File mDocumentfile = new Dianda.Model.Document_File();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目ID
                string ID = Request["ID"];
                Session["Work_ProjectId"] = ID;
                ShowProjectInfo(ID);

                //初始化资金卡下拉列表
                SetDDL_CashCardID();

                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 预算管理 > 预算审核";
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
                string sql = "SELECT * FROM vProject_Budget WHERE  ID = " + id;

                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    //项目名称
                    Label_ProjectName.Text = DT.Rows[0]["NAMES"].ToString();
                    //申请人
                    Label_SendUserID.Text = DT.Rows[0]["SendUserRealName"].ToString() + "[" + DT.Rows[0]["SendUserUserName"].ToString() + "]";
                    //经费单位
                    string CashDw = DT.Rows[0]["CashDw"].ToString();
                    string CashTotal = DT.Rows[0]["CashTotal"].ToString();
                    //领导审批修改过后修改预算经费
                    string CheckCash = null!= DT.Rows[0]["TEMP2"]?DT.Rows[0]["TEMP2"].ToString():"";
                    if (!CheckCash.Equals(""))
                    {
                        CashTotal = CheckCash;
                    }
                    else
                    {
                        if (null != CashDw && CashDw.Equals("万元"))
                        {
                            CashTotal = (Convert.ToDecimal(CashTotal) / 10000).ToString() + " 万元";
                        }
                        else
                        {
                            CashTotal = CashTotal + " 元";
                        }
                    }
                    //预订经费
                    Label_CashTotal.Text = CashTotal;

                    //预算表单
                    if (null != DT.Rows[0]["BudgetList"] && !DT.Rows[0]["BudgetList"].ToString().Equals(""))
                    {
                        if (DT.Rows[0]["BudgetList"].ToString().Contains('@'))
                        {
                             string[] budget = DT.Rows[0]["BudgetList"].ToString().Split('@');

                             Label_budgetlist.Text = "<a href='" + budget[budget.Length-1].ToString() + "' target='_blank'>点击查看</a>";
                        }
                        else
                        {
                            Label_budgetlist.Text = "<a href='" + DT.Rows[0]["BudgetList"].ToString() + "' target='_blank'>点击查看</a>";
                        }
                    }

                    //审批状态
                    string checkstatus = DT.Rows[0]["TEMP1"].ToString();

                    if (null != checkstatus && !checkstatus.Equals("0"))
                    {
                        RadioButtonList_Check.SelectedValue = checkstatus;

                        if (checkstatus.Equals("1"))//审核通过
                        {
                            choose_cashcard.Visible = true;
                            RB_CashCardID.Checked = true;
                        }
                        else
                        {
                            choose_cashcard.Visible = false;
                        }
                    }
                    else
                    {
                        RadioButtonList_Check.SelectedValue = "2";
                    }

                }
            }
            catch
            {

            }
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
                //项目ID
                string projectid = Request["ID"];
                project_model = project_bll.GetModel(int.Parse(projectid.ToString()));
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                string checkvalue = RadioButtonList_Check.SelectedValue.ToString();
                string flag = "";

                string urls = "";//接受审核通过和不通过的地址：审核通过，到项目文档中，审核不通过到只做提示

                if (checkvalue.Equals("1"))//表示审核通过
                {
                    flag = "审核通过";
                    //预算表单的审核状态
                    project_model.TEMP1 = "1";

                    //如果审核通过将上传的预算表单保存到项目的目录中
                    string sql = "SELECT ID FROM Document_Folder WHERE (ProjectID = '" + projectid + "') AND (UpID = 38)  and delflag='0'";
                    DataTable dt = pageControl.doSql(sql).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        string id = dt.Rows[0]["ID"].ToString();
                        //如果审核通过将上传的预算表单保存到项目的目录中
                        if (null != project_model.BudgetList && !(project_model.BudgetList.ToString().Equals("")))
                        {
                            setAttachmentsToDocument(user_model.ID, id, project_model.BudgetList.ToString());
                        }
                    }

                    //选择资金卡
                    DataSet ds1 = cashmessage_bll.GetList(" ProjectID = " + project_model.ID);
                    DataSet ds2 = card_bll.GetList(" ProjectID = " + project_model.ID);

                    if (RB_CashCardID.Checked == true)//如果选择的是资金卡则设为资金卡的ID；
                    {
                        //如果在资金卡中以前本身就有该项目的。。则要将原来的该项目的资金卡的项目ID设空
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds2.Tables[0].Rows.Count;i++ )
                            {
                                Model.Cash_Cards card_model1 = new Dianda.Model.Cash_Cards();
                                BLL.Cash_Cards card_bll1 = new Dianda.BLL.Cash_Cards();

                                string id = ds2.Tables[0].Rows[i]["ID"].ToString();
                                card_model1 = card_bll1.GetModel(int.Parse(id));

                                card_model1.ProjectID = null;
                                card_bll1.Update(card_model1);
                            }
                        }

                        //资金卡ID
                        string cashcardid = DDL_CashCardID.SelectedValue.ToString();
                        card_model = card_bll.GetModel(int.Parse(cashcardid));
                        //将资金卡表中的项目ID改成当前项目
                        card_model.ProjectID = int.Parse(projectid);

                        card_bll.Update(card_model);

                    }
                    else//如果选择的是新建资金卡则设为0,并且需要向cash_message表中加一条记录
                    {
                        project_model.CashCardID = 0;

                        //如果原来就有记录,则修改
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            //ID
                            string cashid = ds1.Tables[0].Rows[0]["ID"].ToString();
                            cashmessage_model = cashmessage_bll.GetModel(int.Parse(cashid));
                            //资金卡初始金额
                            cashmessage_model.LimitNums = Convert.ToDecimal(TB_LimitNums.Text);
                            //新建备注说明
                            cashmessage_model.Notes = TB_Notes.Text.ToString();

                            cashmessage_bll.Update(cashmessage_model);
                        }
                        else
                        {
                            //资金卡名称(暂时写的留空)
                            cashmessage_model.CardName = "";
                            //持卡人
                            cashmessage_model.CardholderID = project_model.SendUserID.ToString();
                            //项目的ID
                            cashmessage_model.ProjectID = project_model.ID;
                            //初始金额
                            cashmessage_model.LimitNums = Convert.ToDecimal(TB_LimitNums.Text.ToString());
                            //填写的时间
                            cashmessage_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToString());
                            //发出这个消息的用户的ID
                            cashmessage_model.SendUserID = user_model.ID;
                            //备注说明
                            cashmessage_model.Notes = TB_Notes.Text.ToString();
                            //是否已经阅读
                            cashmessage_model.IsRead = 0;
                            //消息的状态
                            cashmessage_model.Status = 1;

                            Session["Cash_Message_temps"] = cashmessage_model;

                            //向信息表中添加一条新建资金卡的记录
                            cashmessage_bll.Add(cashmessage_model);
                        }
                    }
                    BLL.Document_Folder bllFolder = new Dianda.BLL.Document_Folder();
                    List<Model.Document_Folder> folderlist = bllFolder.GetModelList("UpID='38' and Types='public' and ProjectID='" + projectid + "' and delflag='0'");
                    if (folderlist.Count > 0)
                    {
                        urls = "<a href='/Admin/DocumentManage/manage.aspx?CID=" + folderlist[0].COLUMNSPATH.ToString() + "&tp=1' target='_self' title='预算表单审核：审核时间" + DateTime.Now.ToString() + "'>"+project_model.NAMES.ToString() + "  预算表单  " + flag + "</a>";


                    }
                    else
                    {
                        urls = project_model.NAMES.ToString() + "  预算表单  " + flag;
                    }
                  
                }else
                {
                  
                    flag = "审核不通过";
                    //预算表单的审核状态
                    project_model.TEMP1 = "2";

                    urls = project_model.NAMES.ToString() + "  预算表单  " + flag;
                }

               project_bll.Update(project_model);


               //给业务申请者发信息
               Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
               BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

               mFaceShowMessage.DATETIME = DateTime.Now;
               mFaceShowMessage.FromTable = "申请情况";
               mFaceShowMessage.IsRead = 0;
               mFaceShowMessage.NewsID = null;
               mFaceShowMessage.NewsType = "申请情况";
               mFaceShowMessage.ReadTime = null;
               mFaceShowMessage.DELFLAG = 0;
               mFaceShowMessage.ProjectID = project_model.ID;
               mFaceShowMessage.Receive = project_model.SendUserID.ToString();//当前项目的创建人的ID
               mFaceShowMessage.URLS = urls;

                //mFaceShowMessage.URLS = "<a href='/Admin/budgetManage/manage.aspx?role=manager&Status=" + project_model.TEMP1 + "' target='_self' title='预算表单审核：审核时间" + DateTime.Now.ToString() + "'>" + project_model.NAMES.ToString() + "  预算表单  " + flag + "</a>";

               bFaceShowMessage.Add(mFaceShowMessage);
               //给业务申请者发信息



               ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入列表页面');javascript:location='manage.aspx?pageindex=" + Request["pageindex"] + "&Status=" + Request["Status"] + "&role=manager';</script>", false);


                //添加操作日志

                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "预算管理", project_model.NAMES + " 预约表单" + flag);

                //添加操作日志


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
            string role = Request["role"].ToString();

            Response.Redirect("manage.aspx?pageindex=" + page + "&Status=" + status + "&role=" + role);
        }



        /// <summary>
        /// 显示资金卡下拉列表
        /// </summary>
        /// <param name="CashflagID"></param>
        protected void SetDDL_CashCardID()
        {
            DataTable dt3 = new DataTable();
            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
            project_model = project_bll.GetModel(int.Parse(Request["ID"].ToString()));

            string sql2 = " SELECT ID,ProjectID, CardNum, CardName, LimitNums FROM Cash_Cards "+
                             " WHERE (ProjectID IS NULL OR ProjectID = '' OR ProjectID = '" + project_model.ID + "') " +
                             " AND (CardholderID = '" + project_model .SendUserID + "') " +
                             " AND Statas = 1 ";

            dt3 = pageControl.doSql(sql2).Tables[0];

            if (dt3.Rows.Count > 0)
            {
                DDL_CashCardID.Enabled = true;
                DDL_CashCardID.Items.Clear();
                for (int j = 0; j < dt3.Rows.Count; j++)
                {
                    string projectid = dt3.Rows[j]["ProjectID"].ToString();
                    string ID = dt3.Rows[j]["ID"].ToString();
                    string CardNum = dt3.Rows[j]["CardNum"].ToString();
                    string CardName = dt3.Rows[j]["CardName"].ToString();
                    string LimitNums = dt3.Rows[j]["LimitNums"].ToString();

                    string showinfo = CardName + "[" + CardNum + "," + LimitNums + "]";

                    ListItem li = new ListItem(showinfo, ID);
                    DDL_CashCardID.Items.Add(li);

                    if (projectid.Equals(project_model.ID.ToString()))
                    {
                        li.Selected = true;
                    }

                }
            }
            else
            {
                DDL_CashCardID.Items.Clear();
                ListItem li = new ListItem("暂无可选资金卡", "");
                DDL_CashCardID.Items.Add(li);
                DDL_CashCardID.Enabled = false;
                // Button_applyfor.Enabled = false;
            }
        }

        /// <summary>
        /// 资金卡选择切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RB_CashCardID_CheckedChanged(object sender, EventArgs e)
        {
            RB_CashCardID.Checked = true;

            RB_NewAddCashCard.Checked = false;

            div_cash.Visible = false;

        }

        /// <summary>
        /// 资金卡选择切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RB_NewAddCashCard_CheckedChanged(object sender, EventArgs e)
        {
            RB_CashCardID.Checked = false;

            RB_NewAddCashCard.Checked = true;

            div_cash.Visible = true;

        }

        /// <summary>
        /// 审核通过与不通过之间切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButtonList_Check_Change(object sender, EventArgs e)
        {
            //单选框所选的值
            string checkvalue = RadioButtonList_Check.SelectedValue.ToString();

            if (checkvalue.Equals("1"))//表示审核通过
            {
                choose_cashcard.Visible = true;
                RB_CashCardID.Checked = true;
                RB_NewAddCashCard.Checked = false;

            }else//审核不通过
            {
                choose_cashcard.Visible = false;
                div_cash.Visible = false;
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
                    //先要检查该项目有没有上传过文件，如果上传过，则只做替换
                    List<Model.Document_File> filelist = bDocumentfile.GetModelList("DELFLAG=0 and FolderID=" + folderid + " and filename like '项目预算表单%'");
                    if (filelist.Count > 0)
                    {
                        string[] filearray = filepath.Split('/');
                        string types = filearray[filearray.Length - 1].Split('.')[1];
                        mDocumentfile = filelist[0];
                        mDocumentfile.DATETIME = DateTime.Now;
                        mDocumentfile.DELFLAG = 0;
                        mDocumentfile.FileName = "项目预算表单." + types;
                        mDocumentfile.FilePath = filepath;
                        mDocumentfile.FileType = types;
                        mDocumentfile.FolderID = int.Parse(folderid);
                        mDocumentfile.Icon = types;
                        mDocumentfile.IsShare = 0;
                        mDocumentfile.UserID = userid;

                        bDocumentfile.Update(mDocumentfile);
                    }
                    else
                    {

                        //先要检查该项目有没有上传过文件，如果上传过，则只做替换
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
            }
            catch
            {
            }
        }

    }
}
