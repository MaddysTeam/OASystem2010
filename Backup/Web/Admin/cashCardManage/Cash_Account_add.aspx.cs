using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class Cash_Account_add : System.Web.UI.Page
    {
        BLL.Cash_Account bllCA = new Dianda.BLL.Cash_Account();
        Model.Cash_Account modeCA = new Dianda.Model.Cash_Account();
        BllExt.StaticFactory_CASH bllextSF = new Dianda.BllExt.StaticFactory_CASH();//静态数据的控制器
        COMMON.common commons = new Dianda.COMMON.common();
        COMMON.pageControl pcs = new Dianda.COMMON.pageControl();

        const string _pageCash_Account = "Cash_Account.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pagenames = "新建账户";
                string modifyid = "";
                modifyid = Request["id"];
                if (!String.IsNullOrEmpty(modifyid))
                {
                    showinfo(modifyid);//加载要修改的数据
                    pagenames = "编辑账户";
                    pagenameshows.InnerText = pagenames;
                    div2.Visible = true;
                }

                string dotype = "";
                dotype = Request["dotype"];
                if (!String.IsNullOrEmpty(dotype))
                {
                    div2.Visible = false;
                    //做删除操作
                  //  Response.Write(modifyid);
                    pagenames = "注销账户";
                    pagenameshows.InnerText = pagenames;
                    delInfos(modifyid);
                   
                }

                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 账户管理 > " + pagenames;
                /*设置模板页中的管理值*/
            }
        }
        /// <summary>
        /// 删除要处理的数据
        /// </summary>
        /// <param name="ids"></param>
        private void delInfos(string ids)
        {
            string sqlin = commons.makeSqlIn(ids, ',');
            string sql = "update Cash_Account set delflag=1 where id in " + sqlin;
           // Response.Write(sql);

            pcs.doSql(sql);
            string dotypes = "注销账户";
            writeLog(dotypes, dotypes + sqlin + "成功");
            bllextSF.resetCash_Account();//重置账户信息
            tag.Text = "操作成功！";
            this.Button_sumbit.Visible = false;
            MessageBox.ShowAndRedirect(this.Page, tag.Text.ToString(), "Cash_Account.aspx");
        }
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="objectID"></param>
        private void showinfo(string objectID)
        {
            try
            {
                objectID = commons.RequestSafeString(objectID, 50);
                if (!String.IsNullOrEmpty(objectID))
                {
                    modeCA = bllCA.GetModel(int.Parse(objectID));
                    if (modeCA != null)
                    {
                        txtCardName.Text = modeCA.NAMES;
                        RadioButtonList_status.SelectedValue = modeCA.STATUS.ToString();
                        txtLimitNums.Text = modeCA.Balance.ToString();
                        string FreezeTime = modeCA.FreezeTime.ToString();
                        if (!string.IsNullOrEmpty(FreezeTime))
                        {
                            TB_DateTime.Value = DateTime.Parse(FreezeTime).ToString("yyyy-MM-dd");
                        }
                        txtEveryDayNum.Text = modeCA.EveryDayNum.ToString();
                        ViewState["_theModifyCA"] = modeCA;//将要处理的数据集保存一下
                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string dotypes = "新建账户";
                string modifyid = "";
                modifyid = Request["id"];
                bool ismodify = false;
                if (!String.IsNullOrEmpty(modifyid))
                {
                    modeCA = (Model.Cash_Account)ViewState["_theModifyCA"];
                    ismodify = true;
                    dotypes = "编辑账户";
                }

                decimal LimitNums = decimal.Parse(txtLimitNums.Text);
                decimal EveryDayNum = decimal.Parse(txtEveryDayNum.Text);

                if (EveryDayNum > LimitNums)
                {
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "TS", "alert('每日限额不能大于账户余额！')", true);
                    return;
                }
                
                bool isdo = true;//是否进行操作的标记
                modeCA.ADDTIME = DateTime.Now;
                modeCA.Adduser =((Model.USER_Users)Session["USER_Users"]).USERNAME;
                modeCA.Balance = LimitNums;
                modeCA.EveryDayNum = EveryDayNum;
                modeCA.Delflag = 0;
                if (TB_DateTime.Value.ToString() != "")
                {
                    modeCA.FreezeTime = DateTime.Parse(TB_DateTime.Value.ToString());
                }
                modeCA.NAMES = txtCardName.Text.ToString();
                modeCA.STATUS = int.Parse(RadioButtonList_status.SelectedValue.ToString());
                if (modeCA.STATUS == 0)
                {
                    if (modeCA.FreezeTime.ToString().Length == 0)
                    {
                        //提示
                        tag.Text = "操作失败！账户冻结，请选择冻结时间！";
                        isdo = false;
                    }
                    else
                    {
                        isdo = true;
                    }
                }
                if (isdo)
                {
                    if (!ismodify)
                    {
                        modeCA.Note = modeCA.Adduser + "于" + modeCA.ADDTIME.ToString() + dotypes + modeCA.NAMES;
                        bllCA.Add(modeCA);
                    }
                    else
                    {
                        modeCA.Note = modeCA.Adduser + "于" + modeCA.ADDTIME.ToString() + dotypes + modeCA.NAMES + "<br/>" + modeCA.Note;
                        bllCA.Update(modeCA);
                    }
                    tag.Text = "操作成功！";
                    this.Button_sumbit.Visible = false;

                    //添加操作日志
                    //Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
                    //Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
                    //bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", dotypes, dotypes + modeCA.NAMES + "成功");
                    writeLog(dotypes, dotypes + modeCA.NAMES + "成功");
                    //添加操作日志

                    bllextSF.resetCash_Account();//重置账户信息

                    string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\");location.href = \"" + _pageCash_Account + "\";</script>";
                    Response.Write(coutws);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="dotype"></param>
        /// <param name="results"></param>
        private void writeLog(string dotype,string results)
        {
            //添加操作日志
            Dianda.BLL.SYS_LogsExt bsyslog = new Dianda.BLL.SYS_LogsExt();
            Model.USER_Users user_model = (Model.USER_Users)Session["USER_Users"];
            bsyslog.addlogs(((Model.USER_Users)Session["USER_Users"]).REALNAME + "(" + ((Model.USER_Users)Session["USER_Users"]).USERNAME + ")", dotype, results);
            //添加操作日志
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_pageCash_Account);
        }
    }
}
