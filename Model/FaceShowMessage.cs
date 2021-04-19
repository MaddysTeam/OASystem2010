using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����FaceShowMessage ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class FaceShowMessage
	{
		public FaceShowMessage()
		{}
		#region Model
		private int _id;
		private string _urls;
		private string _newstype;
		private DateTime? _datetime;
		private DateTime? _readtime;
		private int? _isread;
		private string _receive;
		private string _fromtable;
		private string _newsid;
		private int? _projectid;
		private int? _delflag;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// [��Ϣ���]+��Ϣ�����ӵ�ַ+��Ϣ�ı���
		/// </summary>
		public string URLS
		{
			set{ _urls=value;}
			get{return _urls;}
		}
		/// <summary>
		/// ��Ϣ������[��Ŀ�����ĵ��������������׼���ѡ�֪ͨ���桢վ����Ϣ�����ѡ�������Ϣ]
		/// </summary>
		public string NewsType
		{
			set{ _newstype=value;}
			get{return _newstype;}
		}
		/// <summary>
		/// ��Ϣ������ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// ��Ϣ���Ķ���ʱ��
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// ��Ϣ�Ƿ��Ķ���0��ʾδ����1��ʾ�Ѷ�
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// ��Ϣ�Ľ�����
		/// </summary>
		public string Receive
		{
			set{ _receive=value;}
			get{return _receive;}
		}
		/// <summary>
		/// ��Ϣ�Ǵ����������[վ����Ϣ��������Ϣ����Ŀ��ϢΪ��News_News;]
		/// </summary>
		public string FromTable
		{
			set{ _fromtable=value;}
			get{return _fromtable;}
		}
		/// <summary>
		/// ��Ϣ��Դ���е�IDֵ
		/// </summary>
		public string NewsID
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// ��Ŀ��ID�������������Ŀ��������
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// ɾ����ǣ�0��ʾ������1��ʾɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

