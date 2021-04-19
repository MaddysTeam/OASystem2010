using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.userManager.OAgroupmanage
{
    public partial class manage : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl PageControl = new Dianda.COMMON.pageControl();//引入通用操作类
        Dianda.BLL.USER_Groups GroupsBll = new Dianda.BLL.USER_Groups();
        Dianda.Model.USER_Groups userGroupModel = new Dianda.Model.USER_Groups();
        Dianda.COMMON.USER_GroupsExt user_groupsext = new Dianda.COMMON.USER_GroupsExt();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                  string groupname = "";

                //获取group名称，是岗位还是部门
                  if (null==Request["tags"])
                  {
                      groupname = "部门";
                  }
                  else
                  {
                      groupname = Request["tags"].ToString();
                  }
                //设置模板页中的管理值
                  (Master.FindControl("Label_navigation") as Label).Text = "管理 > 人事管理";
                  //设置模板页中的管理值
                //LB_name.Text = groupname;
                LB_name2.Text = groupname;

                H_NAME.Value = groupname;

                Session["groups"] = groupname;

                Button_add.Text = "新增" + groupname;

                ShowGroupList(groupname);
            }
        }
       
        /// <summary>
        /// 根据groupname来分页显示符合条件的部门或是岗位的列表
        /// </summary>
        /// <param name="groupname"></param>
        protected void ShowGroupList(string groupname)
        {
            try
            {  
                DataTable dt = new DataTable();
                string sql = "";
                if (groupname.Equals("部门"))
                {
                    //查询所有部门信息
                    sql = "SELECT * FROM dbo.USER_Groups where USER_Groups.tags='部门'  AND (DELFLAG = 0) ";                    
                    dt = PageControl.doSql(sql).Tables[0];
                    //新建一列姓名列并添加到DT中
                    DataColumn DC1 = new DataColumn("REALNAME");                  
                    dt.Columns.Add(DC1);
                    //循环DT每一行
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //创建部门人员Datatable,并查询信息
                        DataTable user = new DataTable();
                        user = PageControl.doSql("select* from dbo.USER_Users where DepartMentID like '%" + dt.Rows[i]["id"].ToString() + "%'" + "AND (DELFLAG = 0)").Tables[0];
                        //人员名称列
                        string UserName = "";
                        //将人员信息循环添加
                        for (int j = 0; j < user.Rows.Count; j++)
                        {
                            // <a href="javascript:window.showModalDialog('../OAgroupmanage/show.aspx?userid=<%#Eval("ID").ToString()%>','','dialogWidth=715px;dialogHeight=250px');"title="人员详细信息"><%#Eval("REALNAME").ToString()%></a>

                            UserName += "<a href=\"javascript:window.showModalDialog('show.aspx?userid=" + user.Rows[j]["ID"].ToString() + "','','dialogWidth=715px;dialogHeight=250px');\" title='人员详细信息'>" + user.Rows[j]["REALName"].ToString() + "</a>；";
                        }
                        //将人员名称信息添加到DT中
                        dt.Rows[i]["REALNAME"] = UserName;
                        //将该部门人员添加
                        dt.Rows[i]["ISMOREN"] = user.Rows.Count.ToString();

                    }
                    if (dt.Rows.Count > 0)
                    {
                        //当获取到的数据集不为空的时候，显示在GridView1中
                        GridView1.Visible = true;
                        GridView1.DataSource = dt;//指定GridView1的数据是dv
                        GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                        notice.Text = "";
                    }
                    else
                    {
                        GridView1.Visible = false;
                        Button_modify.Enabled = false;
                        Button_delete.Enabled = false;
                        notice.Text = "*没有符合条件的结果！";
                    }

                }
                else if (groupname.Equals("岗位"))
                {
                    sql = "SELECT * FROM  vUser_Groups_Station ";//vUser_Groups_Station为视图
                    dt = PageControl.doSql(sql).Tables[0];
                    /** 以下做的目的是显示同部门或同岗位的人员合并信息*/
                    DataTable Newdt = dt;
                    if (null != dt)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //部门或岗位的ID
                            string ID1 = dt.Rows[i]["ID"].ToString();

                            //人员名称
                            string NAME1 = dt.Rows[i]["REALNAME"].ToString();

                            //人员ID
                            string UserID1 = dt.Rows[i]["userid"].ToString();

                            //删除标记
                            string delflag1 = dt.Rows[i]["delflag"].ToString();

                            //该部门或是该岗位的人数
                            int menbernum = 0;

                            if (!NAME1.Equals(""))
                            {
                                menbernum = 1;
                                // <a href="javascript:window.showModalDialog('../OAgroupmanage/show.aspx?userid=<%#Eval("ID").ToString()%>','','dialogWidth=715px;dialogHeight=250px');"title="人员详细信息"><%#Eval("REALNAME").ToString()%></a>

                                dt.Rows[i]["REALNAME"] = "<a href=\"javascript:window.showModalDialog('show.aspx?userid=" + UserID1 + "','','dialogWidth=715px;dialogHeight=250px');\" title='人员详细信息'>" + dt.Rows[i]["REALNAME"] + "</a>";

                            }

                            if (delflag1.Equals("0"))
                            {
                                for (int j = 0; j < Newdt.Rows.Count; j++)
                                {
                                    //自己不需要和本条记录对比
                                    if (i != j)
                                    {
                                        //部门或岗位的ID
                                        string ID2 = Newdt.Rows[j]["ID"].ToString();

                                        //删除标记
                                        string delflag2 = Newdt.Rows[j]["delflag"].ToString();

                                        if (delflag2.Equals("0"))
                                        {
                                            //如果部门或岗位相同,则将这二条记录的人员合在一条中
                                            if (ID2.Equals(ID1))
                                            {
                                                //人员名称
                                                string NAME2 = Newdt.Rows[j]["REALNAME"].ToString();
                                                //人员ID
                                                string UserID2 = Newdt.Rows[j]["userid"].ToString();

                                                if (NAME1.Equals(""))
                                                {
                                                    dt.Rows[i]["REALNAME"] = dt.Rows[i]["REALNAME"] + "<a href=\"javascript:window.showModalDialog('show.aspx?userid=" + UserID2 + "','','dialogWidth=715px;dialogHeight=250px');\" title='人员详细信息'>" + NAME2 + "</a>";
                                                }
                                                else
                                                {
                                                    dt.Rows[i]["REALNAME"] = dt.Rows[i]["REALNAME"] + "；" + "<a href=\"javascript:window.showModalDialog('show.aspx?userid=" + UserID2 + "','','dialogWidth=715px;dialogHeight=250px');\" title='人员详细信息'>" + NAME2 + "</a>";
                                                }


                                                dt.Rows[j]["delflag"] = "1";

                                                Newdt.Rows[j]["delflag"] = "1";

                                                menbernum = menbernum + 1;

                                            }
                                        }
                                    }

                                }
                            }
                            //借用dt中的"ISMOREN"来装一下该部门的人员数
                            dt.Rows[i]["ISMOREN"] = menbernum;
                        }
                    }
                    /** 以上做的目的是显示同部门或同岗位的人员合并信息*/
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "delflag='0'";

                    if (dv.Count > 0)
                    {
                        //当获取到的数据集不为空的时候，显示在GridView1中
                        GridView1.Visible = true;
                        GridView1.DataSource = dv;//指定GridView1的数据是dv
                        GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                        notice.Text = "";
                    }
                    else
                    {
                        GridView1.Visible = false;
                        Button_modify.Enabled = false;
                        Button_delete.Enabled = false;
                        notice.Text = "*没有符合条件的结果！";
                    }
                }
            }catch
            {

            }
        }
      
        /// <summary>
        /// 点击全选框时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox_choose_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox CheckBox_Alltemp = (CheckBox)sender;
                if (CheckBox_Alltemp.Checked)//全选
                {
                    grievSearch(true);
                }
                else//全不选
                {
                    grievSearch(false);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        ///根据条件给值
        /// </summary>
        /// <param name="isCheck"></param>
        private void grievSearch(bool isCheck)
        {
            try
            {
                int rows = GridView1.Rows.Count;
                if (rows > 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                        cb.Checked = isCheck;
                    }
                }

            }
            catch
            {
            }
        }

        /// <summary>
        /// 点击新增按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_add_onclick(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx?tags=" + Request["tags"]);
        }

        /// <summary>
        /// 点击编辑按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_modify_onclick(object sender, EventArgs e)
        {
            //选择编辑的条数只能为一条
            int num = 0;
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if(cb.Checked)
                    {
                        num = num + 1;
                    }
                }

                if(num==0)
                {
                    tag.Text = "请选择一条数据进行编辑！";

                }
                else if (num > 1)
                {
                    tag.Text = "编辑时最多只能选择一条数据！";
                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

                        if (cb1.Checked)
                        {
                            Response.Redirect("modify.aspx?tags=" + Request["tags"] + "&ID=" + hid.Value.ToString());
                        }
                    }
                }
      
            }

        }
        /// <summary>
        /// 点击删除按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_delete_onclick(object sender, EventArgs e)
        {
            int num = 0;
            int rows = GridView1.Rows.Count;
            if (rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
                    if (cb.Checked)
                    {
                        num = num + 1;
                    }
                }

                if (num == 0)
                {
                    tag.Text = "删除时最少选择一条数据！";

                }
                else
                {
                    tag.Text = "";
                    for (int j = 0; j < rows; j++)
                    {
                        CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
                        HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

                        if (cb1.Checked)
                        {
                            //获取到当前部门或岗位的基本信息
                            userGroupModel = GroupsBll.GetModel(hid.Value.ToString());
                            //将删除标记设为1
                            userGroupModel.DELFLAG = 1;

                            GroupsBll.Update(userGroupModel);

                            //添加操作日志

                            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "删除" + Request["tags"].ToString(), "删除"+userGroupModel.NAME+"成功");

                            //添加操作日志
                        }
                    }
                    //tag.Text = "操作成功！";
                    //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "&tags=" +Request["tags"]+ "\";</script>";
                    //Response.Write(coutws);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入我的列表页面');javascript:location='manage.aspx?pageindex=" + Request["pageindex"] + "&tags=" + Request["tags"] + "';</script>", false);
                }

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
        /// 创建部门信息栏目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //Dianda.BLL.News_ColumnsExt columnext_bll = new Dianda.BLL.News_ColumnsExt();
                //columnext_bll.addCloumns(userGroupModel.NAME, "DEPARTMENT", userGroupModel.ID, 3);
            }
            catch
            {
            }
        }

       
    }
}
