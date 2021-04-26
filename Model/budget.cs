using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Budget 。(属性说明自动提取数据库字段的描述信息)
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
		/// 预算id
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}

		/// <summary>
		/// 预算名称
		/// </summary>
		public string BudgetName
		{
			set{ _budgetname = value;}
			get{return _budgetname; }
		}

		/// <summary>
		/// 负责人的ID
		/// </summary>
		public string ManagerIDs
		{
			set{ _managerids = value;}
			get{return _managerids; }
		}

		/// <summary>
		/// 所属部门的ID
		/// </summary>
		public string DepartmentIDs
		{
			set{ _departmentids = value;}
			get{return _departmentids; }
		}
	
		/// <summary>
		/// 预算金额
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}

        /// <summary>
		/// 预算的当前余额
		/// </summary>
        public decimal? YEBalance
		{
			set{ _yebalance=value;}
			get{return _yebalance;}
		}

		/// <summary>
		/// 预算的可用金额
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
		/// 当前预算的状态（0-暂停使用、1表示正常使用中）
		/// </summary>
		public int? Statas
		{
			set{ _statas=value;}
			get{return _statas;}
		}

		/// <summary>
		/// 预算类型（1-部门预算、2-待办预算）
		/// </summary>
		public int? BudgetType
		{
			set { _budgettype = value; }
			get { return _budgettype; }
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
		/// 预算开始时间
		/// </summary>
		public DateTime? StartTime
		{
			set { _starttime = value; }
			get { return _starttime; }
		}

		/// <summary>
		/// 预算的到期时间
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

