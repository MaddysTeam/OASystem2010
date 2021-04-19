using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// 业务逻辑类Document_File_Share 的摘要说明。
	/// </summary>
	public class Document_File_Share
	{
		private readonly Dianda.DAL.Document_File_Share dal=new Dianda.DAL.Document_File_Share();
		public Document_File_Share()
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
		public int  Add(Dianda.Model.Document_File_Share model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.Document_File_Share model)
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
		public Dianda.Model.Document_File_Share GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Dianda.Model.Document_File_Share GetModelByCache(int ID)
		{
			
			string CacheKey = "Document_File_ShareModel-" + ID;
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
			return (Dianda.Model.Document_File_Share)objModel;
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
		public List<Dianda.Model.Document_File_Share> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.Document_File_Share> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Document_File_Share> modelList = new List<Dianda.Model.Document_File_Share>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Document_File_Share model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Document_File_Share();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["FileID"].ToString()!="")
					{
						model.FileID=int.Parse(dt.Rows[n]["FileID"].ToString());
					}
					model.ShareForUser=dt.Rows[n]["ShareForUser"].ToString();
					if(dt.Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(dt.Rows[n]["DATETIME"].ToString());
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

