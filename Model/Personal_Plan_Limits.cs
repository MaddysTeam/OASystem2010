using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����Personal_Plan_Limits ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Personal_Plan_Limits
	{
		public Personal_Plan_Limits()
		{}
		#region Model
		private int _id;
		private string _userid;
		private string _applyuserid;
		private int? _isall;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �û���ID
		/// </summary>
		public string USERID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ����鿴�ҵĸ��˼ƻ����û��б���,�Ÿ���
		/// </summary>
		public string APPLYUSERID
		{
			set{ _applyuserid=value;}
			get{return _applyuserid;}
		}
		/// <summary>
		/// �Ƿ����޶���1--��ʾ�����˶��ܲ鿴��0��ʾֻ��APPLYUSERID�е��˲��ܿ���
		/// </summary>
		public int? ISALL
		{
			set{ _isall=value;}
			get{return _isall;}
		}
		#endregion Model

	}
}

