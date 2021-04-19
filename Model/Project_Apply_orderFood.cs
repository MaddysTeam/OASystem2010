using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_Apply_orderFood 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_Apply_orderFood
	{
		public Project_Apply_orderFood()
		{}
		#region Model
		private int _id;
		private int? _applyid;
		private DateTime? _userdatetime;
		private int? _ordernum;
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
		/// 用饭的日期时间
		/// </summary>
		public DateTime? UserDatetime
		{
			set{ _userdatetime=value;}
			get{return _userdatetime;}
		}
		/// <summary>
		/// 预定的份数
		/// </summary>
		public int? OrderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		#endregion Model

	}
}

