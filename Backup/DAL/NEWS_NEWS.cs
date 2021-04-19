using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类News_News。
	/// </summary>
	public class News_News
	{
		public News_News()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "News_News"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from News_News");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.News_News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into News_News(");
			strSql.Append("NAME,PARENTID,DATETIME,CONTENTS,TYPE,KEYWORD,WRITER,SOURCE,MINIPIC,FILEUP,UPTOP,DELFLAG,ISPASS,IsLimits,LimitsChoose)");
			strSql.Append(" values (");
			strSql.Append("@NAME,@PARENTID,@DATETIME,@CONTENTS,@TYPE,@KEYWORD,@WRITER,@SOURCE,@MINIPIC,@FILEUP,@UPTOP,@DELFLAG,@ISPASS,@IsLimits,@LimitsChoose)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NAME", SqlDbType.VarChar,300),
					new SqlParameter("@PARENTID", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@CONTENTS", SqlDbType.Text),
					new SqlParameter("@TYPE", SqlDbType.Int,4),
					new SqlParameter("@KEYWORD", SqlDbType.VarChar,500),
					new SqlParameter("@WRITER", SqlDbType.VarChar,50),
					new SqlParameter("@SOURCE", SqlDbType.VarChar,50),
					new SqlParameter("@MINIPIC", SqlDbType.VarChar,100),
					new SqlParameter("@FILEUP", SqlDbType.VarChar,100),
					new SqlParameter("@UPTOP", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@ISPASS", SqlDbType.Int,4),
					new SqlParameter("@IsLimits", SqlDbType.Int,4),
					new SqlParameter("@LimitsChoose", SqlDbType.Int,4)};
			parameters[0].Value = model.NAME;
			parameters[1].Value = model.PARENTID;
			parameters[2].Value = model.DATETIME;
			parameters[3].Value = model.CONTENTS;
			parameters[4].Value = model.TYPE;
			parameters[5].Value = model.KEYWORD;
			parameters[6].Value = model.WRITER;
			parameters[7].Value = model.SOURCE;
			parameters[8].Value = model.MINIPIC;
			parameters[9].Value = model.FILEUP;
			parameters[10].Value = model.UPTOP;
			parameters[11].Value = model.DELFLAG;
			parameters[12].Value = model.ISPASS;
			parameters[13].Value = model.IsLimits;
			parameters[14].Value = model.LimitsChoose;

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
		public void Update(Dianda.Model.News_News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update News_News set ");
			strSql.Append("NAME=@NAME,");
			strSql.Append("PARENTID=@PARENTID,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("CONTENTS=@CONTENTS,");
			strSql.Append("TYPE=@TYPE,");
			strSql.Append("KEYWORD=@KEYWORD,");
			strSql.Append("WRITER=@WRITER,");
			strSql.Append("SOURCE=@SOURCE,");
			strSql.Append("MINIPIC=@MINIPIC,");
			strSql.Append("FILEUP=@FILEUP,");
			strSql.Append("UPTOP=@UPTOP,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("ISPASS=@ISPASS,");
			strSql.Append("IsLimits=@IsLimits,");
			strSql.Append("LimitsChoose=@LimitsChoose");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@NAME", SqlDbType.VarChar,300),
					new SqlParameter("@PARENTID", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@CONTENTS", SqlDbType.Text),
					new SqlParameter("@TYPE", SqlDbType.Int,4),
					new SqlParameter("@KEYWORD", SqlDbType.VarChar,500),
					new SqlParameter("@WRITER", SqlDbType.VarChar,50),
					new SqlParameter("@SOURCE", SqlDbType.VarChar,50),
					new SqlParameter("@MINIPIC", SqlDbType.VarChar,100),
					new SqlParameter("@FILEUP", SqlDbType.VarChar,100),
					new SqlParameter("@UPTOP", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@ISPASS", SqlDbType.Int,4),
					new SqlParameter("@IsLimits", SqlDbType.Int,4),
					new SqlParameter("@LimitsChoose", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.PARENTID;
			parameters[3].Value = model.DATETIME;
			parameters[4].Value = model.CONTENTS;
			parameters[5].Value = model.TYPE;
			parameters[6].Value = model.KEYWORD;
			parameters[7].Value = model.WRITER;
			parameters[8].Value = model.SOURCE;
			parameters[9].Value = model.MINIPIC;
			parameters[10].Value = model.FILEUP;
			parameters[11].Value = model.UPTOP;
			parameters[12].Value = model.DELFLAG;
			parameters[13].Value = model.ISPASS;
			parameters[14].Value = model.IsLimits;
			parameters[15].Value = model.LimitsChoose;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from News_News ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.News_News GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,NAME,PARENTID,DATETIME,CONTENTS,TYPE,KEYWORD,WRITER,SOURCE,MINIPIC,FILEUP,UPTOP,DELFLAG,ISPASS,IsLimits,LimitsChoose from News_News ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.News_News model=new Dianda.Model.News_News();
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
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				model.CONTENTS=ds.Tables[0].Rows[0]["CONTENTS"].ToString();
				if(ds.Tables[0].Rows[0]["TYPE"].ToString()!="")
				{
					model.TYPE=int.Parse(ds.Tables[0].Rows[0]["TYPE"].ToString());
				}
				model.KEYWORD=ds.Tables[0].Rows[0]["KEYWORD"].ToString();
				model.WRITER=ds.Tables[0].Rows[0]["WRITER"].ToString();
				model.SOURCE=ds.Tables[0].Rows[0]["SOURCE"].ToString();
				model.MINIPIC=ds.Tables[0].Rows[0]["MINIPIC"].ToString();
				model.FILEUP=ds.Tables[0].Rows[0]["FILEUP"].ToString();
				if(ds.Tables[0].Rows[0]["UPTOP"].ToString()!="")
				{
					model.UPTOP=int.Parse(ds.Tables[0].Rows[0]["UPTOP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ISPASS"].ToString()!="")
				{
					model.ISPASS=int.Parse(ds.Tables[0].Rows[0]["ISPASS"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsLimits"].ToString()!="")
				{
					model.IsLimits=int.Parse(ds.Tables[0].Rows[0]["IsLimits"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LimitsChoose"].ToString()!="")
				{
					model.LimitsChoose=int.Parse(ds.Tables[0].Rows[0]["LimitsChoose"].ToString());
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
			strSql.Append("select ID,NAME,PARENTID,DATETIME,CONTENTS,TYPE,KEYWORD,WRITER,SOURCE,MINIPIC,FILEUP,UPTOP,DELFLAG,ISPASS,IsLimits,LimitsChoose ");
			strSql.Append(" FROM News_News ");
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
			strSql.Append(" ID,NAME,PARENTID,DATETIME,CONTENTS,TYPE,KEYWORD,WRITER,SOURCE,MINIPIC,FILEUP,UPTOP,DELFLAG,ISPASS,IsLimits,LimitsChoose ");
			strSql.Append(" FROM News_News ");
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
			parameters[0].Value = "News_News";
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

