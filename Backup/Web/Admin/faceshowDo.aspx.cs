using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin
{
    public partial class faceshowDo : System.Web.UI.Page
    {
        BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();
        Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string indexnum = Request["ID"];
                mFaceShowMessage = bFaceShowMessage.GetModel(int.Parse(indexnum));
                if (mFaceShowMessage != null)
                {
                    mFaceShowMessage.IsRead = 1;
                    mFaceShowMessage.ReadTime = DateTime.Now;
                    bFaceShowMessage.Update(mFaceShowMessage);
                }
            }
            catch
            {
            }
        }
    }
}
