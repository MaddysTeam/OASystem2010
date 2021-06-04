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
	public partial class Budget_User_Apply
	{
		public Budget_User_Apply()
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
			strSql.Append("select count(1) from Budget_User_Apply");
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
		public int Add(Dianda.Model.Budget_User_Apply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Budget_User_Apply(");
			strSql.Append("[BudgetID],[DetailID],[Balance],[AddTime],[DoUserId],[DetailName],[RoundNO])");
			strSql.Append(" values (");
			strSql.Append("@BudgetID,@DetailID,@Balance,@AddTime,@DoUserId,@DetailName,@RoundNO)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BudgetID", SqlDbType.Int,4),
					new SqlParameter("@DetailID", SqlDbType.Int,4),
					new SqlParameter("@Balance", SqlDbType.Float,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime,8),
					new SqlParameter("@DoUserId", SqlDbType.NVarChar,50),
					new SqlParameter("@DetailName", SqlDbType.NVarChar,8),
					new SqlParameter("@RoundNO", SqlDbType.NVarChar,50),
					new SqlParameter("@Notes", SqlDbType.NVarChar,1000),
			};
			parameters[0].Value = model.BudgetID;
			parameters[1].Value = model.DetailID;
			parameters[2].Value = model.Balance;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.DoUserID;
			parameters[5].Value = model.DetailName;
			parameters[6].Value = model.RoundNO;

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


		#endregion  Method
	}
}

