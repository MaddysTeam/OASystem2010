using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����NEWS_USERID_COLUMNSID ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class NEWS_USERID_COLUMNSID
	{
		public NEWS_USERID_COLUMNSID()
		{}
		#region Model
		private string _id;
		private string _userid;
		private string _columnsid;
		private int? _isshenhe;
		private int? _isadd;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �û���ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ������Ŀ��ID
		/// </summary>
		public string ColumnsID
		{
			set{ _columnsid=value;}
			get{return _columnsid;}
		}
		/// <summary>
		/// �����Ϣ��Ȩ��,0��ʾû��,1��ʾ��
		/// </summary>
		public int? ISShenHe
		{
			set{ _isshenhe=value;}
			get{return _isshenhe;}
		}
		/// <summary>
		/// �Ƿ������,�༭,ɾ����Ŀ��Ϣ��Ȩ��:0��ʾû��,1��ʾ��
		/// </summary>
		public int? ISAdd
		{
			set{ _isadd=value;}
			get{return _isadd;}
		}
		/// <summary>
		/// ��ӵ�ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

