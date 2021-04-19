using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Cash_Message ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �ʽ𿨵�����
		/// </summary>
		public string CardName
		{
			set{ _cardname=value;}
			get{return _cardname;}
		}
		/// <summary>
		/// �ʽ𿨳ֿ��˵�ID
		/// </summary>
		public string CardholderID
		{
			set{ _cardholderid=value;}
			get{return _cardholderid;}
		}
		/// <summary>
		/// �������ŵ�ID
		/// </summary>
		public string DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// ��Ŀ��ID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// �ʽ𿨵����
		/// </summary>
		public decimal? LimitNums
		{
			set{ _limitnums=value;}
			get{return _limitnums;}
		}
		/// <summary>
		/// �����˵�ID
		/// </summary>
		public string ApproverIDs
		{
			set{ _approverids=value;}
			get{return _approverids;}
		}
		/// <summary>
		/// ��д��ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// ���������Ϣ���û���ID
		/// </summary>
		public string SendUserID
		{
			set{ _senduserid=value;}
			get{return _senduserid;}
		}
		/// <summary>
		/// ֪ͨ�ı�ע˵��
		/// </summary>
		public string Notes
		{
			set{ _notes=value;}
			get{return _notes;}
		}
		/// <summary>
		/// �Ƿ��Ѿ��Ķ���0��ʾδ����1��ʾ�Ѷ�
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// �Ķ���ʱ��
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// ���Ķ�����д�ı�ע��Ϣ
		/// </summary>
		public string DoNotes
		{
			set{ _donotes=value;}
			get{return _donotes;}
		}
		/// <summary>
		/// �Ķ��ߵ�ID
		/// </summary>
		public string DoUserID
		{
			set{ _douserid=value;}
			get{return _douserid;}
		}
		/// <summary>
		/// ��Ϣ��״̬��0��ʾ��Ϣ���ڴ�����״̬��1��ʾ��Ϣ�Ѿ����ͣ�����Ŀ��Կ�����
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
        /// <summary>
		/// Ԥ�㱨��ID
		/// </summary>
        public int? SFOrderID
		{
			set{ _sforderid=value;}
            get { return _sforderid; }
		}
		#endregion Model

	}
}

