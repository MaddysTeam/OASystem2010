using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Project_CarList。
	/// </summary>
	public class Project_CarList
	{
		public Project_CarList()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Project_CarList"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Project_CarList");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Project_CarList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Project_CarList(");
			strSql.Append("CarName,DriverName,CarNum,Infors,DELFLAG)");
			strSql.Append(" values (");
			strSql.Append("@CarName,@DriverName,@CarNum,@Infors,@DELFLAG)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CarName", SqlDbType.VarChar,50),
					new SqlParameter("@DriverName", SqlDbType.VarChar,50),
					new SqlParameter("@CarNum", SqlDbType.VarChar,50),
					new SqlParameter("@Infors", SqlDbType.VarChar,5000),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4)};
			parameters[0].Value = model.CarName;
			parameters[1].Value = model.DriverName;
			parameters[2].Value = model.CarNum;
			parameters[3].Value = model.Infors;
			parameters[4].Value = model.DELFLAG;

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
		public void Update(Dianda.Model.Project_CarList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Project_CarList set ");
			strSql.Append("CarName=@CarName,");
			strSql.Append("DriverName=@DriverName,");
			strSql.Append("CarNum=@CarNum,");
			strSql.Append("Infors=@Infors,");
			strSql.Append("DELFLAG=@DELFLAG");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CarName", SqlDbType.VarChar,50),
					new SqlParameter("@DriverName", SqlDbType.VarChar,50),
					new SqlParameter("@CarNum", SqlDbType.VarChar,50),
					new SqlParameter("@Infors", SqlDbType.VarChar,5000),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.CarName;
			parameters[2].Value = model.DriverName;
			parameters[3].Value = model.CarNum;
			parameters[4].Value = model.Infors;
			parameters[5].Value = model.DELFLAG;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Project_CarList ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Project_CarList GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CarName,DriverName,CarNum,Infors,DELFLAG from Project_CarList ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Project_CarList model=new Dianda.Model.Project_CarList();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.CarName=ds.Tables[0].Rows[0]["CarName"].ToString();
				model.DriverName=ds.Tables[0].Rows[0]["DriverName"].ToString();
				model.CarNum=ds.Tables[0].Rows[0]["CarNum"].ToString();
				model.Infors=ds.Tables[0].Rows[0]["Infors"].ToString();
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
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
			strSql.Append("select ID,CarName,DriverName,CarNum,Infors,DELFLAG ");
			strSql.Append(" FROM Project_CarList ");
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
			strSql.Append(" ID,CarName,DriverName,CarNum,Infors,DELFLAG ");
			strSql.Append(" FROM Project_CarList ");
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
			parameters[0].Value = "Project_CarList";
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

