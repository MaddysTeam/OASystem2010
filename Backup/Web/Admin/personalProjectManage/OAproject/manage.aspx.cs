using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.personalProjectManage.OAproject
{
    public partial class manage : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.COMMON.common common = new Dianda.COMMON.common();

        Dianda.Model.Project_Projects projects_model = new Dianda.Model.Project_Projects();
        Dianda.BLL.Project_Projects projects_bll = new Dianda.BLL.Project_Projects();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                string status = "";
                //如果是从添加立项申请的“立项草稿箱”过来的，Request["projecttype"]不为空。则直接到我创建的项目--草稿箱中
                status = Request["projecttype"];
                if (null != status && !status.Equals(""))
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "项目 > 立项草稿箱 ";
                    //设置模板页中的管理值

                }
                else
                {
                    //设置模板页中的管理值
                    (Master.FindControl("Label_navigation") as Label).Text = "项目 > 我的项目 ";
                    //设置模板页中的管理值
                }

                if (Request["projectstatus"].ToString().Equals("0"))
               {
                   LB_title.Text = "待审项目";

               }
                else if (Request["projectstatus"].ToString().Equals("1"))
               {
                   LB_title.Text = "当前项目";
               }
                else if (Request["projectstatus"].ToString().Equals("2"))
                {
                    LB_title.Text = "不通过项目";
                }
                else if (Request["projectstatus"].ToString().Equals("3"))
                {
                    LB_title.Text = "暂停项目";
                }
                else if (Request["projectstatus"].ToString().Equals("4"))
                {
                    LB_title.Text = "立项草稿箱";
                }
                else if (Request["projectstatus"].ToString().Equals("5"))
                {
                    LB_title.Text = "完成项目";
                    Button_delete.Visible = false;
                }
                else if (Request["projectstatus"].ToString().Equals("99"))
                {
                    LB_title.Text = "已删除项目";
                    Button_delete.Visible = false;
                }


                string userid = "1";
                if (null != user_model)
                {
                    userid = user_model.ID;
                }

                //显示我的项目的列表信息
                //ShowListInfo(userid, type);
                ShowListInfo(userid);

            }
           
        }

        /// <summary>
        /// 显示我的项目的列表信息
        /// </summary>
        //protected void ShowListInfo(string userid,string type)
        protected void ShowListInfo(string userid)
        {
            try
            {
                //项目状态
                //string projectstatus = DDL_ProjectStatus.SelectedValue.ToString();
                string projectstatus = Request["projectstatus"].ToString();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                //*************************获取该登陆者负责或参与或创建的项目

                //如果查找的是已删除的项目，就直接找出delflag = 1的，则不需要并联状态了。
                if (projectstatus.ToString().Equals("99"))
                {
                    //我负责的项目
                    string sql1 = " SELECT * FROM vProject_Projects WHERE LeaderID='" + userid + "' and DELFLAG=1 ";


                    dt1 = pageControl.doSql(sql1).Tables[0];

                    //我参与的项目
                    string sql2 = "  SELECT  * FROM  vProject_Projects WHERE  DELFLAG=1 and id in(select Projectid from Project_UserList where userid='" + userid + "' and status='1') and NAMES<>'无' and NAMES<>'日常项目' and NAMES<>'-无-'";

                    dt2 = pageControl.doSql(sql2).Tables[0];

                    //DataTable dt3 = null;
                    if (projectstatus != "1" && projectstatus != "3" && projectstatus != "5")
                    {
                        //我创建的项目
                        string sql3 = "  SELECT * FROM vProject_Projects WHERE SendUserID='" + userid + "' and DELFLAG=1 ";

                        dt3 = pageControl.doSql(sql3).Tables[0];
                    }

                }
                else
                {
                    //我负责的项目
                    string sql1 = " SELECT * FROM vProject_Projects WHERE (SendUserID='" + userid + "' OR LeaderID='" + userid + "')  and DELFLAG=0    and (Status=" + projectstatus + ")";


                     dt1 = pageControl.doSql(sql1).Tables[0];

                    //我参与的项目
                    string sql2 = "  SELECT  * FROM  vProject_Projects WHERE  DELFLAG=0 and id in(select Projectid from Project_UserList where userid='" + userid + "' and status='1')  and (Status=" + projectstatus + ") and NAMES<>'无' and NAMES<>'日常项目' and NAMES<>'-无-'";

                     dt2= pageControl.doSql(sql2).Tables[0];

                    //DataTable dt3 = null;
                    if (projectstatus != "1" && projectstatus != "3" && projectstatus != "5")
                    {
                        //我创建的项目
                        string sql3 = "  SELECT * FROM vProject_Projects WHERE SendUserID='" + userid + "' and DELFLAG=0   and (Status=" + projectstatus + ")";

                        dt3 = pageControl.doSql(sql3).Tables[0];
                    }
                }


                //将“我负责的项目”和“我参与的项目”及“我创建的项目”的三个结果集合并在一起（因为结构相同），并且去除掉重复的记录
                //从而形成一个新结果集
                DataTable Newdt =  new DataTable();

                //我创建的项目
                if(null!=dt3 && dt3.Rows.Count>0)
                {
                    for (int i = 0; i < dt3.Columns.Count; i++)
                    {
                        Newdt.Columns.Add(dt3.Columns[i].ColumnName);//有重载的方法，可以加入列数据的类型
                    }

                    for (int i = 0; i < dt3.Rows.Count;i++ )
                    {
                        //在这里借用TEL这个字段来做一个标记，暂存一下2这个数字，表示的是“我创建的项目”
                        dt3.Rows[i]["TEL"] = "2";
                        Newdt.ImportRow(dt3.Rows[i]);
                    }
                }

                //我负责的项目
                if (null != dt1 && dt1.Rows.Count > 0)
                {
                    if (!(Newdt.Columns.Count > 0))
                    {
                        for (int i = 0; i < dt1.Columns.Count; i++)
                        {
                            Newdt.Columns.Add(dt1.Columns[i].ColumnName);//有重载的方法，可以加入列数据的类型
                        }
                    }

                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        //在这里借用TEL这个字段来做一个标记，暂存一下0这个数字，表示的是“我负责的项目”
                        dt1.Rows[i]["TEL"] = "0";
                        Newdt.ImportRow(dt1.Rows[i]);
                    }
                }

                //我参与的项目
                if (null != dt2 && dt2.Rows.Count > 0)
                {
                    if (!(Newdt.Columns.Count > 0))
                    {
                        for (int i = 0; i < dt2.Columns.Count; i++)
                        {
                            Newdt.Columns.Add(dt2.Columns[i].ColumnName);//有重载的方法，可以加入列数据的类型
                        }
                    }

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        //在这里借用TEL这个字段来做一个标记，暂存一下1这个数字，表示的是“我参与的项目”
                        dt2.Rows[i]["TEL"] = "1";
                        Newdt.ImportRow(dt2.Rows[i]);
                    }
                }

                //将一个DATATABLE中的重复项去除掉
                if (null != Newdt)
                {
                    Newdt = common.makeDistinceTable(Newdt, "ID");
                }

                //*************************获取该登陆者负责或参与或创建的项目



                ////项目状态
                //string projectstatus = DDL_ProjectStatus.SelectedValue.ToString();

                //DataTable dt = new DataTable();
                //string sql = "";


                ////默认的是进入到“我参与的项目”中；
                //if (type.Equals("0"))
                //{
                //    sql = " SELECT * FROM vProject_Projects WHERE LeaderID='" + userid + "' and DELFLAG=0  ";

                //    if (projectstatus.Equals(""))
                //    {
                //        sql = sql + " and (Status=1 or Status=3 or Status=5) ";
                //    }
                //    else
                //    {
                //        sql = sql + " and (Status=" + projectstatus + ")";
                //    }

                //}
                //else if (type.Equals("2"))
                //{
                //    sql = " SELECT * FROM vProject_Projects WHERE SendUserID='" + userid + "' and DELFLAG=0 ";

                //    if (projectstatus.Equals(""))
                //    {
                //        sql = sql + " and (Status=0 or Status=2 or Status=4) ";
                //    }
                //    else
                //    {
                //        sql = sql + " and (Status=" + projectstatus + ")";
                //    }
                //}
                //else
                //{
                //    sql = " SELECT  * FROM  vProject_Projects WHERE  DELFLAG=0 and id in(select Projectid from Project_UserList where userid='" + userid + "' and status='1') ";

                //    if (projectstatus.Equals(""))
                //    {
                //        sql = sql + " and (Status=1 or Status=3 or Status=5) ";
                //    }
                //    else
                //    {
                //        sql = sql + " and (Status=" + projectstatus + ")";
                //    }
                //}


                //dt = pageControl.doSql(sql).Tables[0];

                if (Newdt.Rows.Count > 0)
                {
                    //当获取到的数据集不为空的时候，显示在GridView1中
                    GridView1.Visible = true;
                    GridView1.DataSource = Newdt;//指定GridView1的数据是dv
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
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
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#BCE2F9';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    CheckBox checkbox1 = (CheckBox)e.Row.Cells[0].FindControl("CheckBox_choose");
                    Label lb_choose = (Label)e.Row.Cells[0].FindControl("LB_index");

                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    //项目的ID
                    string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    hid.Value = ID;

                    //项目状态
                    string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                    //删除标记
                    string DELFLAG = DataBinder.Eval(e.Row.DataItem, "DELFLAG").ToString();

                    //项目类型（在查找结果并合并结果集时借用的TEL来存放项目类型的）
                    string type = DataBinder.Eval(e.Row.DataItem, "TEL").ToString();
                   
                    //项目的类型：0表示临时项目；1表示正常项目 
                    string ProjectType = DataBinder.Eval(e.Row.DataItem, "ProjectType").ToString();
                    string typenames = "";
                    if (ProjectType == "0")
                    {
                        typenames = "临时项目";
                    }
                    else
                    {
                        typenames = "普通项目";
                    }

                    e.Row.Cells[8].Text = "<a href=\"javascript:window.showModalDialog('/Admin/SystemProjectManage/ProjectInfo/show.aspx?ID=" + ID + " ','','dialogWidth=726px;dialogHeight=400px');\" target='_self' title='项目详细信息''>项目详细</a>";

                    if (DELFLAG.Equals("1"))
                    {
                        e.Row.Cells[3].Text = "<font color='red'>已删除</font>";
                        checkbox1.Visible = false;
                        lb_choose.Visible = true;

                    }
                    else
                    {
                        switch (status)
                        {
                            case "0":
                                e.Row.Cells[3].Text = "待审核";
                                checkbox1.Visible = true;
                                lb_choose.Visible = false;
                                break;
                            case "1":
                                e.Row.Cells[3].Text = "运行中";
                                checkbox1.Visible = true;
                                lb_choose.Visible = false;
                                break;
                            case "2":
                                e.Row.Cells[3].Text = "<font color='red'>审核不通过</font>";
                                break;
                            case "3":
                                e.Row.Cells[3].Text = "暂停";
                                checkbox1.Visible = true;
                                lb_choose.Visible = false;
                                break;
                            case "4":
                                e.Row.Cells[3].Text = "草稿箱中";
                                checkbox1.Visible = true;
                                lb_choose.Visible = false;
                                break;
                            case "5":
                                e.Row.Cells[3].Text = "已完成";
                                checkbox1.Visible = false;
                                lb_choose.Visible = true;
                                break;
                        }
                    }

                    //如果项目处于1,3,5状态下，则只判断当前用户是不是参与者和负责人，不用判断是不是项目的创建者：唐春龙2010-09-11
                    string name = DataBinder.Eval(e.Row.DataItem, "NAMES").ToString();
                    if (status == "1" || status == "3" || status == "5")
                    {
                        if (type.Equals("1"))
                        {
                            e.Row.Cells[1].Text = "<table><tr><td width='16' align='center'><img src='/Admin/images/OAimages/cyr.jpg' title='我参与的项目'></td><td align='left'><a href='/Admin/personalProjectManage/OAtask/manage.aspx?ID=" + ID + "' target='_self' ><span title='点击项目名称可以进入此项目的任务管理页面！" + typenames + "'>" + name + "</span></a></td></tr></table>";
                        }
                        else
                        {
                            e.Row.Cells[1].Text = "<table><tr><td width='16' align='center'><img src='/Admin/images/OAimages/fzr.jpg' title='我负责的项目'></td><td align='left'><a href='/Admin/personalProjectManage/OAtask/manage.aspx?ID=" + ID + "' target='_self' ><span title='点击项目名称可以进入此项目的任务管理页面！" + typenames + "'>" + name + "</span></a></td></tr></table>";
                        }
                    }
                    else
                    {
                        //string type = DDL_ProjectType.SelectedValue.ToString();
                        //项目名称
                        if (type.Equals("2"))
                        {
                            //如果是“已删除项目”或者“暂停项目”或者“完成项目”这三种类型，即使是自己创建的，也不能再编辑了
                            if (Request["projectstatus"].ToString().Equals("99") || Request["projectstatus"].ToString().Equals("3") || Request["projectstatus"].ToString().Equals("5"))
                            {
                                e.Row.Cells[1].Text = "<table><tr><td width='16' align='center'><img src='/Admin/images/OAimages/cjr.jpg' title='我创建的项目'></td><td align='left'>" + name + "</td></tr></table>";
                            }
                            else
                            {
                                e.Row.Cells[1].Text = "<table><tr><td width='16' align='center'><img src='/Admin/images/OAimages/cjr.jpg' title='我创建的项目'></td><td align='left'><a href='modify.aspx?ID=" + ID + "&status=" + status + "' target='_self'><span title='点击项目名称可对此项目进行编辑或删除操作！'>" + name + "</span></a></td></tr></table>";

                            }
                        }
                        else
                        {
                            e.Row.Cells[1].Text = name;
                        }
                    }

                    //项目创建者ID
                    string SendUserID = DataBinder.Eval(e.Row.DataItem, "SendUserID").ToString();
                    //登陆者的ID
                    string loginuserid = Session["LoginID"].ToString();

                    //如果登陆者就是创建者，则有权限删除此条项目信息
                    if (SendUserID.Equals(loginuserid))
                    {
                        checkbox1.Enabled = true;
                    }
                    else
                    {
                        checkbox1.Enabled = false;
                    }

                }
                else//如果是标头部分
                {
                    //全选框
                    CheckBox CB_All = (CheckBox)e.Row.Cells[0].FindControl("CheckBox_All");
                    //全选字
                    Label LB_Choose = (Label)e.Row.Cells[0].FindControl("LB_Choose");

                    //如果是“删除项目”或者是“完成项目”，则不能再进行删除操作
                    if (Request["projectstatus"].ToString().Equals("99") || Request["projectstatus"].ToString().Equals("5"))
                    {
                        CB_All.Visible = false;
                        LB_Choose.Text = "序号";
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 项目类型下拉列表触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void DDL_ProjectType_Changed(object sender, EventArgs e)
        //{
        //    //清空项状态列表重新加载
        //    DDL_ProjectStatus.Items.Clear();
        //    if (DDL_ProjectType.SelectedValue.Equals("0") || DDL_ProjectType.SelectedValue.Equals("1"))
        //    {
        //        ListItem li = new ListItem("全部", "");
        //        DDL_ProjectStatus.Items.Add(li);

        //        ListItem li1 = new ListItem("正常运行", "1");
        //        DDL_ProjectStatus.Items.Add(li1);

        //        ListItem li2 = new ListItem("暂停", "3");
        //        DDL_ProjectStatus.Items.Add(li2);

        //        ListItem li3 = new ListItem("已完成", "5");
        //        DDL_ProjectStatus.Items.Add(li3);

        //    }else
        //    {
        //        ListItem li = new ListItem("全部", "");
        //        DDL_ProjectStatus.Items.Add(li);

        //        ListItem li1 = new ListItem("待审核", "0");
        //        DDL_ProjectStatus.Items.Add(li1);

        //        ListItem li2 = new ListItem("审核不通过", "2");
        //        DDL_ProjectStatus.Items.Add(li2);

        //        ListItem li3 = new ListItem("草稿箱中", "4");
        //        DDL_ProjectStatus.Items.Add(li3);

        //    }
        //    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

        //    ShowListInfo(user_model.ID, DDL_ProjectType.SelectedValue.ToString());

        //    if (DDL_ProjectType.SelectedValue.ToString().Equals("2") && DDL_ProjectStatus.SelectedValue.ToString().Equals("4"))
        //    {
        //        //设置模板页中的管理值
        //        (Master.FindControl("Label_navigation") as Label).Text = "项目 > 立项草稿箱 ";
        //        //设置模板页中的管理值
        //    }
        //    else
        //    {
        //        //设置模板页中的管理值
        //        (Master.FindControl("Label_navigation") as Label).Text = "项目 > 我的项目 ";
        //        //设置模板页中的管理值
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void DDL_ProjectStatus_Changed(object sender, EventArgs e)
        //{
        //    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

        //    ShowListInfo(user_model.ID);

        //    //if (DDL_ProjectStatus.SelectedValue.ToString().Equals("4"))
        //    //{
        //    //    //设置模板页中的管理值
        //    //    (Master.FindControl("Label_navigation") as Label).Text = "项目 > 立项草稿箱 ";
        //    //    //设置模板页中的管理值
        //    //}
        //    //else
        //    //{
        //    //    //设置模板页中的管理值
        //    //    (Master.FindControl("Label_navigation") as Label).Text = "项目 > 我的项目 ";
        //    //    //设置模板页中的管理值
        //    //}
        //}

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

                        if(cb.Enabled==true)
                        {
                            cb.Checked = isCheck;
                        }
                    }
                }

            }
            catch
            {
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
                            //获取到当前项目的基本信息
                            projects_model = projects_bll.GetModel(int.Parse(hid.Value.ToString()));
                            //将删除标记设为1
                            projects_model.DELFLAG = 1;

                            projects_bll.Update(projects_model);


                            //同时删除faceshowmessage中的projectid = ID,的数据，同时置DELFLAG=1;

                            Dianda.BLL.Project_ProjectsExt projectsExt = new Dianda.BLL.Project_ProjectsExt();

                            string sqlwhere = " ProjectID = '" + hid.Value.ToString() + "'";

                            projectsExt.DeleteTableData(sqlwhere, "FaceShowMessage");

                            //添加操作日志

                            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                            bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "系统项目管理", "删除" + projects_model.NAMES + "项目成功");

                            //添加操作日志
                        }
                    }

                    //tag.Text = "操作成功！";

                    //string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\"); location.href = \"manage.aspx?pageindex=" + Request["pageindex"]  + "\";</script>";
                    //Response.Write(coutws);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入我的项目页面');javascript:location='manage.aspx?projectStatus=" + Request["projectstatus"].ToString() + "';</script>", false);
                }

            }

        }

    }
}
