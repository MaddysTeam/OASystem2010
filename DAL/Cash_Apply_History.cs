using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Cash_Apply_History。
	/// </summary>
	public class Cash_Apply_History
	{
		public Cash_Apply_History()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Cash_Apply_History"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cash_Apply_History");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Cash_Apply_History model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Cash_Apply_History(");
			strSql.Append("CashCertificateID,ControlInfo,Balance,DATETIME,DoUser,DoType,NOTES)");
			strSql.Append(" values (");
			strSql.Append("@CashCertificateID,@ControlInfo,@Balance,@DATETIME,@DoUser,@DoType,@NOTES)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CashCertificateID", SqlDbType.Int,4),
					new SqlParameter("@ControlInfo", SqlDbType.VarChar,5000),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DoUser", SqlDbType.VarChar,50),
					new SqlParameter("@DoType", SqlDbType.VarChar,100),
					new SqlParameter("@NOTES", SqlDbType.VarChar,5000)};
			parameters[0].Value = model.CashCertificateID;
			parameters[1].Value = model.ControlInfo;
			parameters[2].Value = model.Balance;
			parameters[3].Value = model.DATETIME;
			parameters[4].Value = model.DoUser;
			parameters[5].Value = model.DoType;
			parameters[6].Value = model.NOTES;

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
		public void Update(Dianda.Model.Cash_Apply_History model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Cash_Apply_History set ");
			strSql.Append("CashCertificateID=@CashCertificateID,");
			strSql.Append("ControlInfo=@ControlInfo,");
			strSql.Append("Balance=@Balance,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("DoUser=@DoUser,");
			strSql.Append("DoType=@DoType,");
			strSql.Append("NOTES=@NOTES");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CashCertificateID", SqlDbType.Int,4),
					new SqlParameter("@ControlInfo", SqlDbType.VarChar,5000),
					new SqlParameter("@Balance", SqlDbType.Float,8),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DoUser", SqlDbType.VarChar,50),
					new SqlParameter("@DoType", SqlDbType.VarChar,100),
					new SqlParameter("@NOTES", SqlDbType.VarChar,5000)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.CashCertificateID;
			parameters[2].Value = model.ControlInfo;
			parameters[3].Value = model.Balance;
			parameters[4].Value = model.DATETIME;
			parameters[5].Value = model.DoUser;
			parameters[6].Value = model.DoType;
			parameters[7].Value = model.NOTES;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cash_Apply_History ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Cash_Apply_History GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CashCertificateID,ControlInfo,Balance,DATETIME,DoUser,DoType,NOTES from Cash_Apply_History ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Cash_Apply_History model=new Dianda.Model.Cash_Apply_History();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CashCertificateID"].ToString()!="")
				{
					model.CashCertificateID=int.Parse(ds.Tables[0].Rows[0]["CashCertificateID"].ToString());
				}
				model.ControlInfo=ds.Tables[0].Rows[0]["ControlInfo"].ToString();
				if(ds.Tables[0].Rows[0]["Balance"].ToString()!="")
				{
					model.Balance=decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				model.DoUser=ds.Tables[0].Rows[0]["DoUser"].ToString();
				model.DoType=ds.Tables[0].Rows[0]["DoType"].ToString();
				model.NOTES=ds.Tables[0].Rows[0]["NOTES"].ToString();
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
			strSql.Append("select ID,CashCertificateID,ControlInfo,Balance,DATETIME,DoUser,DoType,NOTES ");
			strSql.Append(" FROM Cash_Apply_History ");
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
			strSql.Append(" ID,CashCertificateID,ControlInfo,Balance,DATETIME,DoUser,DoType,NOTES ");
			strSql.Append(" FROM Cash_Apply_History ");
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
			parameters[0].Value = "Cash_Apply_History";
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

