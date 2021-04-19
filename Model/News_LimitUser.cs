using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����News_LimitUser ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class News_LimitUser
	{
		public News_LimitUser()
		{}
		#region Model
		private int _id;
		private string _userid;
		private int? _newsid;
		private int? _isread;
		private DateTime? _readtime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �û���ID��һ���ǿ����Ķ�����Ϣ���û���ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ��Ϣ��ID��
		/// </summary>
		public int? NewsID
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 0��ʾδ����1��ʾ�Ѷ�
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// ��¼��һ���Ķ���ʱ��
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		#endregion Model

	}
}

