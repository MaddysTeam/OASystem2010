using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类USER_Groups。
	/// </summary>
	public class USER_Groups
	{
		public USER_Groups()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from USER_Groups");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Dianda.Model.USER_Groups model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into USER_Groups(");
			strSql.Append("ID,NAME,CONTENTS,ROLE,DELFLAG,ISMOREN,TAGS)");
			strSql.Append(" values (");
			strSql.Append("@ID,@NAME,@CONTENTS,@ROLE,@DELFLAG,@ISMOREN,@TAGS)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.VarChar,50),
					new SqlParameter("@CONTENTS", SqlDbType.Text),
					new SqlParameter("@ROLE", SqlDbType.Text),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@ISMOREN", SqlDbType.Int,4),
					new SqlParameter("@TAGS", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.CONTENTS;
			parameters[3].Value = model.ROLE;
			parameters[4].Value = model.DELFLAG;
			parameters[5].Value = model.ISMOREN;
			parameters[6].Value = model.TAGS;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.USER_Groups model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update USER_Groups set ");
			strSql.Append("NAME=@NAME,");
			strSql.Append("CONTENTS=@CONTENTS,");
			strSql.Append("ROLE=@ROLE,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("ISMOREN=@ISMOREN,");
			strSql.Append("TAGS=@TAGS");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.VarChar,50),
					new SqlParameter("@CONTENTS", SqlDbType.Text),
					new SqlParameter("@ROLE", SqlDbType.Text),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@ISMOREN", SqlDbType.Int,4),
					new SqlParameter("@TAGS", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.CONTENTS;
			parameters[3].Value = model.ROLE;
			parameters[4].Value = model.DELFLAG;
			parameters[5].Value = model.ISMOREN;
			parameters[6].Value = model.TAGS;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from USER_Groups ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.USER_Groups GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,NAME,CONTENTS,ROLE,DELFLAG,ISMOREN,TAGS from USER_Groups ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			Dianda.Model.USER_Groups model=new Dianda.Model.USER_Groups();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ID=ds.Tables[0].Rows[0]["ID"].ToString();
				model.NAME=ds.Tables[0].Rows[0]["NAME"].ToString();
				model.CONTENTS=ds.Tables[0].Rows[0]["CONTENTS"].ToString();
				model.ROLE=ds.Tables[0].Rows[0]["ROLE"].ToString();
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ISMOREN"].ToString()!="")
				{
					model.ISMOREN=int.Parse(ds.Tables[0].Rows[0]["ISMOREN"].ToString());
				}
				model.TAGS=ds.Tables[0].Rows[0]["TAGS"].ToString();
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
			strSql.Append("select ID,NAME,CONTENTS,ROLE,DELFLAG,ISMOREN,TAGS ");
			strSql.Append(" FROM USER_Groups ");
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
			strSql.Append(" ID,NAME,CONTENTS,ROLE,DELFLAG,ISMOREN,TAGS ");
			strSql.Append(" FROM USER_Groups ");
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
			parameters[0].Value = "USER_Groups";
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

