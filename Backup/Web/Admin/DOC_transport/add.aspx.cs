using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DOC_transport
{
    public partial class add : System.Web.UI.Page
    {
        COMMON.common commnid = new Dianda.COMMON.common();

        COMMON.FileControl FCL = new COMMON.FileControl();//应用文件上传的控件
        BLL.DOC_transport_From docFromBll = new Dianda.BLL.DOC_transport_From();
        BLL.DOC_transport_To docToBll = new Dianda.BLL.DOC_transport_To();

        Model.DOC_transport_From docFromModel = new Dianda.Model.DOC_transport_From();
        Model.DOC_transport_To docToModel = new Dianda.Model.DOC_transport_To();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch
            {
            }
        }
        /// <summary>
        /// 确定添加公文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_queding_Click(object sender, EventArgs e)
        {
            string coutw = "";
            try
            {
                string userlist = Session["userList_temps_chooseUser"].ToString();
                string TextBox_NAME_1 = TextBox_NAME.Text.ToString();
                string content = "";
                int x = 0;
               
                if (userlist.Length > 0)
                {
                    if (FileUpload_sl.FileName.Length > 0)
                    {
                        content = FCL.UpFile(FileUpload_sl, "/AllFileUp/doc_trasport");//上传文件
                        if (content == "0")
                        {
                            x = 1;
                        }

                        else if (content == "3")
                        {
                            x = 3;
                        }
                        else if (content == "1")
                        {
                            x = 0;
                        }
                        if (x == 1)
                        {

                            coutw = "<script language=\"javascript\" type=\"text/javascript\">alert(\"文件上传失败，请重新上传！\");</script>";
                        }
                        if (x == 3)
                        {

                            coutw = "<script language=\"javascript\" type=\"text/javascript\">alert(\"系统不允许此类文件上传,文件上传失败，请重新上传！\");</script>";
                        }
                        else
                        {
                            doSave(Session["USERNAME_SYSUSER"].ToString(), userlist, content, TextBox_NAME_1);
                           // coutw = "操作成功！";
                            coutw = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");location.href = \"manage.aspx\";</script>";
                        }
                    }
                    else
                    {
                        //可以添加到表中
                        doSave(Session["USERNAME_SYSUSER"].ToString(), userlist, content, TextBox_NAME_1);
                        //coutw = "操作成功！";
                        coutw = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！\");location.href = \"manage.aspx\";</script>";
                    }

                }
                else
                {
                  //  coutw = "操作失败！请选择接收该公文的用户！";
                    coutw = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作失败！请选择接收该公文的用户！\");</script>";
                }

              
            }
            catch
            {
               // coutw = "操作失败！请选择接收该公文的用户！";
                coutw = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作失败！请选择接收该公文的用户！\");</script>";
            }
          //  coutw = "<script language=\"javascript\" type=\"text/javascript\">alert(\"" + coutw + "\"); location.href = \"manage.aspx\";</script>";
            Session["userList_temps_chooseUser"] = "";//清空收件人列表
            Response.Write(coutw);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userfrom"></param>
        /// <param name="usertolist"></param>
        /// <param name="filename"></param>
        /// <param name="titlename"></param>
        private void doSave(string userfrom,string usertolist,string filename,string titlename)
        {
            //可以添加到表中
            docFromModel.ID = commnid.GetGUID();
            docFromModel.DATETIME = DateTime.Now;
            docFromModel.DELFLAG = 0;
            docFromModel.FILEPATH = filename;
            docFromModel.FROMUSER = userfrom;
            docFromModel.TITLES = titlename;
            docFromModel.TOUSER = usertolist;

            docFromBll.Add(docFromModel);//添加到发件箱

            string[] userarray = usertolist.Split(',');
            for (int i = 0; i < userarray.Length; i++)
            {
                if (userarray[i].Length > 0)
                {
                    docToModel.DATETIME = DateTime.Now;
                    docToModel.DELFLAG = 0;
                    docToModel.FILEPATH = filename;
                    docToModel.FROMUSER = userfrom;
                    docToModel.ID = commnid.GetGUID();
                    docToModel.ISREAD = 0;
                    docToModel.READTIME = null;
                    docToModel.TITLES = titlename;
                    docToModel.TOUSER = userarray[i].ToString();

                    docToBll.Add(docToModel);//添加到收件箱
                }
            }
        }
      
    }
}
