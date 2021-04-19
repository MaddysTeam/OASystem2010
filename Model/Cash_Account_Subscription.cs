using System;
namespace Dianda.Model
{
	/// <summary>
	/// Cash_Account_Subscription:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cash_Account_Subscription
	{
		public Cash_Account_Subscription()
		{}
		#region Model
		private int _id;
		private int? _accountid;
		private DateTime? _applydatetime;
		private decimal? _subscription;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 账户ID
		/// </summary>
		public int? AccountID
		{
			set{ _accountid=value;}
			get{return _accountid;}
		}
		/// <summary>
		/// 预约时间
		/// </summary>
		public DateTime? ApplyDatetime
		{
			set{ _applydatetime=value;}
			get{return _applydatetime;}
		}
		/// <summary>
		/// 已预约款
		/// </summary>
		public decimal? Subscription
		{
			set{ _subscription=value;}
			get{return _subscription;}
		}
		#endregion Model

	}
}

