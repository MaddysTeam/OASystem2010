using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// ҵ���߼���Project_Apply ��ժҪ˵����
	/// </summary>
	public class Project_Apply
	{
		private readonly Dianda.DAL.Project_Apply dal=new Dianda.DAL.Project_Apply();
		public Project_Apply()
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
		public int  Add(Dianda.Model.Project_Apply model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Dianda.Model.Project_Apply model)
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
		public Dianda.Model.Project_Apply GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Dianda.Model.Project_Apply GetModelByCache(int ID)
		{
			
			string CacheKey = "Project_ApplyModel-" + ID;
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
			return (Dianda.Model.Project_Apply)objModel;
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
		public List<Dianda.Model.Project_Apply> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Dianda.Model.Project_Apply> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Project_Apply> modelList = new List<Dianda.Model.Project_Apply>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Project_Apply model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Project_Apply();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["ProjectID"].ToString()!="")
					{
						model.ProjectID=int.Parse(dt.Rows[n]["ProjectID"].ToString());
					}
					if(dt.Rows[n]["DELFLAG"].ToString()!="")
					{
						model.DELFLAG=int.Parse(dt.Rows[n]["DELFLAG"].ToString());
					}
					if(dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					model.AppType=dt.Rows[n]["AppType"].ToString();
					model.Overviews=dt.Rows[n]["Overviews"].ToString();
					if(dt.Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(dt.Rows[n]["DATETIME"].ToString());
					}
					model.SendUserID=dt.Rows[n]["SendUserID"].ToString();
					model.DepartmentID=dt.Rows[n]["DepartmentID"].ToString();
					if(dt.Rows[n]["ReadTime"].ToString()!="")
					{
						model.ReadTime=DateTime.Parse(dt.Rows[n]["ReadTime"].ToString());
					}
					model.DoUserID=dt.Rows[n]["DoUserID"].ToString();
					model.CheckNote=dt.Rows[n]["CheckNote"].ToString();
					model.TelNum=dt.Rows[n]["TelNum"].ToString();
					model.DoNote=dt.Rows[n]["DoNote"].ToString();
					model.Attachments=dt.Rows[n]["Attachments"].ToString();
					model.ApplyUserID=dt.Rows[n]["ApplyUserID"].ToString();
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

		#endregion  ��Ա����
	}
}

