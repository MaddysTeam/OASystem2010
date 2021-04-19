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
 
//���������ռ�
using System.Xml;

namespace Dianda.COMMON
{
    public class FileControl
    {
        /// <summary>
        /// ����һ��xml�ļ�name:�ļ������ƣ�files:��ʼ�����ݣ�paths���ļ������·��
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
        ///�μ�ϵͳ������ϵͳ���ļ�ɾ������
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
        /// ɾ���ļ�
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
        /// �ж��ļ����Ƿ����:rss/news/2212121212121
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
        /// �����µ��ļ��У�names:xxx/ddd/ddd
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
        /// �ݹ�ɾ���ļ��м��ļ���dir:xxx/ddd/ddd
        /// </summary>
        public bool DeleteFolder(string dir)
        {
            try
            {

                if (Directory.Exists(dir)) //�����������ļ���ɾ��֮ 
                {
                    foreach (string d in Directory.GetFileSystemEntries(dir))
                    {
                        if (File.Exists(d))
                            File.Delete(d); //ֱ��ɾ�����е��ļ� 
                        else
                            DeleteFolder(d); //�ݹ�ɾ�����ļ��� 
                    }
                    Directory.Delete(dir); //ɾ���ѿ��ļ��� 
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
        /// ��ȡ�ϴ��ļ��Ĵ�С
        /// �����޶����ļ���Сsize(M)
        /// �����޶���Сʱ�������ļ��Ĵ�С
        /// ����0��ʾ���ļ������ϴ�
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        public string fileSize(FileUpload FilePath, int Size)
        {
            string coutw = "0";//0��ʾʧ�ܣ�1��ʾ�ɹ���3��ʾ�ļ���ʽ����
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
        /// ��ȡ�ļ���չ���ĺ���
        /// ����0��ʾ���ļ����Ϸ�
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public string fileType(FileUpload FilePath)
        {
            string coutw = "0";//0��ʾʧ�ܣ�1��ʾ�ɹ���3��ʾ�ļ���ʽ����
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//��ȡ��ʼ���ļ���
                    int i = fileName.LastIndexOf(".");//ȡ���ļ��������һ��"."������
                    string fileType = fileName.Substring(i);//��ȡ�ļ���չ��
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
        /// �ϴ��ļ��������������ļ�
        /// FilePathΪ���ϴ��ļ���ȫ��
        /// FloderNameΪĿ���ļ���
        /// TypeΪ�ļ�������
        ///0��ʾʧ��;�ļ�����ʾ�ɹ�,3��ʾ�ļ������ϸ�ʽҪ��
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FloderName"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public string UpFile(FileUpload FilePath, string FloderName)//�ϴ��ļ�����
        {
            string coutw = "0";//0��ʾʧ�ܣ�1��ʾ�ɹ���3��ʾ�ļ���ʽ����
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//��ȡ��ʼ���ļ���
                    int i = fileName.LastIndexOf(".");//ȡ���ļ��������һ��"."������
                    string fileType = fileName.Substring(i);//��ȡ�ļ���չ��
                    DateTime relese_time_1 = DateTime.Now;
                    string filename_1 =relese_time_1.Year.ToString()+relese_time_1.Month.ToString()+relese_time_1.Day.ToString()+relese_time_1.Hour.ToString()+relese_time_1.Minute.ToString()+relese_time_1.Second.ToString() + "_" + relese_time_1.Millisecond.ToString() + "_" + FilePath.PostedFile.ContentLength.ToString() + fileType;//����Ϊ�ļ�����,ʱ����벿��+�ļ���С+��չ��  
                    string FlieUrls = FloderName + "/" + filename_1;

                    if (checkType(fileType))//������ļ���ͼƬ�ļ�
                    { //�ϴ����ļ�
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
        /// ͨ�õ��ļ��ϴ����[fileTypeSet=IMAGE ��ʾͼƬ��������gif,jpe,jpeg,png,bmp��ʽ��fileTypeSet=COMMONS ��ʾͨ�÷ǿ�ִ���ļ���������.ppt��.rar��.zip��.gif��.jpg��.jpeg��.bmp��.png��.doc��.xls��.txt��.docx��.xlsx��.swf��.wmv��.rm��.wma]
      /// </summary>
      /// <param name="FilePath">�ϴ��ؼ�</param>
      /// <param name="FloderName">Ҫ�ϴ������ļ��е�ַ</param>
      /// <param name="fileType">�ļ�������</param>
      /// <returns>���أ��ַ������ȴ���2��ʾ�ϴ��ɹ��������������ֵ��Ϊ�ϴ��ļ���·����ַ������0����ʾ�ϴ�ʧ�ܣ�3��ʾ�ļ���ʽ������Ҫ��</returns>
        public string UpFile_COMMONS(FileUpload FilePath, string FloderName,string fileTypeSet)//�ϴ��ļ�����
        {
            string coutw = "0";//0��ʾʧ�ܣ�1��ʾ�ɹ���3��ʾ�ļ���ʽ����
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//��ȡ��ʼ���ļ���
                    int i = fileName.LastIndexOf(".");//ȡ���ļ��������һ��"."������
                    string fileType = fileName.Substring(i);//��ȡ�ļ���չ��
                    DateTime relese_time_1 = DateTime.Now;
                    string filename_1 = relese_time_1.Year.ToString() + relese_time_1.Month.ToString() + relese_time_1.Day.ToString() + relese_time_1.Hour.ToString() + relese_time_1.Minute.ToString() + relese_time_1.Second.ToString() + "_" + relese_time_1.Millisecond.ToString() + "_" + FilePath.PostedFile.ContentLength.ToString() + fileType;//����Ϊ�ļ�����,ʱ����벿��+�ļ���С+��չ��  
                    string FlieUrls = FloderName + "/" + filename_1;
                    bool isAccept = false;//�����͵��ļ��Ƿ������ϴ�

                    if (fileTypeSet == "IMAGE")//ͼƬ���ϴ�
                    {
                        isAccept = checkType_IMAGE(fileType);
                    }
                    if (fileTypeSet == "COMMONS")//ͨ�õ����ͼ��
                    {
                        isAccept = checkType(fileType);
                    }

                    if (isAccept)//��������ϴ�Ҫ��
                    { //�ϴ����ļ�
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
        /// �ϴ��ļ��������������ļ�(JPG�ļ�)
        /// FilePathΪ���ϴ��ļ���ȫ��
        /// FloderNameΪĿ���ļ���
        ///0��ʾʧ��;�ļ�����ʾ�ɹ�,3��ʾ�ļ������ϸ�ʽҪ��4��ʾ�������޶���С
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FloderName"></param>
        /// <returns></returns>
        public string UpFile_image(FileUpload FilePath, string FloderName)//�ϴ��ļ�����
        {
            string coutw = "0";//0��ʾʧ�ܣ�1��ʾ�ɹ���3��ʾ�ļ���ʽ����;4��ʾ�������޶���С
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//��ȡ��ʼ���ļ���
                    int i = fileName.LastIndexOf(".");//ȡ���ļ��������һ��"."������
                    string fileType = fileName.Substring(i);//��ȡ�ļ���չ��
                    DateTime relese_time_1 = DateTime.Now;
                    string filename_1 = relese_time_1.Second.ToString() + "_" + relese_time_1.Millisecond.ToString() + "_" + FilePath.PostedFile.ContentLength.ToString() + fileType;//����Ϊ�ļ�����,ʱ����벿��+�ļ���С+��չ��  
                    string FlieUrls = FloderName + "/" + filename_1;

                    if (checkType_IMAGE_JPG(fileType))//������ļ���ͼƬ�ļ�
                    { //�ϴ����ļ�
                        string imageSize = System.Configuration.ConfigurationManager.AppSettings["imageSize"];
                        int sizeimage =(FilePath.PostedFile.ContentLength)/1024;//��ȡ�ϴ�ͼƬ�Ĵ�С
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
        /// ϵͳ������ļ��ϴ�����
        /// </summary>
        /// <param name="fileType">.ppt��.rar��.zip��.gif��.jpg��.jpeg��.bmp��.png��.doc��.xls��.txt��.docx��.xlsx��.swf��.wmv��.rm��.wma</param>
        /// <returns></returns>
        private bool checkType(string fileType)//���ϴ��ļ��ļ��
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
        /// ����ͼƬ�ļ���У����
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        private bool checkType_IMAGE(string fileType)//��ͼƬ�ļ��ļ��
        {
            string new_fileType = fileType.ToLower();
            if (new_fileType != ".gif" && new_fileType != ".jpg" && new_fileType != ".jpeg" && new_fileType != ".bmp" && new_fileType != ".png")
            {
                return false;
            }
            else
                return true;
        }
        private bool checkType_IMAGE_JPG(string fileType)//��ͼƬ�ļ��ļ��
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
        /// �ϴ��ؼ�
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="res_path"></param>
        /// <returns></returns>
        private bool UPFileDO(string urls, FileUpload res_path)
        {
            try
            {
                Page page = new Page();
          
                res_path.PostedFile.SaveAs(page.Server.MapPath(urls)); // �����ļ���·��,��Server.MapPath()ȡ��ǰ�ļ��ľ���Ŀ¼.��asp.net��"\"������""����   
                return true;

            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ��ȡEXCEL�ļ�����
        /// </summary>
        /// <param name="FilePath">�ϴ��ļ���·��</param>
        /// <param name="readFromRowsNum">��ʼ��ȡλ��</param>
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
                //Excel������

                DataTable schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);

                string tableName = schemaTable.Rows[0][2].ToString().Trim();//��ȡ Excel �ı�����Ĭ��ֵ��sheet1

                string strSql = "select * from [" + tableName + "]";
                OleDbCommand objCmd = new OleDbCommand(strSql, objConn);
                OleDbDataAdapter myData = new OleDbDataAdapter(strSql, objConn);
                myData.Fill(ds, tableName);//�������
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

        ///////////////////////////////////////////////////�ϴ�ͼƬ�ظ�����//////////////////////////////////////////////////////////////////////////////////




        /// <summary>
        /// �ϴ��ļ��������������ļ�(JPG�ļ�)
        /// FilePathΪ���ϴ��ļ���ȫ��
        /// FloderNameΪĿ���ļ���
        ///0��ʾʧ��;�ļ�����ʾ�ɹ�,3��ʾ�ļ������ϸ�ʽҪ��4��ʾ�������޶���С
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FloderName"></param>
        /// <returns></returns>
        public string UpFile_image2(FileUpload FilePath, string FloderName,string filename_1)//�ϴ��ļ�����
        {
            string coutw = "0";//0��ʾʧ�ܣ�1��ʾ�ɹ���3��ʾ�ļ���ʽ����;4��ʾ�������޶���С
            try
            {

                int FilePathLen = FilePath.PostedFile.FileName.Length;
                if (FilePathLen > 0)
                {
                    string fileName = FilePath.PostedFile.FileName;//��ȡ��ʼ���ļ���
                    int i = fileName.LastIndexOf(".");//ȡ���ļ��������һ��"."������
                    string fileType = fileName.Substring(i);//��ȡ�ļ���չ��
                    DateTime relese_time_1 = DateTime.Now;



                   // string filename_1 = relese_time_1.Second.ToString() + "_" + relese_time_1.Millisecond.ToString() + "_" + FilePath.PostedFile.ContentLength.ToString() + fileType;//����Ϊ�ļ�����,ʱ����벿��+�ļ���С+��չ��  

                    string FlieUrls = FloderName + "/" + filename_1+fileType;

                    if (checkType_IMAGE_JPG(fileType))//������ļ���ͼƬ�ļ�
                    { //�ϴ����ļ�
                        string imageSize = System.Configuration.ConfigurationManager.AppSettings["imageSize"];
                        int sizeimage = (FilePath.PostedFile.ContentLength) / 1024;//��ȡ�ϴ�ͼƬ�Ĵ�С
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
        /// �ϴ�ѧ����Ƭ��ר���ϴ�����
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="res_path"></param>
        /// <returns></returns>
        private bool UPFileDO2(string urls, FileUpload res_path)
        {
            try
            {
                Page page = new Page();
                if (File.Exists(urls))//�����ļ�
                {
                    File.Delete(urls);
                }
                res_path.PostedFile.SaveAs(page.Server.MapPath(urls)); // �����ļ���·��,��Server.MapPath()ȡ��ǰ�ļ��ľ���Ŀ¼.��asp.net��"\"������""����   
                return true;

            }
            catch
            {
                return false;
            }
        }
        
    }

}
