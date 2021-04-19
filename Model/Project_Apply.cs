using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_Apply 。(属性说明自动提取数据库字段的描述信息)
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
		/// 项目的ID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
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
		/// 申请的状态：0表示待审核；1表示审核通过，2表示审核不通过
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 业务的类型：orderFood订饭请求、orderCar订车、orderRoom订会议室、orderSignet印章申请
		/// </summary>
		public string AppType
		{
			set{ _apptype=value;}
			get{return _apptype;}
		}
		/// <summary>
		/// 用途描述
		/// </summary>
		public string Overviews
		{
			set{ _overviews=value;}
			get{return _overviews;}
		}
		/// <summary>
		/// 提交申请的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 提交申请的用户的ID
		/// </summary>
		public string SendUserID
		{
			set{ _senduserid=value;}
			get{return _senduserid;}
		}
		/// <summary>
		/// 申请的部门
		/// </summary>
		public string DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 审核的时间
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// 审核的用户ID
		/// </summary>
		public string DoUserID
		{
			set{ _douserid=value;}
			get{return _douserid;}
		}
		/// <summary>
		/// 审批备注
		/// </summary>
		public string CheckNote
		{
			set{ _checknote=value;}
			get{return _checknote;}
		}
		/// <summary>
		/// 联系电话
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
		/// 上传的项目附件
		/// </summary>
		public string Attachments
		{
			set{ _attachments=value;}
			get{return _attachments;}
		}
		/// <summary>
		/// 申请人的ID
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

