using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_SignetList ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Project_SignetList
	{
		public Project_SignetList()
		{}
		#region Model
		private int _id;
		private string _signetname;
		private string _signetnum;
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
		/// ӡ�µ�����
		/// </summary>
		public string SignetName
		{
			set{ _signetname=value;}
			get{return _signetname;}
		}
		/// <summary>
		/// ӡ�µı��
		/// </summary>
		public string SignetNum
		{
			set{ _signetnum=value;}
			get{return _signetnum;}
		}
		/// <summary>
		/// ӡ�µļ��
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

