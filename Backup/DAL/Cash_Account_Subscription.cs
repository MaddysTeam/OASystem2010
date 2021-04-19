using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类:Cash_Account_Subscription
	/// </summary>
	public partial class Cash_Account_Subscription
	{
		public Cash_Account_Subscription()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Cash_Account_Subscription model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Cash_Account_Subscription(");
			strSql.Append("AccountID,ApplyDatetime,Subscription)");
			strSql.Append(" values (");
			strSql.Append("@AccountID,@ApplyDatetime,@Subscription)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AccountID", SqlDbType.Int,4),
					new SqlParameter("@ApplyDatetime", SqlDbType.DateTime),
					new SqlParameter("@Subscription", SqlDbType.Float,8)};
			parameters[0].Value = model.AccountID;
			parameters[1].Value = model.ApplyDatetime;
			parameters[2].Value = model.Subscription;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Dianda.Model.Cash_Account_Subscription model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Cash_Account_Subscription set ");
			strSql.Append("AccountID=@AccountID,");
			strSql.Append("ApplyDatetime=@ApplyDatetime,");
			strSql.Append("Subscription=@Subscription");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@AccountID", SqlDbType.Int,4),
					new SqlParameter("@ApplyDatetime", SqlDbType.DateTime),
					new SqlParameter("@Subscription", SqlDbType.Float,8),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.AccountID;
			parameters[1].Value = model.ApplyDatetime;
			parameters[2].Value = model.Subscription;
			parameters[3].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cash_Account_Subscription ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cash_Account_Subscription ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Cash_Account_Subscription GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,AccountID,ApplyDatetime,Subscription from Cash_Account_Subscription ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			Dianda.Model.Cash_Account_Subscription model=new Dianda.Model.Cash_Account_Subscription();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AccountID"]!=null && ds.Tables[0].Rows[0]["AccountID"].ToString()!="")
				{
					model.AccountID=int.Parse(ds.Tables[0].Rows[0]["AccountID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApplyDatetime"]!=null && ds.Tables[0].Rows[0]["ApplyDatetime"].ToString()!="")
				{
					model.ApplyDatetime=DateTime.Parse(ds.Tables[0].Rows[0]["ApplyDatetime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Subscription"]!=null && ds.Tables[0].Rows[0]["Subscription"].ToString()!="")
				{
					model.Subscription=decimal.Parse(ds.Tables[0].Rows[0]["Subscription"].ToString());
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
			strSql.Append("select id,AccountID,ApplyDatetime,Subscription ");
			strSql.Append(" FROM Cash_Account_Subscription ");
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
			strSql.Append(" id,AccountID,ApplyDatetime,Subscription ");
			strSql.Append(" FROM Cash_Account_Subscription ");
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
			parameters[0].Value = "Cash_Account_Subscription";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

