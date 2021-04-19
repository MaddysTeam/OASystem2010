using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类:Cash_Account
	/// </summary>
	public partial class Cash_Account
	{
		public Cash_Account()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Cash_Account"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cash_Account");
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
		public int Add(Dianda.Model.Cash_Account model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cash_Account(");
            strSql.Append("NAMES,STATUS,ADDTIME,Balance,TotalNum,Adduser,Bank,BankInfo,Delflag,Note,FreezeTime,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,EveryDayNum)");
            strSql.Append(" values (");
            strSql.Append("@NAMES,@STATUS,@ADDTIME,@Balance,@TotalNum,@Adduser,@Bank,@BankInfo,@Delflag,@Note,@FreezeTime,@TEMP1,@TEMP2,@TEMP3,@TEMP4,@TEMP5,@EveryDayNum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@NAMES", SqlDbType.VarChar,100),
					new SqlParameter("@STATUS", SqlDbType.Int,4),
					new SqlParameter("@ADDTIME", SqlDbType.DateTime),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@TotalNum", SqlDbType.Float,8),
					new SqlParameter("@Adduser", SqlDbType.VarChar,50),
					new SqlParameter("@Bank", SqlDbType.VarChar,100),
					new SqlParameter("@BankInfo", SqlDbType.VarChar,2000),
					new SqlParameter("@Delflag", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.Text),
					new SqlParameter("@FreezeTime", SqlDbType.DateTime),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP5", SqlDbType.VarChar,500),
					new SqlParameter("@EveryDayNum", SqlDbType.Float,8)};
            parameters[0].Value = model.NAMES;
            parameters[1].Value = model.STATUS;
            parameters[2].Value = model.ADDTIME;
            parameters[3].Value = model.Balance;
            parameters[4].Value = model.TotalNum;
            parameters[5].Value = model.Adduser;
            parameters[6].Value = model.Bank;
            parameters[7].Value = model.BankInfo;
            parameters[8].Value = model.Delflag;
            parameters[9].Value = model.Note;
            parameters[10].Value = model.FreezeTime;
            parameters[11].Value = model.TEMP1;
            parameters[12].Value = model.TEMP2;
            parameters[13].Value = model.TEMP3;
            parameters[14].Value = model.TEMP4;
            parameters[15].Value = model.TEMP5;
            parameters[16].Value = model.EveryDayNum;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
		public bool Update(Dianda.Model.Cash_Account model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cash_Account set ");
            strSql.Append("NAMES=@NAMES,");
            strSql.Append("STATUS=@STATUS,");
            strSql.Append("ADDTIME=@ADDTIME,");
            strSql.Append("Balance=@Balance,");
            strSql.Append("TotalNum=@TotalNum,");
            strSql.Append("Adduser=@Adduser,");
            strSql.Append("Bank=@Bank,");
            strSql.Append("BankInfo=@BankInfo,");
            strSql.Append("Delflag=@Delflag,");
            strSql.Append("Note=@Note,");
            strSql.Append("FreezeTime=@FreezeTime,");
            strSql.Append("TEMP1=@TEMP1,");
            strSql.Append("TEMP2=@TEMP2,");
            strSql.Append("TEMP3=@TEMP3,");
            strSql.Append("TEMP4=@TEMP4,");
            strSql.Append("TEMP5=@TEMP5,");
            strSql.Append("EveryDayNum=@EveryDayNum");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@NAMES", SqlDbType.VarChar,100),
					new SqlParameter("@STATUS", SqlDbType.Int,4),
					new SqlParameter("@ADDTIME", SqlDbType.DateTime),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@TotalNum", SqlDbType.Float,8),
					new SqlParameter("@Adduser", SqlDbType.VarChar,50),
					new SqlParameter("@Bank", SqlDbType.VarChar,100),
					new SqlParameter("@BankInfo", SqlDbType.VarChar,2000),
					new SqlParameter("@Delflag", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.Text),
					new SqlParameter("@FreezeTime", SqlDbType.DateTime),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP5", SqlDbType.VarChar,500),
					new SqlParameter("@EveryDayNum", SqlDbType.Float,8),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.NAMES;
            parameters[1].Value = model.STATUS;
            parameters[2].Value = model.ADDTIME;
            parameters[3].Value = model.Balance;
            parameters[4].Value = model.TotalNum;
            parameters[5].Value = model.Adduser;
            parameters[6].Value = model.Bank;
            parameters[7].Value = model.BankInfo;
            parameters[8].Value = model.Delflag;
            parameters[9].Value = model.Note;
            parameters[10].Value = model.FreezeTime;
            parameters[11].Value = model.TEMP1;
            parameters[12].Value = model.TEMP2;
            parameters[13].Value = model.TEMP3;
            parameters[14].Value = model.TEMP4;
            parameters[15].Value = model.TEMP5;
            parameters[16].Value = model.EveryDayNum;
            parameters[17].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
			strSql.Append("delete from Cash_Account ");
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
			strSql.Append("delete from Cash_Account ");
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
		public Dianda.Model.Cash_Account GetModel(int ID)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,NAMES,STATUS,ADDTIME,Balance,TotalNum,Adduser,Bank,BankInfo,Delflag,Note,FreezeTime,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,EveryDayNum from Cash_Account ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Dianda.Model.Cash_Account model = new Dianda.Model.Cash_Account();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NAMES"] != null && ds.Tables[0].Rows[0]["NAMES"].ToString() != "")
                {
                    model.NAMES = ds.Tables[0].Rows[0]["NAMES"].ToString();
                }
                if (ds.Tables[0].Rows[0]["STATUS"] != null && ds.Tables[0].Rows[0]["STATUS"].ToString() != "")
                {
                    model.STATUS = int.Parse(ds.Tables[0].Rows[0]["STATUS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ADDTIME"] != null && ds.Tables[0].Rows[0]["ADDTIME"].ToString() != "")
                {
                    model.ADDTIME = DateTime.Parse(ds.Tables[0].Rows[0]["ADDTIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Balance"] != null && ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalNum"] != null && ds.Tables[0].Rows[0]["TotalNum"].ToString() != "")
                {
                    model.TotalNum = decimal.Parse(ds.Tables[0].Rows[0]["TotalNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Adduser"] != null && ds.Tables[0].Rows[0]["Adduser"].ToString() != "")
                {
                    model.Adduser = ds.Tables[0].Rows[0]["Adduser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Bank"] != null && ds.Tables[0].Rows[0]["Bank"].ToString() != "")
                {
                    model.Bank = ds.Tables[0].Rows[0]["Bank"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankInfo"] != null && ds.Tables[0].Rows[0]["BankInfo"].ToString() != "")
                {
                    model.BankInfo = ds.Tables[0].Rows[0]["BankInfo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Delflag"] != null && ds.Tables[0].Rows[0]["Delflag"].ToString() != "")
                {
                    model.Delflag = int.Parse(ds.Tables[0].Rows[0]["Delflag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Note"] != null && ds.Tables[0].Rows[0]["Note"].ToString() != "")
                {
                    model.Note = ds.Tables[0].Rows[0]["Note"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FreezeTime"] != null && ds.Tables[0].Rows[0]["FreezeTime"].ToString() != "")
                {
                    model.FreezeTime = DateTime.Parse(ds.Tables[0].Rows[0]["FreezeTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TEMP1"] != null && ds.Tables[0].Rows[0]["TEMP1"].ToString() != "")
                {
                    model.TEMP1 = ds.Tables[0].Rows[0]["TEMP1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TEMP2"] != null && ds.Tables[0].Rows[0]["TEMP2"].ToString() != "")
                {
                    model.TEMP2 = ds.Tables[0].Rows[0]["TEMP2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TEMP3"] != null && ds.Tables[0].Rows[0]["TEMP3"].ToString() != "")
                {
                    model.TEMP3 = ds.Tables[0].Rows[0]["TEMP3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TEMP4"] != null && ds.Tables[0].Rows[0]["TEMP4"].ToString() != "")
                {
                    model.TEMP4 = ds.Tables[0].Rows[0]["TEMP4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TEMP5"] != null && ds.Tables[0].Rows[0]["TEMP5"].ToString() != "")
                {
                    model.TEMP5 = ds.Tables[0].Rows[0]["TEMP5"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EveryDayNum"] != null && ds.Tables[0].Rows[0]["EveryDayNum"].ToString() != "")
                {
                    model.EveryDayNum = decimal.Parse(ds.Tables[0].Rows[0]["EveryDayNum"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NAMES,STATUS,ADDTIME,Balance,TotalNum,Adduser,Bank,BankInfo,Delflag,Note,FreezeTime,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,EveryDayNum ");
            strSql.Append(" FROM Cash_Account ");
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
            strSql.Append(" ID,NAMES,STATUS,ADDTIME,Balance,TotalNum,Adduser,Bank,BankInfo,Delflag,Note,FreezeTime,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,EveryDayNum ");
            strSql.Append(" FROM Cash_Account ");
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
			parameters[0].Value = "Cash_Account";
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

