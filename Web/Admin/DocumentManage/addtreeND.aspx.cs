using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class addtreeND : System.Web.UI.Page
    {
        Model.USER_Users user_model = new Dianda.Model.USER_Users();
        Model.Document_Folder mdf = new Dianda.Model.Document_Folder();
        BLL.Document_Folder bdf = new Dianda.BLL.Document_Folder();
        BLL.Document_FolderExt bdFExt = new Dianda.BLL.Document_FolderExt();
        Model.Document_Folder mdf2 = new Dianda.Model.Document_Folder();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string projectid = "";
                    string url = "";
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
                   
                    if (tp == "" || tp == null||tp=="0")
                    {
                       // url = "文档 > 我的文档 > 新建目录";
                        if (Session["Work_ProjectId"] != null)
                        {
                            url = "项目 > 我的项目 > 项目文档 > 新建目录";
                        }
                        else
                        {
                            url = "文档 > 我的文档 > 新建目录";
                        }
                    }
                    if (tp == "1")
                    {
                        if (Session["Work_ProjectId"] != null)
                        {
                            url = "项目 > 我的项目 > 项目文档 > 新建目录";
                        }
                        else
                        {
                            url = "文档 > 项目文档 > 新建目录";
                        }
                    }
                    //if (Session["Work_ProjectId"] != null)
                    //{
                    //    url = "项目 > 我的项目 > 项目文档 > 新建目录";
                    //}
                    //else
                    //{
                    //    url = "文档 > 项目文档 > 新建目录";
                    //}
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = url;
                    //设置模板页中的管理值
                    string useridRequest = Request["userid"];//url传值过来的参数
                     showbuttom(useridRequest);
                     showuserColumns(useridRequest, tp, projectid);
                     string upid = Request["upid"];
                     if (upid != null && upid != "")
                     {
                         DropDownList_upid.SelectedValue = upid;
                     }
                     chushihua();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 提交新建目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string useridRequest = Request["userid"];//url传值过来的参数
                string tp = Request["tp"];//url传值过来的页卡参数
                user_model = (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                if (user_model.ID.ToString() == useridRequest)
                {
                    //进行添加操作
                    string pid = DropDownList_upid.SelectedItem.Value.ToString();//选择的父栏目的ID
                    if (pid != "38")
                    {

                        //根据父栏目的ID获取到栏目的路径
                        mdf = bdf.GetModel(int.Parse(pid));
                        int ids = bdf.GetMaxId();
                        string paths = mdf.COLUMNSPATH.ToString() + "/" + ids.ToString();
                        mdf2.COLUMNSPATH = paths;
                        mdf2.DATETIME = DateTime.Now;
                        mdf2.DELFLAG = 0;
                        mdf2.FolderName = TextBox_FolderName.Text.ToString();
                        mdf2.ID = ids;
                        mdf2.IMAGEURL = "";
                        mdf2.IsShare = int.Parse(RadioButtonList_isshare.SelectedItem.Value.ToString());
                        mdf2.PNAMES = mdf.PNAMES + ">" + mdf2.FolderName.ToString();
                        mdf2.ProjectID = mdf.ProjectID;
                        mdf2.SHUNXU = 0;
                        mdf2.SizeOf = "0";
                        mdf2.Types = mdf.Types;// "private";
                        mdf2.UpID = int.Parse(pid);
                        mdf2.UserID = useridRequest;
                        bdf.Add(mdf2);

                        //写日志
                        BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                        bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理新增目录", "新增" + TextBox_FolderName.Text.ToString() + ":成功");
                        //写日志
                        Button_sumbit.Enabled = false;
                        Button_sumbit.Visible = false;
                        string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");location.href='manage.aspx?CID=" + paths + "&tp=" + tp + "';</script>";
                        Response.Write(coutws);
                    }
                    else
                    {
                        Button_sumbit.Enabled = false;
                        Button_sumbit.Text = "请选择您所参与的项目";
                    }
                }
                else
                {
                    //不能给其他人添加目录
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
        /// 根据用户的ID，获取到这个自己的所有的
        /// </summary>
        /// <param name="userid"></param>
        private void showuserColumns(string userid,string tp,string projectid)
        {
            try
            {
                DataTable DT = new DataTable();
                if (Session["Work_ProjectId"] != null)
                {
                    DT = bdFExt.makeFolder_droplist(userid, "public", projectid);//获取自己的档案目录的数据
                }
                else
                {
                    if (tp == "0" || tp == "" || tp == null)
                    {
                        DT = bdFExt.makeFolder(userid, "private", "");//获取自己的档案目录的数据
                    }
                    else if (tp == "1")
                    {
                        DT = bdFExt.makeFolder_droplist(userid, "public", projectid);//获取自己的档案目录的数据
                    }
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
                            string UpID= DT.Rows[i]["UpID"].ToString();
                            if(UpID=="38")
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
                    Button_sumbit.Visible = true;
                }
                else
                {
                    DropDownList_upid.Visible = false;
                    Button_sumbit.Visible = false;
                    Label_notice.Text = "*您目前没有任何项目，现在不能添加项目文档！";
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
            string tp = Request["tp"];//url传值过来的页卡参数
            string id = Request["upid"];//根据要创建子目录的目录ID，获取到该目录的路径
            if (id != null && id != "")
            {
                mdf = bdf.GetModel(int.Parse(id));
                if (mdf != null)
                {
                    id = mdf.COLUMNSPATH.ToString();
                }
            }
            Response.Redirect("manage.aspx?tp=" + tp + "&CID=" + id);
        }
        /// <summary>
        /// 如果当前的下拉框选择的是根目录，则不能添加分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_upid_SelectedIndexChanged(object sender, EventArgs e)
        {
            chushihua();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void chushihua()
        {
            string upid = DropDownList_upid.SelectedValue.ToString();
            if (upid == "38")
            {
                Button_sumbit.Enabled = false;
                Button_sumbit.Text = "请选择您所参与的项目";
            }
            else
            {
                Button_sumbit.Enabled = true;
                Button_sumbit.Text = " 确定 ";
            }
        }
    }
}
