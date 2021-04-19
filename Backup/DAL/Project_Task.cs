using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Project_Task。
	/// </summary>
	public class Project_Task
	{
		public Project_Task()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Project_Task"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Project_Task");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Project_Task model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Project_Task(");
			strSql.Append("ProjectID,NAMES,DELFLAG,Status,CompleteType,UserIDs,UserInfo,StartTime,EndTime,Overviews,DATETIME,SendUserID,ReadTime,UpID,IsFather)");
			strSql.Append(" values (");
			strSql.Append("@ProjectID,@NAMES,@DELFLAG,@Status,@CompleteType,@UserIDs,@UserInfo,@StartTime,@EndTime,@Overviews,@DATETIME,@SendUserID,@ReadTime,@UpID,@IsFather)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@NAMES", SqlDbType.VarChar,50),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CompleteType", SqlDbType.Int,4),
					new SqlParameter("@UserIDs", SqlDbType.VarChar,5000),
					new SqlParameter("@UserInfo", SqlDbType.VarChar,5000),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Overviews", SqlDbType.Text),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@SendUserID", SqlDbType.VarChar,50),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@UpID", SqlDbType.Int,4),
					new SqlParameter("@IsFather", SqlDbType.Int,4)};
			parameters[0].Value = model.ProjectID;
			parameters[1].Value = model.NAMES;
			parameters[2].Value = model.DELFLAG;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.CompleteType;
			parameters[5].Value = model.UserIDs;
			parameters[6].Value = model.UserInfo;
			parameters[7].Value = model.StartTime;
			parameters[8].Value = model.EndTime;
			parameters[9].Value = model.Overviews;
			parameters[10].Value = model.DATETIME;
			parameters[11].Value = model.SendUserID;
			parameters[12].Value = model.ReadTime;
			parameters[13].Value = model.UpID;
			parameters[14].Value = model.IsFather;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.Project_Task model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Project_Task set ");
			strSql.Append("ProjectID=@ProjectID,");
			strSql.Append("NAMES=@NAMES,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("Status=@Status,");
			strSql.Append("CompleteType=@CompleteType,");
			strSql.Append("UserIDs=@UserIDs,");
			strSql.Append("UserInfo=@UserInfo,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("Overviews=@Overviews,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("SendUserID=@SendUserID,");
			strSql.Append("ReadTime=@ReadTime,");
			strSql.Append("UpID=@UpID,");
			strSql.Append("IsFather=@IsFather");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@NAMES", SqlDbType.VarChar,50),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CompleteType", SqlDbType.Int,4),
					new SqlParameter("@UserIDs", SqlDbType.VarChar,5000),
					new SqlParameter("@UserInfo", SqlDbType.VarChar,5000),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Overviews", SqlDbType.Text),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@SendUserID", SqlDbType.VarChar,50),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@UpID", SqlDbType.Int,4),
					new SqlParameter("@IsFather", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ProjectID;
			parameters[2].Value = model.NAMES;
			parameters[3].Value = model.DELFLAG;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.CompleteType;
			parameters[6].Value = model.UserIDs;
			parameters[7].Value = model.UserInfo;
			parameters[8].Value = model.StartTime;
			parameters[9].Value = model.EndTime;
			parameters[10].Value = model.Overviews;
			parameters[11].Value = model.DATETIME;
			parameters[12].Value = model.SendUserID;
			parameters[13].Value = model.ReadTime;
			parameters[14].Value = model.UpID;
			parameters[15].Value = model.IsFather;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Project_Task ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Project_Task GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ProjectID,NAMES,DELFLAG,Status,CompleteType,UserIDs,UserInfo,StartTime,EndTime,Overviews,DATETIME,SendUserID,ReadTime,UpID,IsFather from Project_Task ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Project_Task model=new Dianda.Model.Project_Task();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProjectID"].ToString()!="")
				{
					model.ProjectID=int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
				}
				model.NAMES=ds.Tables[0].Rows[0]["NAMES"].ToString();
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CompleteType"].ToString()!="")
				{
					model.CompleteType=int.Parse(ds.Tables[0].Rows[0]["CompleteType"].ToString());
				}
				model.UserIDs=ds.Tables[0].Rows[0]["UserIDs"].ToString();
				model.UserInfo=ds.Tables[0].Rows[0]["UserInfo"].ToString();
				if(ds.Tables[0].Rows[0]["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
				}
				model.Overviews=ds.Tables[0].Rows[0]["Overviews"].ToString();
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				model.SendUserID=ds.Tables[0].Rows[0]["SendUserID"].ToString();
				if(ds.Tables[0].Rows[0]["ReadTime"].ToString()!="")
				{
					model.ReadTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReadTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpID"].ToString()!="")
				{
					model.UpID=int.Parse(ds.Tables[0].Rows[0]["UpID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsFather"].ToString()!="")
				{
					model.IsFather=int.Parse(ds.Tables[0].Rows[0]["IsFather"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ProjectID,NAMES,DELFLAG,Status,CompleteType,UserIDs,UserInfo,StartTime,EndTime,Overviews,DATETIME,SendUserID,ReadTime,UpID,IsFather ");
			strSql.Append(" FROM Project_Task ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,ProjectID,NAMES,DELFLAG,Status,CompleteType,UserIDs,UserInfo,StartTime,EndTime,Overviews,DATETIME,SendUserID,ReadTime,UpID,IsFather ");
			strSql.Append(" FROM Project_Task ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Project_Task";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

