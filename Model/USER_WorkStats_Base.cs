using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����USER_WorkStats_Base ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class USER_WorkStats_Base
	{
		public USER_WorkStats_Base()
		{}
		#region Model
		private int _id;
		private string _workstataname;
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
		/// ����״̬������
		/// </summary>
		public string WorkStataName
		{
			set{ _workstataname=value;}
			get{return _workstataname;}
		}
		/// <summary>
		/// ɾ���ı�ǣ�0������1��ʾɾ����
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

