using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_RoomList ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �����ҵ�����
		/// </summary>
		public string RoomName
		{
			set{ _roomname=value;}
			get{return _roomname;}
		}
		/// <summary>
		/// �����ұ��
		/// </summary>
		public string RoomNum
		{
			set{ _roomnum=value;}
			get{return _roomnum;}
		}
		/// <summary>
		/// �����ҵļ��
		/// </summary>
		public string Infors
		{
			set{ _infors=value;}
			get{return _infors;}
		}
		/// <summary>
		/// 0��ʾ������1��ʾɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

