using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Personal_Plan 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Personal_Plan
	{
		public Personal_Plan()
		{}
		#region Model
		private int _id;
		private string _names;
		private int? _delflag;
		private int? _status;
		private string _overviews;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private DateTime? _datetime;
		private string _userid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 个人计划的标题
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
		/// 计划的状态：0表示未开始；1表示进行中；2表示完成；3表示延期
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 计划的描述
		/// </summary>
		public string Overviews
		{
			set{ _overviews=value;}
			get{return _overviews;}
		}
		/// <summary>
		/// 计划的开始时间
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 计划的结束时间
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 计划的发布时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 创建的用户ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

