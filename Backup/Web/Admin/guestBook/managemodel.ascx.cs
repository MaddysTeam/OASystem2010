using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.guestBook
{
    public partial class managemodel : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl PageControl = new Dianda.COMMON.pageControl();// new COMMON.pageControl();//引入通用操作类
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        BLL.GUESTBOOK_MAIN bbook = new Dianda.BLL.GUESTBOOK_MAIN();
        Model.GUESTBOOK_MAIN mbook = new Dianda.Model.GUESTBOOK_MAIN();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                { 
                    string KeySel = "";
                    string pageindex = null;//这里是为分页服务的
                    try
                    {
                        KeySel = Request["KeySel"];
                        pageindex = Request["pageindex"];
                        TextBox_KEYS.Text = KeySel;
                    }
                    catch
                    {
                    }
                    string count = dtrowsHidden.Value.ToString();
                    if (count.Length == 0)
                    {
                        setRowCout(KeySel);
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

                    if (KeySel == "" || KeySel == null)
                    {
                        KeySel = "";
                    }
                    int pageindex_int = int.Parse(pageindex);
                    ShowKcList(pageindex_int, KeySel);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据当前页的搜索条件、留言属于那个模块、模块中信息的ID
        /// </summary>
        /// <param name="key">搜索条件</param>
        private void setRowCout(string key)
        {
            try
            {
                DataTable dt = new DataTable();
                string sqlwhere1 = "";
                sqlwhere1 = sqlWhere(key);
                int count = PageControl.tableRowCout(sqlwhere1, "GUESTBOOK_MAIN", "ID");
                if (count > 0)
                {
                    dtrowsHidden.Value = count.ToString();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据当前页的搜索条件、留言属于那个模块、模块中信息的ID
        /// </summary>
        /// <param name="key">搜索条件</param>
        private string sqlWhere(string key)
        {
            string coutw = " delflag='0'";
            if (key == null || key.Length == 0)
            {
                coutw = coutw;
            }
            else
            {
                coutw = coutw + " and  (CONTENTS like '%" + key + "%' or WRITER like '%" + key + "%' or RE_CONTENTS like '%" + key + "%')";
            }
            return coutw;
        }
        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="pageindex">页码</param>
        /// <param name="keys">搜索条件</param>
        protected void ShowKcList(int pageindex, string KeySel)//分页显示符合条件的内容
        {
            DataTable DT = new DataTable();
            string sqlWhere1 = "";
            sqlWhere1 = sqlWhere(KeySel);
            string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
            if (allTiaoshu == "" || allTiaoshu == null)
            {
                allTiaoshu = "0";
            }
            int alltiaoshuInt = int.Parse(allTiaoshu);
            DT = PageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "GUESTBOOK_MAIN", "DATETIME").Tables[0];//用带有分页功能的列表进行显示
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
            string KeySel = TextBox_KEYS.Text.ToString();
            ShowKcList(page, KeySel);//调用显示
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
            string KeySel = TextBox_KEYS.Text.ToString();
            ShowKcList(page, KeySel);//调用显示
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
                string STATUS = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "STATUS"));//审核状态 默认为0 ，1为审核通过,0表示前台不显示，1表示前台显示
                string RE_CONTENTS = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RE_CONTENTS"));
                Label re_contents_l = (Label)e.Row.Cells[0].FindControl("Label_reContents");
                re_contents_l.Text = RE_CONTENTS;
                TextBox re_contents_t = (TextBox)e.Row.Cells[0].FindControl("TextBox_reContents");
                re_contents_t.Text = RE_CONTENTS;
                re_contents_t.Visible = false;
                re_contents_l.Visible = true;

                LinkButton LinkButton_replay_1 = (LinkButton)e.Row.Cells[0].FindControl("LinkButton_replay");//回复的按钮
                LinkButton LinkButton_replay_submit_1 = (LinkButton)e.Row.Cells[0].FindControl("LinkButton_replay_submit");//提交回复的按钮
                LinkButton LinkButton_delshow1 = (LinkButton)e.Row.Cells[0].FindControl("LinkButton_delshow");//取消前台显示
                LinkButton LinkButton_show1 = (LinkButton)e.Row.Cells[0].FindControl("LinkButton_show");//在前台显示
                LinkButton_replay_1.Visible = true;
                LinkButton_replay_submit_1.Visible = false;
                if (STATUS == "0")
                {
                    LinkButton_delshow1.Visible = false;
                    LinkButton_show1.Visible = true;
                }
                else if (STATUS == "1")
                {
                    LinkButton_delshow1.Visible = true;
                    LinkButton_show1.Visible = false;
                }

            }
        }
        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_replay_Click(object sender, EventArgs e)
        {
            try
            {
                string id_index = ((LinkButton)sender).CommandArgument.ToString();
                string[] arrays = id_index.Split('|');
                Label re_contents_l = (Label)GridView1.Rows[int.Parse(arrays[1].ToString())].Cells[0].FindControl("Label_reContents");
                TextBox re_contents_t = (TextBox)GridView1.Rows[int.Parse(arrays[1].ToString())].Cells[0].FindControl("TextBox_reContents");

                re_contents_t.Visible = true;
                re_contents_l.Visible = false;

                LinkButton LinkButton_replay_1 = (LinkButton)GridView1.Rows[int.Parse(arrays[1].ToString())].Cells[0].FindControl("LinkButton_replay");//回复的按钮
                LinkButton LinkButton_replay_submit_1 = (LinkButton)GridView1.Rows[int.Parse(arrays[1].ToString())].Cells[0].FindControl("LinkButton_replay_submit");//提交回复的按钮
                LinkButton_replay_1.Visible = false;
                LinkButton_replay_submit_1.Visible = true;

            }
            catch
            {
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_del_Click(object sender, EventArgs e)
        {
            try
            {
                string id_index = ((LinkButton)sender).CommandArgument.ToString();
                string[] arrays = id_index.Split('|');

                mbook = bbook.GetModel(arrays[0].ToString());
                if (mbook != null)
                {
                    mbook.DELFLAG = 1;
                    bbook.Update(mbook);
                }

               
                int page = Convert.ToInt32(pageindexHidden.Value.ToString());
                string KeySel = TextBox_KEYS.Text.ToString();
                ShowKcList(page, KeySel);//调用显示
            }
            catch
            {
            }
        }
        /// <summary>
        /// 取消前台显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_delshow_Click(object sender, EventArgs e)
        {
            try
            {
                string id_index = ((LinkButton)sender).CommandArgument.ToString();
                string[] arrays = id_index.Split('|');

                mbook = bbook.GetModel(arrays[0].ToString());
                if (mbook != null)
                {
                    mbook.STATUS = 0;
                    bbook.Update(mbook);
                }
             

                int page = Convert.ToInt32(pageindexHidden.Value.ToString());
                string KeySel = TextBox_KEYS.Text.ToString();
                ShowKcList(page, KeySel);//调用显示

            }
            catch
            {
            }
        }
        /// <summary>
        /// 在前台显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_show_Click(object sender, EventArgs e)
        {
            try
            {
                string id_index = ((LinkButton)sender).CommandArgument.ToString();
                string[] arrays = id_index.Split('|');

                mbook = bbook.GetModel(arrays[0].ToString());
                if (mbook != null)
                {
                    mbook.STATUS = 1;
                    bbook.Update(mbook);
                }
              

                int page = Convert.ToInt32(pageindexHidden.Value.ToString());
                string KeySel = TextBox_KEYS.Text.ToString();
                ShowKcList(page, KeySel);//调用显示

            }
            catch
            {
            }
        }
        /// <summary>
        /// 提交回复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_replay_submit_Click(object sender, EventArgs e)
        {
            try
            {
                string id_index = ((LinkButton)sender).CommandArgument.ToString();
                string[] arrays = id_index.Split('|');
                Label re_contents_l = (Label)GridView1.Rows[int.Parse(arrays[1].ToString())].Cells[0].FindControl("Label_reContents");
                TextBox re_contents_t = (TextBox)GridView1.Rows[int.Parse(arrays[1].ToString())].Cells[0].FindControl("TextBox_reContents");

                mbook = bbook.GetModel(arrays[0].ToString());
                if (mbook != null)
                {
                    mbook.RE_CONTENTS = re_contents_t.Text.ToString() + "[" + Session["USERNAME_SYSUSER"].ToString() + " 于 " + DateTime.Now.ToString() + " 回复]";
                    mbook.RE_DATETIME = DateTime.Now;
                    mbook.STATUS = 1;
                    re_contents_l.Text = mbook.RE_CONTENTS.ToString();
                    re_contents_t.Text = mbook.RE_CONTENTS.ToString();

                    bbook.Update(mbook);
                }


                re_contents_t.Visible = false;
                re_contents_l.Visible = true;

                LinkButton LinkButton_replay_1 = (LinkButton)GridView1.Rows[int.Parse(arrays[1].ToString())].Cells[0].FindControl("LinkButton_replay");//回复的按钮
                LinkButton LinkButton_replay_submit_1 = (LinkButton)GridView1.Rows[int.Parse(arrays[1].ToString())].Cells[0].FindControl("LinkButton_replay_submit");//提交回复的按钮
                LinkButton_replay_1.Visible = true;
                LinkButton_replay_submit_1.Visible = false;
            }
            catch
            {
            }
        }
        /// <summary>
        /// 搜索功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_search_Click(object sender, EventArgs e)
        {
            try
            {
                int page = 1;
                pageindexHidden.Value = page.ToString();
                string KeySel = TextBox_KEYS.Text.ToString();
                setRowCout(KeySel);

                ShowKcList(1, KeySel);//调用显示
            }
            catch
            {
            }
        }

    }
}