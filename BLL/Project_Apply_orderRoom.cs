using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// ҵ���߼���Project_Apply_orderRoom ��ժҪ˵����
	/// </summary>
	public class Project_Apply_orderRoom
	{
		private readonly Dianda.DAL.Project_Apply_orderRoom dal=new Dianda.DAL.Project_Apply_orderRoom();
		public Project_Apply_orderRoom()
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
		public int  Add(Dianda.Model.Project_Apply_orderRoom model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Dianda.Model.Project_Apply_orderRoom model)
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
		public Dianda.Model.Project_Apply_orderRoom GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Dianda.Model.Project_Apply_orderRoom GetModelByCache(int ID)
		{
			
			string CacheKey = "Project_Apply_orderRoomModel-" + ID;
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
			return (Dianda.Model.Project_Apply_orderRoom)objModel;
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
		public List<Dianda.Model.Project_Apply_orderRoom> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Dianda.Model.Project_Apply_orderRoom> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.Project_Apply_orderRoom> modelList = new List<Dianda.Model.Project_Apply_orderRoom>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.Project_Apply_orderRoom model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.Project_Apply_orderRoom();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["ApplyID"].ToString()!="")
					{
						model.ApplyID=int.Parse(dt.Rows[n]["ApplyID"].ToString());
					}
					if(dt.Rows[n]["RoomID"].ToString()!="")
					{
						model.RoomID=int.Parse(dt.Rows[n]["RoomID"].ToString());
					}
					if(dt.Rows[n]["StartTime"].ToString()!="")
					{
						model.StartTime=DateTime.Parse(dt.Rows[n]["StartTime"].ToString());
					}
					if(dt.Rows[n]["EndTime"].ToString()!="")
					{
						model.EndTime=DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
					}
					if(dt.Rows[n]["PeopleNum"].ToString()!="")
					{
						model.PeopleNum=int.Parse(dt.Rows[n]["PeopleNum"].ToString());
					}
					model.MeetName=dt.Rows[n]["MeetName"].ToString();
					model.Address=dt.Rows[n]["Address"].ToString();
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

