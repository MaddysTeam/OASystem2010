using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_Apply_signet ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Project_Apply_signet
	{
		public Project_Apply_signet()
		{}
		#region Model
		private int _id;
		private int? _applyid;
		private int? _signetid;
		private int? _nums;
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
		/// ӡ�µ�ID
		/// </summary>
		public int? SignetID
		{
			set{ _signetid=value;}
			get{return _signetid;}
		}
		/// <summary>
		/// ���µ�����
		/// </summary>
		public int? Nums
		{
			set{ _nums=value;}
			get{return _nums;}
		}
		#endregion Model

	}
}

