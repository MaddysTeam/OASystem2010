using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Cash_Cards。
	/// </summary>
	public class Cash_Cards
	{
		public Cash_Cards()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Cash_Cards"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cash_Cards");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Cash_Cards model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Cash_Cards(");
            strSql.Append("CardNum,CardName,CardholderID,DepartmentID,ProjectID,Balance,LimitNums,ApproverIDs,DATETIME,Statas,DoUserID,EndTime,TEMP0,TEMP1,TEMP2,TEMP3,SpecialFundsID,SFOrderID,YEBalance)");
			strSql.Append(" values (");
            strSql.Append("@CardNum,@CardName,@CardholderID,@DepartmentID,@ProjectID,@Balance,@LimitNums,@ApproverIDs,@DATETIME,@Statas,@DoUserID,@EndTime,@TEMP0,@TEMP1,@TEMP2,@TEMP3,@SpecialFundsID,@SFOrderID,@YEBalance)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CardNum", SqlDbType.VarChar,50),
					new SqlParameter("@CardName", SqlDbType.VarChar,50),
					new SqlParameter("@CardholderID", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@LimitNums", SqlDbType.Float,8),
					new SqlParameter("@ApproverIDs", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@Statas", SqlDbType.Int,4),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@TEMP0", SqlDbType.VarChar,5000),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,50),
                    new SqlParameter("@SpecialFundsID", SqlDbType.Int,4),
                    new SqlParameter("@SFOrderID", SqlDbType.Int,4),
                    new SqlParameter("@YEBalance", SqlDbType.Float,8)};
			parameters[0].Value = model.CardNum;
			parameters[1].Value = model.CardName;
			parameters[2].Value = model.CardholderID;
			parameters[3].Value = model.DepartmentID;
			parameters[4].Value = model.ProjectID;
			parameters[5].Value = model.Balance;
			parameters[6].Value = model.LimitNums;
			parameters[7].Value = model.ApproverIDs;
			parameters[8].Value = model.DATETIME;
			parameters[9].Value = model.Statas;
			parameters[10].Value = model.DoUserID;
			parameters[11].Value = model.EndTime;
			parameters[12].Value = model.TEMP0;
			parameters[13].Value = model.TEMP1;
			parameters[14].Value = model.TEMP2;
			parameters[15].Value = model.TEMP3;
            parameters[16].Value = model.SpecialFundsID;
            parameters[17].Value = model.SFOrderID;
            parameters[18].Value = model.YEBalance;
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
		public void Update(Dianda.Model.Cash_Cards model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Cash_Cards set ");
			strSql.Append("CardNum=@CardNum,");
			strSql.Append("CardName=@CardName,");
			strSql.Append("CardholderID=@CardholderID,");
			strSql.Append("DepartmentID=@DepartmentID,");
			strSql.Append("ProjectID=@ProjectID,");
			strSql.Append("Balance=@Balance,");
			strSql.Append("LimitNums=@LimitNums,");
			strSql.Append("ApproverIDs=@ApproverIDs,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("Statas=@Statas,");
			strSql.Append("DoUserID=@DoUserID,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("TEMP0=@TEMP0,");
			strSql.Append("TEMP1=@TEMP1,");
			strSql.Append("TEMP2=@TEMP2,");
			strSql.Append("TEMP3=@TEMP3,");
            strSql.Append("SpecialFundsID=@SpecialFundsID,");
            strSql.Append("SFOrderID=@SFOrderID,");
            strSql.Append("YEBalance=@YEBalance");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CardNum", SqlDbType.VarChar,50),
					new SqlParameter("@CardName", SqlDbType.VarChar,50),
					new SqlParameter("@CardholderID", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@LimitNums", SqlDbType.Float,8),
					new SqlParameter("@ApproverIDs", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@Statas", SqlDbType.Int,4),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@TEMP0", SqlDbType.VarChar,5000),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,50),
                    new SqlParameter("@SpecialFundsID", SqlDbType.Int,4),
                    new SqlParameter("@SFOrderID", SqlDbType.Int,4),
                    new SqlParameter("@YEBalance", SqlDbType.Float,8)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.CardNum;
			parameters[2].Value = model.CardName;
			parameters[3].Value = model.CardholderID;
			parameters[4].Value = model.DepartmentID;
			parameters[5].Value = model.ProjectID;
			parameters[6].Value = model.Balance;
			parameters[7].Value = model.LimitNums;
			parameters[8].Value = model.ApproverIDs;
			parameters[9].Value = model.DATETIME;
			parameters[10].Value = model.Statas;
			parameters[11].Value = model.DoUserID;
			parameters[12].Value = model.EndTime;
			parameters[13].Value = model.TEMP0;
			parameters[14].Value = model.TEMP1;
			parameters[15].Value = model.TEMP2;
			parameters[16].Value = model.TEMP3;
            parameters[17].Value = model.SpecialFundsID;
            parameters[18].Value = model.SFOrderID;
            parameters[19].Value = model.YEBalance;
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cash_Cards ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Cash_Cards GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,CardNum,CardName,CardholderID,DepartmentID,ProjectID,Balance,LimitNums,ApproverIDs,DATETIME,Statas,DoUserID,EndTime,TEMP0,TEMP1,TEMP2,TEMP3,SpecialFundsID,SFOrderID,YEBalance from Cash_Cards ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Cash_Cards model=new Dianda.Model.Cash_Cards();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.CardNum=ds.Tables[0].Rows[0]["CardNum"].ToString();
				model.CardName=ds.Tables[0].Rows[0]["CardName"].ToString();
				model.CardholderID=ds.Tables[0].Rows[0]["CardholderID"].ToString();
				model.DepartmentID=ds.Tables[0].Rows[0]["DepartmentID"].ToString();
				if(ds.Tables[0].Rows[0]["ProjectID"].ToString()!="")
				{
					model.ProjectID=int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Balance"].ToString()!="")
				{
					model.Balance=decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LimitNums"].ToString()!="")
				{
					model.LimitNums=decimal.Parse(ds.Tables[0].Rows[0]["LimitNums"].ToString());
				}
				model.ApproverIDs=ds.Tables[0].Rows[0]["ApproverIDs"].ToString();
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Statas"].ToString()!="")
				{
					model.Statas=int.Parse(ds.Tables[0].Rows[0]["Statas"].ToString());
				}
				model.DoUserID=ds.Tables[0].Rows[0]["DoUserID"].ToString();
				if(ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
				}
				model.TEMP0=ds.Tables[0].Rows[0]["TEMP0"].ToString();
				model.TEMP1=ds.Tables[0].Rows[0]["TEMP1"].ToString();
				model.TEMP2=ds.Tables[0].Rows[0]["TEMP2"].ToString();
				model.TEMP3=ds.Tables[0].Rows[0]["TEMP3"].ToString();
                if (ds.Tables[0].Rows[0]["SpecialFundsID"].ToString() != "")
                {
                    model.SpecialFundsID = int.Parse(ds.Tables[0].Rows[0]["SpecialFundsID"].ToString());
                }

                if (ds.Tables[0].Rows[0]["SFOrderID"].ToString() != "")
                {
                    model.SFOrderID = int.Parse(ds.Tables[0].Rows[0]["SFOrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["YEBalance"].ToString() != "")
                {
                    model.YEBalance = decimal.Parse(ds.Tables[0].Rows[0]["YEBalance"].ToString());
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
            strSql.Append("select ID,CardNum,CardName,CardholderID,DepartmentID,ProjectID,Balance,LimitNums,ApproverIDs,DATETIME,Statas,DoUserID,EndTime,TEMP0,TEMP1,TEMP2,TEMP3,SpecialFundsID,SFOrderID,YEBalance ");
			strSql.Append(" FROM Cash_Cards ");
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
            strSql.Append(" ID,CardNum,CardName,CardholderID,DepartmentID,ProjectID,Balance,LimitNums,ApproverIDs,DATETIME,Statas,DoUserID,EndTime,TEMP0,TEMP1,TEMP2,TEMP3,SpecialFundsID,SFOrderID,YEBalance ");
			strSql.Append(" FROM Cash_Cards ");
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
			parameters[0].Value = "Cash_Cards";
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

