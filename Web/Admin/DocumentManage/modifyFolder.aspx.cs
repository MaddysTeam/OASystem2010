using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class modifyFolder : System.Web.UI.Page
    {
        Model.USER_Users user_model = new Dianda.Model.USER_Users();
        Model.Document_Folder mdf = new Dianda.Model.Document_Folder();
        BLL.Document_Folder bdf = new Dianda.BLL.Document_Folder();
        BLL.Document_FolderExt bdFExt = new Dianda.BLL.Document_FolderExt();
        Model.Document_Folder mdf2 = new Dianda.Model.Document_Folder();
        COMMON.common commons = new Dianda.COMMON.common();

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
                        url = "文档 > 我的文档 > 编辑目录";
                    }
                    if (tp == "1")
                    {
                        if (Session["Work_ProjectId"] != null)
                        {
                            url = "项目 > 我的项目 > 项目文档 > 编辑目录";
                        }
                        else
                        {
                            url = "文档 > 项目文档 > 编辑目录";
                        }
                    }
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = url;
                    //设置模板页中的管理值
                    string FID = Request["ID"];//url传值过来的参数
                    showInfo(FID, tp, projectid);
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
        private void showInfo(string FID, string tp, string projectid)
        {
            try
            {
                FID = commons.RequestSafeString(FID, 50);
                mdf = bdf.GetModel(int.Parse(FID));
                TextBox_FolderName.Text = mdf.FolderName.ToString();
               // RadioButtonList_isshare.SelectedValue = mdf.IsShare.ToString();
                showuserColumns(mdf.UserID.ToString(), tp, projectid);//加载栏目的结构
                showbuttom(mdf.UserID.ToString());
                DropDownList_upid.SelectedValue = mdf.UpID.ToString();
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
                string tp = Request["tp"];//url传值过来的页卡参数
                FID = commons.RequestSafeString(FID, 50);

                string oldPids =FID;//获取老的栏目ID
                string newPids=DropDownList_upid.SelectedItem.Value.ToString();//获取到新的父栏目的ID

                user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                 //进行编辑操作
                    string pid = DropDownList_upid.SelectedItem.Value.ToString();//选择的父栏目的ID
                    //根据父栏目的ID获取到栏目的路径

                    mdf2 = bdf.GetModel(int.Parse(FID));
                    mdf = bdf.GetModel(int.Parse(pid));

                    string paths = mdf.COLUMNSPATH.ToString() + "/" + FID.ToString();
                    mdf2.COLUMNSPATH = paths;
                    mdf2.DATETIME = DateTime.Now;
                    mdf2.DELFLAG = 0;
                    mdf2.FolderName = TextBox_FolderName.Text.ToString();
                    
                    mdf2.IMAGEURL = "";
                  //  mdf2.IsShare = int.Parse(RadioButtonList_isshare.SelectedItem.Value.ToString());
                    mdf2.PNAMES = mdf.PNAMES + ">" + mdf2.FolderName.ToString();
                    mdf2.ProjectID =mdf.ProjectID;
                    mdf2.SHUNXU = 0;
                    mdf2.SizeOf = "0";
                    mdf2.Types =mdf.Types;
                    mdf2.UpID = int.Parse(pid);

                    if (checkTheClass(oldPids, newPids))
                    {
                        //先处理子栏目的基本信息
                        modiySunClassInfo(oldPids, newPids);
                        //再处理自己
                        bdf.Update(mdf2);

                        //写日志
                        BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                        bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理编辑目录", "编辑" + TextBox_FolderName.Text.ToString() + ":成功");
                        //写日志
                        Button_sumbit.Enabled = false;
                        Button_sumbit.Visible = false;
                        string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");location.href='manage.aspx?CID=" + paths + "&tp=" + tp + "';</script>";
                        Response.Write(coutws);
                    }
                
            }
            catch
            {
                Button_sumbit.Enabled = false;
                Button_sumbit.Visible = false;
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
                    Label_notice.Text = "";
                }
                else
                {
                    Button_sumbit.Enabled = false;
                    Button_sumbit.Visible = false;
                    Label_notice.Text = "*每个用户仅能对自己创建的目录进行编辑！";
                }
            }
            catch
            {
                Button_sumbit.Enabled = false;
                Button_sumbit.Visible = false;
            }
        }

        /// <summary>
        /// 根据用户的ID，获取到这个自己的所有的
        /// </summary>
        /// <param name="userid"></param>
        private void showuserColumns(string userid, string tp, string projectid)
        {
            try
            {
                DataTable DT = new DataTable();
                if (tp == "0" || tp == "" || tp == null)
                {
                    DT = bdFExt.makeFolder(userid, "private", "");//获取自己的档案目录的数据
                }
                else if (tp == "1")
                {
                    DT = bdFExt.makeFolder_droplist(userid, "public", projectid);//获取自己的档案目录的数据
                }

                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        string parentid = DT.Rows[i]["UpID"].ToString();
                        string path = DT.Rows[i]["COLUMNSPATH"].ToString();
                        string Types = DT.Rows[i]["Types"].ToString();
                        string statusName = "";
                        if (Types == "public")
                        {
                            string status = DT.Rows[i]["status"].ToString();
                            string UpID = DT.Rows[i]["UpID"].ToString();
                            if (UpID == "38")
                            {
                                if (status == "3")
                                {
                                    statusName = "[暂停]";
                                }
                                else if (status == "5")
                                {
                                    statusName = "[完成]";
                                }
                                else
                                {
                                    statusName = "";
                                }
                            }

                        }
                        if (parentid != "0")
                        {
                            string kg = null;
                            int lens = path.Split('/').Length;
                            for (int x = 0; x < lens; x++)
                            {
                                kg += "··";
                            }
                            DT.Rows[i]["FolderName"] = kg + "|--" + DT.Rows[i]["FolderName"].ToString() + statusName;
                        }
                        ListItem L1 = new ListItem();
                        L1.Text = DT.Rows[i]["FolderName"].ToString();
                        L1.Value = DT.Rows[i]["ID"].ToString();
                        DropDownList_upid.Items.Add(L1);
                    }
                }
            }
            catch
            {
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
            string tp = Request["tp"];//url传值过来的页卡参数
            FID = commons.RequestSafeString(FID, 50);
            mdf2 = bdf.GetModel(int.Parse(FID));
            Response.Redirect("manage.aspx?CID=" + mdf2.COLUMNSPATH.ToString() + "&tp=" + tp);
        }
        /// <summary>
        /// 将栏目下面的子栏目同时归类到新的父栏目下面。其中包括COLUMNSPATH,PNAMES
        /// 此操作必须在栏目更新前进行，不能在更新后才操作
        /// </summary>
        /// <param name="oldPID"></param>
        /// <param name="newPID"></param>
        private void modiySunClassInfo(string oldPID, string newPID)
        {
            if (oldPID.Length > 0 && newPID.Length > 0)
            {
                try
                {
                    Model.Document_Folder mNewc_old = bdf.GetModel(int.Parse(oldPID));//获取老的栏目的基本信息
                    Model.Document_Folder mNewc_new = bdf.GetModel(int.Parse(newPID));//获取新的栏目的基本信息

                    //先根据老的父栏目，找出所有的子栏目的信息
                    string sqlwhere = "  COLUMNSPATH LIKE '" + mNewc_old.COLUMNSPATH.ToString() + "/%' and delflag='0'  order by COLUMNSPATH";
                    List<Model.Document_Folder> mNewslist = bdf.GetModelList(sqlwhere);
                    if (mNewslist.Count > 0)
                    {
                        for (int i = 0; i < mNewslist.Count; i++)
                        {
                            string oldClassPath = mNewc_old.COLUMNSPATH.ToString();//老栏目的路径、
                            string newClassPath = mNewc_new.COLUMNSPATH.ToString() + "/" + oldPID;//新栏目的路径
                            string oldClassNames = mNewc_old.PNAMES.ToString();//老栏目的父路径的名称
                            string newClassNames = mNewc_new.PNAMES.ToString() + ">" + mNewc_old.FolderName.ToString();//新栏目的父路径的名称

                            string modiyClassPath = mNewslist[i].COLUMNSPATH.ToString();//待操作的栏目的路径
                            string modiyClassNames = mNewslist[i].PNAMES.ToString();//待操作的栏目的名称
                            mNewslist[i].COLUMNSPATH = modiyClassPath.Replace(oldClassPath, newClassPath);
                            mNewslist[i].PNAMES = modiyClassNames.Replace(oldClassNames, newClassNames);

                            bdf.Update(mNewslist[i]);
                        }
                    }
                }
                catch
                {
                }
            }
        }
          /// <summary>
        /// 判断要操作的两个栏目ID之间的关系，如果新的父栏目是原被操作的栏目的子及孙栏目，则不能进行操作
        /// </summary>
        /// <param name="oldID"></param>
        /// <param name="newPid"></param>
        /// <returns>可以操作返回true,不能操作返回false</returns>
        private bool checkTheClass(string oldID,string newPid)
        {
            bool isdo = false;
            try
            {
                if (oldID.Length > 0 && newPid.Length > 0)
                {
                    Model.Document_Folder mNewc_old = bdf.GetModel(int.Parse(oldID));//获取老的栏目的基本信息
                    Model.Document_Folder mNewc_new = bdf.GetModel(int.Parse(newPid));//获取新的栏目的基本信息

                    string oldpath=mNewc_old.COLUMNSPATH.ToString();
                    string newpath=mNewc_new.COLUMNSPATH.ToString();
                    //1,原有的栏目往其祖父节点转移，可以做（即，原栏目中包括新栏目的路径）
                    //2,原有的栏目往其父节点的兄弟节点转移，可以做，（即，原栏目和新栏目没有包含关系）
                    //3,不能操作的是，父节点往子孙节点转移
                    if (newpath.Contains(oldpath))
                    {
                        isdo = false;
                        string coutws = "";
                        string urls = Request.RawUrl;
                        coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作失败！不能父节点转移到子孙节点\");location.href='" + urls + "';</script>";
                        Response.Write(coutws);
                    }
                    else
                    {
                        isdo = true;
                    }
                }
                else
                {
                    isdo = false;
                    string coutws = "";
                    string urls = Request.RawUrl;
                    coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作失败！不能父节点转移到子孙节点\");location.href='" + urls + "';</script>";
                    Response.Write(coutws);
                }
            }
            catch
            {
            }
            return isdo;
        }
    }
}
