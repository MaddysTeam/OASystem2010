using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Budget。
	/// </summary>
	public class Budget
	{
		public Budget()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Budget"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Budget");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Budget model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Budget(");
            strSql.Append("BudgetName,Balance,DepartmentIDs,ManagerIDs,ApproverIDs,LimitNums,BudgetType,Statas,YEBalance,DATETIME,DoUserID,StartTime,EndTime,TEMP0,TEMP1,TEMP2,TEMP3,Code,ParentId)");
			strSql.Append(" values (");
            strSql.Append("@BudgetName,@Balance,@DepartmentIDs,@ManagerIDs,@ApproverIDs,@LimitNums,@BudgetType,@Statas,@YEBalance,@DATETIME,@DoUserID,@StartTime,@EndTime,@TEMP0,@TEMP1,@TEMP2,@TEMP3,@Code,@ParentId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BudgetName", SqlDbType.VarChar,50),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@DepartmentIDs", SqlDbType.VarChar,5000),
					new SqlParameter("@ManagerIDs", SqlDbType.VarChar,5000),
					new SqlParameter("@ApproverIDs", SqlDbType.VarChar,50),
					new SqlParameter("@LimitNums", SqlDbType.Float,8),
					new SqlParameter("@BudgetType", SqlDbType.Int,4),
					new SqlParameter("@Statas", SqlDbType.Int,4),
					new SqlParameter("@YEBalance", SqlDbType.Float,8),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@TEMP0", SqlDbType.VarChar,5000),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,50),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,50),
			};
			parameters[0].Value = model.BudgetName;
			parameters[1].Value = model.Balance;
			parameters[2].Value = model.DepartmentIDs;
			parameters[3].Value = model.ManagerIDs;
			parameters[4].Value = model.ApproverIDs;
			parameters[5].Value = model.LimitNums;
			parameters[6].Value = model.BudgetType;
			parameters[7].Value = model.Statas;
			parameters[8].Value = model.YEBalance;
			parameters[9].Value = model.DATETIME;
			parameters[10].Value = model.DoUserID;
			parameters[11].Value = model.StartTime;
			parameters[12].Value = model.EndTime;
			parameters[13].Value = model.TEMP0;
			parameters[14].Value = model.TEMP1;
			parameters[15].Value = model.TEMP2;
            parameters[16].Value = model.TEMP3;
			parameters[17].Value = model.Code;
			parameters[18].Value = model.ParentId;
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
		public void Update(Dianda.Model.Budget model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Budget set ");
			strSql.Append("BudgetName=@BudgetName,");
			strSql.Append("Balance=@Balance,");
			strSql.Append("DepartmentIDs=@DepartmentIDs,");
			strSql.Append("ManagerIDs=@ManagerIDs,");
			strSql.Append("ApproverIDs=@ApproverIDs,");
			strSql.Append("LimitNums=@LimitNums,");
			strSql.Append("BudgetType=@BudgetType,");
			strSql.Append("Statas=@Statas,");
			strSql.Append("YEBalance=@YEBalance,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("DoUserID=@DoUserID,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("TEMP0=@TEMP0,");
            strSql.Append("TEMP1=@TEMP1,");
            strSql.Append("TEMP2=@TEMP2,");
            strSql.Append("TEMP3=@TEMP3,");
			strSql.Append("Code=@Code,");
			strSql.Append("ParentId=@ParentId");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BudgetName", SqlDbType.VarChar,50),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@DepartmentIDs", SqlDbType.VarChar,5000),
					new SqlParameter("@ManagerIDs", SqlDbType.VarChar,5000),
					new SqlParameter("@ApproverIDs", SqlDbType.VarChar,50),
					new SqlParameter("@LimitNums", SqlDbType.Float,8),
					new SqlParameter("@BudgetType", SqlDbType.Int,4),
					new SqlParameter("@Statas", SqlDbType.Int,4),
					new SqlParameter("@YEBalance", SqlDbType.Float,8),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@TEMP0", SqlDbType.VarChar,5000),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,50),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,50),
			};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BudgetName;
			parameters[2].Value = model.Balance;
			parameters[3].Value = model.DepartmentIDs;
			parameters[4].Value = model.ManagerIDs;
			parameters[5].Value = model.ApproverIDs;
			parameters[6].Value = model.LimitNums;
			parameters[7].Value = model.BudgetType;
			parameters[8].Value = model.Statas;
			parameters[9].Value = model.YEBalance;
			parameters[10].Value = model.DATETIME;
			parameters[11].Value = model.DoUserID;
			parameters[12].Value = model.StartTime;
			parameters[13].Value = model.EndTime;
			parameters[14].Value = model.TEMP0;
			parameters[15].Value = model.TEMP1;
			parameters[16].Value = model.TEMP2;
			parameters[17].Value = model.TEMP3;
			parameters[18].Value = model.Code;
			parameters[19].Value = model.ParentId;
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Budget ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Budget GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT top 1 [ID],[BudgetName],[Balance],[DepartmentIDs],[ManagerIDs],[ApproverIDs],[BudgetType],[YEBalance],[LimitNums],[Statas],[DATETIME],[DoUserID],[StartTime],[EndTime],[TEMP0],[TEMP1],[TEMP2],[TEMP3],[Code],[ParentId] FROM [dbo].[Budget] ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Budget model =new Dianda.Model.Budget();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.BudgetName = ds.Tables[0].Rows[0]["BudgetName"].ToString();
				if(ds.Tables[0].Rows[0]["Balance"].ToString()!="")
				{
					model.Balance=decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
				}
				model.DepartmentIDs = ds.Tables[0].Rows[0]["DepartmentIDs"].ToString();
				model.ApproverIDs = ds.Tables[0].Rows[0]["ApproverIDs"].ToString();
				model.BudgetType = int.Parse(ds.Tables[0].Rows[0]["BudgetType"].ToString());
				if (ds.Tables[0].Rows[0]["YEBalance"].ToString() != "")
				{
					model.YEBalance = decimal.Parse(ds.Tables[0].Rows[0]["YEBalance"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LimitNums"].ToString()!="")
				{
					model.LimitNums=decimal.Parse(ds.Tables[0].Rows[0]["LimitNums"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Statas"].ToString()!="")
				{
					model.Statas=int.Parse(ds.Tables[0].Rows[0]["Statas"].ToString());
				}
				if (ds.Tables[0].Rows[0]["DATETIME"].ToString() != "")
				{
					model.DATETIME = DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				model.DoUserID=ds.Tables[0].Rows[0]["DoUserID"].ToString();
				if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
				{
					model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
				}
				if (ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
				}
				model.TEMP0=ds.Tables[0].Rows[0]["TEMP0"].ToString();
				model.TEMP1=ds.Tables[0].Rows[0]["TEMP1"].ToString();
				model.TEMP2=ds.Tables[0].Rows[0]["TEMP2"].ToString();
				model.TEMP3=ds.Tables[0].Rows[0]["TEMP3"].ToString();


				if (ds.Tables[0].Rows[0]["Code"].ToString() != "")
				{
					model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
				}

				if (ds.Tables[0].Rows[0]["DepartmentIDs"].ToString() != "")
				{
					model.DepartmentIDs = ds.Tables[0].Rows[0]["DepartmentIDs"].ToString();
				}

				if (ds.Tables[0].Rows[0]["ManagerIDs"].ToString() != "")
				{
					model.ManagerIDs = ds.Tables[0].Rows[0]["ManagerIDs"].ToString();
				}

				if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
				{
					model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
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
            strSql.Append("SELECT [ID],[BudgetName],[Balance],[DepartmentIDs],[ManagerIDs],[ApproverIDs],[BudgetType],[YEBalance],[LimitNums],[Statas],[DATETIME],[DoUserID],[StartTime],[EndTime],[TEMP0],[TEMP1],[TEMP2],[TEMP3] ");
			strSql.Append(" FROM Budget ");
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
            strSql.Append(" [ID],[BudgetName],[Balance],[DepartmentIDs],[ManagerIDs],[ApproverIDs],[BudgetType],[YEBalance],[LimitNums],[Statas],[DATETIME],[DoUserID],[StartTime],[EndTime],[TEMP0],[TEMP1],[TEMP2],[TEMP3] ");
			strSql.Append(" FROM Budget ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  成员方法
	}
}

