using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类GUESTBOOK_MAIN 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class GUESTBOOK_MAIN
	{
		public GUESTBOOK_MAIN()
		{}
		#region Model
		private string _id;
		private string _titles;
		private string _classid;
		private string _contents;
		private string _re_contents;
		private int? _status;
		private string _writer;
		private DateTime? _datetime;
		private DateTime? _re_datetime;
		private int? _delflag;
		private string _courseid;
		/// <summary>
		/// 标识 GUID 主键
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TITLES
		{
			set{ _titles=value;}
			get{return _titles;}
		}
		/// <summary>
		/// 班级ID(由单位代码DWDM+年级NJ+招生季节ZSJJ+专业代码ZYDM组成)保存中文班级名称
		/// </summary>
		public string CLASSID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 留言内容
		/// </summary>
		public string CONTENTS
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 回复内容
		/// </summary>
		public string RE_CONTENTS
		{
			set{ _re_contents=value;}
			get{return _re_contents;}
		}
		/// <summary>
		/// 审核状态 默认为0 ，1为审核通过
		/// </summary>
		public int? STATUS
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 发表人的真实姓名+用户名
		/// </summary>
		public string WRITER
		{
			set{ _writer=value;}
			get{return _writer;}
		}
		/// <summary>
		/// 发表日期
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 回复的时间
		/// </summary>
		public DateTime? RE_DATETIME
		{
			set{ _re_datetime=value;}
			get{return _re_datetime;}
		}
		/// <summary>
		/// 删除标记 默认为0 ，1为已删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 系统内课程的ID
		/// </summary>
		public string COURSEID
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		#endregion Model

	}
}

