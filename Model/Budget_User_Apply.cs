using System;
namespace Dianda.Model
{
	/// <summary>
	/// Budget_User_Apply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Budget_User_Apply
	{
		public Budget_User_Apply()
		{}  
		#region Model
		private int _id;
		private int? _budgetid;
		private int? _detailId;
		private decimal? _balance;
		private string _doUserId;
		private DateTime _addTime;

		/// <summary>
		/// 预算明细ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 预算ID
		/// </summary>
		public int? BudgetID
		{
			set{ _budgetid = value;}
			get{return _budgetid; }
		}

		/// <summary>
		/// 当前记账金额
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}

		/// <summary>
		///  预算明细id
		/// </summary>
		public int? DetailID
		{
			set{ _detailId=value;}
			get{return _detailId; }
		}

		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddTime
		{
			set { _addTime = value; }
			get { return _addTime; }
		}


		/// <summary>
		/// 添加时间
		/// </summary>
		public string DoUserID
		{
			set { _doUserId = value; }
			get { return _doUserId; }
		}
	}
}

#endregion