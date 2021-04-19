using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DOC_transport
{
    public partial class check : System.Web.UI.Page
    {
        BLL.DOC_transport_To docFromBll = new Dianda.BLL.DOC_transport_To();
        Model.DOC_transport_To docFomModel = new Dianda.Model.DOC_transport_To();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string ID = Request["ID"];//获取到公文的ID
                    docFomModel = docFromBll.GetModel(ID);
                    docFomModel.ISREAD = 1;
                    docFomModel.READTIME = DateTime.Now;
                    if (docFomModel.FILEPATH.Length > 0)
                    {
                        Label_fileup.Text = "<a href='" + docFomModel.FILEPATH + "' target='_blank'>点击下载附件</a>";
                    }
                    else
                    {
                        Label_fileup.Text = "此公文无附件";
                    }
                    Label_title.Text = docFomModel.TITLES.ToString();

                    docFromBll.Update(docFomModel);
                    
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
                Response.Redirect("manageShou.aspx?Key=" + Request["Key"] + "&KeySel=" + Request["KeySel"] + "&pageindex=" + Request["pageindex"]);
            }
            catch
            {
            }
        }
       
    }
}
