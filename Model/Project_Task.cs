using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_Task ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��Ŀ��ID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// ����ı���
		/// </summary>
		public string NAMES
		{
			set{ _names=value;}
			get{return _names;}
		}
		/// <summary>
		/// 0��ʾ������1��ʾɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// �����״̬��0��ʾδ��ʼ��1��ʾ�����У�2��ʾ��ɣ�3��ʾ����
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ������������Լ����0��ʾȫ����Ա���ʱ����ɣ�1��ʾ����֮һ���ʱ�����������
		/// </summary>
		public int? CompleteType
		{
			set{ _completetype=value;}
			get{return _completetype;}
		}
		/// <summary>
		/// ������û���IDֵ+������+���״ֵ̬������û����÷ֺŸ���
		/// </summary>
		public string UserIDs
		{
			set{ _userids=value;}
			get{return _userids;}
		}
		/// <summary>
		/// �û�����ʵ����+�û���+��,����Ŀ�������б�����ʾ��
		/// </summary>
		public string UserInfo
		{
			set{ _userinfo=value;}
			get{return _userinfo;}
		}
		/// <summary>
		/// ��ĿԤ�ƿ�ʼʱ��
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// ��ĿԤ�ƽ���ʱ��
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// ���������
		/// </summary>
		public string Overviews
		{
			set{ _overviews=value;}
			get{return _overviews;}
		}
		/// <summary>
		/// ����ķ���ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// �������������û���ID
		/// </summary>
		public string SendUserID
		{
			set{ _senduserid=value;}
			get{return _senduserid;}
		}
		/// <summary>
		/// ������������ʱ�䣬�������û����ɣ���Աÿ�θ���һ�£��ͼ�¼һ��ʱ��
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// �ϼ������ID
		/// </summary>
		public int? UpID
		{
			set{ _upid=value;}
			get{return _upid;}
		}
		/// <summary>
		/// �Ƿ��ǿ��Թ��������������0��ʾ���ܹ�����1��ʾ������
		/// </summary>
		public int? IsFather
		{
			set{ _isfather=value;}
			get{return _isfather;}
		}
		#endregion Model

	}
}

