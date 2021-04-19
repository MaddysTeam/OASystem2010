using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����DOC_transport_From ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class DOC_transport_From
	{
		public DOC_transport_From()
		{}
		#region Model
		private string _id;
		private string _fromuser;
		private string _touser;
		private string _titles;
		private string _filepath;
		private DateTime? _datetime;
		private int? _delflag;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �����˵��û���
		/// </summary>
		public string FROMUSER
		{
			set{ _fromuser=value;}
			get{return _fromuser;}
		}
		/// <summary>
		/// �ռ��˵��û����ַ����б�
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
		/// �ʼ��ĸ�������
		/// </summary>
		public string FILEPATH
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// ���ʼ���ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// �Ƿ�ɾ���ˣ��˴���ɾ����Ӱ���Ѿ��յ��ʼ����û��鿴�ʼ�
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

