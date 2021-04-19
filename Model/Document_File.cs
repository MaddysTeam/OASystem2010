using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Document_File 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Document_File
	{
		public Document_File()
		{}
		#region Model
		private int _id;
		private int? _folderid;
		private string _filename;
		private string _filetype;
		private string _icon;
		private decimal? _sizeof;
		private string _filepath;
		private int? _isshare;
		private int? _delflag;
		private DateTime? _datetime;
		private string _userid;
		private int? _shareid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 文件夹的ID
		/// </summary>
		public int? FolderID
		{
			set{ _folderid=value;}
			get{return _folderid;}
		}
		/// <summary>
		/// 文件的名称
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 文件的类型，取文件的后缀名，没有.号
		/// </summary>
		public string FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// 文件的图标名称，命名和文件的FileType保持一致
		/// </summary>
		public string Icon
		{
			set{ _icon=value;}
			get{return _icon;}
		}
		/// <summary>
		/// 文件的大小，以KB为单位
		/// </summary>
		public decimal? Sizeof
		{
			set{ _sizeof=value;}
			get{return _sizeof;}
		}
		/// <summary>
		/// 文件的存储地址
		/// </summary>
		public string FilePath
		{
			set{ _filepath=value;}
			get{return _filepath;}
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
		/// 创建该文件的用户ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 如果是从他人共享的资源中收藏回来的资源，则保留原资源的ID
		/// </summary>
		public int? ShareID
		{
			set{ _shareid=value;}
			get{return _shareid;}
		}
		#endregion Model

	}
}

