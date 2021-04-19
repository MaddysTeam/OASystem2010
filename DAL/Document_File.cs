using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Document_File。
	/// </summary>
	public class Document_File
	{
		public Document_File()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Document_File"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Document_File");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Document_File model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Document_File(");
			strSql.Append("FolderID,FileName,FileType,Icon,Sizeof,FilePath,IsShare,DELFLAG,DATETIME,UserID,ShareID)");
			strSql.Append(" values (");
			strSql.Append("@FolderID,@FileName,@FileType,@Icon,@Sizeof,@FilePath,@IsShare,@DELFLAG,@DATETIME,@UserID,@ShareID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FolderID", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.VarChar,100),
					new SqlParameter("@FileType", SqlDbType.VarChar,50),
					new SqlParameter("@Icon", SqlDbType.VarChar,100),
					new SqlParameter("@Sizeof", SqlDbType.Float,8),
					new SqlParameter("@FilePath", SqlDbType.VarChar,500),
					new SqlParameter("@IsShare", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@ShareID", SqlDbType.Int,4)};
			parameters[0].Value = model.FolderID;
			parameters[1].Value = model.FileName;
			parameters[2].Value = model.FileType;
			parameters[3].Value = model.Icon;
			parameters[4].Value = model.Sizeof;
			parameters[5].Value = model.FilePath;
			parameters[6].Value = model.IsShare;
			parameters[7].Value = model.DELFLAG;
			parameters[8].Value = model.DATETIME;
			parameters[9].Value = model.UserID;
			parameters[10].Value = model.ShareID;

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
		public void Update(Dianda.Model.Document_File model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Document_File set ");
			strSql.Append("FolderID=@FolderID,");
			strSql.Append("FileName=@FileName,");
			strSql.Append("FileType=@FileType,");
			strSql.Append("Icon=@Icon,");
			strSql.Append("Sizeof=@Sizeof,");
			strSql.Append("FilePath=@FilePath,");
			strSql.Append("IsShare=@IsShare,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("ShareID=@ShareID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@FolderID", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.VarChar,100),
					new SqlParameter("@FileType", SqlDbType.VarChar,50),
					new SqlParameter("@Icon", SqlDbType.VarChar,100),
					new SqlParameter("@Sizeof", SqlDbType.Float,8),
					new SqlParameter("@FilePath", SqlDbType.VarChar,500),
					new SqlParameter("@IsShare", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@ShareID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.FolderID;
			parameters[2].Value = model.FileName;
			parameters[3].Value = model.FileType;
			parameters[4].Value = model.Icon;
			parameters[5].Value = model.Sizeof;
			parameters[6].Value = model.FilePath;
			parameters[7].Value = model.IsShare;
			parameters[8].Value = model.DELFLAG;
			parameters[9].Value = model.DATETIME;
			parameters[10].Value = model.UserID;
			parameters[11].Value = model.ShareID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Document_File ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Document_File GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,FolderID,FileName,FileType,Icon,Sizeof,FilePath,IsShare,DELFLAG,DATETIME,UserID,ShareID from Document_File ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Document_File model=new Dianda.Model.Document_File();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FolderID"].ToString()!="")
				{
					model.FolderID=int.Parse(ds.Tables[0].Rows[0]["FolderID"].ToString());
				}
				model.FileName=ds.Tables[0].Rows[0]["FileName"].ToString();
				model.FileType=ds.Tables[0].Rows[0]["FileType"].ToString();
				model.Icon=ds.Tables[0].Rows[0]["Icon"].ToString();
				if(ds.Tables[0].Rows[0]["Sizeof"].ToString()!="")
				{
					model.Sizeof=decimal.Parse(ds.Tables[0].Rows[0]["Sizeof"].ToString());
				}
				model.FilePath=ds.Tables[0].Rows[0]["FilePath"].ToString();
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
				model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
				if(ds.Tables[0].Rows[0]["ShareID"].ToString()!="")
				{
					model.ShareID=int.Parse(ds.Tables[0].Rows[0]["ShareID"].ToString());
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
			strSql.Append("select ID,FolderID,FileName,FileType,Icon,Sizeof,FilePath,IsShare,DELFLAG,DATETIME,UserID,ShareID ");
			strSql.Append(" FROM Document_File ");
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
			strSql.Append(" ID,FolderID,FileName,FileType,Icon,Sizeof,FilePath,IsShare,DELFLAG,DATETIME,UserID,ShareID ");
			strSql.Append(" FROM Document_File ");
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
			parameters[0].Value = "Document_File";
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

