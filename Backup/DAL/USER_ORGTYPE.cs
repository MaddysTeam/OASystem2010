using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类USER_ORGTYPE。
	/// </summary>
	public class USER_ORGTYPE
	{
		public USER_ORGTYPE()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "USER_ORGTYPE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from USER_ORGTYPE");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Dianda.Model.USER_ORGTYPE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into USER_ORGTYPE(");
			strSql.Append("ID,TYPES,NAMES)");
			strSql.Append(" values (");
			strSql.Append("@ID,@TYPES,@NAMES)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TYPES", SqlDbType.VarChar,50),
					new SqlParameter("@NAMES", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.TYPES;
			parameters[2].Value = model.NAMES;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.USER_ORGTYPE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update USER_ORGTYPE set ");
			strSql.Append("TYPES=@TYPES,");
			strSql.Append("NAMES=@NAMES");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TYPES", SqlDbType.VarChar,50),
					new SqlParameter("@NAMES", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.TYPES;
			parameters[2].Value = model.NAMES;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete USER_ORGTYPE ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.USER_ORGTYPE GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,TYPES,NAMES from USER_ORGTYPE ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.USER_ORGTYPE model=new Dianda.Model.USER_ORGTYPE();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.TYPES=ds.Tables[0].Rows[0]["TYPES"].ToString();
				model.NAMES=ds.Tables[0].Rows[0]["NAMES"].ToString();
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
			strSql.Append("select ID,TYPES,NAMES ");
			strSql.Append(" FROM USER_ORGTYPE ");
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
			parameters[0].Value = "USER_ORGTYPE";
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

