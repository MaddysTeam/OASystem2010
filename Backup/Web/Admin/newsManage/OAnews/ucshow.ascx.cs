using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dianda.COMMON;

namespace Dianda.Web.Admin.newsManage.OAnews
{
    public partial class ucshow : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new pageControl();
        Model.News_News mNews_News = new Dianda.Model.News_News();
        BLL.News_News bNews_News = new Dianda.BLL.News_News();
        Model.News_LimitUser mNews_LimitUser = new Dianda.Model.News_LimitUser();
        BLL.News_LimitUser bNews_LimitUser = new Dianda.BLL.News_LimitUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            string urls = Request.Url.AbsoluteUri.ToString();
            if (urls.Contains("isshownews=1"))
            {
                if (!IsPostBack)
                {
                    string id = Request["id"].ToString();
                    if (String.IsNullOrEmpty(id))
                    {
                        this.Label_NAME.Text = "信息已经被删除！";
                        return;
                    }
                    DataTable dt = new DataTable();
                    string strSQL = "Select ID From News_News WHERE DELFLAG=0 and ID=" + id;
                    dt = pageControl.doSql(strSQL).Tables[0];
                    if (dt.Rows.Count < 1)
                    {
                        this.Label_NAME.Text = "信息已经被删除！";
                        return;
                    }
                    BindData(id);
                    UpdateData(id);
                }
            }
            else
            {
                urls = urls + "&isshownews=1";
                Response.Redirect(urls);
            }
        }


        private void BindData(string id)
        {
            mNews_News = new Dianda.Model.News_News();
            mNews_News = bNews_News.GetModel(Int32.Parse(id));
            DataTable dt = new DataTable();
            string sql = "Select REALNAME From USER_Users Where DELFLAG=0 and USERNAME='" + mNews_News.WRITER + "'";
            dt = pageControl.doSql(sql).Tables[0];
            if (mNews_News != null)
            {
                this.Label_NAME.Text = mNews_News.NAME;
                this.Label_CONTENTS.Text = mNews_News.CONTENTS;
                this.lblWriter.Text = "作者：" + dt.Rows[0]["REALNAME"].ToString(); ;
                this.lblTime.Text = mNews_News.DATETIME.ToString();
            }


        }

        private void UpdateData(string id)
        {
            List<Dianda.Model.News_LimitUser> lmNews_LimitUser = new List<Dianda.Model.News_LimitUser>();
            lmNews_LimitUser = bNews_LimitUser.GetModelList("UserID='" + ((Model.USER_Users)Session["USER_Users"]).ID + "' and NewsID=" + id);
            if (lmNews_LimitUser.Count > 0)
            {
                foreach (Dianda.Model.News_LimitUser model in lmNews_LimitUser)
                {
                    model.IsRead = 1;
                    model.ReadTime = DateTime.Now;
                    bNews_LimitUser.Update(model);
                }
            }
        }

        protected void OnUnload(EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "a", "window.returnValue = 'refresh';parent.parent.location.reload();", true);
        }


    }
}