using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAapply
{
    public partial class ShowManage : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["staue"] != null)
                {
                    showmanage(Request.QueryString["staue"].ToString());
                }
            }
        }
        //显示页面内容
        public void showmanage(string staue)
        {

            if (staue == "orderCar")
            {
                //modify by wangjh on 2011-06-08 begin

//                string T_SQL = @"select dbo.USER_Users.USERNAME, dbo.USER_Users.REALNAME, dbo.Project_CarList.CarName,dbo.Project_Apply_orderCar.StartTime,dbo.Project_Apply_orderCar.EndTime,dbo.Project_Apply.Status 
//            from Project_Apply_orderCar join Project_Apply on Project_Apply.ID=Project_Apply_orderCar.ApplyID join Project_CarList on Project_Apply_orderCar.CarID=Project_CarList.ID join USER_Users on Project_Apply.ApplyUserID=USER_Users.ID
//            where  Project_CarList.DELFLAG=0 and Project_Apply.DELFLAG=0 and (Project_Apply.Status=1 or Project_Apply.Status=0) 
//            and '" + DateTime.Now + "'< Project_Apply_orderCar.EndTime order by Project_CarList.ID ";

                //和上面已注掉的SQL相比，下面的SQL去掉了“Project_CarList.DELFLAG=0 and”
                //因为在Project_CarList表中DELFLAG已经更改，不再作为删除标记了，是作为座位数的标记，如7，14就表示7个座和14个座

                string T_SQL = @"select dbo.USER_Users.USERNAME, dbo.USER_Users.REALNAME, dbo.Project_CarList.CarName,dbo.Project_Apply_orderCar.StartTime,dbo.Project_Apply_orderCar.EndTime,dbo.Project_Apply.Status 
            from Project_Apply_orderCar join Project_Apply on Project_Apply.ID=Project_Apply_orderCar.ApplyID join Project_CarList on Project_Apply_orderCar.CarID=Project_CarList.ID join USER_Users on Project_Apply.ApplyUserID=USER_Users.ID
            where   Project_Apply.DELFLAG=0 and (Project_Apply.Status=1 or Project_Apply.Status=0) 
            and '" + DateTime.Now + "'< Project_Apply_orderCar.EndTime order by Project_Apply_orderCar.StartTime DESC ";

                //modify by wangjh on 2011-06-08 end
                DataTable dt = new DataTable();
                dt = pageControl.doSql(T_SQL).Tables[0];
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (GridView1.Rows.Count == 0)
                {
                    Label6.Text = "对不起！没有预定车辆信息！";
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                }

            }
            else if (staue == "orderRoom")
            {
                string T_SQL = @"select RoomName,StartTime,EndTime,USERNAME,REALNAME,dbo.Project_Apply.Status 
                from Project_Apply_orderRoom join Project_Apply on Project_Apply.ID=Project_Apply_orderRoom.ApplyID
                join Project_RoomList on Project_RoomList.ID=Project_Apply_orderRoom.RoomID join 
                USER_Users on USER_Users.id=Project_Apply.ApplyUserID
                where  Project_RoomList.DELFLAG=0 and Project_Apply.DELFLAG=0 and ( Project_Apply.Status=1 or Project_Apply.Status=0) 
                and '" + DateTime.Now + "'< Project_Apply_orderRoom.EndTime order by StartTime DESC ";
                DataTable dt = new DataTable();
                dt = pageControl.doSql(T_SQL).Tables[0];

                GridView2.DataSource = dt;
                GridView2.DataBind();
                if (GridView2.Rows.Count == 0)
                {

                    Label6.Text = "对不起！没有预定会议室信息！";
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;



                }
            }
            else if (staue == "orderFood")
            {
                string T_SQL = @"select UserDatetime,USERNAME,REALNAME,OrderNum,dbo.Project_Apply.Status 
                from Project_Apply_orderFood join Project_Apply on Project_Apply.ID=Project_Apply_orderFood.ApplyID
                join USER_Users on USER_Users.id=Project_Apply.ApplyUserID
                where Project_Apply.DELFLAG=0 and (Project_Apply.Status=1 or Project_Apply.Status=0)               
                and '" + DateTime.Now + "'< UserDatetime order by UserDatetime";
                DataTable dt = new DataTable();
                dt = pageControl.doSql(T_SQL).Tables[0];
                GridView3.DataSource = dt;
                GridView3.DataBind();
                if (GridView3.Rows.Count == 0)
                {
                    Label6.Text = "对不起！没有预定午餐信息！";
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;

                }
            }
            else if (staue == "orderSignet")
            {
                string T_SQL = @"select SignetName,Nums,USERNAME,REALNAME
                from Project_Apply_signet join Project_Apply on Project_Apply.ID=Project_Apply_signet.ApplyID
                join Project_SignetList on Project_SignetList.ID=Project_Apply_signet.SignetID join 
                USER_Users on USER_Users.id=Project_Apply.ApplyUserID
                where  Project_SignetList.DELFLAG=0 and Project_Apply.DELFLAG=0 and Project_Apply.Status=1";
                DataTable dt = new DataTable();
                dt = pageControl.doSql(T_SQL).Tables[0];
                GridView4.DataSource = dt;
                GridView4.DataBind();
                if (GridView4.Rows.Count == 0)
                {

                    Label6.Text = "对不起！没有已申请用印的相关信息！";
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;


                }
            }
            else
            {
                Label6.Text = "对不起！没有信息！";
                GridView2.Visible = false;
                GridView1.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;

            }
        }
    }
}
