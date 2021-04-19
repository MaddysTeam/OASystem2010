using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类DOC_transport_From。
	/// </summary>
	public class DOC_transport_From
	{
		public DOC_transport_From()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DOC_transport_From");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Dianda.Model.DOC_transport_From model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DOC_transport_From(");
			strSql.Append("ID,FROMUSER,TOUSER,TITLES,FILEPATH,DATETIME,DELFLAG)");
			strSql.Append(" values (");
			strSql.Append("@ID,@FROMUSER,@TOUSER,@TITLES,@FILEPATH,@DATETIME,@DELFLAG)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@FROMUSER", SqlDbType.VarChar,50),
					new SqlParameter("@TOUSER", SqlDbType.Text),
					new SqlParameter("@TITLES", SqlDbType.VarChar,500),
					new SqlParameter("@FILEPATH", SqlDbType.VarChar,300),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.FROMUSER;
			parameters[2].Value = model.TOUSER;
			parameters[3].Value = model.TITLES;
			parameters[4].Value = model.FILEPATH;
			parameters[5].Value = model.DATETIME;
			parameters[6].Value = model.DELFLAG;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.DOC_transport_From model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DOC_transport_From set ");
			strSql.Append("FROMUSER=@FROMUSER,");
			strSql.Append("TOUSER=@TOUSER,");
			strSql.Append("TITLES=@TITLES,");
			strSql.Append("FILEPATH=@FILEPATH,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("DELFLAG=@DELFLAG");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@FROMUSER", SqlDbType.VarChar,50),
					new SqlParameter("@TOUSER", SqlDbType.Text),
					new SqlParameter("@TITLES", SqlDbType.VarChar,500),
					new SqlParameter("@FILEPATH", SqlDbType.VarChar,300),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.FROMUSER;
			parameters[2].Value = model.TOUSER;
			parameters[3].Value = model.TITLES;
			parameters[4].Value = model.FILEPATH;
			parameters[5].Value = model.DATETIME;
			parameters[6].Value = model.DELFLAG;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DOC_transport_From ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.DOC_transport_From GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,FROMUSER,TOUSER,TITLES,FILEPATH,DATETIME,DELFLAG from DOC_transport_From ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			Dianda.Model.DOC_transport_From model=new Dianda.Model.DOC_transport_From();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ID=ds.Tables[0].Rows[0]["ID"].ToString();
				model.FROMUSER=ds.Tables[0].Rows[0]["FROMUSER"].ToString();
				model.TOUSER=ds.Tables[0].Rows[0]["TOUSER"].ToString();
				model.TITLES=ds.Tables[0].Rows[0]["TITLES"].ToString();
				model.FILEPATH=ds.Tables[0].Rows[0]["FILEPATH"].ToString();
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
			strSql.Append("select ID,FROMUSER,TOUSER,TITLES,FILEPATH,DATETIME,DELFLAG ");
			strSql.Append(" FROM DOC_transport_From ");
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
			strSql.Append(" ID,FROMUSER,TOUSER,TITLES,FILEPATH,DATETIME,DELFLAG ");
			strSql.Append(" FROM DOC_transport_From ");
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
			parameters[0].Value = "DOC_transport_From";
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

