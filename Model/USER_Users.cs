using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����USER_Users ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class USER_Users
	{
		public USER_Users()
		{}
		#region Model
		private string _id;
		private string _username;
		private string _password;
		private string _realname;
		private string _sex;
		private string _departmentid;
		private string _stationid;
		private string _tel;
		private string _email;
		private int? _holidays;
		private string _workstats;
		private DateTime? _datesemployed;
		private DateTime? _leavedates;
		private string _birthday;
		private string _nativeplace;
		private string _educationlevel;
		private string _address;
		private string _graduateschool;
		private string _major;
		private string _trackrecord;
		private DateTime? _datetime;
		private string _groups;
		private int? _delflag;
		private string _images;
		private int? _ismanager;
		private string _temp1;
		private string _temp2;
		private string _temp3;
		private string _temp4;
		private string _departmentname;
		/// <summary>
		/// ��ʶ GUID ����
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �û���
		/// </summary>
		public string USERNAME
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// �û�����ļ���ֵ��MD5/11��
		/// </summary>
		public string PASSWORD
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// ��ʵ����
		/// </summary>
		public string REALNAME
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// �Ա�
		/// </summary>
		public string SEX
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// �û�����������ID����USER_Groups�е�ID���Ӧ)��ϴ�
		/// </summary>
		public string DepartMentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// �û��ĸ�λID����USER_Groups�е�ID���Ӧ
		/// </summary>
		public string StationID
		{
			set{ _stationid=value;}
			get{return _stationid;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string TEL
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// �ʼ�
		/// </summary>
		public string EMAIL
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// ���������
		/// </summary>
		public int? Holidays
		{
			set{ _holidays=value;}
			get{return _holidays;}
		}
		/// <summary>
		/// ������״̬����ְ����ְ��ְͣ����н�ݼ١�������
		/// </summary>
		public string WorkStats
		{
			set{ _workstats=value;}
			get{return _workstats;}
		}
		/// <summary>
		/// ��ְʱ��
		/// </summary>
		public DateTime? DatesEmployed
		{
			set{ _datesemployed=value;}
			get{return _datesemployed;}
		}
		/// <summary>
		/// ��ְʱ��
		/// </summary>
		public DateTime? LeaveDates
		{
			set{ _leavedates=value;}
			get{return _leavedates;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string BIRTHDAY
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string NativePlace
		{
			set{ _nativeplace=value;}
			get{return _nativeplace;}
		}
		/// <summary>
		/// ѧ��
		/// </summary>
		public string EducationLevel
		{
			set{ _educationlevel=value;}
			get{return _educationlevel;}
		}
		/// <summary>
		/// סַ
		/// </summary>
		public string ADDRESS
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// ��ҵѧУ
		/// </summary>
		public string GraduateSchool
		{
			set{ _graduateschool=value;}
			get{return _graduateschool;}
		}
		/// <summary>
		/// ��ѧרҵ
		/// </summary>
		public string Major
		{
			set{ _major=value;}
			get{return _major;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string TrackRecord
		{
			set{ _trackrecord=value;}
			get{return _trackrecord;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// �û�������Ȩ��ֵ�ļ���
		/// </summary>
		public string GROUPS
		{
			set{ _groups=value;}
			get{return _groups;}
		}
		/// <summary>
		/// ɾ����� Ĭ��Ϊ0��1��ʾ��ɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// �û���ͷ��
		/// </summary>
		public string IMAGES
		{
			set{ _images=value;}
			get{return _images;}
		}
		/// <summary>
		/// �Ƿ�����Ŀ����:0-���ǣ�1-�ǡ�Ĭ����0
		/// </summary>
		public int? IsManager
		{
			set{ _ismanager=value;}
			get{return _ismanager;}
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
		/// <summary>
		/// �û������Ķ�����ŵ����ƴ�ֵ�����²�����Ŀ�������񲿣�
		/// </summary>
		public string DepartMentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		#endregion Model

	}
}

