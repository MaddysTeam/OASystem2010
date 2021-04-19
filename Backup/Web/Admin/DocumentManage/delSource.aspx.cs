using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class delSource : System.Web.UI.Page
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
                        url = "文档 > 我的文档 > 删除文件";
                    }
                    if (tp == "1")
                    {
                        if (Session["Work_ProjectId"] != null)
                        {
                            url = "项目 > 我的项目 > 项目文档 > 删除文件";
                        }
                        else
                        {
                            url = "文档 > 项目文档 > 删除文件";
                        }
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
        /// 进行删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string tp = Request["tp"];//url传值过来的页卡参数
                //1先获取到要删除的内容的数据集合
                string[] dolist = fileslist1.GetDeleteList();//第一个是文件夹、第二个是文件
                if (dolist[0] != "0")
                {
                    //删除所有的文件夹
                    string sqlin = commons.makeSqlIn(dolist[0].ToString(),';');
                    string sqlFolder = "update Document_Folder set DELFLAG='1' where ID in" + sqlin;//处理文件夹的共享--文件夹本身
                    string sqlFolderShare = "delete from Document_Folder_Share where FolderID in" + sqlin;//处理文件夹之前共享给的用户信息
                    pagdosql.doSql(sqlFolder);
                    pagdosql.doSql(sqlFolderShare);
                    user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                    //写日志
                    BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                    bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理删除文件夹", "删除文件夹成功");
                    //写日志
                }
                if (dolist[1] != "0")
                {
                    //删除所有的文件
                    string sqlin = commons.makeSqlIn(dolist[1].ToString(), ';');
                    string sqlFolder = "update Document_File set DELFLAG='1' where ID in" + sqlin;//处理文件夹的共享--文件夹本身
                    string sqlFolderShare = "delete from Document_File_Share where FolderID in" + sqlin;//处理文件夹之前共享给的用户信息
                    pagdosql.doSql(sqlFolder);
                    pagdosql.doSql(sqlFolderShare);

                    user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                    //写日志
                    BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                    bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理删除文件", "删除文件成功");
                    //写日志
                }

               //string  coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?tp="+tp+"\";</script>";
               Response.Redirect(urls());
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
            //string coutws = "<script language=\"javascript\" type=\"text/javascript\">location.href = \"manage.aspx?tp="+tp+"\";</script>";
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
