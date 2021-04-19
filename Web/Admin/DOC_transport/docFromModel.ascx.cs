using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DOC_transport
{
    public partial class docFromModel : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl PageControl = new Dianda.COMMON.pageControl();// new COMMON.pageControl();//引入通用操作类
        BLL.DOC_transport_From DOC_transport_FromBll = new Dianda.BLL.DOC_transport_From();//引入发件箱的操作类
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string Key = "";//这里是为分页服务的
                    string KeySel = "";
                    string pageindex = null;//这里是为分页服务的
                    try
                    {
                        //Key = Request["Key"];
                        KeySel = Request["KeySel"];
                        pageindex = Request["pageindex"];
                       // MakeDropdownlist(Key);//获取到当前栏目Dropdownlist记录
                       // DropDownList_keys.SelectedValue = Key;
                        TextBox_KEYS.Text = KeySel;
                    }
                    catch
                    {
                    }
                    //if (Key == "" || Key == null)
                    //{
                    //    Key = DropDownList_keys.SelectedValue.ToString();
                    //}
                    string count = dtrowsHidden.Value.ToString();
                    if (count.Length == 0)
                    {
                        setRowCout(Key, KeySel);
                        count = dtrowsHidden.Value.ToString();
                    }
                    else
                    {
                        count = "0";
                    }
                    if (count == "" || count == null)
                    {
                        count = "0";
                    }
                    int countint = int.Parse(count);
                    if (pageindex == null || pageindex == "")
                    {
                        pageindex = "1";
                    }
                    //if (Key == "" || Key == null)
                    //{
                    //    Key = DropDownList_keys.SelectedValue.ToString();
                    //}
                    if (KeySel == "" || KeySel == null)
                    {
                        KeySel = "";
                    }
                    int pageindex_int = int.Parse(pageindex);
                    ShowKcList(pageindex_int, Key, KeySel);
                }
            }
            catch
            {
            }
        }
        ///// <summary>
        ///// 获取到当前栏目Dropdownlist记录
        ///// </summary>
        //protected void MakeDropdownlist(string key)
        //{
        //    //Model.SessionUser sessionUser = new Dianda.Model.SessionUser();
        //    //sessionUser = (Model.SessionUser)Session["sessionUserModel"];

        //    string WRITER = Session["USERID_SYSUSER"].ToString();// sessionUser.USERID.ToString();//Session["USERNAME"].ToString();//发布者

        //    DataTable DT = new DataTable();
        //    string sqlwhere1 = "";
        //    sqlwhere1 = " (delflag='0') AND(ID IN (SELECT ColumnsID FROM NEWS_USERID_COLUMNSID WHERE (UserID='" + WRITER + "') AND (ISAdd = 1))) order by COLUMNSPATH";
        //    DT = ColumnsBll.GetAllList(sqlwhere1).Tables[0];
        //    for (int i = 0; i < DT.Rows.Count; i++)
        //    {
        //        string parentid = DT.Rows[i]["PARENTID"].ToString();
        //        string path = DT.Rows[i]["COLUMNSPATH"].ToString();
        //        if (parentid != "-1")
        //        {
        //            string kg = null;
        //            for (int x = 0; x < (path.Length) / 32; x++)
        //            {
        //                kg += "　";
        //            }
        //            DT.Rows[i]["NAME"] = kg + "|--" + DT.Rows[i]["NAME"].ToString();
        //        }
        //        ListItem L1 = new ListItem();
        //        L1.Text = DT.Rows[i]["NAME"].ToString();
        //        L1.Value = DT.Rows[i]["ID"].ToString();
        //        DropDownList_keys.Items.Add(L1);
        //    }
        //    if (DT.Rows.Count > 0)
        //    {
        //    }
        //    else
        //    {
        //        DropDownList_keys.Visible = false;
        //    }
        //}
        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        private void setRowCout(string key, string KeySel)
        {
            try
            {
                DataTable dt = new DataTable();
                string sqlwhere1 = " delflag='0'";
                sqlwhere1 = sqlWhere(key, KeySel);
              //  dt =DOC_transport_FromBll.GetList(sqlwhere1).Tables[0];
                int count = PageControl.tableRowCout(sqlwhere1, "DOC_transport_From", "ID");
               // int count = dt.Rows.Count;
                if (count > 0)
                {
                    dtrowsHidden.Value = count.ToString();
                }
            }
            catch
            {
            }
        }
        private string sqlWhere(string key, string KeySel)
        {
            string coutw = " delflag='0'";
            //if (key != "0")
            //{
            //coutw = coutw + " and PARENTID like '%" + key + "%' ";
            //}
           // coutw = coutw + " and PARENTID = '" + key + "' ";
            if (KeySel != "")
            {
                coutw = coutw + " and (TITLES like '%" + KeySel + "%' or TOUSER like '%" + KeySel + "%')";
            }
            coutw = coutw + " and FROMUSER='" + Session["USERNAME_SYSUSER"].ToString()+ "'";
            return coutw;
        }
        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="pageindex">页码</param>
        /// <param name="keys">搜索条件</param>
        protected void ShowKcList(int pageindex, string keys, string KeySel)//分页显示符合条件的内容
        {
            DataTable DT = new DataTable();
            string sqlWhere1 = " delflag='0'";
            sqlWhere1 = sqlWhere(keys, KeySel);
            string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
            if (allTiaoshu == "" || allTiaoshu == null)
            {
                allTiaoshu = "0";
            }
            int alltiaoshuInt = int.Parse(allTiaoshu);
            // DT =RoleBll.GetList_FenYe(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt).Tables[0];//用带有分页功能的列表进行显示
            DT = PageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "DOC_transport_From", "DATETIME").Tables[0];//用带有分页功能的列表进行显示
            pageindex = PageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
            if (DT.Rows.Count > 0)
            {
                //当获取到的数据集不为空的时候，显示在GridView1中
                GridView1.Visible = true;
                GridView1.DataSource = DT;//指定GridView1的数据是DT
                pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
                GridView1.DataBind();//将上面指定的信息绑定到GridView1上

                PageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                notice.Text = "";
                pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
            }
            else
            {
                GridView1.Visible = false;
                notice.Text = "*没有符合条件的结果！";
                pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
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
            string keys = "";// DropDownList_keys.SelectedValue.ToString();
            string KeySel = TextBox_KEYS.Text.ToString();
            ShowKcList(page, keys, KeySel);//调用显示
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
            string keys = "";// DropDownList_keys.SelectedValue.ToString();
            string KeySel = TextBox_KEYS.Text.ToString();
            ShowKcList(page, keys, KeySel);//调用显示
        }

        /// <summary>
        /// 当GridView1绑定完毕数据集后，可以通过RowDataBound事件给该GRIDVIEW中数据做切合实际的转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
            {
                e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#F4F4F4'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");
                string ID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID"));//获取到列表中的每条记录的ID
                string Key = "";// DropDownList_keys.SelectedValue;//DropDownList的值
                string KeySel = TextBox_KEYS.Text.ToString();
                string pageindex = pageindexHidden.Value.ToString();
                //e.Row.Cells[1].Text = "<a title='点击进行编辑' href='modiyUserInfo.aspx?UID=" + ID + "&Key=" + Key + "&pageindex=" + pageindex + "' target='_self'>" + usernames + "</a>";
                if (pageindex == "" || pageindex == null)
                {
                    pageindex = "1";
                }
                string FILEPATH = DataBinder.Eval(e.Row.DataItem, "FILEPATH").ToString();
                string TITLE = DataBinder.Eval(e.Row.DataItem, "TITLES").ToString();
                if (FILEPATH.Length > 0)
                {
                    e.Row.Cells[4].Text = "<a href='" + FILEPATH + "' target='_blank'>点击下载</a>";
                }
                else
                {
                    e.Row.Cells[4].Text = "无附件";
                }
              //  string parentid = DataBinder.Eval(e.Row.DataItem, "parentid").ToString();

                //DataTable DTC = new DataTable();
                //string sqlwhere = "";
                //sqlwhere = " delflag='0' AND ID='" + parentid + "'";
                //DTC = ColumnsBll.GetAllList(sqlwhere).Tables[0];
                //string ISPASS = DTC.Rows[0]["ISSHENHE"].ToString();//栏目的审核属性

                //string UPTOP = DataBinder.Eval(e.Row.DataItem, "UPTOP").ToString();
                //string ISPASS1 = DataBinder.Eval(e.Row.DataItem, "ISPASS").ToString();//新闻的是否审核的属性
                //string DATETIME = DataBinder.Eval(e.Row.DataItem, "DATETIME").ToString();

              //  e.Row.Cells[3].Text = commons.ChangagedateTimeString(DATETIME);

                //if (UPTOP == "0")
                //{
                //    e.Row.Cells[5].Text = "否";
                //}
                //else
                //{
                //    e.Row.Cells[5].Text = "<font color=\"red\">是</font>";
                //}
                //if (ISPASS1 == "0")
                //{
                //    e.Row.Cells[6].Text = "未审核";
                //}
                //else
                //{
                //    e.Row.Cells[6].Text = "<font color=\"red\">已审核</font>";
                //}
                //if (parentid == "-1")
                //{
                //    e.Row.Cells[2].Text = "网站根栏目";
                //    e.Row.Cells[8].Text = "网站根目录不能删除";//网站根目录不准删除
                //    e.Row.Cells[7].Text = "网站根目录不能编辑";//网站根目录不准删除
                //}
                //else
                //{
                //    DataTable DT = new DataTable();
                //    string sqlwhere1 = " delflag='0' and ID='" + parentid + "'";
                //    DT = ColumnsBll.GetAllList(sqlwhere1).Tables[0];
                //    try
                //    {
                //        e.Row.Cells[2].Text = DT.Rows[0]["NAME"].ToString();
                //    }
                //    catch
                //    {
                //        e.Row.Cells[2].Text = "<font color=\"red\">上级栏目已经被删除</font>";
                //    }

                //}
             //   e.Row.Cells[5].Text = "<a href='modify.aspx?ID=" + ID + "&Key=" + Key + "&KeySel=" + KeySel + "&pageindex=" + pageindex + "&ISSHENHE=" + ISPASS + "' target='_self'>-编辑-</a>";
                e.Row.Cells[5].Text = "<a href='del.aspx?ID=" + ID + "&Key=" + Key + "&KeySel=" + KeySel + "&pageindex=" + pageindex + "&names=" + TITLE + "' target='_self'>-删除-</a>";
            }
        }

        protected void Button_search_Click(object sender, EventArgs e)
        {
            string keys = "";// DropDownList_keys.SelectedValue.ToString();
            string KeySel = TextBox_KEYS.Text.ToString();
            setRowCout(keys, KeySel);
            ShowKcList(1, keys, KeySel);
        }
    }
}
