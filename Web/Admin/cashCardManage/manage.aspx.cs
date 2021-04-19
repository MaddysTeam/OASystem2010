using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class manage : System.Web.UI.Page
    {
        #region 参数
        public string PageRole
        {
            get {
                if (ViewState["PageRole"] != null)
                    return ViewState["PageRole"].ToString();
                return "";
            }
            set { ViewState["PageRole"] = value; }
        }
        #endregion

        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_Cards mCash_Cards = new Dianda.Model.Cash_Cards();
        BLL.Cash_Cards bCash_Cards = new Dianda.BLL.Cash_Cards();
        BllExt.SearchModels.SearchCashCard searchCardModels = new Dianda.BllExt.SearchModels.SearchCashCard();//搜索资金卡的类
        COMMON.common common = new COMMON.common();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判断当前页面是从哪个入口进来的，role=manage是可以进行操作，如果不是则只能查看 2012-4-13修改
                if (Request["role"] != null)
                    PageRole = common.cleanXSS(Request["role"].ToString());
                if (PageRole == "viewer")
                {
                    OAleftmenu_Show1.Visible = true;
                    ShowButton(false);
                }
                else
                {
                    OAleftmenu1.Visible = true;
                    ShowButton(true);
                }
                //string objName = "信息发布";
                //LB_name.Text = objName;
                getSearchCardModel();//将历史的数据回显出来
                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    setRowCout();//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    count = dtrowsHidden.Value.ToString();
                }
                else
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
                SetCardMessage();
                BindData(pageindex_int);

                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 ";
                /*设置模板页中的管理值*/
            }
        }

        public void ShowButton(bool b)
        {
            Button_add.Visible = b;
            Button_modify.Visible = b;
            Button_delete.Visible = b;
            Button_recover.Visible = b;
            Button_div.Visible = b;
            Button_LimitNums.Visible = b;
            GridView1.Columns[0].Visible = b;
        }
        private void SetCardMessage()
        {
            string strSQL = " SELECT ID FROM vCash_Message WHERE IsRead=0 and Status=1 ";
            DataTable dt = new DataTable();
            dt = pageControl.doSql(strSQL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                //this.lblshowMessage.Text = "<a onclick=\"window.open('showMessage.aspx', '_blank', 'height=550, width=800, top=200, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')\" class=\"zjk_tongz\"> 新设资金卡通知(" + dt.Rows.Count + ")</a>";

                //弹出层
                this.lblshowMessage.Text = "<a style='color:red;text-decoration:none;' href=\"javascript:window.showModalDialog('showMessage.aspx','','dialogWidth=716px;dialogHeight=330px');window.location=window.location;\" title='操作记录查看'>新设资金卡通知(" + dt.Rows.Count + ")</a>";

                // this.Button_Message.Text = "新设资金卡通知(" + dt.Rows.Count + ")";
            }
            else
            {
                //this.lblshowMessage.Text = "<a onclick=\"window.open('showMessage.aspx', '_blank', 'height=550, width=800, top=200, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')\"> 新设资金卡通知</a>";

                //弹出层
                this.lblshowMessage.Text = "<a style='color:red;text-decoration:none;' href=\"javascript:window.showModalDialog('showMessage.aspx','','dialogWidth=716px;dialogHeight=330px');window.location=window.location;\" title='操作记录查看' target='_self'>新设资金卡通知</a>";
            }
        }

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout()
        {
            try
            {
                string strSQL = "SELECT ID FROM vCash_Cards WHERE " + SQLCondition();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        protected void BindData(int pageindex)
        {
            try
            {
                //string strSQL = "SELECT * FROM vNews_News WHERE " + SQLCondition();
                DataTable dt = new DataTable();
                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                dt = pageControl.GetList_FenYe_Common(SQLCondition(), pageindex, GridView1.PageSize, alltiaoshuInt, "vCash_Cards", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (dt.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    Button_modify.Enabled = true;
                    Button_delete.Enabled = true;
                    Button_recover.Enabled = true;
                    Button_div.Enabled = true;
                    Button_LimitNums.Enabled = true;
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";
                    tag.Text = "";

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    GridView1.Visible = false;
                    Button_modify.Enabled = false;
                    Button_delete.Enabled = false;
                    Button_recover.Enabled = false;
                    Button_div.Enabled = false;
                    Button_LimitNums.Enabled = false;
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
                        cb.Checked = isCheck;
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 获取所属部门列表
        /// </summary>
        private void GetddlDepartmentID()
        {
            DataTable dt = new DataTable();
            //string sql = "SELECT ID,[Name] FROM USER_Groups WHERE DELFLAG=0 group by ID,[Name]";
            string sql = " SELECT DepartmentName, DepartmentID FROM vCash_Cards GROUP BY DepartmentName, DepartmentID";
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.ddlDepartmentID.DataSource = dt;
                this.ddlDepartmentID.DataTextField = "DepartmentName";
                this.ddlDepartmentID.DataValueField = "DepartmentID";
                this.ddlDepartmentID.DataBind();

                ListItem li = new ListItem("-全部-", "9999");
                li.Selected = true;
                ddlDepartmentID.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("-暂无可选部门-", "");
                ddlDepartmentID.Items.Insert(0, li);
            }
        }

        /// <summary>
        /// 获取项目列表
        /// </summary>
        private void GetddlProjectID()
        {
            DataTable dt = new DataTable();
            //string sql = "Select NAMES,ID From Project_Projects Where DELFLAG=0 and  [Status]=1";
            string sql = " SELECT ProjectName, ProjectID FROM vCash_Cards WHERE (ProjectID IS NOT NULL) GROUP BY ProjectName, ProjectID ";
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.ddlProjectID.DataSource = dt;
                this.ddlProjectID.DataTextField = "ProjectName";
                this.ddlProjectID.DataValueField = "ProjectID";
                this.ddlProjectID.DataBind();

                ListItem li = new ListItem("-全部-", "9999");
                li.Selected = true;
                ddlProjectID.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("-暂无可选项目-", "");
                ddlProjectID.Items.Insert(0, li);
            }
        }

        /// <summary>
        /// 获取专项资金列表
        /// </summary>
        private void GetddlSpecialFundsID()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT SpecialFundsID, SpecialFundsName FROM vCash_Cards GROUP BY SpecialFundsName, SpecialFundsID ";
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.DDL_SpecialFundsID.DataSource = dt;
                this.DDL_SpecialFundsID.DataTextField = "SpecialFundsName";
                this.DDL_SpecialFundsID.DataValueField = "SpecialFundsID";
                this.DDL_SpecialFundsID.DataBind();

                ListItem li = new ListItem("-全部-", "9999");
                li.Selected = true;
                DDL_SpecialFundsID.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("-暂无可选专项资金-", "");
                DDL_SpecialFundsID.Items.Insert(0, li);
            }
        }

        /// <summary>
        /// 获取专项资金列表
        /// </summary>
        private void GetddlSFOrderID()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT SFOrderID, SFOrderName FROM vCash_Cards GROUP BY SFOrderName, SFOrderID ";
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.DDL_SFOrderID.DataSource = dt;
                this.DDL_SFOrderID.DataTextField = "SFOrderName";
                this.DDL_SFOrderID.DataValueField = "SFOrderID";
                this.DDL_SFOrderID.DataBind();

                ListItem li = new ListItem("-全部-", "9999");
                li.Selected = true;
                DDL_SFOrderID.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("-暂无可选预算报告-", "");
                DDL_SFOrderID.Items.Insert(0, li);
            }
        }

        /// <summary>
        /// 点击搜索按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_div_onclick(object sender, EventArgs e)
        {
            this.div2.Visible = true;
            tag.Text = "";
            GetddlDepartmentID();
            GetddlProjectID();
            GetddlSpecialFundsID();
            GetddlSFOrderID();
            //searchCardModels = null;//初始化
            //Session["_searchCardModel_session"] = null;
            getSearchCardModel();//将历史的数据回显出来

            LB_SX.Visible = false;
            DDL_SX.Visible = false;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_search_onclick(object sender, EventArgs e)
        {
            setRowCout();
            BindData(1);//调用显示
            setSearchCardModel();
        }
        /// <summary>
        /// 设置搜索的资金卡的值
        /// </summary>
        private void setSearchCardModel()
        {
            searchCardModels.cardName = txtCardName.Text.ToString();
            searchCardModels.cardNum = txtCardNum.Text.ToString();
            searchCardModels.Cash_SF_Order = DDL_SFOrderID.SelectedValue.ToString();
            searchCardModels.datetime = TB_AddDateTime.Value.ToString();
            searchCardModels.partmentid = ddlDepartmentID.SelectedValue.ToString();
            searchCardModels.projectid = ddlProjectID.SelectedValue.ToString();
            searchCardModels.specialFundsID = DDL_SpecialFundsID.SelectedValue.ToString();
            searchCardModels.whos = txtCardholderRealName.Text.ToString();
            searchCardModels.Cash_ZT = DDL_ZT.SelectedValue.ToString();

            Session["_searchCardModel_session"] = searchCardModels;
        }
        /// <summary>
        /// 获取到搜索值
        /// </summary>
        private void getSearchCardModel()
        {
            try
            {
                if (Session["_searchCardModel_session"] != null)
                {
                    this.div2.Visible = true;
                    tag.Text = "";
                    GetddlDepartmentID();
                    GetddlProjectID();
                    GetddlSpecialFundsID();
                    GetddlSFOrderID();

                    searchCardModels = (BllExt.SearchModels.SearchCashCard)Session["_searchCardModel_session"];

                    txtCardName.Text = searchCardModels.cardName.ToString();
                    txtCardNum.Text = searchCardModels.cardNum;
                    DDL_SFOrderID.SelectedValue = searchCardModels.Cash_SF_Order;
                    TB_AddDateTime.Value = searchCardModels.datetime;
                    ddlDepartmentID.SelectedValue = searchCardModels.partmentid;
                    ddlProjectID.SelectedValue = searchCardModels.projectid;
                    DDL_SpecialFundsID.SelectedValue = searchCardModels.specialFundsID;
                    txtCardholderRealName.Text = searchCardModels.whos;
                    DDL_ZT.SelectedValue = searchCardModels.Cash_ZT;

                    LB_SX.Visible = false;
                    DDL_SX.Visible = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 点击关闭按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_close_onclick(object sender, EventArgs e)
        {
            this.txtCardNum.Text = "";
            this.txtCardName.Text = "";
            this.txtCardholderRealName.Text = "";
            this.ddlDepartmentID.SelectedIndex = 0;
            this.ddlProjectID.SelectedIndex = 0;
            this.div2.Visible = false;

            LB_SX.Visible = true;
            DDL_SX.Visible = true;
            DDL_SX.SelectedValue = DDL_ZT.SelectedValue;
        }

        /// <summary>
        /// 点击资金卡金额调整钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_LimitNums_onclick(object sender, EventArgs e)
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
                    tag.Text = "请选择一条数据进行编辑！";

                }
                else if (num > 1)
                {
                    tag.Text = "编辑时最多只能选择一条数据！";
                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
                        string id = GridView1.DataKeys[j]["ID"].ToString();
                        //string ForItems = GridView1.DataKeys[j]["ForItems"].ToString();
                        //string PARENTID = GridView1.DataKeys[j]["PARENTID"].ToString();
                        //string LimitsChooseID = GridView1.DataKeys[j]["LimitsChooseID"].ToString();
                        if (cb1.Checked)
                        {
                            if (!GridView1.Rows[j].Cells[9].Text.Contains("过期"))
                            {
                                Response.Redirect("addHistory.aspx?id=" + id + "&pageindex=" + pageindexHidden.Value);
                                // this.H_ModifyID.Value = hid.Value;
                                //BindModifyData(hid.Value);
                                //this.div2.Visible = true;
                            }
                            else
                            {
                                tag.Text = "过期的资金卡不能记账！";
                            }
                        }
                    }
                }
            }
        }

        ///// <summary>
        ///// 点击新设资金卡通知按钮触发的事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void Button_Message_onclick(object sender, EventArgs e)
        //{
        //    Response.Write("<script>window.open('showMessage.aspx', '_blank', 'height=400, width=600, top=400, left=400, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')</script>");
        //}

        /// <summary>
        /// 点击新增按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_add_onclick(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx?pageindex=" + pageindexHidden.Value);
        }
        /// <summary>
        /// 点击编辑按钮触发的事件
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
                    tag.Text = "请选择一条数据进行编辑！";

                }
                else if (num > 1)
                {
                    tag.Text = "编辑时最多只能选择一条数据！";
                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
                        string id = GridView1.DataKeys[j]["ID"].ToString();
                        //string ForItems = GridView1.DataKeys[j]["ForItems"].ToString();
                        //string PARENTID = GridView1.DataKeys[j]["PARENTID"].ToString();
                        //string LimitsChooseID = GridView1.DataKeys[j]["LimitsChooseID"].ToString();

                        if (cb1.Checked)
                        {
                            Response.Redirect("modify.aspx?id=" + id + "&pageindex=" + pageindexHidden.Value+"&action=modify");
                            // this.H_ModifyID.Value = hid.Value;
                            //BindModifyData(hid.Value);
                            //this.div2.Visible = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 点击删除按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_delete_onclick(object sender, EventArgs e)
        {
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
                    tag.Text = "注销时最少选择一条数据！";

                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
                        string id = GridView1.DataKeys[j]["ID"].ToString();
                        if (cb1.Checked)
                        {
                            mCash_Cards = new Dianda.Model.Cash_Cards();
                            mCash_Cards = bCash_Cards.GetModel(Int32.Parse(id));
                            mCash_Cards.Statas = 0;
                            bCash_Cards.Update(mCash_Cards);

                            tag.Text = "操作成功！";
                            // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";


                            // 添加操作日志
                            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "注销资金卡" + mCash_Cards.CardNum /*Request["tags"].ToString()*/, "注销资金卡成功");

                            string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";
                            Response.Write(coutws);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 点击恢复按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_recover_onclick(object sender, EventArgs e)
        {
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
                    tag.Text = "恢复时最少选择一条数据！";

                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
                        string id = GridView1.DataKeys[j]["ID"].ToString();
                        if (cb1.Checked)
                        {
                            mCash_Cards = new Dianda.Model.Cash_Cards();
                            mCash_Cards = bCash_Cards.GetModel(Int32.Parse(id));
                            mCash_Cards.Statas = 1;
                            bCash_Cards.Update(mCash_Cards);

                            tag.Text = "操作成功！";
                            // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";


                            // 添加操作日志
                            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "恢复资金卡" + mCash_Cards.CardNum /*Request["tags"].ToString()*/, "恢复资金卡成功");

                            string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";
                            Response.Write(coutws);
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
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string NAME = this.txtNAME.Text;//获取到用户名

            //    //检查该名称是否有了
            //    if (NAME != "")
            //    {
            //        //检查是否有该用户组名称
            //        bool checkName = PageControl.Exists_Name("News_Columns", "NAME", NAME, "ID", "");
            //        if (checkName)
            //        {
            //            tag.Text = "该名称已经存在，请修改！";
            //            return;
            //        }
            //        if (this.ddlPARENTID.SelectedIndex == 0)
            //        {
            //            tag.Text = "请选择父栏目！";
            //            return;
            //        }
            //        mNews_Columns = new Dianda.Model.News_Columns();

            //        mNews_Columns.NAME = txtNAME.Text;
            //        mNews_Columns.PARENTID = Int32.Parse(ddlPARENTID.SelectedValue);



            //        //密码
            //        users_Model.PASSWORD = commons.GetMD5(TB_PASSWORD.Text.Trim());
            //        //真实姓名
            //        users_Model.REALNAME = TB_REALNAME.Text;
            //        //性别
            //        users_Model.SEX = RadioButtonList_SEX.SelectedValue.ToString();
            //        //部门
            //        users_Model.DepartMentID = DDL_DEPARTMENT.SelectedValue.ToString();
            //        //岗位
            //        users_Model.StationID = DDL_Station.SelectedValue.ToString();
            //        //联系电话
            //        users_Model.TEL = TB_TEL.Text;
            //        //邮箱
            //        users_Model.EMAIL = TB_EMAIL.Text;
            //        //在职状态
            //        users_Model.WorkStats = DDL_WorkStats.SelectedValue.ToString();
            //        //入职时间
            //        users_Model.DatesEmployed = Convert.ToDateTime(TB_DatesEmployed.Value.ToString());
            //        //离职时间
            //        users_Model.LeaveDates = Convert.ToDateTime(TB_LeaveDates.Value.ToString());
            //        //生日
            //        users_Model.BIRTHDAY = TB_BIRTHDAY.Value.ToString();
            //        //籍贯
            //        users_Model.NativePlace = TB_NativePlace.Text;
            //        //学历
            //        users_Model.EducationLevel = DDL_EducationLevel.SelectedValue.ToString();
            //        //住址
            //        users_Model.ADDRESS = TB_ADDRESS.Text.ToString();
            //        //毕业学校
            //        users_Model.GraduateSchool = TB_GraduateSchool.Text;
            //        //专业
            //        users_Model.Major = TB_Major.Text;
            //        //工作履历
            //        users_Model.TrackRecord = TB_TrackRecord.Text;
            //        //时间
            //        users_Model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
            //        //工作组
            //        users_Model.GROUPS = "";
            //        //头像
            //        users_Model.IMAGES = "";
            //        //删除标记
            //        users_Model.DELFLAG = 0;

            //        users_Bll.Add(users_Model);

            //        tag.Text = "操作成功！";

            //        string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx" + "\";</script>";


            //        Response.Write(coutws);

            //        //添加操作日志

            //        Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
            //        Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
            //        bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加人员", "添加成功");
            //        //添加操作日志

            //    }
            //}
            //catch
            //{
            //    tag.Text = "操作失败，请重试！";
            //}
        }

        /// <summary>
        /// 点击重置按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_Click(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// 点击返回全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_viewall_onclick(object sender, EventArgs e)
        {
            searchCardModels = null;//初始化
            Session["_searchCardModel_session"] = null;
            Response.Redirect("manage.aspx");
        }

        /// <summary>
        /// 点击取消按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            // this.div2.Visible = false;
        }

        //protected void BindModifyData(string id)
        //{

        //}

        //protected void ddlMailBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    setRowCout();
        //    BindData(1);//调用显示
        //}
        protected void DDL_SX_Change(object sender, EventArgs e)
        {
            setRowCout();
            SetCardMessage();
            BindData(1);
        }
        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 ");
            if (!String.IsNullOrEmpty(this.txtCardNum.Text.Trim()))
            {
                sbSql.Append(" AND CardNum like '%" + this.txtCardNum.Text.Trim() + "%' ");
            }
            if (!String.IsNullOrEmpty(this.txtCardName.Text.Trim()))
            {
                sbSql.Append(" AND CardName like '%" + this.txtCardName.Text.Trim() + "%' ");
            }
            if (!String.IsNullOrEmpty(this.txtCardholderRealName.Text.Trim()))
            {
                sbSql.Append(" AND CardholderRealName like '%" + this.txtCardholderRealName.Text.Trim() + "%' ");
            }
            if (this.ddlDepartmentID.SelectedValue != "9999" && this.ddlDepartmentID.SelectedValue != "")
            {
                sbSql.Append(" AND DepartmentID ='" + this.ddlDepartmentID.SelectedValue + "' ");
            }
            if (this.ddlProjectID.SelectedValue != "9999" && this.ddlProjectID.SelectedValue != "")
            {
                sbSql.Append(" AND ProjectID ='" + this.ddlProjectID.SelectedValue + "' ");
            }
            if (!String.IsNullOrEmpty(this.TB_AddDateTime.Value.Trim()))
            {
                sbSql.Append(" AND DATETIME between '" + TB_AddDateTime.Value.ToString() + " 00:00:00' and '" + TB_AddDateTime.Value.ToString() + " 23:59:59'");

            }
            if (this.DDL_SpecialFundsID.SelectedValue != "9999" && this.DDL_SpecialFundsID.SelectedValue != "")
            {
                sbSql.Append(" AND SpecialFundsID ='" + this.DDL_SpecialFundsID.SelectedValue + "' ");
            }
            if (this.DDL_SFOrderID.SelectedValue != "9999" && this.DDL_SFOrderID.SelectedValue != "")
            {
                sbSql.Append(" AND SFOrderID ='" + this.DDL_SFOrderID.SelectedValue + "' ");
            }
            if (DDL_SX.Visible==true&&DDL_SX.SelectedValue != "")
            {
                if (!DDL_SX.SelectedValue.Equals("已过期"))
                {
                    sbSql.Append(" AND Statas ='" + DDL_SX.SelectedValue + "' AND EndTime >= '" + DateTime.Now + "'");
                }else
                {
                    sbSql.Append(" AND EndTime < '" + DateTime.Now+"'");
                }
                
            }
            if (DDL_SX.Visible==false&&DDL_ZT.SelectedValue != "")
            {
                if (!DDL_ZT.SelectedValue.Equals("已过期"))
                {
                    sbSql.Append(" AND Statas ='" + DDL_ZT.SelectedValue + "' AND EndTime >= '" + DateTime.Now + "'");
                }
                else
                {
                    sbSql.Append(" AND EndTime < '" + DateTime.Now + "'");
                }
            }
            //sbSql.Append("ORDER BY ID ");
            return sbSql.ToString();
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
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    //HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    string CardName = DataBinder.Eval(e.Row.DataItem, "CardName").ToString();
                    string time = DataBinder.Eval(e.Row.DataItem, "EndTime").ToString();
                    string CardNum = DataBinder.Eval(e.Row.DataItem, "CardNum").ToString();
                    string projectName = DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString();
                    string BudgetList = DataBinder.Eval(e.Row.DataItem, "BudgetList").ToString();
                    string SFOrderName = DataBinder.Eval(e.Row.DataItem, "SFOrderName").ToString();
                    //string Notes = DataBinder.Eval(e.Row.DataItem, "NOTES").ToString();
                    if (!string.IsNullOrEmpty(time))
                    {
                        DateTime dtime = new DateTime();
                        //获取当前资金卡的到期日期                
                        dtime = DateTime.Parse(time);
                        //判断是否过期
                        if (DateTime.Parse(DateTime.Now.ToLongDateString()) > dtime)
                        {
                            e.Row.Cells[12].Text = "<span style='color:Red'>已过期</span>";
                        }
                    }
                    //e.Row.Cells[2].Text = "<a href=\"javascript:window.showModalDialog('showHistory.aspx?id=" + ID + "','','dialogWidth=726px;dialogHeight=400px');\" title='" + CardNum + "'>" + CardName + "</a>";

                    e.Row.Cells[2].Text = "<a href='showHistory.aspx?id=" + ID + "&PageRole=" + PageRole + "' title='" + CardNum + "'>" + CardName + "</a>";
                    if (projectName.Equals(""))
                    {
                        e.Row.Cells[7].Text = "--";
                    }
                    else
                    {
                        e.Row.Cells[7].Text = projectName;
                    }

                    e.Row.Cells[10].Text = "<a href='" + BudgetList + "' target='_blank'>" + SFOrderName + "</a>";
                }
            }
            catch
            {
            }
        }
    }
}
