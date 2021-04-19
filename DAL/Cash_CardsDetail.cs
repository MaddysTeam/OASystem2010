using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类:Cash_CardsDetail
	/// </summary>
	public partial class Cash_CardsDetail
	{
		public Cash_CardsDetail()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Cash_CardsDetail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cash_CardsDetail");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Cash_CardsDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Cash_CardsDetail(");
			strSql.Append("CardID,DetailID,Balance,Unit,TypesName,Oldbalance,KYbalance,DetailName)");
			strSql.Append(" values (");
			strSql.Append("@CardID,@DetailID,@Balance,@Unit,@TypesName,@Oldbalance,@KYbalance,@DetailName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CardID", SqlDbType.Int,4),
					new SqlParameter("@DetailID", SqlDbType.Int,4),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@Unit", SqlDbType.Int,4),
					new SqlParameter("@TypesName", SqlDbType.VarChar,50),
					new SqlParameter("@Oldbalance", SqlDbType.Float,8),
					new SqlParameter("@KYbalance", SqlDbType.Float,8),
					new SqlParameter("@DetailName", SqlDbType.NVarChar,8)};
			parameters[0].Value = model.CardID;
			parameters[1].Value = model.DetailID;
			parameters[2].Value = model.Balance;
			parameters[3].Value = model.Unit;
			parameters[4].Value = model.TypesName;
			parameters[5].Value = model.Oldbalance;
			parameters[6].Value = model.KYbalance;
			parameters[7].Value = model.DetailName;

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
		public bool Update(Dianda.Model.Cash_CardsDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Cash_CardsDetail set ");
			strSql.Append("CardID=@CardID,");
			strSql.Append("DetailID=@DetailID,");
			strSql.Append("Balance=@Balance,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("TypesName=@TypesName,");
			strSql.Append("Oldbalance=@Oldbalance,");
			strSql.Append("KYbalance=@KYbalance,");
			strSql.Append("DetailName=@DetailName");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CardID", SqlDbType.Int,4),
					new SqlParameter("@DetailID", SqlDbType.Int,4),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@Unit", SqlDbType.Int,4),
					new SqlParameter("@TypesName", SqlDbType.VarChar,50),
					new SqlParameter("@Oldbalance", SqlDbType.Float,8),
					new SqlParameter("@KYbalance", SqlDbType.Float,8),
					new SqlParameter("@DetailName", SqlDbType.NVarChar,8),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.CardID;
			parameters[1].Value = model.DetailID;
			parameters[2].Value = model.Balance;
			parameters[3].Value = model.Unit;
			parameters[4].Value = model.TypesName;
			parameters[5].Value = model.Oldbalance;
			parameters[6].Value = model.KYbalance;
			parameters[7].Value = model.DetailName;
			parameters[8].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cash_CardsDetail ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cash_CardsDetail ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Dianda.Model.Cash_CardsDetail GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CardID,DetailID,Balance,Unit,TypesName,Oldbalance,KYbalance,DetailName from Cash_CardsDetail ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			Dianda.Model.Cash_CardsDetail model=new Dianda.Model.Cash_CardsDetail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardID"]!=null && ds.Tables[0].Rows[0]["CardID"].ToString()!="")
				{
					model.CardID=int.Parse(ds.Tables[0].Rows[0]["CardID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DetailID"]!=null && ds.Tables[0].Rows[0]["DetailID"].ToString()!="")
				{
					model.DetailID=int.Parse(ds.Tables[0].Rows[0]["DetailID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Balance"]!=null && ds.Tables[0].Rows[0]["Balance"].ToString()!="")
				{
					model.Balance=decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Unit"]!=null && ds.Tables[0].Rows[0]["Unit"].ToString()!="")
				{
					model.Unit=int.Parse(ds.Tables[0].Rows[0]["Unit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TypesName"]!=null && ds.Tables[0].Rows[0]["TypesName"].ToString()!="")
				{
					model.TypesName=ds.Tables[0].Rows[0]["TypesName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Oldbalance"]!=null && ds.Tables[0].Rows[0]["Oldbalance"].ToString()!="")
				{
					model.Oldbalance=decimal.Parse(ds.Tables[0].Rows[0]["Oldbalance"].ToString());
				}
				if(ds.Tables[0].Rows[0]["KYbalance"]!=null && ds.Tables[0].Rows[0]["KYbalance"].ToString()!="")
				{
					model.KYbalance=decimal.Parse(ds.Tables[0].Rows[0]["KYbalance"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DetailName"]!=null && ds.Tables[0].Rows[0]["DetailName"].ToString()!="")
				{
					model.DetailName=ds.Tables[0].Rows[0]["DetailName"].ToString();
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
			strSql.Append("select ID,CardID,DetailID,Balance,Unit,TypesName,Oldbalance,KYbalance,DetailName ");
			strSql.Append(" FROM Cash_CardsDetail ");
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
			strSql.Append(" ID,CardID,DetailID,Balance,Unit,TypesName,Oldbalance,KYbalance,DetailName ");
			strSql.Append(" FROM Cash_CardsDetail ");
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
			parameters[0].Value = "Cash_CardsDetail";
			parameters[1].Value = "ID";
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

