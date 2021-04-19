using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Dianda.Web.Admin.DocumentManage
{
    public partial class shareForUser : System.Web.UI.UserControl
    {
        BLL.USER_Groups bug = new Dianda.BLL.USER_Groups();
        COMMON.pageControl pagedosql = new Dianda.COMMON.pageControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                }
            }
            catch
            {
            }
        }
 
        /// <summary>
        /// 按部门将所有的用户呈现，并且将已经选择的用户selectUser在列表上显示出来
        /// </summary>
        /// <param name="selectUser"></param>
        public void showDepartment(DataTable selectUser)
        {
            try
            {
                //获取到所有的用户的列表
                string sql = "SELECT   ID, USERNAME, REALNAME, DepartMentID, DELFLAG,DepartMentName FROM USER_Users WHERE (DELFLAG = '0') ORDER BY DepartMentID";
                DataTable dt2 = pagedosql.doSql(sql).Tables[0];
                Session["temp_userall_session"] = dt2;
                Session["temp_userSelect_session"] = selectUser;
                //
                DataTable dt = new DataTable();
                dt = bug.GetList(" TAGS='部门' and DELFLAG='0' order by NAME").Tables[0];
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
        private void showDUsers(DataTable dtAlluser,DataTable selectUser, string depid,CheckBoxList cbl,HiddenField holdid)
        {
            try
            {
                int i = dtAlluser.Rows.Count;
                int itemi = 0;
                string oldidtemp = "";
                for (int j = 0; j < i; j++)
                {
                    if (dtAlluser.Rows[j]["DepartMentID"].ToString().Contains(depid))
                    {
                       
                        ListItem li = new ListItem();
                        li.Text = dtAlluser.Rows[j]["REALNAME"].ToString() + "(" + dtAlluser.Rows[j]["USERNAME"].ToString() + ")";
                        li.Value = dtAlluser.Rows[j]["ID"].ToString();
                        if (selectUser != null && selectUser.Rows.Count > 0)
                        {
                            //判断当前的用户是否已经被选择过
                            if (selectUser != null)
                            {
                                for (int m = 0; m < selectUser.Rows.Count; m++)
                                {
                                    if (selectUser.Rows[m]["ShareForUser"].ToString() == dtAlluser.Rows[j]["ID"].ToString())
                                    {
                                        li.Selected = true;
                                        oldidtemp = oldidtemp + li.Value.ToString() + "|";
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                li.Selected = false;
                            }
                             
                        }
                       
                        cbl.Items.Insert(itemi,li);
                        itemi = itemi + 1;
                       
                    }
                }
                holdid.Value = oldidtemp;//隐藏老的已经选择的用户ID
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
                    CheckBoxList CheckBoxList_userlist=(CheckBoxList)e.Row.FindControl("CheckBoxList_userlist");
                    HiddenField hidol = (HiddenField)e.Row.FindControl("HiddenField_old");
                    showDUsers((DataTable)Session["temp_userall_session"], (DataTable)Session["temp_userSelect_session"], ID, CheckBoxList_userlist, hidol);
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
                    userselected(cbl.Items[i].Value.ToString(), cb.Checked);
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
        protected void user_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBoxList cb = (CheckBoxList)sender;
              
                string indexnum = cb.TabIndex.ToString();
                CheckBoxList cbl = (CheckBoxList)GridView_grouplist.Rows[int.Parse(indexnum)].Cells[0].FindControl("CheckBoxList_userlist");
                HiddenField hioldid = (HiddenField)GridView_grouplist.Rows[int.Parse(indexnum)].Cells[0].FindControl("HiddenField_old");
                //根据现在已经选择的情况和原始被选择的情况，进行比较，找出发生变化的用户ID
                string[] hioldidarray = hioldid.Value.Split('|');
                for (int i = 0; i < cbl.Items.Count; i++)
                {
                    string oldidtemp = hioldid.Value.ToString();

                    if (cbl.Items[i].Selected)//新的用户被选择了。
                    {
                        string newids = cbl.Items[i].Value.ToString();
                        int n = 0;
                        for (int j = 0; j < hioldidarray.Length; j++)
                        {
                            if (newids == hioldidarray[j].ToString())
                            {
                                //老的里面有这个值，则表示没有发生变化
                                break;
                            }
                            else
                            {
                                //老的里面没有，则要看比对的次数是否是老的用户的个数总和
                                n = n + 1;
                            }
                        }
                        if (n == hioldidarray.Length)
                        {
                            //说明这个值发生了变化
                            userselected(newids, true);//加载变化的触发函数
                        }
                    }
                    else
                    {
                        //新的用户没有被选择了

                        string newids = cbl.Items[i].Value.ToString();
                        int n = 0;
                        for (int j = 0; j < hioldidarray.Length; j++)
                        {
                            if (newids == hioldidarray[j].ToString())
                            {
                                //老的里面有这个值，则表示发生变化
                                userselected(newids, false);//加载变化的触发函数
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 当用户发生变化的时候
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="ischeck"></param>
        private void userselected(string userid, bool ischeck)
        {
            try
            {
                int rowscout = GridView_grouplist.Rows.Count;
                for (int i = 0; i < rowscout; i++)
                {
                    CheckBoxList cbl = (CheckBoxList)GridView_grouplist.Rows[i].FindControl("CheckBoxList_userlist");
                    HiddenField hioldid = (HiddenField)GridView_grouplist.Rows[i].FindControl("HiddenField_old");
                    Label Label1 = (Label)GridView_grouplist.Rows[i].FindControl("Label1");
                    
                    for (int j = 0; j < cbl.Items.Count; j++)
                    {
                        if (cbl.Items[j].Value == userid)
                        {
                            cbl.Items[j].Selected = ischeck;
                            if (ischeck)//重置比对函数
                            {
                                hioldid.Value = hioldid.Value + "|" + userid;
                            }
                            else
                            {
                                string oldidtemp = hioldid.Value.ToString();
                               string oldidtemp2="";
                              
                                string[] oldarrays = oldidtemp.Split('|');
                                for (int m = 0; m < oldarrays.Length; m++)
                                {
                                    if (oldarrays[m].ToString() == userid)
                                    {

                                    }
                                    else
                                    {
                                        oldidtemp2 = oldidtemp2 +oldarrays[m].ToString()+ "|";
                                       
                                    }
                                }
                                hioldid.Value = oldidtemp2;
                              // Label1.Text = oldidtemp2;
                                
                            }
                        }
                    }
                  
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
                            string itemsvalue = cbl.Items[m].Value.ToString();
                            //判断当前AL中是否已经有了这个数据，如果有了，则不能加入了
                            if (isinList(al, itemsvalue))
                            {
                            }
                            else
                            {
                                al.Add(itemsvalue);
                            }
                         
                        }
                    }
                }
            }
            catch
            {
            }
            return al;
        }
        /// <summary>
        /// 判断指定的动态数组中，是否有指定的值存在
        /// </summary>
        /// <param name="al"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private bool isinList(ArrayList al, string values)
        {
            bool coutw =false;
            try
            {
                for (int i = 0; i < al.Count; i++)
                {
                    if (al[i].ToString() == values)
                    {
                        coutw = true;
                        break;
                    }
                }
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 获取到选择的用户的真实姓名(用户名)的数组
        /// </summary>
        /// <returns></returns>
        public ArrayList getSelectUserInfo()
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
                            //判断当前AL中是否已经有了这个数据，如果有了，则不能加入了
                            string itemsvalue = cbl.Items[m].Text.ToString();
                            if (isinList(al, itemsvalue))
                            {
                            }
                            else
                            {
                                al.Add(itemsvalue);
                            }
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