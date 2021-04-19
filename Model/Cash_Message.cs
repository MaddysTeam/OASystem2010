using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Cash_Message 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Cash_Message
	{
		public Cash_Message()
		{}
		#region Model
		private int _id;
		private string _cardname;
		private string _cardholderid;
		private string _departmentid;
		private int? _projectid;
		private decimal? _limitnums;
		private string _approverids;
		private DateTime? _datetime;
		private string _senduserid;
		private string _notes;
		private int? _isread;
		private DateTime? _readtime;
		private string _donotes;
		private string _douserid;
		private int? _status;
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
		/// 资金卡的余额
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
		/// 发出这个消息的用户的ID
		/// </summary>
		public string SendUserID
		{
			set{ _senduserid=value;}
			get{return _senduserid;}
		}
		/// <summary>
		/// 通知的备注说明
		/// </summary>
		public string Notes
		{
			set{ _notes=value;}
			get{return _notes;}
		}
		/// <summary>
		/// 是否已经阅读，0表示未读，1表示已读
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// 阅读的时间
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// 由阅读者填写的备注信息
		/// </summary>
		public string DoNotes
		{
			set{ _donotes=value;}
			get{return _donotes;}
		}
		/// <summary>
		/// 阅读者的ID
		/// </summary>
		public string DoUserID
		{
			set{ _douserid=value;}
			get{return _douserid;}
		}
		/// <summary>
		/// 消息的状态：0表示消息处在待发送状态；1表示消息已经发送，财务的可以看到了
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
        /// <summary>
		/// 预算报告ID
		/// </summary>
        public int? SFOrderID
		{
			set{ _sforderid=value;}
            get { return _sforderid; }
		}
		#endregion Model

	}
}

