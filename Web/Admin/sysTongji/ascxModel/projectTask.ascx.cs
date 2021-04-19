using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.sysTongji.ascxModel
{
    public partial class projectTask : System.Web.UI.UserControl
    {
        Dianda.COMMON.common commons = new Dianda.COMMON.common();
        Dianda.Model.Project_Task task_model = new Dianda.Model.Project_Task();
        Dianda.BLL.Project_Task task_bll = new Dianda.BLL.Project_Task();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label_tongji.Text = "暂无统计信息！";
            }
        }
        /// <summary>
        /// 显示项目下的任务
        /// </summary>
        public void ShowTaskList(string projectid)
        {
            try
            {
                DataTable DT = new DataTable();
                DT = task_bll.GetList(" ProjectID='" + projectid + "' and delflag=0 order by StartTime desc").Tables[0];
                if (DT.Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = DT;//指定GridView1的数据是DT
                    GridView1.DataBind();//将上面指定的信息绑定到GridView1上
                    notice.Text = "";
                }
                else
                {
                    GridView1.Visible = false;
                    notice.Text = "*没有符合条件的结果！";
                }
                tongji(DT);
            }
            catch
            {
                GridView1.Visible = false;
                notice.Text = "*进入任务列表时发生错误！";
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

                    //任务状态
                    string Status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                    switch (Status)
                    {
                        case "0":
                            e.Row.Cells[4].Text = "待办";
                            break;
                        case "1":
                            e.Row.Cells[4].Text = "进行中";
                            break;
                        case "2":
                            e.Row.Cells[4].Text = "完成";
                            break;
                        case "3":
                            e.Row.Cells[4].Text = "<font color='red'>暂停</font>";
                            break;
                    }

                }
            }
            catch
            { }
        }
   
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string substing(object e)
        {
            string str = "";
            string str1 = e.ToString();
            if (str1.Contains(";"))
            {
                str = str1.Remove(str1.IndexOf(";")) + "...";

            }
            else if (str1.Contains(","))
            {
                str = str1.Remove(str1.IndexOf(",")) + "...";
            }
            else
            {
                str = str1;
            }
            return str;
        }

        /// <summary>
        /// 根据提供的数据进行统计
        /// </summary>
        /// <param name="dt"></param>
        private void tongji(DataTable dt)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    string alls = dt.Rows.Count.ToString();
                    string couw = "此项目中共有&nbsp;" + alls + "&nbsp;个项目任务！<br/>";
                    //0表示未开始；1表示进行中；2表示完成；3表示延期
                    int[] taskCount1 = taskCount(dt);
                    couw = couw + "其中未开始的任务&nbsp;" + taskCount1[0].ToString() + "&nbsp;个<br/>";
                    couw = couw + "其中进行中的任务&nbsp;" + taskCount1[1].ToString() + "&nbsp;个<br/>";
                    couw = couw + "其中完成的任务&nbsp;" + taskCount1[2].ToString() + "&nbsp;个<br/>";
                    couw = couw + "其中延期的任务&nbsp;" + taskCount1[3].ToString() + "&nbsp;个";
                    Label_tongji.Text = couw;
                }
                else
                {
                    Label_tongji.Text = "暂无统计信息！";
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 统计任务中，不同状态的任务的个数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        private int[] taskCount(DataTable dt)
        {
            int[] coutw = {0,0,0,0};
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Status"].ToString() == "0")
                        {
                            coutw[0] = coutw[0] + 1;
                        }
                        if (dt.Rows[i]["Status"].ToString() == "1")
                        {
                            coutw[1] = coutw[1] + 1;
                        }
                        if (dt.Rows[i]["Status"].ToString() == "2")
                        {
                            coutw[2] = coutw[2] + 1;
                        }
                        if (dt.Rows[i]["Status"].ToString() == "3")
                        {
                            coutw[3] = coutw[3] + 1;
                        }
                    }
                }
            }
            catch
            {
            }
             return  coutw;
        }
    }
}
