using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Term_Diary 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Term_Diary
	{
		public Term_Diary()
		{}
		#region Model
		private int _id;
		private DateTime? _datetime;
		private string _contents;
		private DateTime? _firstweek;
		private DateTime? _lastweek;
		private int? _delflag;
		private int? _iswork;
		private string _userid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 说明文字
		/// </summary>
		public string CONTENTS
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 本年度第一周的时间点
		/// </summary>
		public DateTime? FirstWeek
		{
			set{ _firstweek=value;}
			get{return _firstweek;}
		}
		/// <summary>
		/// 本年度最后一周的时间
		/// </summary>
		public DateTime? LastWeek
		{
			set{ _lastweek=value;}
			get{return _lastweek;}
		}
		/// <summary>
		/// 0表示正常，1表示删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 是否是当前的工作学期：0表示不是，1表示是
		/// </summary>
		public int? isWork
		{
			set{ _iswork=value;}
			get{return _iswork;}
		}
		/// <summary>
		/// 创建的用户ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

