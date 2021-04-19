using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Dianda.Web.Controls
{
    public partial class FeeAppointment : System.Web.UI.UserControl
    {
        #region 参数
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                if (ViewState["UserName"] != null)
                    return ViewState["UserName"].ToString();
                return null;
            }
            set { ViewState["UserName"] = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID
        {
            get
            {
                if (ViewState["UserID"] != null)
                    return ViewState["UserID"].ToString();
                return null;
            }
            set { ViewState["UserID"] = value; }
        }
        /// <summary>
        /// 经费预约
        /// </summary>
        public Model.Cash_Apply _modelCash_Apply
        {
            get
            {
                if (ViewState["_modelCash_Apply"] != null)
                    return (Model.Cash_Apply)ViewState["_modelCash_Apply"];
                return null;
            }
            set { ViewState["_modelCash_Apply"] = value; }
        }
        /// <summary>
        /// 项目数
        /// </summary>
        public int ProjectCount
        {
            get
            {
                if (ViewState["ProjectCount"] != null)
                    return int.Parse(ViewState["ProjectCount"].ToString());
                return 0;
            }
            set { ViewState["ProjectCount"] = value; }
        }
        /// <summary>
        /// 项目ID
        /// </summary>
        public string setProjectID
        {
            get
            {
                if (ViewState["setProjectID"] != null)
                    return ViewState["setProjectID"].ToString();
                return "0";
            }
            set { ViewState["setProjectID"] = value; }
        }
        /// <summary>
        /// 资金卡ID字符串
        /// </summary>
        public string setCardListID
        {
            get
            {
                if (ViewState["setCardListID"] != null)
                    return ViewState["setCardListID"].ToString();
                return null;
            }
            set { ViewState["setCardListID"] = value; }
        }
        /// <summary>
        /// 资金卡明细字符串
        /// </summary>
        public string setCarDetails
        {
            get
            {
                if (ViewState["setCarDetails"] != null)
                    return ViewState["setCarDetails"].ToString();
                return null;
            }
            set { ViewState["setCarDetails"] = value; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public string setApplyCount
        {
            get
            {
                if (ViewState["setApplyCount"] != null)
                    return ViewState["setApplyCount"].ToString();
                return null;
            }
            set { ViewState["setApplyCount"] = value; }
        }
        /// <summary>
        /// 账户|申请额,账户|申请额
        /// </summary>
        public string setTolStr
        {
            get
            {
                if (ViewState["setTolStr"] != null)
                    return ViewState["setTolStr"].ToString();
                return null;
            }
            set { ViewState["setTolStr"] = value; }
        }
        /// <summary>
        /// 专项资金id
        /// </summary>
        public string setSpecialFundsID
        {
            get
            {
                if (ViewState["setSpecialFundsID"] != null)
                    return ViewState["setSpecialFundsID"].ToString();
                return null;
            }
            set { ViewState["setSpecialFundsID"] = value; }
        }
        /// <summary>
        /// 当前属性（0 资金卡，1 专项资金）
        /// </summary>
        public string setAttribute
        {
            get
            {
                if (ViewState["setAttribute"] != null)
                    return ViewState["setAttribute"].ToString();
                return null;
            }
            set { ViewState["setAttribute"] = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string setTemp2
        {
            get
            {
                if (ViewState["setTemp2"] != null)
                    return ViewState["setTemp2"].ToString();
                return null;
            }
            set { ViewState["setTemp2"] = value; }
        }
        /// <summary>
        /// 属性值
        /// </summary>
        public string SetKey
        {
            get
            {
                if (ViewState["SetKey"] != null)
                    return ViewState["SetKey"].ToString();
                return null;
            }
            set { ViewState["SetKey"] = value; }
        }
        #endregion

        BLL.Cash_ControlInfo bllCash_ControlInfo = new Dianda.BLL.Cash_ControlInfo();
        BLL.Cash_CardsDetail bllCash_CardsDetail = new Dianda.BLL.Cash_CardsDetail();
        BLL.Cash_Cards bllCash_Cards = new Dianda.BLL.Cash_Cards();
        BLL.Project_Projects bllProject_Projects = new Dianda.BLL.Project_Projects();
        COMMON.common common = new COMMON.common();

        const string _PageAddHistory = "/Admin/cashCardManage/addHistory.aspx";

        public const string funOnBlur = "funOnBlur(this.id)";

        DataTable AccountDT = null;
        DataTable ApplyMXDT = null;
        DataTable ApplyDT = null;
        string ApplyMXTable = "";

        static string CarDetails = "";          //资金卡细目列表

        COMMON.pageControl pagecontrol = new Dianda.COMMON.pageControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(FeeAppointment), this.Page);
            if (!IsPostBack)
            {
                CarDetails = "";
            }
        }

        /// <summary>
        /// 构造帐户表结构
        /// </summary>
        public void StructureAccountDT()
        {
            AccountDT.Columns.Add("AccountID", System.Type.GetType("System.String"));           //账户ID
            AccountDT.Columns.Add("AccountName", System.Type.GetType("System.String"));         //账户名称
            AccountDT.Columns.Add("EveryDayNum", System.Type.GetType("System.String"));         //每日限额
            AccountDT.Columns.Add("Subscription", System.Type.GetType("System.String"));        //已预约款
        }

        public void StructureApplyDT()
        {
            ApplyDT.Columns.Add("AccountID", System.Type.GetType("System.String"));             //账户ID
            ApplyDT.Columns.Add("cardID", System.Type.GetType("System.String"));                //账户名称
            ApplyDT.Columns.Add("cardname", System.Type.GetType("System.String"));              //每日限额
            ApplyDT.Columns.Add("CarDetails", System.Type.GetType("System.String"));          //使用金额

        }
        /// <summary>
        /// 构造资金卡明细
        /// </summary>
        public void StructureApplyMXDT()
        {
            //预约明细表结构
            ApplyMXDT.Columns.Add("AccountID", System.Type.GetType("System.String"));       //账户ID
            ApplyMXDT.Columns.Add("cardID", System.Type.GetType("System.String"));          //资金卡卡号
            ApplyMXDT.Columns.Add("cardname", System.Type.GetType("System.String"));        //资金卡名称
            ApplyMXDT.Columns.Add("DetailName", System.Type.GetType("System.String"));      //明细的中文名称
            ApplyMXDT.Columns.Add("DetailName_FY", System.Type.GetType("System.String"));   //明细的金额
            ApplyMXDT.Columns.Add("DetailName_LX", System.Type.GetType("System.String"));   //明细的类型
            ApplyMXDT.Columns.Add("CarDetails", System.Type.GetType("System.String"));      //使用金额
        }
        /// <summary>
        /// 资金卡
        /// </summary>
        public void Show_DDList_Cards()
        {
            DataTable dt = new DataTable();
            string strSQL = "select cast(ID as varchar(10))+'|'+cast(AccountID as varchar(10)) ID, CardName from vCash_Cards where Statas='使用中' and CardholderID='" + common.SafeString(UserID) + "' and AccountSTATUS=1";
            dt = pagecontrol.doSql(strSQL).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DDList_Cards.DataSource = dt;
                DDList_Cards.DataTextField = "CardName";
                DDList_Cards.DataValueField = "ID";
                DDList_Cards.DataBind();
            }
        }
        /// <summary>
        /// 专项资金
        /// </summary>
        public void Show_DDL_SpecialFundsID()
        {
            try
            {
                DataTable DT = new DataTable();
                //modify by guanzhq on 2012-03-05 begin 
                // 添加判断 不显示不在预约中列出的数据
                //string sql = " SELECT cast(ID as varchar(10))+'|'+cast(accountid as varchar(10))+'|'+cast(isnull(EveryDayNum,0) as varchar(20)) Code, NAMES FROM vCash_SpecialFunds WHERE (STATUS = 1) and AccountStatus=1";

                string sql = " SELECT cast(ID as varchar(10))+'|'+cast(accountid as varchar(10))+'|'+cast(isnull(EveryDayNum,0) as varchar(20)) Code, NAMES FROM vCash_SpecialFunds WHERE (STATUS = 1) and AccountStatus=1 and IsListApply=1";
                //modify by guanzhq on 2012-03-05 end
                DT = pagecontrol.doSql(sql).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    DDL_SpecialFundsID.DataSource = DT;
                    DDL_SpecialFundsID.DataTextField = "NAMES";
                    DDL_SpecialFundsID.DataValueField = "Code";
                    DDL_SpecialFundsID.DataBind();
                }
                else
                {
                    ListItem li = new ListItem("-暂无可选专项资金-", "0");
                    DDL_SpecialFundsID.Items.Add(li);
                }
            }
            catch { }
        }
        /// <summary>
        /// 获取项目下拉列表值
        /// </summary>
        private void GetddlProjectID()
        {
            DataTable dt = new DataTable();
            //我负责的项目与我创建的项目(SendUserUserName=UserName表示我创建的，DoUserUserName＝UserName表示我负责的)
            string strSQL = " SELECT * FROM vProject_Projects WHERE (SendUserUserName='" + common.SafeString(UserName) + "' OR DoUserUserName='" + common.SafeString(UserName) + "' or LeaderUserName='" + common.SafeString(UserName) + "') and DELFLAG=0 and (Status=1)";

            dt = pagecontrol.doSql(strSQL).Tables[0];
            ProjectCount = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                this.ddlProjectID.DataSource = dt;
                this.ddlProjectID.DataTextField = "NAMES";
                this.ddlProjectID.DataValueField = "ID";
                this.ddlProjectID.DataBind();
            }

            ddlProjectID.Items.Insert(0, new ListItem("暂不属于任何项目", "0"));

            if (!string.IsNullOrEmpty(setProjectID))
                try { ddlProjectID.Items.FindByValue(setProjectID).Selected = true; }
                catch { }
        }
        /// <summary>
        /// 显示GridView
        /// </summary>
        public void Show()
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                GetddlProjectID();
                Show_DDList_Cards();
                Show_DDL_SpecialFundsID();
            }
            if (_modelCash_Apply != null)
            {
                if (!string.IsNullOrEmpty(SetKey))
                {
                    if (SetKey == "1" || SetKey == "2")
                    {
                        Lab_ZJK.Visible = false;
                        DDList_Cards.Visible = false;
                        Btn_Add.Visible = false;
                    }
                }
                string Attribute = _modelCash_Apply.Attribute;
                try { RBList_RXZ.Items.FindByValue(Attribute).Selected = true; }
                catch { }
                //按类型赋值
                if (Attribute == "0")
                {
                    Txt_ApplyCount1.Text = _modelCash_Apply.ApplyCount.ToString();
                    ddlProjectID.SelectedIndex = -1;
                    for (int i = 0; i < ddlProjectID.Items.Count; i++)
                    {
                        string[] strarr = ddlProjectID.Items[i].Value.Split('|');
                        if (strarr[0] == _modelCash_Apply.ProjectID.ToString())
                        {
                            ddlProjectID.Items[i].Selected = true;
                            break;
                        }
                    }
                }
                else
                {
                    Txt_ApplyCount2.Text = _modelCash_Apply.ApplyCount.ToString();
                    for (int i = 0; i < DDL_SpecialFundsID.Items.Count; i++)
                    {
                        string[] strarr = DDL_SpecialFundsID.Items[i].Value.Split('|');
                        if (strarr[0] == _modelCash_Apply.SpecialFundsID.ToString())
                        {
                            DDL_SpecialFundsID.Items[i].Selected = true;
                            break;
                        }
                    }
                }

                CarDetails = _modelCash_Apply.CarDetails;                               //资金卡细目列表
                if (_modelCash_Apply.CashCertificateID != null)
                {
                    ReadCardTable(_modelCash_Apply.CashCertificateID, "1");             //读取表结构和构造表

                    if (AccountDT.Rows.Count > 0)
                    {
                        if (SetKey == "2")
                        {
                            DataList1.DataSource = AccountDT;
                            DataList1.DataBind();
                        }
                        else if (SetKey == "1")
                        {
                            DataList2.DataSource = AccountDT;
                            DataList2.DataBind();

                        }
                    }
                }
                RBList_RXZ.Enabled = false;
                ddlProjectID.Enabled = false;
                DDList_Cards.Enabled = false;
                Txt_ApplyCount1.Enabled = false;
                DDL_SpecialFundsID.Enabled = false;
                Txt_ApplyCount2.Enabled = false;
                Btn_Add.Enabled = false;
            }
        }
        /// <summary>
        /// 读取表结构和构造表
        /// </summary>
        /// <param name="CardID"></param>
        /// <param name="_type"></param>
        public void ReadCardTable(string CardID, string _type)
        {
            try
            {
                if (!string.IsNullOrEmpty(CardID))
                {
                    string TabTitle = "", RowTitle = "", endTitle = "";
                    string sql = "select AccountID,cardID,DetailName,balance,cardname,TypesName,AccountName,isnull(EveryDayNum,0) EveryDayNum from vCash_CardsDetail where cardID in (" + common.SafeString(CardID) + ") and AccountSTATUS=1 order by AccountID,cardID,id";
                    DataTable dt = pagecontrol.doSql(sql).Tables[0];

                    ApplyMXDT = new DataTable();                                    //初始化表
                    ApplyDT = new DataTable();
                    AccountDT = new DataTable();                                    //初始化表

                    string[] CarDetailsArr = null;                                  //资金卡细目数组
                    string[] Arr = null;                                            //资金卡明细
                    if (!string.IsNullOrEmpty(CarDetails))
                    {
                        CarDetailsArr = CarDetails.Split(',');                      //拆分资金卡明细
                    }

                    //构造表结构
                    StructureAccountDT();
                    StructureApplyDT();
                    StructureApplyMXDT();
                    //构造表结构

                    ApplyMXTable = "";

                    string AccountIDTemp1 = "", AccountIDTemp2 = "";
                    string ApplyIDTemp1 = "", ApplyIDTemp2 = "";
                    string Balance = "", TypesName = "", AccountName = "", EveryDayNum = "";
                    string INFORS = "";
                    int Ci = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        //帐户表中添加信息
                        AccountIDTemp1 = dr["AccountID"].ToString();
                        if (AccountIDTemp1 != AccountIDTemp2)
                        {
                            DataRow Accoundr = AccountDT.NewRow(); //新增行
                            AccountName=dr["AccountName"].ToString();
                            EveryDayNum = dr["EveryDayNum"].ToString();
                            Accoundr["AccountID"] = AccountIDTemp1;
                            Accoundr["AccountName"] = AccountName;
                            Accoundr["EveryDayNum"] = EveryDayNum;
                            Accoundr["Subscription"] = "0";

                            AccountDT.Rows.Add(Accoundr);
                            AccountIDTemp2 = AccountIDTemp1;
                        }

                        //资金卡表中添加信息
                        ApplyIDTemp1 = dr["cardID"].ToString();
                        if (ApplyIDTemp1 != ApplyIDTemp2)
                        {
                            DataRow Applydr = ApplyDT.NewRow();
                            Applydr["cardID"] = ApplyIDTemp1;
                            Applydr["cardname"] = dr["cardname"].ToString();
                            Applydr["AccountID"] = AccountIDTemp1;
                            if (CarDetailsArr != null)
                            {
                                for (int i = 0; i < CarDetailsArr.Length; i++)
                                {
                                    Arr = null;
                                    Arr = CarDetailsArr[i].Split(':');
                                    if (ApplyIDTemp1 == Arr[0])
                                    {
                                        Applydr["CarDetails"] = CarDetailsArr[i];
                                        break;
                                    }
                                }
                            }
                            ApplyDT.Rows.Add(Applydr);
                            ApplyIDTemp2 = ApplyIDTemp1;
                            Ci = 1;
                        }

                        //明细表中添加信息
                        DataRow ApplyMXdr = ApplyMXDT.NewRow(); //新增行
                        //预约明细表结构
                        ApplyMXdr["AccountID"] = AccountIDTemp1;                    //账户ID
                        ApplyMXdr["cardID"] = ApplyIDTemp1;                         //资金卡卡号
                        Balance = dr["balance"].ToString();
                        TypesName = dr["TypesName"].ToString();
                        INFORS = dr["DetailName"].ToString();
                        ApplyMXdr["cardname"] = dr["cardname"].ToString();          //资金卡名称
                        ApplyMXdr["DetailName"] = INFORS;                           //明细的中文名称
                        ApplyMXdr["DetailName_FY"] = Balance;                       //明细的金额
                        ApplyMXdr["DetailName_LX"] = TypesName;                     //明细的类型

                        if (CarDetailsArr != null)
                        {
                            for (int i = 0; i < CarDetailsArr.Length; i++)
                            {
                                Arr = null;
                                Arr = CarDetailsArr[i].Split(':');
                                if (ApplyIDTemp1 == Arr[0])
                                {
                                    ApplyMXdr["CarDetails"] = Arr[Ci];
                                    break;
                                }
                            }
                        }
                        //当Ci等于1的时候画表头
                        if (Ci == 1)
                        {
                            if (_type =="3")
                            {
                                TabTitle += "<fieldset id='table" + AccountIDTemp1 + "@'><legend>";
                                TabTitle += "<label>" + AccountName + "：</label><label id='lab_Account" + AccountIDTemp1 + "@'>0</label>/" + EveryDayNum + "<label style='color: Red;'>（每日限报金额）</label><input type='hidden' id='hide_AccountID' value='" + AccountIDTemp1 + "' /></legend>";
                            }

                            TabTitle += "<table id='tab_Account" + ApplyIDTemp1 + "@' border='0' cellpadding='0' cellspacing='0' class='Green_Table'><tr style='height:30px;'><td>资金卡：<input type='button' id='" + ApplyIDTemp1 + "' hideid='" + AccountIDTemp1 + "' value='-' onclick='funRemoveRow(this);' /><label id='lab_cardname'>" + dr["cardname"].ToString() + "</label><input type='hidden' id='hide_CardID' value='" + ApplyIDTemp1 + "' /></td></tr><tr><td>";

                            endTitle = "</table>";
                        }

                        int tabNum = 7;
                        if (Ci % tabNum == 0 || Ci == 1)    //当满足这个条件的时候画内表头
                        {
                            if (Ci % tabNum == 0)
                            {
                                RowTitle += "</tr>";
                                ApplyMXTable += "</tr>"+RowTitle+"</table>";
                            }
                            ApplyMXTable += "<table border='0' cellpadding='0' cellspacing='0' class='Green_Table' id='tabCards' hideCarD='" + ApplyIDTemp1 + "' hideAccount='" + AccountIDTemp1 + "' hideCarDName='" + dr["cardname"].ToString() + "' ><tr style='height:30px;'>";
                            RowTitle = "";
                            RowTitle += "<tr style='height:30px;'>";
                        }

                        ApplyMXTable += "<td class='Green_TableHeader'>" + INFORS + "</td>";

                        RowTitle += "<td class='Green_TableRowCenter' style='width:60px;'>";
                        if (Balance == "0" || TypesName == "公务卡")        //可用金额是零或者类型是公务卡则不能输入
                            RowTitle += "-";
                        else
                            RowTitle += "<input type='text' id='" + INFORS + AccountIDTemp1 + "@Txt' style='width:40px;' onblur='" + funOnBlur + "' maxlength='20' />";
                        decimal money = decimal.Parse(Balance);
                        if (money < 0)
                            RowTitle += "<label id='" + INFORS + AccountIDTemp1 + "@Lab'><br />/<label style='color:Red;'>" + Balance + "</label></label></td>";
                        else if (money == 0)
                            RowTitle += "</td>";
                        else
                            RowTitle += "<label id='" + INFORS + AccountIDTemp1 + "@Lab'><br />/" + Balance + "</label></td>";

                        ApplyMXDT.Rows.Add(ApplyMXdr);
                        Ci++;
                    }

                    RowTitle += "</tr>";
                    ApplyMXTable += "</tr>" + RowTitle + "</table>";

                    ApplyMXTable = TabTitle + ApplyMXTable +"</td></tr>"+ endTitle;
                    if (_type == "3")
                    {
                        ApplyMXTable += "</fieldset>";
                    }

                    /*
                    string[] CarDetailsArr = null;                                  //资金卡细目数组
                    string[] Arr = null;                                            //资金卡明细
                    if (!string.IsNullOrEmpty(CarDetails))
                    {
                        CarDetailsArr = CarDetails.Split(',');                      //拆分资金卡明细
                    }
                    string RepCardID = "", RepAccountID = "";
                    if (dt.Rows.Count > 0)
                    {
                        DataRow ApplyMXdr = null;
                        DataRow Accountdr = null;

                        int countnum = 0;                                           //计数
                        int CarDetailsNum = 0;
                        float Subscription = 0;
                        //把所有数据归并到ApplyMXDT表中去
                        foreach (DataRow dr in dt.Rows)
                        {
                            string INFORS = dr["DetailName"].ToString();                //标题（列名）
                            string Balance = dr["Balance"].ToString();              //可使用金额
                            string CardVal = dr["cardID"].ToString();               //CardID值
                            string TypesName = dr["TypesName"].ToString();          //类型
                            string AccountID = dr["AccountID"].ToString();          //帐户ID值
                            string AccountName = dr["AccountName"].ToString();      //账户名称
                            string EveryDayNum = dr["EveryDayNum"].ToString();      //每日限额

                            //当账户不同时进入
                            if (RepAccountID != AccountID)
                            {
                                if (!string.IsNullOrEmpty(RepAccountID))
                                {
                                    Accountdr["Subscription"] = Subscription.ToString();
                                    AccountDT.Rows.Add(Accountdr);
                                    Subscription = 0;
                                }
                                Accountdr = AccountDT.NewRow();
                                Accountdr["AccountID"] = dr["AccountID"];
                                Accountdr["AccountName"] = dr["AccountName"];
                                Accountdr["EveryDayNum"] = dr["EveryDayNum"];
                                RepAccountID = AccountID;
                            }
                            //当资金卡不同时进入
                            if (RepCardID != CardVal)
                            {
                                countnum=1;
                                //不是第一次读就把当前行添加到ApplyMXDT表中去
                                if (!string.IsNullOrEmpty(RepCardID))
                                {
                                    ApplyMXDT.Rows.Add(ApplyMXdr);
                                    TabTitle += "<table id='tab_Account" + AccountID + "@' width='100%' border='0' cellpadding='0' cellspacing='0' class='Green_Table'><tr class='Green_TableHeader'><td class='Green_TableHeader'>资金卡</td>";
                                    ApplyMXTable += "</tr>";
                                }
                                else
                                {
                                    //添加表的框架和默认一列
                                    TabTitle += "<table id='table" + AccountID + "@' width='100%' border='0' cellpadding='0' cellspacing='0' ><tr style='height:30px;'><td valign='bottom'>";
                                    TabTitle += "<label>" + AccountName + "：</label><label id='lab_Account" + AccountID + "@'>0</label>/" + EveryDayNum + "<label style='color: Red;'>（每日限报金额）</label><input type='hidden' id='hide_AccountID' value='" + AccountID + "' /></td></tr>";
                                    TabTitle += "<tr><td><table id='tab_Account" + AccountID + "@' width='100%' border='0' cellpadding='0' cellspacing='0' class='Green_Table'><tr class='Green_TableHeader'><td class='Green_TableHeader'>资金卡</td>";
                                    ApplyMXTable += "<tr>";
                                }

                                //新建一行
                                ApplyMXdr = ApplyMXDT.NewRow();

                                if (CarDetailsArr != null)
                                {
                                    for (int i = 0; i < CarDetailsArr.Length; i++)
                                    {
                                        Arr = null;
                                        Arr = CarDetailsArr[i].Split(':');
                                        if (CardVal == Arr[0])
                                        {
                                            ApplyMXdr["CarDetails"] = CarDetailsArr[i];
                                            CarDetailsNum = 1;
                                            break;
                                        }
                                    }
                                }
                                ApplyMXdr["cardID"] = dr["cardID"];
                                ApplyMXdr["cardname"] = dr["cardname"];
                                ApplyMXdr["AccountID"] = dr["AccountID"];

                                ApplyMXTable += "<td class='Green_TableRowLeft'><input type='button' id='" + CardVal + "' value='-' onclick='funRemoveRow(this);' /><label id='lab_cardname'>" + dr["cardname"].ToString() + "</label><input type='hidden' id='hide_CardID' value='" + CardVal + "' /></td>";
                                if (countnum == 1)
                                {
                                    TabTitle += "<td class='Green_TableHeader'>" + INFORS + "</td>";
                                }

                                RepCardID = CardVal;
                            }
                            else
                            {
                                if (countnum == 1)
                                {
                                    TabTitle += "<td class='Green_TableHeader'>" + INFORS + "</td>";
                                }
                            }

                            ApplyMXdr[INFORS] = Balance;
                            ApplyMXdr[INFORS + "类型"] = TypesName;
                            if (Arr != null)
                            {
                                if (Arr[CarDetailsNum] != null)
                                {
                                    ApplyMXdr[INFORS + "费用"] = Arr[CarDetailsNum];
                                    Subscription += float.Parse(Arr[CarDetailsNum]);
                                }
                            }

                            CarDetailsNum++;
                            ApplyMXTable += "<td class='Green_TableRowCenter'>";
                            if (Balance == "0" || TypesName == "公务卡")        //可用金额是零或者类型是公务卡则不能输入
                                //ApplyMXTable += "<input type='text' id='" + INFORS + CardVal + "@Dis' style='width:40px;' disabled='disabled' value='—' />"; 
                                ApplyMXTable += "&nbsp;";
                            else
                                ApplyMXTable += "<input type='text' id='" + INFORS + CardVal + "@Txt' style='width:40px;' onblur='" + funOnBlur + "' maxlength='20' />";
                            decimal money = decimal.Parse(Balance);
                            if (money < 0)
                                ApplyMXTable += "<label id='" + INFORS + CardVal + "@Lab'><br />/<label style='color:Red;'>" + Balance + "</label></label></td>";
                            else if (money == 0)
                                ApplyMXTable += "";
                            else
                                ApplyMXTable += "<label id='" + INFORS + CardVal + "@Lab'><br />/" + Balance + "</label></td>";
                        }
                        TabTitle += "</tr>";
                        ApplyMXTable += "</tr>";

                        if (_type == "3")
                        {
                            ApplyMXTable = TabTitle + ApplyMXTable + "</table></td></tr></table>";
                        }

                        Accountdr["Subscription"] = Subscription.ToString();
                        AccountDT.Rows.Add(Accountdr);
                        ApplyMXDT.Rows.Add(ApplyMXdr);
                    }
                    */
                }
            }
            catch { }
        }

        [AjaxPro.AjaxMethod]
        public string ReturnVal(string CardsID, int num)
        {
            if (num > 0)
                ReadCardTable(CardsID, "2");
            else
                ReadCardTable(CardsID, "3");

            return ApplyMXTable;
        }

        public void SetValue()
        {
            setAttribute = RBList_RXZ.SelectedValue;
            if (setAttribute == "0")
            {
                setProjectID = ddlProjectID.SelectedValue;
                setCarDetails = hide_CarDetails.Value;
                setCardListID = hide_CardListID.Value;
                setTolStr = hide_Sum.Value;
                setApplyCount = Txt_ApplyCount1.Text;
                setSpecialFundsID = "0";
                setTemp2 = hide_CardName.Value;
            }
            else
            {
                string[] SpecialFundsID = DDL_SpecialFundsID.SelectedValue.Split('|');
                string ApplyCount2 = Txt_ApplyCount2.Text;

                setProjectID = "0";
                setCarDetails = "";
                setCardListID = DDL_SpecialFundsID.SelectedValue;
                setTolStr = SpecialFundsID[1] + "|" + ApplyCount2;
                setApplyCount = ApplyCount2;
                setSpecialFundsID = SpecialFundsID[0];
                setTemp2 = DDL_SpecialFundsID.SelectedItem.Text;
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string AccountID = DataBinder.Eval(e.Item.DataItem, "AccountID").ToString();

            DataRow[] drs = ApplyDT.Select("AccountID='" + AccountID + "'");
            DataTable newdt = new DataTable();
            newdt = ApplyDT.Clone();

            for (int i = 0; i < drs.Length; i++)
            {
                newdt.ImportRow((DataRow)drs[i]);
            }
            DataList DList_ZJK = (DataList)e.Item.FindControl("DList_ZJK");
            
            DList_ZJK.DataSource = newdt;
            DList_ZJK.DataBind();

            /*
            GridView GridView1 = (GridView)e.Item.FindControl("GridView1");
            for (int i = 0; i < drs.Length; i++)
            {
                newdt.ImportRow((DataRow)drs[i]);
            }

            for (int i = 4; i < newdt.Columns.Count; i += 3)
            {
                string INFORS = newdt.Columns[i].ColumnName;
                string FY = INFORS + "费用";
                string LX = INFORS + "类型";
                TemplateField TF = new TemplateField();
                TF.HeaderText = INFORS + "（元）";
                TF.ItemStyle.CssClass = "Green_TableRowCenter";
                string[] ColName = { FY, INFORS, LX };
                TF.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, ColName);
                GridView1.Columns.Add(TF);
            }
            string key = "";
            if (Request["key"] != null)
                key = Request["key"];
            if (key == "2")
            {
                GridView1.Columns[0].Visible = true;
            }

            GridView1.DataSource = newdt;
            GridView1.DataBind();
            */ 
        }

        protected void DList_ZJKMX_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            string cardID = DataBinder.Eval(e.Item.DataItem, "cardID").ToString();

            DataRow[] drs = ApplyMXDT.Select("cardID='" + cardID + "'");
            DataTable newdt = new DataTable();
            newdt = ApplyMXDT.Clone();

            for (int i = 0; i < drs.Length; i++)
            {
                newdt.ImportRow((DataRow)drs[i]);
            }
            DataList DList_ZJKMX = (DataList)e.Item.FindControl("DList_ZJKMX");

            DList_ZJKMX.DataSource = newdt;
            DList_ZJKMX.DataBind();
        }

        public void lb_Click(Object sender, EventArgs e)
        {
            LinkButton LBtn = (LinkButton)sender;
            string CarDetails = LBtn.CommandArgument;
            string[] arr = CarDetails.Split(':');
            string CardID = arr[0];
            Response.Redirect(_PageAddHistory + "?key=2&PageStr=add&id=" + CardID + "&CarDetails=" + CarDetails + ReturnCS());
        }
        public string ReturnCS()
        {
            string str = "";
            if (Request["ApplyID"] != null)
                str += "&ApplyID=" + Request["ApplyID"];
            if (Request["pageindex"] != null)
                str += "&pageindex=" + Request["pageindex"];
            if (Request["status"] != null)
                str += "&status=" + Request["status"];
            if (Request["parentpage"] != null)
                str += "&parentpage=" + Request["parentpage"];
            if (Request["date"] != null)
                str += "&date=" + Request["date"];

            return str;
        }
    }

    //构造Template
    public class GridViewTemplate : ITemplate
    {
        private DataControlRowType templateType;
        private string[] columnName;

        /// <summary>
        /// 构造函数赋值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="colname"></param>
        public GridViewTemplate(DataControlRowType type, string[] colname)
        {
            templateType = type;
            columnName = colname;
        }
        /// <summary>
        /// 构造TemplateField
        /// </summary>
        /// <param name="container"></param>
        public void InstantiateIn(System.Web.UI.Control container)
        {
            switch (templateType)
            {
                case DataControlRowType.Header:         //构造头元素
                    break;
                case DataControlRowType.DataRow:        //构造子元素
                    TextBox TB = new TextBox();
                    TB.DataBinding += new EventHandler(TB_DataBinding);
                    container.Controls.Add(TB);
                    Label Lab = new Label();
                    Lab.DataBinding += new EventHandler(Lab_DataBinding);
                    container.Controls.Add(Lab);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 生成TextBox控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_DataBinding(object sender, EventArgs e)
        {
            TextBox T = (TextBox)sender;
            GridViewRow row = (GridViewRow)T.NamingContainer;
            T.Width = 40;                                               //
            T.MaxLength = 20;
            //T.Attributes.Add("onblur", FeeAppointment.funOnBlur);              //添加事件
            //绑定值
            if (!string.IsNullOrEmpty(columnName[0]))
                T.Text = DataBinder.Eval(row.DataItem, columnName[0]).ToString();

            string Rs = "", LX = "";
            if (!string.IsNullOrEmpty(columnName[1]))
            {
                T.ID = columnName[1] + DataBinder.Eval(row.DataItem, "cardID").ToString() + "@Txt";       //生成特有的id
                Rs = DataBinder.Eval(row.DataItem, columnName[1]).ToString();
            }
            else
                T.Enabled = false;
            if (!string.IsNullOrEmpty(columnName[2]))
                LX = DataBinder.Eval(row.DataItem, columnName[2]).ToString();
            else
                T.Enabled = false;

            T.Enabled = false;
            if (Rs == "0" || LX == "公务卡")
            {
                //T.Text = "—";
                T.Visible = false;
            }
        }
        /// <summary>
        /// 生成Label控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lab_DataBinding(object sender, EventArgs e)
        {
            Label L = (Label)sender;
            GridViewRow row = (GridViewRow)L.NamingContainer;
            if (!string.IsNullOrEmpty(columnName[1]))
            {
                L.ID = columnName[1] + DataBinder.Eval(row.DataItem, "cardID").ToString() + "@Lab";       //生成特有的id
                decimal Money = decimal.Parse(DataBinder.Eval(row.DataItem, columnName[1]).ToString());
                L.Text = "<br />/";
                if (Money < 0)
                    L.Text += "<label style='color:Red;'>" + Money.ToString() + "</label>";
                else if (Money == 0)
                    L.Visible = false;
                else
                    L.Text += Money.ToString();
            }
        }
    }
}