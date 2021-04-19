using System;
namespace Dianda.Model
{
	/// <summary>
	/// Cash_SF_Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cash_SF_Order
	{
		public Cash_SF_Order()
		{}
		#region Model
		private int _id;
		private string _names;
		private int? _specialfundsid;
		private int? _projectid;
		private DateTime? _addtime;
        private DateTime? _checktime;
		private decimal? _budgetamount;
		private string _baunit;
		private decimal? _actualamount;
		private string _aaunit;
		private string _applyuser;
		private int? _status;
		private int? _delflag;
		private string _budgetlist;
		private string _note;
		private string _checkerhistory;
		private string _checker;
		private string _assignchecker;
		private int? _carnums;
		private string _temp1;
		private string _temp2;
		private string _temp3;
		private string _temp4;
		private string _temp5;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 预算报告的名称
		/// </summary>
		public string NAMES
		{
			set{ _names=value;}
			get{return _names;}
		}
		/// <summary>
		/// 专项资金的ID
		/// </summary>
		public int? SpecialFundsID
		{
			set{ _specialfundsid=value;}
			get{return _specialfundsid;}
		}
		/// <summary>
		/// 所针对项目的ID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// 添加的时间
		/// </summary>
		public DateTime? ADDTIME
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
        /// <summary>
        /// 审批的时间
        /// </summary>
        public DateTime? CheckTime
        {
            set { _checktime = value; }
            get { return _checktime; }
        }

		/// <summary>
		/// 预算金额
		/// </summary>
		public decimal? BudgetAmount
		{
			set{ _budgetamount=value;}
			get{return _budgetamount;}
		}
		/// <summary>
		/// 预算金额的单位
		/// </summary>
		public string BAUNIT
		{
			set{ _baunit=value;}
			get{return _baunit;}
		}
		/// <summary>
		/// 实际确定金额
		/// </summary>
		public decimal? ActualAmount
		{
			set{ _actualamount=value;}
			get{return _actualamount;}
		}
		/// <summary>
		/// 实际确定金额的单位
		/// </summary>
		public string AAUNIT
		{
			set{ _aaunit=value;}
			get{return _aaunit;}
		}
		/// <summary>
		/// 申请的用户
		/// </summary>
		public string Applyuser
		{
			set{ _applyuser=value;}
			get{return _applyuser;}
		}
		/// <summary>
		/// 审核的状态（0待审核，1审核通过，2审核不通过）
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 删除标记：0-正常；1删除
		/// </summary>
		public int? Delflag
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 预算报告的文件路径
		/// </summary>
		public string BudgetList
		{
			set{ _budgetlist=value;}
			get{return _budgetlist;}
		}
		/// <summary>
		/// 备注信息
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 审核的历史记录(;用户名:审核结果;用户名:审核结果)
		/// </summary>
		public string CheckerHistory
		{
			set{ _checkerhistory=value;}
			get{return _checkerhistory;}
		}
		/// <summary>
		/// 审批人的ID（领导的ID）
		/// </summary>
		public string Checker
		{
			set{ _checker=value;}
			get{return _checker;}
		}
		/// <summary>
		/// 指定的经费审批人
		/// </summary>
		public string AssignChecker
		{
			set{ _assignchecker=value;}
			get{return _assignchecker;}
		}
		/// <summary>
		/// 资金卡的数目
		/// </summary>
		public int? CarNums
		{
			set{ _carnums=value;}
			get{return _carnums;}
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
		/// <summary>
		/// 
		/// </summary>
		public string TEMP4
		{
			set{ _temp4=value;}
			get{return _temp4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEMP5
		{
			set{ _temp5=value;}
			get{return _temp5;}
		}
		#endregion Model

	}
}

