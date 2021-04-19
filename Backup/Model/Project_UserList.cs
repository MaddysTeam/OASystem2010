using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_UserList ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��Ŀ��ID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// �û���ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ��ǰ�û�����Ŀ���е�״̬��0��ʾ��ͣ��1��ʾ������
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// �����ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

