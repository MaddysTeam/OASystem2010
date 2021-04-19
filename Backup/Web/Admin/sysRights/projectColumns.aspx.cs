using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Dianda.Web.Admin.sysRights
{
    public partial class projectColumns : System.Web.UI.Page
    {
        BLL.Project_Columns bPojectColumns = new Dianda.BLL.Project_Columns();
        Model.Project_Columns mPojectColumns = new Dianda.Model.Project_Columns();
        COMMON.common commons = new Dianda.COMMON.common();
        COMMON.pageControl cpagecontrol = new Dianda.COMMON.pageControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目分类/规划管理";
                    //设置模板页中的管理值
                   // showlist(DDL_Depart.SelectedItem.Value.ToString());
                    showlist();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 加载原始的分类列表
        /// </summary>
        /// <param name="roletypes"></param>
        private void showlist()
        {
            try
            {
                LinkButton_add.Visible = true;
                LinkButton1_cancel.Visible = true;
                DataTable dt = new DataTable();
                string sql = "select * from Project_Columns where  delflag='0' order by COLUMNSPATH";
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
        /// 显示栏目的下拉
        /// </summary>
        private void showDrop(DropDownList dl,string CID)
        {
            try
            {
                dl.Items.Clear();
                DataTable DT = new DataTable();
                string sql = "";
                if (CID == "")
                {
                    sql = "select * from Project_Columns where  delflag='0' order by COLUMNSPATH";
                }
                else
                {
                  mPojectColumns = bPojectColumns.GetModel(int.Parse(CID));
                    sql = "select * from Project_Columns where  delflag='0' and (COLUMNSPATH NOT LIKE '"+mPojectColumns.COLUMNSPATH.ToString()+"%') order by COLUMNSPATH";
                }
              
                DT = cpagecontrol.doSql(sql).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        string parentid = DT.Rows[i]["UpID"].ToString();
                        string path = DT.Rows[i]["COLUMNSPATH"].ToString();
                         
                        if (parentid != "0")
                        {
                            string kg = null;
                            int lens = path.Split('/').Length;
                            for (int x = 0; x < lens; x++)
                            {
                                kg += "··";
                            }
                            DT.Rows[i]["Names"] = kg + "|--" + DT.Rows[i]["Names"].ToString() + "  [ " + DT.Rows[i]["TYPES"].ToString()+" ]";
                        }
                        ListItem L1 = new ListItem();
                        L1.Text = DT.Rows[i]["Names"].ToString();
                        L1.Value = DT.Rows[i]["ID"].ToString();
                        dl.Items.Add(L1);
                    }
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
        /// 确定提交新的分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_NAME.Text.ToString().Length > 0)
                {
                    mPojectColumns.DATETIME = DateTime.Now;
                    mPojectColumns.DELFLAG = 0;
                    mPojectColumns.Names = TextBox_NAME.Text.ToString();
                    mPojectColumns.TYPES = DropDownList_TYPES.SelectedValue.ToString();
                    mPojectColumns.INFORS = FCKeditor_INFORS.Value.ToString();
                   
                    int id=bPojectColumns.GetMaxId();
                    mPojectColumns.ID = id;
                    string cid = DropDownList_roles.SelectedValue.ToString();//根据这个栏目的ID，获取到该栏目的基本信息 
                    List<Model.Project_Columns> mpclist = bPojectColumns.GetModelList("ID='" + cid + "' and DELFLAG=0");
                    if (mpclist.Count > 0)
                    {
                        mPojectColumns.COLUMNSPATH = mpclist[0].COLUMNSPATH + "/" + id.ToString();
                        mPojectColumns.UpID = mpclist[0].ID;
                        mPojectColumns.PNAMES = mpclist[0].PNAMES + ">" + TextBox_NAME.Text.ToString();
                        mPojectColumns.UserID = mpclist[0].UserID;
                        mPojectColumns.UserInfos = mpclist[0].UserInfos;
                    }

                    bPojectColumns.Add(mPojectColumns);
     
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('添加完成！')", true);

                    addrole.Visible = false;
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目分类/规划管理 > 项目分类/规划列表";
                    //设置模板页中的管理值
                    showlist();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('项目分类/规划名称不能为空！')", true);
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
            Editrole.Visible = false;
            Table_tearch.Visible = false;

            LinkButton_add.Visible = false;
            LinkButton1_cancel.Visible = false;

            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目分类/规划管理 > 添加项目分类/规划"; 
            //设置模板页中的管理值
            GridView1.Visible = false;

            showDrop(DropDownList_roles,"");
        }
        /// <summary>
        /// 取消添加组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit0_Click(object sender, EventArgs e)
        {
           
            Editrole.Visible = false;
            Table_tearch.Visible = false;
            addrole.Visible = false;
            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目分类/规划管理 > 项目分类/规划列表";
            //设置模板页中的管理值
            showlist();
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
                LinkButton_add.Visible = false;
                LinkButton1_cancel.Visible = false;

                string ID = ((LinkButton)sender).CommandArgument.ToString();
                Editrole.Visible = true;
                Table_tearch.Visible = false;
                addrole.Visible = false;
                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目分类/规划管理 > 编辑项目分类/规划";
                //设置模板页中的管理值
                GridView1.Visible = false;
                showDrop(DropDownList_upids, ID);

                showRoles(ID,"");//加载要修改的基本信息
            }
            catch
            {
            }
        }
           /// <summary>
        /// 提交编辑主持人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_editteach_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton_add.Visible = false;
                LinkButton1_cancel.Visible = false;
                string ID = ((LinkButton)sender).CommandArgument.ToString();
                Table_tearch.Visible = true;
                addrole.Visible = false;
                Editrole.Visible = false;
                
                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目分类/规划管理 > 编辑项目分类/规划主持";
                //设置模板页中的管理值
                GridView1.Visible = false;
                showRoles(ID,"lab");//加载要修改的基本信息

            }
            catch
            {
            }
        }
        
        /// <summary>
        /// 显示指定权限的信息
        /// </summary>
        /// <param name="id"></param>
        private void showRoles(string id,string type)
        {
            try
            {
                 HiddenField_ID.Value = id;
                 mPojectColumns = bPojectColumns.GetModel(int.Parse(id));
                 if (type == "lab")
                 {
                     Label_names.Text = mPojectColumns.Names.ToString();
                     Label_path.Text = mPojectColumns.PNAMES.ToString();

                     shareForUser1.Visible = true;

                     string users = mPojectColumns.UserID.ToString();//之前被选择的人员
                     DataTable dt = new DataTable();
                     if (users == "" || users == null)
                     {
                         dt = null;
                     }
                     else
                     {
                         users = commons.makeSqlIn(users, ',');
                         string sqls = "select ID AS ShareForUser from USER_Users WHERE ID IN " + users;
                         dt = cpagecontrol.doSql(sqls).Tables[0];
                     }
                     shareForUser1.showDepartment(dt);
                 }
                 else
                 {
                     shareForUser1.Visible = false;
                     //mUsergroup = bUsergroup.GetModel(id);
                     TextBox_NAME2.Text = mPojectColumns.Names.ToString();
                     DropDownList_upids.SelectedValue = mPojectColumns.UpID.ToString();

                     DropDownList_types2.SelectedValue = mPojectColumns.TYPES.ToString();
                     FCKeditor_infors2.Value = mPojectColumns.INFORS.ToString();

                     if (mPojectColumns.UpID.ToString() == "0")
                     {
                         DropDownList_upids.Enabled = false;
                     }
                     else

                     {
                         DropDownList_upids.Enabled = true;
                     }
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
            addrole.Visible = false;
            LinkButton_add.Visible = true;
            LinkButton1_cancel.Visible = true;

            Table_tearch.Visible = false;
            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目分类/规划管理 > 项目分类/规划列表";
            //设置模板页中的管理值
            showlist();
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
                    string id = HiddenField_ID.Value.ToString();
                    mPojectColumns = bPojectColumns.GetModel(int.Parse(id));

                    mPojectColumns.Names= TextBox_NAME2.Text.ToString();
                    mPojectColumns.INFORS = FCKeditor_infors2.Value.ToString();
                    mPojectColumns.TYPES = DropDownList_types2.SelectedValue.ToString();

                    string cid = DropDownList_upids.SelectedValue.ToString();

                    if (mPojectColumns.UpID == 0)
                    {
                        mPojectColumns.PNAMES =TextBox_NAME2.Text.ToString();
                    }
                    else
                    {
                        if (cid != id)
                        {
                            List<Model.Project_Columns> mpclist = bPojectColumns.GetModelList("ID='" + cid + "' and DELFLAG=0");
                            if (mpclist.Count > 0)
                            {
                                mPojectColumns.COLUMNSPATH = mpclist[0].COLUMNSPATH + "/" + id.ToString();
                                mPojectColumns.UpID = mpclist[0].ID;
                                mPojectColumns.PNAMES = mpclist[0].PNAMES + ">" + TextBox_NAME2.Text.ToString();
                                mPojectColumns.UserID = mpclist[0].UserID;
                                mPojectColumns.UserInfos = mpclist[0].UserInfos;
                            }
                        }
                        else
                        {
                            string[] olders = mPojectColumns.PNAMES.Split('>');
                            string orders2 = "";
                            for (int i = 0; i < olders.Length - 1; i++)
                            {
                                orders2 = orders2 + olders[i].ToString() + ">";
                            }
                            mPojectColumns.PNAMES = orders2 + TextBox_NAME2.Text.ToString();
                        }
                    }
                    bPojectColumns.Update(mPojectColumns);
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('修改完成！')", true);

                    Editrole.Visible = false;
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目分类/规划管理 > 项目分类/规划列表";
                    //设置模板页中的管理值
                    showlist();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('项目分类/规划不能为空！')", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('操作失败，请重试！')", true);
            }
        }
        /// <summary>
        /// 修改栏目的权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_columns_Click(object sender, EventArgs e)
        {
            try
            {
                string id = HiddenField_ID.Value.ToString();
                mPojectColumns = bPojectColumns.GetModel(int.Parse(id));
               ArrayList al=shareForUser1.getSelectUser();//用户的ID
               ArrayList alinfo = shareForUser1.getSelectUserInfo();//用户的基本信息
               string userid = "";
               string userinfo = "";
               for (int i = 0; i < al.Count; i++)
               {
                   if (i == al.Count - 1)
                   {
                       userid = userid + al[i].ToString();
                   }
                   else
                   {
                       userid = userid + al[i].ToString() + ",";
                   }
               }
               for (int i = 0; i < alinfo.Count; i++)
               {
                   if (i == alinfo.Count - 1)
                   {
                       userinfo = userinfo + alinfo[i].ToString();
                   }
                   else
                   {
                       userinfo = userinfo + alinfo[i].ToString() + ",";
                   }
               }
               mPojectColumns.UserID = userid;
               mPojectColumns.UserInfos = userinfo;
               bPojectColumns.Update(mPojectColumns);
               ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('修改完成！')", true);

               Table_tearch.Visible = false;
               //设置模板页中的管理值
               (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 项目分类/规划管理 > 项目分类/规划列表";
               //设置模板页中的管理值
               showlist();
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

        protected void LinkButton1_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/SystemProjectManage/ProjectInfo/manage.aspx");

        }
      
    }
}
