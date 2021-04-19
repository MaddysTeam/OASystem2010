using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.guestBook
{
    public partial class add1 : System.Web.UI.UserControl
    {
        BLL.GUESTBOOK_MAIN guestBookBll = new Dianda.BLL.GUESTBOOK_MAIN();
        Model.GUESTBOOK_MAIN guestBookModel = new Dianda.Model.GUESTBOOK_MAIN();
        Dianda.COMMON.common commonId = new Dianda.COMMON.common();
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckBox_issend.Checked = false;
            }
        }
        /// <summary>
        /// 提交留言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckBox_issend.Checked)
            {
                try
                {
                    guestBookModel.ID = commonId.GetGUID();
                    guestBookModel.TITLES = TextBox_email.Text.ToString();
                    guestBookModel.CLASSID = TextBox_tel.Text.ToString();
                    guestBookModel.CONTENTS = TextBox2_content.Text;
                    guestBookModel.DATETIME = DateTime.Now;
                    guestBookModel.STATUS = 0;
                    guestBookModel.WRITER = TextBox1_Writer.Text.ToString();
                    guestBookModel.DELFLAG = 0;
                    guestBookModel.COURSEID = TextBox_compan.Text.ToString();
                    guestBookBll.Add(guestBookModel);
                    Label_notice.Text = "√提交成功，请等待管理员回复！";
                    CheckBox_issend.Checked = false;
                }
                catch
                {
                    Label_notice.Text = "×提交失败，请重新操作！";
                }
            }
            else
            {
                Label_notice.Text = "!请先勾选“确定提交以上内容”,谢谢！";
            }
        }
    }
}