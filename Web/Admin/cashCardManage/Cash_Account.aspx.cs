using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class Cash_Account : System.Web.UI.Page
    {
        BLL.Cash_Account bllCA = new Dianda.BLL.Cash_Account();//账户的操作类
        BllExt.StaticFactory_CASH bllextSF = new Dianda.BllExt.StaticFactory_CASH();//静态数据的控制器
        COMMON.GridViewControl commonGVC = new Dianda.COMMON.GridViewControl();//控制GridView
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

                list();//列表显示
                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 账户管理";
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
        /// 显示账户的基本信息
        /// </summary>
        private void list()
        {
            try
            {
                DataTable dt = bllextSF.getCash_Account();// bllCA.GetList("Delflag=0").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }
                else
                {
                    GridView1.Visible = false;
                }
            }
            catch
            {
            }

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cash_Account_add.aspx");
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
          string[] gets=commonGVC.getSelect(GridView1, "CheckBox_choose", 0, "ID", '@');

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
                      string id=gets[1].ToString().Replace('@',' ');
                      Response.Redirect("Cash_Account_add.aspx?id=" + id);
                  }
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
                    commonGVC.selectAll(GridView1, "CheckBox_choose", true,0);
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
        /// 将要注销的数据提交给下一个页面
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
                      Response.Redirect("Cash_Account_add.aspx?dotype=dels&id=" + id);
                   
                }
            }
        }
    }
}
