using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Dianda.Web.Admin
{
    public partial class ucFaceShowMessage : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_Apply mCash_Apply = new Dianda.Model.Cash_Apply();
        BLL.Cash_Apply bCash_Apply = new Dianda.BLL.Cash_Apply();
        BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();
        Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();


        Model.userPower mUserPower = new Dianda.Model.userPower();//用户的权限实体类
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                Session["NewsType"] = "1";
                reSetLinkbutton();
                ((LinkButton)this.FindControl("LinkButton1")).CssClass = "ProjectPanal_4";
                string condition = getCondition();
                this.ViewState["Condition"] = condition;
                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    setRowCout(condition);//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    count = dtrowsHidden.Value.ToString();
                }
                else
                {
                    count = "0";
                }
                if (count == "")
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
                BindData(pageindex_int, condition);
                showlinkbutton(condition);
                show1.Visible = false;
                txtBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                txtEndTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                //if (Session["NewsType"].ToString() == "789" || Session["NewsType"].ToString() == "6")
                if (Session["NewsType"].ToString()!="2")//只有当“审批提醒”才不显示整理历史消息
                {
                   // Button_delete.Visible = true;
                    Button2.Visible = true;
                }
                else
                {
                   // Button_delete.Visible = false;
                    Button2.Visible = false;
                }
               // Button_delete.Enabled = false;
            }
        }

        #region 获取条件
        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string getCondition()
        {
            //付全文    2013-4-16   新增消息权限
            Model.userPower userPower = Session["Session_Power"] as Model.userPower;
            List<string> strList = new List<string>();
            foreach (string str in userPower.menuRole.Split(';'))
            {
                strList.Add(str);
            }
            string role = Session["Session_Role"].ToString();
            string condition = "";
            if (bIsExistString(role, strList))
            {
                condition = "通知公告";
            }
            return condition;
        } 
        #endregion

        private void showlinkbutton(string condition)
        {
            
            string l1 = countnums(LinkButton1, "1", condition);
            string l2 = countnums(LinkButton2, "2", condition);
            string l3 = countnums(LinkButton3, "3", condition);
            string l4 = countnums(LinkButton4, "4", condition);
            string l5 = countnums(LinkButton5, "5", condition);
            string l6 = countnums(LinkButton6, "6", condition);
            string l7 = countnums(LinkButton7, "789", condition);
           // string l10 = countnums(LinkButton10, "10");
            string colors = "blue";
            l1 = l1 == "0" ? "" : "<font color='" + colors + "'>[" + l1 + "]</font>";
            l2 = l2 == "0" ? "" : "<font color='" + colors + "'>[" + l2 + "]</font>";
            l3 = l3 == "0" ? "" : "<font color='" + colors + "'>[" + l3 + "]</font>";
            l4 = l4 == "0" ? "" : "<font color='" + colors + "'>[" + l4 + "]</font>";
            l5 = l5 == "0" ? "" : "<font color='" + colors + "'>[" + l5 + "]</font>";
            l6 = l6 == "0" ? "" : "<font color='" + colors + "'>[" + l6 + "]</font>";
            l7 = l7 == "0" ? "" : "<font color='" + colors + "'>[" + l7 + "]</font>";
           // l10 = l10 == "0" ? "" : "<font color='" + colors + "'>[" + l10 + "]</font>";

            LinkButton1.Text = "全部"+l1;
            LinkButton2.Text = "审批提醒" + l2;
            LinkButton3.Text = "项目任务" + l3;
            LinkButton4.Text = "共享文档" + l4;
            LinkButton5.Text = "申请反馈" + l5;
            LinkButton6.Text = "通知公告" + l6;
            LinkButton7.Text = "我的消息" + l7;
           // LinkButton10.Text = "历史消息" + l10;
        }
        /// <summary>
        /// 显示出当前各个按钮的数据条数
        /// </summary>
        /// <returns></returns>
        private string countnums(LinkButton lib,string types, string condition)
        {
            string coutw = "";
            try
            {
                string sqlwhere = SQLCondition_tag2(types, "0", condition);
                string strSQL = "SELECT count(ID) as nums FROM FaceShowMessage WHERE " + sqlwhere;
                DataTable dt = new DataTable();
                dt = pageControl.doSql(strSQL).Tables[0];

                if (dt.Rows.Count > 0)
                {
                  coutw= dt.Rows[0]["nums"].ToString();
                }
                else
                {
                    coutw = dtrowsHidden.Value.ToString();
                }
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 重置按钮的样式
        /// </summary>
        private void reSetLinkbutton()
        {
            try
            {
                this.LinkButton1.CssClass = "ProjectPanal_3";
                this.LinkButton2.CssClass = "ProjectPanal_3";
                this.LinkButton3.CssClass = "ProjectPanal_3";
                this.LinkButton4.CssClass = "ProjectPanal_3";
                this.LinkButton5.CssClass = "ProjectPanal_3";
                this.LinkButton6.CssClass = "ProjectPanal_3";
                this.LinkButton7.CssClass = "ProjectPanal_3";
               // this.LinkButton8.CssClass = "ProjectPanal_3";
               // this.LinkButton9.CssClass = "ProjectPanal_3";
               // this.LinkButton10.CssClass = "ProjectPanal_3";

            }
            catch
            {
            }
        }

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout(string condition)
        {
            try
            {
                string strSQL = "SELECT ID FROM FaceShowMessage WHERE " + SQLCondition(condition);
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
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        protected void BindData(int pageindex, string condition)
        {
            try
            {
                //1-全部、2-审批提醒、3-项目任务、4-共享文档、5-申请反馈、
                //6-通知公告、7-个人消息、8-项目消息、9-部门消息、10-历史消息
                //string strSQL = "SELECT * FROM vNews_News WHERE " + SQLCondition();
                DataTable dt = new DataTable();
                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                dt = pageControl.GetList_FenYe_Common(SQLCondition(condition), pageindex, GridView1.PageSize, alltiaoshuInt, "FaceShowMessage", "ID").Tables[0];
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
                        BindData(pageindex - 1, condition);
                    }
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
        protected string SQLCondition(string condition)
        {
            //1-全部、2-审批提醒、3-项目任务、4-共享文档、5-申请反馈、
            //6-通知公告、7-个人消息、8-项目消息、9-部门消息、10-历史消息
            
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 ");
            string strNewsType = Session["NewsType"].ToString();
            return SQLCondition_tag(strNewsType, condition);
        }

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition_tag(string types, string condition)
        {
            //1-全部、2-审批提醒、3-项目任务、4-共享文档、5-申请反馈、
            //6-通知公告、7-个人消息、8-项目消息、9-部门消息、10-历史消息

            //放入回收站
            //Image del_image = (Image)GridView1.Rows[].Cells[].FindControl("del_image");
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 ");
            string strNewsType = types;
            if (strNewsType == "1")
            {
                //1-全部
                sbSql.Append(" ");
                mUserPower = (Model.userPower)Session["Session_Power"];
                if (mUserPower.specialRole.Contains("or"))
                {
                    sbSql.Append(" and  (" + mUserPower.specialRole.ToString() + " or Receive='" + ((Model.USER_Users)Session["USER_Users"]).ID + "') ");
                }
                else
                {
                    sbSql.Append(" AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
                }
               // searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "2")
            {
                //2-审批提醒
                mUserPower = (Model.userPower)Session["Session_Power"];
                if (mUserPower.specialRole.Contains("or"))
                {
                    sbSql.Append(" and " + mUserPower.specialRole.ToString() + "");
                }
                else
                {
                    sbSql.Append(" and IsRead='3'");
                }
                //searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "3")
            {
                //3-项目任务
                sbSql.Append("and NewsType='项目任务' AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
               // searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "4")
            {
                //4-共享文档
                sbSql.Append(" and  NewsType='共享文档' AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
               // searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "5")
            {
                //5-申请反馈、
                sbSql.Append(" and (NewsType='申请情况' or NewsType='项目审核' or NewsType='经费预约反馈')  AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
              //  searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "6")
            {
                //6-通知公告、
                sbSql.Append("and NewsType='通知公告' AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
               // searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "789")
            {
                //7-个人消息、
                sbSql.Append(" and (NewsType='个人消息' or  NewsType='项目消息' or  NewsType='部门消息') AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
              //  searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "10")
            {
                //10-历史消息、
                sbSql.Append(" ");
                mUserPower = (Model.userPower)Session["Session_Power"];
                if (Session["starttime_session"] == null)//没有搜索条件时
                {
                    if (mUserPower.specialRole.Contains("or"))
                    {
                        sbSql.Append(" and  (" + mUserPower.specialRole.ToString() + " or Receive='" + ((Model.USER_Users)Session["USER_Users"]).ID + "') ");
                    }
                    else
                    {
                        sbSql.Append(" AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
                    }
                }
                //else//有搜索条件时
                //{
                //    DateTime starttimes = DateTime.Parse(Session["starttime_session"].ToString());
                //    DateTime endtimes = DateTime.Parse(Session["endtime_session"].ToString()).AddDays(1);
                //    if (mUserPower.specialRole.Contains("or"))
                //    {
                //        sbSql.Append(" and  (" + mUserPower.specialRole.ToString() + " or Receive='" + ((Model.USER_Users)Session["USER_Users"]).ID + "')  and DATETIME>='" + starttimes + "' and DATETIME<='" + endtimes + "'");
                //    }
                //    else
                //    {
                //        sbSql.Append(" AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'  and DATETIME>='" + starttimes + "' and DATETIME<='" + endtimes + "'");
                //    }
                //}

              
            }
            if (Session["starttime_session"] != null && DropDownList1.SelectedValue != "time")//有搜索条件时
            {
                DateTime starttimes = DateTime.Parse(Session["starttime_session"].ToString());
                DateTime endtimes = DateTime.Parse(Session["endtime_session"].ToString()).AddDays(1);
                COMMON.common com = new Dianda.COMMON.common();

                sbSql.Append("and DATETIME>='" + starttimes + "' and DATETIME<='" + endtimes + "'" + "and URLS like '%" + com.SafeString(Keyword.Text) + "%'");
                sbSql.Append("and DELFLAG=1");//现在搜索的都是放入回收站的消息
            }
            else
            {
                sbSql.Append("and DELFLAG=0");
            }
            if (!string.IsNullOrEmpty(condition))
            {
                sbSql.Append(" and NewsType <> '" + condition + "'");
            }
            return sbSql.ToString();
        }

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition_tag2(string types,string isread, string condition)
        {
            //1-全部、2-审批提醒、3-项目任务、4-共享文档、5-申请反馈、
            //6-通知公告、7-个人消息、8-项目消息、9-部门消息、10-历史消息

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 ");
            string strNewsType = types;
            if (strNewsType == "1")
            {
                //1-全部
                sbSql.Append(" ");
                mUserPower = (Model.userPower)Session["Session_Power"];
                if (mUserPower.specialRole.Contains("or"))
                {
                    sbSql.Append(" and  (" + mUserPower.specialRole.ToString() + " or Receive='" + ((Model.USER_Users)Session["USER_Users"]).ID + "') ");
                }
                else
                {
                    sbSql.Append(" AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
                }
                // searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "2")
            {
                //2-审批提醒
                mUserPower = (Model.userPower)Session["Session_Power"];
                if (mUserPower.specialRole.Contains("or"))
                {
                    sbSql.Append(" and " + mUserPower.specialRole.ToString() + "");
                }
                else
                {
                    sbSql.Append(" and IsRead='3'");
                }
                //searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "3")
            {
                //3-项目任务
                sbSql.Append("and NewsType='项目任务' AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
                // searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "4")
            {
                //4-共享文档
                sbSql.Append(" and  NewsType='共享文档'  AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
                // searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "5")
            {
                //5-申请反馈、
                sbSql.Append(" and (NewsType='申请情况' or NewsType='项目审核' or NewsType='经费预约反馈') AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
                //  searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "6")
            {
                //6-通知公告、
                sbSql.Append("and NewsType='通知公告' AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
                // searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "789")
            {
                //7-个人消息、
                sbSql.Append(" and (NewsType='个人消息' or  NewsType='项目消息' or  NewsType='部门消息') AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
                //  searchrtable.Visible = false;//搜索的功能不显示
            }
            if (strNewsType == "10")
            {
                //10-历史消息、
                sbSql.Append(" ");
                mUserPower = (Model.userPower)Session["Session_Power"];
                if (Session["starttime_session"] == null)//没有搜索条件时
                {
                    if (mUserPower.specialRole.Contains("or"))
                    {
                        sbSql.Append(" and  (" + mUserPower.specialRole.ToString() + " or Receive='" + ((Model.USER_Users)Session["USER_Users"]).ID + "') ");
                    }
                    else
                    {
                        sbSql.Append(" AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'");
                    }
                }
                //else//有搜索条件时
                //{
                //    DateTime starttimes = DateTime.Parse(Session["starttime_session"].ToString());
                //    DateTime endtimes = DateTime.Parse(Session["endtime_session"].ToString()).AddDays(1);
                //    if (mUserPower.specialRole.Contains("or"))
                //    {
                //        sbSql.Append(" and  (" + mUserPower.specialRole.ToString() + " or Receive='" + ((Model.USER_Users)Session["USER_Users"]).ID + "')  and DATETIME>='" + starttimes + "' and DATETIME<='" + endtimes + "'");
                //    }
                //    else
                //    {
                //        sbSql.Append(" AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'  and DATETIME>='" + starttimes + "' and DATETIME<='" + endtimes + "'");
                //    }
                //}


            }

            if (isread == "0")
            {
                sbSql.Append("and isread='0'");
            }

            if (Session["starttime_session"] != null && DropDownList1.SelectedValue != "time")//有搜索条件时
            {
                DateTime starttimes = DateTime.Parse(Session["starttime_session"].ToString());
                DateTime endtimes = DateTime.Parse(Session["endtime_session"].ToString()).AddDays(1);
                sbSql.Append("and DATETIME>='" + starttimes + "' and DATETIME<='" + endtimes + "'" + "and URLS like '%" + Keyword.Text + "%'");
                sbSql.Append("and DELFLAG=1");
            }
            else
            {
                sbSql.Append("and DELFLAG=0");
            }
            if (!string.IsNullOrEmpty(condition))
            {
                sbSql.Append(" and NewsType <> '" + condition + "'");
            }
            return sbSql.ToString();
        }

        #region 付全文    2013-4-16   是否存在字符串
        /// <summary>
        /// 是否存在字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        private bool bIsExistString(string subStr, List<string> strList)
        {
            bool bIs = false;
            foreach (string str in strList)
            {
                if (str == subStr)
                {
                    bIs = true;
                    break;
                }
            }
            return bIs;
        } 
        #endregion

        /// <summary>
        /// 当分页控件中的“第一页”“第二页”...发生时，触发下面的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageChange_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
            pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值
            setRowCout(this.ViewState["Condition"].ToString());
            BindData(page, this.ViewState["Condition"].ToString());//调用显示

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
            setRowCout(this.ViewState["Condition"].ToString());
            BindData(page, this.ViewState["Condition"].ToString());//调用显示

        }

        /// <summary>
        ///点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        ///点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_onclick(object sender, EventArgs e)
        {
            if (txtBeginDate.Value.ToString().Length > 0 && txtEndTime.Value.ToString().Length > 0)
            {
                pageControlShow.Visible = true;
                Session["starttime_session"] = txtBeginDate.Value.ToString();
                Session["endtime_session"] = txtEndTime.Value.ToString();
                setRowCout(this.ViewState["Condition"].ToString());
                BindData(1, this.ViewState["Condition"].ToString());
                tag.Text = "";
               // Button_delete.Enabled = true;
                showlinkbutton(this.ViewState["Condition"].ToString());
            }
            else
            {
                tag.Text = "*请选中您要搜索的时间范围！";
            }
        }

        /// <summary>
        /// 点击删除按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_delete_onclick(object sender, EventArgs e)
        {
            try
            {
                string strNewsType = Session["NewsType"].ToString();
                string strSQL = "Update FaceShowMessage set DELFLAG=1 WHERE 1=1 ";
                if (Session["starttime_session"] != null && DropDownList1.SelectedValue != "time")//有搜索条件时
                {
                    DateTime starttimes = DateTime.Parse(Session["starttime_session"].ToString());
                    DateTime endtimes = DateTime.Parse(Session["endtime_session"].ToString()).AddDays(1);
                    strSQL=strSQL+"and DATETIME>='" + starttimes + "' and DATETIME<='" + endtimes + "'" + "and URLS like '%" + Keyword.Text + "%'";

                }               
                if (strNewsType == "6")
                {
                    //6-通知公告、
                    strSQL=strSQL+"and NewsType='通知公告' AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'";
                    // searchrtable.Visible = false;//搜索的功能不显示
                }
                if (strNewsType == "789")
                {
                    //7-个人消息、
                    strSQL = strSQL + " and (NewsType='个人消息' or  NewsType='项目消息' or  NewsType='部门消息') AND Receive ='" + ((Model.USER_Users)Session["USER_Users"]).ID + "'";
                    //  searchrtable.Visible = false;//搜索的功能不显示
                }

                pageControl.doSql(strSQL);
                setRowCout(this.ViewState["Condition"].ToString());
                BindData(1, this.ViewState["Condition"].ToString());
                notice.Text = "*删除成功！";

                /*添加操作日志*/
                Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", "删除动态信息", "删除成功");
                /*添加操作日志*/
            }
            catch (Exception)
            {

                throw;
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
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    e.Row.Attributes["OnClick"] = "doTypeChange('faceshowDo.aspx?ID=" + ID + "')";//调用处理已读的方法
                    string URLS = DataBinder.Eval(e.Row.DataItem, "URLS").ToString();
                    string DATETIME = DataBinder.Eval(e.Row.DataItem, "DATETIME").ToString();
                    string NewsType = DataBinder.Eval(e.Row.DataItem, "NewsType").ToString();
                    //string Statas = DataBinder.Eval(e.Row.DataItem, "Statas").ToString();

                    Label lblURLS = (Label)e.Row.FindControl("lblURLS");
                    Label lblDATETIME = (Label)e.Row.FindControl("lblDATETIME");
                    //if (NewsType == "个人消息" || NewsType== "项目消息" || NewsType== "部门消息")//(NewsType='个人消息' or  NewsType='项目消息' or  NewsType='部门消息')
                    //{
                    //    URLS = "[" + NewsType + "]" + URLS;
                    //}

                    lblURLS.Text =URLS;
                    lblDATETIME.Text = "(" + Convert.ToDateTime(DATETIME).ToString("yyyy-MM-dd") + ")";

                    //放入回收站
                    ImageButton imagebutton_del = (ImageButton)e.Row.FindControl("ImageButton_del");

                    if (Session["NewsType"].ToString().Equals("2") || Session["starttime_session"] != null)//表示是审批提醒
                    {
                        imagebutton_del.Visible = false;
                    }
                    else
                    {
                        imagebutton_del.CommandArgument = e.Row.RowIndex.ToString() + "|" + ID;
                    }

                    
                  
                }
            }
            catch
            {
            }
        }

        //protected void ddlNewsType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    setRowCout();
        //    BindData(1);
        //}
        /// <summary>
        /// 审批提醒的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
              
                string types = ((LinkButton)sender).CommandArgument.ToString();//获取要操作的类型
                reSetLinkbutton();//重置按钮的样式
                ((LinkButton)sender).CssClass = "ProjectPanal_4";
                Session["NewsType"] = types;
                Session["starttime_session"] = null;
                show1.Visible = false;
                Keyword.Text = "";
                txtBeginDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                txtEndTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
                DropDownList1.SelectedValue = "time";
                showlinkbutton(this.ViewState["Condition"].ToString());
                setRowCout(this.ViewState["Condition"].ToString());
                BindData(1, this.ViewState["Condition"].ToString());
                huishou_buttonReset();
                //if (types == "789" || types == "6")
                if (!(types.Equals("2")))//只有审批提醒时不显示“历史记录”钮
                {
                    //Button_delete.Visible = true;
                    Button2.Visible = true;
                }
                else
                {
                    //Button_delete.Visible = false;
                    Button2.Visible = false;
                }
                //Button_delete.Enabled =false;
            }
            catch
            { }
        }
        //排序方式改变
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "time")
            {
                pageControlShow.Visible = false;
                show1.Visible = true;
                if (Button2.Text == "查看回收站")
                {
                    Button2.Text = "返回列表";
                }

                GridView1.DataSource = null;
                GridView1.DataBind();

            }
            else
            {

                Button2.Text = "查看回收站";
                Session["starttime_session"] = null;
                show1.Visible = false;
                setRowCout(this.ViewState["Condition"].ToString());
                BindData(1, this.ViewState["Condition"].ToString());

                showlinkbutton(this.ViewState["Condition"].ToString());
            }
        }

        /// <summary>
        ///重置搜索按钮的状态
        /// </summary>
        private void huishou_buttonReset()
        {
            try
            {

                if (Button2.Text == "返回列表")
                {
                    Button2.Text = "查看回收站";
                    
                }
               
            }
            catch
            {
            }
        }
        //查看整理历史消息
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                pageControlShow.Visible = false;
                Button bt2 = (Button)sender;
                if (bt2.Text == "查看回收站")
                {
                    bt2.Text = "返回列表";
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                else
                {
                    bt2.Text = "查看回收站";
                    Session["starttime_session"] = null;

                    setRowCout(this.ViewState["Condition"].ToString());
                    BindData(1, this.ViewState["Condition"].ToString());

                    showlinkbutton(this.ViewState["Condition"].ToString());
                }
                if (DropDownList1.SelectedValue != "time")
                {
                    DropDownList1.SelectedValue = "time";
                }
                else
                {
                    DropDownList1.SelectedValue = "select1";
                }
                if (show1.Visible == false)
                {
                    show1.Visible = true;
                }
                else
                {
                    show1.Visible = false;
                }
              
            }
            catch
            {
            }
        }


        /// <summary>
        /// 放入回收站的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton_del_Click(object sender, EventArgs e)
        {
            try
            {
                string indexid = ((ImageButton)sender).CommandArgument.ToString();

                //行号
                int index = int.Parse(indexid.Split('|')[0].ToString());
                //每行记录的ID
                string id = indexid.Split('|')[1].ToString();

                mFaceShowMessage = bFaceShowMessage.GetModel(int.Parse(id));

                //将删除标记改成1
                mFaceShowMessage.DELFLAG = 1;

                bFaceShowMessage.Update(mFaceShowMessage);

                //GridView1.Rows[index].Visible = false;

                setRowCout(this.ViewState["Condition"].ToString());
                BindData(1, this.ViewState["Condition"].ToString());

                showlinkbutton(this.ViewState["Condition"].ToString());

            }
            catch
            {
 
            }
        }
        
    }
}