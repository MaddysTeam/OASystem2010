using System;
namespace Dianda.Model
{
	/// <summary>
	/// ʵ����USER_ORGAN ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class USER_ORGAN
	{
		public USER_ORGAN()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _pid;
		private int? _ismain;
		private int? _delflag;
		private string _path;
		private string _types;
		private string _infor;
		private string _infor2;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ��֯��������
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// �Ƿ����ܲ�������ֻ����һ���ܲ���Ĭ��Ϊ0��1Ϊ���ܲ���
		/// </summary>
		public int? ISMAIN
		{
			set{ _ismain=value;}
			get{return _ismain;}
		}
		/// <summary>
		/// �Ƿ�ɾ����Ĭ��0��1��ʾɾ����
		/// </summary>
		public int? DELFLAG
		{
			set{ _delflag=value;}
			get{return _delflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PATH
		{
			set{ _path=value;}
			get{return _path;}
		}
		/// <summary>
		/// ��֯�����ͣ���USER_ORGTYPE��Ӧ
		/// </summary>
		public string TYPES
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// ��֯������˵��
		/// </summary>
		public string INFOR
		{
			set{ _infor=value;}
			get{return _infor;}
		}
		/// <summary>
		/// ��һЩ���ʲô��
		/// </summary>
		public string INFOR2
		{
			set{ _infor2=value;}
			get{return _infor2;}
		}
		#endregion Model

	}
}

