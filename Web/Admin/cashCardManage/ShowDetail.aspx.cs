using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class ShowDetail : System.Web.UI.Page
    {
        Model.Cash_Apply mCash_Apply = new Dianda.Model.Cash_Apply();
        BLL.Cash_Apply bCash_Apply = new Dianda.BLL.Cash_Apply();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                mCash_Apply = bCash_Apply.GetModel(int.Parse(ID));

                if (null != mCash_Apply.UseFor && !mCash_Apply.UseFor.ToString().Equals(""))
                {
                    LB_Notes.Text = mCash_Apply.UseFor.ToString();
                }
                else
                {
                    LB_Notes.Text = "无";
                }

            }
            catch
            { }
        }
    }
}
