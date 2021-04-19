using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类USER_ORGAN 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class USER_ORGAN
	{
		public USER_ORGAN()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _pid;
		private int? _ismain;
		private int? _delflag;
		private string _path;
		private string _types;
		private string _infor;
		private string _infor2;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 组织机构名称
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 是否是总部，并且只能有一个总部（默认为0，1为是总部）
		/// </summary>
		public int? ISMAIN
		{
			set{ _ismain=value;}
			get{return _ismain;}
		}
		/// <summary>
		/// 是否被删除（默认0，1表示删除）
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PATH
		{
			set{ _path=value;}
			get{return _path;}
		}
		/// <summary>
		/// 组织的类型：和USER_ORGTYPE对应
		/// </summary>
		public string TYPES
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// 组织机构的说明
		/// </summary>
		public string INFOR
		{
			set{ _infor=value;}
			get{return _infor;}
		}
		/// <summary>
		/// 放一些广告什么的
		/// </summary>
		public string INFOR2
		{
			set{ _infor2=value;}
			get{return _infor2;}
		}
		#endregion Model

	}
}

