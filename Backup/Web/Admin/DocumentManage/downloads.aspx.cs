using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class downloads : System.Web.UI.Page
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
                        url = "文档 > 我的文档 > 批量下载";
                    }
                    if (tp == "1")
                    {
                        if (Session["Work_ProjectId"] != null)
                        {
                            url = "项目 > 我的项目 > 项目文档 > 批量下载";
                        }
                        else
                        {
                            url = "文档 > 项目文档 > 批量下载";
                        }
                    }
                    if (tp == "2")
                    {
                        url = "文档 > 共享文档 > 批量下载";
                    }
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = url;
                    //设置模板页中的管理值
                    string folderlist = Request["foldeid"];
                    string fileid = Request["fileid"];
                    fileslist1.ShowFoldes(folderlist, fileid);

                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 进行批量下载操作
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
                    CID = "&CID=" + Request["CID"];
                }
                //1先获取到要删除的内容的数据集合
                string[] dolist = fileslist1.GetDeleteList();//第一个是文件夹、第二个是文件(这边只操作文件的东西)'

                if (dolist[1] != "0")
                {
                    user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                    //打包下载所有的文件
                    string sqlin = commons.makeSqlIn(dolist[1].ToString(), ';');
                    doFileTransfer(dolist[1].ToString());//调用创建新文件的方法

                    //写日志
                    BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                    bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理批量下载", "批量下载成功");
                    //写日志
                }

                //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?tp=" + tp + CID + "\";</script>";
                //Response.Write(coutws);
            }

            catch
            {
            }
        }

        /// <summary>
        /// 将老目录下的文件都拷贝到新的目录下
        /// </summary>
        /// <param name="oldfid">老目录的ID</param>
        /// <param name="newfid">新的目录的ID</param>
        /// <param name="userid">收藏的用户ID</param>
        private void doFileTransfer(string fileids)
        {
            try
            {
                string sqlin = commons.makeSqlIn(fileids, ';');
                List<Model.Document_File> mdflist = bdfile.GetModelList(" ID in " + sqlin + " and delflag='0'");
                if (mdflist.Count > 0)
                {
                    List<string> files = new List<string>();
                    for (int i = 0; i < mdflist.Count; i++)
                    {
                        string oldfilepath = mdflist[i].FilePath.ToString();
                        //先判断当前文件是否存在
                        if (File.Exists(this.Server.MapPath(oldfilepath)))
                        {
                            //将文件打包下载
                            files.Add(oldfilepath);
                        }
                    }
                    DateTime dts = DateTime.Now;
                    string filenames = dts.Year.ToString() + "_" + dts.Month.ToString() + "_" + dts.Day.ToString() + ".zip";
                    Download(files, filenames);
                }
            }
            catch
            {
            }
        }
        private void Download(IEnumerable<string> files, string zipFileName)
        {
            try
            {
                //根据所选文件打包下载
                MemoryStream ms = new MemoryStream();
                byte[] buffer = null;

                using (ZipFile file = ZipFile.Create(ms))
                {
                    file.BeginUpdate();
                    file.NameTransform = new MyNameTransfom();//通过这个名称格式化器，可以将里面的文件名进行一些处理。默认情况下，会自动根据文件的路径在zip中创建有关的文件夹。

                    foreach (var item in files)
                    {
                        file.Add(Server.MapPath(string.Format("~{0}", item)));
                    }


                    file.CommitUpdate();

                    buffer = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(buffer, 0, buffer.Length);
                }


                Response.AddHeader("content-disposition", "attachment;filename=" + zipFileName);
                Response.BinaryWrite(buffer);
                Response.Flush();
                Response.End();
            }
            catch
            {
                MessageBox.Show(Page, "对不起，您选择的文件过大，请尝试多次下载");
            }

        }
        public class MyNameTransfom : ICSharpCode.SharpZipLib.Core.INameTransform
        {

            #region INameTransform 成员

            public string TransformDirectory(string name)
            {
                return null;
            }

            public string TransformFile(string name)
            {
                return Path.GetFileName(name);
            }

            #endregion
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
                if (arrays.Length > 0 && arrays[0].Length > 0)
                {
                    mdfile = bdfile.GetModel(int.Parse(arrays[0].ToString()));
                    string tp = Request["tp"];//url传值过来的页卡参数
                    string FID = mdfile.FolderID.ToString();// HiddenField_pid.Value.ToString();//url传值过来的参数
                    FID = commons.RequestSafeString(FID, 50);
                    coutw = "manage.aspx?CID=" + bdFExt.getFolderPathById(FID) + "&tp=" + tp;
                }
                else
                {
                    if (arrays2.Length > 0 && arrays2[0].Length > 0)
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
