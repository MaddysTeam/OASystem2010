using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// 业务逻辑类News_News 的摘要说明。
	/// </summary>
	public class News_News
	{
		private readonly Dianda.DAL.News_News dal=new Dianda.DAL.News_News();
		public News_News()
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
		public int  Add(Dianda.Model.News_News model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.News_News model)
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
		public Dianda.Model.News_News GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Dianda.Model.News_News GetModelByCache(int ID)
		{
			
			string CacheKey = "News_NewsModel-" + ID;
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
			return (Dianda.Model.News_News)objModel;
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
		public List<Dianda.Model.News_News> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.News_News> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.News_News> modelList = new List<Dianda.Model.News_News>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.News_News model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.News_News();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.NAME=dt.Rows[n]["NAME"].ToString();
					if(dt.Rows[n]["PARENTID"].ToString()!="")
					{
						model.PARENTID=int.Parse(dt.Rows[n]["PARENTID"].ToString());
					}
					if(dt.Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(dt.Rows[n]["DATETIME"].ToString());
					}
					model.CONTENTS=dt.Rows[n]["CONTENTS"].ToString();
					if(dt.Rows[n]["TYPE"].ToString()!="")
					{
						model.TYPE=int.Parse(dt.Rows[n]["TYPE"].ToString());
					}
					model.KEYWORD=dt.Rows[n]["KEYWORD"].ToString();
					model.WRITER=dt.Rows[n]["WRITER"].ToString();
					model.SOURCE=dt.Rows[n]["SOURCE"].ToString();
					model.MINIPIC=dt.Rows[n]["MINIPIC"].ToString();
					model.FILEUP=dt.Rows[n]["FILEUP"].ToString();
					if(dt.Rows[n]["UPTOP"].ToString()!="")
					{
						model.UPTOP=int.Parse(dt.Rows[n]["UPTOP"].ToString());
					}
					if(dt.Rows[n]["DELFLAG"].ToString()!="")
					{
						model.DELFLAG=int.Parse(dt.Rows[n]["DELFLAG"].ToString());
					}
					if(dt.Rows[n]["ISPASS"].ToString()!="")
					{
						model.ISPASS=int.Parse(dt.Rows[n]["ISPASS"].ToString());
					}
					if(dt.Rows[n]["IsLimits"].ToString()!="")
					{
						model.IsLimits=int.Parse(dt.Rows[n]["IsLimits"].ToString());
					}
					if(dt.Rows[n]["LimitsChoose"].ToString()!="")
					{
						model.LimitsChoose=int.Parse(dt.Rows[n]["LimitsChoose"].ToString());
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

