using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.Cash_SF_Order
{
    public partial class SpecialFundsOrder : System.Web.UI.UserControl
    {
        COMMON.pageControl compage = new Dianda.COMMON.pageControl();
        COMMON.common commons = new Dianda.COMMON.common();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    string sid = "";
            //    sid = Request["SpecialFundsID"];
            //    if (!String.IsNullOrEmpty(sid))
            //    {
            //        list(sid);
            //    }
            //    else
            //    {
            //        notice.Text = "没有符合条件的数据！";
            //    }

            //}
        }
        /// <summary>
        /// 直接显示数据
        /// </summary>
        /// <param name="spacialFundsid"></param>
        public void ShowList(string spacialFundsid)
        {
            list(spacialFundsid);
        }
        /// <summary>
        /// 查看专项资金下面的预算报告列表
        /// </summary>
        /// <param name="spacialFundsid"></param>
        private void list(string spacialFundsid)
        {
            spacialFundsid = commons.RequestSafeString(spacialFundsid, 50);
            string sql = "select * from vCash_SF_Order where SpecialFundsID=" + spacialFundsid + " order by ADDTIME desc";
            DataTable dt = new DataTable();
            dt = compage.doSql(sql).Tables[0];

            //=======添加汇总信息 by guanzhq on 2012年3月20日 begin=======
            if (dt != null)
            {
                //重新绑定数据
                GridView1.DataSource = dt;
                GridView1.DataBind();

                if (dt.Rows.Count > 0)
                {
                    string TotalNum = dt.Rows[0]["SFTotalNum"].ToString();//预算金额
                    string Balance = dt.Rows[0]["SFBalance"].ToString();//可用金额

                    //获取项目总金额
                    double rel = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["BAUNIT"].ToString().Trim() == "万元")
                        {
                            int temp = 0;
                            int.TryParse(dr["ActualAmount"].ToString(), out temp);
                            temp = temp * 10000;
                            rel += temp;
                        }
                        else
                        {
                            int temp = 0;
                            int.TryParse(dr["ActualAmount"].ToString(), out temp);
                            rel += temp;
                        }
                    }
                    //添加汇总信息
                    //lblhuizong.Text = "<table class='GridView1'><tr><td>专项资金预算金额：</td><td>" + string.Format("{0:n}", TotalNum) + "元</td><td>项目总金额：</td><td>" + string.Format("{0:n}", rel) + "元</td><td>可用金额：</td><td>" + string.Format("{0:n}", Balance) + "元</td></tr></table> ";
                    lblhuizong.Text = "<table width='100%' height='50px' style='border: solid 1px #99cccd; text-align: center' cellpadding='0' cellspacing='0'><tr style='background-color: #99cccd;'><td>可用金额</td><td>项目总金额</td><td>预算金额</td></tr><tr><td style='border-right: solid 1px #99cccd; width: 120px'>" + string.Format("{0:n}", double.Parse(Balance)) + "元</td><td style='border-right: solid 1px #99cccd'>" + string.Format("{0:n}", rel) + "元</td><td style='border-right: solid 1px #99cccd'>" + string.Format("{0:n}", double.Parse(TotalNum)) + "元</td></tr></table>";
                    notice.Text = "";
                }
                else
                {
                    notice.Text = "该专项资金暂无预算！";
                    lblhuizong.Text = "";
                }
            }
            else
            {
                notice.Text = "该专项资金暂无预算！";
                lblhuizong.Text = "";
            }

            //=======添加汇总信息 by guanzhq on 2012年3月20日 end=======

            //if (dt != null)
            //{
            //    GridView1.DataSource = dt;
            //    GridView1.DataBind();
            //    notice.Text = " ";
            //}
            //if (GridView1.Rows.Count == 0)
            //{
            //    notice.Text = "该专项资金暂无预算！";
            //}
        }

    }
}