using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_ShenheList ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Project_ShenheList
	{
		public Project_ShenheList()
		{}
		#region Model
		private int _id;
		private int? _projectid;
		private string _userid;
		private int? _status;
		private int? _isturn;
		private string _infors;
		/// <summary>
		/// ��Ŀ��˵ı��λ
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �������Ŀ��ID
		/// </summary>
		public int? ProjectID
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// ��˵��û���ID
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ��ǰ����û�����˽����0��ʾ����ˡ�1��ʾ���ͨ����2��ʾ��˲�ͨ����3��ͣ
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// �Ƿ񵽵�ǰ���û���ˡ�0��ʾδ����1��ʾ����2��ʾ�Ѿ���˹�
		/// </summary>
		public int? Isturn
		{
			set{ _isturn=value;}
			get{return _isturn;}
		}
		/// <summary>
		/// ��˵������Ϣ
		/// </summary>
		public string Infors
		{
			set{ _infors=value;}
			get{return _infors;}
		}
		#endregion Model

	}
}

