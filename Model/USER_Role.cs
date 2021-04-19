using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类USER_Role 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class USER_Role
	{
		public USER_Role()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _roles;
		private string _types;
		private int? _upid;
		private int? _delflag;
		/// <summary>
		/// 标识 GUID 主键
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 权限名称
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 权限所指的路径或者控件的名称
		/// </summary>
		public string Roles
		{
			set{ _roles=value;}
			get{return _roles;}
		}
		/// <summary>
		/// 权限的类型中文字（页面权限、按钮权限、菜单权限）
		/// </summary>
		public string Types
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// 当前权限的上级节点，如果没有上级则留空
		/// </summary>
		public int? UpID
		{
			set{ _upid=value;}
			get{return _upid;}
		}
		/// <summary>
		/// 删除标记 默认为0，1表示已删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

