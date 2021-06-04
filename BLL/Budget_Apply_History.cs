using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// 业务逻辑类Budget_Apply_History 的摘要说明。
	/// </summary>
	public class Budget_Apply_History
	{
		private readonly Dianda.DAL.Budget_Apply_History dal =new Dianda.DAL.Budget_Apply_History();
		public Budget_Apply_History() 
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
		public int  Add(Dianda.Model.Budget_Apply_History model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.Budget_Apply_History model)
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
		public Dianda.Model.Budget_Apply_History GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Dianda.Model.Budget_Apply_History GetModelByCache(int ID)
		{
			
			string CacheKey = "Budget_Apply_HistoryModel-" + ID;
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
			return (Dianda.Model.Budget_Apply_History)objModel;
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
		public List<Dianda.Model.Budget_Apply_History> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.Budget_Apply_History> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Budget_Apply_History> modelList = new List<Dianda.Model.Budget_Apply_History>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Budget_Apply_History model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Budget_Apply_History();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["BudgetID"].ToString()!="")
					{
						model.BudgetID=int.Parse(dt.Rows[n]["BudgetID"].ToString());
					}
					model.ControlInfo=dt.Rows[n]["ControlInfo"].ToString();
					if(dt.Rows[n]["Balance"].ToString()!="")
					{
						model.Balance=decimal.Parse(dt.Rows[n]["Balance"].ToString());
					}
					if(dt.Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(dt.Rows[n]["DATETIME"].ToString());
					}
					model.DoUser=dt.Rows[n]["DoUser"].ToString();
					model.DoType=dt.Rows[n]["DoType"].ToString();
					model.NOTES=dt.Rows[n]["NOTES"].ToString();
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


		public string GetNotes(string budgetId)
		{
			string outputNotes = string.Empty;
			if (!string.IsNullOrEmpty(budgetId))
			{
				List<Dianda.Model.Budget_Apply_History> historyList = GetModelList(" budgetId=" + budgetId);
				if (historyList != null && historyList.Count > 0)
				{
					foreach (Dianda.Model.Budget_Apply_History model in historyList)
					{
						outputNotes += string.IsNullOrEmpty(model.NOTES) ? "" : model.NOTES + "</br>";
					}
				}

			}

			return outputNotes;
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

