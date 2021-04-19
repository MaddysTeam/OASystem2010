using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace Dianda.Web.Admin.personalProjectManage.OAapply
{
    public partial class orderFood : System.Web.UI.UserControl
    {
        Dianda.COMMON.pageControl pageControl = new Dianda.COMMON.pageControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //预订份额
                TB_nums.Enabled = false;
                LB_notice.Text = "请先检测所选时间是否可预订！";

                Button_Check.Attributes.Add("onclick", "return check()");
            }
        }


        /// <summary>
        /// 点击检查是否可预订触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Check_Click(object sender, EventArgs e)
        {
            try
            {
                //日期
                string ordertime = TB_ordertime.Value.ToString();
                //父页面上的提示信息控件
                Label lb_tag = (Label)this.Parent.FindControl("tag");

                if (Convert.ToDateTime(Convert.ToDateTime(ordertime).ToString("yyyy-MM-dd")) < Convert.ToDateTime(DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")))
                {
                    lb_tag.Text = "午餐必须提前二天预订，请电话联系相关人员！";
                    return;
                }

                //定饭总量
                int orderFoodNums = int.Parse(ConfigurationSettings.AppSettings["orderFoodNums"]);

                DataTable dt = new DataTable();
                string sql = " SELECT SUM(Project_Apply_orderFood.OrderNum) AS OrderNum FROM Project_Apply " +
                             " RIGHT OUTER JOIN Project_Apply_orderFood " +
                             " ON Project_Apply.ID = Project_Apply_orderFood.ApplyID " +
                             " WHERE (Project_Apply.Status in('0','1')) and (Project_Apply.AppType='orderFood') ";

                sql = sql + "  AND (Project_Apply_orderFood.UserDatetime = '" + ordertime + "')";

                dt = pageControl.doSql(sql).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lb_tag.Text = "";

                    if (null != dt.Rows[0]["OrderNum"] && !dt.Rows[0]["OrderNum"].ToString().Equals(""))
                    {
                        int OrderNum = int.Parse(dt.Rows[0]["OrderNum"].ToString());
                        //剩余可预订的数量
                        int LimitNum = orderFoodNums - OrderNum;
                        HF_ordernums.Value = LimitNum.ToString();
                        if (LimitNum > 0)
                        {
                            LB_notice.Text = "您设定的用饭日期，还剩" + LimitNum + "份可接受预订！";
                            TB_nums.Enabled = true;
                            TB_nums.Focus();
                        }
                        else
                        {
                            LB_notice.Text = "您设定的用饭日期，已经全部预订完！";
                            TB_nums.Enabled = false;
                        }
                    }
                    else
                    {
                        LB_notice.Text = "您设定的用饭日期，还剩" + orderFoodNums + "份可接受预订！";
                        HF_ordernums.Value = orderFoodNums.ToString();
                        TB_nums.Enabled = true;
                        TB_nums.Focus();
                    }
                }
                else
                {
                    LB_notice.Text = "您设定的用饭日期，还剩" + orderFoodNums + "份可接受预订！";
                    HF_ordernums.Value = orderFoodNums.ToString();
                    TB_nums.Enabled = true;
                    TB_nums.Focus();
                }
            }
            catch
            {
                LB_notice.Text = "对不起，在获取可预订数量时发生错误！";
                TB_nums.Enabled = false;
            }
           
        }

        /// <summary>
        /// 返回订饭时间
        /// </summary>
        public string orderfoodtime   
          {
              get
              {
                  return TB_ordertime.Value.ToString();
              }
              set
              {
                  TB_ordertime.Value = value;
              } 
          }
        /// <summary>
        /// 返回订饭数量
        /// </summary>
        public string orderfoodnum
        {
            get
            {
                return TB_nums.Text.ToString();
            }
            set
            {
                TB_nums.Text = value;
            } 

        }

        /// <summary>
        /// 返回剩余饭的数量
        /// </summary>
        public string LimitNum
        {
            get
            {
                return HF_ordernums.Value.ToString();
            }
            set
            {
                HF_ordernums.Value = value;
            }

        } 

    }
}