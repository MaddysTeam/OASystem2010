using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// 业务逻辑类GUESTBOOK_MAIN 的摘要说明。
	/// </summary>
	public class GUESTBOOK_MAIN
	{
		private readonly Dianda.DAL.GUESTBOOK_MAIN dal=new Dianda.DAL.GUESTBOOK_MAIN();
		public GUESTBOOK_MAIN()
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
		public void Add(Dianda.Model.GUESTBOOK_MAIN model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.GUESTBOOK_MAIN model)
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
		public Dianda.Model.GUESTBOOK_MAIN GetModel(string ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Dianda.Model.GUESTBOOK_MAIN GetModelByCache(string ID)
		{
			
			string CacheKey = "GUESTBOOK_MAINModel-" + ID;
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
			return (Dianda.Model.GUESTBOOK_MAIN)objModel;
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
		public List<Dianda.Model.GUESTBOOK_MAIN> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Dianda.Model.GUESTBOOK_MAIN> modelList = new List<Dianda.Model.GUESTBOOK_MAIN>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.GUESTBOOK_MAIN model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.GUESTBOOK_MAIN();
					model.ID=ds.Tables[0].Rows[n]["ID"].ToString();
					model.TITLES=ds.Tables[0].Rows[n]["TITLES"].ToString();
					model.CLASSID=ds.Tables[0].Rows[n]["CLASSID"].ToString();
					model.CONTENTS=ds.Tables[0].Rows[n]["CONTENTS"].ToString();
					model.RE_CONTENTS=ds.Tables[0].Rows[n]["RE_CONTENTS"].ToString();
					if(ds.Tables[0].Rows[n]["STATUS"].ToString()!="")
					{
						model.STATUS=int.Parse(ds.Tables[0].Rows[n]["STATUS"].ToString());
					}
					model.WRITER=ds.Tables[0].Rows[n]["WRITER"].ToString();
					if(ds.Tables[0].Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[n]["DATETIME"].ToString());
					}
					if(ds.Tables[0].Rows[n]["RE_DATETIME"].ToString()!="")
					{
						model.RE_DATETIME=DateTime.Parse(ds.Tables[0].Rows[n]["RE_DATETIME"].ToString());
					}
					if(ds.Tables[0].Rows[n]["DELFLAG"].ToString()!="")
					{
						model.DELFLAG=int.Parse(ds.Tables[0].Rows[n]["DELFLAG"].ToString());
					}
					model.COURSEID=ds.Tables[0].Rows[n]["COURSEID"].ToString();
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

