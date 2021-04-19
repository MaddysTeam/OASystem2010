using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.userManager.OAgroupmanage
{
    public partial class modify : System.Web.UI.Page
    {
        Dianda.Model.USER_Groups userGroupModel = new Dianda.Model.USER_Groups();
        Dianda.BLL.USER_Groups userGroups = new Dianda.BLL.USER_Groups();
        Dianda.COMMON.USER_GroupsExt user_groupsext = new Dianda.COMMON.USER_GroupsExt();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //部门或岗位标识
                string tag = Request["tags"].ToString();
                //部门或岗位ID
                string ID = Request["ID"].ToString();

                LB_NAME1.Text = tag;
                LB_NAME2.Text = tag;

                //获取到当前部门或岗位的基本信息
                userGroupModel = userGroups.GetModel(ID);

                NAME.Text = userGroupModel.NAME;
                CONTENT.Text = userGroupModel.CONTENTS;

                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 人事管理 ";
                //设置模板页中的管理值
            }
        }
        /// <summary>
        /// 点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_queding_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = Request["ID"];////获取到当前要修改的用户组的ID
                string NAME_1 = NAME.Text.ToString();//获取到用户组的名字
                string CONTENTS_1 = CONTENT.Text.ToString();//获取到用户组的说明

                //检查该名称是否有了

                bool checkName = user_groupsext.Exists_Name(NAME_1, ID);//检查是否有该用户组名称
                if (checkName)
                {
                    tag.Text = "该" + Request["tags"] + "名称与已有的部门或岗位名称相同，请修改！";
                }
                else
                {
                    userGroupModel.ID = ID;
                    userGroupModel.CONTENTS = CONTENTS_1;
                    userGroupModel.DELFLAG = 0;
                    userGroupModel.ISMOREN = 0;
                    userGroupModel.NAME = NAME_1;
                    //userGroupModel.ROLE = selectRoles;
                    if (Request["tags"].ToString().Equals("部门"))
                    {
                        userGroupModel.TAGS = "部门";
                    }
                    else
                    {
                        userGroupModel.TAGS = "岗位";
                    }
                    userGroups.Update(userGroupModel);

                    tag.Text = "操作成功！";
                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?tags=" + Request["tags"].ToString() + "\";</script>";
                    Response.Write(coutws);

                    //添加操作日志

                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "编辑" + Request["tags"].ToString(), "编辑" + NAME_1 + "成功");

                    //添加操作日志
                }
            }
            catch
            {
                tag.Text = "操作失败，请重试！";
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
