using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// 业务逻辑类NEWS_USERID_COLUMNSID 的摘要说明。
	/// </summary>
	public class NEWS_USERID_COLUMNSID
	{
		private readonly Dianda.DAL.NEWS_USERID_COLUMNSID dal=new Dianda.DAL.NEWS_USERID_COLUMNSID();
		public NEWS_USERID_COLUMNSID()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Dianda.Model.NEWS_USERID_COLUMNSID model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.NEWS_USERID_COLUMNSID model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ID)
		{
			
			dal.Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.NEWS_USERID_COLUMNSID GetModel(string ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Dianda.Model.NEWS_USERID_COLUMNSID GetModelByCache(string ID)
		{
			
			string CacheKey = "NEWS_USERID_COLUMNSIDModel-" + ID;
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
			return (Dianda.Model.NEWS_USERID_COLUMNSID)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.NEWS_USERID_COLUMNSID> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Dianda.Model.NEWS_USERID_COLUMNSID> modelList = new List<Dianda.Model.NEWS_USERID_COLUMNSID>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.NEWS_USERID_COLUMNSID model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.NEWS_USERID_COLUMNSID();
					model.ID=ds.Tables[0].Rows[n]["ID"].ToString();
					model.UserID=ds.Tables[0].Rows[n]["UserID"].ToString();
					model.ColumnsID=ds.Tables[0].Rows[n]["ColumnsID"].ToString();
					if(ds.Tables[0].Rows[n]["ISShenHe"].ToString()!="")
					{
						model.ISShenHe=int.Parse(ds.Tables[0].Rows[n]["ISShenHe"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ISAdd"].ToString()!="")
					{
						model.ISAdd=int.Parse(ds.Tables[0].Rows[n]["ISAdd"].ToString());
					}
					if(ds.Tables[0].Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[n]["DATETIME"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetAllList(string sqlwhere1)
		{
            return GetList(sqlwhere1);
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

