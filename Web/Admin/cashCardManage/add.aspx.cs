using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Dianda.COMMON;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class add : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_Cards mCash_Cards = new Dianda.Model.Cash_Cards();
        BLL.Cash_Cards bCash_Cards = new Dianda.BLL.Cash_Cards();
        BLL.Cash_CardsExt bCash_CardsExt = new Dianda.BLL.Cash_CardsExt();
        BLL.Project_ProjectsExt bProject_ProjectsExt = new Dianda.BLL.Project_ProjectsExt();
        COMMON.common common = new COMMON.common();
        BllExt.Groups groups_bllext = new Dianda.BllExt.Groups();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Button_sumbit.Visible = true;
                // this.Button_reset.Visible = true;
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

                //提取新建资金卡信息中未读的数据
                Read_data();

                //调用控件中的显示资金卡细目的信息
                Cash_CarDetailMX1.main("");
                //ShowDDLControlInfo();

                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 > 资金卡 ";
                /*设置模板页中的管理值*/
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
        /// 获取持卡人的下拉列表信息
        /// </summary>
        private void GetddlCardholderID()
        {
            DataTable dt = new DataTable();

            //modify by guanzhq on 2012-3-6 begin
            //更正持卡人同时属于多个部门时查找不到
            //string sql = "Select REALNAME+'('+USERNAME+')' as USERINFO,ID From USER_Users Where DELFLAG=0 AND DepartMentID='" + ddlDepartmentID.SelectedValue.ToString() + "' order by REALNAME";

            string sql = "Select REALNAME+'('+USERNAME+')' as USERINFO,ID From USER_Users Where DELFLAG=0 AND DepartMentID LIKE '%" + ddlDepartmentID.SelectedValue.ToString() + "%'order by REALNAME";
            //modify by guanzhq on 2012-3-6 end

            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.ddlCardholderID.DataSource = dt;
                this.ddlCardholderID.DataTextField = "USERINFO";
                this.ddlCardholderID.DataValueField = "ID";
                this.ddlCardholderID.DataBind();
            }
        }
        ///// <summary>
        ///// 显示资金调整说明
        ///// </summary>
        //protected void ShowDDLControlInfo()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        //5为追加金额,而不是资金卡的项.
        //        string sql = " SELECT ID, INFORS FROM Cash_ControlInfo WHERE ID<>5 ORDER BY NUMS ";

        //        dt = pageControl.doSql(sql).Tables[0];

        //        if (dt.Rows.Count > 0)
        //        {

        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //        }
        //        else
        //        {
        //            GridView1.Visible = false;
        //           // tag.Text = "没有可供的调整说明";
        //        }

        //    }
        //    catch
        //    { }
        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    TextBox TB = (TextBox)e.Row.FindControl("txtBalance");

                    //TB.Attributes.Add("onblur", "javascript:ChangeTotalText();");
                }
            }
            catch
            { }
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

        ///// <summary>
        ///// 获取审批人的信息
        ///// </summary>
        //private void GetddlApprover()
        //{

        //ddlApproverIDs.Items.Clear();
        //if (ddlProjectID.SelectedValue != "9999" && ddlProjectID.SelectedValue != "")
        //{
        //    DataTable dt = new DataTable();
        //    string sql = "Select UserInfos,UserID From dbo.Project_Columns Where DELFLAG=0 and id=(select ColumnsID from dbo.Project_Projects where            id=" + ddlProjectID.SelectedValue + ")";
        //    dt = pageControl.doSql(sql).Tables[0];
        //    DataTable Dt2 = new DataTable();
        //    Dt2.Columns.Add("UserID");
        //    Dt2.Columns.Add("UserInfos");
        //    string[] UserID = dt.Rows[0]["UserID"].ToString().Split(',');
        //    string[] UserInfos = dt.Rows[0]["UserInfos"].ToString().Split(',');
        //    for (int i = 0; i < UserID.Length; i++)
        //    {
        //        Dt2.Rows.Add(new object[] { UserID[i], UserInfos[i] });
        //    }
        //    if (Dt2.Rows.Count > 0)
        //    {
        //        this.ddlApproverIDs.DataSource = Dt2;
        //        this.ddlApproverIDs.DataTextField = "UserInfos";
        //        this.ddlApproverIDs.DataValueField = "UserID";
        //        this.ddlApproverIDs.DataBind();
        //    }
        //}
        //else
        //{
        //    DataTable dt = new DataTable();
        //    string sql = "Select UserInfos,UserID From dbo.Project_Columns Where DELFLAG=0 and id in (select ColumnsID from dbo.Project_Projects)";
        //    dt = pageControl.doSql(sql).Tables[0];
        //    DataTable Dt2 = new DataTable();
        //    Dt2.Columns.Add("UserID");
        //    Dt2.Columns.Add("UserInfos");
        //    string UserID = "";
        //    string UserInfos = "";
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        UserID += dt.Rows[i]["UserID"]+",";
        //        UserInfos += dt.Rows[i]["UserInfos"]+",";                    
        //    }
        //    string[] AllUserID = UserID.Remove(UserID.LastIndexOf(',')).Split(',');
        //    string[] AllUserInfos = UserInfos.Remove(UserInfos.LastIndexOf(',')).Split(',');      
        //    ArrayList AllUserID2 = new ArrayList();
        //    ArrayList AllUserInfos2 = new ArrayList();
        //    for (int i = 0; i < AllUserID.Length; i++)
        //    {
        //        if (!AllUserID2.Contains(AllUserID[i]))
        //        {
        //            AllUserID2.Add(AllUserID[i]);
        //        }
        //        if (!AllUserInfos2.Contains(AllUserInfos[i]))
        //        {
        //            AllUserInfos2.Add(AllUserInfos[i]);
        //        }
        //    }
        //    for (int i = 0; i < AllUserID2.Count; i++)
        //    {
        //        Dt2.Rows.Add(new object[] { AllUserID2[i].ToString(), AllUserInfos2[i].ToString() });
        //    }
        //    if (Dt2.Rows.Count > 0)
        //    {
        //        this.ddlApproverIDs.DataSource = Dt2;
        //        this.ddlApproverIDs.DataTextField = "UserInfos";
        //        this.ddlApproverIDs.DataValueField = "UserID";
        //        this.ddlApproverIDs.DataBind();
        //    }
        //}
        //}

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
            }
        }

        private void GetddlProjectID()
        {
            DataTable dt = new DataTable();
            string sql = @"Select NAMES,ID From Project_Projects Where DELFLAG=0 and  [Status]=1 
union select names,id from Project_Projects where names='无' or names='-无-' or names='日常项目'";
            //and id not in (select distinct ProjectID from Cash_Cards where projectid is not null) （sql语句里一条限制，目前不要该限制）
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
                bool checkName = bCash_CardsExt.Exists(NAME);
                if (checkName)
                {
                    tag.Text = "该名称已经存在，请修改！";
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

                int intMaxID = bCash_Cards.GetMaxId();
                int ZJK = 0;
                DataTable dt = new DataTable();
                dt = bCash_Cards.GetList("Statas=0 or Statas=1").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ZJK = dt.Rows.Count;
                }
                mCash_Cards = new Dianda.Model.Cash_Cards();
                mCash_Cards.ID = intMaxID;

                string time = DateTime.Now.ToString("yyyyMMdd");
                //资金卡编号
                mCash_Cards.CardNum = "zjk" + time + ZJK.ToString("0000");
                //资金卡名称
                mCash_Cards.CardName = NAME;
                //所属项目
                mCash_Cards.ProjectID = Int32.Parse(this.ddlProjectID.SelectedValue);

                //所属预算报告
                mCash_Cards.SFOrderID = int.Parse(DDL_Budget.SelectedValue.ToString());
                //所属部门
                mCash_Cards.DepartmentID = this.ddlDepartmentID.SelectedValue;
                //持卡人
                mCash_Cards.CardholderID = this.ddlCardholderID.SelectedValue;
                //到期时间
                mCash_Cards.EndTime = DateTime.Parse(TB_DateTime.Value);
                //审批人
                mCash_Cards.ApproverIDs = this.ddlApproverIDs.SelectedValue;
                //创建日期
                mCash_Cards.DATETIME = DateTime.Now;
                //状态
                mCash_Cards.Statas = 1;
                //创建人
                mCash_Cards.DoUserID = ((Model.USER_Users)Session["USER_Users"]).USERNAME;
                //新建时，可用金额和预算金额及当前余额都是一样
                decimal Balance = decimal.Parse(Cash_CarDetailMX1.Balance);
                //预算金额
                mCash_Cards.Balance = Balance;
                //可用金额
                mCash_Cards.LimitNums = Balance;
                //当前余额
                mCash_Cards.YEBalance = Balance;

                int carid = bCash_CardsExt.Add(mCash_Cards);

                Cash_CarDetailMX1.Submit(carid);
                /*-------------------资金卡明细----------begin--------*/
                //开始操作资金卡明细信息
                //GridView GV = Cash_CarDetailList.GV1;
                //if (GV.Rows.Count > 0)
                //{
                //    Model.Cash_CardsDetail cardsdetail_model = new Dianda.Model.Cash_CardsDetail();
                //    BLL.Cash_CardsDetail cardsdetail_bll = new Dianda.BLL.Cash_CardsDetail();
                //    for (int i = 0; i < GV.Rows.Count; i++)
                //    {
                //        HiddenField HF_DetailID = (HiddenField)GV.Rows[i].FindControl("HiddenField_deid");
                //        TextBox TB_balance = (TextBox)GV.Rows[i].FindControl("TextBox_balance");
                //        DropDownList DropDownList_Unit = (DropDownList)GV.Rows[i].FindControl("DropDownList_Unit");
                //        int Unit = int.Parse(DropDownList_Unit.SelectedValue.ToString());
                //        RadioButtonList RadioButtonList_typename = (RadioButtonList)GV.Rows[i].FindControl("RadioButtonList_typename");
                //        //ID
                //        cardsdetail_model.ID = cardsdetail_bll.GetMaxId();
                //        //资金卡ID
                //        cardsdetail_model.CardID = carid;
                //        //明细项目的ID
                //        cardsdetail_model.DetailID = int.Parse(HF_DetailID.Value.ToString());

                //        //在新建资金卡时，预算金额、可用金额、当前余额都是一样的

                //        //各明细项的当前余额
                //        cardsdetail_model.Balance = decimal.Parse(TB_balance.Text.ToString()) * Unit;
                //        //预算金额
                //        cardsdetail_model.Oldbalance = decimal.Parse(TB_balance.Text.ToString()) * Unit;
                //        //可用金额
                //        cardsdetail_model.KYbalance = decimal.Parse(TB_balance.Text.ToString()) * Unit;

                //        //单位
                //        cardsdetail_model.Unit = Unit;
                //        //细目的类型
                //        cardsdetail_model.TypesName = RadioButtonList_typename.SelectedValue.ToString();

                //        cardsdetail_bll.Add(cardsdetail_model);
                //    }
                //}
                /*-------------------资金卡明细----------begin--------*/

                /*---------------------一旦为某一个预算报告新创建了一个新的资金卡,就要在预算报告的资金卡数量上加1　-----------begin--------------*/

                BLL.Cash_SF_Order order_bll = new Dianda.BLL.Cash_SF_Order();
                Model.Cash_SF_Order order_model = new Dianda.Model.Cash_SF_Order();

                string SFOrderID = mCash_Cards.SFOrderID.ToString();
                order_model = order_bll.GetModel(int.Parse(SFOrderID));
                //资金卡数量加1
                order_model.CarNums = order_model.CarNums + 1;
                order_bll.Update(order_model);

                /*---------------------一旦为某一个预算报告新创建了一个新的资金卡,就要在预算报告的资金卡数量上加1---------------end------------*/

                Cash_CarDetailMX1.main(carid.ToString());
                tag.Text = "操作成功！";
                tag2.Text = "操作成功！";
                this.lblCardNum.Text = mCash_Cards.CardNum;
                this.Button_sumbit.Visible = false;
                //this.Button_reset.Visible = false;
                //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx" + "\";</script>";
                //Response.Write(coutws);

                //添加操作日志
                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "新增资金卡", "新增资金卡" + mCash_Cards.CardNum + "成功");

                //添加操作日志
                string coutws = "alert(\"操作成功！现在返回列表页面\"); ";
                coutws += "location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";";

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "addScript", coutws, true);
            }
            catch
            {
                tag.Text = "操作失败，请重试！";
            }
        }

        /// <summary>
        /// 点击重置按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx?pageindex=" + Request["pageindex"]);
        }

        /// <summary>
        /// 点击取消按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            // Response.Write("<script>history.back()</script>");
            Response.Redirect("manage.aspx?pageindex=" + Request["pageindex"]);
        }

        //读未读的数据
        protected void Read_data()
        {
            DataTable dt = new DataTable();
            //string strSQL = "Select isnull(a.ID,0) ID,isnull(a.CardName,0) CardName, " +
            //    "isnull(a.CardholderRealName,'') CardholderRealName,isnull(a.DepartmentName,'') DepartmentName, " +
            //    "isnull(a.ProjectName,'') ProjectName,isnull(a.LimitNums,0) LimitNums, " +
            //    "isnull(a.ApproverRealName,'') ApproverRealName,isnull(a.DATETIME,'') DATETIME, " +
            //    "case isnull(a.IsRead,0) when 0 then '未读' else '已读' end IsRead,isnull(b.ID,0) Pro_ID " +
            //    "From vCash_Message a " +
            //    "left outer join Project_Projects b on a.ProjectName = b.names " +
            //    "where a.IsRead=0 and b.ID is not null";
            string strSQL = "SELECT * FROM vCash_Message WHERE IsRead=0 ";
            dt = pageControl.doSql(strSQL).Tables[0];
            DataList1.DataSource = dt.DefaultView;
            DataList1.DataBind();
        }

        //提取未读的数据赋给新建项
        protected void Btn_TQXX_Click(object sender, EventArgs e)
        {
            string _ID = ((Button)sender).CommandArgument.ToString();
            DataTable dt = new DataTable();
            string strSQL = "select isnull(ProjectID,'') ProjectID, isnull(SFOrderID,'') SFOrderID," +
                    "isnull(LimitNums,0) LimitNums,isnull(SendUserID,'') SendUserID" +
                    " from Cash_Message where ID=" + _ID;
            //得到当前选中的数据
            dt = pageControl.doSql(strSQL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                //所属项目
                string _ProjectID = dt.Rows[0]["ProjectID"].ToString();

                try
                {
                    if (_ProjectID != "") ddlProjectID.SelectedValue = _ProjectID;
                }
                catch (Exception)
                {
                }
                //所属预算报告
                string _SFOrderID = dt.Rows[0]["SFOrderID"].ToString();
                try
                {
                    if (_SFOrderID != "") DDL_Budget.SelectedValue = _SFOrderID;
                }
                catch (Exception)
                {
                }

            }


            tag.Text = "";
            this.Button_sumbit.Visible = true;
            //this.Button_reset.Visible = true;

        }

        /// <summary>
        /// 把未读的条目直接改为已阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_YY_Click(object sender, EventArgs e)
        {
            //得到button传递的值，拆分成数组
            string _str = ((Button)sender).CommandArgument.ToString();
            string[] _str_arr = _str.Split(',');
            string _id = _str_arr[0].ToString();
            string _CardName = _str_arr[1].ToString();

            //调用已有的对象
            Model.Cash_Message mCash_Message = new Dianda.Model.Cash_Message();
            BLL.Cash_Message bCash_Message = new Dianda.BLL.Cash_Message();
            try
            {
                mCash_Message = new Dianda.Model.Cash_Message();
                mCash_Message = bCash_Message.GetModel(Int32.Parse(_id));
                mCash_Message.IsRead = 1;
                mCash_Message.ReadTime = DateTime.Now;
                mCash_Message.DoNotes = "";
                mCash_Message.DoUserID = ((Model.USER_Users)Session["USER_Users"]).USERNAME;
                bCash_Message.Update(mCash_Message);

                //添加操作日志
                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "阅读了" + _CardName, "确定阅读" + _CardName + ":已阅");

                Read_data();
            }
            catch
            {

            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string ProjectID = DataBinder.Eval(e.Item.DataItem, "ProjectID").ToString();

            string ProjectName = DataBinder.Eval(e.Item.DataItem, "ProjectName").ToString();
            Label Lab_Project = (Label)e.Item.FindControl("Lab_Project");
            if (ProjectID.Equals("9999"))
            {
                //项目名称
                Lab_Project.Text = "暂无所属项目";
            }
            else
            {
                //项目名称
                Lab_Project.Text = ProjectName;
            }

            //预算报告路径地址
            string BudgetList = DataBinder.Eval(e.Item.DataItem, "BudgetList").ToString();
            //预算报告名称
            string BudgetName = DataBinder.Eval(e.Item.DataItem, "BudgetName").ToString();

            Label LB_budget = (Label)e.Item.FindControl("LB_budget");

            LB_budget.Text = "<a href='" + BudgetList + "' target='_blank'>" + BudgetName + "</a>";

        }
        ////切换项目
        //protected void ddlProjectID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetddlApprover();
        //}

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

        public void ShowCash_CarDetailMX()
        {
            //调用控件中的显示资金卡细目的信息
            Cash_CarDetailMX1.Balance = "0";
            Cash_CarDetailMX1.LimitNums = "0";
            Cash_CarDetailMX1.main("");
        }
    }
}
