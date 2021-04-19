using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类SYS_LOGS 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SYS_LOGS
	{
		public SYS_LOGS()
		{}
		#region Model
		private int _id;
		private string _userinfo;
		private string _ip;
		private string _dotype;
		private string _result;
		private DateTime? _datetime;
		private int? _delflag;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 操作者的基本信息，真名（用户名）
		/// </summary>
		public string USERINFO
		{
			set{ _userinfo=value;}
			get{return _userinfo;}
		}
		/// <summary>
		/// 操作者的IP地址
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 操作的类型
		/// </summary>
		public string DOTYPE
		{
			set{ _dotype=value;}
			get{return _dotype;}
		}
		/// <summary>
		/// 操作的结果
		/// </summary>
		public string RESULT
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 操作的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 删除标记
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

