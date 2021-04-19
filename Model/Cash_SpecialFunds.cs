using System;
namespace Dianda.Model
{
	/// <summary>
	/// Cash_SpecialFunds:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cash_SpecialFunds
	{
		public Cash_SpecialFunds()
		{}
		#region Model
		private int _id;
		private string _names;
		private int? _years;
		private int? _accountid;
		private int? _status;
		private DateTime? _addtime;
		private decimal? _balance;
		private decimal? _totalnum;
		private string _adduser;
		private int? _delflag;
		private string _note;
		private int? _islistapply;
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
		/// 专项资金的名称
		/// </summary>
		public string NAMES
		{
			set{ _names=value;}
			get{return _names;}
		}
		/// <summary>
		/// 账户的状态：0表示暂停；1表示正常
		/// </summary>
		public int? YEARS
		{
			set{ _years=value;}
			get{return _years;}
		}
		/// <summary>
		/// 账户中的ID
		/// </summary>
		public int? AccountID
		{
			set{ _accountid=value;}
			get{return _accountid;}
		}
		/// <summary>
		/// 专项资金的状态：0表示暂停；1表示正常
		/// </summary>
		public int? STATUS
		{
			set{ _status=value;}
			get{return _status;}
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
		/// 可用金额
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		/// 预算金额
		/// </summary>
		public decimal? TotalNum
		{
			set{ _totalnum=value;}
			get{return _totalnum;}
		}
		/// <summary>
		/// 添加的用户
		/// </summary>
		public string Adduser
		{
			set{ _adduser=value;}
			get{return _adduser;}
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
		/// 备注信息
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 是否在预约申请中直接列出（0表示不可以，1表示可以）
		/// </summary>
		public int? IsListApply
		{
			set{ _islistapply=value;}
			get{return _islistapply;}
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

