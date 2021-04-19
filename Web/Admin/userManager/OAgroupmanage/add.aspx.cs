using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.userManager.OAgroupmanage
{
    public partial class add : System.Web.UI.Page
    {
        Dianda.COMMON.USER_GroupsExt user_groupsext = new Dianda.COMMON.USER_GroupsExt();
        Dianda.Model.USER_Groups userGroupModel = new Dianda.Model.USER_Groups();
        Dianda.COMMON.common commonID = new Dianda.COMMON.common();//引入通用操作类
        Dianda.BLL.USER_Groups userGroups = new Dianda.BLL.USER_Groups();
        Dianda.Model.News_Columns newcolumns_model = new Dianda.Model.News_Columns();
        Dianda.BLL.News_Columns newcolumns_bll = new Dianda.BLL.News_Columns();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string tags = Request["tags"];
                LB_NAME1.Text = tags.ToString();
                LB_NAME2.Text = tags.ToString();
                //add by wangjh on 2010-08-09 在执行添加之前需要先对输入框进行校验。
                //this.Button_sumbit.Attributes.Add("onclick", "return check();");

                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 人事管理 ";
                //设置模板页中的管理值
            }
        }

        /// <summary>
        /// 确定添加新用户组
        /// 1.添加新用户组前要检测该用户组的名称是否已经在系统中注册，如果注册过了，则提醒用户重复，要求用户重新命名
        /// 2.添加该用户进数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_queding_Click(object sender, EventArgs e)
        {
            try
            {
                string NAME_1 = NAME.Text.ToString();//获取到用户组的名字
                string CONTENTS_1 = CONTENT.Text.ToString();//获取到用户组的说明

                //检查该名称是否有了
                if (NAME_1 != "")
                {
                    bool checkName = user_groupsext.Exists_Name(NAME_1, "");//检查是否有该用户组名称
                    if (checkName)
                    {
                        tag.Text = "该" + Request["tags"] + "名称与已有的部门或岗位名称相同，请修改！";
                    }
                    else
                    {
                        userGroupModel.ID = commonID.GetGUID();//获取到GUID作为ID
                        userGroupModel.CONTENTS = CONTENTS_1;
                        userGroupModel.DELFLAG = 0;
                        userGroupModel.ISMOREN = 0;
                        userGroupModel.NAME = NAME_1;
                        //userGroupModel.ROLE = selectRoles;
                        if (Request["tags"].ToString().Equals("部门"))
                        {
                            userGroupModel.TAGS = "部门";
                            userGroups.Add(userGroupModel);

                            //部门添加成功以后往信息栏目表中添加一条记录
                            Dianda.BLL.News_ColumnsExt columnext_bll = new Dianda.BLL.News_ColumnsExt();
                            columnext_bll.addCloumns(userGroupModel.NAME, "DEPARTMENT", userGroupModel.ID,3);

                            ////ID
                            //newcolumns_model.ID = newcolumns_bll.GetMaxId();
                            ////名称=部门的名称
                            //newcolumns_model.NAME = userGroupModel.NAME;
                            ////PARENTID
                            //newcolumns_model.PARENTID = -1;
                            ////栏目的归属
                            //newcolumns_model.ForItems = "DEPARTMENT";
                            ////如果栏目是部门的栏目，则这边保存部门的ID
                            //newcolumns_model.ItemsID = userGroupModel.ID;
                            ////时间
                            //newcolumns_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
                            ////是否显示发布人的信息
                            //newcolumns_model.ISMENU = 0;
                            ////是否需要审核
                            //newcolumns_model.ISSHENHE = 0;
                            ////单条新闻
                            //newcolumns_model.ONLYONE = 0;
                            ////新闻删除标记
                            //newcolumns_model.DELFLAG = 0;
                            ////栏目的路径记录
                            //newcolumns_model.COLUMNSPATH = "0/" + newcolumns_model.ID;
                            ////栏目显示的顺序
                            //newcolumns_model.SHUNXU = 0;
                            ////栏目的图片
                            //newcolumns_model.IMAGEURL = "";
                            ////栏目的路径名称
                            //newcolumns_model.PNAMES = userGroupModel.NAME;

                            //newcolumns_bll.Add(newcolumns_model);
                        }
                        else
                        {
                            userGroupModel.TAGS = "岗位";
                            userGroups.Add(userGroupModel);
                        }

                        tag.Text = "操作成功！";

                        string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?tags=" + Request["tags"].ToString() + "\";</script>";


                        Response.Write(coutws);
                        
                        //添加操作日志

                        Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                        Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                        bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加新" + Request["tags"].ToString(), "添加" + newcolumns_model.NAME+ "成功");
                        //添加操作日志
                    }
                }
            }
            catch
            {
                tag.Text = "操作失败，请重试！";
            }
        }
        /// <summary>
        /// 重置按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_chongzhi_Click(object sender, EventArgs e)
        {
            try
            {
                NAME.Text = "";
                CONTENT.Text = "";
            }
            catch
            {
 
            }
        }
        /// <summary>
        /// 返回按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx?tags=" + Request["tags"].ToString());
        }
    }
}
