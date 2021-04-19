using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace Dianda.Web.Admin.applyManage.OrdersignetManage
{
    public partial class check : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.Model.Project_Apply apply_model = new Dianda.Model.Project_Apply();
        Dianda.BLL.Project_Apply apply_bll = new Dianda.BLL.Project_Apply();

        Dianda.BLL.Document_File bDocumentfile = new Dianda.BLL.Document_File();
        Dianda.Model.Document_File mDocumentfile = new Dianda.Model.Document_File();
        BLL.Document_Folder bdocumentfolder = new Dianda.BLL.Document_Folder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            //业务申请ID
            string ID = Request["ID"];
            ShowApplyInfo(ID);

            if (null != Request["H_status"] && !Request["H_status"].ToString().Equals("1"))
            {
                for (int i = 0; i < RadioButtonList_Check.Items.Count;i++ )
                {
                    if (RadioButtonList_Check.Items[i].Value.ToString().Equals("4"))
                    {
                        RadioButtonList_Check.Items[i].Enabled = false;
                    }
                }
            }
            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 用印管理 > 用印审批 ";
            //设置模板页中的管理值
            }
        }


        /// <summary>
        /// 显示项目详情
        /// </summary>
        /// <param name="id"></param>
        protected void ShowApplyInfo(string id)
        {
            try
            {
                DataTable DT = new DataTable();
                string sql = "SELECT * FROM vProject_Apply_OrderSignet WHERE  ID = " + id;

                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    //项目名称
                    Label_ProjectName.Text = DT.Rows[0]["ProjectNames"].ToString();
                    Session["ProjectNames"] = DT.Rows[0]["ProjectNames"].ToString();
                    //提交申请时间
                    Label_DATETIME.Text = Convert.ToDateTime(DT.Rows[0]["DATETIME"].ToString()).ToString("yyyy-MM-dd hh:mm");
                    //用印类型
                    Label_SignetName.Text = DT.Rows[0]["SignetName"].ToString();
                    Session["SignetName"] = DT.Rows[0]["SignetName"].ToString();
                    //预订申请人
                    Label_SendUserID.Text = DT.Rows[0]["SendRealName"].ToString() + "[" + DT.Rows[0]["SendUserName"].ToString() + "]";
                    Session["Signet_ApplyUserName"] ="("+ DT.Rows[0]["SendRealName"].ToString() + ")";
                    //申请部门
                    Label_DepartmentID.Text = DT.Rows[0]["DepartmentName"].ToString();
                    //项目概要
                    Label_Overviews.Text = DT.Rows[0]["Overviews"].ToString();
                    //用印份数
                    Label_SignetNums.Text = DT.Rows[0]["Nums"].ToString();
                    Session["Signet_Nums"] = DT.Rows[0]["Nums"].ToString();

                    //审核意见
                    string DoNote = DT.Rows[0]["DoNote"].ToString();

                    if (null != DoNote && !DoNote.Equals(""))
                    {
                        TB_DoNote.Text = DoNote;
                    }
                    else
                    {
                        TB_DoNote.Text = "";
                    }

                    //审批状态
                    string status = DT.Rows[0]["Status"].ToString();

                    if (null != status  && !status.Equals("0"))
                    {
                        RadioButtonList_Check.SelectedValue = status;

                    }else
                    {
                        RadioButtonList_Check.SelectedValue = "1";
                    }

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
                DateTime now = DateTime.Now;
                string flag = "已挂起";
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                //业务申请ID
                string ID = Request["ID"];
                apply_model = apply_bll.GetModel(int.Parse(ID));

                //审批人员
                apply_model.DoUserID = user_model.ID;
                //审批意见
                apply_model.DoNote = TB_DoNote.Text.ToString();

                //审批结果
                string Status = RadioButtonList_Check.SelectedValue;
                if (Status.Equals("4"))
                {
                    flag = "盖章完成";

                    //执行人
                    apply_model.TEMP1 = user_model.REALNAME.ToString();
                    //执行时间
                    apply_model.TEMP2 = DateTime.Now.ToString();

                }
                else
                {
                    //审批时间
                    apply_model.ReadTime = now;
                }

                if (Status.Equals("1"))
                {
                    flag = "审核通过";
                    //将此附件上传到项目文档中
                    if(apply_model.Attachments.ToString().Contains("."))
                    {
                        List<Model.Document_Folder> documentfolderlist=bdocumentfolder.GetModelList("Upid='38' and Types='public' and ProjectID='"+apply_model.ProjectID.ToString()+"' and delflag='0'");
                        if (documentfolderlist.Count > 0)
                        {
                            setAttachmentsToDocument(apply_model.SendUserID.ToString(), documentfolderlist[0].ID.ToString(), apply_model.Attachments.ToString());
                        }
                    }
                }

                apply_model.Status = int.Parse(Status);

                apply_bll.Update(apply_model);

                //给业务申请者发信息
                Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

                mFaceShowMessage.DATETIME = now;
                mFaceShowMessage.FromTable = "申请情况";
                mFaceShowMessage.IsRead = 0;
                mFaceShowMessage.NewsID = null;
                mFaceShowMessage.NewsType = "申请情况";
                mFaceShowMessage.ReadTime = null;
                mFaceShowMessage.Receive = apply_model.SendUserID.ToString();
                mFaceShowMessage.URLS = "<a href=\"javascript:window.showModalDialog('/Admin/personalProjectManage/OAapply/show.aspx?ID=" + apply_model.ID + "','','dialogWidth=726px;dialogHeight=400px');\" target='_self'  title='印章申请审核'>" + Session["SignetName"] + "  数量  " + Session["Signet_Nums"] + "  " + flag + "</a>  " + Session["Signet_ApplyUserName"];

                mFaceShowMessage.DELFLAG = 0;
                mFaceShowMessage.ProjectID = apply_model.ProjectID; 
                bFaceShowMessage.Add(mFaceShowMessage);
                //给业务申请者发信息


                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "&Status=" + Request["Status"] + "\";</script>";


                Response.Write(coutws);

                //添加操作日志

                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "申请管理", "用印申请审核" + flag + "：成功！");

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
                    mDocumentfile.FileName = "用印上传的文件." + types;
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

