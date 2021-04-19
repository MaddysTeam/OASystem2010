using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// ҵ���߼���Project_Projects ��ժҪ˵����
	/// </summary>
	public class Project_Projects
	{
		private readonly Dianda.DAL.Project_Projects dal=new Dianda.DAL.Project_Projects();
		public Project_Projects()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Dianda.Model.Project_Projects model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Dianda.Model.Project_Projects model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			
			dal.Delete(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Dianda.Model.Project_Projects GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Dianda.Model.Project_Projects GetModelByCache(int ID)
		{
			
			string CacheKey = "Project_ProjectsModel-" + ID;
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
			return (Dianda.Model.Project_Projects)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Dianda.Model.Project_Projects> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Dianda.Model.Project_Projects> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Project_Projects> modelList = new List<Dianda.Model.Project_Projects>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Project_Projects model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Project_Projects();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.NAMES=dt.Rows[n]["NAMES"].ToString();
					if(dt.Rows[n]["DELFLAG"].ToString()!="")
					{
						model.DELFLAG=int.Parse(dt.Rows[n]["DELFLAG"].ToString());
					}
					if(dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					model.LeaderID=dt.Rows[n]["LeaderID"].ToString();
					model.DepartmentID=dt.Rows[n]["DepartmentID"].ToString();
					model.DepartmentNames=dt.Rows[n]["DepartmentNames"].ToString();
					if(dt.Rows[n]["StartTime"].ToString()!="")
					{
						model.StartTime=DateTime.Parse(dt.Rows[n]["StartTime"].ToString());
					}
					if(dt.Rows[n]["EndTime"].ToString()!="")
					{
						model.EndTime=DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
					}
					if(dt.Rows[n]["CashTotal"].ToString()!="")
					{
						model.CashTotal=decimal.Parse(dt.Rows[n]["CashTotal"].ToString());
					}
					if(dt.Rows[n]["CashCardID"].ToString()!="")
					{
						model.CashCardID=int.Parse(dt.Rows[n]["CashCardID"].ToString());
					}
					model.Overviews=dt.Rows[n]["Overviews"].ToString();
					model.Attachments=dt.Rows[n]["Attachments"].ToString();
					if(dt.Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(dt.Rows[n]["DATETIME"].ToString());
					}
					model.SendUserID=dt.Rows[n]["SendUserID"].ToString();
					model.DoUserID=dt.Rows[n]["DoUserID"].ToString();
					if(dt.Rows[n]["ReadTime"].ToString()!="")
					{
						model.ReadTime=DateTime.Parse(dt.Rows[n]["ReadTime"].ToString());
					}
					model.DoNote=dt.Rows[n]["DoNote"].ToString();
					if(dt.Rows[n]["ColumnsID"].ToString()!="")
					{
						model.ColumnsID=int.Parse(dt.Rows[n]["ColumnsID"].ToString());
					}
					model.CashDw=dt.Rows[n]["CashDw"].ToString();
					if(dt.Rows[n]["ProjectType"].ToString()!="")
					{
						model.ProjectType=int.Parse(dt.Rows[n]["ProjectType"].ToString());
					}
					model.BudgetList=dt.Rows[n]["BudgetList"].ToString();
					model.TEMP1=dt.Rows[n]["TEMP1"].ToString();
					model.TEMP2=dt.Rows[n]["TEMP2"].ToString();
					model.TEMP3=dt.Rows[n]["TEMP3"].ToString();
					model.TEMP4=dt.Rows[n]["TEMP4"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// �õ���Ŀ��Ա
        /// </summary>
        /// <param name="Pro_ID">��ĿID</param>
        /// <returns></returns>
        public DataTable GetAllRY(string Pro_ID)
        {
            return dal.GetAllRY(Pro_ID);
        }

		#endregion  ��Ա����
	}
}

