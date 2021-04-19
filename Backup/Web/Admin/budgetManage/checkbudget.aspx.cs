using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.budgetManage
{
    public partial class checkbudget : System.Web.UI.Page
    {
        Dianda.COMMON.fileUploads fileup = new Dianda.COMMON.fileUploads();
        Model.Cash_SF_Order order_model = new Dianda.Model.Cash_SF_Order();
        BLL.Cash_SF_Order order_bll = new Dianda.BLL.Cash_SF_Order();
        COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        BllExt.Groups groups_bllext = new Dianda.BllExt.Groups();
        BllExt.StaticFactory_CASH cash_bllext = new Dianda.BllExt.StaticFactory_CASH();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowInitInfor(Request["ID"].ToString());

                ShowMain();

                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 预算管理 > 预算审批 ";
                //设置模板页中的管理值
            }
        }

        /// <summary>
        /// 初始化审核信息
        /// </summary>
        /// <param name="ID"></param>
        protected void ShowInitInfor(string ID)
        {
            try
            {
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                string groups = "";
                if (null != user_model)
                {
                    groups = user_model.GROUPS.ToString();//用来获取当前登录人的权限ID
                }

                //显示专项资金列表
                ShowSpecialFunds();
                //显示经费指定审批人
                ShowAssignChecker();

                DataTable DT = new DataTable();
                string sql = " SELECT * FROM vCash_SF_Order WHERE ID='" + ID + "' ";

                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    //预算报告的路径
                    string BudgetList = DT.Rows[0]["BudgetList"].ToString();

                    //预算申请名称
                    string Name = DT.Rows[0]["NAMES"].ToString();
                    //增加提示字样 by guanzhq on 2012年3月19日
                    //LB_Name.Text = "<a href='" + BudgetList + "' target='_blank'>" + Name + "</a>";
                    LB_Name.Text = "<a href='" + BudgetList + "' target='_blank'>" + Name + "(点击下载)" + "</a>";

                    //所属项目
                    string ProjectID = DT.Rows[0]["ProjectID"].ToString();
                    if (ProjectID.Equals("9999"))
                    {
                        LB_Project.Text = "暂无所属项目";
                    }
                    else
                    {
                        if (null != DT.Rows[0]["ProjectName"] && !DT.Rows[0]["ProjectName"].ToString().Equals(""))
                        {
                            LB_Project.Text = DT.Rows[0]["ProjectName"].ToString();
                        }
                        else
                        {
                            LB_Project.Text = "无";
                        }
                    }

                    //预算金额
                    string BudgetAmount = DT.Rows[0]["BudgetAmount"].ToString();
                    string Amount = BudgetAmount;
                    //预算金额单位
                    string BAUNIT = DT.Rows[0]["BAUNIT"].ToString();
                    //实际确认预算金额
                    if (null != DT.Rows[0]["ActualAmount"] && !DT.Rows[0]["ActualAmount"].ToString().Equals(""))
                    {
                        Amount = DT.Rows[0]["ActualAmount"].ToString();
                    }

                    LB_BudgetAmount.Text = Amount + " " + BAUNIT;

                    //预算申报时间　
                    LB_AddTime.Text = Convert.ToDateTime(DT.Rows[0]["ADDTIME"].ToString()).ToString("yyyy-MM-dd HH:mm");

                    //备注信息
                    Overviews.Value = DT.Rows[0]["TEMP2"].ToString();

                    //*****申报审核信息

                    //确认预算金额
                    if (null != DT.Rows[0]["ActualAmount"] && !DT.Rows[0]["ActualAmount"].ToString().Equals(""))
                    {
                        TB_ActualAmount.Text = DT.Rows[0]["ActualAmount"].ToString();
                    }

                    //预算金额单位
                    if (null != DT.Rows[0]["AAUNIT"] && !DT.Rows[0]["AAUNIT"].ToString().Equals(""))
                    {
                        RB_AAUNIT.SelectedValue = DT.Rows[0]["AAUNIT"].ToString().Equals("元") ? "0" : "1";
                    }
                    //专项资金
                    if (null != DT.Rows[0]["SpecialFundsID"] && !DT.Rows[0]["SpecialFundsID"].ToString().Equals(""))
                    {
                        DDL_SpecialFundsID.SelectedValue = DT.Rows[0]["SpecialFundsID"].ToString();
                    }
                    //指定经费审批人
                    if (null != DT.Rows[0]["AssignChecker"] && !DT.Rows[0]["AssignChecker"].ToString().Equals(""))
                    {
                        DDL_AssignChecker.SelectedValue = DT.Rows[0]["AssignChecker"].ToString();
                    }

                    //string Status = DT.Rows[0]["Status"].ToString();
                    //if (Status.Equals("0") && !DT.Rows[0]["CheckerHistory"].ToString().Equals(""))//说明至少审过一次了，并有下一审核人
                    //{
                    //    //审批结果
                    //    RBL_check.Items.FindByValue(Status).Selected = true;

                    //    DDL_Checker.Visible = true;

                    //    DDL_Checker.SelectedValue = DT.Rows[0]["Checker"].ToString();
                    //}
                    //else if (Status.Equals("1"))    //审批通过说明是
                    //{
                    //    RBL_check.Items.FindByValue("1").Selected = true;
                    //    RBL_Checker.Items.FindByValue(Status).Selected = true;
                    //    RBL_check.Enabled = false;
                    //    RBL_Checker.Enabled = false;
                    //}
                    //else
                    //{
                    //    RBL_check.Items.FindByValue("1").Selected = true;
                    //    DDL_Checker.Visible = false;
                    //}


                    //陈雨  2012年7月20日12:16:07 修改
                    if (groups.IndexOf("20120507141002be1a2329-8f71-4c8c-ac5b-d018f8411bfb") > -1)//判断用户的权限里面有没有  财务   若有  则是室主任  若无则是分管领导
                    {
                        RBL_check.Enabled = false;
                        RBL_check.Items.FindByValue("1").Selected = true;
                        DDL_Checker.Visible = true;
                        DDL_Checker.SelectedValue = DT.Rows[0]["Checker"].ToString();
                    }
                    else
                    {
                        RBL_check.Enabled = false;
                        RBL_check.Items.FindByValue("0").Selected = true;
                        DDL_Checker.Visible = false;
                    }


                    //显示专项资金的基本信息
                    if (!DDL_SpecialFundsID.SelectedValue.ToString().Equals(""))
                    {
                        DataTable DT_SpecialFunds = cash_bllext.getCash_SpecialFunds();

                        if (DT_SpecialFunds.Rows.Count > 0)
                        {
                            DataRow[] dr = DT_SpecialFunds.Select("ID='" + DDL_SpecialFundsID.SelectedValue.ToString() + "'");
                            if (dr.Length > 0)
                            {
                                //资金总额
                                LB_total.Text = dr[0]["TotalNum"].ToString() + "元";
                                //可用资金　
                                LB_KEYong.Text = dr[0]["Balance"].ToString() + "元";
                            }
                            else
                            {
                                //资金总额
                                LB_total.Text = "0元";
                                //可用资金　
                                LB_KEYong.Text = "0元";
                            }
                        }

                        SpecialFundsOrder1.ShowList(DDL_SpecialFundsID.SelectedValue.ToString());
                    }
                    else
                    {
                        SpecialFundsOrder1.Visible = false;
                    }

                }
            }
            catch
            { }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ShowMain()
        {
            //分管领导审批
            if (RBL_check.SelectedValue.Equals("0"))
            {
                tr_SpecialFunds.Visible = false;
                tr_AssignChecker.Visible = false;
                //要求显示 by guanzhq on 2012年4月23日  begin
                //td_SpecialFundsOrder.Visible = false;

                td_SpecialFundsOrder.Visible = false;    //右边的专项资金  分管领导不显示   陈雨  2012年7月20日12:17:10

                //显示 by guanzhq on 2012年4月23日  end
                //限制输入金额 by guanzhq on 2012年3月19日
                tr_BudgetAmount.Visible = false;

                RBL_Checker.Items.Clear();

                ListItem li = new ListItem("不通过", "2");
                RBL_Checker.Items.Add(li);

                ListItem li1 = new ListItem("继续审核", "0");
                RBL_Checker.Items.Add(li1);

                RBL_Checker.Items[1].Selected = true;
                DDL_Checker.Visible = true;
            }
            else//室主任审批
            {
                tr_SpecialFunds.Visible = true;
                tr_AssignChecker.Visible = true;
                td_SpecialFundsOrder.Visible = true;
                DDL_Checker.Visible = false;
                //不限制输入金额 by guanzhq on 2012年3月19日
                tr_BudgetAmount.Visible = true;

                RBL_Checker.Items.Clear();

                ListItem li = new ListItem("不通过", "2");
                RBL_Checker.Items.Add(li);

                ListItem li2 = new ListItem("通过", "1");
                RBL_Checker.Items.Add(li2);

                //室主任 不该有继续审核 by guanzhq on 2012年3月19日
                //ListItem li1 = new ListItem("继续审核", "0");
                //RBL_Checker.Items.Add(li1);


                RBL_Checker.Items[1].Selected = true;
            }
        }
        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_click(object sender, EventArgs e)
        {
            try
            {
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                string ID = Request["ID"].ToString();
                DataTable UserIDdt = new DataTable();
                bool TnF = false;
                tag.Text = "";

                if (RBL_check.SelectedValue == "")
                {
                    tag.Text = "请选择审批权限！";
                    return;
                }

                order_model = order_bll.GetModel(int.Parse(ID));

                //审核状态,如果审核状态是1，表示当前预算报告是审核通过后，由“预算管理”人员进来重新修改的
                //此时修改需要向（财务、秘书、审批过的分管领导（给于同意的）、申请人）发送信息
                if (order_model.Status == 1)
                {
                    TnF = true;
                    string UserIDStr = "";                                  //用户id字符串
                    string UserNameStr = "";                                //用户名字符串
                    UserIDStr = order_model.Applyuser;                  //申请人id
                    if (!string.IsNullOrEmpty(order_model.TEMP1)) UserIDStr += "," + order_model.TEMP1;       //上一审批人id

                    string CheckerHistory = order_model.CheckerHistory.TrimStart(';');      //审核的历史记录
                    string[] CHarr = CheckerHistory.Split(';');
                    //找出所有审核过的人员
                    for (int i = 0; i < CHarr.Length; i++)
                    {
                        string[] s = CHarr[i].Split(':');
                        UserNameStr += s[0] + ",";
                    }
                    UserNameStr = UserNameStr.TrimEnd(',');
                    UserIDStr = UserIDStr.Replace(",", "','");
                    UserNameStr = UserNameStr.Replace(",", "','");

                    string sql = "select distinct a.id from USER_Users a " +
                                    " left outer join USER_Groups b on a.groups like '%'+b.id+'%' " +
                                    " where (b.tags='普通组' and b.name in ('财务','秘书'))" +
                                    " or a.id in ('" + UserIDStr + "') or a.username in ('" + UserNameStr + "')";
                    UserIDdt = pageControl.doSql(sql).Tables[0];
                }
                //室主任审批
                if (RBL_check.SelectedValue.Equals("1"))
                {
                    //专项资金
                    int special;
                    if (int.TryParse(DDL_SpecialFundsID.SelectedValue.ToString(), out special))
                    {
                        order_model.SpecialFundsID = special;
                    }
                    //order_model.SpecialFundsID = int.Parse(DDL_SpecialFundsID.SelectedValue.ToString());
                    //指定经费审批人
                    order_model.AssignChecker = DDL_AssignChecker.SelectedValue.ToString();
                }

                //实际确认预算金额
                if (tr_BudgetAmount.Visible == true)
                    order_model.ActualAmount = decimal.Parse(TB_ActualAmount.Text.Trim().ToString());
                //实际确认预算金额单位
                order_model.AAUNIT = RB_AAUNIT.SelectedValue.ToString();
                if (FileUpload_list.FileName.Length > 2)
                {
                    string[] content = fileup.UpFile_COMMONS(FileUpload_list, "/AllFileUp/fileup", "");
                    //1-成功；0-失败；2-类型不支持；3-大小不符合;文件的路径；文件名称；文件类型；图标；大小；操作结果
                    if (content[0] == "0")
                    {
                        tag.Text = "文件上传失败，请重新上传！";
                        return;
                    }
                    else if (content[0] == "2")
                    {
                        tag.Text = "系统不允许此类文件上传,文件上传失败，请重新上传！";
                        return;
                    }
                    else if (content[0] == "3")
                    {
                        tag.Text = "文件上传大小不符合，文件上传失败，请重新上传！";
                        return;
                    }

                    //备注信息
                    order_model.Note = order_model.Note + "<br>" + user_model.REALNAME + " " + DateTime.Now + "上传预算报告：<a href='" + content[1].ToString() + "' target='_blank'>" + FileUpload_list.FileName.ToString() + "</a><br>";

                    order_model.BudgetList = content[1];
                }


                string check = ""; //审核结果
                if (RBL_check.SelectedIndex == 0)
                {
                    if (RBL_Checker.SelectedValue == "0")
                        check = "3"; //如果是分管领导审核通过  那么把状态  status改为 3 （分管领导审核通过）    陈雨 2012年7月20日12:31:34
                    else if (RBL_Checker.SelectedValue == "2")
                        check = "23";
                }
                else
                {
                    check = RBL_Checker.SelectedValue.ToString();
                }

                order_model.Status = int.Parse(check);

                string checkvalue = RBL_Checker.SelectedItem.Text.ToString();

                if (check.Equals("3"))//表示需要继续审核
                {
                    //如果有一下审批人，那么则要将原来的审批人变成上一审批人存储起来，因为需要发送信息
                    order_model.TEMP1 = order_model.Checker;
                    //下一审核人
                    order_model.Checker = DDL_Checker.SelectedValue.ToString();
                    //如果是继续审核则显示指定的下一审批人
                    checkvalue = checkvalue + "(" + DDL_Checker.SelectedItem.ToString() + ")";
                }
                else
                {
                    //预算审批人
                    order_model.Checker = user_model.ID;
                    if (check.Equals("1"))//如果是审核通过，需要发送新建资金卡的通知
                    {
                        Dianda.Model.Cash_Message cashmessage_model = new Dianda.Model.Cash_Message();
                        Dianda.BLL.Cash_Message cashmessage_bll = new Dianda.BLL.Cash_Message();

                        //资金卡名称,加入的就是预算报告
                        cashmessage_model.CardName = "《" + order_model.NAMES.ToString() + "》的新建资金卡通知！";
                        //持卡人
                        cashmessage_model.CardholderID = "";
                        //项目的ID
                        cashmessage_model.ProjectID = order_model.ProjectID;
                        //初始金额
                        cashmessage_model.LimitNums = (order_model.ActualAmount) * (order_model.AAUNIT.Equals("元") ? 1 : 10000);
                        //填写的时间
                        cashmessage_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToString());
                        //发出这个消息的用户的ID
                        cashmessage_model.SendUserID = user_model.ID;
                        //备注说明
                        cashmessage_model.Notes = "预算报告：‘" + order_model.NAMES.ToString() + "’的新建资金卡通知！发送人：" + user_model.REALNAME;
                        //是否已经阅读
                        cashmessage_model.IsRead = 0;
                        //消息的状态
                        cashmessage_model.Status = 1;
                        //所属预算报告
                        cashmessage_model.SFOrderID = order_model.ID;

                        Session["Cash_Message_temps"] = cashmessage_model;

                        //向信息表中添加一条新建资金卡的记录
                        cashmessage_bll.Add(cashmessage_model);
                    }
                    else//如果是不通过并且有上一审批人，就要把审批人改回成上一审批人
                    {
                        if (null != order_model.TEMP1 && !order_model.TEMP1.Equals(""))//说明有上一审批人，则退回到上一审批人
                        {
                            order_model.Checker = order_model.TEMP1;
                        }
                    }
                }
                //历史审核结果
                order_model.CheckerHistory = order_model.CheckerHistory + ";" + user_model.USERNAME.ToString() + ":" + checkvalue;

                //审核时间
                order_model.CheckTime = DateTime.Now;
                //备注信息
                order_model.TEMP2 = Overviews.Value.ToString();

                //执行审批操作
                order_bll.Update(order_model);

                /************************给业务申请者发信息***********************/

                //  1).首先给预算申请者发送信息
                Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

                mFaceShowMessage.DATETIME = DateTime.Now;
                mFaceShowMessage.FromTable = "预算审批";
                mFaceShowMessage.IsRead = 0;
                mFaceShowMessage.NewsID = null;
                mFaceShowMessage.NewsType = "预算审批";
                mFaceShowMessage.ReadTime = null;
                mFaceShowMessage.DELFLAG = 0;
                mFaceShowMessage.ProjectID = order_model.ProjectID;

                if (TnF)
                {
                    mFaceShowMessage.URLS = user_model.REALNAME + "(" + user_model.USERNAME.ToString() + ")修改了已通过审核的预算申请<a href='/Admin/budgetManage/budgetmanage.aspx?role=lister' target='_self' title='编辑时间:" + DateTime.Now + "'>  点击查看</a>";
                    if (UserIDdt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in UserIDdt.Rows)
                        {
                            mFaceShowMessage.Receive = dr["id"].ToString();
                            bFaceShowMessage.Add(mFaceShowMessage);
                        }
                    }
                }
                else
                {
                    //这里接受者应该是这个预算的申请者
                    mFaceShowMessage.Receive = order_model.Applyuser;//（区别在这里: 接收人不一样）
                    //这里的URL要带上审批的状态，以便查看时直接进入该状态下的列表中
                    mFaceShowMessage.URLS = ((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME.ToString() + ")审批了您的预算申请<a href='/Admin/budgetManage/budgetmanage.aspx?Status=" + order_model.Status.ToString() + "' target='_self' title='审批时间:" + DateTime.Now + "'>  点击查看</a>";
                    bFaceShowMessage.Add(mFaceShowMessage);

                    //  2).如果有下一审核人则要给下一审核人发送信息
                    if (check.Equals("0"))//表示需要继续审核　
                    {
                        //这里接受者应该是选择的下一审批人
                        mFaceShowMessage.Receive = order_model.Checker;//（区别在这里: 接收人不一样）
                        //这里的URL要带上审批的状态，以便查看时直接进入该状态下的列表中，并且指定的下一审核人肯定是领导权限的，也就是有审核权限的，所以需要带上role
                        mFaceShowMessage.URLS = ((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME.ToString() + ")给您发送预算审批<a href='/Admin/budgetManage/budgetmanage.aspx?Status=" + order_model.Status.ToString() + "&role=manager' target='_self' title='发送时间:" + DateTime.Now + "'>  点击处理</a>";
                        bFaceShowMessage.Add(mFaceShowMessage);

                        //  3).如果有下一审核人则要给上一审核人发送信息

                        //这里接受者应该是选择的上一审批人
                        mFaceShowMessage.Receive = order_model.TEMP1;//（区别在这里: 接收人不一样,TEMP1暂存了上一审批人）
                        //这里的URL要带上审批的状态，以便查看时直接进入该状态下的列表中，并且指定的下一审核人肯定是领导权限的，也就是有审核权限的，所以需要带上role
                        mFaceShowMessage.URLS = ((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME.ToString() + ")审批了您发送的预算报告<a href='/Admin/budgetManage/budgetmanage.aspx?Status=" + order_model.Status.ToString() + "&role=manager' target='_self' title='审批时间:" + DateTime.Now + "'>  点击查看</a>";
                        bFaceShowMessage.Add(mFaceShowMessage);

                    }

                    //  4).如果有没有下一审核人并且审核通过，需要给指定经费审核人发送信息
                    if (check.Equals("1"))//表示需要审核通过
                    {
                        //这里接受者应该是选择的下一审批人
                        mFaceShowMessage.Receive = order_model.AssignChecker;//（区别在这里: 接收人不一样）
                        //这里的URL要带上审批的状态，以便查看时直接进入该状态下的列表中
                        mFaceShowMessage.URLS = ((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME.ToString() + ")将您指定为 " + order_model.NAMES + " 的经费审批人<a href='/Admin/budgetManage/budgetmanage.aspx?Status=" + order_model.Status.ToString() + "&role=lister' target='_self' title='指定时间:" + DateTime.Now + "'>  点击查看</a>";
                        bFaceShowMessage.Add(mFaceShowMessage);
                    }

                    //  5).如果审核不通过，需要给指定经费审核人发送信息
                    if (check.Equals("2"))//表示需要审核不通过
                    {
                        //这里返回给创建人
                        mFaceShowMessage.Receive = order_model.Applyuser;
                        //这里的URL要带上审批的状态，以便查看时直接进入该状态下的列表中
                        mFaceShowMessage.URLS = ((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME.ToString() + ")将您的申请预算 " + order_model.NAMES + " 审核不通过<a href='/Admin/budgetManage/budgetmanage.aspx?Status=2' target='_self' title='退回时间:" + DateTime.Now + "'>  点击查看</a>";
                        bFaceShowMessage.Add(mFaceShowMessage);
                    }
                    /************************给业务申请者发信息************************/
                }

                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"budgetmanage.aspx?pageindex=" + Request["pageindex"] + "&Status=" + Request["Status"].ToString() + "&role=" + Request["role"].ToString() + "\";</script>";
                Response.Write(coutws);

            }
            catch
            {
            }
        }
        /// <summary>
        /// 显示经费指定审批人
        /// </summary>
        protected void ShowAssignChecker()
        {
            try
            {
                DataTable DT = groups_bllext.getLeaderList();
                if (DT.Rows.Count > 0)
                {
                    DDL_AssignChecker.DataSource = DT;
                    DDL_AssignChecker.DataValueField = "ID";
                    DDL_AssignChecker.DataTextField = "REALNAME";
                    DDL_AssignChecker.DataBind();

                    DDL_Checker.DataSource = DT;
                    DDL_Checker.DataValueField = "ID";
                    DDL_Checker.DataTextField = "REALNAME";
                    DDL_Checker.DataBind();

                    //给经费审批人指定一个空列
                    ListItem li = new ListItem("-请选择审批人-", "");
                    DDL_AssignChecker.Items.Insert(0, li);

                }
                else
                {
                    ListItem li = new ListItem("-暂无可选审批人-", "");
                    DDL_AssignChecker.Items.Add(li);

                    ListItem li1 = new ListItem("-暂无可选审批人-", "");
                    DDL_Checker.Items.Add(li1);
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 有无下一审批人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RBL_Checker_change(object sender, EventArgs e)
        {
            string isexit = RBL_Checker.SelectedValue.ToString();

            if (isexit.Equals("0"))//表示需要继续审核,则需要显示下一审核人
            {
                DDL_Checker.Visible = true;
            }
            else
            {
                DDL_Checker.Visible = false;
                if (isexit.Equals("2"))
                {
                    tr_SpecialFunds.Visible = false;
                    tr_BudgetAmount.Visible = false;
                }
                else
                {
                    tr_SpecialFunds.Visible = true;
                    tr_BudgetAmount.Visible = true;
                }
            }
        }

        /// <summary>
        /// 专项资金切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_SpecialFundsID_Change(object sender, EventArgs e)
        {
            string SpecialFundsID = DDL_SpecialFundsID.SelectedValue.ToString();

            if (!SpecialFundsID.Equals(""))//如有专项资金
            {
                DataTable DT_SpecialFunds = cash_bllext.getCash_SpecialFunds();

                if (DT_SpecialFunds.Rows.Count > 0)
                {
                    DataRow[] dr = DT_SpecialFunds.Select("ID='" + DDL_SpecialFundsID.SelectedValue.ToString() + "'");
                    if (dr.Length > 0)
                    {
                        //资金总额
                        LB_total.Text = dr[0]["TotalNum"].ToString() + "元";
                        //可用资金　
                        LB_KEYong.Text = dr[0]["Balance"].ToString() + "元";
                    }
                }

                SpecialFundsOrder1.ShowList(SpecialFundsID);
                SpecialFundsOrder1.Visible = true;
            }
            else
            {
                SpecialFundsOrder1.Visible = false;
            }
        }

        /// <summary>
        /// 审批者身份切换触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RBL_check_change(object sender, EventArgs e)
        {
            ShowMain();
        }

        /// <summary>
        /// 显示专项资金列表
        /// </summary>
        protected void ShowSpecialFunds()
        {
            try
            {
                DataTable DT = new DataTable();
                string sql = " SELECT ID, NAMES FROM Cash_SpecialFunds WHERE (STATUS = 1) AND (Delflag = 0) ";
                //string sql = " SELECT ID, NAMES + '[' + CONVERT(varchar(20), Balance) + ',' + CONVERT(varchar(20),TotalNum) + ']' AS NAMES  FROM Cash_SpecialFunds WHERE (STATUS = 1) AND (Delflag = 0) ";
                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    DDL_SpecialFundsID.DataSource = DT;
                    DDL_SpecialFundsID.DataTextField = "NAMES";
                    DDL_SpecialFundsID.DataValueField = "ID";
                    DDL_SpecialFundsID.DataBind();
                }
                else
                {
                    ListItem li = new ListItem("-暂无可选专项资金-", "");
                    DDL_SpecialFundsID.Items.Add(li);
                }

            }
            catch
            { }
        }

        /// <summary>
        /// 点击返回触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_cancel_click(object sender, EventArgs e)
        {
            string pageindex = Request["pageindex"].ToString();
            string Status = Request["Status"].ToString();
            string role = Request["role"].ToString();

            Response.Redirect("budgetmanage.aspx?pageindex=" + pageindex + "&Status=" + Status + "&role=" + role);
        }
    }
}
