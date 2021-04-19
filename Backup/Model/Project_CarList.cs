using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_CarList ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Project_CarList
	{
		public Project_CarList()
		{}
		#region Model
		private int _id;
		private string _carname;
		private string _drivername;
		private string _carnum;
		private string _infors;
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
		/// ����������
		/// </summary>
		public string CarName
		{
			set{ _carname=value;}
			get{return _carname;}
		}
		/// <summary>
		/// ˾��������
		/// </summary>
		public string DriverName
		{
			set{ _drivername=value;}
			get{return _drivername;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string CarNum
		{
			set{ _carnum=value;}
			get{return _carnum;}
		}
		/// <summary>
		/// �����ļ��
		/// </summary>
		public string Infors
		{
			set{ _infors=value;}
			get{return _infors;}
		}
		/// <summary>
		/// 0��ʾ������1��ʾɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

