using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// 业务逻辑类Budget 的摘要说明。
	/// </summary>
	public class Budget
	{
		private readonly Dianda.DAL.Budget dal =new Dianda.DAL.Budget();
		public Budget()
		{}
		#region  成员方法

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
		public int  Add(Dianda.Model.Budget model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.Budget model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			dal.Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Budget GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Dianda.Model.Budget GetModelByCache(int ID)
		{
			
			string CacheKey = "BudgetModel-" + ID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Dianda.Model.Budget)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.Budget> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.Budget> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Budget> modelList = new List<Dianda.Model.Budget>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Budget model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Budget();
					if (dt.Rows[n]["ID"].ToString() != "")
					{
						model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.BudgetName = dt.Rows[n]["BudgetName"].ToString();
					if (dt.Rows[n]["Balance"].ToString() != "")
					{
						model.Balance = decimal.Parse(dt.Rows[n]["Balance"].ToString());
					}
					model.DepartmentIDs = dt.Rows[n]["DepartmentIDs"].ToString();
					model.ApproverIDs = dt.Rows[n]["ApproverIDs"].ToString();
					model.BudgetType = int.Parse(dt.Rows[n]["BudgetType"].ToString());
					if (dt.Rows[n]["YEBalance"].ToString() != "")
					{
						model.YEBalance = decimal.Parse(dt.Rows[n]["YEBalance"].ToString());
					}
					if (dt.Rows[n]["LimitNums"].ToString() != "")
					{
						model.LimitNums = decimal.Parse(dt.Rows[n]["LimitNums"].ToString());
					}
					if (dt.Rows[n]["Statas"].ToString() != "")
					{
						model.Statas = int.Parse(dt.Rows[n]["Statas"].ToString());
					}
					if (dt.Rows[n]["DATETIME"].ToString() != "")
					{
						model.DATETIME = DateTime.Parse(dt.Rows[n]["DATETIME"].ToString());
					}
					model.DoUserID = dt.Rows[n]["DoUserID"].ToString();
					if (dt.Rows[n]["StartTime"].ToString() != "")
					{
						model.EndTime = DateTime.Parse(dt.Rows[n]["StartTime"].ToString());
					}
					if (dt.Rows[n]["EndTime"].ToString() != "")
					{
						model.EndTime = DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
					}
					model.TEMP0 = dt.Rows[n]["TEMP0"].ToString();
					model.TEMP1 = dt.Rows[n]["TEMP1"].ToString();
					model.TEMP2 = dt.Rows[n]["TEMP2"].ToString();
					model.TEMP3 = dt.Rows[n]["TEMP3"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

