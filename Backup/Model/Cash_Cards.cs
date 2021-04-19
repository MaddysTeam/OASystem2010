using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Cash_Cards ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �ʽ𿨵ı���
		/// </summary>
		public string CardNum
		{
			set{ _cardnum=value;}
			get{return _cardnum;}
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
		/// �ʽ𿨵�Ԥ����
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
        /// <summary>
		/// �ʽ𿨵ĵ�ǰ���
		/// </summary>
        public decimal? YEBalance
		{
			set{ _yebalance=value;}
			get{return _yebalance;}
		}
		/// <summary>
		/// �ʽ𿨵Ŀ��ý��
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
		/// ����Ԥ�㱨��
		/// </summary>
        public int? SFOrderID
		{
			set{ _sforderid=value;}
            get { return _sforderid; }
		}
        /// <summary>
		/// ר���ʽ�
		/// </summary>
        public int? SpecialFundsID
		{
			set{ _specialfundsid=value;}
            get { return _specialfundsid; }
		}
        /// <summary>
		/// ��ǰ�ʽ𿨵�״̬��0-��ͣʹ�á�1��ʾ����ʹ���У�
		/// </summary>
		public int? Statas
		{
			set{ _statas=value;}
			get{return _statas;}
		}
		/// <summary>
		/// �����ߵ�ID
		/// </summary>
		public string DoUserID
		{
			set{ _douserid=value;}
			get{return _douserid;}
		}
		/// <summary>
		/// �ʽ𿨵ĵ���ʱ��
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

