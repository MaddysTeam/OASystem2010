using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dianda.COMMON;
using System.Text;
using System.Collections;

namespace Dianda.Web.Admin.newsManage.OAcolumns
{
    public partial class columns : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();//引入通用操作类
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        Dianda.BLL.News_Columns bNews_Columns = new Dianda.BLL.News_Columns();
        Dianda.Model.News_Columns mNews_Columns = new Dianda.Model.News_Columns();
        BLL.USER_Groups bUSER_Groups = new Dianda.BLL.USER_Groups();
        Model.USER_Groups mUSER_Groups = new Dianda.Model.USER_Groups();
        BLL.Project_Projects bProject_Projects = new Dianda.BLL.Project_Projects();
        Model.Project_Projects mProject_Projects = new Dianda.Model.Project_Projects();
        //Dianda.BLL.USER_Groups GroupsBll = new Dianda.BLL.USER_Groups();
        //Dianda.Model.USER_Groups userGroupModel = new Dianda.Model.USER_Groups();
        //Dianda.COMMON.USER_GroupsExt user_groupsext = new Dianda.COMMON.USER_GroupsExt();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string objName = "栏目";

                ////获取group名称，是岗位还是部门
                //if (null == Request["tags"])
                //{
                //    groupname = "部门";
                //}
                //else
                //{
                //    groupname = Request["tags"].ToString();
                //}

                LB_name.Text = objName;

                //H_NAME.Value = objName;

