using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class Cash_SpecialFunds : System.Web.UI.Page
    {
        BllExt.StaticFactory_CASH bllextSF = new Dianda.BllExt.StaticFactory_CASH();//静态数据的控制器
        COMMON.GridViewControl commonGVC = new Dianda.COMMON.GridViewControl();//控制GridView
        private const int _firstPage = 1;//分页的第1页
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判断当前页面是从哪个入口进来的，role=manage是可以进行操作，如果不是则只能查看 2012-4-13修改
                string PageRole = "";
                if (Request["role"] != null)
                    PageRole = Request["role"].ToString();
                if (PageRole == "viewer")
                {
                    OAleftmenu_Show1.Visible = true;
                    ShowButton(false);
                }
                else
                {
                    OAleftmenu1.Visible = true;
                    ShowButton(true);
                }

                showYears(DropDownList_year, DateTime.Now.Year.ToString());//显示年份
                showAccount(DropDownList_AccountList, "");//显示账户列表
                setKeys();//设置回传值
                string pageindex = "";
                pageindex = Request["pageindex"];
                if (!String.IsNullOrEmpty(pageindex))
                {
                    getList(int.Parse(pageindex));//获取列表
                }
                else
                {
                    getList(_firstPage);//获取列表
                }
                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 专项资金管理";
                /*设置模板页中的管理值*/
            }
        }

        public void ShowButton(bool b)
        {
            Button_add.Visible = b;
            Button1.Visible = b;
            Button_delete.Visible = b;
            GridView1.Columns[0].Visible = b;
        }
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="pageindex"></param>
        private void getList(int pageindex)
        {
            GridView_PageSet1.WhereString = getWhereString();
            GridView_PageSet1.SetDataBind(pageindex);
        }
        /// <summary>
        /// 获取到查询条件
        /// </summary>
        /// <returns></returns>
        private string getWhereString()
        {
            //string pids = DropDownList_list.SelectedValue.ToString();//获取到上级栏目的路径及ID
            //string[] pidarray = pids.Split(_splitChar);
            string sql = "";
            sql = " IsListApply=1 and YEARS=" + DropDownList_year.SelectedValue.ToString() + " and AccountID=" + DropDownList_AccountList.SelectedValue.ToString() + "";
            return sql;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cash_SpecialFunds_add.aspx");

        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] gets = commonGVC.getSelect(GridView1, "CheckBox_choose", 0, "ID", '@');

            if (gets != null)
            {
                if (gets[0] == "0")
                {
                    tag.Text = gets[1];
                }
                else
                {
                    if (int.Parse(gets[0].ToString()) > 1)
                    {
                        tag.Text = "请选择一条数据进行编辑！";
                    }
                    else
                    {
                        string id = gets[1].ToString().Replace('@', ' ');
                        string pageindexs = GridView_PageSet1.pageindex.ToString();
                        Response.Redirect("Cash_SpecialFunds_add.aspx?id=" + id + "&pageindex=" + pageindexs + "&" + getKeys());
                    }
                }
            }
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_delete_Click(object sender, EventArgs e)
        {
            string[] gets = commonGVC.getSelect(GridView1, "CheckBox_choose", 0, "ID", '@');

            if (gets != null)
            {
                if (gets[0] == "0")
                {
                    tag.Text = gets[1];
                }
                else
                {
                    string id = gets[1].ToString().Replace('@', ',');
                    string pageindexs = GridView_PageSet1.pageindex.ToString();
                    Response.Redirect("Cash_SpecialFunds_add.aspx?dotype=dels&id=" + id + "&pageindex=" + pageindexs + "&" + getKeys());

                }
            }
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
                    commonGVC.selectAll(GridView1, "CheckBox_choose", true, 0);
                }
                else//全不选
                {
                    commonGVC.selectAll(GridView1, "CheckBox_choose", false, 0);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 显示预算列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_orderlist_Click(object sender, EventArgs e)
        {
            try
            {
                string spid = ((LinkButton)sender).CommandArgument.ToString();
                
                SpecialFundsOrder1.ShowList(spid);
                showOrderList.Visible = true;
                showtables.Visible = false;

            }
            catch
            {
            }
        }
        /// <summary>
        /// 关闭显示层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_guanbi_Click(object sender, EventArgs e)
        {
            showOrderList.Visible = false;
            showtables.Visible = true;
        }
        /// <summary>
        /// 显示年份的数据
        /// </summary>
        /// <param name="dl"></param>
        /// <param name="years"></param>
        private void showYears(DropDownList dl, string years)
        {
            dl.Items.Clear();
            DateTime dt = DateTime.Now;
            for (int i = 2000; i < dt.Year + 5; i++)
            {
                ListItem li = new ListItem();
                li.Value = i.ToString();
                li.Text = i.ToString() + "年";
                dl.Items.Add(li);
            }
            if (!String.IsNullOrEmpty(years))
            {
                dl.SelectedValue = years;
            }
        }
        /// <summary>
        ///显示账户的列表
        /// </summary>
        /// <param name="dl"></param>
        /// <param name="accountid"></param>
        private void showAccount(DropDownList dl, string accountid)
        {
            try
            {
                dl.DataSource = bllextSF.getCash_Account();
                dl.DataValueField = "ID";
                dl.DataTextField = "NAMES";
                dl.DataBind();
                if (!String.IsNullOrEmpty(accountid))
                {
                    dl.SelectedValue = accountid;
                }
            }
            catch { }
        }
        /// <summary>
        ///年份筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            getList(_firstPage);//获取列表
        }
        /// <summary>
        /// 账户筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_AccountList_SelectedIndexChanged(object sender, EventArgs e)
        {
            getList(_firstPage);//获取列表
        }
        /// <summary>
        /// 获取到筛选的值
        /// </summary>
        /// <returns></returns>
        private string getKeys()
        {
            return "account=" + DropDownList_AccountList.SelectedValue.ToString() + "&years=" + DropDownList_year.SelectedValue.ToString();
        }
        /// <summary>
        /// 设置预设的值
        /// </summary>
        private void setKeys()
        {
            string account = Request["account"];
            string years = Request["years"];
            if (!String.IsNullOrEmpty(account))
            {
                DropDownList_AccountList.SelectedValue = account;
            }
            if (!String.IsNullOrEmpty(years))
            {
                DropDownList_year.SelectedValue = years;
            }
        }

    }
}
