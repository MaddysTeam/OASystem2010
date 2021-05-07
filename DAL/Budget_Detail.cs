using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类:Budget_Detail
	/// </summary>
	public partial class Budget_Detail
	{
		public Budget_Detail()
		{}   
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Budget_Detail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Budget_Detail");
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
		public int Add(Dianda.Model.Budget_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Budget_Detail(");
			strSql.Append("[BudgetID],[Balance],[Unit],[Oldbalance],[KYbalance],[DetailName])");
			strSql.Append(" values (");
			strSql.Append("@BudgetID,@Balance,@Unit,@Oldbalance,@KYbalance,@DetailName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BudgetID", SqlDbType.Int,4),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@Unit", SqlDbType.Int,4),
					new SqlParameter("@Oldbalance", SqlDbType.Float,8),
					new SqlParameter("@KYbalance", SqlDbType.Float,8),
               new SqlParameter("@DetailName",SqlDbType.NVarChar)
			};
			parameters[0].Value = model.BudgetID;
			parameters[1].Value = model.Balance;
			parameters[2].Value = model.Unit;
			parameters[3].Value = model.Oldbalance;
			parameters[4].Value = model.KYbalance;
         parameters[5].Value = model.DetailName;

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
		public bool Update(Dianda.Model.Budget_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Budget_Detail set ");
			strSql.Append("BudgetID=@BudgetID,");
			strSql.Append("Balance=@Balance,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("Oldbalance=@Oldbalance,");
			strSql.Append("KYbalance=@KYbalance,");
         strSql.Append("DetailName=@DetailName ");
         strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
               new SqlParameter("@BudgetID", SqlDbType.Int,4),
               new SqlParameter("@Balance", SqlDbType.Float,8),
               new SqlParameter("@Unit", SqlDbType.Int,4),
               new SqlParameter("@Oldbalance", SqlDbType.Float,8),
               new SqlParameter("@KYbalance", SqlDbType.Float,8),
               new SqlParameter("@ID", SqlDbType.Int,4),
               new SqlParameter("@DetailName", SqlDbType.NVarChar)
         };
         parameters[0].Value = model.BudgetID;
			parameters[1].Value = model.Balance;
			parameters[2].Value = model.Unit;
			parameters[3].Value = model.Oldbalance;
			parameters[4].Value = model.KYbalance;
			parameters[5].Value = model.ID;
            parameters[6].Value = model.DetailName;

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
			strSql.Append("delete from Budget_Detail ");
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
			strSql.Append("delete from Budget_Detail ");
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
		public Dianda.Model.Budget_Detail GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT top 1 [ID],[BudgetID],[Balance],[Unit],[Oldbalance],[KYbalance] FROM [dbo].[Budget_Detail] ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Dianda.Model.Budget_Detail model =new Dianda.Model.Budget_Detail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BudgetID"] !=null && ds.Tables[0].Rows[0]["BudgetID"].ToString()!="")
				{
					model.BudgetID=int.Parse(ds.Tables[0].Rows[0]["BudgetID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Balance"]!=null && ds.Tables[0].Rows[0]["Balance"].ToString()!="")
				{
					model.Balance=decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Unit"]!=null && ds.Tables[0].Rows[0]["Unit"].ToString()!="")
				{
					model.Unit=int.Parse(ds.Tables[0].Rows[0]["Unit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Oldbalance"]!=null && ds.Tables[0].Rows[0]["Oldbalance"].ToString()!="")
				{
					model.Oldbalance=decimal.Parse(ds.Tables[0].Rows[0]["Oldbalance"].ToString());
				}
				if(ds.Tables[0].Rows[0]["KYbalance"]!=null && ds.Tables[0].Rows[0]["KYbalance"].ToString()!="")
				{
					model.KYbalance=decimal.Parse(ds.Tables[0].Rows[0]["KYbalance"].ToString());
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
			strSql.Append("select [ID],[BudgetID],[Balance],[Unit],[Oldbalance],[KYbalance],[DetailName] ");
			strSql.Append(" FROM Budget_Detail ");
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
			strSql.Append(" [ID],[BudgetID],[Balance],[Unit],[Oldbalance],[KYbalance],[DetailName] ");
			strSql.Append(" FROM Budget_Detail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  Method
	}
}

