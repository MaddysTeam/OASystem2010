using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin
{
    public partial class OAmaster : System.Web.UI.MasterPage
    {
        Dianda.BLL.USER_Users usersBll = new Dianda.BLL.USER_Users();
        Dianda.Model.USER_Users userModel = new Dianda.Model.USER_Users();
        COMMON.common commons = new Dianda.COMMON.common();

        Model.userPower mUserPower = new Dianda.Model.userPower();//用户的权限实体类

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session["index_pages"] = null;
                    string urls = Request.FilePath.ToString();// //获取到当前的页面的URL
                    if (urls.Contains("department_Index.aspx"))
                    {
                        Session["index_pages"] = "1";
                    }
                    else
                    {
                        Session["index_pages"] =null;
                    }
                    //string ID = "1";
                    //MakeSession(ID);
                    Label_time.Text = commons.getDays("4");

                    //wult 2011-2-15 to alter
                    //当Label_navigation 显示的不是“部门主页”的时候，Master_DDList_BM 都不显示
                    if (Label_navigation.Text.ToString().Trim() != "部门主页")
                    {
                        Master_DDList_BMXZ.Visible = false;
                    }
                    else
                    {
                        Show_Master_DDList_BMXZ();
                    }

                    if (Session["USER_Users"] != null)
                    {
                        userModel = (Model.USER_Users)Session["USER_Users"];//实例化
                        Label_userReal.Text = userModel.REALNAME.ToString() + "(" + userModel.USERNAME.ToString() + ")";
                        sessionJudge();
                    }
                    else
                    {
                        string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
                        Response.Write(coutws);
                    }
                }
                 string urls2 = Request.FilePath.ToString();
                 if (urls2.Contains("/Admin/person_Index.aspx") || urls2.Contains("/Admin/department_Index.aspx"))
                {
                    bannerid.Attributes.Add("class", "master_label_small");
                    bannerid2.Width = "220px";
                }
                else
                {
                     bannerid.Attributes.Add("class","master_label");
                     bannerid2.Width = "1px";
                }
            }
            catch
            {
               // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"您目前已经登录超时！请重新登录！谢谢！\");location.href='/login.aspx';</script>";
               // Response.Write(coutws);
            }
        }

        /// <summary>
        /// 根据当前的用户SESSION判断功能
        /// </summary>
        private void sessionJudge()
        {
            try
            {
                mUserPower = (Model.userPower)Session["Session_Power"];
                //判断菜单的权限
                JudgeMenu(mUserPower.menuRole.ToString());
                //判断按钮的权限

                //判断页面的权限
                 JudgePage(mUserPower.pageurl.ToString());
            }
            catch
            {
            }
        }
        /// <summary>
        /// 判断才菜单的权限
        /// </summary>
        /// <param name="menusession"></param>
        private void JudgeMenu(string menusession)
        {
            try
            {
                if (menusession.Length > 0)
                {
                    string[] menuarray = menusession.Split(';');
                    for (int i = 0; i < menuarray.Length; i++)
                    {
                        string menuName = menuarray[i].ToString();
                        System.Web.UI.HtmlControls.HtmlTableRow tr = (System.Web.UI.HtmlControls.HtmlTableRow)this.form1.FindControl(menuName);
                        if (tr != null)
                        {
                            tr.Visible = true;
                        }
                       
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 判断按钮的权限
        /// </summary>
        /// <param name="buttonsession"></param>
        public void JudgeButton()
        {
            try
            {
                mUserPower = (Model.userPower)Session["Session_Power"];
                string buttonsession = mUserPower.buttomID.ToString();
                if (buttonsession.Length > 0)
                {
                    string[] buarray = buttonsession.Split(';');
                     string urls = Request.FilePath.ToString();// //获取到当前的页面的URL
                    for (int i = 0; i < buarray.Length; i++)
                    {
                        if (buarray[i].ToString().Contains(urls))
                        {
                            string[] arrays = buarray[i].ToString().Split(',');
                            string pageurl = arrays[0].ToString();
                            string buttonid = arrays[1].ToString();

                            LinkButton lb = (LinkButton)Page.FindControl(buttonid);
                            if (lb != null)
                            {
                                lb.Enabled = true;
                            }
                            else
                            {
                                Button bb = (Button)Page.FindControl(buttonid);
                                if (bb != null)
                                {
                                    bb.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 判断当前页的权限
        /// </summary>
        /// <param name="pagesession"></param>
        private void JudgePage(string pagesession)
        {
            try
            {
                bool isrole = false;
                if (pagesession.Length > 0)
                {
                    string[] buarray = pagesession.Split(';');
                    string urls = Request.FilePath.ToString();// //获取到当前的页面的URL
                    for (int i = 0; i < buarray.Length; i++)
                    {
                        if (buarray[i].ToString().Contains(urls))
                        {
                            isrole = true;
                            break;
                        }
                    }
                    if (urls == "/Admin/error.aspx")
                    {
                        isrole = true;
                    }
                }
                if (isrole)
                {
                  LinkButton1.Visible = false;
                }
                else
                {
                    //从WEBCONFIG中获取到当前是否要做权限的控制。
                    string isroles = System.Configuration.ConfigurationManager.AppSettings["rolecontrol"];
                    if (isroles == "1")
                    {
                        string urls = Request.FilePath.ToString();// //获取到当前的页面的URL
                        LinkButton1.Visible = true;
                        TextBox2.Text = urls;
                        rolecontrol.Visible = false;
                    }
                    else
                    {
                        rolecontrol.Visible = false;
                        Response.Redirect("/Admin/error.aspx");
                    }
                   
                }
            }
            catch
            {
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Model.USER_Role mur = new Dianda.Model.USER_Role();
            BLL.USER_Role bur = new Dianda.BLL.USER_Role();
            mur.DELFLAG = 0;
            mur.NAME = TextBox1.Text.ToString();
            mur.Roles = TextBox2.Text.ToString();
            mur.Types = "页面权限";
            mur.UpID = 0;
            bur.Add(mur);
        }

        //为Master_DDList_BMXZ赋值
        protected void Show_Master_DDList_BMXZ()
        {
            userModel = (Model.USER_Users)Session["USER_Users"];

            string DepartMentID = userModel.DepartMentID;
            string DepartMentName = userModel.DepartMentName;

            string[] DepartMentID_arr = DepartMentID.Split(',');
            string[] DepartMentName_arr = DepartMentName.Split(',');

            for (int i = 0; i < DepartMentID_arr.Length; i++)
            {
                Master_DDList_BMXZ.Items.Add(new ListItem(DepartMentName_arr[i],DepartMentID_arr[i]));
            }

            userModel = (Model.USER_Users)Session["USER_Users"];

            string temp4 = userModel.TEMP4.ToString();
            if (temp4 == "")
            {
                temp4 = Master_DDList_BMXZ.SelectedValue.ToString();
                userModel.TEMP4 = temp4;
                Session["USER_Users"] = userModel;
            }
            try
            {
                Master_DDList_BMXZ.SelectedValue = temp4;
            }
            catch { }
        }

        //切换时为Session["USER_Users"]的temp4 更改默认值
        protected void Master_DDList_BMXZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            userModel = (Model.USER_Users)Session["USER_Users"];

            userModel.TEMP4 = Master_DDList_BMXZ.SelectedValue.ToString();

            Session["USER_Users"] = userModel;

            Response.Redirect("/Admin/department_Index.aspx");

        }

    }
}
