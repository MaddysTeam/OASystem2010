using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Document_Folder_Share。
	/// </summary>
	public class Document_Folder_Share
	{
		public Document_Folder_Share()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Document_Folder_Share"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Document_Folder_Share");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Document_Folder_Share model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Document_Folder_Share(");
			strSql.Append("FolderID,ShareForUser,DATETIME)");
			strSql.Append(" values (");
			strSql.Append("@FolderID,@ShareForUser,@DATETIME)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FolderID", SqlDbType.Int,4),
					new SqlParameter("@ShareForUser", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime)};
			parameters[0].Value = model.FolderID;
			parameters[1].Value = model.ShareForUser;
			parameters[2].Value = model.DATETIME;

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
		public void Update(Dianda.Model.Document_Folder_Share model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Document_Folder_Share set ");
			strSql.Append("FolderID=@FolderID,");
			strSql.Append("ShareForUser=@ShareForUser,");
			strSql.Append("DATETIME=@DATETIME");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@FolderID", SqlDbType.Int,4),
					new SqlParameter("@ShareForUser", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.FolderID;
			parameters[2].Value = model.ShareForUser;
			parameters[3].Value = model.DATETIME;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Document_Folder_Share ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Document_Folder_Share GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,FolderID,ShareForUser,DATETIME from Document_Folder_Share ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Document_Folder_Share model=new Dianda.Model.Document_Folder_Share();
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
				model.ShareForUser=ds.Tables[0].Rows[0]["ShareForUser"].ToString();
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
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
			strSql.Append("select ID,FolderID,ShareForUser,DATETIME ");
			strSql.Append(" FROM Document_Folder_Share ");
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
			strSql.Append(" ID,FolderID,ShareForUser,DATETIME ");
			strSql.Append(" FROM Document_Folder_Share ");
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
			parameters[0].Value = "Document_Folder_Share";
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

