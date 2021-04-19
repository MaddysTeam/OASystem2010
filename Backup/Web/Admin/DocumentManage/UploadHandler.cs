using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.SessionState;
using System.IO;

namespace Dianda.Web.Admin.DocumentManage
{
   
    /// <summary>
    /// 上传文件处理程序
    /// </summary>
    public class UploadHandler : IHttpHandler, IRequiresSessionState
    {

        #region IHttpHandler 成员

        public bool IsReusable
        {
            get { return true; }
        }
        COMMON.common commons = new Dianda.COMMON.common();
        BLL.Document_File bdfile = new Dianda.BLL.Document_File();//加载文件的操作类
        Model.Document_File mdfile = new Dianda.Model.Document_File();
        COMMON.fileUploads fileupload = new Dianda.COMMON.fileUploads();

        public void ProcessRequest(HttpContext context)
        {
            //文件上传存储路径
            string uploadPath = context.Server.MapPath(context.Request.ApplicationPath + "/AllFileUp/Documents/private");
            //调用栏目信息和用户ID
            Web.Admin.DocumentManage.uploadfiles uploaddo = new Dianda.Web.Admin.DocumentManage.uploadfiles();
            string uid = uploaddo.Session["upload_session_users"].ToString();
            string cloumns = uploaddo.Session["upload_session_cloumns"].ToString();
   
            if (uid != null && cloumns != null)
            {
                for (int i = 0; i < context.Request.Files.Count; i++)
                {
                    HttpPostedFile uploadFile = context.Request.Files[i];
                    if (uploadFile.ContentLength > 0)
                    {
                        string fileName = uploadFile.FileName;//获取初始的文件名
                        string[] filearray = fileName.Split('\\');

                        int J = fileName.LastIndexOf(".");//取得文件名中最后一个"."的索引
                        string fileType = fileName.Substring(J);//获取文件扩展名
                        string filesizes = uploadFile.ContentLength.ToString();//文件的大小
                        string[] filenames = fileName.Split('.');

                        string filename_1 = filenames[0].ToString() + "_" + commons.TodayToMS() + "_" + filesizes + fileType;//重新为文件命名,时间毫秒部分+文件大小+扩展名  
                        string FlieUrls = "/AllFileUp/Documents/private/" + filename_1;

                        uploadFile.SaveAs(Path.Combine(uploadPath, filename_1));

                        mdfile.DATETIME = DateTime.Now;
                        mdfile.DELFLAG = 0;
                        string[] filenamesarray = fileName.Split('.');

                        mdfile.FileName = filenamesarray[0].ToString();
                        mdfile.FilePath = FlieUrls;
                        mdfile.FileType = fileType.Substring(1, fileType.Length - 1);
                        mdfile.FolderID = int.Parse(cloumns);
                        mdfile.Icon = mdfile.FileType;
                        mdfile.IsShare = 0;
                        mdfile.Sizeof =decimal.Parse(fileupload.sizeChange_B_K(filesizes));
                        mdfile.UserID = uid;
                        bdfile.Add(mdfile);
                    }
                }

                HttpContext.Current.Response.Write("OK");
            }
            else
            {
                HttpContext.Current.Response.Write("请选择栏目！");
            }
        }

        #endregion
    }
}