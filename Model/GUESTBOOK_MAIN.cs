using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����GUESTBOOK_MAIN ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class GUESTBOOK_MAIN
	{
		public GUESTBOOK_MAIN()
		{}
		#region Model
		private string _id;
		private string _titles;
		private string _classid;
		private string _contents;
		private string _re_contents;
		private int? _status;
		private string _writer;
		private DateTime? _datetime;
		private DateTime? _re_datetime;
		private int? _delflag;
		private string _courseid;
		/// <summary>
		/// ��ʶ GUID ����
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TITLES
		{
			set{ _titles=value;}
			get{return _titles;}
		}
		/// <summary>
		/// �༶ID(�ɵ�λ����DWDM+�꼶NJ+��������ZSJJ+רҵ����ZYDM���)�������İ༶����
		/// </summary>
		public string CLASSID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string CONTENTS
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// �ظ�����
		/// </summary>
		public string RE_CONTENTS
		{
			set{ _re_contents=value;}
			get{return _re_contents;}
		}
		/// <summary>
		/// ���״̬ Ĭ��Ϊ0 ��1Ϊ���ͨ��
		/// </summary>
		public int? STATUS
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// �����˵���ʵ����+�û���
		/// </summary>
		public string WRITER
		{
			set{ _writer=value;}
			get{return _writer;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// �ظ���ʱ��
		/// </summary>
		public DateTime? RE_DATETIME
		{
			set{ _re_datetime=value;}
			get{return _re_datetime;}
		}
		/// <summary>
		/// ɾ����� Ĭ��Ϊ0 ��1Ϊ��ɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// ϵͳ�ڿγ̵�ID
		/// </summary>
		public string COURSEID
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		#endregion Model

	}
}

