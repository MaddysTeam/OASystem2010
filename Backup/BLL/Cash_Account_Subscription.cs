using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// Cash_Account_Subscription
	/// </summary>
	public partial class Cash_Account_Subscription
	{
		private readonly Dianda.DAL.Cash_Account_Subscription dal=new Dianda.DAL.Cash_Account_Subscription();
		public Cash_Account_Subscription()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Dianda.Model.Cash_Account_Subscription model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Dianda.Model.Cash_Account_Subscription model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Cash_Account_Subscription GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Dianda.Model.Cash_Account_Subscription GetModelByCache(int id)
		{
			
			string CacheKey = "Cash_Account_SubscriptionModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Dianda.Model.Cash_Account_Subscription)objModel;
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
		public List<Dianda.Model.Cash_Account_Subscription> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.Cash_Account_Subscription> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Cash_Account_Subscription> modelList = new List<Dianda.Model.Cash_Account_Subscription>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Cash_Account_Subscription model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Cash_Account_Subscription();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["AccountID"]!=null && dt.Rows[n]["AccountID"].ToString()!="")
					{
						model.AccountID=int.Parse(dt.Rows[n]["AccountID"].ToString());
					}
					if(dt.Rows[n]["ApplyDatetime"]!=null && dt.Rows[n]["ApplyDatetime"].ToString()!="")
					{
						model.ApplyDatetime=DateTime.Parse(dt.Rows[n]["ApplyDatetime"].ToString());
					}
					if(dt.Rows[n]["Subscription"]!=null && dt.Rows[n]["Subscription"].ToString()!="")
					{
						model.Subscription=decimal.Parse(dt.Rows[n]["Subscription"].ToString());
					}
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
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

