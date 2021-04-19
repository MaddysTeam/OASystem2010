using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OACashApply
{
    public partial class showCashApply : System.Web.UI.Page
    {
        Dianda.COMMON.common common = new Dianda.COMMON.common();
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Model.Cash_Apply mCash_Apply = new Dianda.Model.Cash_Apply();
        BLL.Cash_Apply bCash_Apply = new Dianda.BLL.Cash_Apply();

        private static string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["id"] != null && !String.IsNullOrEmpty(Request["id"]))
                {
                    _id = common.RequestSafeString(Request["id"], 50);
                }

                BindData();

            }
        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            string sql = "Select * From vCash_Apply Where ID=" + _id;
            dt = pageControl.doSql(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.lblApplierRealName.Text = dt.Rows[0]["ApplierRealName"].ToString();
                this.lblApplyCount.Text = dt.Rows[0]["ApplyCount"].ToString();
                this.lblProjectName.Text = dt.Rows[0]["ProjectName"].ToString();
                this.lblGetDateTime.Text = dt.Rows[0]["GetDateTime"].ToString();
                this.lblCardName.Text = dt.Rows[0]["CardName"].ToString();
                this.lblUseFor.Text = dt.Rows[0]["UseFor"].ToString();
                this.lblApplierTel.Text = dt.Rows[0]["ApplierTel"].ToString();
                this.lblDATETIME.Text = dt.Rows[0]["DATETIME"].ToString();
                string Statas = dt.Rows[0]["Statas"].ToString();
                if (Statas == "0")
                {
                    this.lblStatas.Text = "待审核";
                }
                else if (Statas == "1")
                {
                    this.lblStatas.Text = "审核通过";
                }
                else if (Statas == "2")
                {
                    this.lblStatas.Text = "<font color='red'>审核不通过</font>";
                }
                else if (Statas == "3")
                {
                    this.lblStatas.Text = "审核完成";
                }
            }
        }
    }
}
