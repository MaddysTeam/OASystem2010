using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_Apply_orderCar ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Project_Apply_orderCar
	{
		public Project_Apply_orderCar()
		{}
		#region Model
		private int _id;
		private int? _applyid;
		private int? _carid;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private int? _peoplenum;
		private string _fromaddress;
		private string _toaddress;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Project_Apply�������ID
		/// </summary>
		public int? ApplyID
		{
			set{ _applyid=value;}
			get{return _applyid;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int? CarID
		{
			set{ _carid=value;}
			get{return _carid;}
		}
		/// <summary>
		/// �ó��Ŀ�ʼʱ��
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// �ó��Ľ���ʱ��
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// �˳�������
		/// </summary>
		public int? PeopleNum
		{
			set{ _peoplenum=value;}
			get{return _peoplenum;}
		}
		/// <summary>
		/// ʼ����
		/// </summary>
		public string FromAddress
		{
			set{ _fromaddress=value;}
			get{return _fromaddress;}
		}
		/// <summary>
		/// Ŀ�ĵ�
		/// </summary>
		public string ToAddress
		{
			set{ _toaddress=value;}
			get{return _toaddress;}
		}
		#endregion Model

	}
}

