using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.DOC_transport
{
    public partial class chooseUser : System.Web.UI.Page
    {
        BLL.USER_ORGAN userorganBll = new Dianda.BLL.USER_ORGAN();
        BLL.USER_Users userBll = new Dianda.BLL.USER_Users();
        COMMON.common commons=new Dianda.COMMON.common();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showOrgan(CheckBoxList_organList);
            }
        }
        /// <summary>
        /// 当GridView1绑定完毕数据集后，可以通过RowDataBound事件给该GRIDVIEW中数据做切合实际的转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    e.Row.Attributes.Add("onmouseover", "e=this.style.backgroundColor; this.style.backgroundColor='#F4F4F4'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=e");

                    string usernames = DataBinder.Eval(e.Row.DataItem, "USERNAME").ToString();
                    string ID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID"));//获取到列表中的每条记录的ID
                  
                    string organ = DataBinder.Eval(e.Row.DataItem, "ORGAN").ToString();
   
                    string organName = "";
                    if (organ != "" && organ != null)
                    {
                        try
                        {
                            Model.USER_ORGAN organModel = new Dianda.Model.USER_ORGAN();
                            BLL.USER_ORGAN organBll = new Dianda.BLL.USER_ORGAN();
                            organModel = organBll.GetModel(organ);
                            if (organModel.ID.ToString() != "")
                            {
                                organName = organModel.NAME.ToString();
                            }
                        }
                        catch
                        {
                        }

                    }
                    e.Row.Cells[4].Text = organName;

                }
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// 显示组织机构
        /// </summary>
        /// <param name="CBL"></param>
        private void showOrgan(CheckBoxList CBL)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = userorganBll.GetList(" delflag=0  order by NAME").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    CBL.DataSource = dt;
                    CBL.RepeatColumns = 6;
                    CBL.DataTextField = "NAME";
                    CBL.DataValueField = "ID";
                    CBL.DataBind();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 当组织机构进行筛选时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBoxList_organList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string organList = "";
                int itemCount = CheckBoxList_organList.Items.Count;//有多少个组织机构
                chkAll.Checked = false;
                for (int i = 0; i < itemCount; i++)
                {
                    if (CheckBoxList_organList.Items[i].Selected)
                    {
                        if (i == itemCount - 1)
                        {
                            organList = organList + CheckBoxList_organList.Items[i].Value.ToString();
                        }
                        else
                        {
                            organList = organList + CheckBoxList_organList.Items[i].Value.ToString() + ",";
                        }
                    }
                }

                showUserList(organList);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据组织机构的串值来显示学生
        /// </summary>
        /// <param name="organList"></param>
        private void showUserList(string organList)
        {
            try
            {
                if (organList.Length > 0)
                {
                    string sqlin = commons.makeSqlIn(organList, ',');
                    DataTable dt = new DataTable();
                    dt = userBll.GetList(" USERTYPE=1 AND ORGAN IN "+sqlin+" order by organ").Tables[0];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 全选列表中的用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkAll_CheckedChanged1(object sender, EventArgs e)
        {
            try
            {
                
                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    ((CheckBox)GridView1.Rows[i].FindControl("CheckBox_check")).Checked = chkAll.Checked;
                }
              
            }
            catch
            {
            }
        }
        /// <summary>
        /// 将被选中的用户作为公文的发放对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_do_Click(object sender, EventArgs e)
        {
            try
            {
                string userlist = "";
                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    CheckBox ckb = (CheckBox)GridView1.Rows[i].FindControl("CheckBox_check");
                    string userName = GridView1.Rows[i].Cells[1].Text.ToString();
                    if (ckb.Checked)
                    {
                        userlist = userlist + userName + ",";
                    }
                }

                //把获取到得用户列表做到SESSION中去
                Session["userList_temps_chooseUser"] = "";
                Session["userList_temps_chooseUser"] = userlist;
                string coutws = "<script language=\"javascript\" type=\"text/javascript\">window.parent.parent.GB_hide();</script>";
                Response.Write(coutws);
            }
            catch
            {
                string coutws2 = "<script language=\"javascript\" type=\"text/javascript\">alert('操作失败，请重新操作！');window.parent.parent.GB_hide();</script>";
                Response.Write(coutws2);
            }
        }
    }
}
