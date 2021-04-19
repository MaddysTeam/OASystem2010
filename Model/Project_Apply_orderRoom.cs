using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_Apply_orderRoom ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// Project_Apply�������ID
		/// </summary>
		public int? ApplyID
		{
			set{ _applyid=value;}
			get{return _applyid;}
		}
		/// <summary>
		/// �����ҵ�ID
		/// </summary>
		public int? RoomID
		{
			set{ _roomid=value;}
			get{return _roomid;}
		}
		/// <summary>
		/// �ó��Ŀ�ʼʱ��
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// �ó��Ľ���ʱ��
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// ���������
		/// </summary>
		public int? PeopleNum
		{
			set{ _peoplenum=value;}
			get{return _peoplenum;}
		}
		/// <summary>
		/// ���������
		/// </summary>
		public string MeetName
		{
			set{ _meetname=value;}
			get{return _meetname;}
		}
		/// <summary>
		/// �����ַ
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		#endregion Model

	}
}

