using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Dianda.Web.Admin
{
    public partial class ucProjectHot : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.News_News mNews_News = new Dianda.Model.News_News();
        BLL.News_News bNews_News = new Dianda.BLL.News_News();
        Model.USER_Users modelUser = new Dianda.Model.USER_Users();//T
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string objName = "信息发布";
                //LB_name.Text = objName;

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
                if (pageindex == null || pageindex == "")
                {
                    pageindex = "1";
                }
                int pageindex_int = int.Parse(pageindex);
                BindData(pageindex_int);
            }
        }

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout()
        {
            try
            {
                string strSQL = "SELECT ID FROM vNews_News1 WHERE " + SQLCondition();
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
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition()
        {
            try
            {
                modelUser = (Model.USER_Users)Session["USER_Users"];
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append(" 1=1 ");
                sbSql.Append(" AND ForItems ='DEPARTMENT' and ItemsID='" + modelUser.TEMP4.ToString() + "'");

                return sbSql.ToString();
            }
            catch
            {
                return "1=2";
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
                DataTable dt = new DataTable();
                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                dt = pageControl.GetList_FenYe_Common(SQLCondition(), pageindex, GridView1.PageSize, alltiaoshuInt, "vNews_News1", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (dt.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    GridView1.Visible = false;
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
                    //e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    //HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    string NAME = DataBinder.Eval(e.Row.DataItem, "NAME").ToString();
                    string PARENTNAME = DataBinder.Eval(e.Row.DataItem, "PARENTNAME").ToString();
                    string DATETIME = DataBinder.Eval(e.Row.DataItem, "DATETIME").ToString();
                    //string Statas = DataBinder.Eval(e.Row.DataItem, "Statas").ToString();

                    Label lblURLS = (Label)e.Row.FindControl("lblURLS");
                    Label lblDATETIME = (Label)e.Row.FindControl("lblDATETIME");

                    lblURLS.Text = "<a href=\"javascript:window.showModalDialog('/Admin/newsManage/OAnews/show.aspx?id=" + ID + "','','dialogWidth=715px;dialogHeight=250px');\"  title='查看详细'>" + "[" + PARENTNAME + "] " + NAME + "</a>";
                    //lblURLS.Text = "[" + PARENTNAME + "] " + NAME;
                    lblDATETIME.Text = "(" + Convert.ToDateTime(DATETIME).ToString("yyyy-MM-dd HH:mm:ss") + ")";
                    //// string CONTENTS = DataBinder.Eval(e.Row.DataItem, "CONTENTS").ToString();
                    //string NAME = DataBinder.Eval(e.Row.DataItem, "NAME").ToString();
                    //string IsRead = DataBinder.Eval(e.Row.DataItem, "IsRead").ToString();
                    //hid.Value = ID;
                    ////e.Row.Cells[3].Text = CONTENTS;
                    //e.Row.Cells[2].Text = "<a href='showHistory.aspx?id=" + ID + "' title='操作记录查看' target='_self' rel='gb_page_center[726,400]''>" + CardName + "</a>";
                    //if (Statas == "0")
                    //{
                    //    e.Row.Cells[9].Text = "待审核";
                    //}
                    //else if (Statas == "1")
                    //{
                    //    e.Row.Cells[9].Text = "审核通过";
                    //}
                    //else if (Statas == "2")
                    //{
                    //    e.Row.Cells[9].Text = "审核不通过";
                    //}
                }
            }
            catch
            {
            }
        }
    }
}