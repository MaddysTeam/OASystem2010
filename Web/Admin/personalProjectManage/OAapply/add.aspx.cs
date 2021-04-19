using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace Dianda.Web.Admin.personalProjectManage.OAapply
{
    public partial class add : System.Web.UI.Page
    {
        Dianda.Model.Project_Projects project_model = new Dianda.Model.Project_Projects();
        Dianda.BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();
        Dianda.BLL.Project_Apply apply_bll = new Dianda.BLL.Project_Apply();
        Dianda.Model.Project_Apply apply_model = new Dianda.Model.Project_Apply();
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.COMMON.fileUploads fileup = new Dianda.COMMON.fileUploads();

        Dianda.Model.FaceShowMessage mFaceshowMessage = new Dianda.Model.FaceShowMessage();
        Dianda.BLL.FaceShowMessage bFaceshowMessage = new Dianda.BLL.FaceShowMessage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //初始化页面属性值
                //Web.Admin.personalProjectManage.MakeProjectSession makeprojectsession = new Dianda.Web.Admin.personalProjectManage.MakeProjectSession();
                //makeprojectsession.getMyProjectList(this);
                InitInfo();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void InitInfo()
        {
            try
            {
                bool TnF = false;       //判断当前是否是新建资源
                string apply = "";
                //表示并非从主菜单上点的“资源”
                if (null == Request["apply"])
                {
                    project_model = project_bll.GetModel(Convert.ToInt16(Session["Work_ProjectId"]));
                    //显示项目名称
                    LB_Project.Text = project_model.NAMES.ToString();

                    DDL_Project.Visible = false;
                    LB_Project.Visible = true;
                    Control.Visible = true;
                    //Button_viewhistroy.Visible = false;
                    Button_reback.Visible = true;
                    //ordertype.Visible = false
                }
                else
                {
                   DataTable dt_project = (DataTable)Session["Project_Projects"];
                   apply = Request["apply"];
                   TnF = true;
                   //ordertype.Visible = true;
                   if (dt_project.Rows.Count>0)
                    {
                        DDL_Project.Visible = true;
                        LB_Project.Visible = false;
                        for (int i = 0; i < dt_project.Rows.Count;i++ )
                        {
                            //项目名称
                            string projectName = dt_project.Rows[i]["NAMES"].ToString();
                            //项目ID
                            string projectID = dt_project.Rows[i]["ID"].ToString();
                            //删除标记
                            string DELFLAG = dt_project.Rows[i]["DELFLAG"].ToString();

                            if (DELFLAG.Equals("0"))//只选择Session["Project_Projects"]中没有被删除的项目
                            {
                                ListItem li = new ListItem(projectName, projectID);

                                DDL_Project.Items.Add(li);

                                if (null != Request["project"] && Request["project"].ToString().Equals(li.Value.ToString()))
                                {
                                    li.Selected = true;
                                }
                            }
                        }
                    }
                   Control.Visible = false;
                   //Button_viewhistroy.Visible = true;
                    //如果是从主菜单的“资源汇总”列表页面上点的“新建”，则进入到新增页面是需要保留“返回”按钮的；
                   if (null != Request["order"] && Request["order"].ToString().Equals("orderresource"))
                   {
                       Button_reback.Visible = true;
                   }
                   else
                   {
                       Button_reback.Visible = false;
                   }


                   for (int i = 0; i < DDL_AppType.Items.Count; i++)
                   {
                       if (DDL_AppType.Items[i].Value.ToString().Equals(Request["apply"].ToString()))
                       {
                           DDL_AppType.Items[i].Selected = true;
                       }
                   }
                  
                }

                ShowMain(apply, TnF);

                //部门下拉列表
                DataTable dt1 = new DataTable();
                string sql1 = " SELECT ID,NAME FROM USER_Groups WHERE (TAGS = '部门') AND (DELFLAG = 0)  GROUP BY ID,NAME ";

                dt1 = pageControl.doSql(sql1).Tables[0];

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string DepartName = dt1.Rows[i]["NAME"].ToString();
                    string ID = dt1.Rows[i]["ID"].ToString();

                    ListItem li = new ListItem(DepartName, ID);
                    DDL_Department.Items.Add(li);

                }

                //设置部门列表的选定值
                Dianda.Model.USER_Users userModel = new Dianda.Model.USER_Users();
                userModel = (Model.USER_Users)Session["USER_Users"];
                if (userModel.DepartMentID.IndexOf(',') > -1)
                {
                    DDL_Department.SelectedValue = userModel.DepartMentID.Split(',')[0];
                }
                else
                {
                    DDL_Department.SelectedValue = userModel.DepartMentID;
                }
                //绑定人员列表
                DataTable dtuser = new DataTable();
                dtuser = pageControl.doSql("select ID,USERNAME,REALNAME from USER_Users where DepartMentID like '%" + DDL_Department.SelectedValue.ToString() + "%' and WorkStats='1' and DELFLAG=0 order by REALNAME ").Tables[0];
                if (dtuser.Rows.Count > 0)
                {
                    User_DPList.Enabled = true;
                    Button_sumbit.Enabled = true;

                    for (int i = 0; i < dtuser.Rows.Count; i++)
                    {
                        string ApplyUserName = dtuser.Rows[i]["REALNAME"].ToString() + "(" + dtuser.Rows[i]["USERNAME"].ToString() + ")";
                        string ID = dtuser.Rows[i]["ID"].ToString();

                        ListItem li = new ListItem(ApplyUserName, ID);
                        User_DPList.Items.Add(li);

                    }
                    //设置人员列表的选中值
                    User_DPList.SelectedValue = userModel.ID;
                }
                else 
                {
                    ListItem li = new ListItem("本部门无人员", "0");
                    User_DPList.Items.Add(li);
                    User_DPList.Enabled = false;
                    Button_sumbit.Enabled = false;
                }
            }
            catch
            {
                tag.Text = "初始化页面属性值时发生错误！";
            }
        }

        public void ShowMain(string apply, bool b)
        {
            this.show_manage.Visible = b;

            orderFood.Visible = false;
            orderCar.Visible = false;
            orderRoom.Visible = false;
            orderSignet.Visible = false;
            Lab_SHR.Visible = false;
            DDList_SHR.Visible = false; 
            lab_CLTS.Visible = false;
            Label Label_navigation = (Label)Master.FindControl("Label_navigation");
            Label_navigation.Text = "";
            this.show_manage.InnerHtml = "";
            this.show_manage.InnerText = "";
            switch (apply)
            {
                case "orderFood":
                    if (!b)
                    {
                        //设置模板页中的管理值
                        Label_navigation.Text = "项目 > 我的项目 > 项目资源 > 客饭预约 ";
                        //设置模板页中的管理值
                    }
                    else
                    {
                        //设置模板页中的管理值
                        Label_navigation.Text = "资源 > 客饭预约 ";
                        //设置模板页中的管理值

                        this.show_manage.InnerText = "查看已经预定午餐   ";
                        this.show_manage.HRef = @"javascript:window.showModalDialog('ShowManage.aspx?staue=" + DDL_AppType.SelectedValue + "','','dialogWidth=726px;dialogHeight=400px');";
                        this.show_manage.Title = "查看已预定午餐";
                    }
                    ordertype.Visible = true;
                    orderFood.Visible = true;
                    break;
                case "orderCar":
                    if (!b)
                    {
                        //设置模板页中的管理值
                        Label_navigation.Text = "项目 > 我的项目 > 项目资源 > 车辆预约 ";
                        //设置模板页中的管理值
                    }
                    else
                    {
                        //设置模板页中的管理值
                        Label_navigation.Text = "资源 > 车辆预约 ";
                        //设置模板页中的管理值

                        this.show_manage.InnerText = "查看已经预定车辆  ";
                        this.show_manage.HRef = @"javascript:window.showModalDialog('ShowManage.aspx?staue=" + DDL_AppType.SelectedValue + "','','dialogWidth=726px;dialogHeight=400px');";
                        this.show_manage.Title = "查看已预定车辆";
                    }
                    ordertype.Visible = true;
                    lab_CLTS.Visible = true;
                    orderCar.Visible = true;
                    break;
                case "orderRoom":
                    if (!b)
                    {
                        //设置模板页中的管理值
                        Label_navigation.Text = "项目 > 我的项目 > 项目资源 > 会议室预约 ";
                        //设置模板页中的管理值
                    }
                    else
                    {
                        //设置模板页中的管理值
                        Label_navigation.Text = "资源 > 会议室预约 ";
                        //设置模板页中的管理值

                        this.show_manage.InnerText = "查看已预定会议室   ";
                        this.show_manage.HRef = @"javascript:window.showModalDialog('ShowManage.aspx?staue=" + DDL_AppType.SelectedValue + "','','dialogWidth=726px;dialogHeight=400px');";
                        this.show_manage.Title = "查看已预定会议室";
                    }
                    ordertype.Visible = true;
                    orderRoom.Visible = true;
                    break;
                case "orderSignet":
                    if (!b)
                    {
                        //设置模板页中的管理值
                        Label_navigation.Text = "项目 > 我的项目 > 项目资源 > 用印申请 ";
                        //设置模板页中的管理值
                    }
                    else
                    {
                        //设置模板页中的管理值
                        Label_navigation.Text = "资源 > 用印申请 ";
                        //设置模板页中的管理值

                        this.show_manage.InnerText = "查看已经申请印章   ";
                        this.show_manage.HRef = @"javascript:window.showModalDialog('ShowManage.aspx?staue=" + DDL_AppType.SelectedValue + "','','dialogWidth=726px;dialogHeight=400px');";
                        this.show_manage.Title = "查看已申请印章";
                    }
                    ordertype.Visible = true;
                    orderSignet.Visible = true;
                    Lab_SHR.Visible = true;
                    DDList_SHR.Visible = true;

                    string Pro_id = "";
                    if (Request["apply"] == null)
                    {
                        Pro_id = Session["Work_ProjectId"].ToString();
                    }
                    else
                    {
                        Pro_id = DDL_Project.SelectedValue.ToString();
                    }
                    SHR_Bing(Pro_id);
                    break;
                default:
                    this.show_manage.Visible = false;
                    ordertype.Visible = false;
                    Lab_SHR.Visible = false;
                    DDList_SHR.Visible = false;
                    //设置模板页中的管理值
                    Label_navigation.Text = "项目 > 我的项目 > 项目资源 > 新建资源 ";
                    //设置模板页中的管理值
                    break;
            }
        }
        /// <summary>
        /// 点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_onclick(object sender, EventArgs e)
        {
            try
            {
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                //ID
                apply_model.ID = apply_bll.GetMaxId();
                //项目ID
                if (null != Request["order"] && Request["order"].ToString().Equals("orderresource"))
                {
                    apply_model.ProjectID = Convert.ToInt16(DDL_Project.SelectedValue.ToString());
                }
                else
                {
                    //if (null == Session["Work_ProjectId"])
                    if (null !=  Request["apply"])
                    {
                        apply_model.ProjectID = Convert.ToInt16(DDL_Project.SelectedValue.ToString());
                    }
                    else
                    {
                        apply_model.ProjectID = Convert.ToInt16(Session["Work_ProjectId"]);
                    }
                }

                //删除标记
                apply_model.DELFLAG = 0;
                //申请的状态
                apply_model.Status = 0;//初始为0表示待审核

                if (DDL_AppType.SelectedValue.ToString().Equals(""))
                {
                    tag.Text = "请先选择申请类型！";
                    return;
                }

                //申请业务的类型
                apply_model.AppType = DDL_AppType.SelectedValue;

                //用途描述
                apply_model.Overviews = Overviews.Text.ToString();
                //提交的时间
                apply_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToString());
                //提交申请的用户的ID
                apply_model.SendUserID = user_model.ID;
                //申请的部门和申请人
                apply_model.DepartmentID = DDL_Department.SelectedValue;
                //申请人
                apply_model.ApplyUserID = User_DPList.SelectedValue;
                Session["ApplyUserName"] = "("+User_DPList.SelectedItem.Text.ToString().Substring(0, User_DPList.SelectedItem.Text.ToString().IndexOf('('))+")";
                //联系电话
                apply_model.TelNum = TB_TelNum.Text.ToString();

                //表示选择申请业务类型是订饭申请***************************************
                if (DDL_AppType.SelectedValue.ToString().Equals("orderFood"))
                {
                    Dianda.Model.Project_Apply_orderFood orderfood_model = new Dianda.Model.Project_Apply_orderFood();
                    Dianda.BLL.Project_Apply_orderFood orderfood_bll = new Dianda.BLL.Project_Apply_orderFood();

                    if (((HiddenField)orderFood.FindControl("HiddenField2")).Value == "fales")
                    {
                        tag.Text = "定饭日期发生变动！请检查后提交！";
                        return;
                    }

                    //定饭总量
                    int orderFoodNums = int.Parse(ConfigurationSettings.AppSettings["orderFoodNums"]);
                    //获取添写的订饭的数量
                    if (null != orderFood.orderfoodnum && !orderFood.orderfoodnum.Equals(""))
                    {
                        //获取剩余的数量
                        int LimitNum = int.Parse(orderFood.LimitNum);

                        try
                        {
                            int n = Convert.ToInt32(orderFood.orderfoodnum);
                            if (n <= 0)
                            {
                                tag.Text = "预订数量必须大于0！";
                                return;
                            }
                        }
                        catch
                        {
                            tag.Text = "预订数量只能是大于0的数字！";
                            return;
                        }

                        int orderNums = int.Parse(orderFood.orderfoodnum);
                        //预订日期
                        DateTime ordertime = Convert.ToDateTime(orderFood.orderfoodtime);
                        //在当前日期上加二天
                        DateTime now = DateTime.Now.AddDays(2);

                        if (Convert.ToDateTime(ordertime.ToString("yyyy-MM-dd"))<Convert.ToDateTime(now.ToString("yyyy-MM-dd")))
                        {
                            tag.Text = "午餐必须提前二天预订，请电话联系相关人员！";
                            return;
                        }

                        if (orderNums > LimitNum)
                        {
                            tag.Text = "预订的数量不能大于剩余的数量，请修改！";
                        }
                        else
                        {
                            //ID
                            orderfood_model.ID = orderfood_bll.GetMaxId();
                            //申请ID
                            orderfood_model.ApplyID = apply_model.ID;
                            //用饭时间
                            orderfood_model.UserDatetime = Convert.ToDateTime(orderFood.orderfoodtime);
                            //预订份数
                            orderfood_model.OrderNum = int.Parse(orderFood.orderfoodnum);

                            orderfood_bll.Add(orderfood_model);

                            apply_bll.Add(apply_model);

                            Session["Session_Project_linkshow"] = "LinkButton_apply";

                            if (null == Session["Work_ProjectId"])
                            {
                                Session["Work_ProjectId"] = DDL_Project.SelectedValue.ToString();
                            }
                            string coutws = "";
                            string type = "";

                            if (null != Request["type"] && !(Request["type"].ToString().Equals("")))
                            {
                                type = Request["type"].ToString();
                            }
                            else
                            {
                                type = DDL_AppType.SelectedValue.ToString();
                            }
                           // if (null != Request["order"] && Request["order"].ToString().Equals("orderresource"))
                            if (null != Request["apply"] && Request["apply"].ToString().Equals("orderFood"))
                            {
                                coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"resourceManage.aspx?type=" + type + "&project=" + Request["project"] + "&status=" + "\";</script>";

                            }
                            else
                            {
                                 coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?type=" + DDL_AppType.SelectedValue.ToString() + "&status=" + "\";</script>";

                            }


                            Response.Write(coutws);

                           // ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入我的项目页面');javascript:location='manage.aspx?projecttype=4&projectStatus=0';</script>", false);

                            //添加操作日志

                            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "业务申请", project_model.NAMES + "项目订饭预约:成功！");
                            //添加操作日志

                            //添加立项申请的前台提醒信息
                            mFaceshowMessage.DATETIME = DateTime.Now;
                            mFaceshowMessage.FromTable = "客饭预定";
                            mFaceshowMessage.IsRead = 0;
                            mFaceshowMessage.NewsType = "客饭预定";
                            mFaceshowMessage.Receive = "客饭预定";
                            mFaceshowMessage.URLS = "<a href='/Admin/applyManage/OrderfoodManage/check.aspx?ID=" + apply_model.ID + "&pageindex=1&Status=0' target='_self' title='客饭预定：提交时间" + DateTime.Now.ToString() + "'>" + Convert.ToDateTime(orderfood_model.UserDatetime).ToString("yyyy-MM-dd") + " 客饭预约</a> " + "  数量  " + orderfood_model.OrderNum.ToString() + " " + Session["ApplyUserName"];
                            mFaceshowMessage.DELFLAG = 0;
                            mFaceshowMessage.ProjectID = apply_model.ProjectID;// Convert.ToInt16(DDL_Project.SelectedValue.ToString());
                            bFaceshowMessage.Add(mFaceshowMessage);

                        }
                    }
                    else
                    {
                        tag.Text = "预订的数量不能为空！";
                    }
                }//表示选择申请业务类型是订车申请***************************************
                else if (DDL_AppType.SelectedValue.ToString().Equals("orderCar"))
                {
                    foreach (GridViewRow item in orderCar.GridView1.Rows)
                    {
                        RadioButton rb = (RadioButton)item.FindControl("RadioButton_choose");
                        int Count = int.Parse(orderCar.GridView1.DataKeys[item.RowIndex].Value.ToString());
                        if (rb.Checked == true)
                        {
                            if (int.Parse(orderCar.TB_PeopleNum.Text) > Count)
                            {
                                tag.Text = "乘车人数多于车辆座位数！";
                                return;
                            }
                        }
                    }
                    Dianda.BLL.Project_Apply_orderCar ordercar_bll = new Dianda.BLL.Project_Apply_orderCar();
                    Dianda.Model.Project_Apply_orderCar ordercar_model = new Dianda.Model.Project_Apply_orderCar();
                    //用车时间
                    string ordertime = orderCar.ordercartime;
                    if (((HiddenField)orderCar.FindControl("HiddenField2")).Value == "fales")
                    {
                        tag.Text = "由于用车时间发生改变!请点击查看预订情况后再预约！";
                        return;
                    }
                    if (null != ordertime && !ordertime.Equals(""))
                    {
                        if (Convert.ToDateTime(Convert.ToDateTime(ordertime).ToString("yyyy-MM-dd")) < Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")))
                        {
                            tag.Text = "车辆必须提前一天预订，请电话联系相关人员！";

                        }else
                        {
                            //所订车辆的ID
                            string carid = orderCar.CarID;
                            if(null!=carid && !carid.Equals(""))
                            {
                                //ID
                                ordercar_model.ID = ordercar_bll.GetMaxId();
                                //Project_Apply中申请的ID
                                ordercar_model.ApplyID = apply_model.ID;
                                //车辆的ID
                                ordercar_model.CarID =int.Parse(carid);
                                //用车开始时间
                                string starttime = orderCar.ordercartime + " " + orderCar.starthour + ":" + orderCar.startminute;
                                ordercar_model.StartTime = Convert.ToDateTime(starttime);
                                //用车结束时间
                                string endtime = orderCar.ordercarendtime + " " + orderCar.endhour + ":" + orderCar.endminute;
                                ordercar_model.EndTime = Convert.ToDateTime(endtime);

                                //乘车的人数
                                if (null == orderCar.PeopleNum || orderCar.PeopleNum.ToString().Equals(""))
                                {
                                    ordercar_model.PeopleNum = 0;
                                }
                                else
                                {
                                    try
                                    {
                                        int n = Convert.ToInt32(orderCar.PeopleNum);
                                        if (n <= 0)
                                        {
                                            tag.Text = "乘车人数必须大于0！";
                                            return;
                                        }
                                    }
                                    catch
                                    {
                                        tag.Text = "乘车人数只能是大于0的数字！";
                                        return;
                                    }

                                    ordercar_model.PeopleNum = int.Parse(orderCar.PeopleNum);
                                }
                                //始发地
                                ordercar_model.FromAddress = orderCar.FromAddress;
                                //目的地
                                ordercar_model.ToAddress = orderCar.ToAddress;

                                ordercar_bll.Add(ordercar_model);

                                apply_bll.Add(apply_model);

                                Session["Session_Project_linkshow"] = "LinkButton_apply";

                                if (null == Session["Work_ProjectId"])
                                {
                                    Session["Work_ProjectId"] = DDL_Project.SelectedValue.ToString();
                                }

                                string coutws = "";
                                string type = "";

                                if (null != Request["type"] && !(Request["type"].ToString().Equals("")))
                                {
                                    type = Request["type"].ToString(); 
                                }
                                else
                                {
                                    type = DDL_AppType.SelectedValue.ToString();
                                }
                                //if (null != Request["order"] && Request["order"].ToString().Equals("orderresource"))
                                if (null != Request["apply"] && Request["apply"].ToString().Equals("orderCar"))
                                {
                                    coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"resourceManage.aspx?type=" + type + "&project=" + Request["project"] + "&status=" + "\";</script>";

                                }
                                else
                               {
                                   coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?type=" + DDL_AppType.SelectedValue.ToString() + "&status=" + "\";</script>";

                                }

                                Response.Write(coutws);

                                //添加操作日志

                                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "业务申请", project_model.NAMES + "项目订车预约:成功！");
                                //添加操作日志

                                //添加立项申请的前台提醒信息
                                Model.Project_CarList carlist_model = new Dianda.Model.Project_CarList();
                                BLL.Project_CarList carlist_bll = new Dianda.BLL.Project_CarList();

                                carlist_model = carlist_bll.GetModel(int.Parse(ordercar_model.CarID.ToString()));
                                mFaceshowMessage.DATETIME = DateTime.Now;
                                mFaceshowMessage.FromTable = "车辆预定";
                                mFaceshowMessage.IsRead = 0;
                                mFaceshowMessage.NewsType = "车辆预定";
                                mFaceshowMessage.Receive = "车辆预定";
                                mFaceshowMessage.URLS = "<a href='/Admin/applyManage/OrdercarManage/check.aspx?ID=" + apply_model.ID + "&pageindex=1&Status=0' target='_self' title='车辆预定：提交时间" + DateTime.Now.ToString() + "'>" + carlist_model.CarName + " 预约</a> " + Session["ApplyUserName"];
                                mFaceshowMessage.DELFLAG = 0;
                                mFaceshowMessage.ProjectID = apply_model.ProjectID;// Convert.ToInt16(DDL_Project.SelectedValue.ToString());
                                bFaceshowMessage.Add(mFaceshowMessage);

                            }
                            else
                            {
                                tag.Text = "请先选择您所需要预订的车辆！";
                            }
                        }
                    }else
                    {
                        tag.Text = "用车时间不能为空！";
                    }
                    
                }//表示选择申请业务类型是订会议室申请***************************************
                else if (DDL_AppType.SelectedValue.ToString().Equals("orderRoom"))
                {
                    Dianda.BLL.Project_Apply_orderRoom orderroom_bll = new Dianda.BLL.Project_Apply_orderRoom();
                    Dianda.Model.Project_Apply_orderRoom orderroom_model = new Dianda.Model.Project_Apply_orderRoom();
                    if (((HiddenField)orderRoom.FindControl("HiddenField2")).Value == "fales")
                    {
                        tag.Text = "由于会议时间发生改变!请点击查看预订情况后再预约！";
                        return;
                    }
                    string ordertime = orderRoom.orderroomtime;
                    if (null != ordertime && !ordertime.Equals(""))
                    {
                        if (Convert.ToDateTime(Convert.ToDateTime(ordertime).ToString("yyyy-MM-dd")) <Convert.ToDateTime(DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")))
                        {
                            tag.Text = "会议室必须提前二天预订，请电话联系相关人员！";
                        }
                        else
                        {
                            //所订会议室的ID
                            string roomid = orderRoom.RoomID;
                            if (null != roomid && !roomid.Equals(""))
                            {
                                //ID
                                orderroom_model.ID = orderroom_bll.GetMaxId();
                                //Project_Apply中申请的ID
                                orderroom_model.ApplyID = apply_model.ID;
                                //会议室的ID
                                orderroom_model.RoomID = int.Parse(roomid);
                                //会议开始时间
                                string starttime = orderRoom.orderroomtime + " " + orderRoom.starthour + ":" + orderRoom.startminute;
                                orderroom_model.StartTime = Convert.ToDateTime(starttime);
                                //会议结束时间
                                string endtime = orderRoom.ordercarendtime + " " + orderRoom.endhour + ":" + orderRoom.endminute;
                                orderroom_model.EndTime = Convert.ToDateTime(endtime);
                                //会议地址
                                
                                string adress = "";
                                foreach (ListItem item in orderRoom.orderroomadress.Items)
                                {

                                    if (item.Selected)
                                    {                                     
                                        adress = adress + item.Value + ",";
                                        
                                    }
                                }                              
                                if (adress != "")
                                {
                                    adress = adress.Remove(adress.LastIndexOf(","));
                                    orderroom_model.Address = adress;
                                }
                                else
                                {
                                    orderroom_model.Address = null;
                                }
                                //会议名称
                                if (null == orderRoom.MeetingName || orderRoom.MeetingName.ToString().Equals(""))
                                {
                                    tag.Text = "会议名称不能为空！";
                                    return;
                                }
                                orderroom_model.MeetName = orderRoom.MeetingName;

                                //会议的人数
                                if (null == orderRoom.MeetingNum || orderRoom.MeetingNum.ToString().Equals(""))
                                {
                                    orderroom_model.PeopleNum = 0;
                                }else
                                {
                                    try
                                    {
                                        int n = Convert.ToInt32(orderRoom.MeetingNum);
                                        if(n<=0)
                                        {
                                            tag.Text = "会议人数必须大于0！";
                                            return;
                                        }
                                    }
                                    catch
                                    {
                                        tag.Text = "会议人数只能是大于0的数字！";
                                        return;
                                    }

                                  orderroom_model.PeopleNum = int.Parse(orderRoom.MeetingNum);
                                }
                                //会议地址
                                //orderroom_model.Address = orderRoom.MeetingAddress;

                                orderroom_bll.Add(orderroom_model);

                                apply_bll.Add(apply_model);

                                Session["Session_Project_linkshow"] = "LinkButton_apply";

                                if (null == Session["Work_ProjectId"])
                                {
                                    Session["Work_ProjectId"] = DDL_Project.SelectedValue.ToString();
                                }

                                 string coutws = "";
                                 string type = "";

                                 if (null != Request["type"] && !(Request["type"].ToString().Equals("")))
                                 {
                                     type = Request["type"].ToString();
                                 }
                                 else
                                 {
                                     type = DDL_AppType.SelectedValue.ToString();
                                 }

                                //if (null != Request["order"] && Request["order"].ToString().Equals("orderresource"))
                                 if (null != Request["apply"] && Request["apply"].ToString().Equals("orderRoom"))
                                {
                                  coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"resourceManage.aspx?type=" + type + "&project=" + Request["project"] + "&status=" + "\";</script>";

                                 }
                                 else
                                {
                                  coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?type=" + DDL_AppType.SelectedValue.ToString() + "&status=" + "\";</script>";

                                 }


                                Response.Write(coutws);

                                //添加操作日志

                                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "业务申请", project_model.NAMES + "项目订会议室预约:成功！");
                                //添加操作日志

                                //添加立项申请的前台提醒信息
                                Model.Project_RoomList roomlist_model= new Dianda.Model.Project_RoomList();
                                BLL.Project_RoomList roomlist_bll= new Dianda.BLL.Project_RoomList();

                                roomlist_model = roomlist_bll.GetModel(int.Parse(orderroom_model.RoomID.ToString()));
                                mFaceshowMessage.DATETIME = DateTime.Now;
                                mFaceshowMessage.FromTable = "会议室预定";
                                mFaceshowMessage.IsRead = 0;
                                mFaceshowMessage.NewsType = "会议室预定";
                                mFaceshowMessage.Receive = "会议室预定";
                                mFaceshowMessage.URLS = "<a href='/Admin/applyManage/OrderroomManage/check.aspx?ID=" + apply_model.ID + "&pageindex=1&Status=0' target='_self' title='会议室预定：提交时间" + DateTime.Now.ToString() + "'>" + roomlist_model.RoomName + "  预约</a> " + Session["ApplyUserName"];
                                mFaceshowMessage.DELFLAG = 0;
                                mFaceshowMessage.ProjectID = apply_model.ProjectID;// Convert.ToInt16(DDL_Project.SelectedValue.ToString());
                                bFaceshowMessage.Add(mFaceshowMessage);

                            }
                            else
                            {
                                tag.Text = "请先选择您所需要预订的会议室！";
                            }
                        }
                    }
                    else
                    {
                        tag.Text = "会议时间不能为空！";
                    }

                }//表示选择申请业务类型是印章申请***************************************
                else if (DDL_AppType.SelectedValue.ToString().Equals("orderSignet"))
                {
                    //印章ID
                    string SignetID = orderSignet.orderSignetID;
                    //敲章份数
                    string SignetNums = orderSignet.SignetNums;

                    string SHRID = DDList_SHR.SelectedValue.ToString();

                    Button_sumbit.Attributes.Add("onclick", "checksignetnums('" + orderSignet.SignetNums + "')");

                    Dianda.BLL.Project_Apply_signet signet_bll = new Dianda.BLL.Project_Apply_signet();
                    Dianda.Model.Project_Apply_signet signet_model = new Dianda.Model.Project_Apply_signet();

                    if (!string.IsNullOrEmpty(SHRID.Trim()))
                    {
                        if (null != SignetID && !SignetID.Equals(""))
                        {
                            if (null != SignetNums && !SignetNums.Equals(""))
                            {
                                try
                                {
                                    int n = Convert.ToInt32(SignetNums);
                                    if (n <= 0)
                                    {
                                        tag.Text = "敲章份数必须大于0！";
                                        return;
                                    }
                                }
                                catch
                                {
                                    tag.Text = "敲章份数只能输入大于0的数字！";
                                    return;
                                }


                                if (orderSignet.FileUp.FileName.Length > 2)
                                {
                                    string[] content = fileup.UpFile_COMMONS(orderSignet.FileUp, "/AllFileUp/fileup", "");
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
                                        tag.Text = "文件上传大小不符合系统规定，文件上传失败，请重新上传！";
                                        return;
                                    }

                                    apply_model.Attachments = content[1];
                                }

                                //ID
                                signet_model.ID = signet_bll.GetMaxId();
                                //Project_Apply中申请的ID
                                signet_model.ApplyID = apply_model.ID;
                                //印章ID
                                signet_model.SignetID = int.Parse(SignetID);
                                //审核人ID
                                apply_model.DoUserID = SHRID;

                                //敲章份数
                                signet_model.Nums = int.Parse(SignetNums);

                                signet_bll.Add(signet_model);

                                apply_bll.Add(apply_model);

                                Session["Session_Project_linkshow"] = "LinkButton_apply";

                                if (null == Session["Work_ProjectId"])
                                {
                                    Session["Work_ProjectId"] = DDL_Project.SelectedValue.ToString();
                                }

                                string coutws = "";
                                string type = "";

                                if (null != Request["type"] && !(Request["type"].ToString().Equals("")))
                                {
                                    type = Request["type"].ToString();
                                }
                                else
                                {
                                    type = DDL_AppType.SelectedValue.ToString();
                                }

                               //if (null != Request["order"] && Request["order"].ToString().Equals("orderresource"))
                                if (null != Request["apply"] && Request["apply"].ToString().Equals("orderSignet"))
                                {
                                    coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"resourceManage.aspx?type=" + type + "&project=" + Request["project"] + "&status=" + "\";</script>";

                                }
                                else
                                {
                                    coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?type=" + DDL_AppType.SelectedValue.ToString() + "&status=" + "\";</script>";

                                }


                                Response.Write(coutws);

                                //添加操作日志

                                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "业务申请", project_model.NAMES + "项目印章申请:成功！");
                                //添加操作日志

                                Model.Project_SignetList signetlist_model = new Dianda.Model.Project_SignetList();
                                BLL.Project_SignetList signetlist_bll = new Dianda.BLL.Project_SignetList();

                                signetlist_model = signetlist_bll.GetModel(int.Parse(signet_model.SignetID.ToString()));

                                mFaceshowMessage.DATETIME = DateTime.Now;
                                mFaceshowMessage.FromTable = "印章申请";
                                mFaceshowMessage.IsRead = 0;
                                mFaceshowMessage.NewsType = "印章申请";
                                mFaceshowMessage.Receive = SHRID;
                                mFaceshowMessage.URLS = "<a href='/Admin/applyManage/OrdersignetManage/check.aspx?ID=" + apply_model.ID + "&pageindex=1&Status=0' target='_self' title='印章申请：提交时间" + DateTime.Now.ToString() + "'>" + signetlist_model.SignetName + "  申请</a>  " + "  数量  " + signet_model.Nums +" " + Session["ApplyUserName"];
                                mFaceshowMessage.DELFLAG = 0;
                                mFaceshowMessage.ProjectID = apply_model.ProjectID;// Convert.ToInt16(DDL_Project.SelectedValue.ToString());
                                bFaceshowMessage.Add(mFaceshowMessage);

                            }
                            else
                            {
                                tag.Text = "敲章份数不能为空！";
                            }
                        }
                        else
                        {
                            tag.Text = "请先选择需要申请的印章！";
                        }
                    }
                    else
                    {
                        tag.Text = "请选择审核人（确认该项目是否有审核人）！";
                    }
                }

            }
            catch
            {
                tag.Text = "申请过程中发生错误，请检查输入是否正确！";
            }
        }

        /// <summary>
        /// 按状态筛选触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_AppType_Changed(object sender, EventArgs e)
        {
            tag.Text = "";
            //申请类型
            string apptype = DDL_AppType.SelectedValue.ToString();

            bool TnF = false;
            if (Request["apply"] != null)
                TnF = true;

            ShowMain(apptype, TnF);
        }

         /// <summary>
        /// 点击返回按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reback_onclick(object sender, EventArgs e)
        {
            //表示从主菜单上点的“资源汇总”，然后再进的新增页面，这时返回就要返回到资源汇总页面
            if (null != Request["order"] && Request["order"].ToString().Equals("orderresource"))
            {
                Response.Redirect("resourceManage.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"] + "&type=" + Request["type"] + "&project=" + Request["project"]);
            }
            else
            {
                Response.Redirect("manage.aspx?pageindex=" + Request["pageindex"] + "&status=" + Request["status"] + "&type=" + Request["type"]);

            }
        }

        /// <summary>
        /// 点击返回按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_viewhistroy_onclick(object sender, EventArgs e)
        {
            Session["Work_ProjectId"] = DDL_Project.SelectedValue.ToString();
            Session["Session_Project_linkshow"] = "LinkButton_apply";

            Response.Redirect("manage.aspx");
        }
        /// <summary>
        /// 申请部门变更时激发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            User_DPList.Items.Clear();
            //绑定人员列表
            DataTable dtuser = new DataTable();
            dtuser = pageControl.doSql("select ID,USERNAME,REALNAME from USER_Users where DepartMentID like '%" + DDL_Department.SelectedValue.ToString() + "%' and WorkStats='1' and DELFLAG=0").Tables[0];
            if (dtuser.Rows.Count > 0)
            {
                User_DPList.Enabled = true;
                Button_sumbit.Enabled = true;

                for (int i = 0; i < dtuser.Rows.Count; i++)
                {
                    string DepartName = dtuser.Rows[i]["REALNAME"].ToString() + "(" + dtuser.Rows[i]["USERNAME"].ToString() + ")";
                    string ID = dtuser.Rows[i]["ID"].ToString();

                    ListItem li = new ListItem(DepartName, ID);
                    User_DPList.Items.Add(li);

                }
            }
            else
            {
                ListItem li = new ListItem("本部门无人员", "0");
                User_DPList.Items.Add(li);

                User_DPList.Enabled = false;
                Button_sumbit.Enabled = false;
            }
        }
        /// <summary>
        /// 审核人下拉列表绑定数据
        /// </summary>
        /// <param name="Pro_ID">项目ID</param>
        private void SHR_Bing(string Pro_ID)
        {
            DataTable dt = project_bll.GetAllRY(Pro_ID);
            DDList_SHR.DataSource = dt.DefaultView;
            DDList_SHR.DataTextField = "UserInfos";
            DDList_SHR.DataValueField = "UserID";
            DDList_SHR.DataBind();

        }

        protected void DDL_Project_SelectedIndexChanged(object sender, EventArgs e)
        {
            SHR_Bing(DDL_Project.SelectedValue.ToString());
        }

        
    }
}
