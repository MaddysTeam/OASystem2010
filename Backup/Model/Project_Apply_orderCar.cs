using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_Apply_orderCar 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_Apply_orderCar
	{
		public Project_Apply_orderCar()
		{}
		#region Model
		private int _id;
		private int? _applyid;
		private int? _carid;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private int? _peoplenum;
		private string _fromaddress;
		private string _toaddress;
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
		/// 车辆的ID
		/// </summary>
		public int? CarID
		{
			set{ _carid=value;}
			get{return _carid;}
		}
		/// <summary>
		/// 用车的开始时间
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 用车的结束时间
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 乘车的人数
		/// </summary>
		public int? PeopleNum
		{
			set{ _peoplenum=value;}
			get{return _peoplenum;}
		}
		/// <summary>
		/// 始发地
		/// </summary>
		public string FromAddress
		{
			set{ _fromaddress=value;}
			get{return _fromaddress;}
		}
		/// <summary>
		/// 目的地
		/// </summary>
		public string ToAddress
		{
			set{ _toaddress=value;}
			get{return _toaddress;}
		}
		#endregion Model

	}
}

