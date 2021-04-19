using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_RoomList 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_RoomList
	{
		public Project_RoomList()
		{}
		#region Model
		private int _id;
		private string _roomname;
		private string _roomnum;
		private string _infors;
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
		/// 会议室的名称
		/// </summary>
		public string RoomName
		{
			set{ _roomname=value;}
			get{return _roomname;}
		}
		/// <summary>
		/// 会议室编号
		/// </summary>
		public string RoomNum
		{
			set{ _roomnum=value;}
			get{return _roomnum;}
		}
		/// <summary>
		/// 会议室的简介
		/// </summary>
		public string Infors
		{
			set{ _infors=value;}
			get{return _infors;}
		}
		/// <summary>
		/// 0表示正常，1表示删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

