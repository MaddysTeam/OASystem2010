using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类DOC_transport_From 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class DOC_transport_From
	{
		public DOC_transport_From()
		{}
		#region Model
		private string _id;
		private string _fromuser;
		private string _touser;
		private string _titles;
		private string _filepath;
		private DateTime? _datetime;
		private int? _delflag;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 发件人的用户名
		/// </summary>
		public string FROMUSER
		{
			set{ _fromuser=value;}
			get{return _fromuser;}
		}
		/// <summary>
		/// 收件人的用户名字符串列表
		/// </summary>
		public string TOUSER
		{
			set{ _touser=value;}
			get{return _touser;}
		}
		/// <summary>
		/// 邮件的标记内容
		/// </summary>
		public string TITLES
		{
			set{ _titles=value;}
			get{return _titles;}
		}
		/// <summary>
		/// 邮件的附件部分
		/// </summary>
		public string FILEPATH
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// 发邮件的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 是否被删除了，此处的删除不影响已经收到邮件的用户查看邮件
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

