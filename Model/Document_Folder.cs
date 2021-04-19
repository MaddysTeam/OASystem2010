using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Document_Folder ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Document_Folder
	{
		public Document_Folder()
		{}
		#region Model
		private int _id;
		private string _foldername;
		private int? _upid;
		private string _types;
		private string _userid;
		private int? _projectid;
		private int? _isshare;
		private int? _delflag;
		private DateTime? _datetime;
		private string _columnspath;
		private int? _shunxu;
		private string _imageurl;
		private string _pnames;
		private string _sizeof;
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
		public string FolderName
		{
			set{ _foldername=value;}
			get{return _foldername;}
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
		/// �ļ��е����ԣ�public����Ŀ���ļ��У�private�Ǹ��˵��ļ���
		/// </summary>
		public string Types
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// ˽���ļ��е�������ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �����ļ��е���ĿID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// �Ƿ���Ĭ��0��������1��ʾ����
		/// </summary>
		public int? IsShare
		{
			set{ _isshare=value;}
			get{return _isshare;}
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
		/// ��ǰ�ļ������ļ��Ĵ�С
		/// </summary>
		public string SizeOf
		{
			set{ _sizeof=value;}
			get{return _sizeof;}
		}
		#endregion Model

	}
}

