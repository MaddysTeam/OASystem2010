using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类USER_Groups 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class USER_Groups
	{
		public USER_Groups()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _contents;
		private string _role;
		private int? _delflag;
		private int? _ismoren;
		private string _tags;
		/// <summary>
		/// 标识 GUID 主键
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 组名称
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 描述内容
		/// </summary>
		public string CONTENTS
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 权限
		/// </summary>
		public string ROLE
		{
			set{ _role=value;}
			get{return _role;}
		}
		/// <summary>
		/// 删除标记 默认为0，1表示已删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 是否为默认的用户组
		/// </summary>
		public int? ISMOREN
		{
			set{ _ismoren=value;}
			get{return _ismoren;}
		}
		/// <summary>
		/// 标签名称【例如：岗位、部门、普通组..】
		/// </summary>
		public string TAGS
		{
			set{ _tags=value;}
			get{return _tags;}
		}
		#endregion Model

	}
}

