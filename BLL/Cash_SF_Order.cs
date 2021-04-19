using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// Cash_SF_Order
	/// </summary>
	public partial class Cash_SF_Order
	{
		private readonly Dianda.DAL.Cash_SF_Order dal=new Dianda.DAL.Cash_SF_Order();
		public Cash_SF_Order()
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
		public int  Add(Dianda.Model.Cash_SF_Order model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Dianda.Model.Cash_SF_Order model)
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
		public Dianda.Model.Cash_SF_Order GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Dianda.Model.Cash_SF_Order GetModelByCache(int ID)
		{
			
			string CacheKey = "Cash_SF_OrderModel-" + ID;
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
			return (Dianda.Model.Cash_SF_Order)objModel;
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
		public List<Dianda.Model.Cash_SF_Order> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.Cash_SF_Order> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Cash_SF_Order> modelList = new List<Dianda.Model.Cash_SF_Order>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Cash_SF_Order model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Cash_SF_Order();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["NAMES"]!=null && dt.Rows[n]["NAMES"].ToString()!="")
					{
					model.NAMES=dt.Rows[n]["NAMES"].ToString();
					}
					if(dt.Rows[n]["SpecialFundsID"]!=null && dt.Rows[n]["SpecialFundsID"].ToString()!="")
					{
						model.SpecialFundsID=int.Parse(dt.Rows[n]["SpecialFundsID"].ToString());
					}
					if(dt.Rows[n]["ProjectID"]!=null && dt.Rows[n]["ProjectID"].ToString()!="")
					{
						model.ProjectID=int.Parse(dt.Rows[n]["ProjectID"].ToString());
					}
					if(dt.Rows[n]["ADDTIME"]!=null && dt.Rows[n]["ADDTIME"].ToString()!="")
					{
						model.ADDTIME=DateTime.Parse(dt.Rows[n]["ADDTIME"].ToString());
					}
					if(dt.Rows[n]["BudgetAmount"]!=null && dt.Rows[n]["BudgetAmount"].ToString()!="")
					{
						model.BudgetAmount=decimal.Parse(dt.Rows[n]["BudgetAmount"].ToString());
					}
					if(dt.Rows[n]["BAUNIT"]!=null && dt.Rows[n]["BAUNIT"].ToString()!="")
					{
					model.BAUNIT=dt.Rows[n]["BAUNIT"].ToString();
					}
					if(dt.Rows[n]["ActualAmount"]!=null && dt.Rows[n]["ActualAmount"].ToString()!="")
					{
						model.ActualAmount=decimal.Parse(dt.Rows[n]["ActualAmount"].ToString());
					}
					if(dt.Rows[n]["AAUNIT"]!=null && dt.Rows[n]["AAUNIT"].ToString()!="")
					{
					model.AAUNIT=dt.Rows[n]["AAUNIT"].ToString();
					}
					if(dt.Rows[n]["Applyuser"]!=null && dt.Rows[n]["Applyuser"].ToString()!="")
					{
					model.Applyuser=dt.Rows[n]["Applyuser"].ToString();
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["Delflag"]!=null && dt.Rows[n]["Delflag"].ToString()!="")
					{
						model.Delflag=int.Parse(dt.Rows[n]["Delflag"].ToString());
					}
					if(dt.Rows[n]["BudgetList"]!=null && dt.Rows[n]["BudgetList"].ToString()!="")
					{
					model.BudgetList=dt.Rows[n]["BudgetList"].ToString();
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
					}
					if(dt.Rows[n]["CheckerHistory"]!=null && dt.Rows[n]["CheckerHistory"].ToString()!="")
					{
					model.CheckerHistory=dt.Rows[n]["CheckerHistory"].ToString();
					}
					if(dt.Rows[n]["Checker"]!=null && dt.Rows[n]["Checker"].ToString()!="")
					{
					model.Checker=dt.Rows[n]["Checker"].ToString();
					}
					if(dt.Rows[n]["AssignChecker"]!=null && dt.Rows[n]["AssignChecker"].ToString()!="")
					{
					model.AssignChecker=dt.Rows[n]["AssignChecker"].ToString();
					}
					if(dt.Rows[n]["CarNums"]!=null && dt.Rows[n]["CarNums"].ToString()!="")
					{
						model.CarNums=int.Parse(dt.Rows[n]["CarNums"].ToString());
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
                    if (dt.Rows[n]["CheckTime"] != null && dt.Rows[n]["CheckTime"].ToString() != "")
                    {
                        model.ADDTIME = DateTime.Parse(dt.Rows[n]["CheckTime"].ToString());
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

