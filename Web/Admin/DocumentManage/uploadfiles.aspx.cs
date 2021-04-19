using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class uploadfiles : System.Web.UI.Page
    {
        COMMON.fileUploads cfup = new Dianda.COMMON.fileUploads();//通用上传判断
        Model.USER_Users user_model = new Dianda.Model.USER_Users();
        BLL.Document_FolderExt bdFExt = new Dianda.BLL.Document_FolderExt();
        COMMON.common commons = new Dianda.COMMON.common();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string projectid = "";
                    if (Session["Work_ProjectId"] != null)
                    {
                        projectid = Session["Work_ProjectId"].ToString();
                        projectControl1.Visible = true;
                    }
                    else
                    {
                        projectControl1.Visible = false;
                    }

                    string filetypes = cfup.getAllowFileType();//获取支持上传的文件的类型
                    //FlashUpLoad1.FileTypes = cfup.getAllowFileType_Up();
                    //FlashUpLoad1.FileTypeDescription = filetypes;
                    Label_type.Text = filetypes;

                    string tp = Request["tp"];//url传值过来的页卡参数
                    string url = "";
                    if (tp == "" || tp == null || tp == "0")
                    {
                        url = "文档 > 我的文档 > 添加文件";
                    }
                    if (tp == "1")
                    {
                        if (Session["Work_ProjectId"] != null)
                        {
                            url = "项目 > 我的项目 > 项目文档 > 添加文件";
                        }
                        else
                        {
                            url = "文档 > 项目文档 > 添加文件";
                        }
                    }
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = url;
                    //设置模板页中的管理值
                    user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                    showuserColumns(user_model.ID.ToString(), tp, projectid);
                    Session["upload_session_users"]= user_model.ID.ToString();
                    Session["upload_session_cloumns"] = DropDownList_upid.SelectedValue.ToString();
                    chushihua();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_Click(object sender, EventArgs e)
        {
            string tp = Request["tp"];//url传值过来的页卡参数
            Response.Redirect(urls());
        }
        /// <summary>
        /// 获取返回时的地址
        /// </summary>
        /// <returns></returns>
        public string urls()
        {
            string coutw = "";
            try
            {
                //通过文件的ID获取到文件夹的ID
      
                    string tp = Request["tp"];//url传值过来的页卡参数
                    string FID =DropDownList_upid.SelectedValue.ToString();
                    FID = commons.RequestSafeString(FID, 50);
                    coutw = "manage.aspx?CID=" + bdFExt.getFolderPathById(FID) + "&tp=" + tp;
                
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 根据用户的ID，获取到这个自己的所有的
        /// </summary>
        /// <param name="userid"></param>
        private void showuserColumns(string userid, string tp, string projectid)
        {
            try
            {
                string upid = Request["upid"];//获取到当前是给那个文件夹上传文件。默认的情况下，是将这个文件夹目录选中
                DataTable DT = new DataTable();
                if (tp == "0" || tp == "" || tp == null)
                {
                    DT = bdFExt.makeFolder(userid, "private", "");//获取自己的档案目录的数据
                }
                else if (tp == "1")
                {
                    DT = bdFExt.makeFolder_droplist(userid, "public", projectid);//获取自己的档案目录的数据 
                }



                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        string parentid = DT.Rows[i]["UpID"].ToString();
                        string path = DT.Rows[i]["COLUMNSPATH"].ToString();
                        string projectid2 = DT.Rows[i]["projectid"].ToString();
                        string Types = DT.Rows[i]["Types"].ToString();
                        string statusName = "";
                        if (Types == "public")
                        {
                            string status = DT.Rows[i]["status"].ToString();
                            string UpID = DT.Rows[i]["UpID"].ToString();
                            if (UpID == "38")
                            {
                                if (status == "3")
                                {
                                    statusName = "[暂停]";
                                }
                                else if (status == "5")
                                {
                                    statusName = "[完成]";
                                }
                                else
                                {
                                    statusName = "";
                                }
                            }

                        }
                        if (parentid != "0")
                        {
                            string kg = null;
                            int lens = path.Split('/').Length;
                            for (int x = 0; x < lens; x++)
                            {
                                kg += "··";
                            }
                            DT.Rows[i]["FolderName"] = kg + "|--" + DT.Rows[i]["FolderName"].ToString() + statusName;
                        }
                        ListItem L1 = new ListItem();
                        L1.Text = DT.Rows[i]["FolderName"].ToString();
                        L1.Value = DT.Rows[i]["ID"].ToString();
                         DropDownList_upid.Items.Add(L1);
                  
                    }
                    uploada.Visible = true;
                    if (upid != null || upid != "")
                    {
                        DropDownList_upid.SelectedValue = upid;
                    }
                }
                else
                {
                    DropDownList_upid.Visible = false;
                    uploada.Visible = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 获取到当前的栏目和用户的ID
        /// </summary>
        /// <returns></returns>
        public string[] getColumnAndUserID()
        {
            string[] coutw = {"","" };
            try
            {
                coutw[0] =this.DropDownList_upid.SelectedValue.ToString();
                coutw[1] = this.HiddenField_uid.Value.ToString();
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 构造一个栏目的SESSION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_upid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chushihua();
                Session["upload_session_cloumns"] = DropDownList_upid.SelectedValue.ToString();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void chushihua()
        {
            string upid = DropDownList_upid.SelectedValue.ToString();
            if (upid == "38")
            {
                Label_notice2.Visible = true;
                uploada.Visible = false;
            }
            else
            {
                Label_notice2.Visible = false;
                uploada.Visible = true;
            }
        }
        
    }
}
