using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类GUESTBOOK_MAIN。
	/// </summary>
	public class GUESTBOOK_MAIN
	{
		public GUESTBOOK_MAIN()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GUESTBOOK_MAIN");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Dianda.Model.GUESTBOOK_MAIN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GUESTBOOK_MAIN(");
			strSql.Append("ID,TITLES,CLASSID,CONTENTS,RE_CONTENTS,STATUS,WRITER,DATETIME,RE_DATETIME,DELFLAG,COURSEID)");
			strSql.Append(" values (");
			strSql.Append("@ID,@TITLES,@CLASSID,@CONTENTS,@RE_CONTENTS,@STATUS,@WRITER,@DATETIME,@RE_DATETIME,@DELFLAG,@COURSEID)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@TITLES", SqlDbType.VarChar,500),
					new SqlParameter("@CLASSID", SqlDbType.VarChar,500),
					new SqlParameter("@CONTENTS", SqlDbType.Text),
					new SqlParameter("@RE_CONTENTS", SqlDbType.Text),
					new SqlParameter("@STATUS", SqlDbType.Int,4),
					new SqlParameter("@WRITER", SqlDbType.VarChar,500),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@RE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@COURSEID", SqlDbType.VarChar,500)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.TITLES;
			parameters[2].Value = model.CLASSID;
			parameters[3].Value = model.CONTENTS;
			parameters[4].Value = model.RE_CONTENTS;
			parameters[5].Value = model.STATUS;
			parameters[6].Value = model.WRITER;
			parameters[7].Value = model.DATETIME;
			parameters[8].Value = model.RE_DATETIME;
			parameters[9].Value = model.DELFLAG;
			parameters[10].Value = model.COURSEID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.GUESTBOOK_MAIN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GUESTBOOK_MAIN set ");
			strSql.Append("TITLES=@TITLES,");
			strSql.Append("CLASSID=@CLASSID,");
			strSql.Append("CONTENTS=@CONTENTS,");
			strSql.Append("RE_CONTENTS=@RE_CONTENTS,");
			strSql.Append("STATUS=@STATUS,");
			strSql.Append("WRITER=@WRITER,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("RE_DATETIME=@RE_DATETIME,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("COURSEID=@COURSEID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@TITLES", SqlDbType.VarChar,500),
					new SqlParameter("@CLASSID", SqlDbType.VarChar,500),
					new SqlParameter("@CONTENTS", SqlDbType.Text),
					new SqlParameter("@RE_CONTENTS", SqlDbType.Text),
					new SqlParameter("@STATUS", SqlDbType.Int,4),
					new SqlParameter("@WRITER", SqlDbType.VarChar,500),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@RE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@COURSEID", SqlDbType.VarChar,500)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.TITLES;
			parameters[2].Value = model.CLASSID;
			parameters[3].Value = model.CONTENTS;
			parameters[4].Value = model.RE_CONTENTS;
			parameters[5].Value = model.STATUS;
			parameters[6].Value = model.WRITER;
			parameters[7].Value = model.DATETIME;
			parameters[8].Value = model.RE_DATETIME;
			parameters[9].Value = model.DELFLAG;
			parameters[10].Value = model.COURSEID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete GUESTBOOK_MAIN ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.GUESTBOOK_MAIN GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,TITLES,CLASSID,CONTENTS,RE_CONTENTS,STATUS,WRITER,DATETIME,RE_DATETIME,DELFLAG,COURSEID from GUESTBOOK_MAIN ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			Dianda.Model.GUESTBOOK_MAIN model=new Dianda.Model.GUESTBOOK_MAIN();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ID=ds.Tables[0].Rows[0]["ID"].ToString();
				model.TITLES=ds.Tables[0].Rows[0]["TITLES"].ToString();
				model.CLASSID=ds.Tables[0].Rows[0]["CLASSID"].ToString();
				model.CONTENTS=ds.Tables[0].Rows[0]["CONTENTS"].ToString();
				model.RE_CONTENTS=ds.Tables[0].Rows[0]["RE_CONTENTS"].ToString();
				if(ds.Tables[0].Rows[0]["STATUS"].ToString()!="")
				{
					model.STATUS=int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString());
				}
				model.WRITER=ds.Tables[0].Rows[0]["WRITER"].ToString();
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RE_DATETIME"].ToString()!="")
				{
					model.RE_DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["RE_DATETIME"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				model.COURSEID=ds.Tables[0].Rows[0]["COURSEID"].ToString();
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
			strSql.Append("select ID,TITLES,CLASSID,CONTENTS,RE_CONTENTS,STATUS,WRITER,DATETIME,RE_DATETIME,DELFLAG,COURSEID ");
			strSql.Append(" FROM GUESTBOOK_MAIN ");
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
			parameters[0].Value = "GUESTBOOK_MAIN";
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

