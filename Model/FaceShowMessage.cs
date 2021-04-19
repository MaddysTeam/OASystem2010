using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类FaceShowMessage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class FaceShowMessage
	{
		public FaceShowMessage()
		{}
		#region Model
		private int _id;
		private string _urls;
		private string _newstype;
		private DateTime? _datetime;
		private DateTime? _readtime;
		private int? _isread;
		private string _receive;
		private string _fromtable;
		private string _newsid;
		private int? _projectid;
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
		/// [信息类别]+信息的链接地址+信息的标题
		/// </summary>
		public string URLS
		{
			set{ _urls=value;}
			get{return _urls;}
		}
		/// <summary>
		/// 信息的类型[项目任务、文档、申请情况、批准提醒、通知公告、站内信息、经费、部门信息]
		/// </summary>
		public string NewsType
		{
			set{ _newstype=value;}
			get{return _newstype;}
		}
		/// <summary>
		/// 信息发布的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 信息被阅读的时间
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// 信息是否被阅读，0表示未读，1表示已读
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// 信息的接收者
		/// </summary>
		public string Receive
		{
			set{ _receive=value;}
			get{return _receive;}
		}
		/// <summary>
		/// 信息是从哪里过来的[站内消息、部门信息、项目信息为：News_News;]
		/// </summary>
		public string FromTable
		{
			set{ _fromtable=value;}
			get{return _fromtable;}
		}
		/// <summary>
		/// 信息在源表中的ID值
		/// </summary>
		public string NewsID
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 项目的ID，如果不属于项目，则留空
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// 删除标记：0表示正常，1表示删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

