using System;
namespace Dianda.Model
{
	/// <summary>
	/// 实体类Cash_Apply_History 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Cash_Apply_History
	{
		public Cash_Apply_History()
		{}
		#region Model
		private int _id;
		private int? _cashcertificateid;
		private string _controlinfo;
		private decimal? _balance;
		private DateTime? _datetime;
		private string _douser;
		private string _dotype;
		private string _notes;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 资金卡的ID
		/// </summary>
		public int? CashCertificateID
		{
			set{ _cashcertificateid=value;}
			get{return _cashcertificateid;}
		}
		/// <summary>
		/// 资金卡的变更说明(说明的ID,说明的名称,金额)
		/// </summary>
		public string ControlInfo
		{
			set{ _controlinfo=value;}
			get{return _controlinfo;}
		}
		/// <summary>
		/// 资金卡的余额（操作完毕以后，当前资金卡的金额）
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		/// 操作的时间
		/// </summary>
		public DateTime? DATETIME
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 操作者的“真实姓名（用户名)
		/// </summary>
		public string DoUser
		{
			set{ _douser=value;}
			get{return _douser;}
		}
		/// <summary>
		/// 资金卡的操作类型（增加200，减少300）
		/// </summary>
		public string DoType
		{
			set{ _dotype=value;}
			get{return _dotype;}
		}
		/// <summary>
		/// 说明文字
		/// </summary>
		public string NOTES
		{
			set{ _notes=value;}
			get{return _notes;}
		}
		#endregion Model

	}
}

