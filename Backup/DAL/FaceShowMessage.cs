using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类FaceShowMessage。
	/// </summary>
	public class FaceShowMessage
	{
		public FaceShowMessage()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "FaceShowMessage"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FaceShowMessage");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.FaceShowMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FaceShowMessage(");
			strSql.Append("URLS,NewsType,DATETIME,ReadTime,IsRead,Receive,FromTable,NewsID,ProjectID,DELFLAG)");
			strSql.Append(" values (");
			strSql.Append("@URLS,@NewsType,@DATETIME,@ReadTime,@IsRead,@Receive,@FromTable,@NewsID,@ProjectID,@DELFLAG)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@URLS", SqlDbType.VarChar,1000),
					new SqlParameter("@NewsType", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@Receive", SqlDbType.VarChar,50),
					new SqlParameter("@FromTable", SqlDbType.VarChar,50),
					new SqlParameter("@NewsID", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4)};
			parameters[0].Value = model.URLS;
			parameters[1].Value = model.NewsType;
			parameters[2].Value = model.DATETIME;
			parameters[3].Value = model.ReadTime;
			parameters[4].Value = model.IsRead;
			parameters[5].Value = model.Receive;
			parameters[6].Value = model.FromTable;
			parameters[7].Value = model.NewsID;
			parameters[8].Value = model.ProjectID;
			parameters[9].Value = model.DELFLAG;

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
		public void Update(Dianda.Model.FaceShowMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FaceShowMessage set ");
			strSql.Append("URLS=@URLS,");
			strSql.Append("NewsType=@NewsType,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("ReadTime=@ReadTime,");
			strSql.Append("IsRead=@IsRead,");
			strSql.Append("Receive=@Receive,");
			strSql.Append("FromTable=@FromTable,");
			strSql.Append("NewsID=@NewsID,");
			strSql.Append("ProjectID=@ProjectID,");
			strSql.Append("DELFLAG=@DELFLAG");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@URLS", SqlDbType.VarChar,1000),
					new SqlParameter("@NewsType", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@Receive", SqlDbType.VarChar,50),
					new SqlParameter("@FromTable", SqlDbType.VarChar,50),
					new SqlParameter("@NewsID", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.URLS;
			parameters[2].Value = model.NewsType;
			parameters[3].Value = model.DATETIME;
			parameters[4].Value = model.ReadTime;
			parameters[5].Value = model.IsRead;
			parameters[6].Value = model.Receive;
			parameters[7].Value = model.FromTable;
			parameters[8].Value = model.NewsID;
			parameters[9].Value = model.ProjectID;
			parameters[10].Value = model.DELFLAG;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FaceShowMessage ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.FaceShowMessage GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,URLS,NewsType,DATETIME,ReadTime,IsRead,Receive,FromTable,NewsID,ProjectID,DELFLAG from FaceShowMessage ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.FaceShowMessage model=new Dianda.Model.FaceShowMessage();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.URLS=ds.Tables[0].Rows[0]["URLS"].ToString();
				model.NewsType=ds.Tables[0].Rows[0]["NewsType"].ToString();
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReadTime"].ToString()!="")
				{
					model.ReadTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReadTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
				}
				model.Receive=ds.Tables[0].Rows[0]["Receive"].ToString();
				model.FromTable=ds.Tables[0].Rows[0]["FromTable"].ToString();
				model.NewsID=ds.Tables[0].Rows[0]["NewsID"].ToString();
				if(ds.Tables[0].Rows[0]["ProjectID"].ToString()!="")
				{
					model.ProjectID=int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
				}
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
			strSql.Append("select ID,URLS,NewsType,DATETIME,ReadTime,IsRead,Receive,FromTable,NewsID,ProjectID,DELFLAG ");
			strSql.Append(" FROM FaceShowMessage ");
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
			strSql.Append(" ID,URLS,NewsType,DATETIME,ReadTime,IsRead,Receive,FromTable,NewsID,ProjectID,DELFLAG ");
			strSql.Append(" FROM FaceShowMessage ");
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
			parameters[0].Value = "FaceShowMessage";
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

