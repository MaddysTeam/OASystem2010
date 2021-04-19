using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Personal_Plan_Limits。
	/// </summary>
	public class Personal_Plan_Limits
	{
		public Personal_Plan_Limits()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Personal_Plan_Limits"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Personal_Plan_Limits");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Personal_Plan_Limits model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Personal_Plan_Limits(");
			strSql.Append("USERID,APPLYUSERID,ISALL)");
			strSql.Append(" values (");
			strSql.Append("@USERID,@APPLYUSERID,@ISALL)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@USERID", SqlDbType.VarChar,50),
					new SqlParameter("@APPLYUSERID", SqlDbType.Text),
					new SqlParameter("@ISALL", SqlDbType.Int,4)};
			parameters[0].Value = model.USERID;
			parameters[1].Value = model.APPLYUSERID;
			parameters[2].Value = model.ISALL;

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
		public void Update(Dianda.Model.Personal_Plan_Limits model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Personal_Plan_Limits set ");
			strSql.Append("USERID=@USERID,");
			strSql.Append("APPLYUSERID=@APPLYUSERID,");
			strSql.Append("ISALL=@ISALL");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@USERID", SqlDbType.VarChar,50),
					new SqlParameter("@APPLYUSERID", SqlDbType.Text),
					new SqlParameter("@ISALL", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.USERID;
			parameters[2].Value = model.APPLYUSERID;
			parameters[3].Value = model.ISALL;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Personal_Plan_Limits ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Personal_Plan_Limits GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,USERID,APPLYUSERID,ISALL from Personal_Plan_Limits ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Personal_Plan_Limits model=new Dianda.Model.Personal_Plan_Limits();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.USERID=ds.Tables[0].Rows[0]["USERID"].ToString();
				model.APPLYUSERID=ds.Tables[0].Rows[0]["APPLYUSERID"].ToString();
				if(ds.Tables[0].Rows[0]["ISALL"].ToString()!="")
				{
					model.ISALL=int.Parse(ds.Tables[0].Rows[0]["ISALL"].ToString());
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
			strSql.Append("select ID,USERID,APPLYUSERID,ISALL ");
			strSql.Append(" FROM Personal_Plan_Limits ");
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
			strSql.Append(" ID,USERID,APPLYUSERID,ISALL ");
			strSql.Append(" FROM Personal_Plan_Limits ");
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
			parameters[0].Value = "Personal_Plan_Limits";
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

