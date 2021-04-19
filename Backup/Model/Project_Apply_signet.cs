using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_Apply_signet 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_Apply_signet
	{
		public Project_Apply_signet()
		{}
		#region Model
		private int _id;
		private int? _applyid;
		private int? _signetid;
		private int? _nums;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Project_Apply中申请的ID
		/// </summary>
		public int? ApplyID
		{
			set{ _applyid=value;}
			get{return _applyid;}
		}
		/// <summary>
		/// 印章的ID
		/// </summary>
		public int? SignetID
		{
			set{ _signetid=value;}
			get{return _signetid;}
		}
		/// <summary>
		/// 用章的数量
		/// </summary>
		public int? Nums
		{
			set{ _nums=value;}
			get{return _nums;}
		}
		#endregion Model

	}
}

