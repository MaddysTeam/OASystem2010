using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Term_Diary ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Term_Diary
	{
		public Term_Diary()
		{}
		#region Model
		private int _id;
		private DateTime? _datetime;
		private string _contents;
		private DateTime? _firstweek;
		private DateTime? _lastweek;
		private int? _delflag;
		private int? _iswork;
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
		/// ����ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// ˵������
		/// </summary>
		public string CONTENTS
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// ����ȵ�һ�ܵ�ʱ���
		/// </summary>
		public DateTime? FirstWeek
		{
			set{ _firstweek=value;}
			get{return _firstweek;}
		}
		/// <summary>
		/// ��������һ�ܵ�ʱ��
		/// </summary>
		public DateTime? LastWeek
		{
			set{ _lastweek=value;}
			get{return _lastweek;}
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
		/// �Ƿ��ǵ�ǰ�Ĺ���ѧ�ڣ�0��ʾ���ǣ�1��ʾ��
		/// </summary>
		public int? isWork
		{
			set{ _iswork=value;}
			get{return _iswork;}
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

