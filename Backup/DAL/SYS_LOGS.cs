using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类SYS_LOGS。
	/// </summary>
	public class SYS_LOGS
	{
		public SYS_LOGS()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "SYS_LOGS"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SYS_LOGS");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.SYS_LOGS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SYS_LOGS(");
			strSql.Append("USERINFO,IP,DOTYPE,RESULT,DATETIME,DELFLAG)");
			strSql.Append(" values (");
			strSql.Append("@USERINFO,@IP,@DOTYPE,@RESULT,@DATETIME,@DELFLAG)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@USERINFO", SqlDbType.VarChar,100),
					new SqlParameter("@IP", SqlDbType.VarChar,50),
					new SqlParameter("@DOTYPE", SqlDbType.VarChar,500),
					new SqlParameter("@RESULT", SqlDbType.VarChar,500),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4)};
			parameters[0].Value = model.USERINFO;
			parameters[1].Value = model.IP;
			parameters[2].Value = model.DOTYPE;
			parameters[3].Value = model.RESULT;
			parameters[4].Value = model.DATETIME;
			parameters[5].Value = model.DELFLAG;

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
		public void Update(Dianda.Model.SYS_LOGS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SYS_LOGS set ");
			strSql.Append("USERINFO=@USERINFO,");
			strSql.Append("IP=@IP,");
			strSql.Append("DOTYPE=@DOTYPE,");
			strSql.Append("RESULT=@RESULT,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("DELFLAG=@DELFLAG");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@USERINFO", SqlDbType.VarChar,100),
					new SqlParameter("@IP", SqlDbType.VarChar,50),
					new SqlParameter("@DOTYPE", SqlDbType.VarChar,500),
					new SqlParameter("@RESULT", SqlDbType.VarChar,500),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.USERINFO;
			parameters[2].Value = model.IP;
			parameters[3].Value = model.DOTYPE;
			parameters[4].Value = model.RESULT;
			parameters[5].Value = model.DATETIME;
			parameters[6].Value = model.DELFLAG;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_LOGS ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.SYS_LOGS GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,USERINFO,IP,DOTYPE,RESULT,DATETIME,DELFLAG from SYS_LOGS ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.SYS_LOGS model=new Dianda.Model.SYS_LOGS();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.USERINFO=ds.Tables[0].Rows[0]["USERINFO"].ToString();
				model.IP=ds.Tables[0].Rows[0]["IP"].ToString();
				model.DOTYPE=ds.Tables[0].Rows[0]["DOTYPE"].ToString();
				model.RESULT=ds.Tables[0].Rows[0]["RESULT"].ToString();
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
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
			strSql.Append("select ID,USERINFO,IP,DOTYPE,RESULT,DATETIME,DELFLAG ");
			strSql.Append(" FROM SYS_LOGS ");
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
			strSql.Append(" ID,USERINFO,IP,DOTYPE,RESULT,DATETIME,DELFLAG ");
			strSql.Append(" FROM SYS_LOGS ");
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
			parameters[0].Value = "SYS_LOGS";
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

