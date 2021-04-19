using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Cash_Cards 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Cash_Cards
	{
		public Cash_Cards()
		{}
		#region Model
		private int _id;
		private string _cardnum;
		private string _cardname;
		private string _cardholderid;
		private string _departmentid;
		private int? _projectid;
		private decimal? _balance;
        private decimal? _yebalance;
		private decimal? _limitnums;
		private string _approverids;
		private DateTime? _datetime;
		private int? _statas;
		private string _douserid;
		private DateTime? _endtime;
		private string _temp0;
		private string _temp1;
		private string _temp2;
		private string _temp3;
        private int? _specialfundsid;
        private int? _sforderid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 资金卡的编码
		/// </summary>
		public string CardNum
		{
			set{ _cardnum=value;}
			get{return _cardnum;}
		}
		/// <summary>
		/// 资金卡的名称
		/// </summary>
		public string CardName
		{
			set{ _cardname=value;}
			get{return _cardname;}
		}
		/// <summary>
		/// 资金卡持卡人的ID
		/// </summary>
		public string CardholderID
		{
			set{ _cardholderid=value;}
			get{return _cardholderid;}
		}
		/// <summary>
		/// 所属部门的ID
		/// </summary>
		public string DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 项目的ID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// 资金卡的预算金额
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
        /// <summary>
		/// 资金卡的当前余额
		/// </summary>
        public decimal? YEBalance
		{
			set{ _yebalance=value;}
			get{return _yebalance;}
		}
		/// <summary>
		/// 资金卡的可用金额
		/// </summary>
		public decimal? LimitNums
		{
			set{ _limitnums=value;}
			get{return _limitnums;}
		}
		/// <summary>
		/// 审批人的ID
		/// </summary>
		public string ApproverIDs
		{
			set{ _approverids=value;}
			get{return _approverids;}
		}
		/// <summary>
		/// 填写的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 所属预算报告
		/// </summary>
        public int? SFOrderID
		{
			set{ _sforderid=value;}
            get { return _sforderid; }
		}
        /// <summary>
		/// 专项资金
		/// </summary>
        public int? SpecialFundsID
		{
			set{ _specialfundsid=value;}
            get { return _specialfundsid; }
		}
        /// <summary>
		/// 当前资金卡的状态（0-暂停使用、1表示正常使用中）
		/// </summary>
		public int? Statas
		{
			set{ _statas=value;}
			get{return _statas;}
		}
		/// <summary>
		/// 操作者的ID
		/// </summary>
		public string DoUserID
		{
			set{ _douserid=value;}
			get{return _douserid;}
		}
		/// <summary>
		/// 资金卡的到期时间
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEMP0
		{
			set{ _temp0=value;}
			get{return _temp0;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEMP1
		{
			set{ _temp1=value;}
			get{return _temp1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEMP2
		{
			set{ _temp2=value;}
			get{return _temp2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEMP3
		{
			set{ _temp3=value;}
			get{return _temp3;}
		}
		#endregion Model

	}
}

