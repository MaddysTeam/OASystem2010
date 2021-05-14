using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// Budget_Detail
	/// </summary>
	public partial class Budget_User_Apply
	{
		private readonly Dianda.DAL.Budget_User_Apply dal =new Dianda.DAL.Budget_User_Apply();
		public Budget_User_Apply()
		{}    
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Dianda.Model.Budget_User_Apply model)
		{
			return dal.Add(model);
		}


		#endregion  Method
	}
}

