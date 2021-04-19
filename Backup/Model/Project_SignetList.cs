using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_SignetList 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_SignetList
	{
		public Project_SignetList()
		{}
		#region Model
		private int _id;
		private string _signetname;
		private string _signetnum;
		private string _infors;
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
		/// 印章的名称
		/// </summary>
		public string SignetName
		{
			set{ _signetname=value;}
			get{return _signetname;}
		}
		/// <summary>
		/// 印章的编号
		/// </summary>
		public string SignetNum
		{
			set{ _signetnum=value;}
			get{return _signetnum;}
		}
		/// <summary>
		/// 印章的简介
		/// </summary>
		public string Infors
		{
			set{ _infors=value;}
			get{return _infors;}
		}
		/// <summary>
		/// 0表示正常，1表示删除
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

