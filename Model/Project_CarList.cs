using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_CarList 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_CarList
	{
		public Project_CarList()
		{}
		#region Model
		private int _id;
		private string _carname;
		private string _drivername;
		private string _carnum;
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
		/// 车辆的名称
		/// </summary>
		public string CarName
		{
			set{ _carname=value;}
			get{return _carname;}
		}
		/// <summary>
		/// 司机的名称
		/// </summary>
		public string DriverName
		{
			set{ _drivername=value;}
			get{return _drivername;}
		}
		/// <summary>
		/// 车牌
		/// </summary>
		public string CarNum
		{
			set{ _carnum=value;}
			get{return _carnum;}
		}
		/// <summary>
		/// 车辆的简介
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

