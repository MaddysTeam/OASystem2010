using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Cash_ControlInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Cash_ControlInfo
	{
		public Cash_ControlInfo()
		{}
		#region Model
		private int _id;
		private string _infors;
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
		/// �ʽ𿨲�����˵������
		/// </summary>
		public string INFORS
		{
			set{ _infors=value;}
			get{return _infors;}
		}
		/// <summary>
		/// ˳���
		/// </summary>
		public int? NUMS
		{
			set{ _nums=value;}
			get{return _nums;}
		}
		#endregion Model

	}
}

