using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类NEWS_USERID_COLUMNSID 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class NEWS_USERID_COLUMNSID
	{
		public NEWS_USERID_COLUMNSID()
		{}
		#region Model
		private string _id;
		private string _userid;
		private string _columnsid;
		private int? _isshenhe;
		private int? _isadd;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户的ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 管理栏目的ID
		/// </summary>
		public string ColumnsID
		{
			set{ _columnsid=value;}
			get{return _columnsid;}
		}
		/// <summary>
		/// 审核信息的权限,0表示没有,1表示有
		/// </summary>
		public int? ISShenHe
		{
			set{ _isshenhe=value;}
			get{return _isshenhe;}
		}
		/// <summary>
		/// 是否有添加,编辑,删除栏目信息的权利:0表示没有,1表示有
		/// </summary>
		public int? ISAdd
		{
			set{ _isadd=value;}
			get{return _isadd;}
		}
		/// <summary>
		/// 添加的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

