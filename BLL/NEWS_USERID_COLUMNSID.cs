using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// ҵ���߼���NEWS_USERID_COLUMNSID ��ժҪ˵����
	/// </summary>
	public class NEWS_USERID_COLUMNSID
	{
		private readonly Dianda.DAL.NEWS_USERID_COLUMNSID dal=new Dianda.DAL.NEWS_USERID_COLUMNSID();
		public NEWS_USERID_COLUMNSID()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Dianda.Model.NEWS_USERID_COLUMNSID model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Dianda.Model.NEWS_USERID_COLUMNSID model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string ID)
		{
			
			dal.Delete(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Dianda.Model.NEWS_USERID_COLUMNSID GetModel(string ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Dianda.Model.NEWS_USERID_COLUMNSID GetModelByCache(string ID)
		{
			
			string CacheKey = "NEWS_USERID_COLUMNSIDModel-" + ID;
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
			return (Dianda.Model.NEWS_USERID_COLUMNSID)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Dianda.Model.NEWS_USERID_COLUMNSID> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Dianda.Model.NEWS_USERID_COLUMNSID> modelList = new List<Dianda.Model.NEWS_USERID_COLUMNSID>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.NEWS_USERID_COLUMNSID model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.NEWS_USERID_COLUMNSID();
					model.ID=ds.Tables[0].Rows[n]["ID"].ToString();
					model.UserID=ds.Tables[0].Rows[n]["UserID"].ToString();
					model.ColumnsID=ds.Tables[0].Rows[n]["ColumnsID"].ToString();
					if(ds.Tables[0].Rows[n]["ISShenHe"].ToString()!="")
					{
						model.ISShenHe=int.Parse(ds.Tables[0].Rows[n]["ISShenHe"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ISAdd"].ToString()!="")
					{
						model.ISAdd=int.Parse(ds.Tables[0].Rows[n]["ISAdd"].ToString());
					}
					if(ds.Tables[0].Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[n]["DATETIME"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataSet GetAllList(string sqlwhere1)
		{
            return GetList(sqlwhere1);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

