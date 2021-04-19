using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.sysRights
{
    public partial class roleM : System.Web.UI.Page
    {
        BLL.USER_Role bUserrole = new Dianda.BLL.USER_Role();
        Model.USER_Role mUserrole = new Dianda.Model.USER_Role();
        COMMON.pageControl cpagecontrol = new Dianda.COMMON.pageControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 权限管理 > 权限列表";
                    //设置模板页中的管理值
                    showlist(DDL_Depart.SelectedItem.Value.ToString());

                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据权限的类型，加载权限
        /// </summary>
        /// <param name="roletypes"></param>
        private void showlist(string roletypes)
        {
            try
            {
                DataTable dt = new DataTable();
               // dt = bUserrole.GetList("Types='" + roletypes + "' and delflag='0' order by upid,name").Tables[0];
                string sql = "select * from vUSER_Role where Types='" + roletypes + "' and delflag='0' order by upid,name";
                dt = cpagecontrol.doSql(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }
                else
                {
                    GridView1.Visible = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 显示页面权限的列表，作为按钮权限的上级栏目
        /// </summary>
        private void showAnniuupid(DropDownList dl)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = bUserrole.GetList("Types='页面权限' and delflag='0' order by upid,name").Tables[0];
               
                if (dt.Rows.Count > 0)
                {
                    dl.DataSource = dt;
                    dl.DataTextField = "NAME";
                    dl.DataValueField = "ID";
                    dl.DataBind();
                }
                else
                {

                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据筛选加载列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Depart_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                showlist(DDL_Depart.SelectedItem.Value.ToString());
                addrole.Visible = false;
                Editrole.Visible = false;
            }
            catch
            {
            }
        }
        /// <summary>
        /// 到组管理里面去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_groupM_Click(object sender, EventArgs e)
        {
            Response.Redirect("groupM.aspx");
        }
        /// <summary>
        /// 确定提交新的权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_NAME.Text.ToString().Length > 0)
                {
                    mUserrole.DELFLAG = 0;
                    mUserrole.NAME = TextBox_NAME.Text.ToString();
                    mUserrole.Roles = TextBox_roles.Text.ToString();
                    mUserrole.Types = DropDownList_roles.SelectedItem.Value.ToString();
                    if (DropDownList_roles.SelectedItem.Value == "按钮权限")
                    {
                        mUserrole.UpID = int.Parse(DropDownList_upid.SelectedItem.Value.ToString());
                    }
                    else
                    {
                        mUserrole.UpID = 0;
                    }
                    bUserrole.Add(mUserrole);
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('添加完成！')", true);

                    addrole.Visible = false;
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 权限管理 > 权限列表";
                    //设置模板页中的管理值
                    showlist(DropDownList_roles.SelectedItem.Value.ToString());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('权限名称不能为空！')", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('操作失败，请重试！')", true);
            }
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_add_Click(object sender, EventArgs e)
        {
            addrole.Visible = true;
            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 权限管理 > 添加权限";
            //设置模板页中的管理值
            GridView1.Visible = false;
            showAnniuupid(DropDownList_upid);//加载页面权限列表
        }
        /// <summary>
        /// 取消添加权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit0_Click(object sender, EventArgs e)
        {
            addrole.Visible = false;
            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 权限管理 > 权限列表";
            //设置模板页中的管理值
            showlist(DDL_Depart.SelectedItem.Value.ToString());
        }
        /// <summary>
        /// 当权限类型发生变化后，要做上级栏目的选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string anniuquanxian = DropDownList_roles.SelectedItem.Value.ToString();
                if (anniuquanxian == "按钮权限")
                {
                    upid.Visible = true;
                }
                else
                {
                    upid.Visible = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 提交编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_edit_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = ((LinkButton)sender).CommandArgument.ToString();
                Editrole.Visible = true;
                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 权限管理 > 编辑权限";
                //设置模板页中的管理值
                GridView1.Visible = false;
                showAnniuupid(DropDownList_upid2);//加载页面权限列表
                showRoles(ID);//加载要修改的基本信息
            }
            catch
            {
            }
        }
        /// <summary>
        /// 显示指定权限的信息
        /// </summary>
        /// <param name="id"></param>
        private void showRoles(string id)
        {
            try
            {
                HiddenField_ID.Value = id;
                mUserrole = bUserrole.GetModel(int.Parse(id));
                TextBox_NAME2.Text = mUserrole.NAME.ToString();
                TextBox_roles2.Text = mUserrole.Roles.ToString();
                DropDownList_roles2.SelectedValue = mUserrole.Types.ToString();
                if (mUserrole.Types.ToString() == "按钮权限")
                {
                    Tr1.Visible = true;
                    DropDownList_upid2.SelectedValue = mUserrole.UpID.ToString();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 修改时的筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_roles2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string anniuquanxian = DropDownList_roles2.SelectedItem.Value.ToString();
                if (anniuquanxian == "按钮权限")
                {
                    Tr1.Visible = true;
                }
                else
                {
                    Tr1.Visible = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 取消修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Editrole.Visible = false;
            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 权限管理 > 权限列表";
            //设置模板页中的管理值
            showlist(DDL_Depart.SelectedItem.Value.ToString());
        }
        /// <summary>
        /// 提交修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_NAME2.Text.ToString().Length > 0)
                {
                    int id = int.Parse(HiddenField_ID.Value.ToString());
                    mUserrole = bUserrole.GetModel(id);
                    mUserrole.DELFLAG = 0;
                    mUserrole.NAME = TextBox_NAME2.Text.ToString();
                    mUserrole.Roles = TextBox_roles2.Text.ToString();
                    mUserrole.Types = DropDownList_roles2.SelectedItem.Value.ToString();
                    if (DropDownList_roles2.SelectedItem.Value == "按钮权限")
                    {
                        mUserrole.UpID = int.Parse(DropDownList_upid2.SelectedItem.Value.ToString());
                    }
                    else
                    {
                        mUserrole.UpID = 0;
                    }
                    bUserrole.Update(mUserrole);
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('修改完成！')", true);

                    Editrole.Visible = false;
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 权限管理 > 权限列表";
                    //设置模板页中的管理值
                    showlist(DropDownList_roles2.SelectedItem.Value.ToString());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('权限名称不能为空！')", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('操作失败，请重试！')", true);
            }
        }
       /// <summary>
       /// f返回到人员配置的地方
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void LinkButton_roleM_Click(object sender, EventArgs e)
        {
            Response.Redirect("setRight.aspx");
        }
    }
}
