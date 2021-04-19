using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class Cash_SpecialFunds_add : System.Web.UI.Page
    {
        BLL.Cash_SpecialFunds bllCF = new Dianda.BLL.Cash_SpecialFunds();
        Model.Cash_SpecialFunds modelCF = new Dianda.Model.Cash_SpecialFunds();

     
        BllExt.StaticFactory_CASH bllextSF = new Dianda.BllExt.StaticFactory_CASH();//静态数据的控制器
        COMMON.common commons = new Dianda.COMMON.common();
        COMMON.pageControl pcs = new Dianda.COMMON.pageControl();

        const string _pageCash_SpecialFunds = "Cash_SpecialFunds.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showAccount(DropDownList_Account);//加载账户信息
                showYear(DropDownList_year);//加载年份数据
                DropDownList_year.SelectedValue = DateTime.Now.Year.ToString();

                string pagenames = "新建专项资金";
                string modifyid = "";
                modifyid = Request["id"];
                if (!String.IsNullOrEmpty(modifyid))
                {
                    showinfo(modifyid);//加载要修改的数据
                    pagenames = "编辑专项资金";
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
                    pagenames = "注销专项资金";
                    pagenameshows.InnerText = pagenames;
                    delInfos(modifyid);

                }

                /*设置模板页中的管理值*/
                (Master.FindControl("Label_navigation") as Label).Text = "管理 > 专项资金管理 > " + pagenames;
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
            string sql = "update Cash_SpecialFunds set delflag=1 where id in " + sqlin;
            // Response.Write(sql);

            pcs.doSql(sql);
            string dotypes = "注销专项资金";
            writeLog(dotypes, dotypes + sqlin + "成功");
            bllextSF.resetCash_SpecialFunds();//重置账户信息
            tag.Text = "操作成功！";
            this.Button_sumbit.Visible = false;
            MessageBox.ShowAndRedirect(this.Page, tag.Text.ToString(), "Cash_SpecialFunds.aspx?pageindex=" + Request["pageindex"] + "&" + getKeys());
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
                    modelCF = bllCF.GetModel(int.Parse(objectID));
                    if (modelCF != null)
                    {
                        DropDownList_Account.SelectedValue = modelCF.AccountID.ToString();
                        DropDownList_year.SelectedValue = modelCF.YEARS.ToString();
                        TextBox_TotalNum.Text = modelCF.TotalNum.ToString();
                        RadioButtonList_IsListApply.SelectedValue = modelCF.IsListApply.ToString();
                        txtCardName.Text = modelCF.NAMES;
                        RadioButtonList_status.SelectedValue = modelCF.STATUS.ToString();
                        txtLimitNums.Text = modelCF.Balance.ToString();

                        ViewState["_theModifyCF"] = modelCF;//将要处理的数据集保存一下
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
            if (DropDownList_Account.Items.Count > 0)
            {
                try
                {

                    string dotypes = "新建专项资金";
                    string modifyid = "";
                    modifyid = Request["id"];
                    bool ismodify = false;
                    if (!String.IsNullOrEmpty(modifyid))
                    {
                        modelCF = (Model.Cash_SpecialFunds)ViewState["_theModifyCF"];
                        ismodify = true;
                        dotypes = "编辑专项资金";
                    }

                    bool isdo = true;//是否进行操作的标记\
                    modelCF.AccountID = int.Parse(DropDownList_Account.SelectedValue.ToString());
                    modelCF.ADDTIME = DateTime.Now;
                    modelCF.Adduser = ((Model.USER_Users)Session["USER_Users"]).USERNAME;
                    modelCF.Balance = decimal.Parse(txtLimitNums.Text.ToString());
                    modelCF.Delflag = 0;
                    modelCF.IsListApply = int.Parse(RadioButtonList_IsListApply.SelectedValue.ToString());
           
                    modelCF.NAMES = txtCardName.Text.ToString();
       
                    modelCF.STATUS = int.Parse(RadioButtonList_status.SelectedValue.ToString());
                    modelCF.TotalNum = decimal.Parse(TextBox_TotalNum.Text.ToString());
                    modelCF.YEARS =int.Parse(DropDownList_year.SelectedValue.ToString());
                     
                    if (isdo)
                    {
                        if (!ismodify)
                        {
                            modelCF.Note = modelCF.Adduser + "于" + modelCF.ADDTIME.ToString() + dotypes + modelCF.NAMES;
                            bllCF.Add(modelCF);
                        }
                        else
                        {
                            modelCF.Note = modelCF.Adduser + "于" + modelCF.ADDTIME.ToString() + dotypes + modelCF.NAMES + "<br/>" + modelCF.Note;
                            bllCF.Update(modelCF);
                        }
                        tag.Text = "操作成功！";
                        this.Button_sumbit.Visible = false;

                        //添加操作日志
                        writeLog(dotypes, dotypes + modelCF.NAMES + "成功");
                        //添加操作日志

                        bllextSF.resetCash_SpecialFunds();//重置信息

                        //付全文    2013-4-15   修改新增时跳转逻辑
                        string href = null;
                        if (!ismodify)
                        {
                            //add
                            href = "pageindex=1&account=" + modelCF.AccountID + "&years=" + modelCF.YEARS;
                        }
                        else
                        {
                            //update
                            href = "pageindex=" + Request["pageindex"] + "&" + getKeys();
                        }
                        string coutws = "<script language=\"javascript\" type=\"text/javascript\">alert(\"操作成功！现在进入列表页面\");location.href = \"" + _pageCash_SpecialFunds + "?" + href + "\";</script>";
                        Response.Write(coutws);
                    }
                }
                catch
                {
                }
            }
            else
            {
                tag.Text = "账户为空！不能添加专项资金！";
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="dotype"></param>
        /// <param name="results"></param>
        private void writeLog(string dotype, string results)
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
            Response.Redirect(_pageCash_SpecialFunds + "?pageindex=" + Request["pageindex"] + "&" + getKeys());
        }
        /// <summary>
        /// 显示账户的信息
        /// </summary>
        /// <param name="ddl"></param>
        private void showAccount(DropDownList ddl)
        {
            DataRow[] dr=bllextSF.getCash_Account().Select("STATUS=1");
            if (dr.Length > 0)
            {
                ddl.Items.Clear();
                for (int i = 0; i < dr.Length; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = dr[i]["NAMES"].ToString();
                    li.Value = dr[i]["ID"].ToString();
                    ddl.Items.Add(li);
                }
                
            }
            else
            {
                ddl.Items.Clear();
            }
        }
        /// <summary>
        /// 显示年份的数据
        /// </summary>
        /// <param name="ddl"></param>
        private void showYear(DropDownList ddl)
        {
            ddl.Items.Clear();
            DateTime dt=DateTime.Now;
            int years=dt.Year;
            for (int i = years - 20; i < years + 20; i++)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString() + "年";
                li.Value = i.ToString();
                ddl.Items.Add(li);
            }
        }
        /// <summary>
        /// 获取到筛选的值
        /// </summary>
        /// <returns></returns>
        private string getKeys()
        {
            return "account=" + Request["account"] + "&years=" + Request["years"];
        }
    }
}
