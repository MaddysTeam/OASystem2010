using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// 业务逻辑类USER_ORGAN 的摘要说明。
	/// </summary>
	public class USER_ORGAN
	{
		private readonly Dianda.DAL.USER_ORGAN dal=new Dianda.DAL.USER_ORGAN();
		public USER_ORGAN()
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
		public void Add(Dianda.Model.USER_ORGAN model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.USER_ORGAN model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除组织机构以及下属机构
		/// </summary>
		public void Delete(string path)
		{
			
			dal.Delete(path);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.USER_ORGAN GetModel(string ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Dianda.Model.USER_ORGAN GetModelByCache(string ID)
		{
			
			string CacheKey = "USER_ORGANModel-" + ID;
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
			return (Dianda.Model.USER_ORGAN)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得下拉菜单树状的组织机构列表
        /// </summary>
        public DataTable GetDropDownListAllList()
        {
            DataTable DT = new DataTable();
            DT = dal.GetDropDownListAllList().Tables[0];
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                string parentid = DT.Rows[i]["PID"].ToString();
                string path = DT.Rows[i]["path"].ToString();
                if (parentid != "-1")
                {
                    string kg = null;
                    for (int x = 0; x < (path.Length) / 32; x++)      //检查第几层组织机构
                    {
                        kg += "　";
                    }
                    DT.Rows[i]["NAME"] = kg + "|--" + DT.Rows[i]["name"].ToString();
                }
            }
            return DT;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dianda.Model.USER_ORGAN> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Dianda.Model.USER_ORGAN> modelList = new List<Dianda.Model.USER_ORGAN>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.USER_ORGAN model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.USER_ORGAN();
					model.ID=ds.Tables[0].Rows[n]["ID"].ToString();
					model.NAME=ds.Tables[0].Rows[n]["NAME"].ToString();
					model.PID=ds.Tables[0].Rows[n]["PID"].ToString();
					if(ds.Tables[0].Rows[n]["ISMAIN"].ToString()!="")
					{
						model.ISMAIN=int.Parse(ds.Tables[0].Rows[n]["ISMAIN"].ToString());
					}
					if(ds.Tables[0].Rows[n]["DELFLAG"].ToString()!="")
					{
						model.DELFLAG=int.Parse(ds.Tables[0].Rows[n]["DELFLAG"].ToString());
					}
					model.PATH=ds.Tables[0].Rows[n]["PATH"].ToString();
					model.TYPES=ds.Tables[0].Rows[n]["TYPES"].ToString();
					model.INFOR=ds.Tables[0].Rows[n]["INFOR"].ToString();
					model.INFOR2=ds.Tables[0].Rows[n]["INFOR2"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetAllList(string strWhere)
		{
            return GetList(strWhere);
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

