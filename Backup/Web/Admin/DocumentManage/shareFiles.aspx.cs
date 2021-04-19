using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class shareFiles : System.Web.UI.Page
    {
        Model.USER_Users user_model = new Dianda.Model.USER_Users();
        BLL.Document_File bdfile = new Dianda.BLL.Document_File();//加载文件的操作类
        Model.Document_File mdfile = new Dianda.Model.Document_File();
        COMMON.common commons = new Dianda.COMMON.common();

        BLL.Document_File_Share bdfs = new Dianda.BLL.Document_File_Share();
        Model.Document_File_Share mdfs = new Dianda.Model.Document_File_Share();
        COMMON.pageControl dosqls = new Dianda.COMMON.pageControl();

        BLL.Document_FolderExt bdFExt = new Dianda.BLL.Document_FolderExt();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "文档 > 我的文档 > 文件共享设置";
                    //设置模板页中的管理值
                    string FID = Request["ID"];//url传值过来的参数
                    showInfo(FID);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据文件夹的ID，获取到该文件夹的基本属性
        /// </summary>
        /// <param name="FID"></param>
        private void showInfo(string FID)
        {
            try
            {
                FID = commons.RequestSafeString(FID, 50);
                mdfile = bdfile.GetModel(int.Parse(FID));

                Label_cname.Text = mdfile.FileName.ToString();
                RadioButtonList_isshare.SelectedValue = mdfile.IsShare.ToString();

                showbuttom(mdfile.UserID.ToString());
                //先根据当前的共享情况，获取之前的共享人员列表
                if (mdfile.IsShare.ToString() == "1")
                {
                    DataTable dt = new DataTable();
                    dt = bdfs.GetList(" FileID='" + FID + "'").Tables[0];
                    shareForUser1.showDepartment(dt);
                    shareForUser1.Visible = true;
                }
                else
                {
                    shareForUser1.Visible = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 提交编辑目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string FID = Request["ID"];//url传值过来的参数

                FID = commons.RequestSafeString(FID, 50);
                user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                //根据父栏目的ID获取到栏目的路径

                mdfile = bdfile.GetModel(int.Parse(FID));
                mdfile.IsShare = int.Parse(RadioButtonList_isshare.SelectedValue.ToString());
                bdfile.Update(mdfile);
                //如果文件夹被共享了，则获取接受共享的用户的值，如果文件夹没有共享，则去删除原先在共享中的值
                if (RadioButtonList_isshare.SelectedValue.ToString() == "1")
                {
                    ArrayList al = shareForUser1.getSelectUser();
                    //添加这些人到共享里面去
                    addtoFolderShare(FID, al);

                    //给接收共享的用户发信息
                    Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                    BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();
                    for (int i = 0; i < al.Count; i++)
                    {
                        mFaceShowMessage.DATETIME = DateTime.Now;
                        mFaceShowMessage.FromTable = "共享文档";
                        mFaceShowMessage.IsRead = 0;
                        mFaceShowMessage.NewsID = null;
                        mFaceShowMessage.NewsType = "共享文档";
                        mFaceShowMessage.ReadTime = null;
                        mFaceShowMessage.Receive = al[i].ToString();
                        mFaceShowMessage.DELFLAG = 0;
                        mFaceShowMessage.URLS = "<a href='/Admin/DocumentManage/manage.aspx?types=1&tp=2&CID=-1/" + mdfile.UserID.ToString() + "' title='共享文档：共享时间" + DateTime.Now.ToString() + "' target='_self'>" + mdfile.FileName.ToString() + "</a>&nbsp;共享文档&nbsp;(" + user_model.REALNAME.ToString() + ")";

 
                        bFaceShowMessage.Add(mFaceShowMessage);
                    }
                    //给接收共享的用户发信息
                }
                else
                {
                    //删除原文件夹中接受共享的人
                    delFolderShare(FID);//先清空原共享接收用户
                }
                //如果文件夹被共享了，则获取接受共享的用户的值，如果文件夹没有共享，则去删除原先在共享中的值
                //写日志
                BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理设置文件共享", "设置" + mdfile.FileName.ToString() + "共享状态为" + RadioButtonList_isshare.SelectedValue.ToString() + ":成功");
                //写日志
                Button_sumbit.Enabled = false;
                Button_sumbit.Visible = false;
               // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");location.href='manage.aspx?CID=" + bdFExt.getFolderPathById(mdfile.FolderID.ToString()) + "';</script>";
             //   Response.Write(coutws);

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('操作成功！');location.href='manage.aspx?CID=" + bdFExt.getFolderPathById(mdfile.FolderID.ToString()) + "'", true);
            }
            catch
            {
                Button_sumbit.Enabled = false;
                Button_sumbit.Visible = false;
            }
        }
        /// <summary>
        /// 将选择的用户添加到文件的共享中
        /// </summary>
        /// <param name="folderid"></param>
        /// <param name="al"></param>
        private void addtoFolderShare(string FileID, ArrayList al)
        {
            try
            {
                delFolderShare(FileID);//先清空原共享接收用户
                for (int i = 0; i < al.Count; i++)
                {
                    if (al[i] != null && al[i].ToString() != "")
                    {
                        mdfs.DATETIME = DateTime.Now;
                        mdfs.FileID = int.Parse(FileID);
                        mdfs.ShareForUser = al[i].ToString();
                        bdfs.Add(mdfs);
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 将当前文件夹中的接收共享的用户清空
        /// </summary>
        /// <param name="folderid"></param>
        private void delFolderShare(string FileID)
        {
            try
            {
                string sql = "delete from Document_File_Share where FileID='" + FileID + "'";
                dosqls.doSql(sql);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据当期用户的权限，判断该用户是否能继续添加了
        /// </summary>
        /// <param name="userid"></param>
        private void showbuttom(string userid)
        {
            try
            {
                user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                if (user_model.ID.ToString() == userid)
                {
                    Button_sumbit.Enabled = true;
                    Button_sumbit.Visible = true;
                }
                else
                {
                    Button_sumbit.Enabled = false;
                    Button_sumbit.Visible = false;
                }
            }
            catch
            {
                Button_sumbit.Enabled = false;
                Button_sumbit.Visible = false;
            }
        }

        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_Click(object sender, EventArgs e)
        {
            string FID = Request["ID"];//url传值过来的参数

            FID = commons.RequestSafeString(FID, 50);
            mdfile = bdfile.GetModel(int.Parse(FID));
            Response.Redirect("manage.aspx?CID=" + bdFExt.getFolderPathById(mdfile.FolderID.ToString()) + "");
        }
        /// <summary>
        /// 当共享发生变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButtonList_isshare_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioButtonList_isshare.SelectedValue.ToString() == "1")
                {
                    string FID = Request["ID"];//url传值过来的参数
                    FID = commons.RequestSafeString(FID, 50);
                    shareForUser1.Visible = true;

                    DataTable dt = new DataTable();
                    dt = bdfs.GetList(" FileID='" + FID + "'").Tables[0];
                    shareForUser1.showDepartment(dt);
                }
                else
                {
                    shareForUser1.Visible = false;
                }
            }
            catch
            {
            }
        }

    }
}
