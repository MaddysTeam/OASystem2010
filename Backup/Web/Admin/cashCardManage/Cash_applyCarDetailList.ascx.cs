using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class Cash_applyCarDetailList : System.Web.UI.UserControl
    {
        COMMON.pageControl dosql = new Dianda.COMMON.pageControl();
        BLL.Cash_CardsDetail bllCCD = new Dianda.BLL.Cash_CardsDetail();//资金卡的明细列表
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 根据资金卡的ID号，来加载数据
        /// </summary>
        /// <param name="cashCarIDs"></param>
        public void main(string cashCarIDs,char fengefu)
        {
            try
            {
                if (cashCarIDs.Length > 0)
                {

                }
            }
            catch
            {
            }
        }
 
        /// <summary>
        /// 添加一个资金卡进入列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addcar_Click(object sender, EventArgs e)
        {
            string cardid = DropDownList_cashCar.SelectedValue.ToString();
            //先看看选择的资金卡ID在列表中是否已经有了
            bool ishave = false;
            Label_notice.Visible = false;
            for (int i = 0; i <DataList1.Items.Count; i++)
            {
                string HiddenField_cardids = ((HiddenField)DataList1.Items[i].FindControl("HiddenField_cardid")).Value.ToString();
                if (HiddenField_cardids == cardid)
                {
                    ishave = true;
                    Label_notice.Visible = true;
                    break;
                }
            }
            //用资金卡的ID 去Cash_CardsDetail中找，该资金卡有没有明细，如果没有则不能添加进列表
            if (!ishave)
            {
                string sql = "select * from vCash_CardsDetail where CardID='" + cardid + "'";

                DataSet ds = dosql.doSql(sql);// bllCCD.GetList("CardID='" + cardid + "'");
                bool ishavedetail = false;//是否有明细
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //进行动态数据的加载
                            ishavedetail = true;
                        }
                    }
                }
                if (!ishavedetail)
                {
                    Label_notice.Visible = true;
                    Label_notice.Text = nodetailslist.InnerText.ToString();
                }
            }
        }

        //1新加的时候，没有APPLYID;2修改的时候，有APPLYID
        //vCashCardsForApply
        /// <summary>
        /// 加载可以添加的资金卡列表
        /// </summary>
        private void listCar()
        {
            try
            {
                string sql = "select * from vCashCardsForApply order by CardName DESC";
                DataSet ds = dosql.doSql(sql);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        DropDownList_cashCar.Items.Clear();
                        DropDownList_cashCar.DataSource = ds.Tables[0];
                        DropDownList_cashCar.DataTextField = "CardName";
                        DropDownList_cashCar.DataValueField="ID";
                        DropDownList_cashCar.DataBind();
                    }
                }
            }
            catch
            {
            }
        }
        
    }
}