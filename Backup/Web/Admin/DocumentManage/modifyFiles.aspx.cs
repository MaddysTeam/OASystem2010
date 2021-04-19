using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class modifyFiles : System.Web.UI.Page
    {
        Model.USER_Users user_model = new Dianda.Model.USER_Users();
        Model.Document_Folder mdf = new Dianda.Model.Document_Folder();
        BLL.Document_Folder bdf = new Dianda.BLL.Document_Folder();
        BLL.Document_FolderExt bdFExt = new Dianda.BLL.Document_FolderExt();
        Model.Document_Folder mdf2 = new Dianda.Model.Document_Folder();
        COMMON.common commons = new Dianda.COMMON.common();

        BLL.Document_File bdfile = new Dianda.BLL.Document_File();//加载文件的操作类
        Model.Document_File mdfile = new Dianda.Model.Document_File();


        COMMON.fileUploads cfup = new Dianda.COMMON.fileUploads();//通用上传判断

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
                    }

                    string tp = Request["tp"];//url传值过来的页卡参数
                    string url = "";
                    if (tp == "" || tp == null || tp == "0")
                    {
                        url = "文档 > 我的文档 > 编辑文件";
                    }
                    if (tp == "1")
                    {
                        if (Session["Work_ProjectId"] != null)
                        {
                            url = "项目 > 我的项目 > 项目文档 > 编辑文件";
                        }
                        else
                        {
                            url = "文档 > 项目文档 > 编辑文件";
                        }
                    }
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = url;
                    //设置模板页中的管理值
                    string FID = Request["ID"];//url传值过来的参数
                    showInfo(FID, tp, projectid);
                    Label_filetype.Text = cfup.getAllowFileType();//获取当前系统中可以上传的文件的类型
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据文件夹的ID，获取到该文件夹的基本属性
        /// </summary>
        /// <param name="FID">文件的ID</param>
        private void showInfo(string FID, string tp, string projectid)
        {
            try
            {
                FID = commons.RequestSafeString(FID, 50);
                //根据文件ID获取到
                mdfile = bdfile.GetModel(int.Parse(FID));

                TextBox_FolderName.Text = mdfile.FileName.ToString();
                showuserColumns(mdfile.UserID.ToString(), tp, projectid);//加载栏目的结构
                DropDownList_upid.SelectedValue = mdfile.FolderID.ToString();
                showbuttom(mdfile.UserID.ToString());

                HiddenField_oldpath.Value = mdfile.FilePath.ToString();//老的文件的地址
                HiddenField_pid.Value = mdfile.FolderID.ToString();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 提交编辑目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string FID = Request["ID"];//url传值过来的参数
                string tp = Request["tp"];//url传值过来的页卡参数
                user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                FID = commons.RequestSafeString(FID, 50);
                mdfile = bdfile.GetModel(int.Parse(FID));
                mdfile.DATETIME = DateTime.Now;
                mdfile.FileName = TextBox_FolderName.Text.ToString();
                mdfile.FolderID = int.Parse(DropDownList_upid.SelectedItem.Value.ToString());//获取到新的父栏目的ID

                HiddenField_pid.Value = DropDownList_upid.SelectedItem.Value.ToString();
                string alertnotice = "";
                string urls1 = "";//要操作的地址

                //下面进行上传操作
                if (FileUpload1.FileName.Length > 2)
                {
                    //尝试去上传文件
                    string[] files = cfup.UpFile_COMMONS(FileUpload1, "/AllFileUp/Documents/private", HiddenField_oldpath.Value.ToString());
                    //1-成功；0-失败；2-类型不支持；3-大小不符合;文件的路径；文件名称；文件类型；图标；大小；操作结果
                    if (files[0].ToString() == "1")//成功的
                    {
                        urls1 = urls();//返回列表

                        mdfile.FilePath = files[1].ToString();
                        mdfile.FileType = files[3].ToString();
                        mdfile.Icon = files[4].ToString();
                        mdfile.Sizeof =int.Parse(files[5].ToString());
                    }
                    else
                    {
                        urls1 = Request.RawUrl;//留在本页面
                    }
                    alertnotice = files[6].ToString();//操作的提示
                }
                else
                {
                    urls1 = urls();//返回列表
                    alertnotice = "基本信息修改成功";
                    //没有要上传的数据，就不做上传
                }
                //下面进行上传操作

                bdfile.Update(mdfile);

                //写日志
                BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理编辑文件", "编辑" + TextBox_FolderName.Text.ToString() + ":" + alertnotice + "");
                //写日志
                Button_sumbit.Enabled = false;
                Button_sumbit.Visible = false;

                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"" + alertnotice + "！\");location.href='" + urls1 + "';</script>";
                Response.Write(coutws);
            }
            catch
            {
                Button_sumbit.Enabled = false;
                Button_sumbit.Visible = false;
            }
        }
        /// <summary>
        /// 根据当期用户的权限，判断该用户是否能继续添加了
        /// </summary>
        /// <param name="userid"></param>
        private void showbuttom(string userid)
        {
            try
            {
                user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                if (user_model.ID.ToString() == userid)
                {
                    Button_sumbit.Enabled = true;
                    Button_sumbit.Visible = true;
                }
                else
                {
                    Button_sumbit.Enabled = false;
                    Button_sumbit.Visible = false;
                }
            }
            catch
            {
                Button_sumbit.Enabled = false;
                Button_sumbit.Visible = false;
            }
        }

        /// <summary>
        /// 根据用户的ID，获取到这个自己的所有的
        /// </summary>
        /// <param name="userid"></param>
        private void showuserColumns(string userid,string tp,string projectid)
        {
            try
            {
                DataTable DT = new DataTable();
                if (tp == "0" || tp == "" || tp == null)
                {
                    DT = bdFExt.makeFolder(userid, "private", "");//获取自己的档案目录的数据
                }
                else if (tp == "1")
                {
                    DT = bdFExt.makeFolder(userid, "public", projectid);//获取自己的档案目录的数据
                }

                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        string parentid = DT.Rows[i]["UpID"].ToString();
                        string path = DT.Rows[i]["COLUMNSPATH"].ToString();
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
        public void Button_reset_Click(object sender, EventArgs e)
        {
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
                string tp = Request["tp"];//url传值过来的页卡参数
                string FID = HiddenField_pid.Value.ToString();//url传值过来的参数
                FID = commons.RequestSafeString(FID, 50);
                coutw = "manage.aspx?CID=" + bdFExt.getFolderPathById(FID)+"&tp="+tp;
            }
            catch
            {
            }
            return coutw;
        }
    }
}
