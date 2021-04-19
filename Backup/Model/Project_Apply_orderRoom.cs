using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_Apply_orderRoom 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_Apply_orderRoom
	{
		public Project_Apply_orderRoom()
		{}
		#region Model
		private int _id;
		private int? _applyid;
		private int? _roomid;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private int? _peoplenum;
		private string _meetname;
		private string _address;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Project_Apply中申请的ID
		/// </summary>
		public int? ApplyID
		{
			set{ _applyid=value;}
			get{return _applyid;}
		}
		/// <summary>
		/// 会议室的ID
		/// </summary>
		public int? RoomID
		{
			set{ _roomid=value;}
			get{return _roomid;}
		}
		/// <summary>
		/// 用车的开始时间
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 用车的结束时间
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 会议的人数
		/// </summary>
		public int? PeopleNum
		{
			set{ _peoplenum=value;}
			get{return _peoplenum;}
		}
		/// <summary>
		/// 会议的名称
		/// </summary>
		public string MeetName
		{
			set{ _meetname=value;}
			get{return _meetname;}
		}
		/// <summary>
		/// 会议地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		#endregion Model

	}
}

