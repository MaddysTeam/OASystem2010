using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// Cash_CardsDetail
	/// </summary>
	public partial class Cash_CardsDetail
	{
		private readonly Dianda.DAL.Cash_CardsDetail dal=new Dianda.DAL.Cash_CardsDetail();
		public Cash_CardsDetail()
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
		public int  Add(Dianda.Model.Cash_CardsDetail model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Dianda.Model.Cash_CardsDetail model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Cash_CardsDetail GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Dianda.Model.Cash_CardsDetail GetModelByCache(int ID)
		{
			
			string CacheKey = "Cash_CardsDetailModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Dianda.Model.Cash_CardsDetail)objModel;
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
		public List<Dianda.Model.Cash_CardsDetail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.Cash_CardsDetail> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Cash_CardsDetail> modelList = new List<Dianda.Model.Cash_CardsDetail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Cash_CardsDetail model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Cash_CardsDetail();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["CardID"]!=null && dt.Rows[n]["CardID"].ToString()!="")
					{
						model.CardID=int.Parse(dt.Rows[n]["CardID"].ToString());
					}
					if(dt.Rows[n]["DetailID"]!=null && dt.Rows[n]["DetailID"].ToString()!="")
					{
						model.DetailID=int.Parse(dt.Rows[n]["DetailID"].ToString());
					}
					if(dt.Rows[n]["Balance"]!=null && dt.Rows[n]["Balance"].ToString()!="")
					{
						model.Balance=decimal.Parse(dt.Rows[n]["Balance"].ToString());
					}
					if(dt.Rows[n]["Unit"]!=null && dt.Rows[n]["Unit"].ToString()!="")
					{
						model.Unit=int.Parse(dt.Rows[n]["Unit"].ToString());
					}
					if(dt.Rows[n]["TypesName"]!=null && dt.Rows[n]["TypesName"].ToString()!="")
					{
					model.TypesName=dt.Rows[n]["TypesName"].ToString();
					}
					if(dt.Rows[n]["Oldbalance"]!=null && dt.Rows[n]["Oldbalance"].ToString()!="")
					{
						model.Oldbalance=decimal.Parse(dt.Rows[n]["Oldbalance"].ToString());
					}
					if(dt.Rows[n]["KYbalance"]!=null && dt.Rows[n]["KYbalance"].ToString()!="")
					{
						model.KYbalance=decimal.Parse(dt.Rows[n]["KYbalance"].ToString());
					}
					if(dt.Rows[n]["DetailName"]!=null && dt.Rows[n]["DetailName"].ToString()!="")
					{
					model.DetailName=dt.Rows[n]["DetailName"].ToString();
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

