using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����USER_Groups ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class USER_Groups
	{
		public USER_Groups()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _contents;
		private string _role;
		private int? _delflag;
		private int? _ismoren;
		private string _tags;
		/// <summary>
		/// ��ʶ GUID ����
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string CONTENTS
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// Ȩ��
		/// </summary>
		public string ROLE
		{
			set{ _role=value;}
			get{return _role;}
		}
		/// <summary>
		/// ɾ����� Ĭ��Ϊ0��1��ʾ��ɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// �Ƿ�ΪĬ�ϵ��û���
		/// </summary>
		public int? ISMOREN
		{
			set{ _ismoren=value;}
			get{return _ismoren;}
		}
		/// <summary>
		/// ��ǩ���ơ����磺��λ�����š���ͨ��..��
		/// </summary>
		public string TAGS
		{
			set{ _tags=value;}
			get{return _tags;}
		}
		#endregion Model

	}
}

