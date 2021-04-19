using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_UserList 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_UserList
	{
		public Project_UserList()
		{}
		#region Model
		private int _id;
		private int? _projectid;
		private string _userid;
		private int? _status;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 项目的ID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
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
		/// 当前用户在项目组中的状态（0表示暂停，1表示正常）
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 加入的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

