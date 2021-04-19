using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.applyManage.OrdercarManage
{
    public partial class check : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.BLL.Project_Apply apply_bll = new Dianda.BLL.Project_Apply();
        Dianda.Model.Project_Apply apply_model = new Dianda.Model.Project_Apply();
        Dianda.COMMON.common com = new Dianda.COMMON.common();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request["ID"] != null)
                {
                    apply_model = apply_bll.GetModel(int.Parse(com.SafeString(Request["ID"])));
                    if (apply_model.Status != 0)
                    {
                        ListItem ls = new ListItem();
                        ls.Value = "2";
                        ls.Text = "已撤销";
                        RadioButtonList_Check.Items.Add(ls);
                        Button_sumbit.Visible = true;
                    }
                }
                //业务申请ID
                string ID = Request["ID"];
                ShowApplyInfo(ID);


                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 车辆管理 > 订车审批 ";
                //设置模板页中的管理值
            }
        }



        /// <summary>
        /// 显示项目详情
        /// </summary>
        /// <param name="id"></param>
        protected void ShowApplyInfo(string id)
        {
            try
            {
                DataTable DT = new DataTable();
                string sql = "SELECT * FROM vProject_Apply_OrderCar WHERE  ID = " + id;

                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    //项目名称
                    Label_ProjectName.Text = DT.Rows[0]["ProjectNames"].ToString();
                    Session["ProjectNames"] = DT.Rows[0]["ProjectNames"].ToString();
                    //提交申请时间
                    Label_DATETIME.Text = Convert.ToDateTime(DT.Rows[0]["DATETIME"].ToString()).ToString("yyyy-MM-dd hh:mm");
                    //预订车辆
                    Label_CarName.Text = DT.Rows[0]["CarName"].ToString();
                    Session["CarName"] = DT.Rows[0]["CarName"].ToString();
                    //订车申请人
                    Label_SendUserID.Text = DT.Rows[0]["SendRealName"].ToString() + "[" + DT.Rows[0]["SendUserName"].ToString() + "]";
                    Session["Car_ApplyUserName"] = "("+DT.Rows[0]["SendRealName"].ToString() + ")";
                    //申请部门
                    Label_DepartmentID.Text = DT.Rows[0]["DepartmentName"].ToString();
                    //用车开始时间
                    string StartTime = DT.Rows[0]["StartTime"].ToString();
                    //用车开始时间
                    string EndTime = DT.Rows[0]["EndTime"].ToString();
                    //用车时间
                    Label_UserDatetime.Text = Convert.ToDateTime(StartTime).ToString("yyyy-MM-dd hh:mm") + " 至 " + Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd hh:mm");
                    //乘车人数
                    Label_PeopleNums.Text = DT.Rows[0]["PeopleNum"].ToString() +" 人";
                    //联系电话
                    Label_TelNums.Text = DT.Rows[0]["TelNum"].ToString();
                    //项目概要
                    Label_Overviews.Text = DT.Rows[0]["Overviews"].ToString();

                    //审核意见
                    string DoNote = DT.Rows[0]["DoNote"].ToString();

                    if (null != DoNote && !DoNote.Equals(""))
                    {
                        TB_DoNote.Text = DoNote;
                    }
                    else
                    {
                        TB_DoNote.Text = "";
                    }

                    //审批状态
                    string status = DT.Rows[0]["Status"].ToString();

                    if (null != status && !status.Equals("0"))
                    {
                        RadioButtonList_Check.SelectedValue = status;

                    }
                    else
                    {
                        RadioButtonList_Check.SelectedValue = "1";
                    }

                    /********************* 以下是显示某一车辆在预订时间内已经预订的时间段*************************/

                    //预订开始时间("yyyy-MM-dd"格式)
                    string stime = Convert.ToDateTime(StartTime).ToString("yyyy-MM-dd");
                    DateTime DD1 = Convert.ToDateTime(stime);
                    DateTime DD1_1 = DD1.AddSeconds(-1);
                    DateTime DD1_2 = DD1.AddDays(1);
                    //车辆ID
                    string carid = DT.Rows[0]["CarID"].ToString();

                    DataTable dt1 = new DataTable();
                    string sql_ordercar = "SELECT CONVERT(varchar(100),Project_Apply_orderCar.StartTime,23) as StartTime1, " +
                                            " CONVERT(varchar(100),Project_Apply_orderCar.EndTime,23) as EndTime1," +
                                            " CONVERT(varchar(100),Project_Apply_orderCar.StartTime,24) as StartTime2, " +
                                            " CONVERT(varchar(100),Project_Apply_orderCar.EndTime,24) as EndTime2, " +
                                              " USER_Users.USERNAME, USER_Users.REALNAME " +
                                        " FROM USER_Users RIGHT OUTER JOIN " +
                                              " Project_Apply ON USER_Users.ID = Project_Apply.SendUserID RIGHT OUTER JOIN " +
                                              " Project_Apply_orderCar ON  " +
                                              " Project_Apply.ID = Project_Apply_orderCar.ApplyID " +
                                 " WHERE (Project_Apply.DELFLAG = 0) AND (Project_Apply.AppType='orderCar') " +
                                 " AND (Project_Apply.Status=1) AND (Project_Apply_orderCar.CarID=" + carid + ")" +
                                 " AND (Project_Apply_orderCar.StartTime >'" + DD1_1 + "')" +
                                 " AND (Project_Apply_orderCar.StartTime <'" + DD1_2 + "')" +
                                 " AND (Project_Apply_orderCar.EndTime >'" + DD1_1 + "')" +
                                 " AND (Project_Apply_orderCar.EndTime <'" + DD1_2 + "')";

                    dt1 = pageControl.doSql(sql_ordercar).Tables[0];

                    if (dt1.Rows.Count > 0)
                    {
                        for (int k = 0; k < dt1.Rows.Count; k++)
                        {
                            string StartHour = dt1.Rows[k]["StartTime2"].ToString();
                            string EndHour = dt1.Rows[k]["EndTime2"].ToString();
                            string REALNAME = dt1.Rows[k]["REALNAME"].ToString();
                            string USERNAME = dt1.Rows[k]["USERNAME"].ToString();
                            string name = REALNAME + "["+USERNAME+"]";

                            string message = "<font color='red'>" + stime + " " + StartHour.Substring(0, StartHour.Length - 3) + " 至 " + stime + " " + EndHour.Substring(0, EndHour.Length - 3) + " 已被" + name + "预订 </font></br>";

                            Label_Notice.Text = Label_Notice.Text + message;
                        }
                    }
                    else
                    {
                        Label_Notice.Text = "<font color='red'>当前日期没有被预订过！</font>";
                    }

                    /********************* 以上是显示某一车辆在预订时间内已经预订的时间段*************************/

                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// 点击返回触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_goback_onclick(object sender, EventArgs e)
        {
            string page = Request["pageindex"].ToString();
            string status = Request["Status"].ToString();

            Response.Redirect("manage.aspx?pageindex=" + page + "&Status=" + status);
        }


        /// <summary>
        /// 点击确定触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_onclick(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                string flag = "已挂起";
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                //业务申请ID
                string ID = Request["ID"];
                apply_model = apply_bll.GetModel(int.Parse(ID));

                //审批人员
                apply_model.DoUserID = user_model.ID;
                //审批时间
                apply_model.ReadTime = now;
                //审批意见
                apply_model.DoNote = TB_DoNote.Text.ToString();

                //审批结果
                string Status = RadioButtonList_Check.SelectedValue;

                if (Status.Equals("1"))
                {
                    flag = "已确认";
                }

                apply_model.Status = int.Parse(Status);

                apply_bll.Update(apply_model);

                //给业务申请者发信息
                Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

                mFaceShowMessage.DATETIME = now;
                mFaceShowMessage.FromTable = "申请情况";
                mFaceShowMessage.IsRead = 0;
                mFaceShowMessage.NewsID = null;
                mFaceShowMessage.NewsType = "申请情况";
                mFaceShowMessage.ReadTime = null;
                mFaceShowMessage.Receive = apply_model.SendUserID.ToString();
                mFaceShowMessage.URLS = "<a href=\"javascript:window.showModalDialog('/Admin/personalProjectManage/OAapply/show.aspx?ID=" + apply_model.ID + "','','dialogWidth=600px;dialogHeight=400px')\"; target='_self' title='车辆预定审核'>" + Session["CarName"] + "的预约" + flag + "</a>  " + Session["Car_ApplyUserName"];
                mFaceShowMessage.DELFLAG = 0;
                mFaceShowMessage.ProjectID = apply_model.ProjectID;
                bFaceShowMessage.Add(mFaceShowMessage);
                //给业务申请者发信息

                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "&Status=" + Request["Status"] + "\";</script>";

                Response.Write(coutws);

                //添加操作日志

                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "申请管理", "订车申请审核" + flag + "：成功！");

                //添加操作日志

            }
            catch
            {

            }
        }
    }
}
