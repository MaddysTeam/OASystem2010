using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.budgetManage
{
    public partial class viewbudget : System.Web.UI.Page
    {
        BLL.Cash_SF_Order order_bll = new Dianda.BLL.Cash_SF_Order();
        Model.Cash_SF_Order order_model = new Dianda.Model.Cash_SF_Order();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowInfor(Request["ID"].ToString());
            }
        }

        /// <summary>
        /// 显示详情
        /// </summary>
        /// <param name="ID"></param>
        protected void ShowInfor(string ID)
        {
            try
            {
                order_model = order_bll.GetModel(int.Parse(ID));

                if (null != order_model.Note && !order_model.Note.ToString().Equals(""))
                {
                    LB_Notes.Text = order_model.Note.ToString();
                }
                else
                {
                    LB_Notes.Text = "　暂无预算报告！";
                }

            }
            catch
            { }
        }

    }
}
