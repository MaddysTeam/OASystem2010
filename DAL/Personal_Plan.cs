using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Personal_Plan。
	/// </summary>
	public class Personal_Plan
	{
		public Personal_Plan()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Personal_Plan"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Personal_Plan");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Personal_Plan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Personal_Plan(");
			strSql.Append("NAMES,DELFLAG,Status,Overviews,StartTime,EndTime,DATETIME,UserID)");
			strSql.Append(" values (");
			strSql.Append("@NAMES,@DELFLAG,@Status,@Overviews,@StartTime,@EndTime,@DATETIME,@UserID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NAMES", SqlDbType.VarChar,500),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Overviews", SqlDbType.Text),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.NAMES;
			parameters[1].Value = model.DELFLAG;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.Overviews;
			parameters[4].Value = model.StartTime;
			parameters[5].Value = model.EndTime;
			parameters[6].Value = model.DATETIME;
			parameters[7].Value = model.UserID;

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
		public void Update(Dianda.Model.Personal_Plan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Personal_Plan set ");
			strSql.Append("NAMES=@NAMES,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("Status=@Status,");
			strSql.Append("Overviews=@Overviews,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("UserID=@UserID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@NAMES", SqlDbType.VarChar,500),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Overviews", SqlDbType.Text),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAMES;
			parameters[2].Value = model.DELFLAG;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Overviews;
			parameters[5].Value = model.StartTime;
			parameters[6].Value = model.EndTime;
			parameters[7].Value = model.DATETIME;
			parameters[8].Value = model.UserID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Personal_Plan ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Personal_Plan GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,NAMES,DELFLAG,Status,Overviews,StartTime,EndTime,DATETIME,UserID from Personal_Plan ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Personal_Plan model=new Dianda.Model.Personal_Plan();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.NAMES=ds.Tables[0].Rows[0]["NAMES"].ToString();
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.Overviews=ds.Tables[0].Rows[0]["Overviews"].ToString();
				if(ds.Tables[0].Rows[0]["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				model.UserID=ds.Tables[0].Rows[0]["UserID"].ToString();
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
			strSql.Append("select ID,NAMES,DELFLAG,Status,Overviews,StartTime,EndTime,DATETIME,UserID ");
			strSql.Append(" FROM Personal_Plan ");
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
			strSql.Append(" * ");
            strSql.Append(" FROM Personal_Plan ");
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
			parameters[0].Value = "Personal_Plan";
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

