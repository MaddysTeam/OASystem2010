using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类USER_WorkStats_Base 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class USER_WorkStats_Base
	{
		public USER_WorkStats_Base()
		{}
		#region Model
		private int _id;
		private string _workstataname;
		private int? _delflag;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 工作状态的名称
		/// </summary>
		public string WorkStataName
		{
			set{ _workstataname=value;}
			get{return _workstataname;}
		}
		/// <summary>
		/// 删除的标记（0正常，1表示删除）
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

