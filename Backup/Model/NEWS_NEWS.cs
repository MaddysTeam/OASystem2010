using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����News_News ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class News_News
	{
		public News_News()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _parentid;
		private DateTime? _datetime;
		private string _contents;
		private int? _type;
		private string _keyword;
		private string _writer;
		private string _source;
		private string _minipic;
		private string _fileup;
		private int? _uptop;
		private int? _delflag;
		private int? _ispass;
		private int? _islimits;
		private int? _limitschoose;
		/// <summary>
		/// ��ʶGUID ����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// ������ĿID GUID
		/// </summary>
		public int? PARENTID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// ��������Ĭ������GETDATE() ��������
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// ��Ϣ����
		/// </summary>
		public string CONTENTS
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// ��Ϣ���ͣ�1Ϊͼ�����ݣ�2ΪURL���ӣ�3Ϊ�ϴ��ļ���
		/// </summary>
		public int? TYPE
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// �ؼ���
		/// </summary>
		public string KEYWORD
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// �����ߣ�ʹ���û���
		/// </summary>
		public string WRITER
		{
			set{ _writer=value;}
			get{return _writer;}
		}
		/// <summary>
		/// ��Ϣ��Դ
		/// </summary>
		public string SOURCE
		{
			set{ _source=value;}
			get{return _source;}
		}
		/// <summary>
		/// ����ͼ
		/// </summary>
		public string MINIPIC
		{
			set{ _minipic=value;}
			get{return _minipic;}
		}
		/// <summary>
		/// �ϴ�����
		/// </summary>
		public string FILEUP
		{
			set{ _fileup=value;}
			get{return _fileup;}
		}
		/// <summary>
		/// �ö���Ĭ��ֵΪ0��1Ϊ�ö���
		/// </summary>
		public int? UPTOP
		{
			set{ _uptop=value;}
			get{return _uptop;}
		}
		/// <summary>
		/// Ĭ��ֵΪ0��1Ϊ�Ѿ�ɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// �Ƿ�ͨ����ˣ�Ĭ��0��1��ʾͨ�����,2��ʾ��˲�ͨ�����������ʱ����Ҫ����ѡ����Ŀ������趨���и�ֵ
		/// </summary>
		public int? ISPASS
		{
			set{ _ispass=value;}
			get{return _ispass;}
		}
		/// <summary>
		/// �Ķ��ķ�Χ��0��ʾ��Լ����ȫ���˶����Կ�����1��ʾԼ����Ҫ��News_LimitUser�����Ƿ��и��û�
		/// </summary>
		public int? IsLimits
		{
			set{ _islimits=value;}
			get{return _islimits;}
		}
		/// <summary>
		/// 1-�����ų�Ա��2-ȫԱ��3-��Ŀ���Ա
		/// </summary>
		public int? LimitsChoose
		{
			set{ _limitschoose=value;}
			get{return _limitschoose;}
		}
		#endregion Model

	}
}

