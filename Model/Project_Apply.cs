using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_Apply ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Project_Apply
	{
		public Project_Apply()
		{}
		#region Model
		private int _id;
		private int? _projectid;
		private int? _delflag;
		private int? _status;
		private string _apptype;
		private string _overviews;
		private DateTime? _datetime;
		private string _senduserid;
		private string _departmentid;
		private DateTime? _readtime;
		private string _douserid;
		private string _checknote;
		private string _telnum;
		private string _donote;
		private string _attachments;
		private string _applyuserid;
		private string _temp1;
		private string _temp2;
		private string _temp3;
		private string _temp4;
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
		/// 0��ʾ������1��ʾɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// �����״̬��0��ʾ����ˣ�1��ʾ���ͨ����2��ʾ��˲�ͨ��
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ҵ������ͣ�orderFood��������orderCar������orderRoom�������ҡ�orderSignetӡ������
		/// </summary>
		public string AppType
		{
			set{ _apptype=value;}
			get{return _apptype;}
		}
		/// <summary>
		/// ��;����
		/// </summary>
		public string Overviews
		{
			set{ _overviews=value;}
			get{return _overviews;}
		}
		/// <summary>
		/// �ύ�����ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// �ύ������û���ID
		/// </summary>
		public string SendUserID
		{
			set{ _senduserid=value;}
			get{return _senduserid;}
		}
		/// <summary>
		/// ����Ĳ���
		/// </summary>
		public string DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// ��˵�ʱ��
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// ��˵��û�ID
		/// </summary>
		public string DoUserID
		{
			set{ _douserid=value;}
			get{return _douserid;}
		}
		/// <summary>
		/// ������ע
		/// </summary>
		public string CheckNote
		{
			set{ _checknote=value;}
			get{return _checknote;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string TelNum
		{
			set{ _telnum=value;}
			get{return _telnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DoNote
		{
			set{ _donote=value;}
			get{return _donote;}
		}
		/// <summary>
		/// �ϴ�����Ŀ����
		/// </summary>
		public string Attachments
		{
			set{ _attachments=value;}
			get{return _attachments;}
		}
		/// <summary>
		/// �����˵�ID
		/// </summary>
		public string ApplyUserID
		{
			set{ _applyuserid=value;}
			get{return _applyuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEMP1
		{
			set{ _temp1=value;}
			get{return _temp1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEMP2
		{
			set{ _temp2=value;}
			get{return _temp2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEMP3
		{
			set{ _temp3=value;}
			get{return _temp3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEMP4
		{
			set{ _temp4=value;}
			get{return _temp4;}
		}
		#endregion Model

	}
}

