using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Reflection;
namespace Dianda.Web.Admin.sysTongji.ascxModel
{
    public partial class downloads : System.Web.UI.UserControl
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
        COMMON.ZipFloClass zips = new Dianda.COMMON.ZipFloClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                { 
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 外界控制函数
        /// </summary>
        /// <param name="foldid"></param>
        /// <param name="fileid"></param>
        public void downloadscontrols(string foldid, string fileid)
        {
            try
            {
                fileslist1.ShowFoldes(foldid, fileid);
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
               
                //1先获取到要删除的内容的数据集合
                string[] dolist = fileslist1.GetDeleteList();//第一个是文件夹、第二个是文件(这边只操作文件的东西)'

                if (dolist[1] != "0")
                {
                    user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                    //打包下载所有的文件
                    string sqlin = commons.makeSqlIn(dolist[1].ToString(), ';');
                    string sqlinfolderid = commons.makeSqlIn(dolist[0].ToString(), ';');
                    string sqlinfileid = commons.makeSqlIn(dolist[1].ToString(), ';');
                    string filetopurl = System.Configuration.ConfigurationManager.AppSettings["FTPURLS"];
                    DateTime dts = DateTime.Now;
                    filetopurl = filetopurl + user_model.USERNAME.ToString() + "/" + dts.Year.ToString() + dts.Month.ToString() + dts.Day.ToString() + dts.Hour.ToString() + dts.Minute.ToString() + dts.Second.ToString() + "/";
                    string zipfoldername = filetopurl.Substring(0, filetopurl.Length - 1) + ".zip";
                    bdFExt.makeFolderByFolderID(filetopurl, sqlinfolderid);//构建目录结构
                    bdFExt.copyFilesToNewFolder(filetopurl, sqlinfileid);//构建文件的结构
                    //doFileTransfer(dolist[1].ToString());//调用创建新文件的方法
                    // zips.ZipFile(filetopurl, zipfoldername);
                    //zips.CreateZIPFile(filetopurl,100);
                    //写日志
                    BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                    bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理批量下载", "归档成功");
                    //写日志
                    Label_notice.Text = "*操作完成！";
                    Button_sumbit.Enabled = false;
                }
                else
                {
                    Label_notice.Text = "*没有可以归档的文件！";
                    Button_sumbit.Enabled = false;
                }
            }

            catch
            {
                Label_notice.Text = "*发送错误，请重新操作！";
                Button_sumbit.Enabled = true;
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
            Page p = this.Parent.Page;
            Type pageType = p.GetType();
            MethodInfo mi = pageType.GetMethod("controls_Show");
            mi.Invoke(p, new object[] { "docmain" });
        }
    }
}
