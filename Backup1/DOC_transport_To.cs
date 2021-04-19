using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// 业务逻辑类DOC_transport_To 的摘要说明。
	/// </summary>
	public class DOC_transport_To
	{
		private readonly Dianda.DAL.DOC_transport_To dal=new Dianda.DAL.DOC_transport_To();
		public DOC_transport_To()
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
		public void Add(Dianda.Model.DOC_transport_To model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.DOC_transport_To model)
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
		public Dianda.Model.DOC_transport_To GetModel(string ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Dianda.Model.DOC_transport_To GetModelByCache(string ID)
		{
			
			string CacheKey = "DOC_transport_ToModel-" + ID;
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
			return (Dianda.Model.DOC_transport_To)objModel;
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
		public List<Dianda.Model.DOC_transport_To> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.DOC_transport_To> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.DOC_transport_To> modelList = new List<Dianda.Model.DOC_transport_To>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.DOC_transport_To model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.DOC_transport_To();
					model.ID=dt.Rows[n]["ID"].ToString();
					model.FROMUSER=dt.Rows[n]["FROMUSER"].ToString();
					model.TOUSER=dt.Rows[n]["TOUSER"].ToString();
					model.TITLES=dt.Rows[n]["TITLES"].ToString();
					model.FILEPATH=dt.Rows[n]["FILEPATH"].ToString();
					if(dt.Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(dt.Rows[n]["DATETIME"].ToString());
					}
					if(dt.Rows[n]["DELFLAG"].ToString()!="")
					{
						model.DELFLAG=int.Parse(dt.Rows[n]["DELFLAG"].ToString());
					}
					if(dt.Rows[n]["ISREAD"].ToString()!="")
					{
						model.ISREAD=int.Parse(dt.Rows[n]["ISREAD"].ToString());
					}
					if(dt.Rows[n]["READTIME"].ToString()!="")
					{
						model.READTIME=DateTime.Parse(dt.Rows[n]["READTIME"].ToString());
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
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

