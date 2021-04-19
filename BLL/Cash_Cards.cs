using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// 业务逻辑类Cash_Cards 的摘要说明。
	/// </summary>
	public class Cash_Cards
	{
		private readonly Dianda.DAL.Cash_Cards dal=new Dianda.DAL.Cash_Cards();
		public Cash_Cards()
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
		public int  Add(Dianda.Model.Cash_Cards model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.Cash_Cards model)
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
		public Dianda.Model.Cash_Cards GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Dianda.Model.Cash_Cards GetModelByCache(int ID)
		{
			
			string CacheKey = "Cash_CardsModel-" + ID;
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
			return (Dianda.Model.Cash_Cards)objModel;
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
		public List<Dianda.Model.Cash_Cards> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.Cash_Cards> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Cash_Cards> modelList = new List<Dianda.Model.Cash_Cards>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Cash_Cards model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Cash_Cards();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.CardNum=dt.Rows[n]["CardNum"].ToString();
					model.CardName=dt.Rows[n]["CardName"].ToString();
					model.CardholderID=dt.Rows[n]["CardholderID"].ToString();
					model.DepartmentID=dt.Rows[n]["DepartmentID"].ToString();
					if(dt.Rows[n]["ProjectID"].ToString()!="")
					{
						model.ProjectID=int.Parse(dt.Rows[n]["ProjectID"].ToString());
					}
					if(dt.Rows[n]["Balance"].ToString()!="")
					{
						model.Balance=decimal.Parse(dt.Rows[n]["Balance"].ToString());
					}
					if(dt.Rows[n]["LimitNums"].ToString()!="")
					{
						model.LimitNums=decimal.Parse(dt.Rows[n]["LimitNums"].ToString());
					}
					model.ApproverIDs=dt.Rows[n]["ApproverIDs"].ToString();
					if(dt.Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(dt.Rows[n]["DATETIME"].ToString());
					}
					if(dt.Rows[n]["Statas"].ToString()!="")
					{
						model.Statas=int.Parse(dt.Rows[n]["Statas"].ToString());
					}
					model.DoUserID=dt.Rows[n]["DoUserID"].ToString();
					if(dt.Rows[n]["EndTime"].ToString()!="")
					{
						model.EndTime=DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
					}
					model.TEMP0=dt.Rows[n]["TEMP0"].ToString();
					model.TEMP1=dt.Rows[n]["TEMP1"].ToString();
					model.TEMP2=dt.Rows[n]["TEMP2"].ToString();
					model.TEMP3=dt.Rows[n]["TEMP3"].ToString();
                    if (dt.Rows[n]["SpecialFundsID"].ToString() != "")
                    {
                        model.SpecialFundsID = int.Parse(dt.Rows[n]["SpecialFundsID"].ToString());
                    }
                    if (dt.Rows[n]["SFOrderID"].ToString() != "")
                    {
                        model.SFOrderID = int.Parse(dt.Rows[n]["SFOrderID"].ToString());
                    }
                    if (dt.Rows[n]["YEBalance"].ToString() != "")
					{
                        model.YEBalance = decimal.Parse(dt.Rows[n]["YEBalance"].ToString());
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

