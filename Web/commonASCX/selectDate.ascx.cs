using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.commonASCX
{
    public partial class selectDate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    makeYear(DropDownList_Y);/// 构造年份
                    makeMouth(DropDownList_M);//构造月份            
                    makeDay(DropDownList_D, 31);//构造天
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 构造年份
        /// </summary>
        /// <param name="dl"></param>
        private void makeYear(DropDownList dl)
        {
            try
            {
                DateTime dt = DateTime.Now;
                dl.Items.Clear();
                for (int i = dt.Year; i>dt.Year-100; i--)
                {
                    ListItem li = new ListItem();
                    li.Text = i.ToString();
                    li.Value = i.ToString();
                    dl.Items.Add(li);
                }
                ListItem li2 = new ListItem();
                //li2.Text = " ";
                //li2.Value = "";
                //dl.Items.Insert(0, li2);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 构造月份
        /// </summary>
        /// <param name="dl"></param>
        private void makeMouth(DropDownList dl)
        {
            try
            {
                dl.Items.Clear();
                for (int i =1; i<13; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = i.ToString();
                    li.Value = i.ToString();
                    dl.Items.Add(li);
                }
                ListItem li2 = new ListItem();
                //li2.Text = " ";
                //li2.Value = "";
                //dl.Items.Insert(0, li2);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 构造天
        /// </summary>
        /// <param name="dl"></param>
        private void makeDay(DropDownList dl,int days)
        {
            try
            {
                dl.Items.Clear();
                for (int i = 1; i <= days; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = i.ToString();
                    li.Value = i.ToString();
                    dl.Items.Add(li);
                }
                ListItem li2 = new ListItem();
                //li2.Text = " ";
                //li2.Value = "";
                //dl.Items.Insert(0, li2);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 月份进行筛选的时候，判断闰年的事情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_M_SelectedIndexChanged(object sender, EventArgs e)
        {
            doChanged();
        }
        /// <summary>
        /// 年份变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_Y_SelectedIndexChanged(object sender, EventArgs e)
        {
            doChanged();
        }
        /// <summary>
        /// 触发
        /// </summary>
        private void doChanged()
        {
            try
            {
                int years = int.Parse(DropDownList_Y.SelectedValue.ToString());
                int mouths = int.Parse(DropDownList_M.SelectedValue.ToString());
                //计算当前年份的这个月，有多少天
                int day = 0;
                switch (mouths)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        day = 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        day = 30;
                        break;
                    case 2:
                        if (years % 4 == 0)
                        {
                            day = 29;
                            if (years % 100 == 0)
                            {
                                day = 28;
                                if (years % 400 == 0)
                                    day = 29;
                            }
                        }
                        else
                            day = 28;
                        break;
                }
                makeDay(DropDownList_D, day);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 获取选择的年月日
        /// </summary>
        /// <returns></returns>
        public string getSelectDays()
        {
            string coutw = "";
            try
            {
                if (DropDownList_Y.SelectedValue.ToString() != "" && DropDownList_M.SelectedValue.ToString() != "" && DropDownList_D.SelectedValue.ToString() != "")
                {
                    coutw = DropDownList_Y.SelectedValue.ToString() + "-" + DropDownList_M.SelectedValue.ToString() + "-" + DropDownList_D.SelectedValue.ToString();
                }
                else
                {
                    coutw = "";
                }
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="dt"></param>
        public void setSelectDays(DateTime dt)
        {
            try
            {
                DropDownList_Y.SelectedValue = dt.Year.ToString();
                DropDownList_M.SelectedValue = dt.Month.ToString();
                DropDownList_D.SelectedValue = dt.Day.ToString();
            }
            catch
            {
            }
        }

    }
}
