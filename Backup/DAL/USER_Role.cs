using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类USER_Role。
	/// </summary>
	public class USER_Role
	{
		public USER_Role()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "USER_Role"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from USER_Role");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.USER_Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into USER_Role(");
			strSql.Append("NAME,Roles,Types,UpID,DELFLAG)");
			strSql.Append(" values (");
			strSql.Append("@NAME,@Roles,@Types,@UpID,@DELFLAG)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@Roles", SqlDbType.VarChar,800),
					new SqlParameter("@Types", SqlDbType.VarChar,50),
					new SqlParameter("@UpID", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4)};
			parameters[0].Value = model.NAME;
			parameters[1].Value = model.Roles;
			parameters[2].Value = model.Types;
			parameters[3].Value = model.UpID;
			parameters[4].Value = model.DELFLAG;

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
		public void Update(Dianda.Model.USER_Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update USER_Role set ");
			strSql.Append("NAME=@NAME,");
			strSql.Append("Roles=@Roles,");
			strSql.Append("Types=@Types,");
			strSql.Append("UpID=@UpID,");
			strSql.Append("DELFLAG=@DELFLAG");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@Roles", SqlDbType.VarChar,800),
					new SqlParameter("@Types", SqlDbType.VarChar,50),
					new SqlParameter("@UpID", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.Roles;
			parameters[3].Value = model.Types;
			parameters[4].Value = model.UpID;
			parameters[5].Value = model.DELFLAG;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from USER_Role ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.USER_Role GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,NAME,Roles,Types,UpID,DELFLAG from USER_Role ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.USER_Role model=new Dianda.Model.USER_Role();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.NAME=ds.Tables[0].Rows[0]["NAME"].ToString();
				model.Roles=ds.Tables[0].Rows[0]["Roles"].ToString();
				model.Types=ds.Tables[0].Rows[0]["Types"].ToString();
				if(ds.Tables[0].Rows[0]["UpID"].ToString()!="")
				{
					model.UpID=int.Parse(ds.Tables[0].Rows[0]["UpID"].ToString());
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
			strSql.Append("select ID,NAME,Roles,Types,UpID,DELFLAG ");
			strSql.Append(" FROM USER_Role ");
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
			strSql.Append(" ID,NAME,Roles,Types,UpID,DELFLAG ");
			strSql.Append(" FROM USER_Role ");
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
			parameters[0].Value = "USER_Role";
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

