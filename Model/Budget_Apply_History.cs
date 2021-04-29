using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Buget_Apply_History ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Budget_Apply_History
	{
		public Budget_Apply_History()
		{}
		#region Model
		private int _id;
		private int? _budgetid;
		private string _controlinfo;
		private decimal? _balance;
		private DateTime? _datetime;
		private string _douser;
		private string _dotype;
		private string _notes;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Ԥ��ID
		/// </summary>
		public int? BudgetID
		{
			set{ _budgetid = value;}
			get{return _budgetid; }
		}
		/// <summary>
		/// Ԥ��ı��˵��(˵����ID,˵��������,���)
		/// </summary>
		public string ControlInfo
		{
			set{ _controlinfo=value;}
			get{return _controlinfo;}
		}
		/// <summary>
		/// Ԥ�������������Ժ󣬵�ǰ�ʽ𿨵Ľ�
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
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
		/// �����ߵġ���ʵ�������û���)
		/// </summary>
		public string DoUser
		{
			set{ _douser=value;}
			get{return _douser;}
		}
		/// <summary>
		/// Ԥ��Ĳ������ͣ�����200������300��
		/// </summary>
		public string DoType
		{
			set{ _dotype=value;}
			get{return _dotype;}
		}
		/// <summary>
		/// ˵������
		/// </summary>
		public string NOTES
		{
			set{ _notes=value;}
			get{return _notes;}
		}
		#endregion Model

	}
}

