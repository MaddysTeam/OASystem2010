using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dianda.Web.Admin.cashCardManage
{
    public partial class Cash_CarDetailList : System.Web.UI.UserControl
    {
        Model.Cash_CardsDetail modelCDa = new Dianda.Model.Cash_CardsDetail();
        BLL.Cash_CardsDetail bllCardDetail = new Dianda.BLL.Cash_CardsDetail();//加载资金卡的明细列表
        BllExt.StaticFactory_CASH bllextSF = new Dianda.BllExt.StaticFactory_CASH();//加载静态数据
        COMMON.pageControl dosqls = new Dianda.COMMON.pageControl();
        Model.Cash_Cards Cards_model = new Dianda.Model.Cash_Cards();
        BLL.Cash_Cards Cards_bll = new Dianda.BLL.Cash_Cards();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 模块主函数(1)
        /// </summary>
        /// <param name="CardID"></param>
        public void main(string CardID)
        {
            if (!IsPostBack)
            {
                if (CardID.Equals(""))
                {
                    td_LimitNums.Visible = false;
                }
                showList(CardID);
            }
        }
        /// <summary>
        /// 模块主函数-当总数发生调整时调用（2）
        /// </summary>
        /// <param name="newtotal"></param>
        public void chanageTotal(string newtotal)
        {
            EventArgs e=new EventArgs();
            TextBox_totalnew.Text = newtotal;
            TextBox_totalnew_TextChanged(TextBox_totalnew, e);
        }
        /// <summary>
        /// 模块主函数-当保存数据时调用(3)
        /// </summary>
        public void saveValue()
        {
            EventArgs e=new EventArgs();
            Button_save_Click(Button_save, e);
        }
        /// <summary>
        /// 根据资金卡的ID，获取到资金卡明细的列表
        /// </summary>
        /// <param name="CardID"></param>
        private void showList(string CardID)
        {
            try
            {
                Label_TOTAL.Text = "0";
                bool isnew = true;//是否是新的
                if (String.IsNullOrEmpty(CardID))
                {
                   
                }
                else
                {
                    ViewState["_cardID_tcl_control"] = CardID;//要处理的资金卡的ID
                 
                    DataSet ds = bllCardDetail.GetList("CardID='" + CardID + "' order by ID ASC");
                    if (ds != null)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ViewState["_isModifyControl_tcl"] = "1";//1表示是修改明细列表
                                //已经保存过数据了。直接赋值
                                GridView1.DataSource = ds.Tables[0];
                                GridView1.DataBind();
                                isnew = false;
                                Cards_model = Cards_bll.GetModel(int.Parse(CardID));
                                TB_Balance.Text = Cards_model.Balance.ToString();
                                TB_LimitNums.Text = Cards_model.LimitNums.ToString();
                                getBili();//获取比例值
                            }

                        }
                    }
                }
                if (isnew)
                {
                    showDetailList();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 直接获取到资金卡的明细列表
        /// </summary>
        private void showDetailList()
        {
            try
            {
                ViewState["_isModifyControl_tcl"] = "0";//0表示是新增加明细列表
                DataTable dt = bllextSF.getCash_DetailNameList();
                GridView1.DataSource = dt;
                GridView1.DataBind();
              
            }
            catch
            {
            }
        }
        /// <summary>
        /// 数据进行加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) //判断是否是DataRow，以防止鼠标经过Header也有效果
                {
                    
                    string _isModifyControl_tcl = ViewState["_isModifyControl_tcl"].ToString();//1表示是修改明细列表,0表示是新增加明细列表
                    HiddenField HiddenField_deid = (HiddenField)e.Row.Cells[1].FindControl("HiddenField_deid");
                    HiddenField HiddenField_ID = (HiddenField)e.Row.Cells[1].FindControl("HiddenField_ID");
                    HiddenField HiddenField_balance = (HiddenField)e.Row.Cells[1].FindControl("HiddenField_balance");
                    HiddenField HiddenField_KYbalance = (HiddenField)e.Row.Cells[1].FindControl("HiddenField_KYbalance");
                    
                    if (null != Request["action"] && Request["action"].ToString().Equals("modify"))
                    {
                        Label lb_bili = (Label)e.Row.Cells[3].FindControl("lb_bili");
                        lb_bili.Visible = true;
                    }
                    
                    if (_isModifyControl_tcl == "0")
                    {
                         e.Row.Cells[0].Text = DataBinder.Eval(e.Row.DataItem, "INFORS").ToString();
                         HiddenField_deid.Value = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
                    }
                    else if (_isModifyControl_tcl == "1")
                    {
                        string ID = DataBinder.Eval(e.Row.DataItem, "ID").ToString();

                        string detailID = DataBinder.Eval(e.Row.DataItem, "DetailID").ToString();
                        
                        string Unit = DataBinder.Eval(e.Row.DataItem, "Unit").ToString();
                        string TypesName = DataBinder.Eval(e.Row.DataItem, "TypesName").ToString();
                        
                        //最原始的可用金额值　
                        string oldBalance = DataBinder.Eval(e.Row.DataItem, "Oldbalance").ToString();
                        HiddenField_balance.Value = oldBalance;

                        //可用金额
                        string KYbalance = DataBinder.Eval(e.Row.DataItem, "KYbalance").ToString();

                        TextBox TextBox_balance = (TextBox)e.Row.Cells[1].FindControl("TextBox_balance");
                        DropDownList DropDownList_Unit = (DropDownList)e.Row.Cells[1].FindControl("DropDownList_Unit");
                        RadioButtonList RadioButtonList_typename = (RadioButtonList)e.Row.Cells[2].FindControl("RadioButtonList_typename");
                        e.Row.Cells[0].Text = getDetailNames(detailID);
                        TextBox_balance.Text = (decimal.Parse(KYbalance) / int.Parse(Unit)).ToString();
                        HiddenField_KYbalance.Value = TextBox_balance.Text;
                        DropDownList_Unit.SelectedValue = Unit;
                        RadioButtonList_typename.SelectedValue = TypesName;
                        HiddenField_deid.Value = detailID;
                        HiddenField_ID.Value = ID;

                        //一旦细目在有数据记录的时候，就无法修改类型，否则就需要删除后重新记录
                        if (!TextBox_balance.Text.Equals("") && !TextBox_balance.Text.Equals("0"))
                        {
                            RadioButtonList_typename.Enabled = false;
                        }

                      //汇总数据
                        //totalNums(Balance, Unit);
                    }

                    TextBox TB = (TextBox)e.Row.FindControl("TextBox_balance");
                    DropDownList DDL = (DropDownList)e.Row.FindControl("DropDownList_Unit");

                    TB.Attributes.Add("onblur", "javascript:ChangeTotalText('" + _isModifyControl_tcl + "','" + Request["action"] + "');");
                    DDL.Attributes.Add("onblur", "javascript:ChangeTotalText('" + _isModifyControl_tcl + "','" + Request["action"] + "');");
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 根据明细的ID获取到明细的数据
        /// </summary>
        /// <param name="DetailID"></param>
        /// <returns></returns>
        private string getDetailNames(string DetailID)
        {
            string coutw = "";
            try
            {
                DataTable dt = bllextSF.getCash_DetailNameList();
                DataRow[] dr = dt.Select("ID='" + DetailID + "'");
                if (dr.Length > 0)
                {
                    coutw = dr[0]["INFORS"].ToString();
                }
            }
            catch
            {
            }
            return coutw;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["_cardID_tcl_control"].ToString() != null)
                {
                    //先删除这张资金卡中的数据
                    string sqldel = "delete from Cash_CardsDetail where cardid='" + ViewState["_cardID_tcl_control"].ToString() + "'";
                    dosqls.doSql(sqldel);

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        HiddenField HiddenField_deid = (HiddenField)GridView1.Rows[i].Cells[1].FindControl("HiddenField_deid");
                        TextBox TextBox_balance = (TextBox)GridView1.Rows[i].Cells[1].FindControl("TextBox_balance");
                        DropDownList DropDownList_Unit = (DropDownList)GridView1.Rows[i].Cells[1].FindControl("DropDownList_Unit");
                        RadioButtonList RadioButtonList_typename = (RadioButtonList)GridView1.Rows[i].Cells[2].FindControl("RadioButtonList_typename");
                        modelCDa.Balance = DecimalParse(TextBox_balance.Text.ToString());// decimal.Parse(TextBox_balance.Text.ToString());
                        modelCDa.CardID = int.Parse(ViewState["_cardID_tcl_control"].ToString());
                        modelCDa.DetailID = int.Parse(HiddenField_deid.Value.ToString());
                        modelCDa.TypesName = RadioButtonList_typename.SelectedValue.ToString();
                        modelCDa.Unit = int.Parse(DropDownList_Unit.SelectedValue.ToString());
                        bllCardDetail.Add(modelCDa); 
                    }
                    showList(ViewState["_cardID_tcl_control"].ToString());
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 将字符串转成decimal
        /// </summary>
        /// <param name="instring"></param>
        /// <returns></returns>
        private decimal DecimalParse(string instring)
        {
            try
            {
                return decimal.Parse(instring);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 将字符串转成double
        /// </summary>
        /// <param name="instring"></param>
        /// <returns></returns>
        private double doubleParse(string instring)
        {
            try
            {
                return Math.Round(double.Parse(instring),2);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 将列表中的数据汇总
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="units"></param>
        private void totalNums(string balance,string units)
        {
            try
            {
                string olds = Label_TOTAL.Text.ToString();
               Label_TOTAL.Text=(doubleParse(balance) * doubleParse(units) + doubleParse(olds)).ToString();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 当设定新的数据时，要重新做每天数据的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TextBox_totalnew_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //可用金额
                string totalvalues = TB_LimitNums.Text.ToString();
                //如果可用金额和预算金额不等，说明调整了
                if (totalvalues != TB_Balance.Text.ToString())
                {
                    //可用金额
                    decimal newtotal = decimal.Parse(totalvalues); 
                    //预算金额
                    decimal oldtotal = decimal.Parse(TB_Balance.Text.ToString());
                    if (newtotal > 0)
                    {
                        
                        for (int i = 0; i < GridView1.Rows.Count; i++)
                        {
                             //每一明细的可用金额输入框
                             TextBox TextBox_balance = (TextBox)GridView1.Rows[i].Cells[1].FindControl("TextBox_balance");
                             //明细的单位　
                             DropDownList ddl_unit = (DropDownList)GridView1.Rows[i].Cells[1].FindControl("DropDownList_Unit");
                             //最原始的可用金额
                             HiddenField HF_Oldbalance = (HiddenField)GridView1.Rows[i].Cells[1].FindControl("HiddenField_balance");

                            HiddenField HF_BILI = (HiddenField)GridView1.Rows[i].Cells[1].FindControl("HF_BILI");
                            Label lb_bili = (Label)GridView1.Rows[i].Cells[3].FindControl("lb_bili");

                             decimal balance = decimal.Parse(TextBox_balance.Text.ToString()) * decimal.Parse(ddl_unit.SelectedValue.ToString());
                            //最原始的可用金额占总的可用金额中是多大的比例
                             //decimal bili =decimal.Parse(HF_Oldbalance.Value.ToString()) / oldtotal;
                             decimal bili =decimal.Parse(HF_BILI.Value.ToString());
                             if (ddl_unit.SelectedValue.ToString().Equals("10000"))
                             {
                                 TextBox_balance.Text = Math.Round((decimal.Parse(totalvalues) * bili) / 10000, 3).ToString();
                             }
                             else
                             {
                                 TextBox_balance.Text = Math.Round(decimal.Parse(totalvalues) * bili, 2).ToString();
                             }

                             if (bili < decimal.Parse("0.01"))
                             {
                                 lb_bili.Text = "<0.01%";
                             }
                             else
                             {
                                 lb_bili.Text = Math.Round(bili * 100, 2).ToString() + "%";
                             }
                             
                            }
                        //Button_save_Click(Button_save, e);
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 统计比例值
        /// </summary>
        private void getBili()
        {
            try
            {
                //可用金额
                string totalvalues = TB_LimitNums.Text.ToString();
                //预算金额
                decimal oldtotal = decimal.Parse(TB_Balance.Text.ToString());
                    if (oldtotal > 0)
                    {
                        for (int i = 0; i < GridView1.Rows.Count; i++)
                        {
                            Label lb_bili = (Label)GridView1.Rows[i].Cells[3].FindControl("lb_bili");
                            TextBox TextBox_balance = (TextBox)GridView1.Rows[i].Cells[1].FindControl("TextBox_balance");

                            if (TextBox_balance.Text.ToString().Equals("0"))
                            {
                                lb_bili.Text = "";
                            }
                            else
                            {
                                DropDownList DropDownList_Unit = (DropDownList)GridView1.Rows[i].Cells[1].FindControl("DropDownList_Unit");
                                HiddenField HF_BILI = (HiddenField)GridView1.Rows[i].Cells[1].FindControl("HF_BILI");
                                //最原始的可用金额
                                HiddenField HF_Oldbalance = (HiddenField)GridView1.Rows[i].Cells[1].FindControl("HiddenField_balance");

                                decimal values = decimal.Parse(TextBox_balance.Text.ToString()) * decimal.Parse(DropDownList_Unit.SelectedValue.ToString());
                                //最原始的可用金额在预算金额中占的比例
                                //decimal bili = decimal.Parse(HF_Oldbalance.Value.ToString()) / oldtotal;

                                decimal bili = decimal.Parse(values.ToString()) / decimal.Parse(totalvalues);
                                HF_BILI.Value = bili.ToString();

                                if (bili < decimal.Parse("0.01"))
                                {
                                    lb_bili.Text = "<0.01%";
                                }
                                else
                                {
                                    lb_bili.Text = Math.Round(bili * 100, 2).ToString() + "%";
                                }
                            }
                            
                            
                        }
                    }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 返回预算金额
        /// </summary>
        public string Balance
        {
            get
            {
                return TB_Balance.Text.ToString();
            }
            set
            {
                TB_Balance.Text = value;
            }
        }
        /// <summary>
        /// 返回可用金额
        /// </summary>
        public string LimitNums
        {
            get
            {
                return TB_LimitNums.Text.ToString();
            }
            set
            {
                TB_LimitNums.Text = value;
            }
        }

        /// <summary>
        /// 返回初始总金额
        /// </summary>
        public GridView GV1
        {
            get
            {
                return GridView1;
            }
            set
            {
                GridView1 = value;
            }
        }
    }
}