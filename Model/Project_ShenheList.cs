using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Project_ShenheList 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Project_ShenheList
	{
		public Project_ShenheList()
		{}
		#region Model
		private int _id;
		private int? _projectid;
		private string _userid;
		private int? _status;
		private int? _isturn;
		private string _infors;
		/// <summary>
		/// 项目审核的标记位
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 待审核项目的ID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// 审核的用户的ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 当前这个用户的审核结果：0表示待审核、1表示审核通过、2表示审核不通过，3暂停
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 是否到当前的用户审核。0表示未到；1表示到；2表示已经审核过
		/// </summary>
		public int? Isturn
		{
			set{ _isturn=value;}
			get{return _isturn;}
		}
		/// <summary>
		/// 审核的意见信息
		/// </summary>
		public string Infors
		{
			set{ _infors=value;}
			get{return _infors;}
		}
		#endregion Model

	}
}

