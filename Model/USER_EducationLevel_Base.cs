using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类USER_EducationLevel_Base 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class USER_EducationLevel_Base
	{
		public USER_EducationLevel_Base()
		{}
		#region Model
		private int _id;
		private string _educationlevel;
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
		/// 学历表
		/// </summary>
		public string EducationLevel
		{
			set{ _educationlevel=value;}
			get{return _educationlevel;}
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

