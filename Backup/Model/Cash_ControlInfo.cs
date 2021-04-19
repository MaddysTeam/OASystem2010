using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Cash_ControlInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Cash_ControlInfo
	{
		public Cash_ControlInfo()
		{}
		#region Model
		private int _id;
		private string _infors;
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
		/// 资金卡操作的说明文字
		/// </summary>
		public string INFORS
		{
			set{ _infors=value;}
			get{return _infors;}
		}
		/// <summary>
		/// 顺序号
		/// </summary>
		public int? NUMS
		{
			set{ _nums=value;}
			get{return _nums;}
		}
		#endregion Model

	}
}

