using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类USER_Users 。(属性说明自动提取数据库字段的描述信息)
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
		/// 标识 GUID 主键
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string USERNAME
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 用户密码的加密值（MD5/11）
		/// </summary>
		public string PASSWORD
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string REALNAME
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string SEX
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 用户的所属部门ID（和USER_Groups中的ID想对应)组合串
		/// </summary>
		public string DepartMentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 用户的岗位ID，和USER_Groups中的ID相对应
		/// </summary>
		public string StationID
		{
			set{ _stationid=value;}
			get{return _stationid;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string TEL
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 邮件
		/// </summary>
		public string EMAIL
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 可修年假数
		/// </summary>
		public int? Holidays
		{
			set{ _holidays=value;}
			get{return _holidays;}
		}
		/// <summary>
		/// 工作的状态（在职、离职、停职、带薪休假、其他）
		/// </summary>
		public string WorkStats
		{
			set{ _workstats=value;}
			get{return _workstats;}
		}
		/// <summary>
		/// 入职时间
		/// </summary>
		public DateTime? DatesEmployed
		{
			set{ _datesemployed=value;}
			get{return _datesemployed;}
		}
		/// <summary>
		/// 离职时间
		/// </summary>
		public DateTime? LeaveDates
		{
			set{ _leavedates=value;}
			get{return _leavedates;}
		}
		/// <summary>
		/// 出生年月
		/// </summary>
		public string BIRTHDAY
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 籍贯
		/// </summary>
		public string NativePlace
		{
			set{ _nativeplace=value;}
			get{return _nativeplace;}
		}
		/// <summary>
		/// 学历
		/// </summary>
		public string EducationLevel
		{
			set{ _educationlevel=value;}
			get{return _educationlevel;}
		}
		/// <summary>
		/// 住址
		/// </summary>
		public string ADDRESS
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 毕业学校
		/// </summary>
		public string GraduateSchool
		{
			set{ _graduateschool=value;}
			get{return _graduateschool;}
		}
		/// <summary>
		/// 所学专业
		/// </summary>
		public string Major
		{
			set{ _major=value;}
			get{return _major;}
		}
		/// <summary>
		/// 工作履历
		/// </summary>
		public string TrackRecord
		{
			set{ _trackrecord=value;}
			get{return _trackrecord;}
		}
		/// <summary>
		/// 加入时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 用户的其他权限值的集合
		/// </summary>
		public string GROUPS
		{
			set{ _groups=value;}
			get{return _groups;}
		}
		/// <summary>
		/// 删除标记 默认为0，1表示已删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 用户的头像
		/// </summary>
		public string IMAGES
		{
			set{ _images=value;}
			get{return _images;}
		}
		/// <summary>
		/// 是否是项目经理:0-不是；1-是。默认是0
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
		/// 用户所属的多个部门的名称串值（人事部、项目部、财务部）
		/// </summary>
		public string DepartMentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		#endregion Model

	}
}

