using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Dianda.Web.Admin.sysTongji.ascxModel
{
    public partial class usermember : System.Web.UI.UserControl
    {
        BLL.USER_Groups bug = new Dianda.BLL.USER_Groups();
        COMMON.pageControl pagedosql = new Dianda.COMMON.pageControl();
        COMMON.common commonId = new Dianda.COMMON.common();
        BLL.Project_UserList projectuserListBll = new Dianda.BLL.Project_UserList();
        Model.Project_UserList projectUserListModel = new Dianda.Model.Project_UserList();

        Model.Project_Projects mProjects = new Dianda.Model.Project_Projects();
        BLL.Project_Projects bProjects = new Dianda.BLL.Project_Projects();
        COMMON.common common = new COMMON.common();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
             
            }
            catch (Exception)
            {
            }

        }


        /// <summary>
        /// 按部门将所有的用户呈现，并且将已经选择的用户selectUser在列表上显示出来
        /// </summary>
        /// <param name="selectUser"></param>
        public void showDepartment(string projectId)
        {
            try
            {
                //获取到部门ID
                mProjects = bProjects.GetModel(int.Parse(projectId));
                //通过方法 用逗号把部门ID分开
                string strdepartmentId = commonId.makeSqlIn(mProjects.DepartmentID, ',');
                //查询出部门中status =1 并且delflag=0 的用户
                string sql = "SELECT  * FROM vProject_UserList WHERE (DELFLAG = '0') and status='1'and ProjectID='" + projectId + "' ORDER BY DepartMentID";
                DataTable dt1 = pagedosql.doSql(sql).Tables[0];

                if (dt1.Rows.Count > 0)
                {
                    Label_tongji.Text = "此项目中共有参与人员&nbsp;" + dt1.Rows.Count.ToString() + "&nbsp;人";

                }
                else
                {
                    Label_tongji.Text = "此项目中没有参与人员";
                }


                //通过部门ID 查看部门里有多少人员
                string[] strdepartmentId_arr = mProjects.DepartmentID.Split(',');
                string strsql = "";
                for (int i = 0; i < strdepartmentId_arr.Length; i++)
                {
                    if (strsql == "")
                    {
                        strsql = "select id,realName,userName,'" + strdepartmentId_arr[i] + "' departmentid from USER_Users where departmentid like '%" + strdepartmentId_arr[i] + "%'";
                    }
                    else
                    {
                        strsql += " union select id,realName,userName,'" + strdepartmentId_arr[i] + "'departmentid from USER_Users where departmentid like '%" + strdepartmentId_arr[i] + "%'";
                    }
                }

                //string strsql = "select id,realName,userName,departmentid from USER_Users where departmentid in " + strdepartmentId;
                DataTable dt = pagedosql.doSql(strsql).Tables[0];

                Session["temp_UserAllUser_session"] = dt;
                Session["temp_SelectUser_session"] = dt1;

                //查询出传进来的部门ID
                DataTable dt2 = new DataTable();
                dt2 = bug.GetList(" TAGS='部门' and DELFLAG='0' and id in " + common.SafeString(strdepartmentId) + " order by ISMOREN").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView_grouplist.DataSource = dt2;
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
        private void showDUsers(DataTable dtAlluser, DataTable selectUser, string depid, CheckBoxList cbl)
        {
            try
            {
                int i = dtAlluser.Rows.Count;
                int itemi = 0;
                for (int j = 0; j < i; j++)
                {
                    if (dtAlluser.Rows[j]["DepartMentID"].ToString() == depid)
                    {

                        ListItem li = new ListItem();
                        li.Text = dtAlluser.Rows[j]["REALNAME"].ToString() + "(" + dtAlluser.Rows[j]["USERNAME"].ToString() + ")";
                        li.Value = dtAlluser.Rows[j]["ID"].ToString();
                        if (selectUser != null && selectUser.Rows.Count > 0)
                        {
                            //判断当前的用户是否已经被选择过
                            for (int m = 0; m < selectUser.Rows.Count; m++)
                            {
                                if (selectUser.Rows[m]["userid"].ToString() == dtAlluser.Rows[j]["ID"].ToString())
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
        /// GirdView绑定
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
                    showDUsers((DataTable)Session["temp_UserAllUser_session"], (DataTable)Session["temp_SelectUser_session"], ID, CheckBoxList_userlist);
                }
            }
            catch
            { }
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
                    CheckBoxList cbl = (CheckBoxList)GridView_grouplist.Rows[i].Cells[0].FindControl("CheckBoxList_userlist");
                    for (int m = 0; m < cbl.Items.Count; m++)
                    {
                        if (cbl.Items[m].Selected)
                        {
                            al.Add(cbl.Items[m].Value.ToString());
                        }
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

