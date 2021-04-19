using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类News_News 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class News_News
	{
		public News_News()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _parentid;
		private DateTime? _datetime;
		private string _contents;
		private int? _type;
		private string _keyword;
		private string _writer;
		private string _source;
		private string _minipic;
		private string _fileup;
		private int? _uptop;
		private int? _delflag;
		private int? _ispass;
		private int? _islimits;
		private int? _limitschoose;
		/// <summary>
		/// 标识GUID 主键
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 所属栏目ID GUID
		/// </summary>
		public int? PARENTID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 发布日期默认日期GETDATE() 排序依据
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 信息内容
		/// </summary>
		public string CONTENTS
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 信息类型（1为图文内容；2为URL链接；3为上传文件）
		/// </summary>
		public int? TYPE
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 关键字
		/// </summary>
		public string KEYWORD
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 发布者；使用用户名
		/// </summary>
		public string WRITER
		{
			set{ _writer=value;}
			get{return _writer;}
		}
		/// <summary>
		/// 信息来源
		/// </summary>
		public string SOURCE
		{
			set{ _source=value;}
			get{return _source;}
		}
		/// <summary>
		/// 缩略图
		/// </summary>
		public string MINIPIC
		{
			set{ _minipic=value;}
			get{return _minipic;}
		}
		/// <summary>
		/// 上传附件
		/// </summary>
		public string FILEUP
		{
			set{ _fileup=value;}
			get{return _fileup;}
		}
		/// <summary>
		/// 置顶（默认值为0，1为置顶）
		/// </summary>
		public int? UPTOP
		{
			set{ _uptop=value;}
			get{return _uptop;}
		}
		/// <summary>
		/// 默认值为0，1为已经删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 是否通过审核（默认0，1表示通过审核,2表示审核不通过）添加新闻时，需要根据选择栏目的审核设定进行赋值
		/// </summary>
		public int? ISPASS
		{
			set{ _ispass=value;}
			get{return _ispass;}
		}
		/// <summary>
		/// 阅读的范围，0表示不约束，全部人都可以看到；1表示约束，要看News_LimitUser表中是否有该用户
		/// </summary>
		public int? IsLimits
		{
			set{ _islimits=value;}
			get{return _islimits;}
		}
		/// <summary>
		/// 1-本部门成员、2-全员、3-项目组成员
		/// </summary>
		public int? LimitsChoose
		{
			set{ _limitschoose=value;}
			get{return _limitschoose;}
		}
		#endregion Model

	}
}

