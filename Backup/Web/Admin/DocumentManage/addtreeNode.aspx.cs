using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class addtreeNode : System.Web.UI.Page
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
                    string useridRequest = Request["userid"];//url传值过来的参数
                    string tp = Request["tp"];//url传值过来的页卡参数
                    showuserColumns(useridRequest,tp);
                    showbuttom(useridRequest);
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
                user_model= (Model.USER_Users)Session["USER_Users"];//获取操作者的SESSION
                if (user_model.ID.ToString() == useridRequest)
                {
                    //进行添加操作
                    string pid = DropDownList_upid.SelectedItem.Value.ToString();//选择的父栏目的ID
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
                    mdf2.ProjectID = null;
                    mdf2.SHUNXU = 0;
                    mdf2.SizeOf = "0";
                    mdf2.Types = "private";
                    mdf2.UpID =int.Parse(pid);
                    mdf2.UserID = useridRequest;
                    bdf.Add(mdf2);

                    //写日志
                    BLL.SYS_LogsExt bslog = new Dianda.BLL.SYS_LogsExt();
                    bslog.addlogs(user_model.REALNAME.ToString() + "(" + user_model.USERNAME.ToString() + ")", "档案管理新增目录", "新增" + TextBox_FolderName.Text.ToString() + ":成功");
                    //写日志
                    Button_sumbit.Enabled = false;
                    Button_sumbit.Visible = false;
                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");parent.parent.location.reload();parent.parent.GB_hide();</script>";
                    Response.Write(coutws);
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
        private void showuserColumns(string userid,string tp)
        {
            try
            {
                DataTable DT =new DataTable();
                if (tp == "0"||tp==""||tp==null)
                {
                    DT = bdFExt.makeFolder(userid, "private", "");//获取自己的档案目录的数据
                }
                else if (tp == "1")
                {
                    DT = bdFExt.makeFolder(userid, "public", "0");//获取自己的档案目录的数据
                }


                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        string parentid = DT.Rows[i]["UpID"].ToString();
                        string path = DT.Rows[i]["COLUMNSPATH"].ToString();
                        if (parentid != "0")
                        {
                            string kg = null;
                            int lens = path.Split('/').Length;
                            for (int x = 0; x < lens; x++)
                            {
                                kg += "··";
                            }
                            DT.Rows[i]["FolderName"] = kg + "|--" + DT.Rows[i]["FolderName"].ToString();
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
 
    }
}
