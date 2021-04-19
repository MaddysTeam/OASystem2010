using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Personal_Plan ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Personal_Plan
	{
		public Personal_Plan()
		{}
		#region Model
		private int _id;
		private string _names;
		private int? _delflag;
		private int? _status;
		private string _overviews;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private DateTime? _datetime;
		private string _userid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ���˼ƻ��ı���
		/// </summary>
		public string NAMES
		{
			set{ _names=value;}
			get{return _names;}
		}
		/// <summary>
		/// 0��ʾ������1��ʾɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// �ƻ���״̬��0��ʾδ��ʼ��1��ʾ�����У�2��ʾ��ɣ�3��ʾ����
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// �ƻ�������
		/// </summary>
		public string Overviews
		{
			set{ _overviews=value;}
			get{return _overviews;}
		}
		/// <summary>
		/// �ƻ��Ŀ�ʼʱ��
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// �ƻ��Ľ���ʱ��
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// �ƻ��ķ���ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// �������û�ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

