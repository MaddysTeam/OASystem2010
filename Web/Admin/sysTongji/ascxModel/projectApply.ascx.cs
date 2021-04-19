using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.sysTongji.ascxModel
{
    public partial class projectApply : System.Web.UI.UserControl
    {
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.BLL.Project_Apply apply_bll = new Dianda.BLL.Project_Apply();
        Dianda.Model.Project_Apply apply_model = new Dianda.Model.Project_Apply();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label_tongji.Text = "暂无统计信息！";
            }
        }

        /// <summary>
        /// 获取业务申请列表信息
        /// </summary>
        public void ShowApplyList(string type,string projectid)
        {

            try
            {
                HiddenField_projectid.Value = projectid;
                DataTable DT = new DataTable();
                string sqlWhere1 = "select * from vProject_Apply where DELFLAG=0 and ProjectID=" + projectid + "  and AppType = '" + type + "'  order by datetime desc";

                DT = pageControl.doSql(sqlWhere1).Tables[0];
              
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中

                    GridView1.Visible = true;
                    GridView1.DataSource = DT;//指定GridView1的数据是DT
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";
                    tongji(DT);
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
                    Label_tongji.Text = "暂无统计信息！";
                }
            }
            catch
            {
                GridView1.Visible = false;
                notice.Text = "*进入业务申请列表发生错误！";
                Label_tongji.Text = "暂无统计信息！";
            }
            if (type == "orderSignet")
            {
                GridView1.HeaderRow.Cells[1].Text = "预订日期";
            }
            if (DDL_type.SelectedValue.ToString().Equals("orderSignet"))
            {
                if (GridView1.Visible != false)
                {
                    GridView1.HeaderRow.Cells[1].Text = "预订日期";
                }
            }
            else
            {
                if (GridView1.Visible != false)
                {
                    GridView1.HeaderRow.Cells[1].Text = "使用日期";
                    GridView1.Columns[4].Visible = false;
                }


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

                            e.Row.Cells[1].Text = "<a href=\"javascript:window.showModalDialog('/Admin/personalProjectManage/OAapply/show.aspx?ID=" + ID + "','','dialogWidth=715px;dialogHeight=250px');\"  title='查看午餐预定情况'>" + (Convert.ToDateTime(time).ToString("yyyy-MM-dd")).ToString() + "</a>";

                            switch (Status)
                            {
                                case "0":
                                    e.Row.Cells[3].Text = "待确认";
                                    break;
                                case "1":
                                    e.Row.Cells[3].Text = "已确认";
                                    break;
                                case "2":
                                    e.Row.Cells[3].Text = "<font color='red'>已撤销</font>";
                                    break;
                            }

                            break;

                        case "orderCar":

                            string time1 = "";
                            string sql1 = "SELECT  StartTime, EndTime FROM Project_Apply_orderCar WHERE (ApplyID = '" + ID + "')";

                            DataTable dt1 = pageControl.doSql(sql1).Tables[0];

                            if (dt1.Rows.Count > 0)
                            {
                                time1 = "<a href=\"javascript:window.showModalDialog('/Admin/personalProjectManage/OAapply/show.aspx?ID=" + ID + "','','dialogWidth=715px;dialogHeight=250px');\"  title='查看车辆申请情况'>" + dt1.Rows[0]["StartTime"].ToString() + " 至 " + dt1.Rows[0]["EndTime"].ToString() + "</a>";
                            }

                            e.Row.Cells[1].Text = time1;

                            switch (Status)
                            {
                                case "0":
                                    e.Row.Cells[3].Text = "待确认";
                                    break;
                                case "1":
                                    e.Row.Cells[3].Text = "已确认";
                                    break;
                                case "2":
                                    e.Row.Cells[3].Text = "<font color='red'>已撤销</font>";
                                    break;
                            }
                            break;

                        case "orderRoom":
                            string time2 = "";
                            string sql2 = "SELECT  StartTime, EndTime FROM Project_Apply_orderRoom WHERE (ApplyID = '" + ID + "')";

                            DataTable dt2 = pageControl.doSql(sql2).Tables[0];

                            if (dt2.Rows.Count > 0)
                            {
                                time2 = "<a href=\"javascript:window.showModalDialog('/Admin/personalProjectManage/OAapply/show.aspx?ID=" + ID + "','','dialogWidth=715px;dialogHeight=250px');\"  title='查看会议室预定情况'>" + dt2.Rows[0]["StartTime"].ToString() + " 至 " + dt2.Rows[0]["EndTime"].ToString() + "</a>";
                            }

                            e.Row.Cells[1].Text = time2;

                            switch (Status)
                            {
                                case "0":
                                    e.Row.Cells[3].Text = "待确认";
                                    break;
                                case "1":
                                    e.Row.Cells[3].Text = "已确认";
                                    break;
                                case "2":
                                    e.Row.Cells[3].Text = "<font color='red'>已撤销</font>";
                                    break;
                            }

                            break;

                        case "orderSignet":

                            string time3 = DataBinder.Eval(e.Row.DataItem, "DATETIME").ToString();
                            e.Row.Cells[1].Text = "<a href=\"javascript:window.showModalDialog('/Admin/personalProjectManage/OAapply/show.aspx?ID=" + ID + "','','dialogWidth=715px;dialogHeight=250px');\"  title='查看印章申请情况'>" + time3 + "</a>";

                            switch (Status)
                            {
                                case "0":
                                    e.Row.Cells[3].Text = "待审核";
                                    break;
                                case "1":
                                    e.Row.Cells[3].Text = "审核通过";
                                    break;
                                case "2":
                                    e.Row.Cells[3].Text = "<font color='red'>审核不通过</font>";
                                    break;
                            }
                            //下载地址
                            string Attachments = DataBinder.Eval(e.Row.DataItem, "Attachments").ToString();
                            if (null != Attachments && !Attachments.Equals(""))
                            {
                                e.Row.Cells[4].Text = "<a href='" + Attachments + "' target='_blank'>点击下载</a>";
                            }
                            else
                            {
                                e.Row.Cells[4].Text = "无";
                            }

                            break;
                    }

                }
            }
            catch
            { }
        }
 
        /// <summary>
        /// 按项目的类型进行筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_type_Change(object sender, EventArgs e)
        {
            tag.Text = "";
            string type = DDL_type.SelectedValue.ToString();
            string projectid = HiddenField_projectid.Value.ToString();
            ShowApplyList(type, projectid);
        }
        /// <summary>
        /// 根据数据和统计的类型，数据统计信息
        /// </summary>
        /// <param name="dt"></param>
        private void tongji(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    Label_tongji.Text = "共&nbsp;" + dt.Rows.Count.ToString() + "&nbsp;条记录<br/>";
                    int t0 = 0;
                    int t1 = 0;
                    int t2 = 0;
                    //申请类型
                    string AppType = dt.Rows[0]["AppType"].ToString();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //状态
                        string Status = dt.Rows[i]["Status"].ToString();
                        if (Status == "0")
                        {
                            t0 = t0 + 1;
                        }

                        if (Status == "1")
                        {
                            t1 = t1 + 1;
                        }
                        if (Status == "2")
                        {
                            t2 = t2 + 1;
                        }
                    }

                    if (AppType == "orderFood" || AppType == "orderCar" || AppType == "orderRoom")
                    {
                        Label_tongji.Text = Label_tongji.Text + "待确认&nbsp;" + t0.ToString() + "&nbsp;条<br/>已确认&nbsp;" + t1.ToString() + "&nbsp;条<br/>已撤销&nbsp;" + t2.ToString() + "&nbsp;条";
                    }
                    if (AppType == "orderSignet")
                    {
                        Label_tongji.Text = Label_tongji.Text + "待审核&nbsp;" + t0.ToString() + "&nbsp;条<br/>审核通过&nbsp;" + t1.ToString() + "&nbsp;条<br/>审核不通过&nbsp;" + t2.ToString() + "&nbsp;条";
                    }
                }
                else
                {
                    Label_tongji.Text = "暂无统计信息！";
                }
            }
            catch
            {
            }
        }
    }
}
