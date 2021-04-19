using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Document_File ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Document_File
	{
		public Document_File()
		{}
		#region Model
		private int _id;
		private int? _folderid;
		private string _filename;
		private string _filetype;
		private string _icon;
		private decimal? _sizeof;
		private string _filepath;
		private int? _isshare;
		private int? _delflag;
		private DateTime? _datetime;
		private string _userid;
		private int? _shareid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �ļ��е�ID
		/// </summary>
		public int? FolderID
		{
			set{ _folderid=value;}
			get{return _folderid;}
		}
		/// <summary>
		/// �ļ�������
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// �ļ������ͣ�ȡ�ļ��ĺ�׺����û��.��
		/// </summary>
		public string FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// �ļ���ͼ�����ƣ��������ļ���FileType����һ��
		/// </summary>
		public string Icon
		{
			set{ _icon=value;}
			get{return _icon;}
		}
		/// <summary>
		/// �ļ��Ĵ�С����KBΪ��λ
		/// </summary>
		public decimal? Sizeof
		{
			set{ _sizeof=value;}
			get{return _sizeof;}
		}
		/// <summary>
		/// �ļ��Ĵ洢��ַ
		/// </summary>
		public string FilePath
		{
			set{ _filepath=value;}
			get{return _filepath;}
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
		/// �������ļ����û�ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ����Ǵ����˹������Դ���ղػ�������Դ������ԭ��Դ��ID
		/// </summary>
		public int? ShareID
		{
			set{ _shareid=value;}
			get{return _shareid;}
		}
		#endregion Model

	}
}

