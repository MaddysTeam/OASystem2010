using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����News_Columns ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class News_Columns
	{
		public News_Columns()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _parentid;
		private string _foritems;
		private string _itemsid;
		private DateTime? _datetime;
		private int? _ismenu;
		private int? _isshenhe;
		private int? _onlyone;
		private int? _delflag;
		private string _columnspath;
		private int? _shunxu;
		private string _imageurl;
		private string _pnames;
		/// <summary>
		/// GUID��������ʶ
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��Ŀ����
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// ����Ŀ��ID��GUID
		/// </summary>
		public int? PARENTID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// ��Ŀ�Ĺ�����NEWS��ʾ���ţ�PROJECT��ʾ��Ŀ���ţ�DEPARTMENT��ʾ�������ţ�
		/// </summary>
		public string ForItems
		{
			set{ _foritems=value;}
			get{return _foritems;}
		}
		/// <summary>
		/// �����Ŀ�ǲ��ŵ���Ŀ������߱��沿�ŵ�ID
		/// </summary>
		public string ItemsID
		{
			set{ _itemsid=value;}
			get{return _itemsid;}
		}
		/// <summary>
		/// ����ʱ�䣨Ĭ������getdate()�������ݣ�
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// �Ƿ���ʾ�����˵���Ϣ
		/// </summary>
		public int? ISMENU
		{
			set{ _ismenu=value;}
			get{return _ismenu;}
		}
		/// <summary>
		/// �Ƿ���Ҫ���
		/// </summary>
		public int? ISSHENHE
		{
			set{ _isshenhe=value;}
			get{return _isshenhe;}
		}
		/// <summary>
		/// �������ţ�Ĭ��ֵΪ0��1��ʾ�������ţ�
		/// </summary>
		public int? ONLYONE
		{
			set{ _onlyone=value;}
			get{return _onlyone;}
		}
		/// <summary>
		/// ����ɾ�����(0��ʾû��ɾ����1��ʾ��ɾ��)
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// ��Ŀ��·����¼
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
		#endregion Model

	}
}

