using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����USER_ORGTYPE ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class USER_ORGTYPE
	{
		public USER_ORGTYPE()
		{}
		#region Model
		private int _id;
		private string _types;
		private string _names;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TYPES
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// ��֯�������͵�˵��
		/// </summary>
		public string NAMES
		{
			set{ _names=value;}
			get{return _names;}
		}
		#endregion Model

	}
}

