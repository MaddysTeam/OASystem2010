using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class modify : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.COMMON.common common = new Dianda.COMMON.common();
        Model.Cash_Cards Cards_model = new Dianda.Model.Cash_Cards();
        BLL.Cash_Cards Cards_bll = new Dianda.BLL.Cash_Cards();
        BLL.Cash_CardsExt bCash_CardsExt = new Dianda.BLL.Cash_CardsExt();
        BLL.Cash_Apply_History bCash_Apply_History = new Dianda.BLL.Cash_Apply_History();
        BllExt.Groups groups_bllext = new Dianda.BllExt.Groups();

        private static string _id;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Balance
        {
            get
            {
                if (ViewState["Balance"] != null)
                    return ViewState["Balance"].ToString();
                return null;
            }
            set { ViewState["Balance"] = value; }
        }
        public string LimitNums
        {
            get
            {
                if (ViewState["LimitNums"] != null)
                    return ViewState["LimitNums"].ToString();
                return null;
            }
            set { ViewState["LimitNums"] = value; }
        }
        public string Cardsid
        {
            get
            {
                if (ViewState["Cardsid"] != null)
                    return ViewState["Cardsid"].ToString();
                return null;
            }
            set { ViewState["Cardsid"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Button_sumbit.Visible = true;
                id = common.RequestSafeString(Request["id"].ToString(), 50);

                //获取所属预算报告列表信息
                GetDDLBudget();
                //获取所属部门的列表信息
                GetddlDepartmentID();
                //获取持卡人的列表信息
                GetddlCardholderID();
                //获取所属项目的列表信息
                GetddlProjectID();
                //获取审批人的列表信息
                GetddlApprover();

                ShowInitInfo(id);

                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 > 资金卡";
            }
        }

        /// <summary>
        /// 获取所属预算报告列表
        /// </summary>
        private void GetDDLBudget()
        {
            try
            {
                DDL_Budget.Items.Clear();
                DataTable DT = new DataTable();
                string sql = "SELECT ID, NAMES FROM Cash_SF_Order WHERE (Delflag = 0) AND (Status = 1) ORDER BY ADDTIME DESC ";
                DT = pageControl.doSql(sql).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    DDL_Budget.DataSource = DT;
                    DDL_Budget.DataTextField = "NAMES";
                    DDL_Budget.DataValueField = "ID";
                    DDL_Budget.DataBind();
                }
                else
                {
                    ListItem li = new ListItem("-暂无预算报告-", "");
                    DDL_Budget.Items.Add(li);

                    //没有预算报告不能创建资金卡
                    Button_sumbit.Enabled = false;
                    tag.Text = "暂无预算报告，不能创建资金卡！";
                }

            }
            catch
            { }
        }
        /// <summary>
        /// 加载所属部门信息
        /// </summary>
        private void GetddlDepartmentID()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT ID,[Name] FROM USER_Groups WHERE DELFLAG=0 and Tags='部门' group by ID,[Name]";
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.ddlDepartmentID.DataSource = dt;
                this.ddlDepartmentID.DataTextField = "Name";
                this.ddlDepartmentID.DataValueField = "ID";
                this.ddlDepartmentID.DataBind();

                Cards_model = Cards_bll.GetModel(int.Parse(id));
                ddlDepartmentID.SelectedValue = Cards_model.DepartmentID;

            }


        }

        /// <summary>
        /// 获取持卡人的下拉列表信息
        /// </summary>
        private void GetddlCardholderID()
        {
            DataTable dt = new DataTable();
            string sql = "Select REALNAME+'('+USERNAME+')' as USERINFO,ID From USER_Users Where DELFLAG=0 AND (DepartMentID like '%" + ddlDepartmentID.SelectedValue.ToString() + "%') order by REALNAME";
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.ddlCardholderID.DataSource = dt;
                this.ddlCardholderID.DataTextField = "USERINFO";
                this.ddlCardholderID.DataValueField = "ID";
                this.ddlCardholderID.DataBind();
            }
        }
        /// <summary>
        /// 加载审批人
        /// </summary>
        protected void GetddlApprover()
        {
            try
            {
                DataTable DT = groups_bllext.getLeaderList();
                if (DT.Rows.Count > 0)
                {
                    ddlApproverIDs.DataSource = DT;
                    ddlApproverIDs.DataValueField = "ID";
                    ddlApproverIDs.DataTextField = "USERINFO";
                    ddlApproverIDs.DataBind();
                }
                else
                {
                    ListItem li = new ListItem("-暂无可选审批人-", "");
                    ddlApproverIDs.Items.Add(li);
                    Button_sumbit.Enabled = false;
                }

            }
            catch
            { }

        }
        /// <summary>
        /// 加载项目信息
        /// </summary>
        private void GetddlProjectID()
        {
            DataTable dt = new DataTable();
            string sql = @"Select NAMES,ID From Project_Projects Where DELFLAG=0 and  [Status]=1 ";
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.ddlProjectID.DataSource = dt;
                this.ddlProjectID.DataTextField = "NAMES";
                this.ddlProjectID.DataValueField = "ID";
                this.ddlProjectID.DataBind();

                ListItem li = new ListItem("-暂时不属于任何项目-", "9999");
                li.Selected = true;
                ddlProjectID.Items.Insert(0, li);

            }
        }

        /// <summary>
        /// 初始化显面信息
        /// </summary>
        /// <param name="id"></param>
        protected void ShowInitInfo(string id)
        {
            try
            {
                Cards_model = Cards_bll.GetModel(int.Parse(id));
                //资金卡编号
                TB_CardNum.Text = Cards_model.CardNum.ToString();
                //资金卡名称
                txtCardName.Text = Cards_model.CardName.ToString();
                //所属项目
                ddlProjectID.SelectedValue = Cards_model.ProjectID.ToString();
                //所属预算报告
                DDL_Budget.SelectedValue = Cards_model.SFOrderID.ToString();
                //所属部门
                ddlDepartmentID.SelectedValue = Cards_model.DepartmentID.ToString();
                //持卡人
                ddlCardholderID.SelectedValue = Cards_model.CardholderID.ToString();
                //到期时间
                TB_DateTime.Value = Convert.ToDateTime(Cards_model.EndTime.ToString()).ToString("yyyy-MM-dd");
                //审批人
                ddlApproverIDs.SelectedValue = Cards_model.ApproverIDs.ToString();
                //初始化资金卡详细

                Balance = Cards_model.Balance.ToString();
                LimitNums = Cards_model.LimitNums.ToString();
                Cardsid = Cards_model.ID.ToString();
                ShowCash_CarDetailMX();

                string sql = "select ID from dbo.Cash_Apply where CashCertificateID='" + id + "' union all select ID from dbo.Cash_Apply_History where CashCertificateID='" + id + "'";
                DataTable dt = pageControl.doSql(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //付全文    2013-4-12   不管是否记账，开放资金卡细目明细及可用金额修改
                    //string msg = "已有记账明细或经费预约，不能进行编辑！";
                    //tag.Text = msg;
                    //tag2.Text = msg;
                    //Button_sumbit.Visible = false;
                }
                else
                {
                    tag.Text = "";
                    tag2.Text = "";
                    Button_sumbit.Visible = true;
                }
            }
            catch
            { }
        }

        public void ShowCash_CarDetailMX()
        {
            //调用控件中的显示资金卡细目的信息
            Cash_CarDetailMX1.Balance = Balance;
            Cash_CarDetailMX1.LimitNums = LimitNums;
            Cash_CarDetailMX1.main(Cardsid);
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
                string NAME = this.txtCardName.Text;//获取到资金卡名称
                if (String.IsNullOrEmpty(NAME))
                {
                    tag.Text = "名称不能为空，请填写名称！";
                    return;
                }

                if (string.IsNullOrEmpty(TB_DateTime.Value) || DateTime.Parse(TB_DateTime.Value) < DateTime.Parse(DateTime.Now.ToLongDateString()))
                {
                    tag.Text = "到期日期必须大于或等于当前日期";
                    return;
                }
                if (!Cash_CarDetailMX1.ReturnTnF())
                {
                    tag.Text = "未添加明细，请添加！";
                    return;
                }

                Cards_model = Cards_bll.GetModel(Int32.Parse(id));
                //资金卡名称
                Cards_model.CardName = NAME;
                //所属项目
                Cards_model.ProjectID = Int32.Parse(this.ddlProjectID.SelectedValue);
                //所属预算报告
                Cards_model.SFOrderID = int.Parse(DDL_Budget.SelectedValue.ToString());
                //所属部门
                Cards_model.DepartmentID = this.ddlDepartmentID.SelectedValue;
                //持卡人
                Cards_model.CardholderID = this.ddlCardholderID.SelectedValue;
                //到期时间
                Cards_model.EndTime = DateTime.Parse(TB_DateTime.Value);
                //审批人
                Cards_model.ApproverIDs = this.ddlApproverIDs.SelectedValue;
                //创建日期
                Cards_model.DATETIME = DateTime.Now;
                //状态
                Cards_model.Statas = 1;
                //创建人
                Cards_model.DoUserID = ((Model.USER_Users)Session["USER_Users"]).USERNAME;
                //原可用金额
                string oldLimitNums = Cards_model.LimitNums.ToString();
                //调整后的可用金额
                string newLimitNums = Cash_CarDetailMX1.LimitNums;
                //差额
                decimal cj = decimal.Parse(newLimitNums) - decimal.Parse(oldLimitNums);
                if (cj > 0)
                {
                    //当前余额(可用金额增加或减少多少，当前余额对应的调整)
                    Cards_model.YEBalance = Cards_model.YEBalance + cj;

                    Cards_model.TEMP0 = Cards_model.TEMP0 + "&nbsp;&nbsp;" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "，增加" + cj + "元，可用金额由" + oldLimitNums + "元调整为" + newLimitNums + "元<br>";
                }
                else
                {
                    cj = decimal.Parse(oldLimitNums) - decimal.Parse(newLimitNums);

                    //当前余额(可用金额增加或减少多少，当前余额对应的调整)
                    Cards_model.YEBalance = Cards_model.YEBalance - cj;

                    Cards_model.TEMP0 = Cards_model.TEMP0 + "&nbsp;&nbsp;" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "，减少" + cj + "元，可用金额由" + oldLimitNums + "元调整为" + newLimitNums + "元<br>";
                }
                //可用金额
                Cards_model.LimitNums = decimal.Parse((newLimitNums));
                //预算金额
                Cards_model.Balance = decimal.Parse((Cash_CarDetailMX1.Balance));

                Cards_bll.Update(Cards_model);

                Cash_CarDetailMX1.CJ = cj;
                Cash_CarDetailMX1.Submit(int.Parse(id));

                /*-------------------资金卡明细----------begin-----------------------*/
                //开始操作资金卡明细信息
                //GridView GV = Cash_CarDetailList.GV1;
                //if (GV.Rows.Count > 0)
                //{
                //    Model.Cash_CardsDetail cardsdetail_model = new Dianda.Model.Cash_CardsDetail();
                //    BLL.Cash_CardsDetail cardsdetail_bll = new Dianda.BLL.Cash_CardsDetail();
                //    for (int i = 0; i < GV.Rows.Count; i++)
                //    {
                //        HiddenField HF_ID = (HiddenField)GV.Rows[i].FindControl("HiddenField_ID");

                //        HiddenField HF_DetailID = (HiddenField)GV.Rows[i].FindControl("HiddenField_deid");
                //        TextBox TB_balance = (TextBox)GV.Rows[i].FindControl("TextBox_balance");
                //        DropDownList DropDownList_Unit = (DropDownList)GV.Rows[i].FindControl("DropDownList_Unit");
                //        int Unit = int.Parse(DropDownList_Unit.SelectedValue.ToString());
                //        RadioButtonList RadioButtonList_typename = (RadioButtonList)GV.Rows[i].FindControl("RadioButtonList_typename");

                //        cardsdetail_model = cardsdetail_bll.GetModel(int.Parse(HF_ID.Value.ToString()));
                //        //资金卡ID
                //        cardsdetail_model.CardID =int.Parse(id);
                //        //明细项目的ID
                //        cardsdetail_model.DetailID = int.Parse(HF_DetailID.Value.ToString());


                //        //编辑时，预算金额不变，还是最初始的值，但是可用金额有可能被调整了。。那么当前余额也要对应增加或减

                //        //当前余额 (可用金额调整额度是多少，就要在原来的当前余额基础上加减多少)
                //        if (cj > 0)
                //        {
                //            //首先获得可用金额调整的差值
                //            decimal cz = decimal.Parse(TB_balance.Text.ToString()) * Unit - decimal.Parse(cardsdetail_model.KYbalance.ToString());
                //            cardsdetail_model.Balance = cardsdetail_model.Balance + cz;
                //        }
                //        else
                //        {
                //            //首先获得可用金额调整的差值
                //            decimal cz = decimal.Parse(cardsdetail_model.KYbalance.ToString()) - decimal.Parse(TB_balance.Text.ToString()) * Unit;
                //            cardsdetail_model.Balance = cardsdetail_model.Balance - cz;
                //        }
                //        //可用金额
                //        cardsdetail_model.KYbalance = decimal.Parse(TB_balance.Text.ToString()) * Unit;
                //        //单位
                //        cardsdetail_model.Unit = Unit;
                //        //细目的类型
                //        cardsdetail_model.TypesName = RadioButtonList_typename.SelectedValue.ToString();

                //        cardsdetail_bll.Update(cardsdetail_model);
                //    }
                //}
                /*-------------------资金卡明细----------begin-------------------------------*/

                tag.Text = "操作成功！";
                tag2.Text = "操作成功！";
                this.TB_CardNum.Text = Cards_model.CardNum.ToString();
                this.Button_sumbit.Visible = false;

                //添加操作日志
                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "编辑资金卡", "编辑资金卡" + Cards_model.CardNum + "成功");
                //添加操作日志

                string coutws = "alert(\"操作成功！现在返回列表页面\"); ";
                coutws += "location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "&role=manage\";";

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "addScript", coutws, true);
            }
            catch
            {
                tag.Text = "操作失败，请重试！";
            }
        }
        /// <summary>
        /// 切换所属部门时连动的显示持卡人的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetddlCardholderID();
            ShowCash_CarDetailMX();
        }

        /// <summary>
        /// 点击取消按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx?pageindex=" + Request["pageindex"] + "&role=manage");
        }
    }
}
