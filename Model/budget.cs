using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Budget ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Budget
	{
		public Budget()
		{}
		#region Model
		private int _id;
		private string _budgetname;
		private string _departmentids;
		private string _managerids;
		private string _approverids;
		private decimal? _balance;
		private decimal? _yebalance;
		private decimal? _limitnums;
		private DateTime? _datetime;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private int? _budgettype;
		private int? _statas;
		private string _douserid;
		private string _temp0;
		private string _temp1;
		private string _temp2;
		private string _temp3;

		/// <summary>
		/// Ԥ��id
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}

		/// <summary>
		/// Ԥ������
		/// </summary>
		public string BudgetName
		{
			set{ _budgetname = value;}
			get{return _budgetname; }
		}

		/// <summary>
		/// �����˵�ID
		/// </summary>
		public string ManagerIDs
		{
			set{ _managerids = value;}
			get{return _managerids; }
		}

		/// <summary>
		/// �������ŵ�ID
		/// </summary>
		public string DepartmentIDs
		{
			set{ _departmentids = value;}
			get{return _departmentids; }
		}
	
		/// <summary>
		/// Ԥ����
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}

        /// <summary>
		/// Ԥ��ĵ�ǰ���
		/// </summary>
        public decimal? YEBalance
		{
			set{ _yebalance=value;}
			get{return _yebalance;}
		}

		/// <summary>
		/// Ԥ��Ŀ��ý��
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
		/// ��ǰԤ���״̬��0-��ͣʹ�á�1��ʾ����ʹ���У�
		/// </summary>
		public int? Statas
		{
			set{ _statas=value;}
			get{return _statas;}
		}

		/// <summary>
		/// Ԥ�����ͣ�1-����Ԥ�㡢2-����Ԥ�㣩
		/// </summary>
		public int? BudgetType
		{
			set { _budgettype = value; }
			get { return _budgettype; }
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
		/// Ԥ�㿪ʼʱ��
		/// </summary>
		public DateTime? StartTime
		{
			set { _starttime = value; }
			get { return _starttime; }
		}

		/// <summary>
		/// Ԥ��ĵ���ʱ��
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

