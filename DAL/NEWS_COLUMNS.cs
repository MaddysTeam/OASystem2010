using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类News_Columns。
	/// </summary>
	public class News_Columns
	{
		public News_Columns()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "News_Columns"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from News_Columns");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.News_Columns model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into News_Columns(");
			strSql.Append("NAME,PARENTID,ForItems,ItemsID,DATETIME,ISMENU,ISSHENHE,ONLYONE,DELFLAG,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES)");
			strSql.Append(" values (");
			strSql.Append("@NAME,@PARENTID,@ForItems,@ItemsID,@DATETIME,@ISMENU,@ISSHENHE,@ONLYONE,@DELFLAG,@COLUMNSPATH,@SHUNXU,@IMAGEURL,@PNAMES)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@PARENTID", SqlDbType.Int,4),
					new SqlParameter("@ForItems", SqlDbType.VarChar,50),
					new SqlParameter("@ItemsID", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@ISMENU", SqlDbType.Int,4),
					new SqlParameter("@ISSHENHE", SqlDbType.Int,4),
					new SqlParameter("@ONLYONE", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@COLUMNSPATH", SqlDbType.VarChar,1000),
					new SqlParameter("@SHUNXU", SqlDbType.Int,4),
					new SqlParameter("@IMAGEURL", SqlDbType.VarChar,100),
					new SqlParameter("@PNAMES", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.NAME;
			parameters[1].Value = model.PARENTID;
			parameters[2].Value = model.ForItems;
			parameters[3].Value = model.ItemsID;
			parameters[4].Value = model.DATETIME;
			parameters[5].Value = model.ISMENU;
			parameters[6].Value = model.ISSHENHE;
			parameters[7].Value = model.ONLYONE;
			parameters[8].Value = model.DELFLAG;
			parameters[9].Value = model.COLUMNSPATH;
			parameters[10].Value = model.SHUNXU;
			parameters[11].Value = model.IMAGEURL;
			parameters[12].Value = model.PNAMES;

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
		public void Update(Dianda.Model.News_Columns model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update News_Columns set ");
			strSql.Append("NAME=@NAME,");
			strSql.Append("PARENTID=@PARENTID,");
			strSql.Append("ForItems=@ForItems,");
			strSql.Append("ItemsID=@ItemsID,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("ISMENU=@ISMENU,");
			strSql.Append("ISSHENHE=@ISSHENHE,");
			strSql.Append("ONLYONE=@ONLYONE,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("COLUMNSPATH=@COLUMNSPATH,");
			strSql.Append("SHUNXU=@SHUNXU,");
			strSql.Append("IMAGEURL=@IMAGEURL,");
			strSql.Append("PNAMES=@PNAMES");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@PARENTID", SqlDbType.Int,4),
					new SqlParameter("@ForItems", SqlDbType.VarChar,50),
					new SqlParameter("@ItemsID", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@ISMENU", SqlDbType.Int,4),
					new SqlParameter("@ISSHENHE", SqlDbType.Int,4),
					new SqlParameter("@ONLYONE", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@COLUMNSPATH", SqlDbType.VarChar,1000),
					new SqlParameter("@SHUNXU", SqlDbType.Int,4),
					new SqlParameter("@IMAGEURL", SqlDbType.VarChar,100),
					new SqlParameter("@PNAMES", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.PARENTID;
			parameters[3].Value = model.ForItems;
			parameters[4].Value = model.ItemsID;
			parameters[5].Value = model.DATETIME;
			parameters[6].Value = model.ISMENU;
			parameters[7].Value = model.ISSHENHE;
			parameters[8].Value = model.ONLYONE;
			parameters[9].Value = model.DELFLAG;
			parameters[10].Value = model.COLUMNSPATH;
			parameters[11].Value = model.SHUNXU;
			parameters[12].Value = model.IMAGEURL;
			parameters[13].Value = model.PNAMES;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from News_Columns ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.News_Columns GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,NAME,PARENTID,ForItems,ItemsID,DATETIME,ISMENU,ISSHENHE,ONLYONE,DELFLAG,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES from News_Columns ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.News_Columns model=new Dianda.Model.News_Columns();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.NAME=ds.Tables[0].Rows[0]["NAME"].ToString();
				if(ds.Tables[0].Rows[0]["PARENTID"].ToString()!="")
				{
					model.PARENTID=int.Parse(ds.Tables[0].Rows[0]["PARENTID"].ToString());
				}
				model.ForItems=ds.Tables[0].Rows[0]["ForItems"].ToString();
				model.ItemsID=ds.Tables[0].Rows[0]["ItemsID"].ToString();
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ISMENU"].ToString()!="")
				{
					model.ISMENU=int.Parse(ds.Tables[0].Rows[0]["ISMENU"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ISSHENHE"].ToString()!="")
				{
					model.ISSHENHE=int.Parse(ds.Tables[0].Rows[0]["ISSHENHE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ONLYONE"].ToString()!="")
				{
					model.ONLYONE=int.Parse(ds.Tables[0].Rows[0]["ONLYONE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				model.COLUMNSPATH=ds.Tables[0].Rows[0]["COLUMNSPATH"].ToString();
				if(ds.Tables[0].Rows[0]["SHUNXU"].ToString()!="")
				{
					model.SHUNXU=int.Parse(ds.Tables[0].Rows[0]["SHUNXU"].ToString());
				}
				model.IMAGEURL=ds.Tables[0].Rows[0]["IMAGEURL"].ToString();
				model.PNAMES=ds.Tables[0].Rows[0]["PNAMES"].ToString();
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
			strSql.Append("select ID,NAME,PARENTID,ForItems,ItemsID,DATETIME,ISMENU,ISSHENHE,ONLYONE,DELFLAG,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES ");
			strSql.Append(" FROM News_Columns ");
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
			strSql.Append(" ID,NAME,PARENTID,ForItems,ItemsID,DATETIME,ISMENU,ISSHENHE,ONLYONE,DELFLAG,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES ");
			strSql.Append(" FROM News_Columns ");
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
			parameters[0].Value = "News_Columns";
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

