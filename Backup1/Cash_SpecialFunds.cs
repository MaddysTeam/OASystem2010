using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// Cash_SpecialFunds
	/// </summary>
	public partial class Cash_SpecialFunds
	{
        private readonly Dianda.DAL.Cash_SpecialFunds dal = new Dianda.DAL.Cash_SpecialFunds();
		public Cash_SpecialFunds()
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
		public int  Add(Dianda.Model.Cash_SpecialFunds model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Dianda.Model.Cash_SpecialFunds model)
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
		public Dianda.Model.Cash_SpecialFunds GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Dianda.Model.Cash_SpecialFunds GetModelByCache(int ID)
		{
			
			string CacheKey = "Cash_SpecialFundsModel-" + ID;
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
			return (Dianda.Model.Cash_SpecialFunds)objModel;
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
		public List<Dianda.Model.Cash_SpecialFunds> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.Cash_SpecialFunds> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Cash_SpecialFunds> modelList = new List<Dianda.Model.Cash_SpecialFunds>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Cash_SpecialFunds model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Cash_SpecialFunds();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["NAMES"]!=null && dt.Rows[n]["NAMES"].ToString()!="")
					{
					model.NAMES=dt.Rows[n]["NAMES"].ToString();
					}
					if(dt.Rows[n]["YEARS"]!=null && dt.Rows[n]["YEARS"].ToString()!="")
					{
						model.YEARS=int.Parse(dt.Rows[n]["YEARS"].ToString());
					}
					if(dt.Rows[n]["AccountID"]!=null && dt.Rows[n]["AccountID"].ToString()!="")
					{
						model.AccountID=int.Parse(dt.Rows[n]["AccountID"].ToString());
					}
					if(dt.Rows[n]["STATUS"]!=null && dt.Rows[n]["STATUS"].ToString()!="")
					{
						model.STATUS=int.Parse(dt.Rows[n]["STATUS"].ToString());
					}
					if(dt.Rows[n]["ADDTIME"]!=null && dt.Rows[n]["ADDTIME"].ToString()!="")
					{
						model.ADDTIME=DateTime.Parse(dt.Rows[n]["ADDTIME"].ToString());
					}
					if(dt.Rows[n]["Balance"]!=null && dt.Rows[n]["Balance"].ToString()!="")
					{
						model.Balance=decimal.Parse(dt.Rows[n]["Balance"].ToString());
					}
					if(dt.Rows[n]["TotalNum"]!=null && dt.Rows[n]["TotalNum"].ToString()!="")
					{
						model.TotalNum=decimal.Parse(dt.Rows[n]["TotalNum"].ToString());
					}
					if(dt.Rows[n]["Adduser"]!=null && dt.Rows[n]["Adduser"].ToString()!="")
					{
					model.Adduser=dt.Rows[n]["Adduser"].ToString();
					}
					if(dt.Rows[n]["Delflag"]!=null && dt.Rows[n]["Delflag"].ToString()!="")
					{
						model.Delflag=int.Parse(dt.Rows[n]["Delflag"].ToString());
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
					}
					if(dt.Rows[n]["IsListApply"]!=null && dt.Rows[n]["IsListApply"].ToString()!="")
					{
						model.IsListApply=int.Parse(dt.Rows[n]["IsListApply"].ToString());
					}
					if(dt.Rows[n]["TEMP1"]!=null && dt.Rows[n]["TEMP1"].ToString()!="")
					{
					model.TEMP1=dt.Rows[n]["TEMP1"].ToString();
					}
					if(dt.Rows[n]["TEMP2"]!=null && dt.Rows[n]["TEMP2"].ToString()!="")
					{
					model.TEMP2=dt.Rows[n]["TEMP2"].ToString();
					}
					if(dt.Rows[n]["TEMP3"]!=null && dt.Rows[n]["TEMP3"].ToString()!="")
					{
					model.TEMP3=dt.Rows[n]["TEMP3"].ToString();
					}
					if(dt.Rows[n]["TEMP4"]!=null && dt.Rows[n]["TEMP4"].ToString()!="")
					{
					model.TEMP4=dt.Rows[n]["TEMP4"].ToString();
					}
					if(dt.Rows[n]["TEMP5"]!=null && dt.Rows[n]["TEMP5"].ToString()!="")
					{
					model.TEMP5=dt.Rows[n]["TEMP5"].ToString();
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

