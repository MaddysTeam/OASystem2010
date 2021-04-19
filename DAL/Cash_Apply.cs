using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类:Cash_Apply
	/// </summary>
	public partial class Cash_Apply
	{
		public Cash_Apply()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Cash_Apply"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cash_Apply");
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
		public int Add(Dianda.Model.Cash_Apply model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cash_Apply(");
            strSql.Append("ProjectID,CashCertificateID,ApplyCount,GetDateTime,UseFor,ApplierTel,ApplierID,DATETIME,Statas,DoUserID,CarDetails,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,SpecialFundsID,Attribute,AuditOpinion)");
            strSql.Append(" values (");
            strSql.Append("@ProjectID,@CashCertificateID,@ApplyCount,@GetDateTime,@UseFor,@ApplierTel,@ApplierID,@DATETIME,@Statas,@DoUserID,@CarDetails,@TEMP1,@TEMP2,@TEMP3,@TEMP4,@TEMP5,@SpecialFundsID,@Attribute,@AuditOpinion)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@CashCertificateID", SqlDbType.VarChar,500),
					new SqlParameter("@ApplyCount", SqlDbType.Float,8),
					new SqlParameter("@GetDateTime", SqlDbType.DateTime),
					new SqlParameter("@UseFor", SqlDbType.Text),
					new SqlParameter("@ApplierTel", SqlDbType.VarChar,50),
					new SqlParameter("@ApplierID", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@Statas", SqlDbType.Int,4),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@CarDetails", SqlDbType.Text),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP5", SqlDbType.VarChar,500),
					new SqlParameter("@SpecialFundsID", SqlDbType.Int,4),
					new SqlParameter("@Attribute", SqlDbType.Char,1),
					new SqlParameter("@AuditOpinion", SqlDbType.VarChar,500)};
            parameters[0].Value = model.ProjectID;
            parameters[1].Value = model.CashCertificateID;
            parameters[2].Value = model.ApplyCount;
            parameters[3].Value = model.GetDateTime;
            parameters[4].Value = model.UseFor;
            parameters[5].Value = model.ApplierTel;
            parameters[6].Value = model.ApplierID;
            parameters[7].Value = model.DATETIME;
            parameters[8].Value = model.Statas;
            parameters[9].Value = model.DoUserID;
            parameters[10].Value = model.CarDetails;
            parameters[11].Value = model.TEMP1;
            parameters[12].Value = model.TEMP2;
            parameters[13].Value = model.TEMP3;
            parameters[14].Value = model.TEMP4;
            parameters[15].Value = model.TEMP5;
            parameters[16].Value = model.SpecialFundsID;
            parameters[17].Value = model.Attribute;
            parameters[18].Value = model.AuditOpinion;

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
		public bool Update(Dianda.Model.Cash_Apply model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cash_Apply set ");
            strSql.Append("ProjectID=@ProjectID,");
            strSql.Append("CashCertificateID=@CashCertificateID,");
            strSql.Append("ApplyCount=@ApplyCount,");
            strSql.Append("GetDateTime=@GetDateTime,");
            strSql.Append("UseFor=@UseFor,");
            strSql.Append("ApplierTel=@ApplierTel,");
            strSql.Append("ApplierID=@ApplierID,");
            strSql.Append("DATETIME=@DATETIME,");
            strSql.Append("Statas=@Statas,");
            strSql.Append("DoUserID=@DoUserID,");
            strSql.Append("CarDetails=@CarDetails,");
            strSql.Append("TEMP1=@TEMP1,");
            strSql.Append("TEMP2=@TEMP2,");
            strSql.Append("TEMP3=@TEMP3,");
            strSql.Append("TEMP4=@TEMP4,");
            strSql.Append("TEMP5=@TEMP5,");
            strSql.Append("SpecialFundsID=@SpecialFundsID,");
            strSql.Append("Attribute=@Attribute,");
            strSql.Append("AuditOpinion=@AuditOpinion");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@CashCertificateID", SqlDbType.VarChar,500),
					new SqlParameter("@ApplyCount", SqlDbType.Float,8),
					new SqlParameter("@GetDateTime", SqlDbType.DateTime),
					new SqlParameter("@UseFor", SqlDbType.Text),
					new SqlParameter("@ApplierTel", SqlDbType.VarChar,50),
					new SqlParameter("@ApplierID", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@Statas", SqlDbType.Int,4),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@CarDetails", SqlDbType.Text),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,500),
					new SqlParameter("@TEMP5", SqlDbType.VarChar,500),
					new SqlParameter("@SpecialFundsID", SqlDbType.Int,4),
					new SqlParameter("@Attribute", SqlDbType.Char,1),
					new SqlParameter("@AuditOpinion", SqlDbType.VarChar,500),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ProjectID;
            parameters[1].Value = model.CashCertificateID;
            parameters[2].Value = model.ApplyCount;
            parameters[3].Value = model.GetDateTime;
            parameters[4].Value = model.UseFor;
            parameters[5].Value = model.ApplierTel;
            parameters[6].Value = model.ApplierID;
            parameters[7].Value = model.DATETIME;
            parameters[8].Value = model.Statas;
            parameters[9].Value = model.DoUserID;
            parameters[10].Value = model.CarDetails;
            parameters[11].Value = model.TEMP1;
            parameters[12].Value = model.TEMP2;
            parameters[13].Value = model.TEMP3;
            parameters[14].Value = model.TEMP4;
            parameters[15].Value = model.TEMP5;
            parameters[16].Value = model.SpecialFundsID;
            parameters[17].Value = model.Attribute;
            parameters[18].Value = model.AuditOpinion;
            parameters[19].Value = model.ID;

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
			strSql.Append("delete from Cash_Apply ");
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
			strSql.Append("delete from Cash_Apply ");
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
		public Dianda.Model.Cash_Apply GetModel(int ID)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ProjectID,CashCertificateID,ApplyCount,GetDateTime,UseFor,ApplierTel,ApplierID,DATETIME,Statas,DoUserID,CarDetails,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,SpecialFundsID,Attribute,AuditOpinion from Cash_Apply ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Dianda.Model.Cash_Apply model = new Dianda.Model.Cash_Apply();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProjectID"] != null && ds.Tables[0].Rows[0]["ProjectID"].ToString() != "")
                {
                    model.ProjectID = int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CashCertificateID"] != null && ds.Tables[0].Rows[0]["CashCertificateID"].ToString() != "")
                {
                    model.CashCertificateID = ds.Tables[0].Rows[0]["CashCertificateID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplyCount"] != null && ds.Tables[0].Rows[0]["ApplyCount"].ToString() != "")
                {
                    model.ApplyCount = decimal.Parse(ds.Tables[0].Rows[0]["ApplyCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GetDateTime"] != null && ds.Tables[0].Rows[0]["GetDateTime"].ToString() != "")
                {
                    model.GetDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["GetDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseFor"] != null && ds.Tables[0].Rows[0]["UseFor"].ToString() != "")
                {
                    model.UseFor = ds.Tables[0].Rows[0]["UseFor"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplierTel"] != null && ds.Tables[0].Rows[0]["ApplierTel"].ToString() != "")
                {
                    model.ApplierTel = ds.Tables[0].Rows[0]["ApplierTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplierID"] != null && ds.Tables[0].Rows[0]["ApplierID"].ToString() != "")
                {
                    model.ApplierID = ds.Tables[0].Rows[0]["ApplierID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DATETIME"] != null && ds.Tables[0].Rows[0]["DATETIME"].ToString() != "")
                {
                    model.DATETIME = DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Statas"] != null && ds.Tables[0].Rows[0]["Statas"].ToString() != "")
                {
                    model.Statas = int.Parse(ds.Tables[0].Rows[0]["Statas"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DoUserID"] != null && ds.Tables[0].Rows[0]["DoUserID"].ToString() != "")
                {
                    model.DoUserID = ds.Tables[0].Rows[0]["DoUserID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CarDetails"] != null && ds.Tables[0].Rows[0]["CarDetails"].ToString() != "")
                {
                    model.CarDetails = ds.Tables[0].Rows[0]["CarDetails"].ToString();
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
                if (ds.Tables[0].Rows[0]["SpecialFundsID"] != null && ds.Tables[0].Rows[0]["SpecialFundsID"].ToString() != "")
                {
                    model.SpecialFundsID = int.Parse(ds.Tables[0].Rows[0]["SpecialFundsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Attribute"] != null && ds.Tables[0].Rows[0]["Attribute"].ToString() != "")
                {
                    model.Attribute = ds.Tables[0].Rows[0]["Attribute"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AuditOpinion"] != null && ds.Tables[0].Rows[0]["AuditOpinion"].ToString() != "")
                {
                    model.AuditOpinion = ds.Tables[0].Rows[0]["AuditOpinion"].ToString();
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
            strSql.Append("select ID,ProjectID,CashCertificateID,ApplyCount,GetDateTime,UseFor,ApplierTel,ApplierID,DATETIME,Statas,DoUserID,CarDetails,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,SpecialFundsID,Attribute,AuditOpinion ");
            strSql.Append(" FROM Cash_Apply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,ProjectID,CashCertificateID,ApplyCount,GetDateTime,UseFor,ApplierTel,ApplierID,DATETIME,Statas,DoUserID,CarDetails,TEMP1,TEMP2,TEMP3,TEMP4,TEMP5,SpecialFundsID,Attribute,AuditOpinion ");
            strSql.Append(" FROM Cash_Apply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
			parameters[0].Value = "Cash_Apply";
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

