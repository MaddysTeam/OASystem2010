using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Document_Folder 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Document_Folder
	{
		public Document_Folder()
		{}
		#region Model
		private int _id;
		private string _foldername;
		private int? _upid;
		private string _types;
		private string _userid;
		private int? _projectid;
		private int? _isshare;
		private int? _delflag;
		private DateTime? _datetime;
		private string _columnspath;
		private int? _shunxu;
		private string _imageurl;
		private string _pnames;
		private string _sizeof;
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
		public string FolderName
		{
			set{ _foldername=value;}
			get{return _foldername;}
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
		/// 文件夹的属性：public是项目的文件夹；private是个人的文件夹
		/// </summary>
		public string Types
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// 私有文件夹的所属人ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 公有文件夹的项目ID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// 是否共享，默认0，不共享；1表示共享
		/// </summary>
		public int? IsShare
		{
			set{ _isshare=value;}
			get{return _isshare;}
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
		/// 当前文件夹中文件的大小
		/// </summary>
		public string SizeOf
		{
			set{ _sizeof=value;}
			get{return _sizeof;}
		}
		#endregion Model

	}
}

