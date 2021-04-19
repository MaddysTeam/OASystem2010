using System;
namespace Dianda.Model
{
	/// <summary>
	/// Cash_Account:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cash_Account
	{
		public Cash_Account()
		{}
		#region Model
		private int _id;
		private string _names;
		private int? _status;
		private DateTime? _addtime;
		private decimal? _balance;
		private decimal? _totalnum;
		private string _adduser;
		private string _bank;
		private string _bankinfo;
		private int? _delflag;
		private string _note;
		private DateTime? _freezetime;
		private string _temp1;
		private string _temp2;
		private string _temp3;
		private string _temp4;
        private string _temp5;
        private decimal? _everydaynum;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 账户的名称
		/// </summary>
		public string NAMES
		{
			set{ _names=value;}
			get{return _names;}
		}
		/// <summary>
		/// 账户的状态：0表示暂停；1表示正常
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
		/// 账户余额
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		/// 总费用（可以不填写）
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
		/// 开户行名称
		/// </summary>
		public string Bank
		{
			set{ _bank=value;}
			get{return _bank;}
		}
		/// <summary>
		/// 开户行基本信息
		/// </summary>
		public string BankInfo
		{
			set{ _bankinfo=value;}
			get{return _bankinfo;}
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
		/// 账户冻结的时间(如果发生冻结时,填写)
		/// </summary>
		public DateTime? FreezeTime
		{
			set{ _freezetime=value;}
			get{return _freezetime;}
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
        /// <summary>
        /// 每日限额
        /// </summary>
        public decimal? EveryDayNum
        {
            set { _everydaynum = value; }
            get { return _everydaynum; }
        }
		#endregion Model

	}
}

