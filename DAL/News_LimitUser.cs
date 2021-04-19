using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类News_LimitUser。
	/// </summary>
	public class News_LimitUser
	{
		public News_LimitUser()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "News_LimitUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from News_LimitUser");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.News_LimitUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into News_LimitUser(");
			strSql.Append("UserID,NewsID,IsRead,ReadTime)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@NewsID,@IsRead,@ReadTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@ReadTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.NewsID;
			parameters[2].Value = model.IsRead;
			parameters[3].Value = model.ReadTime;

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
		public void Update(Dianda.Model.News_LimitUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update News_LimitUser set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("NewsID=@NewsID,");
			strSql.Append("IsRead=@IsRead,");
			strSql.Append("ReadTime=@ReadTime");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@NewsID", SqlDbType.Int,4),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@ReadTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.NewsID;
			parameters[3].Value = model.IsRead;
			parameters[4].Value = model.ReadTime;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from News_LimitUser ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.News_LimitUser GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,NewsID,IsRead,ReadTime from News_LimitUser ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.News_LimitUser model=new Dianda.Model.News_LimitUser();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
				if(ds.Tables[0].Rows[0]["NewsID"].ToString()!="")
				{
					model.NewsID=int.Parse(ds.Tables[0].Rows[0]["NewsID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReadTime"].ToString()!="")
				{
					model.ReadTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReadTime"].ToString());
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
			strSql.Append("select ID,UserID,NewsID,IsRead,ReadTime ");
			strSql.Append(" FROM News_LimitUser ");
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
			strSql.Append(" ID,UserID,NewsID,IsRead,ReadTime ");
			strSql.Append(" FROM News_LimitUser ");
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
			parameters[0].Value = "News_LimitUser";
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

