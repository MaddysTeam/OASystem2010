using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Document_File_Share 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Document_File_Share
	{
		public Document_File_Share()
		{}
		#region Model
		private int _id;
		private int? _fileid;
		private string _shareforuser;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 文件的ID
		/// </summary>
		public int? FileID
		{
			set{ _fileid=value;}
			get{return _fileid;}
		}
		/// <summary>
		/// 接收共享的用户ID
		/// </summary>
		public string ShareForUser
		{
			set{ _shareforuser=value;}
			get{return _shareforuser;}
		}
		/// <summary>
		/// 创建的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

