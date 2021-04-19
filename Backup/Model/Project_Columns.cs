using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_Columns ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Project_Columns
	{
		public Project_Columns()
		{}
		#region Model
		private int _id;
		private string _names;
		private int? _upid;
		private string _userid;
		private string _userinfos;
		private int? _delflag;
		private DateTime? _datetime;
		private string _columnspath;
		private int? _shunxu;
		private string _imageurl;
		private string _pnames;
		private string _types;
		private string _infors;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��Ŀ������
		/// </summary>
		public string Names
		{
			set{ _names=value;}
			get{return _names;}
		}
		/// <summary>
		/// �ϼ���Ŀ��ID
		/// </summary>
		public int? UpID
		{
			set{ _upid=value;}
			get{return _upid;}
		}
		/// <summary>
		/// �������������û���ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �û�����ʵ������Ϣ
		/// </summary>
		public string UserInfos
		{
			set{ _userinfos=value;}
			get{return _userinfos;}
		}
		/// <summary>
		/// 0��ʾû��ɾ����1��ʾ��ɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// ������ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// ��Ŀ��·����¼����/��������
		/// </summary>
		public string COLUMNSPATH
		{
			set{ _columnspath=value;}
			get{return _columnspath;}
		}
		/// <summary>
		/// ��Ŀ��ʾ��˳��
		/// </summary>
		public int? SHUNXU
		{
			set{ _shunxu=value;}
			get{return _shunxu;}
		}
		/// <summary>
		/// ��Ŀ��ͼƬ
		/// </summary>
		public string IMAGEURL
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// ��Ŀ��·�����ƣ�A>B>C
		/// </summary>
		public string PNAMES
		{
			set{ _pnames=value;}
			get{return _pnames;}
		}
		/// <summary>
		/// ��������ͣ��ú��֣����ࡢ����Ŀ
		/// </summary>
		public string TYPES
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// �������������
		/// </summary>
		public string INFORS
		{
			set{ _infors=value;}
			get{return _infors;}
		}
		#endregion Model

	}
}

