using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Document_Folder_Share ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��Ŀ�ļ��е�ID
		/// </summary>
		public int? FolderID
		{
			set{ _folderid=value;}
			get{return _folderid;}
		}
		/// <summary>
		/// ���չ�����û�ID
		/// </summary>
		public string ShareForUser
		{
			set{ _shareforuser=value;}
			get{return _shareforuser;}
		}
		/// <summary>
		/// ������ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

