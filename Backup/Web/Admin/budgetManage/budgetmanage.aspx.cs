using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.budgetManage
{
    public partial class budgetmanage : System.Web.UI.Page
    {
        #region 参数
        /// <summary>
        /// 可以编辑审核通过的经费权限
        /// </summary>
        public string BudgetmanageQX
        {
            get
            {
                if (ViewState["BudgetmanageQX"] != null)
                    return ViewState["BudgetmanageQX"].ToString();
                return null;
            }
            set { ViewState["BudgetmanageQX"] = value; }
        }
        #endregion
        COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_SF_Order order_model = new Dianda.Model.Cash_SF_Order();
        BLL.Cash_SF_Order order_bll = new Dianda.BLL.Cash_SF_Order();
        BLL.USER_Groups groups_bll = new Dianda.BLL.USER_Groups();
        Model.USER_Users user_model = new Dianda.Model.USER_Users();
        float daishenhe = 0;
        float tongguo = 0;
        float weitongguo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //可以编辑审核通过的经费权限
                TSQX();
                //初始化状态下拉列表
                GetddlStatas();
                //初始化部门下拉列表
                GetddlDepartmentID();
                //获取申请人下拉列表
                GetDDL_AdderID();
                //初始化专项资金下拉
                GetddlSpecialFunds();
                //======初始化年份下拉列表 by guanzhq on 2012年3月20日======
                showYears(DropDownList_year, DateTime.Now.Year.ToString());

                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    setRowCout();//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    count = dtrowsHidden.Value.ToString();
                }
                if(string.IsNullOrEmpty(count))
                {
                    count = "0";
                }
                int countint = int.Parse(count);
                string pageindex = null;//这里是为分页服务的
                pageindex = Request["pageindex"];
                if (pageindex == null || pageindex == "")
                {
                    pageindex = "1";
                }
                int pageindex_int = int.Parse(pageindex);
                BindData(pageindex_int);

                //说明是领导审批进入的列表
                if ((null != Request["role"] && Request["role"].ToString().Equals("manager")))
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 预算管理 > 预算申请列表 ";
                    //设置模板页中的管理值

                    //领导不具备新建、编辑、撤销预算申报的功能，只能审核
                    Button_add.Visible = false;
                    Button_modify.Visible = false;
                    Button_sumbit.Visible = false;
                    Button_check.Visible = true;

                    //DDL_Department.Visible = true;
                    //DDL_Adder.Visible = true;
                    td_Dep.Visible = true;
                }//财务查看
                else if (null != Request["role"] && Request["role"].ToString().Equals("lister"))
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 预算管理 > 预算申请查看 ";
                    //设置模板页中的管理值

                    //领导不具备新建、编辑、撤销预算申报的功能，只能审核
                    Button_add.Visible = false;
                    Button_modify.Visible = false;
                    Button_sumbit.Visible = false;
                    Button_check.Visible = false;

                    //DDL_Department.Visible = false;
                    //DDL_Adder.Visible = false;
                    td_Dep.Visible = false;

                    GridView1.Columns[0].Visible = false;
                    //DDL_Status.SelectedValue = "1";
                    //DDL_Status.Enabled = false;
                }
                else
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "经费 > 预算申请 ";
                    //设置模板页中的管理值

                    //领导具备新建、编辑、撤销预算申报的功能，但不能审核　
                    Button_add.Visible = true;
                    Button_modify.Visible = true;
                    Button_sumbit.Visible = true;

                    Button_check.Visible = false;

                    //DDL_Department.Visible = false;
                    //DDL_Adder.Visible = false;

                    td_Dep.Visible = false;
                }
            }
        }
        /// <summary>
        /// 可以编辑审核通过经费权限的组ID
        /// </summary>
        public void TSQX()
        {
            if (null != Request["role"] && Request["role"].ToString().Equals("manager"))
            {
                DataTable dt = groups_bll.GetList("name='财务' and tags='普通组'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    BudgetmanageQX = dt.Rows[0]["id"].ToString();
                }
            }
        }
        /// <summary>
        /// 获取部门
        /// </summary>
        private void GetddlDepartmentID()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT ID,[Name] FROM USER_Groups WHERE DELFLAG=0 and Tags='部门' group by ID,[Name]";
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {

                this.DDL_Department.DataSource = dt;
                this.DDL_Department.DataTextField = "Name";
                this.DDL_Department.DataValueField = "ID";
                this.DDL_Department.DataBind();

                ListItem li = new ListItem("-全部-", "9999");
                li.Selected = true;
                DDL_Department.Items.Insert(0, li);

            }
        }
        /// <summary>
        /// 切换所属部门时连动的显示持卡人的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDDL_AdderID();

            setRowCout();
            BindData(1);//调用显示
        }

        /// <summary>
        /// 切换所属部门时连动的显示持卡人的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDDLAdder_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRowCout();
            BindData(1);//调用显示

        }
        /// <summary>
        /// 获取持卡人的下拉列表信息
        /// </summary>
        private void GetDDL_AdderID()
        {
            DataTable dt = new DataTable();
            string sql = "Select REALNAME+'('+USERNAME+')' as USERINFO,ID From USER_Users Where DELFLAG=0 ";
            if (!DDL_Department.SelectedValue.ToString().Equals("9999"))
            {
                sql = sql + "AND DepartMentID='" + DDL_Department.SelectedValue.ToString() + "'";
            }
            sql = sql + " order by REALNAME";

            dt = pageControl.doSql(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.DDL_Adder.DataSource = dt;
                this.DDL_Adder.DataTextField = "USERINFO";
                this.DDL_Adder.DataValueField = "ID";
                this.DDL_Adder.DataBind();

                ListItem li = new ListItem("-全部-", "9999");
                li.Selected = true;
                DDL_Adder.Items.Insert(0, li);

                string adderid = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    adderid = adderid + "'" + dt.Rows[i]["ID"].ToString() + "',";
                }

                Session["adderid"] = adderid.Substring(0, adderid.Length - 1);
            }
        }

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout()
        {
            try
            {
                user_model = (Model.USER_Users)Session["USER_Users"];

                string strSQL = "select * from vCash_SF_Order where " + SQLCondition();
                DataTable dt = new DataTable();
                dt = pageControl.doSql(strSQL).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    dtrowsHidden.Value = dt.Rows.Count.ToString();
                }
                else
                {
                    dtrowsHidden.Value = "0";
                }
            }
            catch
            {
            }
        }

        protected void ddlStatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Status.SelectedValue == "1" || this.DDL_Status.SelectedValue == "")
            {
                this.Button_sumbit.Enabled = false;
                Button_modify.Enabled = false;
            }
            else
            {
                this.Button_sumbit.Enabled = true;
                Button_modify.Enabled = true;
            }
            setRowCout();
            BindData(1);//调用显示
        }
        /// <summary>
        /// 专项资金切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_SpecialFunds_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRowCout();
            BindData(1);//调用显示
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        protected void BindData(int pageindex)
        {
            try
            {

                DataTable dt = new DataTable();
                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                dt = pageControl.GetList_FenYe_Common(SQLCondition(), pageindex, GridView1.PageSize, alltiaoshuInt, "vCash_SF_Order", "ADDTIME").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (dt.Rows.Count > 0)
                {
                    //""表示全部，0待审，1审核通过，2审核不通过
                    //if (this.DDL_Status.SelectedValue == "1" || this.DDL_Status.SelectedValue == "")
                    if (this.DDL_Status.SelectedValue == "1")
                    {
                        this.Button_sumbit.Enabled = false;
                        Button_modify.Enabled = false;
                        Button_check.Enabled = false;
                    }
                    else
                    {
                        this.Button_sumbit.Enabled = true;
                        Button_modify.Enabled = true;
                        Button_check.Enabled = true;
                    }
                    // Button_reset.Enabled = true;
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件

                    //汇总统计值
                    //Label_money1.Text = daishenhe.ToString();
                    //Label_money2.Text = tongguo.ToString();
                    //Label_money3.Text = weitongguo.ToString();string.Format("{0:N}", 250000)
                    Label_money1.Text = string.Format("{0:N}", daishenhe).Split('.')[1].ToString().Equals("00") ? string.Format("{0:N}", daishenhe).Split('.')[0].ToString() : string.Format("{0:N}", daishenhe);
                    Label_money2.Text = string.Format("{0:N}", tongguo).Split('.')[1].ToString().Equals("00") ? string.Format("{0:N}", tongguo).Split('.')[0].ToString() : string.Format("{0:N}", tongguo);//这样是防止出现科学记数法
                    Label_money3.Text = string.Format("{0:N}", weitongguo).Split('.')[1].ToString().Equals("00") ? string.Format("{0:N}", weitongguo).Split('.')[0].ToString() : string.Format("{0:N}", weitongguo);

                    div_total.Visible = true;
                }
                else
                {
                    Button_sumbit.Enabled = false;
                    Button_modify.Enabled = false;
                    Button_check.Enabled = false;
                    div_total.Visible = false;
                    // Button_reset.Enabled = false;
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";

                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    if (alltiaoshuInt > 0)
                    {
                        BindData(pageindex - 1);
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition()
        {
            user_model = (Model.USER_Users)Session["USER_Users"];
            string sqlwhere = " delflag=0 ";

            if (this.DDL_Status.SelectedValue != "9999" && this.DDL_Status.SelectedValue != "")
            {
                sqlwhere = sqlwhere + " AND Status in (" + this.DDL_Status.SelectedValue + ")";
            }
            //说明是具有审批权限的领导
            if (null != Request["role"] && Request["role"].ToString().Equals("manager"))
            {
                //CheckerHistory like的时候有个；和：　因为在审核时就是这样加进去的
                if (string.IsNullOrEmpty(BudgetmanageQX) || !user_model.GROUPS.Contains(BudgetmanageQX))
                    sqlwhere = sqlwhere + " and (Checker='" + user_model.ID + "' OR AssignChecker='" + user_model.ID + "' OR CheckerHistory LIKE '%;" + user_model.USERNAME.ToString() + ":%')";
                if (!DDL_Adder.SelectedValue.Equals(""))
                {
                    if (!DDL_Adder.SelectedValue.Equals("9999"))
                    {
                        sqlwhere = sqlwhere + " AND Applyuser ='" + DDL_Adder.SelectedValue.ToString() + "'";
                    }
                    else
                    {
                        string adderid = Session["adderid"].ToString();

                        sqlwhere = sqlwhere + " AND Applyuser in (" + adderid + ")";
                    }
                }
                else
                {
                    sqlwhere = sqlwhere + " AND Applyuser ='该部门没有人'";
                }
            }
            else if (null != Request["role"] && Request["role"].ToString().Equals("lister"))
            {
                //主任的ID
                string DirectorID = System.Web.Configuration.WebConfigurationManager.AppSettings["DirectorID"].ToString();
                if (Session["IsSecretary"] != null && Session["IsSecretary"].ToString() == "1")
                    sqlwhere = " delflag=0 and (Status=1 or REVERSE(substring(REVERSE(checkerHistory),0,charindex(';',REVERSE(checkerHistory)))) like '%继续审核%' or checker = '" + DirectorID + "')";//秘书可以看到所有审核通过和继续审核的预算申请
                else
                    sqlwhere = " delflag=0 and Status=1";//财务只能看到审核通过的
            }
            else//说明是预算申请上报人
            {
                sqlwhere = sqlwhere + " and Applyuser='" + user_model.ID + "'";
            }

            //===设置年份条件 by guanzhq on 2012年3月20日 end====
            if (!DDL_SpecialFunds.SelectedValue.Equals(""))
            {
                sqlwhere = sqlwhere + " AND SpecialFundsID =" + DDL_SpecialFunds.SelectedValue;
            }
            //===设置年份条件 by guanzhq on 2012年3月20日 begin===
            if (DropDownList_year.SelectedValue != "")
            {
                sqlwhere = sqlwhere + " AND ADDTIME like '%" + DropDownList_year.SelectedValue + "%'";
            }
            return sqlwhere;
            
        }

        /// <summary>
        /// 点击新增按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_add_onclick(object sender, EventArgs e)
        {
            Response.Redirect("addbudget.aspx?pageindex=" + pageindexHidden.Value + "&Status=" + DDL_Status.SelectedValue.ToString());
        }
        /// <summary>
        ///点击修改按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_modify_onclick(object sender, EventArgs e)
        {
            //选择编辑的条数只能为一条
            int num = 0;
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if (cb.Checked)
                    {
                        num = num + 1;
                    }
                }

                if (num == 0)
                {
                    tag.Text = "请选择一条要操作的纪录！";

                }
                else if (num > 1)
                {
                    tag.Text = "编辑时只能选择一条记录进行操作！";
                }
                else
                {
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        string id = GridView1.DataKeys[j]["ID"].ToString();

                        if (cb1.Checked)
                        {
                            Response.Redirect("addbudget.aspx?pageindex=" + pageindexHidden.Value + "&Status=" + DDL_Status.SelectedValue.ToString() + "&ID=" + id);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 审核通过/审核不通过时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_check_onclick(object sender, EventArgs e)
        {
            //选择审批的条数只能为一条
            int num = 0;
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if (cb.Checked)
                    {
                        num = num + 1;
                    }
                }

                if (num == 0)
                {
                    tag.Text = "请选择一条数据进行审核！";

                }
                else if (num > 1)
                {
                    tag.Text = "审核时最多只能选择一条数据！";

                }
                else
                {
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        string id = GridView1.DataKeys[j]["ID"].ToString();
                        if (cb1.Checked)
                        {
                            Response.Redirect("checkbudget.aspx?ID=" + id + "&pageindex=" + pageindexHidden.Value.ToString() + "&Status=" + DDL_Status.SelectedValue.ToString() + "&role=manager");
                        }


                    }

                }

            }


        }
        /// <summary>
        ///点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_onclick(object sender, EventArgs e)
        {
            //选择编辑的条数只能为一条
            int num = 0;
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if (cb.Checked)
                    {
                        num = num + 1;
                    }
                }

                if (num == 0)
                {
                    tag.Text = "请至少选择一条要操作的纪录！";

                }
                else
                {
                    tag.Text = "";
                    string IDStr = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        string id = GridView1.DataKeys[j]["ID"].ToString();

                        if (cb1.Checked)
                        {
                            IDStr += GridView1.DataKeys[j]["ID"].ToString() + ",";
                        }
                    }

                    try
                    {
                        IDStr = IDStr.TrimEnd(',');
                        string sql = "update Cash_SF_Order set delflag=1 where status=0 and id in (" + IDStr + ")";
                        pageControl.doSql(sql);
                        tag.Text = "撤销成功！";

                        // 添加操作日志
                        Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                        user_model = (Model.USER_Users)Session["USER_Users"];
                        bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "撤销预算申报", "撤销预算申报：成功");

                        string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"budgetmanage.aspx\";</script>";
                        Response.Write(coutws);
                    }
                    catch
                    {
                        tag.Text = "撤销失败！";
                    }
                }
            }
        }

        /// <summary>
        /// 当分页控件中的“第一页”“第二页”...发生时，触发下面的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageChange_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
            pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值
            setRowCout();
            BindData(page);//调用显示

        }
        /// <summary>
        /// 当分页控件中的下拉菜单触发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
            pageindexHidden.Value = page.ToString();
            setRowCout();
            BindData(page);//调用显示

        }

        /// <summary>
        /// 点击全选框时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox_choose_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox CheckBox_Alltemp = (CheckBox)sender;
                if (CheckBox_Alltemp.Checked)//全选
                {
                    grievSearch(true);
                }
                else//全不选
                {
                    grievSearch(false);
                }
            }
            catch
            {
            }
        }

        protected void GetddlStatas()
        {
            DDL_Status.Items.Add(new ListItem("-全部-", ""));
            ListItem li = new ListItem("待审核", "0");
            this.DDL_Status.Items.Add(li);
            li = new ListItem("审核通过", "1");
            this.DDL_Status.Items.Add(li);
            li = new ListItem("审核不通过", "2,23");
            this.DDL_Status.Items.Add(li);
            li = new ListItem("分管领导审核通过", "3");
            this.DDL_Status.Items.Add(li);

            if (Request.Params["Status"] != null && !String.IsNullOrEmpty(Request["Status"]))
            {
                this.DDL_Status.SelectedValue = Request["Status"];
            }
            else
            {
                this.DDL_Status.SelectedValue = "";
            }

            //如果是财务只能查看审核通过的
            if (null != Request["role"] && Request["role"].ToString().Equals("lister"))
            {
                DDL_Status.SelectedValue = "1";
                DDL_Status.Enabled = false;
            }
        }

        /// <summary>
        /// 初始化专项资金选择项下拉列表
        /// </summary>
        protected void GetddlSpecialFunds()
        {
            try
            {
                string sqlwhere = "  and Status =1 ";
                string sql = " SELECT SpecialFundsID, SFName FROM vCash_SF_Order WHERE (SpecialFundsID IS NOT NULL) ";

                if (null != Request["role"] && Request["role"].ToString().Equals("lister"))
                {
                    sql = sql + sqlwhere;
                }
                //以SFName作为第一排序字段 by guanzhq on 2012年3月19日
                //sql = sql + " GROUP BY SpecialFundsID, SFName ";
                sql = sql + " GROUP BY  SFName,SpecialFundsID";

                DataTable DT = new DataTable();
                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    DDL_SpecialFunds.DataSource = DT;
                    DDL_SpecialFunds.DataValueField = "SpecialFundsID";
                    DDL_SpecialFunds.DataTextField = "SFName";
                    DDL_SpecialFunds.DataBind();

                    ListItem li = new ListItem("-全部-", "");
                    DDL_SpecialFunds.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("-暂无可选专项资金-", "");
                    DDL_SpecialFunds.Items.Add(li);
                }
            }
            catch
            { }
        }

        /// <summary>
        ///根据条件给值
        /// </summary>
        /// <param name="isCheck"></param>
        private void grievSearch(bool isCheck)
        {
            try
            {
                int rows = GridView1.Rows.Count;
                if (rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                        if (cb.Enabled == true)
                        {
                            cb.Checked = isCheck;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    //状态
                    string Status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                    //预算报告名称
                    string NAMES = DataBinder.Eval(e.Row.DataItem, "NAMES").ToString();
                    //预算报告路径
                    string BudgetList = DataBinder.Eval(e.Row.DataItem, "BudgetList").ToString();
                    //预算金额
                    string BudgetAmount = DataBinder.Eval(e.Row.DataItem, "BudgetAmount").ToString();
                    //金额单位
                    string BAUNIT = DataBinder.Eval(e.Row.DataItem, "BAUNIT").ToString();

                    //实际确认预算金额
                    string ActualAmount = DataBinder.Eval(e.Row.DataItem, "ActualAmount").ToString();

                    string Amount = BudgetAmount;

                    if (!ActualAmount.Equals(""))
                    {
                        Amount = ActualAmount;
                    }

                    //所属项目
                    string ProjectName = DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString();
                    if (null == ProjectName || ProjectName.Equals(""))
                    {
                        e.Row.Cells[2].Text = "--";
                    }
                    else
                    {
                        e.Row.Cells[2].Text = ProjectName;
                    }

                    //经费审批人
                    string AssignCheckerName = DataBinder.Eval(e.Row.DataItem, "AssignCheckerName").ToString();
                    e.Row.Cells[6].Text = AssignCheckerName.Equals("") ? "--" : AssignCheckerName;

                    //专项资金
                    string SFName = DataBinder.Eval(e.Row.DataItem, "SFName").ToString();
                    e.Row.Cells[7].Text = SFName.Equals("") ? "--" : SFName;

                    if (Request["role"] == null)
                    {
                        e.Row.Cells[7].Visible = false;
                    }

                    //审批时间
                    string CheckTime = DataBinder.Eval(e.Row.DataItem, "CheckTime").ToString();
                    e.Row.Cells[8].Text = CheckTime.Equals("") ? "--" : Convert.ToDateTime(CheckTime).ToString("yyyy-MM-dd");

                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();



                    e.Row.Cells[3].Text = Amount + " " + BAUNIT;

                    CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("CheckBox_choose");
                    //预算审批人
                    string Checker = DataBinder.Eval(e.Row.DataItem, "Checker").ToString();

                    int dw = BAUNIT.Equals("元") ? 1 : 10000;
                    if (Status == "0")
                    {
                        e.Row.Cells[9].Text = "待审核";
                        daishenhe += (float.Parse(Amount) * dw);

                        if (cb != null)
                        {
                            //如果进入的是 经费 > 预算申请  列表  提交的预算申请，如果还没有人审核过时，可以撤销和编辑
                            if (Request["role"] == null)
                            {
                                cb.Enabled = true;
                            }
                            else
                            {
                                //预算审批人是当前登录者的才可以进行审核
                                if (user_model.ID == Checker)
                                {
                                    cb.Enabled = true;
                                }
                                else
                                {
                                    cb.Enabled = false;
                                }
                            }
                        }
                    }
                    else if (Status == "1")
                    {
                        e.Row.Cells[9].Text = "<font color='blue'>审核通过</font>";

                        //用户的权限如果出现在特定的那个组中，可以对审核通过的信息进行再次编辑。
                        if (cb != null)
                        {
                            if (!string.IsNullOrEmpty(BudgetmanageQX) && user_model.GROUPS.Contains(BudgetmanageQX))
                                cb.Enabled = true;
                            else
                                cb.Enabled = false;
                        }
                        tongguo += (float.Parse(Amount) * dw);
                    }
                    else if (Status == "2")
                    {
                        e.Row.Cells[9].Text = "<font color='red'>室主任审核不通过</font>";
                        weitongguo += (float.Parse(Amount) * dw);
                    }
                    else if (Status == "23")
                    {
                        e.Row.Cells[9].Text = "<font color='red'>分管领导审核不通过</font>";
                        weitongguo += (float.Parse(Amount) * dw);
                    }
                    else if (Status == "3")
                    {
                        e.Row.Cells[9].Text = "<font color='blue'>分管领导审核通过</font>";

                        //用户的权限如果出现在特定的那个组中，可以对审核通过的信息进行再次编辑。
                        if (cb != null)
                        {
                            //预算审批人是当前登录者的才可以进行审核
                            if (user_model.ID == Checker)
                                cb.Enabled = true;
                            else
                                cb.Enabled = false;
                        }
                        daishenhe += (float.Parse(Amount) * dw);
                    }
                    HyperLink HL_viewbudget = (HyperLink)e.Row.FindControl("HL_viewbudget");
                    HL_viewbudget.NavigateUrl = @"javascript:window.showModalDialog('viewbudget.aspx?ID=" + ID + "','','dialogWidth=650px;dialogHeight=350px');";
                    //e.Row.Cells[10].Text = "<a href='viewbudget.aspx?ID=" + ID + "' target='_blank'>点击查看</a>";

                    //备注信息
                    string TEMP2 = DataBinder.Eval(e.Row.DataItem, "TEMP2").ToString();

                    e.Row.Cells[1].Text = "<a href='" + BudgetList + "' target='_blank'>" + NAMES + "</a>";

                    HyperLink HL_BZ = (HyperLink)e.Row.FindControl("HL_BZ");
                    HL_BZ.NavigateUrl = @"javascript:window.showModalDialog('viewnotes.aspx?ID=" + ID + "','','dialogWidth=650px;dialogHeight=350px');";

                    //if (null != TEMP2 && !TEMP2.Equals(""))
                    //{
                    //    e.Row.Cells[1].Text = "<table><tr><td width='16' align='center'><img src='/Admin/images/OAimages/fj.jpg' border='0'></td><td align='left'><a href='" + BudgetList + "' target='_blank'>" + NAMES + "</a></td></tr></table>";
                    //}
                    //else
                    //{
                    //    e.Row.Cells[1].Text = "<table><tr><td width='13'></td><td align='left'><a href='" + BudgetList + "' target='_blank'>" + NAMES + "</a></td></tr></table>";

                    //}
                }
                else
                {
                    if (Request["role"] == null)
                    {
                        e.Row.Cells[7].Visible = false;
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 显示年份的数据 by guanzhq on 2012年3月20日
        /// </summary>
        /// <param name="dl"></param>
        /// <param name="years"></param>
        private void showYears(DropDownList dl, string years)
        {
            dl.Items.Clear();
            DateTime dt = DateTime.Now;
            for (int i = 2000; i < dt.Year + 5; i++)
            {
                ListItem li = new ListItem();
                li.Value = i.ToString();
                li.Text = i.ToString() + "年";
                dl.Items.Add(li);
            }
            if (!String.IsNullOrEmpty(years))
            {
                dl.SelectedValue = years;
            }
        }
        /// <summary>
        /// 年份选择改变 by guanzhq on 2012年3月20日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRowCout();
            BindData(1);//调用显示
        }

    }
}