                //Session["groups"] = objName;
                GetddlPARENTID();
                //Button_add.Text = "新增" + objName;
                BindData();
            }
        }

        protected void GetddlPARENTID()
        {
            ListItem li = new ListItem("-全部-", "9999");
            li.Selected = true;
            this.ddlNews_Columns.Items.Insert(0, li);
            li = new ListItem("普通信息栏目", "1");
            this.ddlNews_Columns.Items.Insert(1, li);
            li = new ListItem("项目信息栏目", "2");
            this.ddlNews_Columns.Items.Insert(2, li);
            li = new ListItem("部门信息栏目", "3");
            this.ddlNews_Columns.Items.Insert(3, li);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        protected void BindData()
        {
            try
            {
                // string sql = "SELECT DepartMentID,DepartName FROM vUSER_Users WHERE DELFLAG=0 and DepartMentID='" + mUSER_Users.DepartMentID + "' Group By DepartMentID,DepartName";
                string strSQL = "SELECT * FROM News_Columns WHERE " + SQLCondition();
                DataTable dt = new DataTable();
                dt = pageControl.doSql(strSQL).Tables[0];
                //string sql = "";
                //if (groupname.Equals("部门"))
                //{
                //    sql = "SELECT * FROM vUser_Groups_DepartMent ";//vUser_Groups_DepartMent为视图
                //}
                //else if (groupname.Equals("岗位"))
                //{
                //    sql = "SELECT * FROM  vUser_Groups_Station ";//vUser_Groups_Station为视图
                //}

                //dt = PageControl.doSql(sql).Tables[0];

                /** 以下做的目的是显示同部门或同岗位的人员合并信息*/

                //DataTable Newdt = dt;
                //if (null != dt)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        //部门或岗位的ID
                //        string ID1 = dt.Rows[i]["ID"].ToString();

                //        //人员名称
                //        string NAME1 = dt.Rows[i]["REALNAME"].ToString();

                //        //人员ID
                //        string UserID1 = dt.Rows[i]["userid"].ToString();

                //        //删除标记
                //        string delflag1 = dt.Rows[i]["delflag"].ToString();

                //        //该部门或是该岗位的人数
                //        int menbernum = 0;

                //        if (!NAME1.Equals(""))
                //        {
                //            menbernum = 1;
                //            dt.Rows[i]["REALNAME"] = "<a href='show.aspx?userid=" + UserID1 + "' target='_self' rel='gb_page_center[726,400]'>" + dt.Rows[i]["REALNAME"] + "</a>";

                //        }

                //        if (delflag1.Equals("0"))
                //        {
                //            for (int j = 0; j < Newdt.Rows.Count; j++)
                //            {
                //                //自己不需要和本条记录对比
                //                if (i != j)
                //                {
                //                    //部门或岗位的ID
                //                    string ID2 = Newdt.Rows[j]["ID"].ToString();

                //                    //删除标记
                //                    string delflag2 = Newdt.Rows[j]["delflag"].ToString();

                //                    if (delflag2.Equals("0"))
                //                    {
                //                        //如果部门或岗位相同,则将这二条记录的人员合在一条中
                //                        if (ID2.Equals(ID1))
                //                        {
                //                            //人员名称
                //                            string NAME2 = Newdt.Rows[j]["REALNAME"].ToString();
                //                            //人员ID
                //                            string UserID2 = Newdt.Rows[j]["userid"].ToString();

                //                            if (NAME1.Equals(""))
                //                            {
                //                                dt.Rows[i]["REALNAME"] = dt.Rows[i]["REALNAME"] + "<a href='show.aspx?userid=" + UserID2 + "' target='_self' rel='gb_page_center[726,400]'>" + NAME2 + "</a>";
                //                            }
                //                            else
                //                            {
                //                                dt.Rows[i]["REALNAME"] = dt.Rows[i]["REALNAME"] + "；" + "<a href='show.aspx?userid=" + UserID2 + "' target='_self' rel='gb_page_center[726,400]'>" + NAME2 + "</a>";
                //                            }


                //                            dt.Rows[j]["delflag"] = "1";

                //                            Newdt.Rows[j]["delflag"] = "1";

                //                            menbernum = menbernum + 1;

                //                        }
                //                    }
                //                }

                //            }

                //            //借用dt中的"ISMOREN"来装一下该部门的人员数

                //            dt.Rows[i]["ISMOREN"] = menbernum;

                //        }
                //    }

                //}
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
                    //Button_modify.Enabled = false;
                    //Button_delete.Enabled = false;
                    notice.Text = "*没有符合条件的结果！";
                }
            }
            catch
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
        //protected void Button_add_onclick(object sender, EventArgs e)
        //{
        //    // this.div2.Visible = true;
        //    // Response.Redirect("add.aspx?tags=" + Session["groups"]);
        //}

        /// <summary>
        /// 点击编辑按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Button_modify_onclick(object sender, EventArgs e)
        //{
        //    //选择编辑的条数只能为一条
        //    int num = 0;
        //    int rows = GridView1.Rows.Count;
        //    if (rows > 0)
        //    {
        //        for (int i = 0; i < rows; i++)
        //        {
        //            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
        //            if (cb.Checked)
        //            {
        //                num = num + 1;
        //            }
        //        }

        //        if (num == 0)
        //        {
        //            tag.Text = "请选择一条数据进行编辑！";

        //        }
        //        else if (num > 1)
        //        {
        //            tag.Text = "编辑时最多只能选择一条数据！";
        //        }
        //        else
        //        {
        //            tag.Text = "";
        //            for (int j = 0; j < rows; j++)
        //            {
        //                CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
        //                HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

        //                if (cb1.Checked)
        //                {
        //                    //Response.Redirect("modify.aspx?tags=" + Session["groups"] + "&ID=" + hid.Value.ToString());
        //                    // this.H_ModifyID.Value = hid.Value;
        //                    BindModifyData(hid.Value);
        //                    //this.div2.Visible = true;
        //                }
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 点击删除按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Button_delete_onclick(object sender, EventArgs e)
        //{
        //    int num = 0;
        //    int rows = GridView1.Rows.Count;
        //    if (rows > 0)
        //    {
        //        for (int i = 0; i < rows; i++)
        //        {
        //            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox_choose");
        //            if (cb.Checked)
        //            {
        //                num = num + 1;
        //            }
        //        }

        //        if (num == 0)
        //        {
        //            tag.Text = "删除时最少选择一条数据！";

        //        }
        //        else
        //        {
        //            tag.Text = "";
        //            for (int j = 0; j < rows; j++)
        //            {
        //                CheckBox cb1 = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("CheckBox_choose");
        //                HiddenField hid = (HiddenField)GridView1.Rows[j].Cells[0].FindControl("Hid_ID");

        //                if (cb1.Checked)
        //                {
        //                    mNews_Columns = bNews_Columns.GetModel(Int32.Parse(hid.Value));
        //                    //将删除标记设为1
        //                    mNews_Columns.DELFLAG = 1;
        //                    bNews_Columns.Update(mNews_Columns);

        //                    tag.Text = "操作成功！";
        //                    //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"] + "\";</script>";
        //                    //Response.Write(coutws);

        //                    //添加操作日志
        //                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
        //                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
        //                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "删除栏目" /*Request["tags"].ToString()*/, "删除成功");
        //                }
        //            }
        //        }

        //    }

        //}



        /// <summary>
        ///点击确定按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string NAME = this.txtNAME.Text;//获取到用户名

            //    //检查该名称是否有了
            //    if (NAME != "")
            //    {
            //        //检查是否有该用户组名称
            //        bool checkName = PageControl.Exists_Name("News_Columns", "NAME", NAME, "ID", "");
            //        if (checkName)
            //        {
            //            tag.Text = "该名称已经存在，请修改！";
            //            return;
            //        }
            //        if (this.ddlPARENTID.SelectedIndex == 0)
            //        {
            //            tag.Text = "请选择父栏目！";
            //            return;
            //        }
            //        mNews_Columns = new Dianda.Model.News_Columns();

            //        mNews_Columns.NAME = txtNAME.Text;
            //        mNews_Columns.PARENTID = Int32.Parse(ddlPARENTID.SelectedValue);



            //        //密码
            //        users_Model.PASSWORD = commons.GetMD5(TB_PASSWORD.Text.Trim());
            //        //真实姓名
            //        users_Model.REALNAME = TB_REALNAME.Text;
            //        //性别
            //        users_Model.SEX = RadioButtonList_SEX.SelectedValue.ToString();
            //        //部门
            //        users_Model.DepartMentID = DDL_DEPARTMENT.SelectedValue.ToString();
            //        //岗位
            //        users_Model.StationID = DDL_Station.SelectedValue.ToString();
            //        //联系电话
            //        users_Model.TEL = TB_TEL.Text;
            //        //邮箱
            //        users_Model.EMAIL = TB_EMAIL.Text;
            //        //在职状态
            //        users_Model.WorkStats = DDL_WorkStats.SelectedValue.ToString();
            //        //入职时间
            //        users_Model.DatesEmployed = Convert.ToDateTime(TB_DatesEmployed.Value.ToString());
            //        //离职时间
            //        users_Model.LeaveDates = Convert.ToDateTime(TB_LeaveDates.Value.ToString());
            //        //生日
            //        users_Model.BIRTHDAY = TB_BIRTHDAY.Value.ToString();
            //        //籍贯
            //        users_Model.NativePlace = TB_NativePlace.Text;
            //        //学历
            //        users_Model.EducationLevel = DDL_EducationLevel.SelectedValue.ToString();
            //        //住址
            //        users_Model.ADDRESS = TB_ADDRESS.Text.ToString();
            //        //毕业学校
            //        users_Model.GraduateSchool = TB_GraduateSchool.Text;
            //        //专业
            //        users_Model.Major = TB_Major.Text;
            //        //工作履历
            //        users_Model.TrackRecord = TB_TrackRecord.Text;
            //        //时间
            //        users_Model.DATETIME = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
            //        //工作组
            //        users_Model.GROUPS = "";
            //        //头像
            //        users_Model.IMAGES = "";
            //        //删除标记
            //        users_Model.DELFLAG = 0;

            //        users_Bll.Add(users_Model);

            //        tag.Text = "操作成功！";

            //        string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx" + "\";</script>";


            //        Response.Write(coutws);

            //        //添加操作日志

            //        Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
            //        Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
            //        bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "添加人员", "添加成功");
            //        //添加操作日志

            //    }
            //}
            //catch
            //{
            //    tag.Text = "操作失败，请重试！";
            //}
        }

        /// <summary>
        /// 点击重置按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 点击取消按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            // this.div2.Visible = false;
        }

        protected void BindModifyData(string id)
        {

        }

        protected void ddlNews_Columns_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <returns></returns>
        protected string SQLCondition()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" 1=1 and PARENTID<>-1");
            // 学期
            if (this.ddlNews_Columns.SelectedValue != "9999")
            {
                sbSql.Append(" AND PARENTID =" + ddlNews_Columns.SelectedValue + " ");
            }
            sbSql.Append("AND DELFLAG=0 ");
            sbSql.Append("ORDER BY SHUNXU ");
            return sbSql.ToString();
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

                    //HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    //部门或岗位的ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    //hid.Value = ID;
                    string PARENTID = DataBinder.Eval(e.Row.DataItem, "PARENTID").ToString();
                    string ForItems = DataBinder.Eval(e.Row.DataItem, "ForItems").ToString();
                    string ItemsID = DataBinder.Eval(e.Row.DataItem, "ItemsID").ToString();

                    mNews_Columns = new Dianda.Model.News_Columns();
                    mNews_Columns = bNews_Columns.GetModel(Int32.Parse(PARENTID));
                    if (mNews_Columns != null)
                    {
                        e.Row.Cells[1].Text = mNews_Columns.NAME;
                    }
                    else
                    {
                        e.Row.Cells[1].Text = "";
                    }

                    if (ForItems == "DEPARTMENT")
                    {
                        e.Row.Cells[2].Text = "部门信息栏目";
                        mUSER_Groups = new Dianda.Model.USER_Groups();
                        mUSER_Groups = bUSER_Groups.GetModel(ItemsID);
                        if (mUSER_Groups != null)
                        {
                            e.Row.Cells[3].Text = mUSER_Groups.NAME;
                        }

                    }
                    if (ForItems == "PROJECT")
                    {
                        e.Row.Cells[2].Text = "项目信息栏目";
                        mProject_Projects = new Dianda.Model.Project_Projects();
                        mProject_Projects = bProject_Projects.GetModel(Int32.Parse(ItemsID));
                        if (mProject_Projects != null)
                        {
                            e.Row.Cells[3].Text = mProject_Projects.NAMES;
                        }
                    }
                    if (ForItems == "NEWS")
                    {
                        e.Row.Cells[2].Text = "普通信息栏目";
                    }
                }
            }
            catch
            {
            }
        }
    }
}