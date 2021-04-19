using System;
namespace Dianda.Model
{
    /// <summary>
    /// Cash_Apply:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cash_Apply
    {
        public Cash_Apply()
        { }
        #region Model
        private int _id;
        private int? _projectid;
        private string _cashcertificateid;
        private decimal? _applycount;
        private DateTime? _getdatetime;
        private string _usefor;
        private string _appliertel;
        private string _applierid;
        private DateTime? _datetime;
        private int? _statas;
        private string _douserid;
        private string _cardetails;
        private string _temp1;
        private string _temp2;
        private string _temp3;
        private string _temp4;
        private string _temp5;
        private int? _specialfundsid;
        private string _attribute;
        private string _auditopinion;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 项目的ID
        /// </summary>
        public int? ProjectID
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 资金卡的ID(可以是多张资金卡)
        /// </summary>
        public string CashCertificateID
        {
            set { _cashcertificateid = value; }
            get { return _cashcertificateid; }
        }
        /// <summary>
        /// 申请的金额
        /// </summary>
        public decimal? ApplyCount
        {
            set { _applycount = value; }
            get { return _applycount; }
        }
        /// <summary>
        /// 期望预约取款的时间
        /// </summary>
        public DateTime? GetDateTime
        {
            set { _getdatetime = value; }
            get { return _getdatetime; }
        }
        /// <summary>
        /// 经费的申请用途
        /// </summary>
        public string UseFor
        {
            set { _usefor = value; }
            get { return _usefor; }
        }
        /// <summary>
        /// 申请人的联系电话
        /// </summary>
        public string ApplierTel
        {
            set { _appliertel = value; }
            get { return _appliertel; }
        }
        /// <summary>
        /// 申请人的ID，和USER_Users表中的用户ID关联
        /// </summary>
        public string ApplierID
        {
            set { _applierid = value; }
            get { return _applierid; }
        }
        /// <summary>
        /// 填写申请的时间
        /// </summary>
        public DateTime? DATETIME
        {
            set { _datetime = value; }
            get { return _datetime; }
        }
        /// <summary>
        /// 当前申请的状态（0-待审核、1表示审核通过、2表示审核不通过）
        /// </summary>
        public int? Statas
        {
            set { _statas = value; }
            get { return _statas; }
        }
        /// <summary>
        /// 操作者的ID
        /// </summary>
        public string DoUserID
        {
            set { _douserid = value; }
            get { return _douserid; }
        }
        /// <summary>
        /// 资金卡的细目列表
        /// </summary>
        public string CarDetails
        {
            set { _cardetails = value; }
            get { return _cardetails; }
        }
        /// <summary>
        /// 保存当前的帐号id+金额
        /// </summary>
        public string TEMP1
        {
            set { _temp1 = value; }
            get { return _temp1; }
        }
        /// <summary>
        /// 资金卡或专项资金名称串值
        /// </summary>
        public string TEMP2
        {
            set { _temp2 = value; }
            get { return _temp2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TEMP3
        {
            set { _temp3 = value; }
            get { return _temp3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TEMP4
        {
            set { _temp4 = value; }
            get { return _temp4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TEMP5
        {
            set { _temp5 = value; }
            get { return _temp5; }
        }
        /// <summary>
        /// 专项资金ID
        /// </summary>
        public int? SpecialFundsID
        {
            set { _specialfundsid = value; }
            get { return _specialfundsid; }
        }
        /// <summary>
        /// 属性（0：资金卡；1：专项资金）
        /// </summary>
        public string Attribute
        {
            set { _attribute = value; }
            get { return _attribute; }
        }
        /// <summary>
        /// 审核意见
        /// </summary>
        public string AuditOpinion
        {
            set { _auditopinion = value; }
            get { return _auditopinion; }
        }
        #endregion Model

    }
}

