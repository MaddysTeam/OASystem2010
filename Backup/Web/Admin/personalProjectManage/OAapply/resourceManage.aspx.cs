using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAapply
{
    public partial class resourceManage : System.Web.UI.Page
    {
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.BLL.Project_Apply apply_bll = new Dianda.BLL.Project_Apply();
        Dianda.Model.Project_Apply apply_model = new Dianda.Model.Project_Apply();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Web.Admin.personalProjectManage.MakeProjectSession makeprojectsession = new Dianda.Web.Admin.personalProjectManage.MakeProjectSession();
                makeprojectsession.getMyProjectList(this);
                //初始化项目下拉列表
                DataTable dt_project = (DataTable)Session["Project_Projects"];

                if (dt_project.Rows.Count > 0)
                {
                    //for (int i = 0; i < dt_project.Rows.Count; i++)
                    //{
                    //    //项目名称
                    //    string projectName = dt_project.Rows[i]["NAMES"].ToString();
                    //    //项目ID
                    //    string projectID = dt_project.Rows[i]["ID"].ToString();

                    //    ListItem li = new ListItem(projectName, projectID);

                    //    DDL_project.Items.Add(li);
                    //}

                    //if (null != Request["project"])
                    //{
                    //    DDL_project.SelectedValue = Request["project"].ToString();
                    //}

                    //状态
                    if (null != Request["status"] && !(Request["status"].ToString().Equals("")))
                    {
                        DDL_status.SelectedValue = Request["status"].ToString();
                    }

                    //类型
                    if (null != Request["type"] && !(Request["type"].ToString().Equals("")))
                    {
                        DDL_type.SelectedValue = Request["type"].ToString();
                    }


                    string pageindex = null;//这里是为分页服务的

                    pageindex = Request["pageindex"];

                    string count = dtrowsHidden.Value.ToString();
                    if (count.Length == 0)
                    {
                        //if (null == Request["status"] || Request["status"].ToString().Equals(""))
                        //{
                        //    setRowCout("orderSignet", "");//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                        //}
                        //else
                        //{
                        //    setRowCout(Request["type"].ToString(), Request["status"].ToString());
                        //    //DDL_status.SelectedValue = Request["status"].ToString();
                        //}

                        setRowCout(DDL_type.SelectedValue.ToString(), DDL_status.SelectedValue.ToString());
                        count = dtrowsHidden.Value.ToString();
                    }
                    else
                    {
                        count = "0";
                    }
                    int countint = int.Parse(count);

                    if (pageindex == null || pageindex == "")
                    {
                        pageindex = "1";
                    }

                    int pageindex_int = int.Parse(pageindex);

                    //if (null == Request["status"] || Request["status"].ToString().Equals(""))
                    //{
                    //    ShowApplyList(pageindex_int, "orderSignet", "");
                    //}
                    //else
                    //{
                        //ShowApplyList(pageindex_int, Request["type"].ToString(), Request["status"].ToString());

                        ShowApplyList(pageindex_int, DDL_type.SelectedValue.ToString(), DDL_status.SelectedValue.ToString());

                       // DDL_type.SelectedValue = Request["type"].ToString();

                        if (null!=Request["type"] && !(Request["type"].ToString().Equals("orderSignet")))
                        {
                            DDL_status.Items.Clear();

                            DDL_status.Items.Add(new ListItem("全部", ""));

                            ListItem li1 = new ListItem("待确认", "0");
                            DDL_status.Items.Add(li1);

                            ListItem li2 = new ListItem("已确认", "1");
                            DDL_status.Items.Add(li2);

                            ListItem li3 = new ListItem("已撤销", "2");
                            DDL_status.Items.Add(li3);

                            ListItem li4 = new ListItem("已挂起", "3");
                            DDL_status.Items.Add(li4);

                            // GridView1.Columns[4].Visible = false;
                        }

                        //for (int k = 0; k < DDL_type.Items.Count; k++)
                        //{
                        //    if (DDL_type.Items[k].Value.Equals(Request["type"].ToString()))
                        //    {
                        //        DDL_type.Items[k].Selected = true;
                        //    }
                        //}


                        //for (int i = 0; i < DDL_status.Items.Count; i++)
                        //{
                        //    if (DDL_status.Items[i].Value.Equals(Request["status"].ToString()))
                        //    {
                        //        DDL_status.Items[i].Selected = true;
                        //    }
                        //}


                  //  }

                        showHeaderRowName();
                }
                else
                {
                    notice.Text = "*没有可供选择的项目信息，无法查看资源！";
                    Button_add.Visible = false;
                    Button_revoke.Visible = false;
                }


                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = " 资源 > 资源汇总 ";
                //设置模板页中的管理值
            }
        }

        /// <summary>
        /// 显示头的名称
        /// </summary>
        private void showHeaderRowName()
        {
            try
            {
                if (DDL_type.SelectedValue.ToString().Equals("orderSignet"))
                {
                    if (GridView1.Visible != false)
                    {
                        GridView1.HeaderRow.Cells[2].Text = "预订日期";
                    }
                }
                else
                {
                    if (GridView1.Visible != false)
                    {
                        GridView1.HeaderRow.Cells[2].Text = "使用日期";
                        GridView1.Columns[5].Visible = false;
                    }


                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 获取业务申请列表信息
        /// </summary>
        protected void ShowApplyList(int pageindex, string type, string status)
        {

            try
            {
                DataTable DT = new DataTable();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                //string sqlWhere1 = " DELFLAG=0 and ProjectID=" + Session["Work_ProjectId"] + " and Status = " + status + " and SendUserID = '" + user_model.ID + "'  and AppType = '" + type + "'";
                
               // string sqlWhere1 = " DELFLAG=0 and ProjectID=" + DDL_project.SelectedValue.ToString() + " and Status = " + status + " and SendUserID = '" + user_model.ID + "'  and AppType = '" + type + "'";
                string sqlWhere1 = "";
                if (status == "")
                {
                    sqlWhere1 = " DELFLAG=0 and SendUserID = '" + user_model.ID + "'  and AppType = '" + type + "'";
                }
                else
                {
                    sqlWhere1 = " DELFLAG=0 and Status = " + status + " and SendUserID = '" + user_model.ID + "'  and AppType = '" + type + "'";
                }

                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                DT = pageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "vProject_Apply", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中

                    GridView1.Visible = true;
                    GridView1.DataSource = DT;//指定GridView1的数据是DT
                    pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    notice.Text = "";
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                    Button_revoke.Enabled = false;
                    if (alltiaoshuInt > 0)
                    {
                        ShowApplyList(pageindex - 1, type, status);
                    }
                }
            }
            catch
            {
                GridView1.Visible = false;
                notice.Text = "*进入业务申请列表发生错误！";
                pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                Button_revoke.Enabled = false;
            }
        }




        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout(string type, string status)
        {
            try
            {
                DataTable DT = new DataTable();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                string sendid = "";
                if (null != user_model)
                {
                    sendid = user_model.ID;
                }
                else
                {
                    sendid = "1";
                }
                //string sqlWhere = " DELFLAG=0 and ProjectID=" + Session["Work_ProjectId"] + " and Status = " + status + " and SendUserID = '" + sendid + "' and AppType = '" + type + "'";
                
                //string sqlWhere = " DELFLAG=0 and ProjectID=" + DDL_project.SelectedValue.ToString() + " and Status = " + status + " and SendUserID = '" + sendid + "' and AppType = '" + type + "'";
                string sqlWhere = "";
                if (status == "")
                {
                    sqlWhere = " DELFLAG=0 and SendUserID = '" + sendid + "' and AppType = '" + type + "'";
                }
                else
                {
                    sqlWhere = " DELFLAG=0 and Status = " + status + " and SendUserID = '" + sendid + "' and AppType = '" + type + "'";
                }
                int count = pageControl.tableRowCout(sqlWhere, "vProject_Apply", "ID");

                dtrowsHidden.Value = count.ToString();

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
            string status = DDL_status.SelectedValue.ToString();
            string type = DDL_type.SelectedValue.ToString();
            setRowCout(type, status);
            ShowApplyList(page, type, status);//调用显示
            showHeaderRowName();
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
            string status = DDL_status.SelectedValue.ToString();
            string type = DDL_type.SelectedValue.ToString();
            setRowCout(type, status);
            ShowApplyList(page, type, status);//调用显示
            showHeaderRowName();
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

                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    //业务申请的ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;

                    //申请类型
                    string AppType = DataBinder.Eval(e.Row.DataItem, "AppType").ToString();

                    //状态
                    string Status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                    //switch (AppType)
                    //{
                    //    case "orderFood":
                    //        e.Row.Cells[1].Text = "<a href='show.aspx?ID=" + ID + "' target='_self' rel='gb_page_center[726,400]'  title='查看订饭申请情况''>订饭申请</a>";
                    //        break;
                    //    case "orderCar":
                    //        e.Row.Cells[1].Text = "<a href='show.aspx?ID=" + ID + "' target='_self' rel='gb_page_center[726,400]'  title='查看订车申请情况''>订车申请</a>"; 
                    //        break;
                    //    case "orderRoom":
                    //        e.Row.Cells[1].Text = "<a href='show.aspx?ID=" + ID + "' target='_self' rel='gb_page_center[726,400]'  title='查看会议室申请情况''>订会议室</a>"; 
                    //        break;
                    //    case "orderSignet":
                    //        e.Row.Cells[1].Text = "<a href='show.aspx?ID=" + ID + "' target='_self' rel='gb_page_center[726,400]'  title='查看印章申请情况''>印章申请</a>"; 
                    //        break;
                    //}
                    ////申请人真实姓名
                    //string REALNAME = DataBinder.Eval(e.Row.DataItem, "REALNAME").ToString();
                    ////申请人用户名
                    //string USERNAME = DataBinder.Eval(e.Row.DataItem, "USERNAME").ToString();
                    ////申请人
                    //e.Row.Cells[2].Text = REALNAME + "[" + USERNAME + "]";

                    switch (AppType)
                    {
                        case "orderFood":
                            string time = "";
                            string sql = "SELECT UserDatetime FROM Project_Apply_orderFood WHERE (ApplyID = '" + ID + "')";

                            DataTable dt = pageControl.doSql(sql).Tables[0];

                            if (dt.Rows.Count > 0)
                            {
                                time = dt.Rows[0]["UserDatetime"].ToString();
                            }

                            e.Row.Cells[2].Text = "<a href=\"javascript:window.showModalDialog('show.aspx?ID=" + ID + "&UserDatetime=" + time + "','','dialogWidth=726px;dialogHeight=400px');\" target='_self'  title='查看午餐预定情况''>" + (Convert.ToDateTime(time).ToString("yyyy-MM-dd")).ToString() + "</a>";

                            switch (Status)
                            {
                                case "0":
                                    e.Row.Cells[4].Text = "待确认";
                                    break;
                                case "1":
                                    e.Row.Cells[4].Text = "已确认";
                                    break;
                                case "2":
                                    e.Row.Cells[4].Text = "<font color='red'>已撤销</font>";
                                    break;
                                case "3":
                                    e.Row.Cells[4].Text = "<font color='red'>已挂起</font>";
                                    break;
                            }

                            break;

                        case "orderCar":

                            string time1 = "";
                            string sql1 = "SELECT  StartTime, EndTime FROM Project_Apply_orderCar WHERE (ApplyID = '" + ID + "')";

                            DataTable dt1 = pageControl.doSql(sql1).Tables[0];

                            if (dt1.Rows.Count > 0)
                            {
                                string starttime = dt1.Rows[0]["StartTime"].ToString();
                                string endtime = dt1.Rows[0]["EndTime"].ToString();

                                time1 = "<a href=\"javascript:window.showModalDialog('show.aspx?ID=" + ID + "&StartTime=" + starttime + "&EndTime=" + endtime + "','','dialogWidth=726px;dialogHeight=400px');\" target='_self' title='查看车辆申请情况''>" + Convert.ToDateTime(starttime).ToString("yyyy-MM-dd HH:mm") + " 至 " + Convert.ToDateTime(endtime).ToString("yyyy-MM-dd HH:mm") + "</a>";
                                //使用开始时间
                                DateTime StartTime = Convert.ToDateTime(starttime);
                                //使用结束时间
                                DateTime EndTime = Convert.ToDateTime(endtime);
                                if (StartTime.Date == EndTime.Date)
                                {
                                    time1 = "<a href=\"javascript:window.showModalDialog('show.aspx?ID=" + ID + "&StartTime=" + starttime + "&EndTime=" + endtime + "','','dialogWidth=726px;dialogHeight=400px');\" target='_self' title='查看车辆申请情况''> " + StartTime.ToLongDateString() + "&nbsp;&nbsp;  " + StartTime.ToShortTimeString() + " 至 " + EndTime.ToShortTimeString() + "</a>";
                                }
                            }

                            e.Row.Cells[2].Text = time1;

                            switch (Status)
                            {
                                case "0":
                                    e.Row.Cells[4].Text = "待确认";
                                    break;
                                case "1":
                                    e.Row.Cells[4].Text = "已确认";
                                    break;
                                case "2":
                                    e.Row.Cells[4].Text = "<font color='red'>已撤销</font>";
                                    break;
                                case "3":
                                    e.Row.Cells[4].Text = "<font color='red'>已挂起</font>";
                                    break;
                            }
                            break;

                        case "orderRoom":
                            string time2 = "";
                            string meetingName = "";
                            string sql2 = "SELECT  StartTime, EndTime,MeetName FROM Project_Apply_orderRoom WHERE (ApplyID = '" + ID + "')";

                            DataTable dt2 = pageControl.doSql(sql2).Tables[0];

                            if (dt2.Rows.Count > 0)
                            {
                                string starttime = dt2.Rows[0]["StartTime"].ToString();

                                string endtime = dt2.Rows[0]["EndTime"].ToString();

                                meetingName = dt2.Rows[0]["MeetName"].ToString();

                                time2 = "<a href=\"javascript:window.showModalDialog('show.aspx?ID=" + ID + "&StartTime=" + starttime + "&EndTime=" + endtime + "','','dialogWidth=726px;dialogHeight=400px');\" target='_self'  title='查看会议室预定情况''> " + Convert.ToDateTime(starttime).ToString("yyyy-MM-dd HH:mm") + " 至 " + Convert.ToDateTime(endtime).ToString("yyyy-MM-dd HH:mm") + "</a>";

                                //使用开始时间
                                DateTime StartTime = Convert.ToDateTime(starttime);
                                //使用结束时间
                                DateTime EndTime = Convert.ToDateTime(endtime);
                                if (StartTime.Date == EndTime.Date)
                                {
                                    time2 = "<a href=\"javascript:window.showModalDialog('show.aspx?ID=" + ID + "&StartTime=" + starttime + "&EndTime=" + endtime + "','','dialogWidth=726px;dialogHeight=400px');\" target='_self'  title='查看会议室预定情况''>" + StartTime.ToLongDateString() + "&nbsp;&nbsp;  " + StartTime.ToShortTimeString() + " 至 " + EndTime.ToShortTimeString() + "</a>";
                                }


                            }
                            e.Row.Cells[2].Text = time2;

                            GridView1.HeaderRow.Cells[3].Text = "会议名称";
                            string Name = meetingName.Length > 30 ? meetingName.Substring(0, 30) + "..." : meetingName;
                            e.Row.Cells[3].Text = "<span title='" + meetingName + "'>" + Name+ "</span>";
                            
                            switch (Status)
                            {
                                case "0":
                                    e.Row.Cells[4].Text = "待确认";
                                    break;
                                case "1":
                                    e.Row.Cells[4].Text = "已确认";
                                    break;
                                case "2":
                                    e.Row.Cells[4].Text = "<font color='red'>已撤销</font>";
                                    break;
                                case "3":
                                    e.Row.Cells[4].Text = "<font color='red'>已挂起</font>";
                                    break;
                            }


                            break;

                        case "orderSignet":

                            string time3 = DataBinder.Eval(e.Row.DataItem, "DATETIME").ToString();
                            e.Row.Cells[2].Text = "<a href=\"javascript:window.showModalDialog('show.aspx?ID=" + ID + "','','dialogWidth=726px;dialogHeight=400px');\" target='_self'  title='查看印章申请情况''>" + Convert.ToDateTime(time3).ToString("yyyy-MM-dd HH:mm") + "</a>";

                            switch (Status)
                            {
                                case "0":
                                    e.Row.Cells[4].Text = "待审批";
                                    break;
                                case "1":
                                    e.Row.Cells[4].Text = "已审批";
                                    break;
                                case "2":
                                    e.Row.Cells[4].Text = "<font color='red'>已撤销</font>";
                                    break;
                                case "3":
                                    e.Row.Cells[4].Text = "<font color='red'>已挂起</font>";
                                    break;
                                case "4":
                                    e.Row.Cells[4].Text = "已完成";
                                    break;
                            }
                            //下载地址
                            string Attachments = DataBinder.Eval(e.Row.DataItem, "Attachments").ToString();
                            if (null != Attachments && !Attachments.Equals(""))
                            {
                                e.Row.Cells[5].Text = "<a href='" + Attachments + "' target='_blank'>点击下载</a>";
                            }
                            else
                            {
                                e.Row.Cells[5].Text = "无";
                            }

                            break;
                    }

                }
            }
            catch
            { }
        }

        /// <summary>
        /// 按项目筛选触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_project_Change(object sender, EventArgs e)
        {
            Button_revoke.Enabled = true;
            tag.Text = "";
            string status = DDL_status.SelectedValue.ToString();
            string type = DDL_type.SelectedValue.ToString();

            setRowCout(type, status);
            ShowApplyList(1, type, status);
            showHeaderRowName();
        }

        /// <summary>
        /// 按状态筛选触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_status_Change(object sender, EventArgs e)
        {

            tag.Text = "";
            string title = "";
            string status = DDL_status.SelectedValue.ToString();
            string type = DDL_type.SelectedValue.ToString();

            if (type.Equals("orderSignet"))
            {
                title = "预订日期";
            }
            else
            {
                title = "使用日期";
            }
            if (status.Equals("1"))//如果审核通过是不能再进行撤销操作的
            {
                Button_revoke.Enabled = false;
            }
            else
            {
                Button_revoke.Enabled = true;
            }

            setRowCout(type, status);
            ShowApplyList(1, type, status);

            if (GridView1.Visible != false)
            {
                GridView1.HeaderRow.Cells[2].Text = title;
            }

            //当状态为“已确认/已审核”，“已撤销”，“已完成”时，不能再进行撤销操作
            if (status.Equals("1") || status.Equals("2") || status.Equals("4"))
            {
                Button_revoke.Enabled = false;
            }
            showHeaderRowName();
        }

        /// <summary>
        /// 按状态筛选触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_type_Change(object sender, EventArgs e)
        {
            tag.Text = "";
            string title = "";
            string type = DDL_type.SelectedValue.ToString();

            if (type.Equals("orderSignet"))
            {
                DDL_status.Items.Clear();

                DDL_status.Items.Add(new ListItem("全部", ""));

                ListItem li1 = new ListItem("待审批", "0");
                DDL_status.Items.Add(li1);

                ListItem li2 = new ListItem("已审批", "1");
                DDL_status.Items.Add(li2);

                ListItem li3 = new ListItem("已撤销", "2");
                DDL_status.Items.Add(li3);

                ListItem li4 = new ListItem("已挂起", "3");
                DDL_status.Items.Add(li4);

                ListItem li5 = new ListItem("已完成", "4");
                DDL_status.Items.Add(li5);

                title = "预订日期";

            }
            else
            {
                DDL_status.Items.Clear();

                DDL_status.Items.Add(new ListItem("全部", ""));

                ListItem li1 = new ListItem("待确认", "0");
                DDL_status.Items.Add(li1);

                ListItem li2 = new ListItem("已确认", "1");
                DDL_status.Items.Add(li2);

                ListItem li3 = new ListItem("已撤销", "2");
                DDL_status.Items.Add(li3);

                ListItem li4 = new ListItem("已挂起", "3");
                DDL_status.Items.Add(li4);
                title = "使用日期";
            }

            //DDL_status.SelectedValue = "0";
            string status = DDL_status.SelectedValue.ToString();
            if (status.Equals("1"))//如果审核通过是不能再进行撤销操作的
            {
                Button_revoke.Enabled = false;
            }
            else
            {
                Button_revoke.Enabled = true;
            }


            setRowCout(type, status);
            ShowApplyList(1, type, status);
            if (GridView1.Visible != false)
            {
                GridView1.HeaderRow.Cells[2].Text = title;
            }


            if (type.Equals("orderSignet"))
            {
                GridView1.Columns[5].Visible = true;
            }
            else
            {
                GridView1.Columns[5].Visible = false;
            }
            showHeaderRowName();
        }

        /// <summary>
        /// 点击新增按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_add_onclick(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx?pageindex=" + pageindexHidden.Value + "&status=" + DDL_status.SelectedValue.ToString() + "&type=" + DDL_type.SelectedValue.ToString() + "&apply=" + DDL_type.SelectedValue.ToString() + "&order=orderresource");
        }

        /// <summary>
        /// 点击撤销按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_revoke_onclick(object sender, EventArgs e)
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
                    tag.Text = "撤销时最少选择一条数据！";

                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

                        if (cb1.Checked)
                        {
                            //获取业务的基本信息
                            apply_model = apply_bll.GetModel(int.Parse(hid.Value.ToString()));
                            //将删除标记设为1
                            //apply_model.DELFLAG = 1;

                            //将状态调为不通过
                            apply_model.Status = 2;
                            //申请类型
                            string applytype = apply_model.AppType;

                            string tablename = "";
                            string typeflag = "";
                            string type = "";
                            if (applytype.Equals("orderFood"))
                            {
                                tablename = "Project_Apply_orderFood";
                                typeflag = "订饭申请";
                                type = "客饭预定";
                            }
                            else if (applytype.Equals("orderCar"))
                            {
                                tablename = "Project_Apply_orderCar";
                                typeflag = "订车申请";
                                type = "车辆预定";
                            }
                            else if (applytype.Equals("orderRoom"))
                            {
                                tablename = "Project_Apply_orderRoom";
                                typeflag = "订会议室申请";
                                type = "会议室预定";
                            }
                            else if (applytype.Equals("orderSignet"))
                            {
                                tablename = "Project_Apply_signet";
                                typeflag = "印章申请";
                                type = "印章申请";
                            }

                           // string sql = " DELETE FROM " + tablename + " WHERE ApplyID = " + hid.Value.ToString();

                            apply_bll.Update(apply_model);

                            Dianda.Model.FaceShowMessage FaceShowMessage_Model = new Dianda.Model.FaceShowMessage();
                            Dianda.BLL.FaceShowMessage FaceShowMessage_BLL = new Dianda.BLL.FaceShowMessage();
                            string sql = " delete FaceShowMessage where NewsType='" + type + "' and ProjectID=" + apply_model.ProjectID + " and URLS like '%check.aspx?ID=" + apply_model.ID + "%'";

                            pageControl.doSql(sql);

                            //添加操作日志
                            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                            Dianda.Model.Project_Projects project_model = new Dianda.Model.Project_Projects();
                            Dianda.BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();

                            //project_model = project_bll.GetModel(Convert.ToInt16(DDL_project.SelectedValue.ToString()));
                           // bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "业务申请撤销", project_model.NAMES + "项目" + typeflag + "删除:成功！");
                            //添加操作日志
                        }
                    }

                    //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + pageindexHidden.Value.ToString() + "&status=" + DDL_status.SelectedValue.ToString() + "\";</script>";
                    //Response.Write(coutws);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入资源汇总列表页面');javascript:location='resourceManage.aspx?pageindex=" + pageindexHidden.Value.ToString() + "&type=" + DDL_type.SelectedValue + "&status=" + DDL_status.SelectedValue.ToString() + "';</script>", false);


                }

            }

        }
    }
}
