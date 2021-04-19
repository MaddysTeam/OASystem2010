using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_Task 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_Task
	{
		public Project_Task()
		{}
		#region Model
		private int _id;
		private int? _projectid;
		private string _names;
		private int? _delflag;
		private int? _status;
		private int? _completetype;
		private string _userids;
		private string _userinfo;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private string _overviews;
		private DateTime? _datetime;
		private string _senduserid;
		private DateTime? _readtime;
		private int? _upid;
		private int? _isfather;
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
		/// 任务的标题
		/// </summary>
		public string NAMES
		{
			set{ _names=value;}
			get{return _names;}
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
		/// 任务的状态：0表示未开始；1表示进行中；2表示完成；3表示延期
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 完成任务的条件约束：0表示全部组员完成时算完成；1表示其中之一完成时，算任务完成
		/// </summary>
		public int? CompleteType
		{
			set{ _completetype=value;}
			get{return _completetype;}
		}
		/// <summary>
		/// 参与的用户的ID值+“，”+完成状态值；多个用户间用分号隔开
		/// </summary>
		public string UserIDs
		{
			set{ _userids=value;}
			get{return _userids;}
		}
		/// <summary>
		/// 用户的真实姓名+用户名+“,”。目的是在列表中显示用
		/// </summary>
		public string UserInfo
		{
			set{ _userinfo=value;}
			get{return _userinfo;}
		}
		/// <summary>
		/// 项目预计开始时间
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 项目预计结束时间
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 任务的描述
		/// </summary>
		public string Overviews
		{
			set{ _overviews=value;}
			get{return _overviews;}
		}
		/// <summary>
		/// 任务的发布时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 发布这个任务的用户的ID
		/// </summary>
		public string SendUserID
		{
			set{ _senduserid=value;}
			get{return _senduserid;}
		}
		/// <summary>
		/// 最终完成任务的时间，如果任务没有完成，组员每次更新一下，就记录一下时间
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// 上级任务的ID
		/// </summary>
		public int? UpID
		{
			set{ _upid=value;}
			get{return _upid;}
		}
		/// <summary>
		/// 是否是可以构建子任务的任务。0表示不能构建；1表示父任务
		/// </summary>
		public int? IsFather
		{
			set{ _isfather=value;}
			get{return _isfather;}
		}
		#endregion Model

	}
}

