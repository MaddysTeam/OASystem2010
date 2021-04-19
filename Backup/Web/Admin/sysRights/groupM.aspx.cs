using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Dianda.Web.Admin.sysRights
{
    public partial class groupM : System.Web.UI.Page
    {
        BLL.USER_Role bUserrole = new Dianda.BLL.USER_Role();
        Model.USER_Role mUserrole = new Dianda.Model.USER_Role();
        BLL.USER_Groups bUsergroup = new Dianda.BLL.USER_Groups();
        Model.USER_Groups mUsergroup = new Dianda.Model.USER_Groups();
        COMMON.common commons = new Dianda.COMMON.common();
        COMMON.pageControl cpagecontrol = new Dianda.COMMON.pageControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 组管理 > 用户组列表";
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
                string sql = "select * from USER_Groups where TAGS='" + roletypes + "' and delflag='0' order by NAME";
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
        /// 到权限里面去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_groupM_Click(object sender, EventArgs e)
        {
            Response.Redirect("roleM.aspx");
        }
        /// <summary>
        /// 确定提交新的组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_NAME.Text.ToString().Length > 0)
                {
                    mUsergroup.DELFLAG = 0;
                    mUsergroup.ISMOREN = 0;
                    mUsergroup.NAME = TextBox_NAME.Text.ToString();
                    mUsergroup.ISMOREN = 0;// int.Parse(TextBox_ISMOREN.Text.ToString());
                    mUsergroup.TAGS = DropDownList_roles.SelectedItem.Value.ToString();
                    ArrayList al = rolemodel1.getSelectUser();
                     string rols = "";
                    if (al.Count > 0)
                    {
                        for (int i = 0; i < al.Count; i++)
                        {
                            if (i == al.Count - 1)
                            {
                                rols = rols + al[i].ToString();
                            }
                            else
                            {
                                rols = rols + al[i].ToString() + ",";
                            }
                        }
                    }
                    mUsergroup.ROLE = rols;
                    mUsergroup.ID = commons.GetGUID();
                    bUsergroup.Add(mUsergroup);
                   
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('添加完成！')", true);

                    addrole.Visible = false;
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 组管理 > 用户组列表";
                    //设置模板页中的管理值
                    showlist(DropDownList_roles.SelectedItem.Value.ToString());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('组名称不能为空！')", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('操作失败，请重试！')", true);
            }
        }
        /// <summary>
        /// 添加组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_add_Click(object sender, EventArgs e)
        {
            addrole.Visible = true;
            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 组管理 > 添加组";
            //设置模板页中的管理值
            GridView1.Visible = false;
            rolemodel1.showDepartment("");
        }
        /// <summary>
        /// 取消添加组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit0_Click(object sender, EventArgs e)
        {
            addrole.Visible = false;
            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 组管理 > 组列表";
            //设置模板页中的管理值
            showlist(DDL_Depart.SelectedItem.Value.ToString());
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
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 组管理 > 编辑组";
                //设置模板页中的管理值
                GridView1.Visible = false;
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
                mUsergroup = bUsergroup.GetModel(id);
                TextBox_NAME2.Text = mUsergroup.NAME.ToString();
                TextBox_ISMOREN2.Text = mUsergroup.ISMOREN.ToString();
                rolemodel2.showDepartment(mUsergroup.ROLE.ToString());
                if (mUsergroup.DELFLAG == 0)
                {
                    CheckBox_del.Checked = false;
                }
                else
                {
                    CheckBox_del.Checked = true;
                }

                if (mUsergroup.TAGS == "普通组")
                {
                    shunxuhao.Visible = false;
                }
                else
                {
                    shunxuhao.Visible = true;
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
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 组管理 > 组列表";
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
                    string  id =HiddenField_ID.Value.ToString();
                    mUsergroup = bUsergroup.GetModel(id);

                    mUsergroup.DELFLAG = 0;
                    mUsergroup.NAME = TextBox_NAME2.Text.ToString();
                    mUsergroup.ISMOREN =int.Parse(TextBox_ISMOREN2.Text.ToString());
                    if (CheckBox_del.Checked)
                    {
                        mUsergroup.DELFLAG = 1;
                    }

                    ArrayList al = rolemodel2.getSelectUser();
                    string rols = "";
                    if (al.Count > 0)
                    {
                        for (int i = 0; i < al.Count; i++)
                        {
                            if (i == al.Count - 1)
                            {
                                rols = rols + al[i].ToString();
                            }
                            else
                            {
                                rols = rols + al[i].ToString() + ",";
                            }
                        }
                    }
                    mUsergroup.ROLE = rols;

                    bUsergroup.Update(mUsergroup);
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('修改完成！')", true);

                    Editrole.Visible = false;
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 组管理 > 组列表";
                    //设置模板页中的管理值
                    showlist(mUsergroup.TAGS.ToString());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('组名称不能为空！')", true);
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
        /// <summary>
        /// 设置默认组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_ismoren_Click(object sender, EventArgs e)
        {
            try
            {
                string id = ((LinkButton)sender).CommandArgument.ToString();//获取到当前的按钮上携带的ID
                //先将原本的默认值设置为非默认值，然后将当前的ID的值设置为默认值
                List<Model.USER_Groups> usergroupslist = bUsergroup.GetModelList("ISMOREN='1' and TAGS='普通组' and DELFLAG='0'");
                if (usergroupslist.Count > 0)
                {
                    for (int i = 0; i < usergroupslist.Count; i++)
                    {
                        usergroupslist[i].ISMOREN = 0;
                        bUsergroup.Update(usergroupslist[i]);
                    }
                }

                mUsergroup = bUsergroup.GetModel(id);
                if (mUsergroup != null)
                {
                    mUsergroup.ISMOREN = 1;
                    bUsergroup.Update(mUsergroup);
                }
                showlist(DDL_Depart.SelectedItem.Value.ToString());
            }
            catch
            {
            }
        }
        /// <summary>
        /// 当列表被加载的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");
                    
                    string TAGS = DataBinder.Eval(e.Row.DataItem, "TAGS").ToString();
                    string ISMOREN = DataBinder.Eval(e.Row.DataItem, "ISMOREN").ToString();
                    LinkButton domoren = (LinkButton)e.Row.Cells[3].FindControl("LinkButton_ismoren");
                   
                    if (TAGS == "普通组")
                    {
                        if (ISMOREN == "1")
                        {
                            domoren.Text = "默认组";
                            domoren.Enabled = false;
                            e.Row.Cells[2].Text = "<font color='red'>默认组</font>";
                        }
                        else
                        {
                            domoren.Text = "非默认-[点击设置]";
                            domoren.Enabled = true;
                            e.Row.Cells[2].Text = "<font color='blue'>非默认</font>";
                        }
                        domoren.Visible = true;
                     
                    }
                    else
                    {
                        domoren.Visible = false;
                    }
                }
            }
            catch
            { }
        }
    }
}
