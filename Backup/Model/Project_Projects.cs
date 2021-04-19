using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_Projects ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Project_Projects
	{
		public Project_Projects()
		{}
		#region Model
		private int _id;
		private string _names;
		private int? _delflag;
		private int? _status;
		private string _leaderid;
		private string _departmentid;
		private string _departmentnames;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private decimal? _cashtotal;
		private int? _cashcardid;
		private string _overviews;
		private string _attachments;
		private DateTime? _datetime;
		private string _senduserid;
		private string _douserid;
		private DateTime? _readtime;
		private string _donote;
		private int? _columnsid;
		private string _cashdw;
		private int? _projecttype;
		private string _budgetlist;
		private string _temp1;
		private string _temp2;
		private string _temp3;
		private string _temp4;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��Ŀ������
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
		/// ��Ŀ��״̬ 1��ʾ����������,0��ʾ����ˣ�2��ʾ��˲�ͨ����3��ͣ��4��ʾ�ݸ����У�5��ʾ���
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ��Ŀ�����˵�ID
		/// </summary>
		public string LeaderID
		{
			set{ _leaderid=value;}
			get{return _leaderid;}
		}
		/// <summary>
		/// ����Ĳ��ŵ���ϴ�ֵ���ö��Ÿ���
		/// </summary>
		public string DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// ������ѡ��Ĳ��ţ����첿�ŵ������б��Զ��Ÿ��������²������񲿡�
		/// </summary>
		public string DepartmentNames
		{
			set{ _departmentnames=value;}
			get{return _departmentnames;}
		}
		/// <summary>
		/// ��ĿԤ�ƿ�ʼʱ��
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// ��ĿԤ�ƽ���ʱ��
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// ��Ŀ��Ԥ�ƾ���
		/// </summary>
		public decimal? CashTotal
		{
			set{ _cashtotal=value;}
			get{return _cashtotal;}
		}
		/// <summary>
		/// �ʽ𿨵�ID�����Ϊ0����ʾ��ʱû�������ʽ𿨣�
		/// </summary>
		public int? CashCardID
		{
			set{ _cashcardid=value;}
			get{return _cashcardid;}
		}
		/// <summary>
		/// ��Ŀ��Ҫ
		/// </summary>
		public string Overviews
		{
			set{ _overviews=value;}
			get{return _overviews;}
		}
		/// <summary>
		/// �ϴ�����Ŀ����
		/// </summary>
		public string Attachments
		{
			set{ _attachments=value;}
			get{return _attachments;}
		}
		/// <summary>
		/// ��Ŀ��д��ʱ��
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// ��д���������û���ID
		/// </summary>
		public string SendUserID
		{
			set{ _senduserid=value;}
			get{return _senduserid;}
		}
		/// <summary>
		/// ��˵��û�ID
		/// </summary>
		public string DoUserID
		{
			set{ _douserid=value;}
			get{return _douserid;}
		}
		/// <summary>
		/// ��˵�ʱ��
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// �����Ա���õ�������
		/// </summary>
		public string DoNote
		{
			set{ _donote=value;}
			get{return _donote;}
		}
		/// <summary>
		/// ��Ŀ�����ڷ���,Project_Columns�е�ID
		/// </summary>
		public int? ColumnsID
		{
			set{ _columnsid=value;}
			get{return _columnsid;}
		}
		/// <summary>
		/// Ԥ�ƽ��ĵ�λ����Ԫ��Ԫ��
		/// </summary>
		public string CashDw
		{
			set{ _cashdw=value;}
			get{return _cashdw;}
		}
		/// <summary>
		/// ��Ŀ�����ͣ�0��ʾ����/��ʱ��Ŀ��1��ʾ��������Ŀ
		/// </summary>
		public int? ProjectType
		{
			set{ _projecttype=value;}
			get{return _projecttype;}
		}
		/// <summary>
		/// �ϴ�Ԥ�����·����ַ
		/// </summary>
		public string BudgetList
		{
			set{ _budgetlist=value;}
			get{return _budgetlist;}
		}
		/// <summary>
		/// Ԥ���ֶ�1
		/// </summary>
		public string TEMP1
		{
			set{ _temp1=value;}
			get{return _temp1;}
		}
		/// <summary>
		/// Ԥ���ֶ�2
		/// </summary>
		public string TEMP2
		{
			set{ _temp2=value;}
			get{return _temp2;}
		}
		/// <summary>
		/// Ԥ���ֶ�3
		/// </summary>
		public string TEMP3
		{
			set{ _temp3=value;}
			get{return _temp3;}
		}
		/// <summary>
		/// Ԥ���ֶ�4
		/// </summary>
		public string TEMP4
		{
			set{ _temp4=value;}
			get{return _temp4;}
		}
		#endregion Model

	}
}

