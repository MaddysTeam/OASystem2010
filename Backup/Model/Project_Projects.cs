using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_Projects 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_Projects
	{
		public Project_Projects()
		{}
		#region Model
		private int _id;
		private string _names;
		private int? _delflag;
		private int? _status;
		private string _leaderid;
		private string _departmentid;
		private string _departmentnames;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private decimal? _cashtotal;
		private int? _cashcardid;
		private string _overviews;
		private string _attachments;
		private DateTime? _datetime;
		private string _senduserid;
		private string _douserid;
		private DateTime? _readtime;
		private string _donote;
		private int? _columnsid;
		private string _cashdw;
		private int? _projecttype;
		private string _budgetlist;
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
		/// 项目的名称
		/// </summary>
		public string NAMES
		{
			set{ _names=value;}
			get{return _names;}
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
		/// 项目的状态 1表示正常运行中,0表示待审核，2表示审核不通过，3暂停，4表示草稿箱中，5表示完成
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 项目负责人的ID
		/// </summary>
		public string LeaderID
		{
			set{ _leaderid=value;}
			get{return _leaderid;}
		}
		/// <summary>
		/// 参与的部门的组合串值，用逗号隔开
		/// </summary>
		public string DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 根据所选择的部门，构造部门的名称列表，以逗号隔开“人事部，财务部“
		/// </summary>
		public string DepartmentNames
		{
			set{ _departmentnames=value;}
			get{return _departmentnames;}
		}
		/// <summary>
		/// 项目预计开始时间
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 项目预计结束时间
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 项目的预计经费
		/// </summary>
		public decimal? CashTotal
		{
			set{ _cashtotal=value;}
			get{return _cashtotal;}
		}
		/// <summary>
		/// 资金卡的ID（如果为0，表示暂时没有设置资金卡）
		/// </summary>
		public int? CashCardID
		{
			set{ _cashcardid=value;}
			get{return _cashcardid;}
		}
		/// <summary>
		/// 项目概要
		/// </summary>
		public string Overviews
		{
			set{ _overviews=value;}
			get{return _overviews;}
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
		/// 项目填写的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 填写这个申请的用户的ID
		/// </summary>
		public string SendUserID
		{
			set{ _senduserid=value;}
			get{return _senduserid;}
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
		/// 审核的时间
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// 审核人员设置的审核意见
		/// </summary>
		public string DoNote
		{
			set{ _donote=value;}
			get{return _donote;}
		}
		/// <summary>
		/// 项目的所在分类,Project_Columns中的ID
		/// </summary>
		public int? ColumnsID
		{
			set{ _columnsid=value;}
			get{return _columnsid;}
		}
		/// <summary>
		/// 预计金额的单位（万元、元）
		/// </summary>
		public string CashDw
		{
			set{ _cashdw=value;}
			get{return _cashdw;}
		}
		/// <summary>
		/// 项目的类型：0表示个人/临时项目，1表示正常的项目
		/// </summary>
		public int? ProjectType
		{
			set{ _projecttype=value;}
			get{return _projecttype;}
		}
		/// <summary>
		/// 上传预算表单的路径地址
		/// </summary>
		public string BudgetList
		{
			set{ _budgetlist=value;}
			get{return _budgetlist;}
		}
		/// <summary>
		/// 预留字段1
		/// </summary>
		public string TEMP1
		{
			set{ _temp1=value;}
			get{return _temp1;}
		}
		/// <summary>
		/// 预留字段2
		/// </summary>
		public string TEMP2
		{
			set{ _temp2=value;}
			get{return _temp2;}
		}
		/// <summary>
		/// 预留字段3
		/// </summary>
		public string TEMP3
		{
			set{ _temp3=value;}
			get{return _temp3;}
		}
		/// <summary>
		/// 预留字段4
		/// </summary>
		public string TEMP4
		{
			set{ _temp4=value;}
			get{return _temp4;}
		}
		#endregion Model

	}
}

