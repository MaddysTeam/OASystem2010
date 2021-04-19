using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类NEWS_USERID_COLUMNSID。
	/// </summary>
	public class NEWS_USERID_COLUMNSID
	{
		public NEWS_USERID_COLUMNSID()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NEWS_USERID_COLUMNSID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Dianda.Model.NEWS_USERID_COLUMNSID model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NEWS_USERID_COLUMNSID(");
			strSql.Append("ID,UserID,ColumnsID,ISShenHe,ISAdd,DATETIME)");
			strSql.Append(" values (");
			strSql.Append("@ID,@UserID,@ColumnsID,@ISShenHe,@ISAdd,@DATETIME)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@ColumnsID", SqlDbType.VarChar,50),
					new SqlParameter("@ISShenHe", SqlDbType.Int,4),
					new SqlParameter("@ISAdd", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.ColumnsID;
			parameters[3].Value = model.ISShenHe;
			parameters[4].Value = model.ISAdd;
			parameters[5].Value = model.DATETIME;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.NEWS_USERID_COLUMNSID model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NEWS_USERID_COLUMNSID set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("ColumnsID=@ColumnsID,");
			strSql.Append("ISShenHe=@ISShenHe,");
			strSql.Append("ISAdd=@ISAdd,");
			strSql.Append("DATETIME=@DATETIME");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@ColumnsID", SqlDbType.VarChar,50),
					new SqlParameter("@ISShenHe", SqlDbType.Int,4),
					new SqlParameter("@ISAdd", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.ColumnsID;
			parameters[3].Value = model.ISShenHe;
			parameters[4].Value = model.ISAdd;
			parameters[5].Value = model.DATETIME;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete NEWS_USERID_COLUMNSID ");
            strSql.Append(" where UserID='" + ID + "' ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.NEWS_USERID_COLUMNSID GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,ColumnsID,ISShenHe,ISAdd,DATETIME from NEWS_USERID_COLUMNSID ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			Dianda.Model.NEWS_USERID_COLUMNSID model=new Dianda.Model.NEWS_USERID_COLUMNSID();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ID=ds.Tables[0].Rows[0]["ID"].ToString();
				model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
				model.ColumnsID=ds.Tables[0].Rows[0]["ColumnsID"].ToString();
				if(ds.Tables[0].Rows[0]["ISShenHe"].ToString()!="")
				{
					model.ISShenHe=int.Parse(ds.Tables[0].Rows[0]["ISShenHe"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ISAdd"].ToString()!="")
				{
					model.ISAdd=int.Parse(ds.Tables[0].Rows[0]["ISAdd"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
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
			strSql.Append("select ID,UserID,ColumnsID,ISShenHe,ISAdd,DATETIME ");
			strSql.Append(" FROM NEWS_USERID_COLUMNSID ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			parameters[0].Value = "NEWS_USERID_COLUMNSID";
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

