using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.sysRights
{
    public partial class setRight : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.Model.USER_Users users_model = new Dianda.Model.USER_Users();
        Dianda.BLL.USER_Users users_bll = new Dianda.BLL.USER_Users();

        BLL.USER_Groups buserGroup = new Dianda.BLL.USER_Groups();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //部门
                string Depart = "";
                //工作状态
                string Workstatus = "";
                string pageindex = null;//这里是为分页服务的

                Depart = Request["depart"];
                Workstatus = Request["workstatus"];
                pageindex = Request["pageindex"];


                string count = dtrowsHidden.Value.ToString();
                if (count.Length == 0)
                {
                    setRowCout(Depart, Workstatus);//获取当前状态下有多少条数据记录，为分页提供页数和全部条数服务
                    count = dtrowsHidden.Value.ToString();
                }
                else
                {
                    count = "0";
                }
                int countint = int.Parse(count);

                if (pageindex == null || pageindex == "")
                {
                    pageindex = "1";
                }

                int pageindex_int = int.Parse(pageindex);
                //显示下拉列表中的值
                ShowDdlInfo();

                ShowUsersList(pageindex_int, Depart, Workstatus);

                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 权限管理 > 配置用户权限";
                //设置模板页中的管理值
            }
        }
        /// <summary>
        /// 根据条件查询人员信息列表
        /// </summary>
        /// <param name="pageindex">页码</param>
        /// <param name="depart">部门</param>
        /// <param name="workstatus">工作状态</param>
        protected void ShowUsersList(int pageindex, string depart, string workstatus)
        {
            try
            {
                DataTable DT = new DataTable();
                string sqlWhere1 = "1=1";

                if (null != depart && depart != "")
                {
                    sqlWhere1 = sqlWhere1 + " and DepartMentID like '%" + depart + "%'";
                }
                if (null != workstatus && workstatus != "")
                {
                    sqlWhere1 = sqlWhere1 + " and WorkStats = '" + workstatus + "'";
                }


                string allTiaoshu = dtrowsHidden.Value.ToString();//获取到所有的条数
                int alltiaoshuInt = int.Parse(allTiaoshu);
                DT = pageControl.GetList_FenYe_Common(sqlWhere1, pageindex, GridView1.PageSize, alltiaoshuInt, "vUSER_Users", "ID").Tables[0];
                pageindex = pageControl.pageindex(pageindex, GridView1.PageSize, alltiaoshuInt);//获取当前要显示的页码数【如果最后一页的最后一条记录被删除后，还能正常显示】
                if (DT.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中

                    GridView1.Visible = true;
                    GridView1.DataSource = DT;//指定GridView1的数据是DT
                    pageindexHidden.Value = pageindex.ToString();//给隐藏的页码变量赋值，给下面的分页控件提供数据
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上

                    pageControl.SetSelectPage(pageindex, int.Parse(dtrowsHidden.Value.ToString()), DropDownList2, GridView1.PageSize, FirstPage, NextPage, PreviousPage, LastPage, Label_showInfo);//加载通用组件里面的分页函数
                    notice.Text = "";
                    pageControlShow.Visible = true;//如果记录集不为空，则显示分页控件
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
                    pageControlShow.Visible = false;//如果记录集为空，则不显示分页控件
                 
                    if (alltiaoshuInt > 0)
                    {
                        ShowUsersList(pageindex - 1, depart, workstatus);
                    }

                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 获取到当前数据集中总共有多少条记录
        /// </summary>
        /// <param name="depart">部门</param>
        /// <param name="workstatus">工作状态</param>
        private void setRowCout(string depart, string workstatus)
        {
            try
            {
                DataTable DT = new DataTable();
                string sql = "SELECT * FROM vUSER_Users WHERE 1=1";
                if (null != depart && depart != "")
                {
                    sql = sql + " and DepartMentID like '%" + depart + "%'";
                }
                if (null != workstatus && workstatus != "")
                {
                    sql = sql + " and WorkStats = '" + workstatus + "'";
                }
                DT = pageControl.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    dtrowsHidden.Value = DT.Rows.Count.ToString();
                }
                else
                {
                    dtrowsHidden.Value = "0";
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 当分页控件中的“第一页”“第二页”...发生时，触发下面的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageChange_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());//获取到触发源
            pageindexHidden.Value = page.ToString();//给隐藏的页码记录器赋值
            string depart = DDL_Depart.SelectedValue.ToString();
            string workstatus = DDL_Status.SelectedValue.ToString();
            setRowCout(depart, workstatus);
            ShowUsersList(page, depart, workstatus);//调用显示

        }
        /// <summary>
        /// 当分页控件中的下拉菜单触发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
            pageindexHidden.Value = page.ToString();
            string depart = DDL_Depart.SelectedValue.ToString();
            string workstatus = DDL_Status.SelectedValue.ToString();
            setRowCout(depart, workstatus);
            ShowUsersList(page, depart, workstatus);//调用显示

        }

        /// <summary>
        /// 部门下拉列表选择的值发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Depart_SelectedIndexChanged(object sender, EventArgs e)
        {
            string depart = ((DropDownList)sender).SelectedValue.ToString();
            string workstatus = DDL_Status.SelectedValue.ToString();
            setRowCout(depart, workstatus);
            ShowUsersList(1, depart, workstatus);//调用显示

        }

        /// <summary>
        /// 状态下拉列表选择的值发生改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            string workstatus = ((DropDownList)sender).SelectedValue.ToString();
            string depart = DDL_Depart.SelectedValue.ToString();
            setRowCout(depart, workstatus);
            ShowUsersList(1, depart, workstatus);//调用显示

        }

        /// <summary>
        /// 显示下拉列表中的值
        /// </summary>
        protected void ShowDdlInfo()
        {
            try
            {
                string depart = Request["depart"];
                string status = Request["workstatus"];

                DataTable dt1 = new DataTable();

                string sql1 = " SELECT ID,NAME FROM USER_Groups WHERE (TAGS = '部门') AND (DELFLAG = 0) GROUP BY ID,NAME ";

                dt1 = pageControl.doSql(sql1).Tables[0];

                ListItem li1 = new ListItem("全部", "");
                DDL_Depart.Items.Add(li1);

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string DepartName = dt1.Rows[i]["NAME"].ToString();
                    string ID = dt1.Rows[i]["ID"].ToString();

                    ListItem li = new ListItem(DepartName, ID);
                    DDL_Depart.Items.Add(li);

                    if (ID.Equals(depart))
                    {
                        li.Selected = true;
                    }
                }

                DataTable dt2 = new DataTable();
                string sql2 = " SELECT ID, WorkStataName FROM USER_WorkStats_Base WHERE (DELFLAG = '0') ";
                dt2 = pageControl.doSql(sql2).Tables[0];

                ListItem li2 = new ListItem("全部", "");
                DDL_Status.Items.Add(li2);

                for (int k = 0; k < dt2.Rows.Count; k++)
                {
                    string WorkStats = dt2.Rows[k]["WorkStataName"].ToString();
                    string ID = dt2.Rows[k]["ID"].ToString();
                    ListItem li = new ListItem(WorkStats, ID);
                    DDL_Status.Items.Add(li);

                    if (ID.Equals(status))
                    {
                        li.Selected = true;
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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    //部门或岗位的ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 到权限管理的页面上去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_RoleM_Click(object sender, EventArgs e)
        {
            Response.Redirect("roleM.aspx");
        }
        /// <summary>
        /// 到组管理里面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_groupM_Click(object sender, EventArgs e)
        {
            Response.Redirect("groupM.aspx");

        }
        /// <summary>
        /// 配置用户的特殊权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_edit_Click(object sender, EventArgs e)
        {
            string ID = ((LinkButton)sender).CommandArgument.ToString();
            addrole.Visible = true;
            //设置模板页中的管理值
            (Master.FindControl("Label_navigation") as Label).Text = "管理 > 权限管理 > 配置用户权限";
            //设置模板页中的管理值
            GridView1.Visible = false;
            showUserinfo(ID);//加载要修改的基本信息
        }
        /// <summary>
        /// 根据用户的ID，显示用户的基本信息
        /// </summary>
        /// <param name="userid"></param>
        private void showUserinfo(string userid)
        {
            try
            {
                users_model = users_bll.GetModel(userid);
                if (users_model != null)
                {
                    HiddenField_userid.Value = userid;
                    Label_userinfo.Text = users_model.REALNAME.ToString() + "(" + users_model.USERNAME.ToString()+ ")";
                    showGroups(users_model.GROUPS.ToString());
                }
            }
            catch
            {
            }
        }
            
        /// <summary>
        /// 将全部的用户组列出，并将之前选中的用户组勾选上
        /// </summary>
        /// <param name="selectGroup"></param>
        private void showGroups(string selectGroup)
        {
            try
            {
                DataTable dt = new DataTable();
                dt=buserGroup.GetList("DELFLAG='0' AND TAGS='普通组' order by NAME").Tables[0];
                if(dt.Rows.Count>0)
                {
                    CheckBoxList_grouplist.DataSource = dt;
                    CheckBoxList_grouplist.DataTextField = "NAME";
                    CheckBoxList_grouplist.DataValueField = "ID";
                    CheckBoxList_grouplist.DataBind();
                    if (selectGroup.Length > 0)
                    {
                        string[] selecarray = selectGroup.Split(',');
                        int cj = CheckBoxList_grouplist.Items.Count;
                        for (int i = 0; i < selecarray.Length; i++)
                        {
                            for (int j = 0; j < cj; j++)
                            {
                                if (CheckBoxList_grouplist.Items[j].Value == selecarray[i].ToString())
                                {
                                    CheckBoxList_grouplist.Items[j].Selected = true;
                                    break;
                                }
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
        /// 获取当前用户组被选择的项
        /// </summary>
        /// <returns></returns>
        private string getGroups()
        {
            string coutw = "";
            try
            {
                int i = CheckBoxList_grouplist.Items.Count;
                for (int j = 0; j < i; j++)
                {
                    if (CheckBoxList_grouplist.Items[j].Selected)
                    {
                        coutw = coutw + CheckBoxList_grouplist.Items[j].Value.ToString() + ",";
                    }
                }
                string charj = coutw.Substring(coutw.Length - 1, 1);
                if (charj == ",")
                {
                    coutw = coutw.Substring(0, coutw.Length - 1);
                }
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 确定提交修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = HiddenField_userid.Value.ToString();
                users_model = users_bll.GetModel(userid);
                if (users_model != null)
                {
                    users_model.GROUPS = getGroups();
                    users_bll.Update(users_model);
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('配置成功！')", true);
                    Button_sumbit0_Click(sender, e);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('该用户已经不存在！')", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('操作失败，请重试！')", true);
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit0_Click(object sender, EventArgs e)
        {
            addrole.Visible = false;
            string depart = DDL_Depart.SelectedValue.ToString();
            string workstatus = DDL_Status.SelectedValue.ToString();
            ShowUsersList(int.Parse(pageindexHidden.Value.ToString()), depart, workstatus);//调用显示
            GridView1.Visible = true;
        }
    }
}
