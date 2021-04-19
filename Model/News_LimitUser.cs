using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类News_LimitUser 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class News_LimitUser
	{
		public News_LimitUser()
		{}
		#region Model
		private int _id;
		private string _userid;
		private int? _newsid;
		private int? _isread;
		private DateTime? _readtime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户的ID，一般是可以阅读该信息的用户的ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 信息的ID，
		/// </summary>
		public int? NewsID
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 0表示未读，1表示已读
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// 记录第一次阅读的时间
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		#endregion Model

	}
}

