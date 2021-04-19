using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_Columns 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_Columns
	{
		public Project_Columns()
		{}
		#region Model
		private int _id;
		private string _names;
		private int? _upid;
		private string _userid;
		private string _userinfos;
		private int? _delflag;
		private DateTime? _datetime;
		private string _columnspath;
		private int? _shunxu;
		private string _imageurl;
		private string _pnames;
		private string _types;
		private string _infors;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 栏目的名称
		/// </summary>
		public string Names
		{
			set{ _names=value;}
			get{return _names;}
		}
		/// <summary>
		/// 上级栏目的ID
		/// </summary>
		public int? UpID
		{
			set{ _upid=value;}
			get{return _upid;}
		}
		/// <summary>
		/// 管理这个分类的用户的ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户的真实姓名信息
		/// </summary>
		public string UserInfos
		{
			set{ _userinfos=value;}
			get{return _userinfos;}
		}
		/// <summary>
		/// 0表示没有删除，1表示被删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 创建的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 栏目的路径记录（用/来隔开）
		/// </summary>
		public string COLUMNSPATH
		{
			set{ _columnspath=value;}
			get{return _columnspath;}
		}
		/// <summary>
		/// 栏目显示的顺序
		/// </summary>
		public int? SHUNXU
		{
			set{ _shunxu=value;}
			get{return _shunxu;}
		}
		/// <summary>
		/// 栏目的图片
		/// </summary>
		public string IMAGEURL
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 栏目的路径名称：A>B>C
		/// </summary>
		public string PNAMES
		{
			set{ _pnames=value;}
			get{return _pnames;}
		}
		/// <summary>
		/// 分类的类型：用汉字：分类、总项目
		/// </summary>
		public string TYPES
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// 分类的描述内容
		/// </summary>
		public string INFORS
		{
			set{ _infors=value;}
			get{return _infors;}
		}
		#endregion Model

	}
}

