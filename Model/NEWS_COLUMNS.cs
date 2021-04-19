using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类News_Columns 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class News_Columns
	{
		public News_Columns()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _parentid;
		private string _foritems;
		private string _itemsid;
		private DateTime? _datetime;
		private int? _ismenu;
		private int? _isshenhe;
		private int? _onlyone;
		private int? _delflag;
		private string _columnspath;
		private int? _shunxu;
		private string _imageurl;
		private string _pnames;
		/// <summary>
		/// GUID主键，标识
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 栏目名称
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 父栏目的ID，GUID
		/// </summary>
		public int? PARENTID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 栏目的归属（NEWS表示新闻，PROJECT表示项目新闻，DEPARTMENT表示部门新闻）
		/// </summary>
		public string ForItems
		{
			set{ _foritems=value;}
			get{return _foritems;}
		}
		/// <summary>
		/// 如果栏目是部门的栏目，则这边保存部门的ID
		/// </summary>
		public string ItemsID
		{
			set{ _itemsid=value;}
			get{return _itemsid;}
		}
		/// <summary>
		/// 建立时间（默认日期getdate()排序依据）
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 是否显示发布人的信息
		/// </summary>
		public int? ISMENU
		{
			set{ _ismenu=value;}
			get{return _ismenu;}
		}
		/// <summary>
		/// 是否需要审核
		/// </summary>
		public int? ISSHENHE
		{
			set{ _isshenhe=value;}
			get{return _isshenhe;}
		}
		/// <summary>
		/// 单条新闻（默认值为0；1表示单条新闻）
		/// </summary>
		public int? ONLYONE
		{
			set{ _onlyone=value;}
			get{return _onlyone;}
		}
		/// <summary>
		/// 新闻删除标记(0表示没有删除，1表示被删除)
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 栏目的路径记录
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
		#endregion Model

	}
}

