using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OACashApply
{
    public partial class uploadfilesups : System.Web.UI.Page
    {
        Dianda.COMMON.fileUploads fileup = new Dianda.COMMON.fileUploads();
        Dianda.BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();
        Dianda.Model.Project_Projects project_model = new Dianda.Model.Project_Projects();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 确定按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_submit_Click(object sender,EventArgs e)
        {
            try
            {
                project_model = project_bll.GetModel(int.Parse(Session["Work_ProjectId"].ToString()));

                if (null != Request["role"] && Request["role"].ToString().Equals("manager"))
                {
                    //说明是领导审批项目经费时重新上传的预算表单
                }
                else
                {
                    if (project_model.TEMP1.Equals("1") || project_model.TEMP1.Equals("3"))
                    {
                        tag.Text = "该项目上传的预算表单已经审核通过！不能再次上传!";
                        return;
                    }

                    if (FileUpload_list.FileName.Length <= 0)
                    {
                        tag.Text = "上传预算表单项不能为空！";
                        return;
                    }
                }


                if (FileUpload_list.FileName.Length > 2)
                {
                    string[] content = fileup.UpFile_COMMONS(FileUpload_list, "/AllFileUp/fileup", "");
                    //1-成功；0-失败；2-类型不支持；3-大小不符合;文件的路径；文件名称；文件类型；图标；大小；操作结果
                    if (content[0] == "0")
                    {
                        tag.Text = "文件上传失败，请重新上传！";
                        return;
                    }
                    else if (content[0] == "2")
                    {
                        tag.Text = "系统不允许此类文件上传,文件上传失败，请重新上传！";
                        return;
                    }
                    else if (content[0] == "3")
                    {
                        tag.Text = "文件上传大小不符合，文件上传失败，请重新上传！";
                        return;
                    }

                    if (null != Request["role"] && Request["role"].ToString().Equals("manager"))
                    {
                        project_model.BudgetList = project_model.BudgetList+"@"+ content[1];
                    }
                    else
                    {
                        project_model.BudgetList = content[1];
                    }

                }


                if (!CashTotal.Text.ToString().Equals(""))
                {
                    if (null != Request["role"] && Request["role"].ToString().Equals("manager"))
                    {
                        if (RB_cashtotal.SelectedValue.ToString().Equals("1"))//表示经费单位选择的是万元
                        {
                            //领导在审批时重新上传预算表单时重新写的经费额。
                            project_model.TEMP2 = (Convert.ToDecimal(CashTotal.Text.ToString())).ToString()+"万元";
                        }
                        else
                        {
                            project_model.TEMP2 = (Convert.ToDecimal(CashTotal.Text.ToString())).ToString()+"元";
                        }
                    }
                    else
                    {
                        if (RB_cashtotal.SelectedValue.ToString().Equals("1"))//表示经费单位选择的是万元
                        {
                            //经费额度存放的是元
                            project_model.CashTotal = Convert.ToDecimal(CashTotal.Text.ToString()) * 10000;
                            //经费单位
                            project_model.CashDw = "万元";
                        }
                        else
                        {
                            project_model.CashTotal = Convert.ToDecimal(CashTotal.Text.ToString());
                            //经费单位
                            project_model.CashDw = "元";
                        }
                    }

                }
               //预算表单的审核状态
                if (null != Request["role"] && Request["role"].ToString().Equals("manager"))
                {
                    //
                }
                else
                {
                    project_model.TEMP1 = "0";
                }

                project_bll.Update(project_model);


                //给业务申请者发信息
                Model.FaceShowMessage mFaceShowMessage = new Dianda.Model.FaceShowMessage();
                Model.FaceShowMessage mFaceShowMessage2 = new Dianda.Model.FaceShowMessage();
                BLL.FaceShowMessage bFaceShowMessage = new Dianda.BLL.FaceShowMessage();

                //DataTable dt = bFaceShowMessage.GetList("FromTable='预算表单' and NewsType='预算表单审批' and ProjectID='" + project_model.ID.ToString() + "'").Tables[0];
                List<Model.FaceShowMessage> facelist = bFaceShowMessage.GetModelList("FromTable='预算表单' and NewsType='预算表单审批' and ProjectID='" + project_model.ID.ToString() + "'");

                mFaceShowMessage.DATETIME = DateTime.Now;
                mFaceShowMessage.FromTable = "预算表单";
                mFaceShowMessage.IsRead = 0;
                mFaceShowMessage.NewsID = null;
                mFaceShowMessage.NewsType = "预算表单审批";
                mFaceShowMessage.ReadTime = null;
                mFaceShowMessage.DELFLAG = 0;
                mFaceShowMessage.ProjectID = project_model.ID;
                mFaceShowMessage.Receive = project_model.DoUserID.ToString();//当前项目的审核人的ID
                mFaceShowMessage.URLS = "<a href='/Admin/budgetManage/manage.aspx?role=manager' target='_self' title='项目预算表单'>" + project_model.NAMES.ToString() + "  预算表单 待审</a>";

                if (facelist.Count > 0)
                {
                    mFaceShowMessage2 = facelist[0];
                    mFaceShowMessage2.DELFLAG = 1;

                   // mFaceShowMessage.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                    bFaceShowMessage.Update(mFaceShowMessage2);
                    bFaceShowMessage.Add(mFaceShowMessage);
                }
                else
                {
                    bFaceShowMessage.Add(mFaceShowMessage);
                }
                //给业务申请者发信息

                string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"预算表单上传成功! \");window.close();</script>";

                Response.Write(coutws);

            }
            catch
            {
 
            }
        }
    }
}
