using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace Dianda.Web.Admin.applyManage.OrderfoodManage
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
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 订饭管理 > 订饭审批 ";
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
                string sql = "SELECT * FROM vProject_Apply_OrderFood WHERE  ID = " + id;

                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    //项目名称
                    Label_ProjectName.Text = DT.Rows[0]["ProjectNames"].ToString();
                    Session["ProjectNames"] = DT.Rows[0]["ProjectNames"].ToString();
                    //提交申请时间
                    Label_DATETIME.Text = Convert.ToDateTime(DT.Rows[0]["DATETIME"].ToString()).ToString("yyyy-MM-dd hh:mm");
                    //预订份额
                    Label_OrderNum.Text = DT.Rows[0]["OrderNum"].ToString()+"份";
                    Session["OrderNum"] = DT.Rows[0]["OrderNum"].ToString();
                    //订饭申请人
                    Label_SendUserID.Text = DT.Rows[0]["SendRealName"].ToString() + "[" + DT.Rows[0]["SendUserName"].ToString() + "]";
                    Session["Food_ApplyUserName"] ="("+ DT.Rows[0]["SendRealName"].ToString() + ")";
                    //用饭时间
                    string userdatetime = DT.Rows[0]["UserDatetime"].ToString();
                    Label_UserDatetime.Text = Convert.ToDateTime(userdatetime).ToString("yyyy-MM-dd") + " 11:30";
                    Session["UserDatetime"] = Convert.ToDateTime(userdatetime).ToString("yyyy-MM-dd") + " 11:30";
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


                    /********************* 以下是显示还剩余多少份可以预订*************************/
                    //定饭总量
                    int orderFoodNums = int.Parse(ConfigurationSettings.AppSettings["orderFoodNums"]);

                    DataTable dt = new DataTable();
                    string sql_num = " SELECT SUM(Project_Apply_orderFood.OrderNum) AS OrderNum FROM Project_Apply " +
                                 " RIGHT OUTER JOIN Project_Apply_orderFood " +
                                 " ON Project_Apply.ID = Project_Apply_orderFood.ApplyID " +
                                 " WHERE (Project_Apply.Status = 1) and (Project_Apply.AppType='orderFood') ";

                    sql_num = sql_num + "  AND (Project_Apply_orderFood.UserDatetime = '" + userdatetime + "')";

                    dt = pageControl.doSql(sql_num).Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        if (null == dt.Rows[0]["OrderNum"] || dt.Rows[0]["OrderNum"].ToString().Equals(""))
                        {
                            Label_LimitNums.Text = "当日还剩" + orderFoodNums + "份可以预订！";
                        }else
                        {
                            int OrderNum = int.Parse(dt.Rows[0]["OrderNum"].ToString());
                            //剩余可预订的数量
                            int LimitNum = orderFoodNums - OrderNum;

                            if (LimitNum > 0)
                            {
                                Label_LimitNums.Text = "当日还剩" + LimitNum + "份可以预订！";
                            }
                            else
                            {
                                Label_LimitNums.Text = "该日已经全部预订完！";
                            }
                        }
                    }
                    else
                    {
                        Label_LimitNums.Text = "当日还剩" + orderFoodNums + "份可以预订！";
                    }

                    /********************* 以上是显示还剩余多少份可以预订*************************/

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
                mFaceShowMessage.URLS = "<a href=\"javascript:window.showModalDialog('/Admin/personalProjectManage/OAapply/show.aspx?ID=" + apply_model.ID + "','','dialogWidth=726px;dialogHeight=400px');\" target='_self'  title='客饭预定审核'>客饭预定  " + "数量  " + Session["OrderNum"] + "  " + flag + "</a>  " + Session["UserDatetime"] + "  " + Session["Food_ApplyUserName"];
                mFaceShowMessage.DELFLAG = 0;
                mFaceShowMessage.ProjectID = apply_model.ProjectID;
                bFaceShowMessage.Add(mFaceShowMessage);
                //给业务申请者发信息

                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "&Status=" + Request["Status"] + "\";</script>";


                Response.Write(coutws);

                //添加操作日志

                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "申请管理", "订饭申请审核" + flag + "：成功！");

                //添加操作日志

            }
            catch
            {

            }
        }
    }
}
