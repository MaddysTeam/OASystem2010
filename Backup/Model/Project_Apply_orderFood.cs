using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Project_Apply_orderFood ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Project_Apply_orderFood
	{
		public Project_Apply_orderFood()
		{}
		#region Model
		private int _id;
		private int? _applyid;
		private DateTime? _userdatetime;
		private int? _ordernum;
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
		/// �÷�������ʱ��
		/// </summary>
		public DateTime? UserDatetime
		{
			set{ _userdatetime=value;}
			get{return _userdatetime;}
		}
		/// <summary>
		/// Ԥ���ķ���
		/// </summary>
		public int? OrderNum
		{
			set{ _ordernum=value;}
			get{return _ordernum;}
		}
		#endregion Model

	}
}

