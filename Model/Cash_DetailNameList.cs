using System;
namespace Dianda.Model
{
	/// <summary>
	/// Cash_DetailNameList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cash_DetailNameList
	{
		public Cash_DetailNameList()
		{}
		#region Model
		private int _id;
		private string _detailname;
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
		/// 
		/// </summary>
		public string DetailName
		{
			set{ _detailname=value;}
			get{return _detailname;}
		}
		/// <summary>
		/// 排列的顺序号
		/// </summary>
		public int? OrderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		#endregion Model

	}
}

