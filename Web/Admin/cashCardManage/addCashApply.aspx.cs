using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class addCashApply : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_Apply mCash_Apply = new Dianda.Model.Cash_Apply();
        BLL.Cash_Apply bCash_Apply = new Dianda.BLL.Cash_Apply();
    

        private static string _projectid;
        private static string _parentpage;

        public string projectid
        {
            get { return _projectid; }
            set { _projectid = value; }
        }

        public string parentpage
        {
            get { return _parentpage; }
            set { _parentpage = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //项目ID
                    //projectid = Session["Work_ProjectId"].ToString();

                    GetddlHour();
                    GetddlMin();
                    GetDateTime();
                    ///
                    Web.Admin.personalProjectManage.MakeProjectSession makeprojectsession = new Dianda.Web.Admin.personalProjectManage.MakeProjectSession();
                    makeprojectsession.getMyProjectList(this);

                    ////
                    GetddlProjectID();
                    GetddlCardName();
                    isShowSubmit();/////判断是否要显示确定按钮
                    if (Request.Params["parentpage"] != null && !String.IsNullOrEmpty(Request["parentpage"]))
                    {
                        parentpage = Request["parentpage"];
                    }
                    else
                    {
                        parentpage = "";
                    }
                    if (_parentpage == "manageCashApplyPerson")
                    {
                        /*设置模板页中的管理值*/
                        (Master.FindControl("Label_navigation") as Label).Text = "经费 > 经费预约 > 新建预约 ";
                        /*设置模板页中的管理值*/
                    }
                    else
                    {
                        /*设置模板页中的管理值*/
                        (Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 ";
                        /*设置模板页中的管理值*/
                    }

                }
            }
            catch
            {
            }
        }
        /// <summary>
        ///判断是否要显示确定按钮
        /// </summary>
        private void isShowSubmit()
        {
            try
            {
                if (ddlCardName.Items.Count > 0)
                {
                    Button_sumbit.Enabled = true;
                }
                else
                {
                    Button_sumbit.Enabled = false;
                }
            }
            catch
            {
                Button_sumbit.Enabled = false;
            }
        }
        private void GetDateTime()
        {
            DateTime dTime = DateTime.Now;
            this.txtGetDateTime.Value = dTime.Year + "-" + dTime.Month + "-" + dTime.Day;
            this.ddlHour.SelectedValue = dTime.Hour.ToString();
            this.ddlMin.SelectedValue = dTime.Minute.ToString();
        }

        private void GetddlHour()
        {
            for (int i = 0; i < 24; i++)
            {
                ListItem li = new ListItem(i.ToString("00"), i.ToString());
                this.ddlHour.Items.Add(li);
            }
        }

        private void GetddlMin()
        {
            for (int i = 0; i < 60; i++)
            {
                ListItem li = new ListItem(i.ToString("00"), i.ToString());
                this.ddlMin.Items.Add(li);
            }
        }

        private void GetddlProjectID()
        {
            try
            {
                DataTable dt = new DataTable();
                // string strSQL = "Select distinct(ProjectID),ProjectName From vProject_UserList";// Where UserID='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'";
                //dt = pageControl.doSql(strSQL).Tables[0];

                dt = (DataTable)Session["Project_Projects"];
                DataTable New_dt = new DataTable();
                New_dt.Columns.Add(new DataColumn("NAMES", System.Type.GetType("System.String")));
                New_dt.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int32")));

                foreach (DataRow _row in dt.Rows)
                {
                    object Delflag = _row["DELFLAG"];
                    object Status = _row["Status"];
                    object Names = _row["NAMES"];
                    object ID = _row["ID"];
                    if (Delflag.ToString() == "0" && Status.ToString() == "1")
                    {
                        New_dt.Rows.Add(new object[] { Names, ID });
                    }
                }
                if (New_dt.Rows.Count > 0)
                {
                    this.ddlProjectID.DataSource = New_dt;
                    this.ddlProjectID.DataTextField = "NAMES";
                    this.ddlProjectID.DataValueField = "ID";
                    this.ddlProjectID.DataBind();
                }
                else
                {
                    this.ddlProjectID.Items.Clear();
                    //this.ddlProjectID.Items.Add(new ListItem("无项目", ""));
 
                }
            }
            catch
            {
                this.ddlProjectID.Items.Clear();
                //this.ddlProjectID.Items.Add(new ListItem("无项目", ""));
            }
        }
        /// <summary>
        /// 获取资金卡的列表
        /// </summary>
        private void GetddlCardName()
        {
            try
            {
                string Dtime = DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dt = new DataTable();
                //string strSQL = "Select CardName+'['+CardNum+','+cast (LimitNums as varchar)+']' as CardName,ID From Cash_Cards Where Statas=1 and ProjectID=" + this.ddlProjectID.SelectedValue + " order by ID";
                string strSQL = "select CardName+'[ 编号: '+CardNum+' , 金额:'+cast (LimitNums as varchar)+']' + case when datediff(dd,cast('" + Dtime + " 00:00:00' as datetime),isnull(endtime,''))<0 then '（已过期）' else '' end as CardName,ID from Cash_Cards where statas=1 and ProjectID= " + this.ddlProjectID.SelectedValue + " order by id";

                dt = pageControl.doSql(strSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.ddlCardName.DataSource = dt;
                    this.ddlCardName.DataTextField = "CardName";
                    this.ddlCardName.DataValueField = "ID";
                    this.ddlCardName.DataBind();
                }
                else
                {
                    this.ddlCardName.Items.Clear();
                    //this.ddlCardName.Items.Add(new ListItem("无资金卡", ""));
                }
            }
            catch
            {
             
            }
        }

        /// <summary>
        ///点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string strLimitNums = (this.ddlCardName.SelectedItem.Text.Split(',')[1]).Split(']')[0];//cash表纪录的金额
                strLimitNums = strLimitNums.Split(':')[1];
                double dLimitNums = double.Parse(strLimitNums);
                string strApplyCount = this.txtApplyCount.Text;
                double dApplyCount = double.Parse(strApplyCount);
                string strGetDateTime = this.txtGetDateTime.Value;
                //DateTime dTimeInput = new DateTime(Int32.Parse(strGetDateTime.Split('-')[0]), Int32.Parse(strGetDateTime.Split('-')[1]), Int32.Parse(strGetDateTime.Split('-')[2]), Int32.Parse(this.ddlHour.SelectedValue), Int32.Parse(this.ddlMin.SelectedValue), 0);
                DateTime dTimeInput = Convert.ToDateTime(strGetDateTime + RadioButtonList_shijian.SelectedValue.ToString());
                //用途
                string UserFor = this.txtUseFor.Text.Trim();
                if (RBlist_YYLX.SelectedValue == "1")
                {
                    if (dApplyCount > dLimitNums)
                    {
                        tag.Text = "申请数额不能超过所选资金卡的余额！";
                        return;
                    }
                }
                //用途拼接字符串
                UserFor = "[" + RBlist_YYLX.SelectedItem.Text + "]" + UserFor;

                if (Convert.ToDateTime(Convert.ToDateTime(strGetDateTime).ToString("yyyy-MM-dd")) < Convert.ToDateTime(DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")))
                {
                    tag.Text = "经费预约必须提前二天，请电话联系相关人员！";
                    return;
                }
                mCash_Apply = new Dianda.Model.Cash_Apply();
                mCash_Apply.ProjectID = Int32.Parse(this.ddlProjectID.SelectedValue);
                mCash_Apply.CashCertificateID =this.ddlCardName.SelectedValue;
                mCash_Apply.ApplyCount = decimal.Parse(strApplyCount);
                mCash_Apply.GetDateTime = dTimeInput;
                mCash_Apply.UseFor = UserFor;
                mCash_Apply.ApplierTel = this.txtApplierTel.Text;
                mCash_Apply.ApplierID = ((Model.USER_Users)Session["USER_Users"]).ID;
                mCash_Apply.DATETIME = DateTime.Now;
                mCash_Apply.Statas = 0;//（0-待审核、1表示审核通过、2表示审核不通过）
                mCash_Apply.DoUserID = ((Model.USER_Users)Session["USER_Users"]).ID;

                bCash_Apply.Add(mCash_Apply);

                /*给业务申请者发信息*/
                Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

                mFaceShowMessage.DATETIME = DateTime.Now;
                mFaceShowMessage.FromTable = "经费预约";
                mFaceShowMessage.IsRead = 0;
                mFaceShowMessage.NewsID = null;
                mFaceShowMessage.NewsType = "经费预约";
                mFaceShowMessage.ReadTime = null;
                mFaceShowMessage.Receive = "经费预约";
                mFaceShowMessage.ProjectID = Int32.Parse(this.ddlProjectID.SelectedValue);
                mFaceShowMessage.DELFLAG = 0;
                //mFaceShowMessage.URLS = ((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME.ToString() + ")经费预约<a href='/Admin/cashCardManage/manageCashApply.aspx' target='_self' title='经费预约：提交时间" + DateTime.Now + "'>点击处理</a>";
                mFaceShowMessage.URLS = "<a href='/Admin/cashCardManage/manageCashApply.aspx' target='_self' title='经费预约：提交时间" + DateTime.Now + "'>经费预约  金额 " + dApplyCount + "</a>" + "  " + dTimeInput + " (" + ((Model.USER_Users)Session["USER_Users"]).REALNAME +")";
                bFaceShowMessage.Add(mFaceShowMessage);
                /*给业务申请者发信息*/

                Model.Cash_Cards mCash_Cards = new Dianda.Model.Cash_Cards();
                BLL.Cash_Cards bCash_Cards = new Dianda.BLL.Cash_Cards();
                mCash_Cards = bCash_Cards.GetModel(Int32.Parse(this.ddlCardName.SelectedValue));



                //添加操作日志
                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "添加经费预约", "预约" + dTimeInput + "时间取" + strApplyCount + "：成功");
                //添加操作日志

                //tag.Text = "操作成功！";
                string coutws = "";
                if (parentpage == "manageCashApplyPerson")
                {
                  //  coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manageCashApplyPerson.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"] + "&parentpage=" + Request["parentpage"] + "\";</script>";
                    coutws = "alert(\"操作成功！现在进入列表页面\"); location.href = \"manageCashApplyPerson.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"] + "&parentpage=" + Request["parentpage"]+"\";";
                    
                }
                else
                {
                   // coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manageCashApply.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"] + "\";</script>";
                    coutws = "alert(\"操作成功！现在进入列表页面\"); location.href = \"manageCashApply.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"] + "\";";
                }
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", coutws, true);
              //  Response.Write(coutws);
            }
            catch
            {
                tag.Text = "操作失败，请重试！";
            }
        }

        /// <summary>
        /// 点击取消按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            // Response.Write("<script>history.back()</script>");
            if (parentpage == "manageCashApplyPerson")
            {
                Response.Redirect("manageCashApplyPerson.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"] + "&parentpage=" + Request["parentpage"]);
            }
            else
            {
                Response.Redirect("manageCashApply.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"]);
            }
        }
        /// <summary>
        /// 静态页面刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetddlCardName();
            isShowSubmit();/////判断是否要显示确定按钮
        }
    }
}
