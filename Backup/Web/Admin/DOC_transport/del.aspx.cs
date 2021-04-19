using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DOC_transport
{
    public partial class del : System.Web.UI.Page
    {
        BLL.DOC_transport_From docFromBll = new Dianda.BLL.DOC_transport_From();
        Model.DOC_transport_From docFomModel = new Dianda.Model.DOC_transport_From();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string username = Request["names"];
                    tag.Text = "&nbsp;&nbsp;您确定要删除   " + username + "    吗！";
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_fanhui_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("manage.aspx?Key=" + Request["Key"] + "&KeySel=" + Request["KeySel"] + "&pageindex=" + Request["pageindex"]);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 删除用户操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_del_Click(object sender, EventArgs e)
        {
            try
            {
                string UID = Request["ID"];

                docFomModel = docFromBll.GetModel(UID);
                docFomModel.DELFLAG = 1;

                docFromBll.Update(docFomModel);
                tag.Text = "操作成功！";
                Button_del.Visible = false;

            }
            catch
            {
                tag.Text = "操作失败！";
            }
        }

    }
}
