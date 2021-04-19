using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class shareFolder : System.Web.UI.Page
    {
        Model.USER_Users user_model = new Dianda.Model.USER_Users();
        Model.Document_Folder mdf = new Dianda.Model.Document_Folder();
        BLL.Document_Folder bdf = new Dianda.BLL.Document_Folder();
        COMMON.common commons = new Dianda.COMMON.common();

        BLL.Document_Folder_Share bdfs = new Dianda.BLL.Document_Folder_Share();
        Model.Document_Folder_Share mdfs = new Dianda.Model.Document_Folder_Share();
        COMMON.pageControl dosqls = new Dianda.COMMON.pageControl();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "文档 > 我的文档 > 目录共享设置";
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
                mdf = bdf.GetModel(int.Parse(FID));

                Label_cname.Text = mdf.FolderName.ToString();
                RadioButtonList_isshare.SelectedValue = mdf.IsShare.ToString();
              
                showbuttom(mdf.UserID.ToString());
                //先根据当前的共享情况，获取之前的共享人员列表
                if (mdf.IsShare.ToString() == "1")
                {
                    DataTable dt = new DataTable();
                    dt = bdfs.GetList(" FolderID='" + FID + "'").Tables[0];
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

                mdf = bdf.GetModel(int.Parse(FID));
                mdf.IsShare =int.Parse(RadioButtonList_isshare.SelectedValue.ToString());
                bdf.Update(mdf);
                //如果文件夹被共享了，则获取接受共享的用户的值，如果文件夹没有共享，则去删除原先在共享中的值
                if (RadioButtonList_isshare.SelectedValue.ToString() == "1")
                {
                    ArrayList al = shareForUser1.getSelectUser();
                    //添加这些人到共享里面去
                    addtoFolderShare(FID,al);

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
                        mFaceShowMessage.DELFLAG = 0;
                        mFaceShowMessage.Receive = al[i].ToString();
                        mFaceShowMessage.URLS = "<a href='/Admin/DocumentManage/manage.aspx?types=1&tp=2&CID=-1/" + mdf.UserID.ToString() + "' title='共享文档：共享时间" + DateTime.Now.ToString() + "' target='_self'>" + mdf.FolderName.ToString() + "</a>&nbsp;共享目录&nbsp;(" + user_model.REALNAME.ToString() + ")";
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
                    bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理设置目录共享", "设置" + mdf.FolderName.ToString() + "共享状态为" + RadioButtonList_isshare.SelectedValue.ToString() + ":成功");
                    //写日志
                    Button_sumbit.Enabled = false;
                    Button_sumbit.Visible = false;
                    //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");location.href='manage.aspx?CID=" + mdf.COLUMNSPATH.ToString() + "';</script>";
                    //Response.Write(coutws);
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('操作成功！');location.href='manage.aspx?CID=" + mdf.COLUMNSPATH.ToString() + "'", true);

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
        private void addtoFolderShare(string folderid, ArrayList al)
        {
            try
            {
                delFolderShare(folderid);//先清空原共享接收用户
                for (int i = 0; i < al.Count; i++)
                {
                    if (al[i] != null && al[i].ToString() != "")
                    {
                        mdfs.DATETIME = DateTime.Now;
                        mdfs.FolderID =int.Parse(folderid);
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
        private void delFolderShare(string folderid)
        {
            try
            {
                string sql = "delete from Document_Folder_Share where FolderID='" + folderid + "'";
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
            mdf = bdf.GetModel(int.Parse(FID));
            Response.Redirect("manage.aspx?CID=" + mdf.COLUMNSPATH.ToString() + "");
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
                    dt = bdfs.GetList(" FolderID='" + FID + "'").Tables[0];
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
