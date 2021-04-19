using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace Dianda.Web.Public
{
    public partial class UserManage : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();
        Dianda.COMMON.common common = new Dianda.COMMON.common();

        BLL.Project_Projects bProjects = new Dianda.BLL.Project_Projects();

        Model.USER_Users mUSER_Users = new Dianda.Model.USER_Users();
        Model.Project_Projects mProjects = new Dianda.Model.Project_Projects();

        #region 参数
        /// <summary>
        /// 选中的值
        /// </summary>
        private string _SelectVal;

        public string SelectVal
        {
            get { return _SelectVal; }
            set { _SelectVal = value; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        private string _Type;

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        /// <summary>
        /// 项目ID
        /// </summary>
        private string _projectid;

        public string Projectid
        {
            get { return _projectid; }
            set { _projectid = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        public void Show_GView_UserManage()
        {
            try
            {
                chkAll.Checked = false;

                //类型不为空并且部门不为空
                if (_Type != "" && _Type != null)
                {
                    mUSER_Users = new Dianda.Model.USER_Users();
                    mUSER_Users = (Model.USER_Users)Session["USER_Users"];

                    DataTable dtBM = new DataTable();
                    DataTable dtRY = new DataTable();

                    string sqlBM = "";
                    string sqlRY = "";

                    //_SelectVal赋默认值
                    if (_SelectVal != null && _SelectVal != "")
                    {
                        HField_ReturnVal.Value = _SelectVal;
                    }

                    //_Type：1 登录人的部门；2 全部门；3 项目的部门；
                    if (_Type == "1")
                    {
                        //按登录人来查找部门
                        string[] DepartMentID_arr = mUSER_Users.DepartMentID.Split(',');
                        for (int i = 0; i < DepartMentID_arr.Length; i++)
                        {
                            if (sqlBM == "")
                            {
                                sqlBM = "SELECT id DepartMentID,Name DepartMentName FROM USER_Groups WHERE (TAGS='部门' and DELFLAG=0) and id = '" + DepartMentID_arr[i] + "'";
                            }
                            else
                            {
                                sqlBM += " union SELECT id DepartMentID,Name DepartMentName FROM USER_Groups WHERE (TAGS='部门' and DELFLAG=0) and id = '" + DepartMentID_arr[i] + "'";
                            }
                        }
                    }
                    else if (_Type == "2")
                    {
                        //显示全部的部门
                        sqlBM = "SELECT ID DepartMentID,Name DepartMentName FROM USER_Groups WHERE (TAGS='部门' and DELFLAG=0)";
                    }
                    else if (_Type == "3")
                    {
                        //显示项目的部门
                        string sql = "select DepartmentID from Project_Projects where id="+_projectid;
                        DataTable dt = pageControl.doSql(sql).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            string DepartID = dt.Rows[0]["DepartmentID"].ToString();
                            if (DepartID != "")
                            {
                                string[] DepartMentID_arr = DepartID.Split(',');
                                for (int i = 0; i < DepartMentID_arr.Length; i++)
                                {
                                    if (sqlBM == "")
                                    {
                                        sqlBM = "SELECT id DepartMentID,Name DepartMentName FROM USER_Groups WHERE (TAGS='部门' and DELFLAG=0) and id = '" + DepartMentID_arr[i] + "'";
                                    }
                                    else
                                    {
                                        sqlBM += " union SELECT id DepartMentID,Name DepartMentName FROM USER_Groups WHERE (TAGS='部门' and DELFLAG=0) and id = '" + DepartMentID_arr[i] + "'";
                                    }
                                }
                            }
                        }
                        
                    }

                    //sql语句不为空的情况，添加排序语句
                    if (sqlBM != "")
                    {
                        sqlBM += " order by DepartMentID";
                    }

                    dtBM = pageControl.doSql(sqlBM).Tables[0];

                    //部门表不为空
                    if (dtBM.Rows.Count > 0)
                    {
                        //查询部门中的人员
                        for (int i = 0; i < dtBM.Rows.Count; i++)
                        {
                            if (sqlRY == "")
                            {
                                sqlRY = "select id,realName,userName,'" + dtBM.Rows[i]["DepartMentID"] + "' departmentid from USER_Users where departmentid like '%" + dtBM.Rows[i]["DepartMentID"] + "%' and DELFLAG=0";
                            }
                            else
                            {
                                sqlRY += " union select id,realName,userName,'" + dtBM.Rows[i]["DepartMentID"] + "' departmentid from USER_Users where departmentid like '%" + dtBM.Rows[i]["DepartMentID"] + "%' and DELFLAG=0";
                            }
                        }
                        dtRY = pageControl.doSql(sqlRY).Tables[0];

                        Session["temp_UserAllUser_session"] = dtBM;
                        Session["temp_SelectUser_session"] = dtRY;

                        GView_UserManage.DataSource = dtBM;
                        GView_UserManage.DataBind();
                    }
                    else
                    {
                        GView_UserManage.DataSource = null;
                        GView_UserManage.DataBind();
                    }
                }
            }
            catch { }
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
                    //取得部门id
                    string ID = DataBinder.Eval(e.Row.DataItem, "DepartMentID").ToString();

                    //找到该行的CheckBox，更改它的id
                    CheckBox depid = (CheckBox)e.Row.FindControl("depid");
                    depid.ID = "depid_" + ID;

                    //找到该行的隐藏控件，给它赋值id
                    HiddenField hid = (HiddenField)e.Row.FindControl("Hid_ID");
                    hid.Value = ID;

                    //找到该行的Panel，更改它的id
                    Panel Pan_UserManage = (Panel)e.Row.FindControl("Pan_UserManage");
                    Pan_UserManage.ID = ID;

                    //得到人员表
                    DataTable dt = (DataTable)Session["temp_SelectUser_session"];
                    //计数
                    int len = 0;

                    //在Panel中动态添加一个table
                    Pan_UserManage.Controls.Add(new LiteralControl("<table width='98%'><tr>"));
                    foreach (DataRow dr in dt.Rows)
                    {
                        //如果该人员的部门id 等于 现在的部门id，继续进行
                        if (dr["departmentid"].ToString() == ID)
                        {
                            //判断是不是新的一行tr
                            if (len == 1)
                            {
                                Pan_UserManage.Controls.Add(new LiteralControl("<tr>"));
                            }
                            //判断是不是第一次进入，第一次进入不用画tr
                            if (len == 0)
                            {
                                len = 1;
                            }
                            //创建一个CheckBox
                            CheckBox CB = new CheckBox();

                            CB.Text = dr["realName"].ToString() + "(" + dr["USERNAME"].ToString() + ")";
                            CB.Attributes.Add("name", dr["id"].ToString());
                            CB.CssClass = "UserManageCss";
                            CB.ID = dr["id"].ToString();
                            //判断是否存在
                            if (_SelectVal != null && _SelectVal != "")
                            {
                                if (_SelectVal.Contains(dr["id"].ToString()))
                                {
                                    CB.Checked = true;
                                }
                            }

                            len++;

                            //添加一列
                            Pan_UserManage.Controls.Add(new LiteralControl("<td width='25%'>"));
                            Pan_UserManage.Controls.Add(CB);
                            Pan_UserManage.Controls.Add(new LiteralControl("</td>"));
                            //当计数到5要结束行，并重新计数
                            if (len == 5)
                            {
                                Pan_UserManage.Controls.Add(new LiteralControl("</tr>"));
                                len = 1;
                            }
                        }
                    }

                    //如果计数不是1要结束行
                    if (len != 1)
                    {
                        for (int i = 1; i <= 5 - len; i++)
                        {
                            Pan_UserManage.Controls.Add(new LiteralControl("<td width='25%'></td>"));
                        }
                        Pan_UserManage.Controls.Add(new LiteralControl("</tr>"));
                    }

                    //结束table
                    Pan_UserManage.Controls.Add(new LiteralControl("</table>"));

                }
            }
            catch
            { }
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
                string[] ReturnVal = HField_ReturnVal.Value.ToString().Split(',');
                for (int i = 0; i < ReturnVal.Length; i++)
                {
                    string itemsvalue = ReturnVal[i].ToString();
                    //判断当前AL中是否已经有了这个数据，如果有了，则不能加入了
                    if (!isinList(al, itemsvalue))
                    {
                        al.Add(itemsvalue);
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
            bool coutw = false;
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

    }
}