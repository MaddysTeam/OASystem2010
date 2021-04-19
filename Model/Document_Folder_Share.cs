using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Document_Folder_Share 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Document_Folder_Share
	{
		public Document_Folder_Share()
		{}
		#region Model
		private int _id;
		private int? _folderid;
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
		/// 栏目文件夹的ID
		/// </summary>
		public int? FolderID
		{
			set{ _folderid=value;}
			get{return _folderid;}
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

