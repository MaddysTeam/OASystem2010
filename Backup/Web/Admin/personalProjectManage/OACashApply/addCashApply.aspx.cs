using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAproject
{
    public partial class addCashApply : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_Apply mCash_Apply = new Dianda.Model.Cash_Apply();
        BLL.Cash_Apply bCash_Apply = new Dianda.BLL.Cash_Apply();

        private static string _projectid;

        public string projectid
        {
            get { return _projectid; }
            set { _projectid = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //项目ID
                    projectid = Session["Work_ProjectId"].ToString();

                    this.Button_sumbit.Visible = true;
                    this.Button_cancel.Visible = true;

                    GetddlHour();
                    GetddlMin();
                    GetDateTime();
                    GetddlProjectID();
                    GetddlCardName();
                    /*设置模板页中的管理值*/
                    (Master.FindControl("Label_navigation") as Label).Text = "项目 > 我的项目 > 项目经费 > 新建预约 ";
                    /*设置模板页中的管理值*/
                }
            }
            catch
            {
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
                //string strSQL = "Select distinct(ProjectID),ProjectName From vProject_UserList Where ProjectID=" + _projectid;
                string strSQL = "Select distinct(ID) as ProjectID,NAMES as ProjectName From Project_Projects Where ID=" + _projectid;
                dt = pageControl.doSql(strSQL).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.ddlProjectID.DataSource = dt;
                    this.ddlProjectID.DataTextField = "ProjectName";
                    this.ddlProjectID.DataValueField = "ProjectID";
                    this.ddlProjectID.DataBind();
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

        private void GetddlCardName()
        {
            string Dtime = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            
            //modify by wangjh on 2011-06-23 begin

            //修改的目的是为了防止资金卡金额LimitNums在转换面varchar呈现科学计数法
            //string strSQL = "select CardName+'['+CardNum+','+cast (LimitNums as varchar)+']'+ case when datediff(dd,cast('" + Dtime + " 00:00:00' as datetime),isnull(endtime,''))<0 then '（已过期）' else '' end as CardName,ID from Cash_Cards where statas=1 and ProjectID= " + this.ddlProjectID.SelectedValue + " order by id";
            string strSQL = "select CardName+'['+CardNum+','+ CAST(CAST(LimitNums AS numeric(15, 0)) AS varchar) +']'+ case when datediff(dd,cast('" + Dtime + " 00:00:00' as datetime),isnull(endtime,''))<0 then '（已过期）' else '' end as CardName,ID from Cash_Cards where statas=1 and ProjectID= " + this.ddlProjectID.SelectedValue + " order by id";

            //modify by wangjh on 2011-06-23 end

            dt = pageControl.doSql(strSQL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.ddlCardName.DataSource = dt;
                this.ddlCardName.DataTextField = "CardName";
                this.ddlCardName.DataValueField = "ID";
                this.ddlCardName.DataBind();
                Button_sumbit.Enabled = true;
            }
            else
            {
                Button_sumbit.Enabled = false;
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
                double dLimitNums = double.Parse(strLimitNums);
                string strApplyCount = this.txtApplyCount.Text;
                double dApplyCount = double.Parse(strApplyCount);
                string strGetDateTime = this.txtGetDateTime.Value;
               // DateTime dTimeInput = new DateTime(Int32.Parse(strGetDateTime.Split('-')[0]), Int32.Parse(strGetDateTime.Split('-')[1]), Int32.Parse(strGetDateTime.Split('-')[2]), Int32.Parse(this.ddlHour.SelectedValue), Int32.Parse(this.ddlMin.SelectedValue), 0);
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
                mFaceShowMessage.URLS = ((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME.ToString() + ")经费预约<a href='/Admin/cashCardManage/manageCashApply.aspx' target='_self' title='经费预约：提交时间"+DateTime.Now +"'>点击处理</a>";
                bFaceShowMessage.Add(mFaceShowMessage);
                /*给业务申请者发信息*/

                // tag.Text = "操作成功！";
                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manageCashApply.aspx?pageindex=" + Request["pageindex"] + "\";</script>";
                Response.Write(coutws);

                //添加操作日志
                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "添加经费预约", "预约" + dTimeInput + "时间取" + strApplyCount + "：成功");
                //添加操作日志
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
            Response.Redirect("manageCashApply.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"]);
        }


        protected void ddlProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetddlCardName();
        }
    }
}
