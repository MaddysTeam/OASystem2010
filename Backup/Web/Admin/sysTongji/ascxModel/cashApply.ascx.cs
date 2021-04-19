using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.sysTongji.ascxModel
{
    public partial class cashApply : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.COMMON.common common = new Dianda.COMMON.common();
        Model.Cash_Apply mCash_Apply = new Dianda.Model.Cash_Apply();
        BLL.Cash_Apply bCash_Apply = new Dianda.BLL.Cash_Apply();
        BLL.Project_Projects bProject = new Dianda.BLL.Project_Projects();
        Model.Project_Projects mProject = new Dianda.Model.Project_Projects();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// 外部接入
        /// </summary>
        /// <param name="projectid"></param>
        public void showlist(string projectid)
        {
            try
            {
                HiddenField_projectid.Value = projectid;
                BindData("1");
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据条件构建数据
        /// </summary>
        /// <param name="groupname"></param>
        protected void BindData(string status)
        {
            try
            {
                ddlStatas.SelectedValue = status;
                string projectid = common.RequestSafeString(HiddenField_projectid.Value.ToString(), 50) ;
                string strSQL = "SELECT * FROM vCash_Apply WHERE projectid='" + projectid + "' and statas='" + status + "'  order by getdatetime desc";
                DataTable dt = new DataTable();
                dt = pageControl.doSql(strSQL).Tables[0];
                HiddenField_totals.Value = "0";

                mProject = bProject.GetModel(int.Parse(projectid));

                if (dt.Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";
                    tag.Text ="总计:&nbsp;" + HiddenField_totals.Value.ToString() + "&nbsp;元";
                    Label_tongji.Text = mProject.NAMES.ToString() + "&nbsp;的预计经费为:&nbsp;" + mProject.CashTotal.ToString() + "元<br/>共&nbsp;" + dt.Rows.Count.ToString() + "&nbsp;条记录！<br/>总计&nbsp;" + HiddenField_totals.Value.ToString() + "&nbsp;元";
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
                    tag.Text = "";
                    Label_tongji.Text = "暂无统计信息！";
                }
            }
            catch
            {
                tag.Text = "";
                Label_tongji.Text = "暂无统计信息！";
            }
        }
     /// <summary>
     /// 状态的筛选
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
        protected void ddlStatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(ddlStatas.SelectedValue.ToString());//调用显示
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
                    string Statas = DataBinder.Eval(e.Row.DataItem, "Statas").ToString();
                    string strApplyCount = DataBinder.Eval(e.Row.DataItem, "ApplyCount").ToString();
                    long longApplyCount = long.Parse(strApplyCount);
                    string totals = HiddenField_totals.Value.ToString();
                    long totalsdouble = long.Parse(totals);
                    totalsdouble += longApplyCount;
                    HiddenField_totals.Value = totalsdouble.ToString();
                    e.Row.Cells[1].Text = "<a href=\"javascript:window.showModalDialog('/Admin/personalProjectManage/OACashApply/showCashApply.aspx?id=" + ID + "','','dialogWidth=715px;dialogHeight=250px');\" title='查看详细'>" + strApplyCount.ToString() + "</a>";
                    if (Statas == "0")
                    {
                        e.Row.Cells[4].Text = "待审核";
                    }
                    else if (Statas == "1")
                    {
                        e.Row.Cells[4].Text = "审核通过";
                    }
                    else if (Statas == "2")
                    {
                        e.Row.Cells[4].Text = "<font color='red'>审核不通过</font>";
                    }
                }
            }
            catch
            {
            }
        }
    }
}
