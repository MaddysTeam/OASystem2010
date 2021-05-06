using System;
namespace Dianda.Model
{
	/// <summary>
	/// Buget_Detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Budget_Detail
	{
		public Budget_Detail()
		{}  
		#region Model
		private int _id;
		private int? _budgetid;
		private decimal? _balance;
		private int? _unit;
		private decimal? _oldbalance;
		private decimal? _kybalance;
		private string _detailname;

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
		/// 当前余额，当前余额在新建时和预算金额相同，但是记帐时会增加或减少。
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}

		/// <summary>
		/// 单位(1表示元;10000表示万元)
		/// </summary>
		public int? Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}

		/// <summary>
		/// 记录的是最初在新建预算时记录的各项的初始预算金额(元)，是不变的。
		/// </summary>
		public decimal? Oldbalance
		{
			set{ _oldbalance=value;}
			get{return _oldbalance;}
		}

		/// <summary>
		/// 可用金额，即当资金新建时与预算金额相同，可以在编辑时的调整可用总额按比例计算后的金额
		/// </summary>
		public decimal? KYbalance
		{
			set{ _kybalance=value;}
			get{return _kybalance;}
		}

		/// <summary>
		/// 明细项名称
		/// </summary>
		public string DetailName
		{
			set { _detailname = value; }
			get { return _detailname; }
		}

	}
}

#endregion