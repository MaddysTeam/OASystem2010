using System;

using System.Data;

using System.Configuration;

using System.Web;

using System.Web.Security;

using System.Web.UI;

using System.IO;

using ICSharpCode.SharpZipLib.Checksums;

using ICSharpCode.SharpZipLib.Zip;

using ICSharpCode.SharpZipLib.GZip;

/// <summary>

/// ZipFloClass 的摘要说明

/// </summary>
namespace Dianda.COMMON
{
    public class ZipFloClass
    {
        /// <summary>
        /// 将文件夹压缩到指定的名称上（strFile待压缩文件目录;strZip压缩后的目标文件）
        /// </summary>
        /// <param name="strFile"></param>
        /// <param name="strZip"></param>
        public void ZipFile(string strFile, string strZip)
        {
            try
            {
                if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar)
                    strFile += Path.DirectorySeparatorChar;
                ZipOutputStream s = new ZipOutputStream(File.Create(strZip));
                s.SetLevel(6); // 0 - store only to 9 - means best compression
                zip(strFile, s, strFile);
                s.Finish();
                s.Close();
            }
            catch
            {
            }

        }

        private void zip(string strFile, ZipOutputStream s, string staticFile)
        {

            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar) strFile += Path.DirectorySeparatorChar;

            Crc32 crc = new Crc32();

            string[] filenames = Directory.GetFileSystemEntries(strFile);

            foreach (string file in filenames)
            {

                if (Directory.Exists(file))
                {

                    zip(file, s, staticFile);

                }

                else // 否则直接压缩文件
                {

                    //打开压缩文件

                    FileStream fs = File.OpenRead(file);

                    byte[] buffer = new byte[fs.Length];


                    /////////////
                   
                    if (fs.Length <= 102400)
                    {
                        fs.Read(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        int size = 102400;
                        int i = 0;
                        while (size == 102400)
                        {
                            size = fs.Read(buffer, i, 102400);
                            i += 102400;
                            if ((buffer.Length - i) <= 102400)
                            {
                                size = fs.Read(buffer, i, (buffer.Length - i));
                            }
                        }
                    } 
                    ///////////////

                    

                    string tempfile = file.Substring(staticFile.LastIndexOf("\\") + 1);

                    ZipEntry entry = new ZipEntry(tempfile);

                    entry.DateTime = DateTime.Now;

                    entry.Size = fs.Length;

                    fs.Close();

                    crc.Reset();

                    crc.Update(buffer);

                    entry.Crc = crc.Value;

                    s.PutNextEntry(entry);

                    s.Write(buffer, 0, buffer.Length);

                }

            }

        }
        public string CreateZIPFile(string path, int M)
        {
            try
            {
                Crc32 crc = new Crc32();
                ICSharpCode.SharpZipLib.Zip.ZipOutputStream zipout = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(System.IO.File.Create(path + ".zip"));
                System.IO.FileStream fs = System.IO.File.OpenRead(path);
                long pai = 1024 * 1024 * M;//每M兆写一次
                long forint = fs.Length / pai + 1;
                byte[] buffer = null;
                ZipEntry entry = new ZipEntry(System.IO.Path.GetFileName(path));
                entry.Size = fs.Length;
                entry.DateTime = DateTime.Now;
                zipout.PutNextEntry(entry);
                for (long i = 1; i <= forint; i++)
                {
                    if (pai * i < fs.Length)
                    {
                        buffer = new byte[pai];
                        fs.Seek(pai * (i - 1), System.IO.SeekOrigin.Begin);
                    }
                    else
                    {
                        if (fs.Length < pai)
                        {
                            buffer = new byte[fs.Length];
                        }
                        else
                        {
                            buffer = new byte[fs.Length - pai * (i - 1)];
                            fs.Seek(pai * (i - 1), System.IO.SeekOrigin.Begin);
                        }
                    }
                    fs.Read(buffer, 0, buffer.Length);
                    crc.Reset();
                    crc.Update(buffer);
                    zipout.Write(buffer, 0, buffer.Length);
                    zipout.Flush();
                }
                fs.Close();
                zipout.Finish();
                zipout.Close();
                System.IO.File.Delete(path);
                return path + ".zip";
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return path;
            }
        }



    }
}