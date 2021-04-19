using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Document_Folder。
	/// </summary>
	public class Document_Folder
	{
		public Document_Folder()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Document_Folder"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Document_Folder");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Document_Folder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Document_Folder(");
			strSql.Append("FolderName,UpID,Types,UserID,ProjectID,IsShare,DELFLAG,DATETIME,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES,SizeOf)");
			strSql.Append(" values (");
			strSql.Append("@FolderName,@UpID,@Types,@UserID,@ProjectID,@IsShare,@DELFLAG,@DATETIME,@COLUMNSPATH,@SHUNXU,@IMAGEURL,@PNAMES,@SizeOf)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FolderName", SqlDbType.VarChar,50),
					new SqlParameter("@UpID", SqlDbType.Int,4),
					new SqlParameter("@Types", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@IsShare", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@COLUMNSPATH", SqlDbType.VarChar,1000),
					new SqlParameter("@SHUNXU", SqlDbType.Int,4),
					new SqlParameter("@IMAGEURL", SqlDbType.VarChar,100),
					new SqlParameter("@PNAMES", SqlDbType.VarChar,1000),
					new SqlParameter("@SizeOf", SqlDbType.VarChar,50)};
			parameters[0].Value = model.FolderName;
			parameters[1].Value = model.UpID;
			parameters[2].Value = model.Types;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.ProjectID;
			parameters[5].Value = model.IsShare;
			parameters[6].Value = model.DELFLAG;
			parameters[7].Value = model.DATETIME;
			parameters[8].Value = model.COLUMNSPATH;
			parameters[9].Value = model.SHUNXU;
			parameters[10].Value = model.IMAGEURL;
			parameters[11].Value = model.PNAMES;
			parameters[12].Value = model.SizeOf;

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
		public void Update(Dianda.Model.Document_Folder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Document_Folder set ");
			strSql.Append("FolderName=@FolderName,");
			strSql.Append("UpID=@UpID,");
			strSql.Append("Types=@Types,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("ProjectID=@ProjectID,");
			strSql.Append("IsShare=@IsShare,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("COLUMNSPATH=@COLUMNSPATH,");
			strSql.Append("SHUNXU=@SHUNXU,");
			strSql.Append("IMAGEURL=@IMAGEURL,");
			strSql.Append("PNAMES=@PNAMES,");
			strSql.Append("SizeOf=@SizeOf");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@FolderName", SqlDbType.VarChar,50),
					new SqlParameter("@UpID", SqlDbType.Int,4),
					new SqlParameter("@Types", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@IsShare", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@COLUMNSPATH", SqlDbType.VarChar,1000),
					new SqlParameter("@SHUNXU", SqlDbType.Int,4),
					new SqlParameter("@IMAGEURL", SqlDbType.VarChar,100),
					new SqlParameter("@PNAMES", SqlDbType.VarChar,1000),
					new SqlParameter("@SizeOf", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.FolderName;
			parameters[2].Value = model.UpID;
			parameters[3].Value = model.Types;
			parameters[4].Value = model.UserID;
			parameters[5].Value = model.ProjectID;
			parameters[6].Value = model.IsShare;
			parameters[7].Value = model.DELFLAG;
			parameters[8].Value = model.DATETIME;
			parameters[9].Value = model.COLUMNSPATH;
			parameters[10].Value = model.SHUNXU;
			parameters[11].Value = model.IMAGEURL;
			parameters[12].Value = model.PNAMES;
			parameters[13].Value = model.SizeOf;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Document_Folder ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Document_Folder GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,FolderName,UpID,Types,UserID,ProjectID,IsShare,DELFLAG,DATETIME,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES,SizeOf from Document_Folder ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Document_Folder model=new Dianda.Model.Document_Folder();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.FolderName=ds.Tables[0].Rows[0]["FolderName"].ToString();
				if(ds.Tables[0].Rows[0]["UpID"].ToString()!="")
				{
					model.UpID=int.Parse(ds.Tables[0].Rows[0]["UpID"].ToString());
				}
				model.Types=ds.Tables[0].Rows[0]["Types"].ToString();
				model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
				if(ds.Tables[0].Rows[0]["ProjectID"].ToString()!="")
				{
					model.ProjectID=int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsShare"].ToString()!="")
				{
					model.IsShare=int.Parse(ds.Tables[0].Rows[0]["IsShare"].ToString());
				}
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
				model.SizeOf=ds.Tables[0].Rows[0]["SizeOf"].ToString();
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
			strSql.Append("select ID,FolderName,UpID,Types,UserID,ProjectID,IsShare,DELFLAG,DATETIME,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES,SizeOf ");
			strSql.Append(" FROM Document_Folder ");
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
			strSql.Append(" ID,FolderName,UpID,Types,UserID,ProjectID,IsShare,DELFLAG,DATETIME,COLUMNSPATH,SHUNXU,IMAGEURL,PNAMES,SizeOf ");
			strSql.Append(" FROM Document_Folder ");
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
			parameters[0].Value = "Document_Folder";
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

