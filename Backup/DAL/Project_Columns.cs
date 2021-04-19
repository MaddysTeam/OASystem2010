using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Project_Columns。
	/// </summary>
	public class Project_Columns
	{
		public Project_Columns()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Project_Columns"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Project_Columns");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Project_Columns model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Project_Columns(");
			strSql.Append("Names,UpID,UserID,UserInfos,DELFLAG,DATETIME,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES,TYPES,INFORS)");
			strSql.Append(" values (");
			strSql.Append("@Names,@UpID,@UserID,@UserInfos,@DELFLAG,@DATETIME,@COLUMNSPATH,@SHUNXU,@IMAGEURL,@PNAMES,@TYPES,@INFORS)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Names", SqlDbType.VarChar,50),
					new SqlParameter("@UpID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Text),
					new SqlParameter("@UserInfos", SqlDbType.Text),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@COLUMNSPATH", SqlDbType.VarChar,1000),
					new SqlParameter("@SHUNXU", SqlDbType.Int,4),
					new SqlParameter("@IMAGEURL", SqlDbType.VarChar,100),
					new SqlParameter("@PNAMES", SqlDbType.VarChar,1000),
					new SqlParameter("@TYPES", SqlDbType.VarChar,50),
					new SqlParameter("@INFORS", SqlDbType.Text)};
			parameters[0].Value = model.Names;
			parameters[1].Value = model.UpID;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.UserInfos;
			parameters[4].Value = model.DELFLAG;
			parameters[5].Value = model.DATETIME;
			parameters[6].Value = model.COLUMNSPATH;
			parameters[7].Value = model.SHUNXU;
			parameters[8].Value = model.IMAGEURL;
			parameters[9].Value = model.PNAMES;
			parameters[10].Value = model.TYPES;
			parameters[11].Value = model.INFORS;

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
		public void Update(Dianda.Model.Project_Columns model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Project_Columns set ");
			strSql.Append("Names=@Names,");
			strSql.Append("UpID=@UpID,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserInfos=@UserInfos,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("COLUMNSPATH=@COLUMNSPATH,");
			strSql.Append("SHUNXU=@SHUNXU,");
			strSql.Append("IMAGEURL=@IMAGEURL,");
			strSql.Append("PNAMES=@PNAMES,");
			strSql.Append("TYPES=@TYPES,");
			strSql.Append("INFORS=@INFORS");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Names", SqlDbType.VarChar,50),
					new SqlParameter("@UpID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Text),
					new SqlParameter("@UserInfos", SqlDbType.Text),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@COLUMNSPATH", SqlDbType.VarChar,1000),
					new SqlParameter("@SHUNXU", SqlDbType.Int,4),
					new SqlParameter("@IMAGEURL", SqlDbType.VarChar,100),
					new SqlParameter("@PNAMES", SqlDbType.VarChar,1000),
					new SqlParameter("@TYPES", SqlDbType.VarChar,50),
					new SqlParameter("@INFORS", SqlDbType.Text)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Names;
			parameters[2].Value = model.UpID;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.UserInfos;
			parameters[5].Value = model.DELFLAG;
			parameters[6].Value = model.DATETIME;
			parameters[7].Value = model.COLUMNSPATH;
			parameters[8].Value = model.SHUNXU;
			parameters[9].Value = model.IMAGEURL;
			parameters[10].Value = model.PNAMES;
			parameters[11].Value = model.TYPES;
			parameters[12].Value = model.INFORS;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Project_Columns ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Project_Columns GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Names,UpID,UserID,UserInfos,DELFLAG,DATETIME,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES,TYPES,INFORS from Project_Columns ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Project_Columns model=new Dianda.Model.Project_Columns();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.Names=ds.Tables[0].Rows[0]["Names"].ToString();
				if(ds.Tables[0].Rows[0]["UpID"].ToString()!="")
				{
					model.UpID=int.Parse(ds.Tables[0].Rows[0]["UpID"].ToString());
				}
				model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
				model.UserInfos=ds.Tables[0].Rows[0]["UserInfos"].ToString();
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				model.COLUMNSPATH=ds.Tables[0].Rows[0]["COLUMNSPATH"].ToString();
				if(ds.Tables[0].Rows[0]["SHUNXU"].ToString()!="")
				{
					model.SHUNXU=int.Parse(ds.Tables[0].Rows[0]["SHUNXU"].ToString());
				}
				model.IMAGEURL=ds.Tables[0].Rows[0]["IMAGEURL"].ToString();
				model.PNAMES=ds.Tables[0].Rows[0]["PNAMES"].ToString();
				model.TYPES=ds.Tables[0].Rows[0]["TYPES"].ToString();
				model.INFORS=ds.Tables[0].Rows[0]["INFORS"].ToString();
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
			strSql.Append("select ID,Names,UpID,UserID,UserInfos,DELFLAG,DATETIME,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES,TYPES,INFORS ");
			strSql.Append(" FROM Project_Columns ");
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
			strSql.Append(" ID,Names,UpID,UserID,UserInfos,DELFLAG,DATETIME,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES,TYPES,INFORS ");
			strSql.Append(" FROM Project_Columns ");
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
			parameters[0].Value = "Project_Columns";
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

