using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.IO;
using System.Data.OleDb;
 
//引用命名空间
using System.Xml;

namespace Dianda.COMMON
{
    public class FileControl
    {
        /// <summary>
        /// 创建一个xml文件name:文件的名称；files:初始化内容；paths：文件保存的路径
        /// </summary>

        public bool CreatXML(string name, string files, string Paths)
        {
            // return HttpContext.Current.Server.MapPath(xmlFile);
            try
            {
                StreamWriter sw = File.AppendText(Paths + "\\" + name);
                sw.WriteLine(files);
                sw.Flush();
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        ///课件系统，购物系统的文件删除函数
        /// </summary>

        public bool DELFile_Paths(string Paths)
        {

            string pathss = Paths.Replace('/', '\\');
            pathss = HttpContext.Current.Server.MapPath(pathss);
            try
            {

                if (File.Exists(pathss))
                {

                    File.Delete(pathss);
                }

                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 删除文件
        /// </summary>

        public bool DELFile(string Paths)
        {

            try
            {

                if (File.Exists(Paths))
                {

                    File.Delete(Paths);
                }

                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 判断文件夹是否存在:rss/news/2212121212121
        /// </summary>

        public bool JUDGEFOLDER(string NAMES)
        {

            try
            {

                if (Directory.Exists(NAMES))
                {

                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 创建新的文件夹：names:xxx/ddd/ddd
        /// </summary>

        public bool CREATFOLDER(string NAMES)
        {

            try
            {

                if (Directory.Exists(NAMES))
                {

                    return true;
                }

                else
                {
                    Directory.CreateDirectory(NAMES);
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }


        /// <summary>
        /// 递归删除文件夹及文件：dir:xxx/ddd/ddd
        /// </summary>
        public bool DeleteFolder(string dir)
        {
            try
            {

                if (Directory.Exists(dir)) //如果存在这个文件夹删除之 
                {
                    foreach (string d in Directory.GetFileSystemEntries(dir))
                    {
                        if (File.Exists(d))
                            File.Delete(d); //直接删除其中的文件 
                        else
                            DeleteFolder(d); //递归删除子文件夹 
                    }
                    Directory.Delete(dir); //删除已空文件夹 
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取上传文件的大小
        /// 带入限定的文件大小size(M)
        /// 符合限定大小时，返回文件的大小
        /// 返回0表示该文件不能上传
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        public string fileSize(FileUpload FilePath, int Size)
        {
            string coutw = "0";//0表示失败；1表示成功；3表示文件格式不对
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    int fileSizes = FilePath.PostedFile.ContentLength;
                    if (Size * 1024 * 1024 - fileSizes >= 0)
                    {
                        if (fileSizes > 1024 * 1024)
                        {
                            coutw = Convert.ToString(fileSizes / 1024 / 1024) + "MB";
                        }
                        else if (fileSizes > 1024)
                        {
                            coutw = Convert.ToString(fileSizes / 1024) + "KB";
                        }
                        else
                        {
                            coutw = Convert.ToString(fileSizes) + "B";
                        }
                    }
                    else
                    {
                        coutw = null;
                    }
                }
                else
                {
                    coutw = null;
                }

            }
            catch
            {
                coutw = null;
            }
            return coutw;
        }

        /// <summary>
        /// 获取文件扩展名的函数
        /// 返回0表示该文件不合法
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public string fileType(FileUpload FilePath)
        {
            string coutw = "0";//0表示失败；1表示成功；3表示文件格式不对
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//获取初始的文件名
                    int i = fileName.LastIndexOf(".");//取得文件名中最后一个"."的索引
                    string fileType = fileName.Substring(i);//获取文件扩展名
                    coutw = fileType;
                }
                else
                {
                    coutw = "0";
                }

            }
            catch
            {
                coutw = "0";
            }
            return coutw;
        }
        /// <summary>
        /// 上传文件到服务器的类文件
        /// FilePath为待上传文件的全称
        /// FloderName为目标文件夹
        /// Type为文件的类型
        ///0表示失败;文件名表示成功,3表示文件不符合格式要求
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FloderName"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public string UpFile(FileUpload FilePath, string FloderName)//上传文件的类
        {
            string coutw = "0";//0表示失败；1表示成功；3表示文件格式不对
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//获取初始的文件名
                    int i = fileName.LastIndexOf(".");//取得文件名中最后一个"."的索引
                    string fileType = fileName.Substring(i);//获取文件扩展名
                    DateTime relese_time_1 = DateTime.Now;
                    string filename_1 =relese_time_1.Year.ToString()+relese_time_1.Month.ToString()+relese_time_1.Day.ToString()+relese_time_1.Hour.ToString()+relese_time_1.Minute.ToString()+relese_time_1.Second.ToString() + "_" + relese_time_1.Millisecond.ToString() + "_" + FilePath.PostedFile.ContentLength.ToString() + fileType;//重新为文件命名,时间毫秒部分+文件大小+扩展名  
                    string FlieUrls = FloderName + "/" + filename_1;

                    if (checkType(fileType))//如果该文件是图片文件
                    { //上传该文件
                        if (UPFileDO(FlieUrls, FilePath))
                        {
                            coutw = FlieUrls;
                        }
                        else
                        {
                            coutw = "0";
                        }
                    }
                    else if (!checkType(fileType))
                    {
                        coutw = "3";
                    }
                }
                else
                {
                    coutw = "0";
                }

            }
            catch
            {
                coutw = "0";
            }
            return coutw;
        }
      /// <summary>
        /// 通用的文件上传组件[fileTypeSet=IMAGE 表示图片，包括：gif,jpe,jpeg,png,bmp格式；fileTypeSet=COMMONS 表示通用非可执行文件，包括：.ppt，.rar，.zip，.gif，.jpg，.jpeg，.bmp，.png，.doc，.xls，.txt，.docx，.xlsx，.swf，.wmv，.rm，.wma]
      /// </summary>
      /// <param name="FilePath">上传控件</param>
      /// <param name="FloderName">要上传到的文件夹地址</param>
      /// <param name="fileType">文件的类型</param>
      /// <returns>返回：字符串长度大于2表示上传成功，并且这个返回值即为上传文件的路径地址；返回0，表示上传失败；3表示文件格式不符合要求；</returns>
        public string UpFile_COMMONS(FileUpload FilePath, string FloderName,string fileTypeSet)//上传文件的类
        {
            string coutw = "0";//0表示失败；1表示成功；3表示文件格式不对
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//获取初始的文件名
                    int i = fileName.LastIndexOf(".");//取得文件名中最后一个"."的索引
                    string fileType = fileName.Substring(i);//获取文件扩展名
                    DateTime relese_time_1 = DateTime.Now;
                    string filename_1 = relese_time_1.Year.ToString() + relese_time_1.Month.ToString() + relese_time_1.Day.ToString() + relese_time_1.Hour.ToString() + relese_time_1.Minute.ToString() + relese_time_1.Second.ToString() + "_" + relese_time_1.Millisecond.ToString() + "_" + FilePath.PostedFile.ContentLength.ToString() + fileType;//重新为文件命名,时间毫秒部分+文件大小+扩展名  
                    string FlieUrls = FloderName + "/" + filename_1;
                    bool isAccept = false;//该类型的文件是否允许上传

                    if (fileTypeSet == "IMAGE")//图片的上传
                    {
                        isAccept = checkType_IMAGE(fileType);
                    }
                    if (fileTypeSet == "COMMONS")//通用的类型检测
                    {
                        isAccept = checkType(fileType);
                    }

                    if (isAccept)//如果符合上传要求
                    { //上传该文件
                        if (UPFileDO(FlieUrls, FilePath))
                        {
                            coutw = FlieUrls;
                        }
                        else
                        {
                            coutw = "0";
                        }
                    }
                    else if (!isAccept)
                    {
                        coutw = "3";
                    }
                }
                else
                {
                    coutw = "0";
                }

            }
            catch
            {
                coutw = "0";
            }
            return coutw;
        }
        /// <summary>
        /// 上传文件到服务器的类文件(JPG文件)
        /// FilePath为待上传文件的全称
        /// FloderName为目标文件夹
        ///0表示失败;文件名表示成功,3表示文件不符合格式要求；4表示超过了限定大小
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FloderName"></param>
        /// <returns></returns>
        public string UpFile_image(FileUpload FilePath, string FloderName)//上传文件的类
        {
            string coutw = "0";//0表示失败；1表示成功；3表示文件格式不对;4表示超过了限定大小
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//获取初始的文件名
                    int i = fileName.LastIndexOf(".");//取得文件名中最后一个"."的索引
                    string fileType = fileName.Substring(i);//获取文件扩展名
                    DateTime relese_time_1 = DateTime.Now;
                    string filename_1 = relese_time_1.Second.ToString() + "_" + relese_time_1.Millisecond.ToString() + "_" + FilePath.PostedFile.ContentLength.ToString() + fileType;//重新为文件命名,时间毫秒部分+文件大小+扩展名  
                    string FlieUrls = FloderName + "/" + filename_1;

                    if (checkType_IMAGE_JPG(fileType))//如果该文件是图片文件
                    { //上传该文件
                        string imageSize = System.Configuration.ConfigurationManager.AppSettings["imageSize"];
                        int sizeimage =(FilePath.PostedFile.ContentLength)/1024;//获取上传图片的大小
                        if (sizeimage < int.Parse(imageSize))
                        {
                            if (UPFileDO(FlieUrls, FilePath))
                            {
                                coutw = FlieUrls;
                            }
                            else
                            {
                                coutw = "0";
                            }
                        }
                        else
                        {
                            coutw = "4";
                        }
                    }
                    else if (!checkType(fileType))
                    {
                        coutw = "3";
                    }
                }
                else
                {
                    coutw = "0";
                }

            }
            catch
            {
                coutw = "0";
            }
            return coutw;
        }
        /// <summary>
        /// 系统允许的文件上传检验
        /// </summary>
        /// <param name="fileType">.ppt，.rar，.zip，.gif，.jpg，.jpeg，.bmp，.png，.doc，.xls，.txt，.docx，.xlsx，.swf，.wmv，.rm，.wma</param>
        /// <returns></returns>
        private bool checkType(string fileType)//可上传文件的检测
        {
            string new_fileType = fileType.ToLower();

            if (new_fileType != ".ppt" && new_fileType != ".rar" && new_fileType != ".zip" && new_fileType != ".gif" && new_fileType != ".jpg" && new_fileType != ".jpeg" && new_fileType != ".bmp" && new_fileType != ".png" && new_fileType != ".doc" && new_fileType != ".xls" && new_fileType != ".txt" && new_fileType != ".docx" && new_fileType != ".xlsx" && new_fileType != ".swf" && new_fileType != ".wmv" && new_fileType != ".rm" && new_fileType != ".wma")
            {
                return false;
            }
            else
                return true;
        }
        /// <summary>
        /// 进行图片文件的校验检测
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        private bool checkType_IMAGE(string fileType)//对图片文件的检测
        {
            string new_fileType = fileType.ToLower();
            if (new_fileType != ".gif" && new_fileType != ".jpg" && new_fileType != ".jpeg" && new_fileType != ".bmp" && new_fileType != ".png")
            {
                return false;
            }
            else
                return true;
        }
        private bool checkType_IMAGE_JPG(string fileType)//对图片文件的检测
        {
            string new_fileType = fileType.ToLower();
            if (new_fileType != ".jpg" && new_fileType != ".jpeg")
            {
                return false;
            }
            else
                return true;
        }
        /// <summary>
        /// 上传控件
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="res_path"></param>
        /// <returns></returns>
        private bool UPFileDO(string urls, FileUpload res_path)
        {
            try
            {
                Page page = new Page();
          
                res_path.PostedFile.SaveAs(page.Server.MapPath(urls)); // 保存文件到路径,用Server.MapPath()取当前文件的绝对目录.在asp.net里"\"必须用""代替   
                return true;

            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取EXCEL文件的类
        /// </summary>
        /// <param name="FilePath">上传文件的路径</param>
        /// <param name="readFromRowsNum">开始读取位置</param>
        /// <returns></returns>
        public DataSet ReadExcel(string FilePath, int readFromRowsNum)
        {
           
            DataSet ds = new DataSet();

            try
            {
                string[] fileList = FilePath.Split('.');
                int leng = fileList.Length;
                string fileType = fileList[leng - 1].ToString();
                OleDbConnection objConn = new OleDbConnection();

                if (fileType == "xlsx")
                {
                    objConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";" + "Extended Properties=Excel 12.0;");

                }
                else
                {
                    objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";" + "Extended Properties=Excel 8.0;");

                }
                objConn.Open();
                //Excel的连接

                DataTable schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);

                string tableName = schemaTable.Rows[0][2].ToString().Trim();//获取 Excel 的表名，默认值是sheet1

                string strSql = "select * from [" + tableName + "]";
                OleDbCommand objCmd = new OleDbCommand(strSql, objConn);
                OleDbDataAdapter myData = new OleDbDataAdapter(strSql, objConn);
                myData.Fill(ds, tableName);//填充数据
                objConn.Close();
                //
                // ds.Tables[0].Rows.Remove(ds.Tables[0].Rows[0]);
                //
                return ds;
            }
            catch
            {
                return ds;
            }
        }

        ///////////////////////////////////////////////////上传图片重复数据//////////////////////////////////////////////////////////////////////////////////




        /// <summary>
        /// 上传文件到服务器的类文件(JPG文件)
        /// FilePath为待上传文件的全称
        /// FloderName为目标文件夹
        ///0表示失败;文件名表示成功,3表示文件不符合格式要求；4表示超过了限定大小
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FloderName"></param>
        /// <returns></returns>
        public string UpFile_image2(FileUpload FilePath, string FloderName,string filename_1)//上传文件的类
        {
            string coutw = "0";//0表示失败；1表示成功；3表示文件格式不对;4表示超过了限定大小
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//获取初始的文件名
                    int i = fileName.LastIndexOf(".");//取得文件名中最后一个"."的索引
                    string fileType = fileName.Substring(i);//获取文件扩展名
                    DateTime relese_time_1 = DateTime.Now;



                   // string filename_1 = relese_time_1.Second.ToString() + "_" + relese_time_1.Millisecond.ToString() + "_" + FilePath.PostedFile.ContentLength.ToString() + fileType;//重新为文件命名,时间毫秒部分+文件大小+扩展名  

                    string FlieUrls = FloderName + "/" + filename_1+fileType;

                    if (checkType_IMAGE_JPG(fileType))//如果该文件是图片文件
                    { //上传该文件
                        string imageSize = System.Configuration.ConfigurationManager.AppSettings["imageSize"];
                        int sizeimage = (FilePath.PostedFile.ContentLength) / 1024;//获取上传图片的大小
                        if (sizeimage < int.Parse(imageSize))
                        {
                            if (UPFileDO2(FlieUrls, FilePath))
                            {
                                coutw = FlieUrls;
                            }
                            else
                            {
                                coutw = "0";
                            }
                        }
                        else
                        {
                            coutw = "4";
                        }
                    }
                    else if (!checkType(fileType))
                    {
                        coutw = "3";
                    }
                }
                else
                {
                    coutw = "0";
                }

            }
            catch
            {
                coutw = "0";
            }
            return coutw;
        }
        /// <summary>
        /// 上传学生照片的专用上传代码
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="res_path"></param>
        /// <returns></returns>
        private bool UPFileDO2(string urls, FileUpload res_path)
        {
            try
            {
                Page page = new Page();
                if (File.Exists(urls))//存在文件
                {
                    File.Delete(urls);
                }
                res_path.PostedFile.SaveAs(page.Server.MapPath(urls)); // 保存文件到路径,用Server.MapPath()取当前文件的绝对目录.在asp.net里"\"必须用""代替   
                return true;

            }
            catch
            {
                return false;
            }
        }
        
    }

}
