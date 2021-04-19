using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OACashApply
{
    public partial class add : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        BllExt.Cash_Account_Subscription bllextCash_Account_Subscription = new Dianda.BllExt.Cash_Account_Subscription();
        Model.Cash_Apply modelCash_Apply = new Dianda.Model.Cash_Apply();
        BLL.Cash_Apply bllCash_Apply = new Dianda.BLL.Cash_Apply();

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
        /// <summary>
        /// 返回的路径
        /// </summary>
        public string ReturnPage
        {
            get
            {
                if (ViewState["ReturnPage"] != null)
                    return ViewState["ReturnPage"].ToString();
                return null;
            }
            set { ViewState["ReturnPage"] = value; }
        }
        /// <summary>
        /// 预约ID
        /// </summary>
        public string ApplyID
        {
            get
            {
                if (ViewState["ApplyID"] != null)
                    return ViewState["ApplyID"].ToString();
                return null;
            }
            set { ViewState["ApplyID"] = value; }
        }
        /// <summary>
        /// 外部传入的值
        /// </summary>
        public string SetKey
        {
            get
            {
                if (ViewState["SetKey"] != null)
                    return ViewState["SetKey"].ToString();
                return null;
            }
            set { ViewState["SetKey"] = value; }
        }

        const string ManageCashApplyPersonPage = "/admin/cashCardManage/manageCashApplyPerson.aspx";
        const string ManageCashApplyPage = "/admin/personalProjectManage/OACashApply/manageCashApply.aspx";
        const string cashCardManageManageCashApplyPage = "/admin/cashCardManage/manageCashApply.aspx";
        const string _TypeAdd = "0";
        const string _TypeThrough = "1";
        const string _TypeUnthread = "2";
        const string _TypeDone = "3";

        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(add), this.Page);
            if (!IsPostBack)
            {
                Button[] SonBtn = new Button[] { };
                if (Request["ApplyID"] != null)
                {
                    ApplyID = Request["ApplyID"];
                    modelCash_Apply = bllCash_Apply.GetModel(int.Parse(ApplyID));
                }

                if (Request.Params["parentpage"] != null && !String.IsNullOrEmpty(Request["parentpage"]))
                {
                    parentpage = Request["parentpage"];
                }
                else
                {
                    parentpage = "";
                }
                ShowButtonVisibleFalse();       //按钮全部不可见，按条件显示
                if (_parentpage == "manageCashApplyPerson")
                {
                    /*设置模板页中的管理值*/
                    (Master.FindControl("Label_navigation") as Label).Text = "经费 > 经费预约 > 新建预约 ";
                    /*设置模板页中的管理值*/
                    ReturnPage = ManageCashApplyPersonPage;
                    SonBtn = new Button[] { Button_sumbit };
                }
                else if (_parentpage == "cashCardManageManageCashApplyPage")
                {
                    string key = "";            //按key值显示按钮
                    if (Request["key"] != null)
                        SetKey = Request["key"];
                    /*设置模板页中的管理值*/
                    if (SetKey == "1")
                    {
                        (Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 > 预约审核 ";
                        if (modelCash_Apply.Statas == 0)
                        {
                            SonBtn = new Button[] { Btn_Through, Btn_Unthread };
                            Pan_AuditOpinion.Visible = true;
                        }
                    }
                    else if (SetKey == "2")
                    {
                        (Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 > 审核完成 ";
                        if (modelCash_Apply.Statas == 1)
                            SonBtn = new Button[] { Btn_Done };
                    }
                    /*设置模板页中的管理值*/
                    ReturnPage = cashCardManageManageCashApplyPage;
                }
                else
                {
                    /*设置模板页中的管理值*/
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 ";
                    /*设置模板页中的管理值*/
                    ReturnPage = ManageCashApplyPage;
                    SonBtn = new Button[] { Button_sumbit };

                    string ProjectID = "";
                    if (Session["Work_ProjectId"] != null)
                        ProjectID = Session["Work_ProjectId"].ToString();

                    FeeAppointment1.setProjectID = ProjectID;
                }

                //调用自定义控件事件
                if (Session["USER_Users"] == null)
                    return;

                FeeAppointment1.UserName = ((Model.USER_Users)Session["USER_Users"]).USERNAME;
                FeeAppointment1.UserID = ((Model.USER_Users)Session["USER_Users"]).ID;
                FeeAppointment1.SetKey = SetKey;
                if (modelCash_Apply.ID != 0)
                {
                    setValue(modelCash_Apply);
                    FeeAppointment1._modelCash_Apply = modelCash_Apply;
                }
                FeeAppointment1.Show();

                //获取项目下拉列表
                //GetddlProjectID();

                ShowButtonVisibleTrue(SonBtn);
            }
        }
        public void ShowButtonVisibleFalse()
        {
            Button[] BtnArr = { Button_sumbit, Btn_Through, Btn_Unthread, Btn_Done };
            for (int i = 0; i < BtnArr.Length; i++)
            {
                BtnArr[i].Visible = false;
            }
        }
        public void ShowButtonVisibleTrue(Button[] _btn)
        {
            for (int i = 0; i < _btn.Length; i++)
            {
                _btn[i].Visible = true;
            }
        }

        /// <summary>
        /// 获取项目下拉列表值
        /// </summary>
        private void GetddlProjectID()
        {
            try
            {
                if (FeeAppointment1.ProjectCount > 0)
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

        /// <summary>
        /// 点击取消按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ReturnPage))
                Response.Redirect(ReturnPage + "?" + ReturnCS());
        }

        public void setValue(Model.Cash_Apply _modelCash_Apply)
        {
            string[] GetDateTime = DateTime.Parse(_modelCash_Apply.GetDateTime.ToString()).ToString("yyyy-MM-dd HH:mm:ss").Split(' ');
            txtGetDateTime.Value = GetDateTime[0];
            try { RadioButtonList_shijian.Items.FindByValue(" " + GetDateTime[1]).Selected = true; }
            catch { }
            txtUseFor.Text = _modelCash_Apply.UseFor;
            txtUseFor.Enabled = false;
            RadioButtonList_shijian.Enabled = false;
        }

        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                tag.Text = "";
                string coutws = "";
                FeeAppointment1.SetValue();
                string ProjectID = FeeAppointment1.setProjectID;
                string CashCertificateID = FeeAppointment1.setCardListID;
                string CarDetails = FeeAppointment1.setCarDetails;
                string ApplyCount = FeeAppointment1.setApplyCount;
                string GetDateTime = txtGetDateTime.Value;
                DateTime dTimeInput = Convert.ToDateTime(GetDateTime + RadioButtonList_shijian.SelectedValue.ToString());
                string UseFor = txtUseFor.Text;
                string ApplierTel = txtApplierTel.Text;
                string ApplierID = ((Model.USER_Users)Session["USER_Users"]).ID;
                string str = FeeAppointment1.setTolStr;
                string SpecialFundsID = FeeAppointment1.setSpecialFundsID;
                string Attribute = FeeAppointment1.setAttribute;
                string Temp2 = FeeAppointment1.setTemp2;

                modelCash_Apply.ProjectID = int.Parse(ProjectID);
                modelCash_Apply.CashCertificateID = CashCertificateID;
                modelCash_Apply.ApplyCount = decimal.Parse(ApplyCount);
                modelCash_Apply.GetDateTime = dTimeInput;
                modelCash_Apply.UseFor = UseFor;
                modelCash_Apply.ApplierTel = ApplierTel;
                modelCash_Apply.ApplierID = ApplierID;
                modelCash_Apply.DATETIME = DateTime.Now;
                modelCash_Apply.Statas = 0;//（0-待审核、1表示审核通过、2表示审核不通过）
                modelCash_Apply.DoUserID = ((Model.USER_Users)Session["USER_Users"]).ID;
                modelCash_Apply.CarDetails = CarDetails;
                modelCash_Apply.SpecialFundsID = int.Parse(SpecialFundsID);
                modelCash_Apply.Attribute = Attribute;
                modelCash_Apply.TEMP1 = str;
                modelCash_Apply.TEMP2 = Temp2;

                bool B = bllextCash_Account_Subscription.OperationAccount(str, GetDateTime, "1");
                if (B)
                {
                    bllCash_Apply.Add(modelCash_Apply);

                    SendMessage("0", modelCash_Apply);

                    coutws = "alert(\"操作成功！现在进入列表页面\"); ";
                }
                else
                {
                    coutws = "alert(\"操作失败，申请金额超标！现在返回列表页面\"); ";
                }
                coutws += "location.href = \"" + ReturnPage + "?" + ReturnCS() + "\";";

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", coutws, true);
            }
            catch
            {
                tag.Text = "操作失败，请重试！";
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        public void SendMessage(string SendType, Model.Cash_Apply modelCash_Apply)
        {
            /*给业务申请者发信息*/
            Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
            BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();
            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

            string SendName = "", SendUrl = "", doType = "", results = "", Receive = "";
            string ApplyCount = modelCash_Apply.ApplyCount.ToString();
            string dTimeInput = modelCash_Apply.GetDateTime.ToString();
            string Attribute = modelCash_Apply.Attribute == "0" ? "资金卡：" : "专项资金：";
            string NameStr = Attribute + modelCash_Apply.TEMP2;
            string AuditOpinion = (!string.IsNullOrEmpty(modelCash_Apply.AuditOpinion)) ? "（" + modelCash_Apply.AuditOpinion + "）" : "";

            switch (SendType)
            {
                case _TypeAdd:   //经费预约
                    doType = "添加经费预约";
                    results = "预约" + dTimeInput + "时间取" + ApplyCount;
                    SendName = "经费预约";
                    SendUrl = "<a href='/Admin/cashCardManage/manageCashApply.aspx' target='_self' title='经费预约：提交时间" + DateTime.Now + "'>经费预约  金额 " + ApplyCount + "</a>" + "  " + dTimeInput + " (" + user_model.REALNAME + ")";
                    break;
                case _TypeThrough:   //预约审核通过
                    doType = "审核经费预约";
                    results = "审核预约(申请额度" + ApplyCount + "在" + dTimeInput + ")通过";
                    SendName = "申请情况";
                    Receive = modelCash_Apply.ApplierID;
                    SendUrl = "<a href='/Admin/cashCardManage/manageCashApplyPerson.aspx?status=1' target='_self' title='经费预约：提交时间" + DateTime.Now + "'>" + NameStr + "的经费预约 审核通过 " + AuditOpinion + "</a>  (" + user_model.REALNAME + ")";
                    break;
                case _TypeUnthread:   //预约审核不通过
                    doType = "审核经费预约";
                    results = "审核预约(申请额度" + ApplyCount + "在" + dTimeInput + ")不通过";
                    SendName = "申请情况";
                    Receive = modelCash_Apply.ApplierID;
                    SendUrl = "<a href='/Admin/cashCardManage/manageCashApplyPerson.aspx?status=2' target='_self' title='经费预约：提交时间" + DateTime.Now + "'>" + NameStr + "的经费预约 审核不通过 " + AuditOpinion + "</a>  (" + user_model.REALNAME + ")";
                    break;
                case _TypeDone:   //预约完成
                    doType = "审核经费完成";
                    results = "审核完成(" + "申请额度" + ApplyCount + "在" + dTimeInput + ")完成";
                    SendName = "申请情况";
                    SendUrl = "<a href='/Admin/cashCardManage/manageCashApplyPerson.aspx?status=3' target='_self' title='经费预约：提交时间" + DateTime.Now + "'>" + NameStr + "的经费预约 审核完成 </a>  (" + user_model.REALNAME + ")";
                    break;

            }

            mFaceShowMessage.DATETIME = DateTime.Now;
            mFaceShowMessage.FromTable = SendName;
            mFaceShowMessage.IsRead = 0;
            mFaceShowMessage.NewsID = null;
            mFaceShowMessage.NewsType = SendName;
            mFaceShowMessage.ReadTime = null;
            mFaceShowMessage.Receive = Receive;
            mFaceShowMessage.ProjectID = modelCash_Apply.ProjectID;
            mFaceShowMessage.DELFLAG = 0;
            mFaceShowMessage.URLS = SendUrl;
            bFaceShowMessage.Add(mFaceShowMessage);
            /*给业务申请者发信息*/

            //添加操作日志
            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", doType, results + "：成功");
            //添加操作日志
        }

        public string ReturnCS()
        {
            string str = "1=1";
            if (Request["pageindex"] != null)
                str += "&pageindex=" + Request["pageindex"];
            if (Request["status"] != null)
                str += "&status=" + Request["status"];
            if (Request["parentpage"] != null)
                str += "&parentpage=" + Request["parentpage"];
            if (Request["date"] != null)
                str += "&date=" + Request["date"];

            return str;
        }
        /// <summary>
        /// 通过操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Through_Click(object sender, EventArgs e)
        {
            funSubmit("0", _TypeThrough);

        }
        /// <summary>
        /// 不通过操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Unthread_Click(object sender, EventArgs e)
        {
            funSubmit("0", _TypeUnthread);
        }
        /// <summary>
        /// 完成操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Done_Click(object sender, EventArgs e)
        {
            funSubmit("1", _TypeDone);
        }

        public void funSubmit(string _Statas, string _MType)
        {
            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
            string coutws = "";
            bool TnF = false;
            if (!string.IsNullOrEmpty(ApplyID))
            {
                TnF = true;
                modelCash_Apply = bllCash_Apply.GetModel(int.Parse(ApplyID));
            }

            if (modelCash_Apply != null)
            {
                if (TnF && (modelCash_Apply.Statas.ToString() == _Statas))
                {
                    bool B = true;
                    switch (_MType)
                    {
                        case _TypeThrough: modelCash_Apply.Statas = 1; break;
                        case _TypeUnthread: modelCash_Apply.Statas = 2; break;
                        case _TypeDone: modelCash_Apply.Statas = 3; break;
                    }

                    if (_MType == _TypeUnthread)
                    {
                        string str = modelCash_Apply.TEMP1;
                        string GetDateTime = modelCash_Apply.GetDateTime.ToString();
                        B = bllextCash_Account_Subscription.OperationAccount(str, GetDateTime, "2");
                    }

                    if (B)
                    {
                        modelCash_Apply.DoUserID = user_model.ID;

                        bllCash_Apply.Update(modelCash_Apply);

                        SendMessage(_MType, modelCash_Apply);

                        coutws = "alert(\"操作成功！现在返回列表页面\"); ";
                    }
                    else
                    {
                        coutws = "alert(\"操作失败！现在返回列表页面\"); ";
                    }

                }
                else
                {
                    coutws = "alert(\"该申请已不能操作！现在返回列表页面\")";
                }
            }
            else
                coutws = "alert(\"未找到纪录！现在返回列表页面\")";
            coutws += "location.href = \"" + ReturnPage + "?" + ReturnCS() + "\";";

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", coutws, true);
        }

        [AjaxPro.AjaxMethod]
        public int ReturnDateOrder(string _ApplyDate)
        {
            int i = 0;
            DateTime ApplyDate;
            if (string.IsNullOrEmpty(_ApplyDate))
                i = -1;
            else
            {
                DateTime.TryParse(_ApplyDate + " 23:59:59", out ApplyDate);
                DateTime NowDate = DateTime.Now;
                int XS = NowDate.Hour;
                //大于等于15点需要加三天，其它两天就可以预约到
                if (XS >= 15)
                    NowDate = NowDate.AddDays(3);
                else
                    NowDate = NowDate.AddDays(2);

                if (ApplyDate < NowDate)
                    i = -1;
            }

            return i;
        }

        [AjaxPro.AjaxMethod]
        public bool ReturnAccount(string str, string ReadDate, string attr)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            return bllextCash_Account_Subscription.OperationAccount(str, ReadDate, "0");
        }
    }
}
