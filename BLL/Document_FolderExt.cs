using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dianda.BLL
{
  
    public class Document_FolderExt
    {
        COMMON.common commons = new Dianda.COMMON.common();
        BLL.Document_Folder bdf = new Dianda.BLL.Document_Folder();
        Model.Document_Folder mdf = new Dianda.Model.Document_Folder();
        COMMON.pageControl pageconto = new Dianda.COMMON.pageControl();
        COMMON.FileControl filecontrols = new Dianda.COMMON.FileControl();
        BLL.Document_File bdfiles = new Document_File();
        COMMON.fileUploads cfup = new Dianda.COMMON.fileUploads();

















        /// <summary>
        /// 根据文件的属性是项目的还是个人的，还有用户的ID，项目的ID获取到列表
        /// </summary>
        /// <param name="userid">用户的ID</param>
        /// <param name="types">文件的归类：public是项目的文件夹；private是个人的文件夹</param>
        /// <param name="projectid">项目的ID(select in ('0','ds')的方式)</param>
        public DataTable makeFolder1(string userid, string types, string projectid, string TJ)
        {
            DataTable DTColumns = new DataTable();
            if (TJ == "and ( status is null or Status=-1)") { TJ = ""; } else if (String.IsNullOrEmpty(TJ)) { TJ = "and ( status is null or Status=1)"; }

            try
            {
                userid = commons.RequestSafeString(userid, 50);
                types = commons.RequestSafeString(types, 50);
                projectid = commons.RequestSafeString(projectid, 50);
                // 用来比对子栏目是否为顶级节点

                string sqlwhere = "";
                if (types == "private")
                {
                    sqlwhere = " Types='" + types + "' and UserID='" + userid + "' and DELFLAG='0'" + TJ + "  order by COLUMNSPATH";
                    DTColumns = bdf.GetList(sqlwhere).Tables[0];
                }
                else if (types == "public")
                {
                    if (projectid.Length > 0)//表示仅仅取该项目的文档
                    {
                        sqlwhere = "select * from vDocument_Folder where Types='" + types + "' and (projectid='" + projectid + "' or upid='-1') and DELFLAG='0' " + TJ + "  order by COLUMNSPATH";
                        DTColumns = pageconto.doSql(sqlwhere).Tables[0];
                        //DTColumns = bdf.GetList(sqlwhere).Tables[0];
                    }
                    else
                    {
                        // sqlwhere = " Types='" + types + "' and (projectid in(select id from Project_Projects where leaderid='" + userid + "') or projectid in(select Projectid from Project_UserList where userid='" + userid + "' and status='1') or projectid='0') and DELFLAG='0' order by COLUMNSPATH";
                        sqlwhere = "select * from vDocument_Folder where  Types='" + types + "' and (projectid in(select id from Project_Projects where leaderid='" + userid + "') or projectid in(select Projectid from Project_UserList where userid='" + userid + "' and status='1') or projectid='0') and DELFLAG='0' AND (PDEL=0 OR PDEL IS NULL) " + TJ + "  order by status,COLUMNSPATH";
                        DTColumns = pageconto.doSql(sqlwhere).Tables[0];
                        System.Web.HttpContext.Current.Session["tj"] = "";
                        
                    }
                    // DTColumns = bdf.GetList(sqlwhere).Tables[0];
                }
                else//共享文档
                {
                    //根据当前的用户，从视图中找出所有的提供共享的组织内用户
                    string sql1 = " SELECT userid,username,realname,shareForuser,shareForuser+'/'+userid as paths FROM vDocument_File_Share where shareforuser='" + userid + "' and delflag='0' group by userid,username,realname,shareForuser";

                    string sql2 = "select userid,username,realname,shareForuser,shareForuser+'/'+userid as paths from vDocument_Folder_Share where shareforuser='" + userid + "' and delflag='0' group by userid,username,realname,shareForuser";
                    DataTable dt1 = pageconto.doSql(sql1).Tables[0];
                    DataTable dt2 = pageconto.doSql(sql2).Tables[0];
                    DTColumns = commons.CombineTheSameDatatable(dt1, dt2);
                    DTColumns = commons.makeDistinceTable(DTColumns, "userid");
                    System.Web.HttpContext.Current.Session["tj"] = "";

                }

                // 有子栏目,则显示树

            }
            catch
            {
                System.Web.HttpContext.Current.Session["tj"] = "";
            }
            return DTColumns;
        }


        /// <summary>
        /// 根据文件的属性是项目的还是个人的，还有用户的ID，项目的ID获取到列表
        /// </summary>
        /// <param name="userid">用户的ID</param>
        /// <param name="types">文件的归类：public是项目的文件夹；private是个人的文件夹</param>
        /// <param name="projectid">项目的ID(select in ('0','ds')的方式)</param>
        public DataTable makeFolder(string userid, string types, string projectid)
        {
             DataTable DTColumns = new DataTable();
            try
            {
                userid = commons.RequestSafeString(userid, 50);
                types = commons.RequestSafeString(types, 50);
                projectid = commons.RequestSafeString(projectid, 50);
                // 用来比对子栏目是否为顶级节点
              
                string sqlwhere = "";
                if (types == "private")
                {
                    sqlwhere = " Types='" + types + "' and UserID='" + userid + "' and DELFLAG='0' order by COLUMNSPATH";
                    DTColumns = bdf.GetList(sqlwhere).Tables[0];
                }
                else if (types == "public")
                {
                    if (projectid.Length>0)//表示仅仅取该项目的文档
                    {
                        sqlwhere = "select * from vDocument_Folder where Types='" + types + "' and (projectid='" + projectid + "' or upid='-1') and DELFLAG='0' order by COLUMNSPATH";
                        DTColumns = pageconto.doSql(sqlwhere).Tables[0];
                        //DTColumns = bdf.GetList(sqlwhere).Tables[0];
                    }
                    else
                    {
                       // sqlwhere = " Types='" + types + "' and (projectid in(select id from Project_Projects where leaderid='" + userid + "') or projectid in(select Projectid from Project_UserList where userid='" + userid + "' and status='1') or projectid='0') and DELFLAG='0' order by COLUMNSPATH";
                        sqlwhere = "select * from vDocument_Folder where  Types='" + types + "' and (projectid in(select id from Project_Projects where leaderid='" + userid + "') or projectid in(select Projectid from Project_UserList where userid='" + userid + "' and status='1') or projectid='0') and DELFLAG='0' AND (PDEL=0 OR PDEL IS NULL) order by status,COLUMNSPATH";
                        DTColumns = pageconto.doSql(sqlwhere).Tables[0];
                    }
                   // DTColumns = bdf.GetList(sqlwhere).Tables[0];
                }
                else//共享文档
                {
                    //根据当前的用户，从视图中找出所有的提供共享的组织内用户
                    string sql1 = " SELECT userid,username,realname,shareForuser,shareForuser+'/'+userid as paths FROM vDocument_File_Share where shareforuser='" + userid + "' and delflag='0' group by userid,username,realname,shareForuser";

                    string sql2 = "select userid,username,realname,shareForuser,shareForuser+'/'+userid as paths from vDocument_Folder_Share where shareforuser='" + userid + "' and delflag='0' group by userid,username,realname,shareForuser";
                    DataTable dt1 = pageconto.doSql(sql1).Tables[0];
                    DataTable dt2 = pageconto.doSql(sql2).Tables[0];
                    DTColumns=commons.CombineTheSameDatatable(dt1, dt2);
                    DTColumns = commons.makeDistinceTable(DTColumns, "userid");

                    
                }
              
                // 有子栏目,则显示树
 
            }
            catch
            {
            }
            return DTColumns;
        }
        /// <summary>
        /// 根据项目的ID，获取到该项目下面所有的文档目录
        /// </summary>
        /// <param name="projectid"></param>
        /// <returns></returns>
        public DataTable makeProjectFolder(string projectid)
        {
            projectid = commons.RequestSafeString(projectid, 50);
            DataTable dt = new DataTable();
            try
            {
                string sql = " Types='public' and (projectid='" + projectid + "') and DELFLAG='0' order by COLUMNSPATH";
                dt = bdf.GetList(sql).Tables[0];
            }
            catch
            {
            }

            return dt;
        }

        /// <summary>
        /// 根据文件的属性是项目的还是个人的，还有用户的ID，项目的ID获取到列表
        /// </summary>
        /// <param name="userid">用户的ID</param>
        /// <param name="types">文件的归类：public是项目的文件夹；private是个人的文件夹</param>
        /// <param name="projectid">项目的ID(select in ('0','ds')的方式)</param>
        public DataTable makeFolder_droplist(string userid, string types, string projectid)
        {
            DataTable DTColumns = new DataTable();
            try
            {
                userid = commons.RequestSafeString(userid, 50);
                types = commons.RequestSafeString(types, 50);
                projectid = commons.RequestSafeString(projectid, 50);
                // 用来比对子栏目是否为顶级节点

                string sqlwhere = "";
                if (types == "private")
                {
                    sqlwhere = " Types='" + types + "' and UserID='" + userid + "' and DELFLAG='0' order by COLUMNSPATH";
                    DTColumns = bdf.GetList(sqlwhere).Tables[0];
                }
                else if (types == "public")
                {
                    if (projectid.Length > 0)//表示仅仅取该项目的文档
                    {
                       // sqlwhere = " Types='" + types + "' and (projectid='" + projectid + "') and DELFLAG='0' order by COLUMNSPATH";

                        sqlwhere = "select * from vDocument_Folder where   Types='" + types + "' and (projectid='" + projectid + "') and DELFLAG='0' order by status,COLUMNSPATH";
                    }
                    else
                    {
                        sqlwhere = "select * from vDocument_Folder where  Types='" + types + "' and (projectid in(select id from Project_Projects where leaderid='" + userid + "') or projectid in(select Projectid from Project_UserList where userid='" + userid + "' and status='1') or projectid='0') and DELFLAG='0' AND (PDEL=0 OR PDEL IS NULL)  order by status,COLUMNSPATH";
                    }
                    DTColumns = pageconto.doSql(sqlwhere).Tables[0];// bdf.GetList(sqlwhere).Tables[0];
                }
                else//共享文档
                {
                    //根据当前的用户，从视图中找出所有的提供共享的组织内用户
                    string sql1 = " SELECT userid,username,realname,shareForuser,shareForuser+'/'+userid as paths FROM vDocument_File_Share where shareforuser='" + userid + "' and delflag='0' group by userid,username,realname,shareForuser";

                    string sql2 = "select userid,username,realname,shareForuser,shareForuser+'/'+userid as paths from vDocument_Folder_Share where shareforuser='" + userid + "' and delflag='0' group by userid,username,realname,shareForuser";
                    DataTable dt1 = pageconto.doSql(sql1).Tables[0];
                    DataTable dt2 = pageconto.doSql(sql2).Tables[0];
                    DTColumns = commons.CombineTheSameDatatable(dt1, dt2);
                    DTColumns = commons.makeDistinceTable(DTColumns, "userid");


                }

                // 有子栏目,则显示树

            }
            catch
            {
            }
            return DTColumns;
        }
        /// <summary>
        /// 根据栏目的ID获取到栏目的路径地址
        /// </summary>
        /// <param name="folderid"></param>
        /// <returns></returns>
        public string getFolderPathById(string folderid)
        {
            string coutw = "";
            try
            {
                folderid = commons.RequestSafeString(folderid, 50);
                mdf = bdf.GetModel(int.Parse(folderid));
                coutw = mdf.COLUMNSPATH.ToString();
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 根据提供共享的用户IDUserID，和接受共享的用户IDShareForUser，归并出所有的共享文件
        /// </summary>
        /// <param name="ShareForUser"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataTable ShareFileTable(string ShareForUser, string UserID)
        {
            DataTable dtAllfile = new DataTable();//用来接收汇总后的文件的数据
            try
            {
                DataTable dtAll = new DataTable();//用来接收汇总后文件夹的数据
                string sqlinfile ="";
                string sqlin ="";
                DataTable dt = new DataTable();

                //1先处理文件夹
                sqlin = "(select folderid from vDocument_Folder_Share where shareforuser='" + ShareForUser + "' and UserID='" + UserID + "')";
                dt = bdf.GetList(" DELFLAG='0' and  ID IN " + sqlin).Tables[0];

                sqlinfile = "(SELECT fileid FROM vDocument_File_Share where shareforuser='" + ShareForUser + "' and UserID='"+UserID+"')";
                //找出当前用户接受到的所有的文件的ID，并且将这些文件都排除在共享列表的外面
                string sqlisshare = "(select ShareID from Document_File where ShareID is not null and UserID='" + ShareForUser + "' and DELFLAG='0')";

                //找出当前用户接受到的所有的文件的ID，并且将这些文件都排除在共享列表的外面

                string sqlfile = "select * from vDocument_File where DELFLAG='0' and id not in " + sqlisshare + " and id in" + sqlinfile;
                 dtAllfile = pageconto.doSql(sqlfile).Tables[0];//获取到被选择的文件的数据集合
                
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string paths = dt.Rows[i]["COLUMNSPATH"].ToString();
                        //用循环的方式构建DT（文件夹）
                        DataTable dt1 = bdf.GetList(" DELFLAG='0' and COLUMNSPATH LIKE '" + paths + "%'").Tables[0];
                        if (dt1.Rows.Count > 0)
                        {
                            dtAll = commons.CombineTheSameDatatable(dt1, dtAll);
                        }

                        //处理文件的
                        string sqlfile2 = "select * from vDocument_File where DELFLAG='0' and COLUMNSPATH LIKE '" + paths + "%' and id not in " + sqlisshare + "";
                        DataTable dtf2 = pageconto.doSql(sqlfile2).Tables[0];
                        if (dtf2.Rows.Count > 0)
                        {
                            dtAllfile = commons.CombineTheSameDatatable(dtf2, dtAllfile);
                        }

                    }
                    dtAll = commons.makeDistinceTable(dtAll, "COLUMNSPATH");//将重复的数据处理掉
                    dtAllfile = commons.makeDistinceTable(dtAllfile, "ID");//将重复的数据处理掉
                }
            }
            catch
            { }
            return dtAllfile;
        }

        /// <summary>
        /// 根据栏目的ID和顶级的栏目路径，构建这个栏目对应的文件夹(topFolderPath的最后包括/)
        /// </summary>
        /// <param name="topFolderPath"></param>
        /// <param name="FolderID"></param>
        public void makeFolderByFolderID(string topFolderPath, string FolderIDs)
        {
            try
            {

                List<Model.Document_Folder> listDoc = bdf.GetModelList("ID in " + FolderIDs);
                if (listDoc != null && listDoc.Count>0)
                {
                    for (int i = 0; i < listDoc.Count; i++)
                    {
                        string pnames =listDoc[i].PNAMES.ToString();
                        pnames = pnames.Replace('>', '/');
                        pnames = topFolderPath + pnames;
                        filecontrols.CREATFOLDER(pnames);
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据文件的ID和顶级的栏目路径，拷贝文件（topFolderPath的最后包括/）
        /// </summary>
        /// <param name="topFolderPath"></param>
        /// <param name="filesIDs"></param>
        public void copyFilesToNewFolder(string topFolderPath,string filesIDs)
        {
            try
            {
                DataTable dts=new DataTable();
                string sqls="select * from vDocument_File where ID in " + filesIDs;
                 dts=pageconto.doSql(sqls).Tables[0];

                if (dts.Rows.Count>0)
                {
                  
                    for (int i = 0; i < dts.Rows.Count; i++)
                    {

                        string filename =dts.Rows[i]["FileName"].ToString();//文件的名称
                        string fileurls =dts.Rows[i]["FilePath"].ToString();//文件的路径
                        string fileFileType = dts.Rows[i]["FileType"].ToString();//文件的类型
                        string filePname = dts.Rows[i]["PNAMES"].ToString();//文件的父路径
                        filePname = filePname.Replace('>','/');
                        string filePaths = topFolderPath + filePname + "/";

                        //先判断该目录是否存在，如果已经存在，则不用创建新的，如果没有，则创建
                        if (System.IO.Directory.Exists(filePaths) == false)
                        {
                            filecontrols.CREATFOLDER(filePaths);
                        }
                        //先判断该目录是否存在，如果已经存在，则不用创建新的，如果没有，则创建

                        //判断文件名是否已经有文件类型，如果没有就添加，有就不做操作
                        string[] fn = filename.Split('.');
                        string newfilename = filename;
                        if (fn.Length > 1)
                        {
                            if (!(fn[fn.Length - 1].ToUpper()).Equals(fileFileType.ToUpper()))
                            {
                                newfilename += "." + fileFileType;
                            }
                        }
                        else
                        {
                            newfilename += "." + fileFileType;
                        }
                        string newfilepath = filePaths + newfilename;//构造新的文件路径



                        //先用文件系统判断这个新路径下有没有这个文件
                        if (!cfup.isFileExists(newfilepath))
                        {
                            cfup.CopyFiles(fileurls, newfilepath);//复制
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
