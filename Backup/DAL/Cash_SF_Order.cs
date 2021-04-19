using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类:Cash_SF_Order
	/// </summary>
	public partial class Cash_SF_Order
	{
		public Cash_SF_Order()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Cash_SF_Order"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cash_SF_Order");
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
		public int Add(Dianda.Model.Cash_SF_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Cash_SF_Order(");
            strSql.Append("NAMES,SpecialFundsID,ProjectID,ADDTIME,BudgetAmount,BAUNIT,ActualAmount,AAUNIT,Applyuser,Status,Delflag,BudgetList,Note,CheckerHistory,Checker,AssignChecker,CarNums,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,CheckTime)");
			strSql.Append(" values (");
            strSql.Append("@NAMES,@SpecialFundsID,@ProjectID,@ADDTIME,@BudgetAmount,@BAUNIT,@ActualAmount,@AAUNIT,@Applyuser,@Status,@Delflag,@BudgetList,@Note,@CheckerHistory,@Checker,@AssignChecker,@CarNums,@TEMP1,@TEMP2,@TEMP3,@TEMP4,@TEMP5,@CheckTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NAMES", SqlDbType.VarChar,100),
					new SqlParameter("@SpecialFundsID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@ADDTIME", SqlDbType.DateTime),
					new SqlParameter("@BudgetAmount", SqlDbType.Float,8),
					new SqlParameter("@BAUNIT", SqlDbType.VarChar,10),
					new SqlParameter("@ActualAmount", SqlDbType.Float,8),
					new SqlParameter("@AAUNIT", SqlDbType.VarChar,10),
					new SqlParameter("@Applyuser", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Delflag", SqlDbType.Int,4),
					new SqlParameter("@BudgetList", SqlDbType.VarChar,500),
					new SqlParameter("@Note", SqlDbType.Text),
					new SqlParameter("@CheckerHistory", SqlDbType.VarChar,500),
					new SqlParameter("@Checker", SqlDbType.VarChar,500),
					new SqlParameter("@AssignChecker", SqlDbType.VarChar,500),
					new SqlParameter("@CarNums", SqlDbType.Int,4),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP5", SqlDbType.VarChar,500),
                    new SqlParameter("@CheckTime", SqlDbType.DateTime)};
			parameters[0].Value = model.NAMES;
			parameters[1].Value = model.SpecialFundsID;
			parameters[2].Value = model.ProjectID;
			parameters[3].Value = model.ADDTIME;
			parameters[4].Value = model.BudgetAmount;
			parameters[5].Value = model.BAUNIT;
			parameters[6].Value = model.ActualAmount;
			parameters[7].Value = model.AAUNIT;
			parameters[8].Value = model.Applyuser;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.Delflag;
			parameters[11].Value = model.BudgetList;
			parameters[12].Value = model.Note;
			parameters[13].Value = model.CheckerHistory;
			parameters[14].Value = model.Checker;
			parameters[15].Value = model.AssignChecker;
			parameters[16].Value = model.CarNums;
			parameters[17].Value = model.TEMP1;
			parameters[18].Value = model.TEMP2;
			parameters[19].Value = model.TEMP3;
			parameters[20].Value = model.TEMP4;
			parameters[21].Value = model.TEMP5;
            parameters[22].Value = model.CheckTime;

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
		public bool Update(Dianda.Model.Cash_SF_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Cash_SF_Order set ");
			strSql.Append("NAMES=@NAMES,");
			strSql.Append("SpecialFundsID=@SpecialFundsID,");
			strSql.Append("ProjectID=@ProjectID,");
			strSql.Append("ADDTIME=@ADDTIME,");
			strSql.Append("BudgetAmount=@BudgetAmount,");
			strSql.Append("BAUNIT=@BAUNIT,");
			strSql.Append("ActualAmount=@ActualAmount,");
			strSql.Append("AAUNIT=@AAUNIT,");
			strSql.Append("Applyuser=@Applyuser,");
			strSql.Append("Status=@Status,");
			strSql.Append("Delflag=@Delflag,");
			strSql.Append("BudgetList=@BudgetList,");
			strSql.Append("Note=@Note,");
			strSql.Append("CheckerHistory=@CheckerHistory,");
			strSql.Append("Checker=@Checker,");
			strSql.Append("AssignChecker=@AssignChecker,");
			strSql.Append("CarNums=@CarNums,");
			strSql.Append("TEMP1=@TEMP1,");
			strSql.Append("TEMP2=@TEMP2,");
			strSql.Append("TEMP3=@TEMP3,");
			strSql.Append("TEMP4=@TEMP4,");
			strSql.Append("TEMP5=@TEMP5,");
            strSql.Append("CheckTime=@CheckTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@NAMES", SqlDbType.VarChar,100),
					new SqlParameter("@SpecialFundsID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@ADDTIME", SqlDbType.DateTime),
					new SqlParameter("@BudgetAmount", SqlDbType.Float,8),
					new SqlParameter("@BAUNIT", SqlDbType.VarChar,10),
					new SqlParameter("@ActualAmount", SqlDbType.Float,8),
					new SqlParameter("@AAUNIT", SqlDbType.VarChar,10),
					new SqlParameter("@Applyuser", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Delflag", SqlDbType.Int,4),
					new SqlParameter("@BudgetList", SqlDbType.VarChar,500),
					new SqlParameter("@Note", SqlDbType.Text),
					new SqlParameter("@CheckerHistory", SqlDbType.VarChar,500),
					new SqlParameter("@Checker", SqlDbType.VarChar,500),
					new SqlParameter("@AssignChecker", SqlDbType.VarChar,500),
					new SqlParameter("@CarNums", SqlDbType.Int,4),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP5", SqlDbType.VarChar,500),
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@CheckTime", SqlDbType.DateTime)};
			parameters[0].Value = model.NAMES;
			parameters[1].Value = model.SpecialFundsID;
			parameters[2].Value = model.ProjectID;
			parameters[3].Value = model.ADDTIME;
			parameters[4].Value = model.BudgetAmount;
			parameters[5].Value = model.BAUNIT;
			parameters[6].Value = model.ActualAmount;
			parameters[7].Value = model.AAUNIT;
			parameters[8].Value = model.Applyuser;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.Delflag;
			parameters[11].Value = model.BudgetList;
			parameters[12].Value = model.Note;
			parameters[13].Value = model.CheckerHistory;
			parameters[14].Value = model.Checker;
			parameters[15].Value = model.AssignChecker;
			parameters[16].Value = model.CarNums;
			parameters[17].Value = model.TEMP1;
			parameters[18].Value = model.TEMP2;
			parameters[19].Value = model.TEMP3;
			parameters[20].Value = model.TEMP4;
			parameters[21].Value = model.TEMP5;
			parameters[22].Value = model.ID;
            parameters[23].Value = model.CheckTime;

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
			strSql.Append("delete from Cash_SF_Order ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cash_SF_Order ");
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
		public Dianda.Model.Cash_SF_Order GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,NAMES,SpecialFundsID,ProjectID,ADDTIME,BudgetAmount,BAUNIT,ActualAmount,AAUNIT,Applyuser,Status,Delflag,BudgetList,Note,CheckerHistory,Checker,AssignChecker,CarNums,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,CheckTime from Cash_SF_Order ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			Dianda.Model.Cash_SF_Order model=new Dianda.Model.Cash_SF_Order();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NAMES"]!=null && ds.Tables[0].Rows[0]["NAMES"].ToString()!="")
				{
					model.NAMES=ds.Tables[0].Rows[0]["NAMES"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SpecialFundsID"]!=null && ds.Tables[0].Rows[0]["SpecialFundsID"].ToString()!="")
				{
					model.SpecialFundsID=int.Parse(ds.Tables[0].Rows[0]["SpecialFundsID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProjectID"]!=null && ds.Tables[0].Rows[0]["ProjectID"].ToString()!="")
				{
					model.ProjectID=int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ADDTIME"]!=null && ds.Tables[0].Rows[0]["ADDTIME"].ToString()!="")
				{
					model.ADDTIME=DateTime.Parse(ds.Tables[0].Rows[0]["ADDTIME"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BudgetAmount"]!=null && ds.Tables[0].Rows[0]["BudgetAmount"].ToString()!="")
				{
					model.BudgetAmount=decimal.Parse(ds.Tables[0].Rows[0]["BudgetAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BAUNIT"]!=null && ds.Tables[0].Rows[0]["BAUNIT"].ToString()!="")
				{
					model.BAUNIT=ds.Tables[0].Rows[0]["BAUNIT"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ActualAmount"]!=null && ds.Tables[0].Rows[0]["ActualAmount"].ToString()!="")
				{
					model.ActualAmount=decimal.Parse(ds.Tables[0].Rows[0]["ActualAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AAUNIT"]!=null && ds.Tables[0].Rows[0]["AAUNIT"].ToString()!="")
				{
					model.AAUNIT=ds.Tables[0].Rows[0]["AAUNIT"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Applyuser"]!=null && ds.Tables[0].Rows[0]["Applyuser"].ToString()!="")
				{
					model.Applyuser=ds.Tables[0].Rows[0]["Applyuser"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Delflag"]!=null && ds.Tables[0].Rows[0]["Delflag"].ToString()!="")
				{
					model.Delflag=int.Parse(ds.Tables[0].Rows[0]["Delflag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BudgetList"]!=null && ds.Tables[0].Rows[0]["BudgetList"].ToString()!="")
				{
					model.BudgetList=ds.Tables[0].Rows[0]["BudgetList"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CheckerHistory"]!=null && ds.Tables[0].Rows[0]["CheckerHistory"].ToString()!="")
				{
					model.CheckerHistory=ds.Tables[0].Rows[0]["CheckerHistory"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Checker"]!=null && ds.Tables[0].Rows[0]["Checker"].ToString()!="")
				{
					model.Checker=ds.Tables[0].Rows[0]["Checker"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AssignChecker"]!=null && ds.Tables[0].Rows[0]["AssignChecker"].ToString()!="")
				{
					model.AssignChecker=ds.Tables[0].Rows[0]["AssignChecker"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CarNums"]!=null && ds.Tables[0].Rows[0]["CarNums"].ToString()!="")
				{
					model.CarNums=int.Parse(ds.Tables[0].Rows[0]["CarNums"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TEMP1"]!=null && ds.Tables[0].Rows[0]["TEMP1"].ToString()!="")
				{
					model.TEMP1=ds.Tables[0].Rows[0]["TEMP1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TEMP2"]!=null && ds.Tables[0].Rows[0]["TEMP2"].ToString()!="")
				{
					model.TEMP2=ds.Tables[0].Rows[0]["TEMP2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TEMP3"]!=null && ds.Tables[0].Rows[0]["TEMP3"].ToString()!="")
				{
					model.TEMP3=ds.Tables[0].Rows[0]["TEMP3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TEMP4"]!=null && ds.Tables[0].Rows[0]["TEMP4"].ToString()!="")
				{
					model.TEMP4=ds.Tables[0].Rows[0]["TEMP4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TEMP5"]!=null && ds.Tables[0].Rows[0]["TEMP5"].ToString()!="")
				{
					model.TEMP5=ds.Tables[0].Rows[0]["TEMP5"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CheckTime"] != null && ds.Tables[0].Rows[0]["CheckTime"].ToString() != "")
                {
                    model.ADDTIME = DateTime.Parse(ds.Tables[0].Rows[0]["CheckTime"].ToString());
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
            strSql.Append("select ID,NAMES,SpecialFundsID,ProjectID,ADDTIME,BudgetAmount,BAUNIT,ActualAmount,AAUNIT,Applyuser,Status,Delflag,BudgetList,Note,CheckerHistory,Checker,AssignChecker,CarNums,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,CheckTime ");
			strSql.Append(" FROM Cash_SF_Order ");
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
            strSql.Append(" ID,NAMES,SpecialFundsID,ProjectID,ADDTIME,BudgetAmount,BAUNIT,ActualAmount,AAUNIT,Applyuser,Status,Delflag,BudgetList,Note,CheckerHistory,Checker,AssignChecker,CarNums,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,CheckTime");
			strSql.Append(" FROM Cash_SF_Order ");
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
			parameters[0].Value = "Cash_SF_Order";
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

