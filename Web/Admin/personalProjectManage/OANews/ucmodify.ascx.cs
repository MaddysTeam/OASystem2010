using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OANews
{
    public partial class ucmodify : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.USER_Users mUSER_Users = new Dianda.Model.USER_Users();
        BLL.USER_Users bUSER_Users = new Dianda.BLL.USER_Users();
        BLL.News_Columns bNews_Columns = new Dianda.BLL.News_Columns();
        BLL.News_News bNews_News = new Dianda.BLL.News_News();
        Model.News_News mNews_News = new Dianda.Model.News_News();
        BLL.News_LimitUser bNews_LimitUser = new Dianda.BLL.News_LimitUser();
        Model.News_LimitUser mNews_LimitUser = new Dianda.Model.News_LimitUser();
        COMMON.common common = new COMMON.common();

        private string _foritems;
        private string _projectid;
        private string _parentid;
        private string _limitschoose;

        public string foritems
        {
            get { return _foritems; }
            set { _foritems = value; }
        }

        public string projectid
        {
            get { return _projectid; }
            set { _projectid = value; }
        }

        public string parentid
        {
            get { return _parentid; }
            set { _parentid = value; }
        }

        public string limitschoose
        {
            get { return _limitschoose; }
            set { _limitschoose = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目ID
                projectid = Session["Work_ProjectId"].ToString();

                string id = Request["id"].ToString();
                foritems = Request["ForItems"].ToString();
                parentid = Request["PARENTID"].ToString();
                limitschoose = Request["LimitsChooseID"].ToString();
                // 默认NEWS
                if (String.IsNullOrEmpty(_foritems))
                {
                    _foritems = "NEWS";
                }
                DataTable dt = new DataTable();
                string sql = "SELECT UserID FROM News_LimitUser WHERE NewsID=" + id;
                dt = pageControl.doSql(sql).Tables[0];
                Session["UserID"] = dt;
                mNews_News = new Dianda.Model.News_News();
                mNews_News = bNews_News.GetModel(Int32.Parse(id));
                this.txtNAME.Text = mNews_News.NAME;
                this.FCKeditor_neirong.Value = mNews_News.CONTENTS;


                GetddlPARENTID();
                GetrblLimitsChoose();
                BindDataList();
            }
        }

        private void GetddlPARENTID()
        {
            DataTable dt = new DataTable();
            if (_foritems == "NEWS")//[新闻] 显示个人消息 通知公告
            {
                dt = bNews_Columns.GetList("PARENTID=1").Tables[0];
                this.ddlPARENTID.DataSource = dt;
                this.ddlPARENTID.DataTextField = "NAME";
                this.ddlPARENTID.DataValueField = "ID";
                this.ddlPARENTID.DataBind();
            }
            else if (_foritems == "PROJECT")//[项目]项目组成员
            {
                dt = bNews_Columns.GetList("PARENTID=2").Tables[0];
                this.ddlPARENTID.DataSource = dt;
                this.ddlPARENTID.DataTextField = "NAME";
                this.ddlPARENTID.DataValueField = "ID";
                this.ddlPARENTID.DataBind();
            }
            else if (_foritems == "DEPARTMENT")//[部门]本部门成员
            {
                dt = bNews_Columns.GetList("PARENTID=3").Tables[0];
                this.ddlPARENTID.DataSource = dt;
                this.ddlPARENTID.DataTextField = "NAME";
                this.ddlPARENTID.DataValueField = "ID";
                this.ddlPARENTID.DataBind();
            }
            this.ddlPARENTID.SelectedValue = _parentid;
        }

        private void GetrblLimitsChoose()
        {
            if (_foritems == "NEWS")//[新闻]本部门成员,全员
            {
                ListItem li = new ListItem("本部门成员", "1");
                li.Selected = true;
                this.rblLimitsChoose.Items.Add(li);
                li = new ListItem("全员", "2");
                this.rblLimitsChoose.Items.Add(li);
            }
            else if (_foritems == "PROJECT")//[项目]项目组成员
            {
                ListItem li = new ListItem("项目组成员", "3");
                li.Selected = true;
                this.rblLimitsChoose.Items.Add(li);
            }
            else if (_foritems == "DEPARTMENT")//[部门]本部门成员
            {
                ListItem li = new ListItem("本部门成员", "1");
                li.Selected = true;
                this.rblLimitsChoose.Items.Add(li);
            }
            this.rblLimitsChoose.SelectedValue = _limitschoose;
            this.rblLimitsChoose.Visible = false;
        }

        private void BindDataList()
        {
            //调用控件
            string type = "";
            type = rblLimitsChoose.SelectedValue.ToString();

            if (type != "")
            {
                UserManage1.Type = type;

                DataTable dt = (DataTable)Session["UserID"];
                string SelectVal = "";
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (SelectVal == "")
                        {
                            SelectVal = dt.Rows[i]["UserID"].ToString();
                        }
                        else
                        {
                            SelectVal += "," + dt.Rows[i]["UserID"].ToString();
                        }
                    }
                }

                UserManage1.SelectVal = SelectVal;
                UserManage1.Projectid = projectid;
                UserManage1.Show_GView_UserManage();
            }
        }

        /// <summary>
        ///点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            string NAME = this.txtNAME.Text;//获取到用户名
            if (NAME != "" && NAME != null)
            {
                try
                {


                    mNews_News = new Dianda.Model.News_News();
                    mNews_News = bNews_News.GetModel(Int32.Parse(Request["id"]));
                    mNews_News.NAME = txtNAME.Text;
                    mNews_News.PARENTID = Int32.Parse(ddlPARENTID.SelectedValue);
                    mNews_News.DATETIME = DateTime.Now;
                    mNews_News.CONTENTS = this.FCKeditor_neirong.Value;
                    // mNews_News.TYPE = 0;
                    mNews_News.KEYWORD = txtNAME.Text;
                    mNews_News.WRITER = ((Model.USER_Users)Session["USER_Users"]).USERNAME;
                    //mNews_News.FILEUP = "";//上传附件/AllFileUp/admin/news/目录下
                    mNews_News.UPTOP = 0;
                    mNews_News.DELFLAG = 0;
                    mNews_News.ISPASS = 0;//是否通过审核（默认0，1表示通过审核,2表示审核不通过）添加新闻时，需要根据选择栏目的审核设定进行赋值
                    mNews_News.LimitsChoose = Int32.Parse(this.rblLimitsChoose.SelectedValue);
                    bNews_News.Update(mNews_News);

                    string strSQL = "DELETE FROM News_LimitUser WHERE NewsID=" + common.cleanXSS(Request["id"]);
                    pageControl.doSql(strSQL);

                    // 添加News_LimitUser
                    ArrayList arrUserID = UserManage1.getSelectUser();

                    // 清除旧信息
                    string strSQL2 = "Update FaceShowMessage set Delflag=1 Where NewsType='项目消息' and URLS like '%id=" + common.cleanXSS(Request["id"]) + "''%'";
                    pageControl.doSql(strSQL2);

                    if (arrUserID.Count > 0)
                    {
                        for (int k = 0; k < arrUserID.Count; k++)
                        {
                            mNews_LimitUser = new Dianda.Model.News_LimitUser();
                            mNews_LimitUser.ID = bNews_LimitUser.GetMaxId();
                            mNews_LimitUser.UserID = arrUserID[k].ToString();
                            mNews_LimitUser.NewsID = Int32.Parse(Request["id"]);
                            mNews_LimitUser.IsRead = 0;
                            bNews_LimitUser.Add(mNews_LimitUser);

                            /*给业务申请者发信息*/
                            Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                            BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();



                            mFaceShowMessage.DATETIME = DateTime.Now;
                            // mFaceShowMessage.FromTable = this.ddlPARENTID.SelectedItem.Text;
                            mFaceShowMessage.FromTable = "项目消息";
                            mFaceShowMessage.IsRead = 0;
                            mFaceShowMessage.NewsID = null;
                            //mFaceShowMessage.NewsType = this.ddlPARENTID.SelectedItem.Text;
                            mFaceShowMessage.NewsType = "项目消息";
                            mFaceShowMessage.ReadTime = null;
                            mFaceShowMessage.Receive = arrUserID[k].ToString();
                            //mFaceShowMessage.URLS = ((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME.ToString() + ")给您发送了[" + this.ddlPARENTID.SelectedItem.Text + "]！<a href='/Admin/newsManage/OAnews/show.aspx?id=" + intMaxID + "' target='_self' rel='gb_page_center[726,400]' title='查看详细'>点击查看</a>";
                            mFaceShowMessage.URLS = " <a href=\"javascript:window.showModalDialog('/Admin/newsManage/OAnews/show.aspx?id=" + Request["id"] + " ','','dialogWidth=726px;dialogHeight=400px');\" target='_self'  title='发布时间:" + DateTime.Now.ToString() + "'>" + NAME + "</a>&nbsp;" + ddlPARENTID.SelectedItem.Text + "&nbsp;项目消息&nbsp;(" + ((Model.USER_Users)Session["USER_Users"]).REALNAME.ToString() + ")";
                            mFaceShowMessage.ProjectID = int.Parse(Session["Work_ProjectId"].ToString());
                            mFaceShowMessage.DELFLAG = 0;

                            bFaceShowMessage.Add(mFaceShowMessage);
                            /*给业务申请者发信息*/
                        }
                    }
                    //tag.Text = "操作成功！";
                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"] + "\";</script>";
                    Response.Write(coutws);

                    //添加操作日志
                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                    bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "添加新闻", "添加成功");
                    //添加操作日志
                }
                catch
                {
                    tag.Text = "操作失败，请重试！";
                }
            }
            else
            {
                tag.Text = "操作失败，标题不能为空！";
            }
        }

        /// <summary>
        /// 点击重置按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx");
        }

        /// <summary>
        /// 点击取消按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            // Response.Write("<script>history.back()</script>");
            Response.Redirect("manage.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"]);
        }


        /// <summary>
        /// 本部门成员,全员,项目组成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rblLimitsChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataList();
        }

    }
}