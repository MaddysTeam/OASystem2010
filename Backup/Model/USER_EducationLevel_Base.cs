using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����USER_EducationLevel_Base ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class USER_EducationLevel_Base
	{
		public USER_EducationLevel_Base()
		{}
		#region Model
		private int _id;
		private string _educationlevel;
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
		/// ѧ����
		/// </summary>
		public string EducationLevel
		{
			set{ _educationlevel=value;}
			get{return _educationlevel;}
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

