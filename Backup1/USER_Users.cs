using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Dianda.Model;
namespace Dianda.BLL
{
	/// <summary>
	/// ҵ���߼���USER_Users ��ժҪ˵����
	/// </summary>
	public class USER_Users
	{
		private readonly Dianda.DAL.USER_Users dal=new Dianda.DAL.USER_Users();
		public USER_Users()
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
		public void Add(Dianda.Model.USER_Users model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Dianda.Model.USER_Users model)
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
		public Dianda.Model.USER_Users GetModel(string ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Dianda.Model.USER_Users GetModelByCache(string ID)
		{
			
			string CacheKey = "USER_UsersModel-" + ID;
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
			return (Dianda.Model.USER_Users)objModel;
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
		public List<Dianda.Model.USER_Users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Dianda.Model.USER_Users> DataTableToList(DataTable dt)
		{
			List<Dianda.Model.USER_Users> modelList = new List<Dianda.Model.USER_Users>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dianda.Model.USER_Users model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Dianda.Model.USER_Users();
					model.ID=dt.Rows[n]["ID"].ToString();
					model.USERNAME=dt.Rows[n]["USERNAME"].ToString();
					model.PASSWORD=dt.Rows[n]["PASSWORD"].ToString();
					model.REALNAME=dt.Rows[n]["REALNAME"].ToString();
					model.SEX=dt.Rows[n]["SEX"].ToString();
					model.DepartMentID=dt.Rows[n]["DepartMentID"].ToString();
					model.StationID=dt.Rows[n]["StationID"].ToString();
					model.TEL=dt.Rows[n]["TEL"].ToString();
					model.EMAIL=dt.Rows[n]["EMAIL"].ToString();
					if(dt.Rows[n]["Holidays"].ToString()!="")
					{
						model.Holidays=int.Parse(dt.Rows[n]["Holidays"].ToString());
					}
					model.WorkStats=dt.Rows[n]["WorkStats"].ToString();
					if(dt.Rows[n]["DatesEmployed"].ToString()!="")
					{
						model.DatesEmployed=DateTime.Parse(dt.Rows[n]["DatesEmployed"].ToString());
					}
					if(dt.Rows[n]["LeaveDates"].ToString()!="")
					{
						model.LeaveDates=DateTime.Parse(dt.Rows[n]["LeaveDates"].ToString());
					}
					model.BIRTHDAY=dt.Rows[n]["BIRTHDAY"].ToString();
					model.NativePlace=dt.Rows[n]["NativePlace"].ToString();
					model.EducationLevel=dt.Rows[n]["EducationLevel"].ToString();
					model.ADDRESS=dt.Rows[n]["ADDRESS"].ToString();
					model.GraduateSchool=dt.Rows[n]["GraduateSchool"].ToString();
					model.Major=dt.Rows[n]["Major"].ToString();
					model.TrackRecord=dt.Rows[n]["TrackRecord"].ToString();
					if(dt.Rows[n]["DATETIME"].ToString()!="")
					{
						model.DATETIME=DateTime.Parse(dt.Rows[n]["DATETIME"].ToString());
					}
					model.GROUPS=dt.Rows[n]["GROUPS"].ToString();
					if(dt.Rows[n]["DELFLAG"].ToString()!="")
					{
						model.DELFLAG=int.Parse(dt.Rows[n]["DELFLAG"].ToString());
					}
					model.IMAGES=dt.Rows[n]["IMAGES"].ToString();
					if(dt.Rows[n]["IsManager"].ToString()!="")
					{
						model.IsManager=int.Parse(dt.Rows[n]["IsManager"].ToString());
					}
					model.TEMP1=dt.Rows[n]["TEMP1"].ToString();
					model.TEMP2=dt.Rows[n]["TEMP2"].ToString();
					model.TEMP3=dt.Rows[n]["TEMP3"].ToString();
					model.TEMP4=dt.Rows[n]["TEMP4"].ToString();
					model.DepartMentName=dt.Rows[n]["DepartMentName"].ToString();
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

