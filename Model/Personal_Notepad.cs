using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Personal_Notepad 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Personal_Notepad
	{
		public Personal_Notepad()
		{}
		#region Model
		private int _id;
		private string _names;
		private int? _delflag;
		private DateTime? _datetime;
		private string _userid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 便签的标题
		/// </summary>
		public string NAMES
		{
			set{ _names=value;}
			get{return _names;}
		}
		/// <summary>
		/// 0表示正常，1表示删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 创建的用户ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

