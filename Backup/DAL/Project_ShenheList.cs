using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Project_ShenheList。
	/// </summary>
	public class Project_ShenheList
	{
		public Project_ShenheList()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Project_ShenheList"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Project_ShenheList");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Project_ShenheList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Project_ShenheList(");
			strSql.Append("ProjectID,UserID,Status,Isturn,Infors)");
			strSql.Append(" values (");
			strSql.Append("@ProjectID,@UserID,@Status,@Isturn,@Infors)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Isturn", SqlDbType.Int,4),
					new SqlParameter("@Infors", SqlDbType.VarChar,5000)};
			parameters[0].Value = model.ProjectID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.Isturn;
			parameters[4].Value = model.Infors;

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
		public void Update(Dianda.Model.Project_ShenheList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Project_ShenheList set ");
			strSql.Append("ProjectID=@ProjectID,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("Status=@Status,");
			strSql.Append("Isturn=@Isturn,");
			strSql.Append("Infors=@Infors");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Isturn", SqlDbType.Int,4),
					new SqlParameter("@Infors", SqlDbType.VarChar,5000)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ProjectID;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Isturn;
			parameters[5].Value = model.Infors;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Project_ShenheList ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Project_ShenheList GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ProjectID,UserID,Status,Isturn,Infors from Project_ShenheList ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Project_ShenheList model=new Dianda.Model.Project_ShenheList();
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
				model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Isturn"].ToString()!="")
				{
					model.Isturn=int.Parse(ds.Tables[0].Rows[0]["Isturn"].ToString());
				}
				model.Infors=ds.Tables[0].Rows[0]["Infors"].ToString();
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
			strSql.Append("select ID,ProjectID,UserID,Status,Isturn,Infors ");
			strSql.Append(" FROM Project_ShenheList ");
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
			strSql.Append(" ID,ProjectID,UserID,Status,Isturn,Infors ");
			strSql.Append(" FROM Project_ShenheList ");
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
			parameters[0].Value = "Project_ShenheList";
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

