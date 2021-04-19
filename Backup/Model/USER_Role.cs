using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����USER_Role ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class USER_Role
	{
		public USER_Role()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _roles;
		private string _types;
		private int? _upid;
		private int? _delflag;
		/// <summary>
		/// ��ʶ GUID ����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Ȩ������
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// Ȩ����ָ��·�����߿ؼ�������
		/// </summary>
		public string Roles
		{
			set{ _roles=value;}
			get{return _roles;}
		}
		/// <summary>
		/// Ȩ�޵����������֣�ҳ��Ȩ�ޡ���ťȨ�ޡ��˵�Ȩ�ޣ�
		/// </summary>
		public string Types
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// ��ǰȨ�޵��ϼ��ڵ㣬���û���ϼ�������
		/// </summary>
		public int? UpID
		{
			set{ _upid=value;}
			get{return _upid;}
		}
		/// <summary>
		/// ɾ����� Ĭ��Ϊ0��1��ʾ��ɾ��
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		#endregion Model

	}
}

