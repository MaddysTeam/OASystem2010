using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class transfer : System.Web.UI.Page
    {
        COMMON.common commons = new Dianda.COMMON.common();
        COMMON.pageControl pagdosql = new Dianda.COMMON.pageControl();
        Model.USER_Users user_model = new Dianda.Model.USER_Users();
        BLL.Document_FolderExt bdFExt = new Dianda.BLL.Document_FolderExt();
        Model.Document_Folder mdf = new Dianda.Model.Document_Folder();
        BLL.Document_Folder bdf = new Dianda.BLL.Document_Folder();

        BLL.Document_File bdfile = new Dianda.BLL.Document_File();
        Model.Document_File mdfile = new Dianda.Model.Document_File();

        COMMON.fileUploads cfup = new Dianda.COMMON.fileUploads();

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
                    string tp = Request["tp"];//url传值过来的页卡参数
                    string url = "";
                    if (tp == "" || tp == null || tp == "0")
                    {
                        url = "文档 > 我的文档 > 收藏";
                    }
                    if (tp == "1")
                    {
                        if (Session["Work_ProjectId"] != null)
                        {
                            url = "项目 > 我的项目 > 项目文档 > 收藏";
                        }
                        else
                        {
                            url = "文档 > 项目文档 > 收藏";
                        }
                    }
                    if (tp == "2")
                    {
                        url = "文档 > 共享文档 > 收藏";
                    }
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = url;
                    //设置模板页中的管理值
                    string folderlist = Request["foldeid"];
                    string fileid = Request["fileid"];
                    fileslist1.ShowFoldes(folderlist, fileid);
                    fileslist1.isShowFolderList(false);
                    user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                    showuserColumns(user_model.ID.ToString(),"0");
                    if (fileslist1.getFileListnum()== 0)
                    {
                        Button_sumbit.Visible = false;
                        Label_notices.Text = "您所选择的数据中，没有可以收藏的文件！";
                    }
                    else
                    {
                        Button_sumbit.Visible = true;
                        Label_notices.Text = "";
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 根据用户的ID，获取到这个自己的所有的
        /// </summary>
        /// <param name="userid"></param>
        private void showuserColumns(string userid, string tp)
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
                    DT = bdFExt.makeFolder(userid, "public", "0");//获取自己的档案目录的数据
                }



                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        string parentid = DT.Rows[i]["UpID"].ToString();
                        string path = DT.Rows[i]["COLUMNSPATH"].ToString();
                        if (parentid != "0")
                        {
                            string kg = null;
                            int lens = path.Split('/').Length;
                            for (int x = 0; x < lens; x++)
                            {
                                kg += "··";
                            }
                            DT.Rows[i]["FolderName"] = kg + "|--" + DT.Rows[i]["FolderName"].ToString();
                        }
                        ListItem L1 = new ListItem();
                        L1.Text = DT.Rows[i]["FolderName"].ToString();
                        L1.Value = DT.Rows[i]["ID"].ToString();
                        DropDownList_upid.Items.Add(L1);
                    }
                    Button_sumbit.Visible = true;
                }
                else
                {
                    DropDownList_upid.Visible = false;
                    Button_sumbit.Visible = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 进行收藏操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
              
                string tp = Request["tp"];//url传值过来的页卡参数
                string CID = "";
                if (tp == "2")
                {
                    CID ="&CID="+Request["CID"];
                }
                //1先获取到要删除的内容的数据集合
                string[] dolist = fileslist1.GetDeleteList();//第一个是文件夹、第二个是文件(这边只操作文件的东西)'
                string newfoldid=DropDownList_upid.SelectedValue.ToString();//新栏目的ID
                if (dolist[1] != "0")
                {
                    user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                    //复制所有的文件
                    string sqlin = commons.makeSqlIn(dolist[1].ToString(), ';');
                    doFileTransfer(dolist[1].ToString(), newfoldid, user_model.ID.ToString());//调用创建新文件的方法

                    //写日志
                    BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                    bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理收藏文件", "收藏文件成功");
                    //写日志
                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！请查看收藏结果！\");</script>";
                    Response.Write(coutws);
                    fileslist1.Visible = false;
                    Button_sumbit.Visible = false;
                }
                else
                {
                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您所选择的数据中，没有可以收藏的文件！\");</script>";
                    Response.Write(coutws);
                }
              
            }

            catch
            {
                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作失败！请联系管理员检查权限！\");</script>";
                Response.Write(coutws);
            }
        }
     
        /// <summary>
        /// 将老目录下的文件都拷贝到新的目录下
        /// </summary>
        /// <param name="oldfid">老目录的ID</param>
        /// <param name="newfid">新的目录的ID</param>
        /// <param name="userid">收藏的用户ID</param>
        private void doFileTransfer(string fileids, string newfoldid,string userid)
        {
            try
            {
                string sqlin = commons.makeSqlIn(fileids, ';');
                List<Model.Document_File> mdflist = bdfile.GetModelList(" ID in "+sqlin+" and delflag='0'");
                string dosuccess = "";//操作成功的
                string dofalse = "";//操作失败的
                if (mdflist.Count > 0)
                {
                    for (int i = 0; i < mdflist.Count; i++)
                    {
                        string oldfilepath = mdflist[i].FilePath.ToString();
                        if (oldfilepath.Contains("."))
                        {
                            string[] arras = oldfilepath.Split('.');
                            string[] arrasname = arras[0].Split('/');
                            string oldname = arrasname[arrasname.Length - 1];
                          
                            DateTime relese_time_1 = DateTime.Now;

                            string filename_1 =userid+"_"+oldname;//当前用户的基本信息加上文件的原始名称
                            string newfilepath = oldfilepath.Replace(oldname, filename_1);

                            if (!isHave(newfilepath, userid))
                            {
                                dosuccess = dosuccess + "<br><br>" + mdflist[i].FileName + "&nbsp;&nbsp;收藏成功！";
                                cfup.CopyFiles(oldfilepath, newfilepath);//复制
                                mdfile.FilePath = newfilepath;

                                mdfile.DATETIME = DateTime.Now;
                                mdfile.DELFLAG = 0;
                                mdfile.FileName = mdflist[i].FileName;

                                mdfile.FileType = mdflist[i].FileType;
                                mdfile.FolderID = int.Parse(newfoldid);
                                mdfile.Icon = mdflist[i].Icon;
                                mdfile.IsShare = 0;
                                mdfile.Sizeof = mdflist[i].Sizeof;
                                mdfile.UserID = userid;
                                mdfile.ShareID = mdflist[i].ID;//保留资源最先的ID

                                bdfile.Add(mdfile);
                            }
                            else
                            {
                                dofalse = dofalse + "<br><br>" + mdflist[i].FileName + "&nbsp;&nbsp;您之前已经收藏过，当前收藏失败！";
                            }
                        }

                     
                    }
                    Label_notices.Text = dosuccess + "<br><br>" + dofalse;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 返回刚才的列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_Click(object sender, EventArgs e)
        {
            //string tp = Request["tp"];//url传值过来的页卡参数
            //string CID = "";
            //if (tp == "2")
            //{
            //    CID = "&CID=" + Request["CID"];
            //}
            //string coutws = "<script language=\"javascript\" type=\"text/javascript\">location.href = \"manage.aspx?tp=" + tp + CID + "\";</script>";
            Response.Redirect(urls());
        }
        /// <summary>
        /// 检查当前用户有没有该文件，如果有则返回true,如果没有则返回false
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        private bool isHave(string filePath, string userid)
        {
            bool coutw = false;
            try
            {
                List<Model.Document_File> mdflist = bdfile.GetModelList(" FilePath='" + filePath + "' and UserID='" + userid + "' and DELFLAG='0'");
                if (mdflist.Count > 0)
                {
                    coutw = true;
                }
                else
                {
                    coutw = false;
                }
            }
            catch
            {
            }
            return coutw;
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
                string fileid = Request["fileid"];
                string foldeid = Request["foldeid"];
                string[] arrays = fileid.Split(';');
                string[] arrays2 = foldeid.Split(';');
                //通过文件的ID获取到文件夹的ID
                if (arrays.Length > 0 && arrays[0].Length>0)
                {
                    mdfile = bdfile.GetModel(int.Parse(arrays[0].ToString()));
                    string tp = Request["tp"];//url传值过来的页卡参数
                    string FID = mdfile.FolderID.ToString();// HiddenField_pid.Value.ToString();//url传值过来的参数
                    FID = commons.RequestSafeString(FID, 50);
                    coutw = "manage.aspx?CID=" + bdFExt.getFolderPathById(FID) + "&tp=" + tp;
                }
                else
                {
                    if (arrays2.Length > 0 && arrays2[0].Length>0)
                    {
                        mdf = bdf.GetModel(int.Parse(arrays2[0].ToString()));
                        string tp = Request["tp"];//url传值过来的页卡参数
                        string FID = mdf.UpID.ToString();// HiddenField_pid.Value.ToString();//url传值过来的参数
                        FID = commons.RequestSafeString(FID, 50);
                        coutw = "manage.aspx?CID=" + bdFExt.getFolderPathById(FID) + "&tp=" + tp;
                    }
                    else
                    {
                        string tp = Request["tp"];//url传值过来的页卡参数
                        string CID = "";
                        if (tp == "2")
                        {
                            CID = "&CID=" + Request["CID"];
                        }
                        coutw = "manage.aspx?tp=" + tp + CID;
                        //string coutws = "<script language=\"javascript\" type=\"text/javascript\">location.href = \"manage.aspx?tp=" + tp + CID + "\";</script>";
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
