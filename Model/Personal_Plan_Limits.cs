using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Personal_Plan_Limits 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Personal_Plan_Limits
	{
		public Personal_Plan_Limits()
		{}
		#region Model
		private int _id;
		private string _userid;
		private string _applyuserid;
		private int? _isall;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户的ID
		/// </summary>
		public string USERID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 允许查看我的个人计划的用户列表，用,号隔开
		/// </summary>
		public string APPLYUSERID
		{
			set{ _applyuserid=value;}
			get{return _applyuserid;}
		}
		/// <summary>
		/// 是否不做限定。1--表示所有人都能查看；0表示只有APPLYUSERID中的人才能看到
		/// </summary>
		public int? ISALL
		{
			set{ _isall=value;}
			get{return _isall;}
		}
		#endregion Model

	}
}

