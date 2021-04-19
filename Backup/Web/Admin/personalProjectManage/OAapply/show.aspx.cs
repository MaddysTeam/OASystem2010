using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAapply
{
    public partial class show : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string applyid = Request["ID"];
                td_address.Visible = false;
                td_1.ColSpan = 2;
                SetApplyInfo(applyid);
            }
        }

        /// <summary>
        /// 初妈显示业务申请的详细信息
        /// </summary>
        /// <param name="id"></param>
        protected void SetApplyInfo(string id)
        {
            try
            {
                string name = "申请日期：";
                DataTable dt = new DataTable();
                string sql = " SELECT USER_Users_1.REALNAME AS SendUserName, "+
                              " USER_Users.REALNAME AS DoUserName, Project_Projects.NAMES AS ProjectName, "+
                              " USER_Groups.NAME AS DepartmentName, Project_Apply.ID, Project_Apply.ProjectID, "+ 
                              " Project_Apply.Status, Project_Apply.AppType, Project_Apply.Overviews,  "+
                              " Project_Apply.DATETIME, Project_Apply.ReadTime, Project_Apply.CheckNote, "+
                              " Project_Apply.TelNum, Project_Apply.DoNote, Project_Apply.TEMP1, Project_Apply.TEMP2 " +
                        " FROM USER_Users RIGHT OUTER JOIN "+
                              " Project_Projects RIGHT OUTER JOIN "+
                              " Project_Apply LEFT OUTER JOIN "+
                              " USER_Groups ON Project_Apply.DepartmentID = USER_Groups.ID ON  "+
                              " Project_Projects.ID = Project_Apply.ProjectID ON  "+
                              " USER_Users.ID = Project_Apply.DoUserID LEFT OUTER JOIN " +
                              " USER_Users AS USER_Users_1 ON Project_Apply.ApplyUserID = USER_Users_1.ID " +
                        
                              
                              " WHERE Project_Apply.ID=" + id;

                dt = pageControl.doSql(sql).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    showinfo.Visible = true;
                    notice.Text = "";
                    //项目名称
                    Label_ProjectName.Text = dt.Rows[0]["ProjectName"].ToString();
                    //业务类型
                    string AppType = dt.Rows[0]["AppType"].ToString();
                    //申请状态
                    string Status = dt.Rows[0]["Status"].ToString();

                    switch (Status)
                    {
                        case "0":
                            Label_Status.Text = "待确认";
                            break;
                        case "1":
                            Label_Status.Text = "已确认";
                            break;
                        case "2":
                            Label_Status.Text = "<font color='red'>已撤销</font>";
                            break;
                        case "3":
                            Label_Status.Text = "<font color='red'>已挂起</font>";
                            break;
                    }

                    switch (AppType)
                    {
                        case "orderFood":
                            Label_AppType.Text = "客饭预约";

                            //Label_userTime.Text = (Convert.ToDateTime(Request["UserDatetime"]).ToString("yyyy-MM-dd")).ToString();
                            ReadFood(id);
                            break;
                        case "orderCar":
                            Label_AppType.Text = "车辆预约";
                            ReadCar(id);
 
                            //Label_userTime.Text = Convert.ToDateTime(Request["StartTime"]).ToString("yyyy-MM-dd hh:mm") + " 至 " + Convert.ToDateTime(Request["EndTime"].ToString()).ToString("yyyy-MM-dd hh:mm");
                            break;
                        case "orderRoom":
                            Label_AppType.Text = "会议室预约";
                            ReadRoom(id);
                            //Label_userTime.Text = Convert.ToDateTime(Request["StartTime"].ToString()).ToString("yyyy-MM-dd hh:mm") + " 至 " + Convert.ToDateTime(Request["EndTime"].ToString()).ToString("yyyy-MM-dd hh:mm");
                            //adress(id);
                            break;
                        case "orderSignet":
                            Label_AppType.Text = "用印申请";
                            //tr_userTime.Visible = false;
                            name = "预订日期：";

                            switch (Status)
                            {
                                case "0":
                                    Label_Status.Text = "待审批";
                                    break;
                                case "1":
                                    Label_Status.Text = "已审批";
                                    break;
                                case "2":
                                    Label_Status.Text = "<font color='red'>已撤销</font>";
                                    break;
                                case "3":
                                    Label_Status.Text = "<font color='red'>已挂起</font>";
                                    break;
                                case "4":
                                    Label_Status.Text = "已完成";
                                    break;
                            }
                            ReadSignet(id);
                            break;
                    }
                    //申请时间
                    Label_DATETIME.Text = name + dt.Rows[0]["DATETIME"].ToString();
                    //申请人
                    Label_SendUserID.Text = dt.Rows[0]["SendUserName"].ToString();
                    //申请部门
                    Label_DEPARTMENT.Text = dt.Rows[0]["DepartmentName"].ToString();
                    //联系电话
                    Label_TelNum.Text = dt.Rows[0]["TelNum"].ToString();
                    //用途描述
                    Label_Overviews.Text = dt.Rows[0]["Overviews"].ToString();
                    //审核人
                    Label_DoUserID.Text = dt.Rows[0]["DoUserName"].ToString();
                    //审核时间
                    Label_ReadTime.Text = dt.Rows[0]["ReadTime"].ToString();
                    //审核意见
                    Label_DoNote.Text = dt.Rows[0]["DoNote"].ToString();
                    //执行人
                    if (null != dt.Rows[0]["TEMP1"] && !(dt.Rows[0]["TEMP1"].ToString().Equals("")))
                    {
                        LB_ZXR.Text = "执行人：" + dt.Rows[0]["TEMP1"].ToString();
                    }
                    //执行时间
                    if (null != dt.Rows[0]["TEMP2"] && !(dt.Rows[0]["TEMP2"].ToString().Equals("")))
                    {
                        LB_ZXSJ.Text = "执行时间：" + dt.Rows[0]["TEMP2"].ToString();
                    }
                }
                else
                {
                    notice.Text = "没有找到符合条件的数据或该数据已经删除！";
                    showinfo.Visible = false;
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 会议室地址获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void adress(string id)
        {
            td_address.Visible = true;
            td_1.ColSpan = 0;
            string RoomAdress="";
            DataTable dt = new DataTable();
            string sql = "select Address from Project_Apply_orderRoom where ApplyID=" + id;
            dt = pageControl.doSql(sql).Tables[0];
            RoomAdress = dt.Rows[0]["Address"].ToString();
            Label1_Adress.Text = RoomAdress;
        }
        /// <summary>
        /// 读用餐信息
        /// </summary>
        /// <param name="_ID"></param>
        public void ReadFood(string _ID)
        {
            string sql = "select case convert(varchar(10),isnull(UserDatetime,''),120) when '1900-01-01' then '' else convert(varchar(10),isnull(UserDatetime,''),120) end UserDatetime,isnull(OrderNum,0) OrderNum " +
                "from vProject_Apply_OrderFood where ID=" + _ID;
            DataTable dt = pageControl.doSql(sql).Tables[0];

            string message = "";
            if (dt.Rows.Count > 0)
            {
                message += " 用餐时间：" + dt.Rows[0]["UserDatetime"].ToString();
                message += " 用餐人数：" + dt.Rows[0]["OrderNum"].ToString();
                Label_userTime.Text = message;
            }
        }
        /// <summary>
        /// 读用车信息
        /// </summary>
        /// <param name="_ID"></param>
        public void ReadCar(string _ID)
        {
            string sql = "select isnull(StartTime,'') StartTime,isnull(EndTime,'') EndTime,"+
                "isnull(FromAddress,'') FromAddress,isnull(ToAddress,'') ToAddress," +
                "isnull(PeopleNum,0) PeopleNum,isnull(CarName,'') CarName " +
                " from vProject_Apply_OrderCar where ID=" + _ID;
            DataTable dt = pageControl.doSql(sql).Tables[0];

            string message = "";
            if (dt.Rows.Count > 0)
            {
                message += " 车名：" + dt.Rows[0]["CarName"].ToString();
                message += " 用车时间：" + dt.Rows[0]["StartTime"].ToString() + " 至 " + dt.Rows[0]["EndTime"].ToString();
                message += "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                message += " 始发地：" + dt.Rows[0]["FromAddress"].ToString();
                message += " 目的地：" + dt.Rows[0]["ToAddress"].ToString();
                message += " 乘车人数：" + dt.Rows[0]["PeopleNum"].ToString();
                Label_userTime.Text = message;
            }
        }
        /// <summary>
        /// 读会议室信息
        /// </summary>
        /// <param name="_ID"></param>
        public void ReadRoom(string _ID)
        {
            string sql = "select isnull(StartTime,'') StartTime,isnull(EndTime,'') EndTime," +
                "isnull(Address,'') Address,isnull(RoomName,'') RoomName,isnull(MeetName,'') MeetName," +
                "isnull(PeopleNum,0) PeopleNum " +
                "from vProject_Apply_OrderRoom where ID=" + _ID;
            DataTable dt = pageControl.doSql(sql).Tables[0];

            string message = "";
            if (dt.Rows.Count > 0)
            {
                message += " 会议室名称：" + dt.Rows[0]["RoomName"].ToString();
                message += " 会议名称：" + dt.Rows[0]["MeetName"].ToString();
                message += "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                message += " 会议时间：" + dt.Rows[0]["StartTime"].ToString() + " 至 " + dt.Rows[0]["EndTime"].ToString();
                message += " 会议人数：" + dt.Rows[0]["PeopleNum"].ToString();
                message += "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                if (string.IsNullOrEmpty(dt.Rows[0]["Address"].ToString()))
                {
                    message += " 预定要求：无";
                }
                else
                {
                    message += " 预定要求：" + dt.Rows[0]["Address"].ToString();
                }
                Label_userTime.Text = message;
            }
        }
        /// <summary>
        /// 读用印信息
        /// </summary>
        /// <param name="_ID"></param>
        public void ReadSignet(string _ID)
        {
            string sql = "select isnull(signetName,'') signetName,isnull(Nums,0) Nums " +
                "from vProject_Apply_OrderSignet where ID=" + _ID;
            DataTable dt = pageControl.doSql(sql).Tables[0];

            string message = "";
            if (dt.Rows.Count > 0)
            {
                message += " 印章种类：" + dt.Rows[0]["signetName"].ToString();
                message += " 敲章份数：" + dt.Rows[0]["Nums"].ToString();

                Label_userTime.Text = message;
            }
        }
    }
}
