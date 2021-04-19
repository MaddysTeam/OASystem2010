using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Document_File_Share ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �ļ���ID
		/// </summary>
		public int? FileID
		{
			set{ _fileid=value;}
			get{return _fileid;}
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

