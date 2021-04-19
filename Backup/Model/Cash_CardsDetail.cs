using System;
namespace Dianda.Model
{
	/// <summary>
	/// Cash_CardsDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cash_CardsDetail
	{
		public Cash_CardsDetail()
		{}
		#region Model
		private int _id;
		private int? _cardid;
		private int? _detailid;
		private decimal? _balance;
		private int? _unit;
		private string _typesname;
		private decimal? _oldbalance;
		private decimal? _kybalance;
		private string _detailname;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 资金卡ID
		/// </summary>
		public int? CardID
		{
			set{ _cardid=value;}
			get{return _cardid;}
		}
		/// <summary>
		/// Cash_ControlInfo中的明细ID
		/// </summary>
		public int? DetailID
		{
			set{ _detailid=value;}
			get{return _detailid;}
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
		/// 细目的类型(公务卡,现金---用中文保存)
		/// </summary>
		public string TypesName
		{
			set{ _typesname=value;}
			get{return _typesname;}
		}
		/// <summary>
		/// 记录的是最初在新建资金卡时记录的各项的初始预算金额(元)，是不变的。
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
		/// 
		/// </summary>
		public string DetailName
		{
			set{ _detailname=value;}
			get{return _detailname;}
		}
		#endregion Model

	}
}

