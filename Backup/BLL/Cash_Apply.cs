using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// Cash_Apply
	/// </summary>
	public partial class Cash_Apply
	{
		private readonly Dianda.DAL.Cash_Apply dal=new Dianda.DAL.Cash_Apply();
		public Cash_Apply()
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
		public int  Add(Dianda.Model.Cash_Apply model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Dianda.Model.Cash_Apply model)
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
		public Dianda.Model.Cash_Apply GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Dianda.Model.Cash_Apply GetModelByCache(int ID)
		{
			
			string CacheKey = "Cash_ApplyModel-" + ID;
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
			return (Dianda.Model.Cash_Apply)objModel;
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
		public List<Dianda.Model.Cash_Apply> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.Cash_Apply> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Cash_Apply> modelList = new List<Dianda.Model.Cash_Apply>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Cash_Apply model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Cash_Apply();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["ProjectID"]!=null && dt.Rows[n]["ProjectID"].ToString()!="")
					{
						model.ProjectID=int.Parse(dt.Rows[n]["ProjectID"].ToString());
					}
					if(dt.Rows[n]["CashCertificateID"]!=null && dt.Rows[n]["CashCertificateID"].ToString()!="")
					{
					model.CashCertificateID=dt.Rows[n]["CashCertificateID"].ToString();
					}
					if(dt.Rows[n]["ApplyCount"]!=null && dt.Rows[n]["ApplyCount"].ToString()!="")
					{
						model.ApplyCount=decimal.Parse(dt.Rows[n]["ApplyCount"].ToString());
					}
					if(dt.Rows[n]["GetDateTime"]!=null && dt.Rows[n]["GetDateTime"].ToString()!="")
					{
						model.GetDateTime=DateTime.Parse(dt.Rows[n]["GetDateTime"].ToString());
					}
					if(dt.Rows[n]["UseFor"]!=null && dt.Rows[n]["UseFor"].ToString()!="")
					{
					model.UseFor=dt.Rows[n]["UseFor"].ToString();
					}
					if(dt.Rows[n]["ApplierTel"]!=null && dt.Rows[n]["ApplierTel"].ToString()!="")
					{
					model.ApplierTel=dt.Rows[n]["ApplierTel"].ToString();
					}
					if(dt.Rows[n]["ApplierID"]!=null && dt.Rows[n]["ApplierID"].ToString()!="")
					{
					model.ApplierID=dt.Rows[n]["ApplierID"].ToString();
					}
					if(dt.Rows[n]["DATETIME"]!=null && dt.Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(dt.Rows[n]["DATETIME"].ToString());
					}
					if(dt.Rows[n]["Statas"]!=null && dt.Rows[n]["Statas"].ToString()!="")
					{
						model.Statas=int.Parse(dt.Rows[n]["Statas"].ToString());
					}
					if(dt.Rows[n]["DoUserID"]!=null && dt.Rows[n]["DoUserID"].ToString()!="")
					{
					model.DoUserID=dt.Rows[n]["DoUserID"].ToString();
					}
					if(dt.Rows[n]["CarDetails"]!=null && dt.Rows[n]["CarDetails"].ToString()!="")
					{
					model.CarDetails=dt.Rows[n]["CarDetails"].ToString();
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
                    if (dt.Rows[n]["TEMP4"] != null && dt.Rows[n]["TEMP4"].ToString() != "")
                    {
                        model.TEMP4 = dt.Rows[n]["TEMP4"].ToString();
                    }
                    if (dt.Rows[n]["TEMP5"] != null && dt.Rows[n]["TEMP5"].ToString() != "")
                    {
                        model.TEMP5 = dt.Rows[n]["TEMP5"].ToString();
                    }
                    if (dt.Rows[n]["SpecialFundsID"] != null && dt.Rows[n]["SpecialFundsID"].ToString() != "")
                    {
                        model.SpecialFundsID = int.Parse(dt.Rows[n]["SpecialFundsID"].ToString());
                    }
                    if (dt.Rows[n]["Attribute"] != null && dt.Rows[n]["Attribute"].ToString() != "")
                    {
                        model.Attribute = dt.Rows[n]["Attribute"].ToString();
                    }
                    if (dt.Rows[n]["AuditOpinion"] != null && dt.Rows[n]["AuditOpinion"].ToString() != "")
                    {
                        model.AuditOpinion = dt.Rows[n]["AuditOpinion"].ToString();
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

