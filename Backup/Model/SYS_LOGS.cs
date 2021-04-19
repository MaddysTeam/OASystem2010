using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����SYS_LOGS ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class SYS_LOGS
	{
		public SYS_LOGS()
		{}
		#region Model
		private int _id;
		private string _userinfo;
		private string _ip;
		private string _dotype;
		private string _result;
		private DateTime? _datetime;
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
		/// �����ߵĻ�����Ϣ���������û�����
		/// </summary>
		public string USERINFO
		{
			set{ _userinfo=value;}
			get{return _userinfo;}
		}
		/// <summary>
		/// �����ߵ�IP��ַ
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// ����������
		/// </summary>
		public string DOTYPE
		{
			set{ _dotype=value;}
			get{return _dotype;}
		}
		/// <summary>
		/// �����Ľ��
		/// </summary>
		public string RESULT
		{
			set{ _result=value;}
			get{return _result;}
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
		/// ɾ�����
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

