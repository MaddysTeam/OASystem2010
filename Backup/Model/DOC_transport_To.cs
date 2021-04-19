using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����DOC_transport_To ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class DOC_transport_To
	{
		public DOC_transport_To()
		{}
		#region Model
		private string _id;
		private string _fromuser;
		private string _touser;
		private string _titles;
		private string _filepath;
		private DateTime? _datetime;
		private int? _delflag;
		private int? _isread;
		private DateTime? _readtime;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �����˵��л���
		/// </summary>
		public string FROMUSER
		{
			set{ _fromuser=value;}
			get{return _fromuser;}
		}
		/// <summary>
		/// �ռ��˵��û���
		/// </summary>
		public string TOUSER
		{
			set{ _touser=value;}
			get{return _touser;}
		}
		/// <summary>
		/// �ʼ��ı������
		/// </summary>
		public string TITLES
		{
			set{ _titles=value;}
			get{return _titles;}
		}
		/// <summary>
		/// �ʼ��ĸ�����ַ
		/// </summary>
		public string FILEPATH
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// �յ��ʼ���ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// �Ƿ��Ķ��ˣ�0��ʾû�У�1��ʾ��
		/// </summary>
		public int? ISREAD
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// �Ķ���ʱ��
		/// </summary>
		public DateTime? READTIME
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		#endregion Model

	}
}

