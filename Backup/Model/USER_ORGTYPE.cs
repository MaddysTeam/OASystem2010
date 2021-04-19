using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类USER_ORGTYPE 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class USER_ORGTYPE
	{
		public USER_ORGTYPE()
		{}
		#region Model
		private int _id;
		private string _types;
		private string _names;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TYPES
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// 组织机构类型的说明
		/// </summary>
		public string NAMES
		{
			set{ _names=value;}
			get{return _names;}
		}
		#endregion Model

	}
}

