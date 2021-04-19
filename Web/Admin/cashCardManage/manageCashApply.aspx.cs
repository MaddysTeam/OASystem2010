using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class manageCashApply : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_Apply mCash_Apply = new Dianda.Model.Cash_Apply();
        BLL.Cash_Apply bCash_Apply = new Dianda.BLL.Cash_Apply();

        const string SkipPage = "/Admin/personalProjectManage/OACashApply/add.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string objName = "信息发布";
                //LB_name.Text = objName;

                //显示日期筛选条件
                ShowList();

                //项目ID
                GetddlStatas();

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
                pageindex = Request["pageindex"];
                if (pageindex == null || pageindex == "")
                {
                    pageindex = "1";
                }
                int pageindex_int = int.Parse(pageindex);
                BindData(pageindex_int);

                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 财务管理 ";
                /*设置模板页中的管理值*/
            }
        }

        protected void GetddlStatas()
        {
            ListItem li = new ListItem("全部", "");
            this.ddlStatas.Items.Add(li);
            li = new ListItem("新预约", "0");
            this.ddlStatas.Items.Add(li);
            li = new ListItem("历史预约", "1");
            this.ddlStatas.Items.Add(li);

            if (Request.Params["status"] != null && !String.IsNullOrEmpty(Request["status"]))
            {
                this.ddlStatas.SelectedValue = Request["status"];
            }
        }

        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout()
        {
            try
            {
                string strSQL = "SELECT ID FROM vCash_Apply2 WHERE " + SQLCondition();
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
        protected void BindData(int pageindex)
        {
            try
            {
                //string strSQL = "SELECT * FROM vNews_News WHERE " + SQLCondition();
                DataTable dt = new DataTable();
                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                dt = pageControl.GetList_FenYe_Common(SQLCondition(), pageindex, GridView1.PageSize, alltiaoshuInt, "vCash_Apply2", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (dt.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    Button_sumbit.Enabled = true;
                    Button_Complete.Enabled = true;
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                    //设置选中日期的合计金额
                    DataTable dt2 = new DataTable();
                    dt2 = pageControl.doSql("select*from vCash_Apply2 where " + SQLCondition()).Tables[0];
                    float daishenhe = 0;
                    float tongguo = 0;
                    float weitongguo = 0;
                    float wancheng = 0;
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        int staue = int.Parse(dt2.Rows[i]["Statas"].ToString());
                        switch (staue)
                        {
                            //待审核金额
                            case 0:
                                daishenhe += float.Parse(dt2.Rows[i]["ApplyCount"].ToString());
                                break;
                            //审核通过金额
                            case 1:
                                tongguo += float.Parse(dt2.Rows[i]["ApplyCount"].ToString());
                                break;
                            //审核未通过金额
                            case 2:
                                weitongguo += float.Parse(dt2.Rows[i]["ApplyCount"].ToString());
                                break;
                            //审核完成金额
                            case 3:
                                wancheng += float.Parse(dt2.Rows[i]["ApplyCount"].ToString());
                                break;
                        }

                    }
                    Label_money1.Text = daishenhe.ToString();
                    Label_money2.Text = tongguo.ToString();
                    Label_money3.Text = weitongguo.ToString();
                    Label_money4.Text = wancheng.ToString();
                }
                else
                {
                    Button_sumbit.Enabled = false;
                    Button_Complete.Enabled = false;
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
                    Label_money1.Text = "0";
                    Label_money2.Text = "0";
                    Label_money3.Text = "0";
                    Label_money4.Text = "0";

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
                        RadioButton cb = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("RBtn_choose");
                        if (cb.Enabled == true)
                        {
                            cb.Checked = isCheck;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        ///// <summary>
        ///// 点击资金卡金额调整钮触发的事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void Button_LimitNums_onclick(object sender, EventArgs e)
        //{
        //    //选择编辑的条数只能为一条
        //    int num = 0;
        //    int rows = GridView1.Rows.Count;
        //    if (rows > 0)
        //    {
        //        for (int i = 0; i < rows; i++)
        //        {
        //            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
        //            if (cb.Checked)
        //            {
        //                num = num + 1;
        //            }
        //        }

        //        if (num == 0)
        //        {
        //            tag.Text = "请选择一条数据进行编辑！";

        //        }
        //        else if (num > 1)
        //        {
        //            tag.Text = "编辑时最多只能选择一条数据！";
        //        }
        //        else
        //        {
        //            tag.Text = "";
        //            for (int j = 0; j < rows; j++)
        //            {
        //                CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
        //                // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
        //                string id = GridView1.DataKeys[j]["ID"].ToString();
        //                //string ForItems = GridView1.DataKeys[j]["ForItems"].ToString();
        //                //string PARENTID = GridView1.DataKeys[j]["PARENTID"].ToString();
        //                //string LimitsChooseID = GridView1.DataKeys[j]["LimitsChooseID"].ToString();

        //                if (cb1.Checked)
        //                {
        //                    Response.Redirect("addHistory.aspx?id=" + id);
        //                    // this.H_ModifyID.Value = hid.Value;
        //                    //BindModifyData(hid.Value);
        //                    //this.div2.Visible = true;
        //                }
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 点击编辑按钮触发的事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void Button_modify_onclick(object sender, EventArgs e)
        //{
        //    //选择编辑的条数只能为一条
        //    int num = 0;
        //    int rows = GridView1.Rows.Count;
        //    if (rows > 0)
        //    {
        //        for (int i = 0; i < rows; i++)
        //        {
        //            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
        //            if (cb.Checked)
        //            {
        //                num = num + 1;
        //            }
        //        }

        //        if (num == 0)
        //        {
        //            tag.Text = "请选择一条数据进行编辑！";

        //        }
        //        else if (num > 1)
        //        {
        //            tag.Text = "编辑时最多只能选择一条数据！";
        //        }
        //        else
        //        {
        //            tag.Text = "";
        //            for (int j = 0; j < rows; j++)
        //            {
        //                CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
        //                // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
        //                string id = GridView1.DataKeys[j]["ID"].ToString();
        //                //string ForItems = GridView1.DataKeys[j]["ForItems"].ToString();
        //                //string PARENTID = GridView1.DataKeys[j]["PARENTID"].ToString();
        //                //string LimitsChooseID = GridView1.DataKeys[j]["LimitsChooseID"].ToString();

        //                if (cb1.Checked)
        //                {
        //                    Response.Redirect("modify.aspx?id=" + id);
        //                    // this.H_ModifyID.Value = hid.Value;
        //                    //BindModifyData(hid.Value);
        //                    //this.div2.Visible = true;
        //                }
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 点击删除按钮触发的事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void Button_delete_onclick(object sender, EventArgs e)
        //{
        //    int num = 0;
        //    int rows = GridView1.Rows.Count;
        //    if (rows > 0)
        //    {
        //        for (int i = 0; i < rows; i++)
        //        {
        //            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
        //            if (cb.Checked)
        //            {
        //                num = num + 1;
        //            }
        //        }

        //        if (num == 0)
        //        {
        //            tag.Text = "注销时最少选择一条数据！";

        //        }
        //        else
        //        {
        //            tag.Text = "";
        //            for (int j = 0; j < rows; j++)
        //            {
        //                CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
        //                // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
        //                string id = GridView1.DataKeys[j]["ID"].ToString();
        //                if (cb1.Checked)
        //                {
        //                    mCash_Cards = new Dianda.Model.Cash_Cards();
        //                    mCash_Cards = bCash_Cards.GetModel(Int32.Parse(id));
        //                    mCash_Cards.Statas = 0;
        //                    bCash_Cards.Update(mCash_Cards);

        //                    tag.Text = "操作成功！";
        //                    // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";
        //                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx\";</script>";
        //                    Response.Write(coutws);

        //                    // 添加操作日志
        //                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
        //                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
        //                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "注销资金卡" + mCash_Cards.CardNum /*Request["tags"].ToString()*/, "注销资金卡成功");
        //                }
        //            }
        //        }
        //    }
        //}

        /// <summary>
        ///点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_onclick(object sender, EventArgs e)
        {
            //选择编辑的条数只能为一条
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
                    tag.Text = "请选择要操作的纪录！";

                }
                else
                {
                    tag.Text = "";
                    string info = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
                        string id = GridView1.DataKeys[j]["ID"].ToString();
                        string ApplierRealName = GridView1.DataKeys[j]["ApplierRealName"].ToString();
                        string GetDateTime = GridView1.DataKeys[j]["GetDateTime"].ToString();
                        string ApplyCount = GridView1.DataKeys[j]["ApplyCount"].ToString();

                        if (cb1.Checked)
                        {
                            mCash_Apply = new Dianda.Model.Cash_Apply();
                            mCash_Apply = bCash_Apply.GetModel(Int32.Parse(id));
                            mCash_Apply.Statas = 1;
                            mCash_Apply.DoUserID = ((Model.USER_Users)Session["USER_Users"]).ID;
                            bCash_Apply.Update(mCash_Apply);
                            info += ("(" + ApplierRealName + "申请额度" + ApplyCount + "在" + GetDateTime + ")");
                            tag.Text = "操作成功！";
                            // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";

                            Model.Cash_Cards mCash_Cards = new Dianda.Model.Cash_Cards();
                            BLL.Cash_Cards bCash_Cards = new Dianda.BLL.Cash_Cards();
                            mCash_Cards = bCash_Cards.GetModel(Int32.Parse(mCash_Apply.CashCertificateID.ToString()));

                            /*给业务申请者发信息*/
                            Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                            BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

                            mFaceShowMessage.DATETIME = DateTime.Now;
                            mFaceShowMessage.FromTable = "申请情况";
                            mFaceShowMessage.IsRead = 0;
                            mFaceShowMessage.NewsID = null;
                            mFaceShowMessage.NewsType = "申请情况";
                            mFaceShowMessage.ReadTime = null;
                            mFaceShowMessage.Receive = mCash_Apply.ApplierID;
                            mFaceShowMessage.ProjectID = mCash_Apply.ProjectID;
                            mFaceShowMessage.DELFLAG = 0;
                            mFaceShowMessage.URLS = "<a href='/Admin/cashCardManage/manageCashApplyPerson.aspx' target='_self' title='经费预约：提交时间" + DateTime.Now + "'>" + mCash_Cards.CardName + "的经费预约 审核通过 </a>  (" + ((Model.USER_Users)Session["USER_Users"]).REALNAME + ")";
                            bFaceShowMessage.Add(mFaceShowMessage);
                            /*给业务申请者发信息*/

                        }
                    }

                    // 添加操作日志
                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "审核经费预约", "审核预约" + info + "通过：成功");

                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manageCashApply.aspx?pageindex=" + pageindexHidden.Value + "&date=" + DDList_RQ.SelectedValue + "&status=" + this.ddlStatas.SelectedValue + "\";</script>";
                    Response.Write(coutws);
                }
            }
        }

        /// <summary>
        /// 点击重置按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_onclick(object sender, EventArgs e)
        {
            //选择编辑的条数只能为一条
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
                    tag.Text = "请选择要操作的纪录！";

                }
                else
                {
                    tag.Text = "";
                    string info = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        // HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");
                        string id = GridView1.DataKeys[j]["ID"].ToString();
                        string ApplierRealName = GridView1.DataKeys[j]["ApplierRealName"].ToString();
                        string GetDateTime = GridView1.DataKeys[j]["GetDateTime"].ToString();
                        string ApplyCount = GridView1.DataKeys[j]["ApplyCount"].ToString();

                        if (cb1.Checked)
                        {
                            mCash_Apply = new Dianda.Model.Cash_Apply();
                            mCash_Apply = bCash_Apply.GetModel(Int32.Parse(id));
                            mCash_Apply.Statas = 2;
                            mCash_Apply.DoUserID = ((Model.USER_Users)Session["USER_Users"]).ID;
                            bCash_Apply.Update(mCash_Apply);
                            info += ("(" + ApplierRealName + "申请额度" + ApplyCount + "在" + GetDateTime + ")");
                            tag.Text = "操作成功！";
                            // string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";

                            Model.Cash_Cards mCash_Cards = new Dianda.Model.Cash_Cards();
                            BLL.Cash_Cards bCash_Cards = new Dianda.BLL.Cash_Cards();
                            mCash_Cards = bCash_Cards.GetModel(Int32.Parse(mCash_Apply.CashCertificateID.ToString()));

                            /*给业务申请者发信息*/
                            Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                            BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

                            mFaceShowMessage.DATETIME = DateTime.Now;
                            mFaceShowMessage.FromTable = "申请情况";
                            mFaceShowMessage.IsRead = 0;
                            mFaceShowMessage.NewsID = null;
                            mFaceShowMessage.NewsType = "申请情况";
                            mFaceShowMessage.ReadTime = null;
                            mFaceShowMessage.Receive = mCash_Apply.ApplierID;
                            mFaceShowMessage.URLS = "<a href='/Admin/cashCardManage/manageCashApplyPerson.aspx' target='_self' title='经费预约：提交时间" + DateTime.Now + "'>" + mCash_Cards.CardName + "的经费预约 审核不通过 </a>  (" + ((Model.USER_Users)Session["USER_Users"]).REALNAME + ")";
                            bFaceShowMessage.Add(mFaceShowMessage);
                            /*给业务申请者发信息*/
                        }
                    }

                    // 添加操作日志
                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "审核经费预约", "审核预约" + info + "不通过：成功");

                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manageCashApply.aspx?pageindex=" + pageindexHidden.Value + "&date=" + DDList_RQ.SelectedValue + "&status=" + this.ddlStatas.SelectedValue + "\";</script>";
                    Response.Write(coutws);
                }
            }
        }

        protected void ddlStatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRowCout();
            BindData(1);//调用显示
        }

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 and PDEL=0");
            if (this.ddlStatas.SelectedValue == "0")
            {
                sbSql.Append(" AND Statas = 0");
            }
            else if (this.ddlStatas.SelectedValue == "1")
            {
                sbSql.Append(" AND (Statas = 1 or Statas = 2 or Statas = 3) ");
            }
            //sbSql.Append("ORDER BY ID ");
            if (!string.IsNullOrEmpty(DDList_RQ.SelectedValue))
            {
                sbSql.Append(" AND GetDateTime between '" + DDList_RQ.SelectedValue + " 00:00:00' and '" + DDList_RQ.SelectedValue + " 23:59:59'");
            }
            return sbSql.ToString();
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

                    string datatime = DataBinder.Eval(e.Row.DataItem, "GetDateTime").ToString();
                    string Attribute = DataBinder.Eval(e.Row.DataItem, "Attribute").ToString();

                    if (Attribute == "0")
                        e.Row.Cells[3].Text = "资金卡";
                    else
                        e.Row.Cells[3].Text = "专项资金";

                    if (datatime.Contains(" 10:00:00"))
                    {
                        e.Row.Cells[4].Text = Convert.ToDateTime(datatime).ToString("yyyy-MM-dd").ToString() + " 上午";
                    }
                    else
                    {
                        e.Row.Cells[4].Text = Convert.ToDateTime(datatime).ToString("yyyy-MM-dd").ToString() + " 下午";
                    }

                    //// string CONTENTS = DataBinder.Eval(e.Row.DataItem, "CONTENTS").ToString();
                    //string NAME = DataBinder.Eval(e.Row.DataItem, "NAME").ToString();
                    //string IsRead = DataBinder.Eval(e.Row.DataItem, "IsRead").ToString();
                    //hid.Value = ID;
                    ////e.Row.Cells[3].Text = CONTENTS;
                    //e.Row.Cells[2].Text = "<a href='showHistory.aspx?id=" + ID + "' title='操作记录查看' target='_self' rel='gb_page_center[726,400]''>" + CardName + "</a>";
                    if (Statas == "0")
                    {
                        e.Row.Cells[8].Text = "待审核";
                    }
                    else if (Statas == "1")
                    {
                        e.Row.Cells[8].Text = "审核通过";
                    }
                    else if (Statas == "2")
                    {
                        e.Row.Cells[8].Text = "<font color='red'>审核不通过</font>";
                    }
                    else if (Statas == "3")
                    {
                        RadioButton cb = (RadioButton)e.Row.Cells[0].FindControl("RBtn_choose");
                        cb.Enabled = false;
                        e.Row.Cells[8].Text = "审核完成";
                    }
                }
            }
            catch
            {
            }
        }

        protected void btn_JEHZ_Click(object sender, EventArgs e)
        {

        }
        //审核完成状态
        protected void Button_Complete_Click(object sender, EventArgs e)
        {
            //选择编辑的条数只能为一条
            int num = 0;
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    RadioButton rb = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("RBtn_choose");
                    if (rb.Checked)
                    {
                        string id = GridView1.DataKeys[i]["ID"].ToString();
                        string Statas = GridView1.DataKeys[i]["Statas"].ToString();
                        if (Statas == "1")
                            Response.Redirect(SkipPage + "?key=2&ApplyID=" + id + ReturnCS());
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, GetType(), "TS", "alert('当前纪录状态不对，不可操作！')", true);
                            break;
                        }

                    }
                }
            }

            tag.Text = "请选择要操作的纪录！";
        }

        protected void Button_sumbit_Click(object sender, EventArgs e)
        { 
            //选择编辑的条数只能为一条
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    RadioButton rb = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("RBtn_choose");
                    if (rb.Checked)
                    {
                        string id = GridView1.DataKeys[i]["ID"].ToString();
                        string Statas = GridView1.DataKeys[i]["Statas"].ToString();
                        if (Statas == "0" || Statas == "2")
                            Response.Redirect(SkipPage + "?key=1&ApplyID=" + id + ReturnCS());
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, GetType(), "TS", "alert('当前纪录状态不对，不可操作！')", true);
                            break;
                        }
                    }
                }
            }

            tag.Text = "请选择要操作的纪录！";
        }

        public string ReturnCS()
        {
            return "&parentpage=cashCardManageManageCashApplyPage&pageindex=" + pageindexHidden.Value + "&date=" + DDList_RQ.SelectedValue + "&status=" + this.ddlStatas.SelectedValue;
        }
        /// <summary>
        /// 显示全部
        /// </summary>
        public void ShowList()
        {
            BLL.YYJEHZ bYYJEHZ = new Dianda.BLL.YYJEHZ();
            DataTable dt = bYYJEHZ.GetYYJEHZ();
            DDList_RQ.DataSource = dt;
            DDList_RQ.DataTextField = "GetDateTime";
            DDList_RQ.DataValueField = "GetDateTime";
            DDList_RQ.DataBind();
            DDList_RQ.Items.Remove(DDList_RQ.Items.FindByText("合计"));
            DDList_RQ.Items.Insert(0, new ListItem("全部", ""));
            //设置合计金额标题日期
            if (!string.IsNullOrEmpty(DDList_RQ.SelectedValue.ToString()))
            {
                Label_Time.Text = DDList_RQ.SelectedValue.ToString();
            }
            else { Label_Time.Text = "全部"; }
            if (Request.Params["status"] != null && !String.IsNullOrEmpty(Request["date"]))
            {
                this.DDList_RQ.SelectedValue = Request["date"];
            }
        }
        //日期状态发生改变
        protected void DDList_RQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRowCout();
            BindData(1);//调用显示
            //设置合计金额标题日期
            if (!string.IsNullOrEmpty(DDList_RQ.SelectedValue.ToString()))
            {
                Label_Time.Text = DDList_RQ.SelectedValue.ToString();
            }
            else { Label_Time.Text = "全部"; }

        }

    }
}
