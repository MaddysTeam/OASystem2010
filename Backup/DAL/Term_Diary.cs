using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Term_Diary。
	/// </summary>
	public class Term_Diary
	{
		public Term_Diary()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Term_Diary"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Term_Diary");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Term_Diary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Term_Diary(");
			strSql.Append("DATETIME,CONTENTS,FirstWeek,LastWeek,DELFLAG,isWork,UserID)");
			strSql.Append(" values (");
			strSql.Append("@DATETIME,@CONTENTS,@FirstWeek,@LastWeek,@DELFLAG,@isWork,@UserID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@CONTENTS", SqlDbType.VarChar,500),
					new SqlParameter("@FirstWeek", SqlDbType.DateTime),
					new SqlParameter("@LastWeek", SqlDbType.DateTime),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@isWork", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.DATETIME;
			parameters[1].Value = model.CONTENTS;
			parameters[2].Value = model.FirstWeek;
			parameters[3].Value = model.LastWeek;
			parameters[4].Value = model.DELFLAG;
			parameters[5].Value = model.isWork;
			parameters[6].Value = model.UserID;

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
		public void Update(Dianda.Model.Term_Diary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Term_Diary set ");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("CONTENTS=@CONTENTS,");
			strSql.Append("FirstWeek=@FirstWeek,");
			strSql.Append("LastWeek=@LastWeek,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("isWork=@isWork,");
			strSql.Append("UserID=@UserID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@CONTENTS", SqlDbType.VarChar,500),
					new SqlParameter("@FirstWeek", SqlDbType.DateTime),
					new SqlParameter("@LastWeek", SqlDbType.DateTime),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@isWork", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.DATETIME;
			parameters[2].Value = model.CONTENTS;
			parameters[3].Value = model.FirstWeek;
			parameters[4].Value = model.LastWeek;
			parameters[5].Value = model.DELFLAG;
			parameters[6].Value = model.isWork;
			parameters[7].Value = model.UserID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Term_Diary ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Term_Diary GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,DATETIME,CONTENTS,FirstWeek,LastWeek,DELFLAG,isWork,UserID from Term_Diary ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Term_Diary model=new Dianda.Model.Term_Diary();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				model.CONTENTS=ds.Tables[0].Rows[0]["CONTENTS"].ToString();
				if(ds.Tables[0].Rows[0]["FirstWeek"].ToString()!="")
				{
					model.FirstWeek=DateTime.Parse(ds.Tables[0].Rows[0]["FirstWeek"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LastWeek"].ToString()!="")
				{
					model.LastWeek=DateTime.Parse(ds.Tables[0].Rows[0]["LastWeek"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isWork"].ToString()!="")
				{
					model.isWork=int.Parse(ds.Tables[0].Rows[0]["isWork"].ToString());
				}
				model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
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
			strSql.Append("select ID,DATETIME,CONTENTS,FirstWeek,LastWeek,DELFLAG,isWork,UserID ");
			strSql.Append(" FROM Term_Diary ");
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
			strSql.Append(" ID,DATETIME,CONTENTS,FirstWeek,LastWeek,DELFLAG,isWork,UserID ");
			strSql.Append(" FROM Term_Diary ");
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
			parameters[0].Value = "Term_Diary";
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

