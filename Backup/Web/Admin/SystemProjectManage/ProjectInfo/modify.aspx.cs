using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dianda.Web.Admin.SystemProjectManage.ProjectInfo
{
    public partial class modify : System.Web.UI.Page
    {
        Dianda.COMMON.pageControl pagecontrol = new Dianda.COMMON.pageControl();
        Dianda.Model.Project_Projects project_model = new Dianda.Model.Project_Projects();
        Dianda.BLL.Project_Projects project_bll = new Dianda.BLL.Project_Projects();
        Dianda.Model.Cash_Message cashmessage_model = new Dianda.Model.Cash_Message();
        Dianda.BLL.Cash_Message cashmessage_bll = new Dianda.BLL.Cash_Message();
        Dianda.COMMON.fileUploads fileup = new Dianda.COMMON.fileUploads();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //项目ID
                string ProjectId = Request["ID"];
                //显示项目的基本信息
                ShowProjectInfo(ProjectId);
                //初始化下拉列表信息
                ShowDDLInfo();


                //设置模板页中的管理值
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 项目管理 > 编辑项目";
                //设置模板页中的管理值
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        protected void ShowProjectInfo(string ProjectId)
        {
            //获取到项目的基本信息
            project_model = project_bll.GetModel(int.Parse(ProjectId));

            //项目类型
            if (project_model.ProjectType.ToString().Equals("0"))//如果是个人/临时项目
            {
                //审批人
                div_CheckUserID.Visible = false;
                //预计经费
                //div_CashTotal.Visible = false;

                RL_ProjectType.SelectedValue = "0";
            }
            else
            {
                //审批人
                div_CheckUserID.Visible = true;
                //预计经费
               // div_CashTotal.Visible = true;

                RL_ProjectType.SelectedValue = "1";
            }
            //项目类型是不可以进行编辑的
            RL_ProjectType.Enabled = false;

            //项目名称
            NAME.Text = project_model.NAMES;
            //项目状态
            RadioButtonList_projectstatu.SelectedValue = project_model.Status.ToString();
            //项目预计起始时间
            TB_StartTime.Value = Convert.ToDateTime(project_model.StartTime.ToString()).ToString("yyyy-MM-dd");
            //项目预计结束时间
            TB_EndTime.Value = Convert.ToDateTime(project_model.EndTime.ToString()).ToString("yyyy-MM-dd");
            //项目概要
            Overviews.Value = project_model.Overviews.ToString();

            if (RL_ProjectType.SelectedValue.ToString().Equals("1"))//当项目类型为正常项目时才有预计经费项
            {
                //经费单位
                if (project_model.CashDw != null && project_model.CashDw.ToString().Equals("万元"))
                {
                    RB_cashtotal.SelectedValue = "1";
                    //预计经费
                    CashTotal.Text = (Convert.ToDecimal(project_model.CashTotal.ToString()) / 10000).ToString();
                }
                else
                {
                    RB_cashtotal.SelectedValue = "0";
                    //预计经费
                    CashTotal.Text = project_model.CashTotal.ToString();
                }
            }


            //资金卡选择
            string CashCardID = project_model.CashCardID.ToString();
            RB_CashCardID.Checked = true;
            //如果资金卡为0，说明在新建项目时选择的是新建资金卡
            //if (CashCardID.Equals("0"))
            //{
            //    div_cash.Visible = true;
            //    RB_NewAddCashCard.Checked = true;
            //    RB_CashCardID.Checked = false;

            //    DataSet ds = cashmessage_bll.GetList(" ProjectID = " + project_model.ID);

            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        //资金卡初始金额
            //        TB_LimitNums.Text = ds.Tables[0].Rows[0]["LimitNums"].ToString();
            //        //新建备注说明
            //        TB_Notes.Text = ds.Tables[0].Rows[0]["Notes"].ToString();
            //    }
            //}
            //else
            //{
            //    div_cash.Visible = false;
            //    RB_NewAddCashCard.Checked = false;
            //    RB_CashCardID.Checked = true;
            //}


            if (!project_model.Attachments.Equals(""))
            {
                //老的文件的地址
                HiddenField_oldpath.Value = project_model.Attachments.ToString();

                LB_view.Text = "<a href='" + project_model.Attachments.ToString() + "' target='_blank'>点击查看附件</a>";
            }
            else
            {
                LB_view.Visible = false;
            }

        }


        /// <summary>
        /// 初始化下拉列表的值
        /// </summary>
        protected void ShowDDLInfo()
        {
            try
            {
                string CashflagID = "";

                //显示项目负责人下拉列表
                DataTable dt = new DataTable();

                string sql = " SELECT ID,DepartMentID, USERNAME, REALNAME FROM USER_Users WHERE (DELFLAG = 0)  AND (IsManager = 1) AND (WorkStats = 1)  ORDER BY REALNAME,ID ";

                dt = pagecontrol.doSql(sql).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string ID = dt.Rows[i]["ID"].ToString();
                        string DepartMentID = dt.Rows[i]["DepartMentID"].ToString();
                        string REALNAME = dt.Rows[i]["REALNAME"].ToString();
                        string USERNAME = dt.Rows[i]["USERNAME"].ToString();

                        ListItem li = new ListItem(REALNAME + "(" + USERNAME + ")", ID + "|" + DepartMentID);
                        DDL_LeaderID.Items.Add(li);

                        if (li.Value.ToString().Split('|')[0].ToString().Equals(project_model.LeaderID))
                        {
                            li.Selected = true;
                            CashflagID = li.Value.ToString().Split('|')[0].ToString();
                        }
                    }
                }
                else//因为项目负责人是非空项，如果没有项目负责人的话是不可以进行项目的申请的。
                {
                    ListItem li = new ListItem("没有可选项目负责人", "");
                    DDL_LeaderID.Items.Add(li);

                    DDL_LeaderID.Enabled = false;
                    Button_applyfor.Enabled = false;
                }


                //显示可供参与的部门信息 。
                DataTable dt_dep = new DataTable();
                string sql1 = " SELECT ID, NAME FROM USER_Groups WHERE (DELFLAG = 0) AND (TAGS = '部门') ORDER BY ISMOREN ";
                dt_dep = pagecontrol.doSql(sql1).Tables[0];

                if (dt_dep.Rows.Count > 0)
                {
                    CB_DepartmentID.DataSource = dt_dep.DefaultView;
                    CB_DepartmentID.DataTextField = "NAME";
                    CB_DepartmentID.DataValueField = "ID";
                    CB_DepartmentID.DataBind();

                    //在项目表中的部门字段
                    string DepartmentID = project_model.DepartmentID.ToString();

                    //因为在项目表中部门以‘，’分开。故以‘，’将其分割
                    string[] Department = DepartmentID.Split(',');

                    for (int i = 0; i < dt_dep.Rows.Count; i++)
                    {
                        for (int j = 0; j < Department.Length; j++)
                        {
                            if (Department[j].ToString() == CB_DepartmentID.Items[i].Value.ToString())
                            {
                                CB_DepartmentID.Items[i].Selected = true;

                                if (DDL_LeaderID.SelectedValue.ToString().Split('|')[1].ToString().Equals(Department[j].ToString()))
                                {
                                    CB_DepartmentID.Items[i].Enabled = false;
                                }
                            }
                        }
                    }


                }
                else//因为参与部门是非空项，所以如果没有可供参与的部门的话，是不可以进行项目的申请的。
                {
                    CB_DepartmentID.Enabled = false;
                    Label_dep.Visible = true;
                    Button_applyfor.Enabled = false;
                }

                //根据项目负责人来动态显示资金卡下拉列表
                if (!CashflagID.Equals(""))
                {
                    SetDDL_CashCardID(CashflagID);
                }

                //显示所属分类的下拉列表
                DataTable dt_col = new DataTable();
                //string sql2 = " SELECT ID, Names FROM Project_Columns WHERE (DELFLAG = 0) AND (UpID <> 0) ";
                string sql2 = " SELECT *  FROM Project_Columns WHERE (DELFLAG = 0) order by COLUMNSPATH";
                dt_col = pagecontrol.doSql(sql2).Tables[0];

                //if (dt_col.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt_col.Rows.Count; i++)
                //    {
                //        ListItem li = new ListItem(dt_col.Rows[i]["Names"].ToString(), dt_col.Rows[i]["ID"].ToString());
                //        DDL_COLUMN.Items.Add(li);

                //        if (li.Value.ToString().Equals(project_model.ColumnsID.ToString()))
                //        {
                //            li.Selected = true;
                //        }
                //    }

                //}
                if (dt_col.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_col.Rows.Count; i++)
                    {
                        string parentid = dt_col.Rows[i]["UpID"].ToString();
                        string path = dt_col.Rows[i]["COLUMNSPATH"].ToString();

                        if (parentid != "0")
                        {
                            string kg = null;
                            int lens = path.Split('/').Length;
                            for (int x = 0; x < lens; x++)
                            {
                                kg += "··";
                            }
                            dt_col.Rows[i]["Names"] = kg + "|--" + dt_col.Rows[i]["Names"].ToString() + "  [ " + dt_col.Rows[i]["TYPES"].ToString() + " ]";
                        }
                        ListItem L1 = new ListItem();
                        L1.Text = dt_col.Rows[i]["Names"].ToString();
                        L1.Value = dt_col.Rows[i]["ID"].ToString();
                        DDL_COLUMN.Items.Add(L1);

                        if (L1.Value.ToString().Equals(project_model.ColumnsID.ToString()))
                        {
                            L1.Selected = true;

                            if (L1.Text.Contains("总项目"))
                            {
                                LB_COLUMNINFO.Text = "<a href=\"javascript:window.showModalDialog('/Admin/personalProjectManage/OAproject/show.aspx?ID=" + L1.Value.ToString() + "','','dialogWidth=715px;dialogHeight=250px');\" style='text-decoration: none' title='总项目分类详细信息'>显示该总项目详细</a>";
                                LB_COLUMNINFO.Visible = true;
                            }
                            else
                            {
                                LB_COLUMNINFO.Text = "";
                                LB_COLUMNINFO.Visible = false;
                            }
                        }
                    }


                    //根据所属分类动态的显示这个分类的管理人，此管理即作为项目的审核人，供项目创建者来选择。

                    string sql3 = " SELECT *  FROM Project_Columns WHERE ID = '" + DDL_COLUMN.SelectedValue.ToString() + "'";

                    DataTable dt_checkuser = pagecontrol.doSql(sql3).Tables[0];
                    if (dt_checkuser.Rows.Count > 0)
                    {
                        //如果项目管理人员不为空
                        if (null != dt_checkuser.Rows[0]["UserID"] && !(dt_checkuser.Rows[0]["UserID"].ToString().Equals("")))
                        {
                            string[] CheckUserId = dt_checkuser.Rows[0]["UserID"].ToString().Split(',');
                            string[] CheckUserName = dt_checkuser.Rows[0]["UserInfos"].ToString().Split(',');

                            for (int k = 0; k < CheckUserId.Length; k++)
                            {
                                ListItem L = new ListItem(CheckUserName[k].ToString(), CheckUserId[k].ToString());
                                DDL_CheckUserID.Items.Add(L);

                                if (L.Value.ToString().Equals(project_model.DoUserID))
                                {
                                    L.Selected = true;
                                }
                            }

                            LB_CheckUserInfo.Visible = false;
                        }
                        else
                        {
                            ListItem L = new ListItem("暂无可供选择的审批人", "");
                            DDL_CheckUserID.Items.Add(L);


                            LB_CheckUserInfo.Visible = true;
                            Button_applyfor.Enabled = false;
                        }
                    }
                    else
                    {
                        ListItem L = new ListItem("暂无可供选择的审批人", "");
                        DDL_CheckUserID.Items.Add(L);


                        LB_CheckUserInfo.Visible = true;
                        Button_applyfor.Enabled = false;
                    }


                }
                else
                {
                    ListItem li = new ListItem("暂无可选分类", "");
                    DDL_COLUMN.Items.Add(li);

                    ListItem L = new ListItem("暂无可供选择的审批人", "");
                    DDL_CheckUserID.Items.Add(L);

                    DDL_CheckUserID.Enabled = false;
                    DDL_COLUMN.Enabled = false;
                    Button_applyfor.Enabled = false;
                }

            }
            catch
            { }
        }


        /// <summary>
        /// 根据项目负责人来动态显示资金卡下拉列表
        /// </summary>
        /// <param name="CashflagID"></param>
        protected void SetDDL_CashCardID(string CashflagID)
        {
            DataTable dt3 = new DataTable();

            string sql2 = " SELECT ID, CardNum, CardName, LimitNums FROM Cash_Cards WHERE (CardholderID = '" + CashflagID + "') AND Statas = 1 ";
            dt3 = pagecontrol.doSql(sql2).Tables[0];

            if (dt3.Rows.Count > 0)
            {
                DDL_CashCardID.Enabled = true;
                DDL_CashCardID.Items.Clear();
                for (int j = 0; j < dt3.Rows.Count; j++)
                {
                    string ID = dt3.Rows[j]["ID"].ToString();
                    string CardNum = dt3.Rows[j]["CardNum"].ToString();
                    string CardName = dt3.Rows[j]["CardName"].ToString();
                    string LimitNums = dt3.Rows[j]["LimitNums"].ToString();

                    string showinfo = CardName + "[" + CardNum + "," + LimitNums + "]";

                    ListItem li = new ListItem(showinfo, ID);
                    DDL_CashCardID.Items.Add(li);

                    if (li.Value.ToString().Equals(project_model.CashCardID.ToString()))
                    {
                        li.Selected = true;
                    }

                }

                Button_applyfor.Enabled = true;
            }
            else
            {
                DDL_CashCardID.Items.Clear();
                ListItem li = new ListItem("暂无可选资金卡", "");
                DDL_CashCardID.Items.Add(li);
                DDL_CashCardID.Enabled = false;
               // Button_applyfor.Enabled = false;
            }
        }

        /// <summary>
        /// 资金卡选择切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RB_NewAddCashCard_CheckedChanged(object sender, EventArgs e)
        {
            RB_CashCardID.Checked = false;

            RB_NewAddCashCard.Checked = true;

            div_cash.Visible = true;


            Button_applyfor.Enabled = true;
        }


        /// <summary>
        /// 资金卡选择切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RB_CashCardID_CheckedChanged(object sender, EventArgs e)
        {
            RB_CashCardID.Checked = true;

            RB_NewAddCashCard.Checked = false;

            div_cash.Visible = false;

            //if (DDL_CashCardID.SelectedValue.ToString().Equals(""))
            //{
            //    Button_applyfor.Enabled = false;
            //}
            //else
            //{
            //    Button_applyfor.Enabled = true;
            //}
        }

        /// <summary>
        /// 根据项目负责人来动态显示资金卡下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_LeaderID_Changed(object sender, EventArgs e)
        {
            //DDL_LeaderID是由项目负责人的ID和部门ID共同合成的
            string ID = DDL_LeaderID.SelectedValue.ToString();

            string CashflagID = ID.Split('|')[0].ToString();

            SetDDL_CashCardID(CashflagID);

            SetCB_DepartmentID();
        }

        /// <summary>
        /// 点击重置触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_Click(object sender, EventArgs e)
        {

            NAME.Text = "";

            for (int i = 0; i < CB_DepartmentID.Items.Count; i++)
            {
                if (CB_DepartmentID.Items[i].Selected == true)
                {
                    CB_DepartmentID.Items[i].Selected = false;
                }
            }
            TB_StartTime.Value = "";
            TB_EndTime.Value = "";
            CashTotal.Text = "";
            RB_CashCardID.Checked = true;
            RB_NewAddCashCard.Checked = false;
            Overviews.Value = "";
            div_cash.Visible = false;
            TB_LimitNums.Text = "";
            TB_Notes.Text = "";
        }

        /// <summary>
        /// 点击申请触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_applyfor_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = Request["ID"];
                project_model = project_bll.GetModel(int.Parse(ID));
                //项目审核人
                string douserid = project_model.DoUserID.ToString();
                string projectName = NAME.Text.ToString();

                //检查是否有该项目名称
                bool checkName = pagecontrol.Exists_Name("Project_Projects", "NAMES", projectName, "ID", ID);
                if (checkName)
                {
                    tag.Text = "该项目名称已经存在，请修改！";
                }
                else
                {
                    if (FileUpload1.FileName.Length > 2)
                    {
                        string[] content = fileup.UpFile_COMMONS(FileUpload1, "/AllFileUp/fileup", HiddenField_oldpath.Value.ToString());
                        //1-成功；0-失败；2-类型不支持；3-大小不符合;文件的路径；文件名称；文件类型；图标；大小；操作结果
                        if (content[0] == "0")
                        {
                            tag.Text = "文件上传失败，请重新上传！";
                            return;
                        }
                        else if (content[0] == "2")
                        {
                            tag.Text = "系统不允许此类文件上传,文件上传失败，请重新上传！";
                            return;
                        }
                        else if (content[0] == "3")
                        {
                            tag.Text = "文件上传大小不符合，文件上传失败，请重新上传！";
                            return;
                        }

                        project_model.Attachments = content[1];

                    }

                    Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];

                   // int statusflag = Convert.ToInt32(((Button)sender).CommandArgument.ToString());//获取到触发源

                    //项目名称
                    project_model.NAMES = NAME.Text.ToString();
                    //状态
                    project_model.Status = int.Parse(RadioButtonList_projectstatu.SelectedValue);
                    //项目负责人
                    project_model.LeaderID = DDL_LeaderID.SelectedValue.ToString().Split('|')[0].ToString();
                    ////参与部门
                    //project_model.DepartmentID = "";
                    ////参与部门名称
                    //project_model.DepartmentNames = "";
                    //for (int i = 0; i < CB_DepartmentID.Items.Count; i++)
                    //{
                    //    if (CB_DepartmentID.Items[i].Selected == true)
                    //    {
                    //        project_model.DepartmentID = project_model.DepartmentID + CB_DepartmentID.Items[i].Value + ",";

                    //        project_model.DepartmentNames = project_model.DepartmentNames + CB_DepartmentID.Items[i].Text + ",";
                    //    }
                    //}
                    ///* 截掉最后一个逗号*/
                    //if (project_model.DepartmentID.Length > 0)
                    //{
                    //    project_model.DepartmentID = project_model.DepartmentID.Substring(0, project_model.DepartmentID.Length - 1);
                    //    project_model.DepartmentNames = project_model.DepartmentNames.Substring(0, project_model.DepartmentNames.Length - 1);
                    //}

                    //项目预计起始时间
                    project_model.StartTime = Convert.ToDateTime(TB_StartTime.Value.ToString());
                    //项目预计结束时间
                    project_model.EndTime = Convert.ToDateTime(TB_EndTime.Value.ToString());
                    if (RL_ProjectType.SelectedValue.ToString().Equals("1"))//当项目类型为正常项目时才有预计经费项
                    {
                        //项目审核人
                        project_model.DoUserID = DDL_CheckUserID.SelectedValue.ToString();

                        //预计经费
                        if (!CashTotal.Text.ToString().Equals(""))
                        {
                            //project_model.CashTotal = Convert.ToDecimal(CashTotal.Text.ToString());

                            if (RB_cashtotal.SelectedValue.ToString().Equals("1"))//表示经费单位选择的是万元
                            {
                                //经费额度存放的是元
                                project_model.CashTotal = Convert.ToDecimal(CashTotal.Text.ToString()) * 10000;
                                //经费单位
                                project_model.CashDw = "万元";
                            }
                            else
                            {
                                project_model.CashTotal = Convert.ToDecimal(CashTotal.Text.ToString());
                                //经费单位
                                project_model.CashDw = "元";
                            }

                        }
                    }
                    else
                    {
                        //项目审核人
                        project_model.DoUserID = "";
                    }
                    //资金卡选择

                    //DataSet ds1 = cashmessage_bll.GetList(" ProjectID = " + project_model.ID);

                    //if (RB_CashCardID.Checked == true)//如果选择的是资金卡则设为资金卡的ID；
                    //{
                    //    if (DDL_CashCardID.SelectedValue.ToString().Equals(""))
                    //    {
                    //        project_model.CashCardID = 0;

                    //    }else
                    //    {
                    //        project_model.CashCardID = Int16.Parse(DDL_CashCardID.SelectedValue.ToString());
                    //    }
                    //    //如果编辑时选择的是资金卡，但是在cash_message表中发现有此项目的消息记录，则说明
                    //    //在新建此项目时选择的是新建资金卡，而现在如果修改成资金卡，则要将这条消息记录删除
                    //    if (ds1.Tables[0].Rows.Count > 0)
                    //    {
                    //        string cashid = ds1.Tables[0].Rows[0]["ID"].ToString();
                    //        cashmessage_bll.Delete(int.Parse(cashid));
                    //    }

                    //}
                    //else//如果选择的是新建资金卡则设为0,并且需要向cash_message表中加一条记录
                    //{
                    //    project_model.CashCardID = 0;

                    //    //如果原来就有记录,则修改
                    //    if (ds1.Tables[0].Rows.Count > 0)
                    //    {
                    //        //ID
                    //        string cashid = ds1.Tables[0].Rows[0]["ID"].ToString();
                    //        cashmessage_model = cashmessage_bll.GetModel(int.Parse(cashid));
                    //        //资金卡初始金额
                    //        cashmessage_model.LimitNums = Convert.ToDecimal(TB_LimitNums.Text);
                    //        //新建备注说明
                    //        cashmessage_model.Notes = TB_Notes.Text.ToString();

                    //        cashmessage_bll.Update(cashmessage_model);
                    //    }
                    //    else
                    //    {
                    //        //资金卡名称(暂时写的留空)
                    //        cashmessage_model.CardName = "";
                    //        //持卡人
                    //        cashmessage_model.CardholderID = DDL_LeaderID.SelectedValue.Split('|')[0].ToString();
                    //        //项目的ID
                    //        cashmessage_model.ProjectID = project_model.ID;
                    //        //初始金额
                    //        cashmessage_model.LimitNums = Convert.ToDecimal(TB_LimitNums.Text.ToString());
                    //        //填写的时间
                    //        cashmessage_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToString());
                    //        //发出这个消息的用户的ID
                    //        cashmessage_model.SendUserID = user_model.ID;
                    //        //备注说明
                    //        cashmessage_model.Notes = TB_Notes.Text.ToString();
                    //        //是否已经阅读
                    //        cashmessage_model.IsRead = 0;
                    //        //消息的状态
                    //        cashmessage_model.Status = 1;

                    //        Session["Cash_Message_temps"] = cashmessage_model;

                    //        //向信息表中添加一条新建资金卡的记录
                    //        cashmessage_bll.Add(cashmessage_model);
                    //    }
                    //}
                    //项目概要
                    project_model.Overviews = Overviews.Value.ToString();
                    //申请时间
                    project_model.DATETIME = Convert.ToDateTime(DateTime.Now.ToString());

                    //所属分类
                    project_model.ColumnsID =int.Parse(DDL_COLUMN.SelectedValue);

                    //修改项目
                    project_bll.Update(project_model);


                    //根据项目负责人的改变来改变项目组成员

                    string sql_userlist = " SELECT ID, ProjectID, UserID, Status, DATETIME FROM Project_UserList WHERE (ProjectID = '" + ID + "') AND (UserID = '" + project_model.LeaderID + "') AND (Status = '1')";
                    DataTable dt = pagecontrol.doSql(sql_userlist).Tables[0];

                    if (!(dt.Rows.Count > 0))
                    {
                        Dianda.BLL.Project_UserList project_userlist_bll = new Dianda.BLL.Project_UserList();
                        Dianda.Model.Project_UserList project_userlist_model = new Dianda.Model.Project_UserList();

                        project_userlist_model.ID = project_userlist_bll.GetMaxId();

                        //项目ID
                        project_userlist_model.ProjectID = project_model.ID;
                        //项目组成员
                        project_userlist_model.UserID = project_model.LeaderID;
                        //状态
                        project_userlist_model.Status = 1;
                        //时间
                        project_userlist_model.DATETIME = DateTime.Now;

                        //向Project_UserList加条记录
                        project_userlist_bll.Add(project_userlist_model);
                    }

                    //根据所选择的分类的改变来动态的改变项目审批人的下拉列表。这样原来这个项目的审核人就发生了更改则需要将原来审核表中的UserID改成新的
                    string sql_checkuser = " UPDATE Project_ShenheList SET UserID = '" + DDL_CheckUserID.SelectedValue.ToString() + "',Status =" + RadioButtonList_projectstatu.SelectedValue.ToString()+ " WHERE (ProjectID = " + project_model.ID + ") AND (UserID = '" + douserid + "') ";
                    pagecontrol.doSql(sql_checkuser);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "<script>alert('操作成功！现在进入列表页面');javascript:location='manage.aspx?pageindex=" + Request["pageindex"] + "';</script>", false);

                    //添加操作日志
                    Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    bsyslog.addlogs(user_model.REALNAME + "(" + user_model.USERNAME + ")", "系统项目管理", "编辑" + project_model.NAMES + "项目成功");
                    //添加操作日志

                    //tag.Text = "操作成功! 点击“返回”按钮进入项目信息页面！";
                    //addproject.Visible = false;
                    //goback.Visible = true;
                }

            }
            catch
            {

            }
        }

        /// <summary>
        /// 返回触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_reset_onclick(object sender, EventArgs e)
        {
            Response.Redirect("manage.aspx?pageindex=" + Request["pageindex"]);
        }


        /// <summary>
        /// 根据所选择的项目负责人来动态的选择默认的部门,选中后并且设置为不可用
        /// </summary>
        protected void SetCB_DepartmentID()
        {
            try
            {
                for (int i = 0; i < CB_DepartmentID.Items.Count; i++)
                {
                    //下面做的目的是要将上一次默认选上的并且不可用的部门恢复成正常情况。
                    CB_DepartmentID.Items[i].Enabled = true;

                    //部门的ID
                    string id = CB_DepartmentID.Items[i].Value.ToString();
                    //所选择的项目负责人所属的部门ID
                    string deptid = DDL_LeaderID.SelectedValue.Split('|')[1].ToString();
                    if (id.Equals(deptid))
                    {
                        CB_DepartmentID.Items[i].Selected = true;
                        CB_DepartmentID.Items[i].Enabled = false;

                    }
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// 根据所属分类下拉列表的改变来改变后面详细信息的显示与否，如果是总项目，则需要显示此分类的详细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_COLUMN_Changed(object sender, EventArgs e)
        {
            try
            {
                //选择的所属分类
                string column = DDL_COLUMN.SelectedItem.Text.ToString();

                if (column.Contains("总项目"))
                {
                    LB_COLUMNINFO.Text = "<a href=\"javascript:window.showModalDialog('/Admin/personalProjectManage/OAproject/show.aspx?ID=" + DDL_COLUMN.SelectedValue.ToString() + "','','dialogWidth=715px;dialogHeight=250px');\"  style='text-decoration: none' title='总项目分类详细信息'>显示该总项目详细</a>";
                    LB_COLUMNINFO.Visible = true;
                }
                else
                {
                    LB_COLUMNINFO.Text = "";
                    LB_COLUMNINFO.Visible = false;
                }



                //根据所属分类动态的显示这个分类的管理人，此管理即作为项目的审核人，供项目创建者来选择。

                string sql3 = " SELECT *  FROM Project_Columns WHERE ID = '" + DDL_COLUMN.SelectedValue.ToString() + "'";

                DataTable dt_checkuser = pagecontrol.doSql(sql3).Tables[0];
                DDL_CheckUserID.Items.Clear();
                if (dt_checkuser.Rows.Count > 0)
                {
                    //如果项目管理人员不为空
                    if (null != dt_checkuser.Rows[0]["UserID"] && !(dt_checkuser.Rows[0]["UserID"].ToString().Equals("")))
                    {
                        string[] CheckUserId = dt_checkuser.Rows[0]["UserID"].ToString().Split(',');
                        string[] CheckUserName = dt_checkuser.Rows[0]["UserInfos"].ToString().Split(',');

                        for (int k = 0; k < CheckUserId.Length; k++)
                        {
                            ListItem li = new ListItem(CheckUserName[k].ToString(), CheckUserId[k].ToString());
                            DDL_CheckUserID.Items.Add(li);
                        }

                        LB_CheckUserInfo.Visible = false;
                        Button_applyfor.Enabled = true;
                    }
                    else
                    {
                        ListItem li = new ListItem("暂无可供选择的审批人", "");
                        DDL_CheckUserID.Items.Add(li);

                        LB_CheckUserInfo.Visible = true;
                        Button_applyfor.Enabled = false;
                    }
                }
                else
                {
                    ListItem li = new ListItem("暂无可供选择的审批人", "");
                    DDL_CheckUserID.Items.Add(li);

                    LB_CheckUserInfo.Visible = true;
                    Button_applyfor.Enabled = false;
                }

            }
            catch
            { }
        }
    }
}
