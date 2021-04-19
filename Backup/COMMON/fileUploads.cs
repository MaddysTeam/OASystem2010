using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Net;

using ICSharpCode.SharpZipLib.Zip;
using System.Reflection;

namespace Dianda.COMMON
{
    /// <summary>
    /// 通用的文件上传类
    /// 2010年8月13日 唐春龙
    /// </summary>
    public class fileUploads
    {
        pageControl pc = new pageControl();
        common commons = new common();
        /// <summary>
        /// 从数据库中获取到当前的系统允许的文件类型及文件的约束大小、图标数据集
        /// </summary>
        /// <returns></returns>
        private DataTable GetDocument_File_Config()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT  ID, FileType, TypeIcon, FileSize FROM  Document_File_Config order by FileType";
                dt = pc.doSql(sql).Tables[0];
            }
            catch
            {
            }
            return dt;
        }
        /// <summary>
        /// 获取到当前系统中，可以上传的文件的类型
        /// </summary>
        /// <returns></returns>
        public string getAllowFileType()
        {
            string coutw = "";
            try
            {
                DataTable dt = GetDocument_File_Config();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i == dt.Rows.Count - 1)
                        {
                            coutw = coutw + dt.Rows[i]["FileType"].ToString();
                        }
                        else
                        {
                            coutw = coutw + dt.Rows[i]["FileType"].ToString() + ",";
                        }
                    }
                }
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 获取到当前系统中，可以上传的文件的类型(*.jpg,*.rar)
        /// </summary>
        /// <returns></returns>
        public string getAllowFileType_Up()
        {
            string coutw = "";
            try
            {
                DataTable dt = GetDocument_File_Config();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i == dt.Rows.Count - 1)
                        {
                            coutw = coutw + "*."+dt.Rows[i]["FileType"].ToString();
                        }
                        else
                        {
                            coutw = coutw + "*." + dt.Rows[i]["FileType"].ToString() + ";";
                        }
                    }
                }
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 上传文件的通用方法(成功与否（1-成功；0-失败；2-类型不支持；3-大小不符合）；文件的路径；文件名称；文件类型；图标；大小；操作结果)
        /// </summary>
        /// <param name="FilePath">文件的路径地址</param>
        /// <param name="FloderName">文件要上传的文件夹地址</param>
        /// <param name="oldfilePath">原始文件的路径地址</param>
        /// <returns> {成功与否（1-成功；0-失败；2-类型不支持；3-大小不符合）；文件的路径；文件名称；文件类型；图标；大小}</returns>
        public string[] UpFile_COMMONS(FileUpload FilePath, string FloderName, string oldfilePath)
        {
            string[] coutw ={"0","0","0","0","0","0","0"};
            //成功与否（1-成功；0-失败；2-类型不支持；3-大小不符合）；文件的路径；文件名称；文件类型；图标；大小；
            try
            {
                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//获取初始的文件名
                    string[] filearray=fileName.Split('\\');

                    int i = fileName.LastIndexOf(".");//取得文件名中最后一个"."的索引
                    string fileType = fileName.Substring(i);//获取文件扩展名
                    string filesizes=FilePath.PostedFile.ContentLength.ToString();//文件的大小
                    string[] filenames = filearray[filearray.Length - 1].ToString().Split('.');// fileName.Split('.');

                    string filename_1 = filenames[0].ToString() + "_" + commons.TodayToMS() + "_" + filesizes + fileType;//重新为文件命名,时间毫秒部分+文件大小+扩展名  


                  //  string filename_1 = fileName+"_"+commons.GetGUID() + "_" + filesizes + fileType;//重新为文件命名,时间毫秒部分+文件大小+扩展名  
                    string FlieUrls = FloderName + "/" + filename_1;
                   
                  

                    string [] checkvalue=typeCheck( GetDocument_File_Config(),fileType,sizeChange_B_K(filesizes));
                  //成功与否1-符合，0-类型不符合，2-表示大小不符合；文件的类型；文件的图标
                    if(checkvalue[0].ToString()=="1")
                    {
                        if (UPFileDO(FlieUrls, FilePath))
                        {
                            coutw[0] = "1";// FlieUrls;
                            coutw[1] = FlieUrls;
                            coutw[2] = filearray[filearray.Length-1].ToString();
                            coutw[3] = checkvalue[1].ToString();
                            coutw[4] = checkvalue[2].ToString();
                            coutw[5] = sizeChange_B_K(filesizes);
                            coutw[6] = "成功";
                            if (oldfilePath.Length > 2)
                            {
                                //删除原来的文件
                                Page page = new Page();
                                File.Delete(page.Server.MapPath(oldfilePath));
                            }
                        }
                        else
                        {
                            coutw[0] = "0";//0-失败
                            coutw[6] = "失败";
                        }
                    }
                    else
                    {
                        if(checkvalue[0].ToString()=="0")
                        {
                            coutw[0]="2";//2-类型不支持
                            coutw[6] = "类型不支持";
                        }
                        else if(checkvalue[0].ToString()=="2")
                        {
                             coutw[0]="3";//3-大小不符合
                             coutw[6] = "大小不符合";
                        }
                    }
                }
                else
                {
                    coutw[0] = "0";//0-失败
                    coutw[6] = "失败";
                }

            }
            catch
            {
                 coutw[0]="0";//0-失败
                 coutw[6] = "失败";
            }
            return coutw;
        }

        /// <summary>
        /// 上传控件
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="res_path"></param>
        /// <returns></returns>
        private bool  UPFileDO(string urls, FileUpload res_path)
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
        /// 根据文件的约束类型集合，对当前的文件类型和文件大小做校验
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filetype"></param>
        /// <param name="filesize"></param>
        /// <returns></returns>
        private string[] typeCheck(DataTable dt, string filetype,string filesize)
        {
            string[] coutw = {"0","0","0"};//成功与否1-符合，0-类型不符合，2-表示大小不符合；文件的类型；文件的图标

            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string filetypeCK = ("." + dt.Rows[i]["FileType"].ToString()).ToLower();
                        if (filetypeCK == filetype.ToLower())
                        {
                            int filesizeDT = int.Parse(dt.Rows[i]["FileSize"].ToString());//该类型的大小限定值
                            int filesizeCh = int.Parse(filesize);//要检验的文件的大小值
                            if (filesizeDT >= filesizeCh)
                            {
                                //正常的
                                coutw[0] = "1";
                                coutw[1] = dt.Rows[i]["FileType"].ToString();
                                coutw[2] = dt.Rows[i]["TypeIcon"].ToString();
                            }
                            else
                            {
                                coutw[0] = "2";
                            }
                            break;
                        }
                    }
                }
                else
                {
                    coutw[0] ="0";
                }
            }
            catch
            {
                coutw[0] = "0";
            }

            return coutw;

        }
        /// <summary>
        /// 将文件的大小由字节转换为k
        /// </summary>
        /// <param name="oldersize"></param>
        /// <returns></returns>
        public string sizeChange_B_K(string oldersize)
        {
            string coutw = "0";
            try
            {
                if (oldersize.Length > 0)
                {
                    int oldersizef = int.Parse(oldersize);
                    oldersizef = oldersizef / 1024;
                    coutw = oldersizef.ToString();
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
        /// 将老的文件以新的文件名进行拷贝处理
        /// </summary>
        /// <param name="oldeFilePath">老的文件的路径地址</param>
        /// <param name="newFilePath">新的文件的路径地址</param>
        /// <returns></returns>
        public bool CopyFiles(string oldeFilePath, string newFilePath)
        {
            bool coutw = false;
            try
            {
                Page page = new Page();
                string oldfile = page.Server.MapPath(oldeFilePath);
                string newfile = "";
                if (newFilePath.Contains(":/"))
                {
                    newfile = newFilePath.Replace("/", "\\");
                }
                else
                {
                    newfile = page.Server.MapPath(newFilePath);
                }
                File.Copy(oldfile,newfile, true);
                coutw = true;
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 判断当前路径的文件在不在
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool isFileExists(string filePath)
        {
            bool coutw = false;
            try
            {
                if (File.Exists(filePath))
                {
                    coutw = true;
                }
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 下载天气文件
        /// </summary>
        /// <param name="url">天气文件url地址</param>
        /// <param name="filename">保存的文件名</param>
        /// <param name="pagecode">文件编码</param>
        public bool DownUrltoFile_weather(string url, string filename, string pagecode)
        {
            bool coutw = false;
            try
            {
                Page page = new Page();
                //编码
                Encoding encode = Encoding.GetEncoding(pagecode);
                //请求URL
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                //配置超时(10秒)
                req.Timeout = 10000;
                //this.NotFolderIsCreate(filename);
                //获取Response
                HttpWebResponse rep = (HttpWebResponse)req.GetResponse();
                //建立StreamReader与StreamWriter文件流对象
                StreamReader sr = new StreamReader(rep.GetResponseStream(), encode);
                StreamWriter sw = new StreamWriter(page.Server.MapPath(filename), false, encode);
                //写入内容
                sw.Write(sr.ReadToEnd());
                //清理当前缓存区，并将缓存写入文件
                sw.Flush();
                //释放有关对象资源
                sw.Close();
                sw.Dispose();
                sr.Close();
                sr.Dispose();
                //Response.Write("生成文件" + filename + "成功");
                coutw = true;
            }

            catch (Exception ex)
            {
                coutw = false;
                //Response.Write("生成文件" + filename + "失败，原由：" + ex.Message);

            }
            return coutw;
        }
 
    }
}
