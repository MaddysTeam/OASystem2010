using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Dianda.Web.Admin.sysRights
{
    public partial class rolemodel : System.Web.UI.UserControl
    {
        COMMON.pageControl pagedosql = new Dianda.COMMON.pageControl();
        BLL.USER_Role buRole = new Dianda.BLL.USER_Role();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 按部门将所有的用户呈现，并且将已经选择的用户selectUser在列表上显示出来
        /// </summary>
        /// <param name="selectUser"></param>
        public void showDepartment(string  selectRoles)
        {
            try
            {
                 
                //获取到所有的用户按钮权限
                string sql = "SELECT   ID, NAME, ROLES,TYPES,UPID FROM USER_Role WHERE (DELFLAG = '0' and Types='按钮权限') ORDER BY UPID,name";
                DataTable dt2 = pagedosql.doSql(sql).Tables[0];
                Session["temp_Roles_session"] = dt2;
                Session["temp_rolesSelect_session"] = selectRoles;
                //
                DataTable dt = new DataTable();
                dt = buRole.GetList(" Types<>'按钮权限' and DELFLAG='0' order by NAME").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView_grouplist.DataSource = dt;
                    GridView_grouplist.DataBind();
                    GridView_grouplist.Visible = true;
                }
                else
                {
                    GridView_grouplist.Visible = false;
                }

            }
            catch
            {
            }
        }
        /// <summary>
        /// 将全部的用户和现在已经选择的用户对应着放入到每个部门下面
        /// </summary>
        /// <param name="dtAlluser"></param>
        /// <param name="selectUser"></param>
        /// <param name="depid"></param>
        /// <param name="cbl"></param>
        private void showDUsers(DataTable dtAlluser, string selectUser, string depid, CheckBoxList cbl)
        {
            try
            {
                int i = dtAlluser.Rows.Count;
                int itemi = 0;
                string[] selectuserarray = selectUser.Split(',');
                for (int j = 0; j < i; j++)
                {
                    if (dtAlluser.Rows[j]["UpID"].ToString() == depid)
                    {

                        string types = dtAlluser.Rows[j]["Types"].ToString();
                       
                        ListItem li = new ListItem();
                        li.Text = dtAlluser.Rows[j]["NAME"].ToString() +"["+types+"]";
                        li.Value = dtAlluser.Rows[j]["ID"].ToString();
                        if (selectuserarray.Length>0)
                        {
                            //判断当前的用户是否已经被选择过
                            for (int m = 0; m < selectuserarray.Length; m++)
                            {
                                if (selectuserarray[m].ToString() == dtAlluser.Rows[j]["ID"].ToString())
                                {
                                    li.Selected = true;
                                    break;
                                }
                            }
                        }

                        cbl.Items.Insert(itemi, li);
                        itemi = itemi + 1;
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView_grouplist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    //  e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    // e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");
                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;
                    CheckBoxList CheckBoxList_userlist = (CheckBoxList)e.Row.FindControl("CheckBoxList_userlist");
                    showDUsers((DataTable)Session["temp_Roles_session"],Session["temp_rolesSelect_session"].ToString(), ID, CheckBoxList_userlist);

                    CheckBox depids = (CheckBox)e.Row.FindControl("depid");
                    showPageMeau(Session["temp_rolesSelect_session"].ToString(), ID, depids);// 将页面权限和菜单权限做勾选
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 将页面权限和菜单权限做勾选
        /// </summary>
        private void showPageMeau(string  selectRole, string roleID, CheckBox cbl)
        {
            try
            {
                string[] arrays = selectRole.Split(',');
                int i = arrays.Length;
                for (int j = 0; j < i; j++)
                {
                    if (arrays[j].ToString() == roleID)
                    {
                        cbl.Checked=true;
                        break;
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 当部门被选择时，触发下面人员的选择状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void depid_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = (CheckBox)sender;
                string indexnum = cb.TabIndex.ToString();
                CheckBoxList cbl = (CheckBoxList)GridView_grouplist.Rows[int.Parse(indexnum)].Cells[0].FindControl("CheckBoxList_userlist");
                for (int i = 0; i < cbl.Items.Count; i++)
                {
                    cbl.Items[i].Selected = cb.Checked;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 获取到选择的用户的值的数组
        /// </summary>
        /// <returns></returns>
        public ArrayList getSelectUser()
        {
            ArrayList al = new ArrayList();
            try
            {
                int countint = GridView_grouplist.Rows.Count;
                for (int i = 0; i < countint; i++)
                {
                    CheckBox depids = (CheckBox)GridView_grouplist.Rows[i].Cells[0].FindControl("depid");
                    CheckBoxList cbl = (CheckBoxList)GridView_grouplist.Rows[i].Cells[0].FindControl("CheckBoxList_userlist");
                    for (int m = 0; m < cbl.Items.Count; m++)
                    {
                        if (cbl.Items[m].Selected)
                        {
                            al.Add(cbl.Items[m].Value.ToString());
                        }
                    }
                    if (depids.Checked)
                    {
                        HiddenField hid = (HiddenField)GridView_grouplist.Rows[i].Cells[0].FindControl("Hid_ID");
                        al.Add(hid.Value.ToString());
                    }
                }
            }
            catch
            {
            }
            return al;
        }
    }
}