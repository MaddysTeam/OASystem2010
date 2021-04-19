using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Cash_Message。
	/// </summary>
	public class Cash_Message
	{
		public Cash_Message()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Cash_Message"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cash_Message");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Cash_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Cash_Message(");
            strSql.Append("CardName,CardholderID,DepartmentID,ProjectID,LimitNums,ApproverIDs,DATETIME,SendUserID,Notes,IsRead,ReadTime,DoNotes,DoUserID,Status,SFOrderID)");
			strSql.Append(" values (");
            strSql.Append("@CardName,@CardholderID,@DepartmentID,@ProjectID,@LimitNums,@ApproverIDs,@DATETIME,@SendUserID,@Notes,@IsRead,@ReadTime,@DoNotes,@DoUserID,@Status,@SFOrderID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CardName", SqlDbType.VarChar,100),
					new SqlParameter("@CardholderID", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@LimitNums", SqlDbType.Float,8),
					new SqlParameter("@ApproverIDs", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@SendUserID", SqlDbType.VarChar,50),
					new SqlParameter("@Notes", SqlDbType.VarChar,1000),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@DoNotes", SqlDbType.VarChar,1000),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@SFOrderID", SqlDbType.Int,4)};
			parameters[0].Value = model.CardName;
			parameters[1].Value = model.CardholderID;
			parameters[2].Value = model.DepartmentID;
			parameters[3].Value = model.ProjectID;
			parameters[4].Value = model.LimitNums;
			parameters[5].Value = model.ApproverIDs;
			parameters[6].Value = model.DATETIME;
			parameters[7].Value = model.SendUserID;
			parameters[8].Value = model.Notes;
			parameters[9].Value = model.IsRead;
			parameters[10].Value = model.ReadTime;
			parameters[11].Value = model.DoNotes;
			parameters[12].Value = model.DoUserID;
			parameters[13].Value = model.Status;
            parameters[14].Value = model.SFOrderID;

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
		public void Update(Dianda.Model.Cash_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Cash_Message set ");
			strSql.Append("CardName=@CardName,");
			strSql.Append("CardholderID=@CardholderID,");
			strSql.Append("DepartmentID=@DepartmentID,");
			strSql.Append("ProjectID=@ProjectID,");
			strSql.Append("LimitNums=@LimitNums,");
			strSql.Append("ApproverIDs=@ApproverIDs,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("SendUserID=@SendUserID,");
			strSql.Append("Notes=@Notes,");
			strSql.Append("IsRead=@IsRead,");
			strSql.Append("ReadTime=@ReadTime,");
			strSql.Append("DoNotes=@DoNotes,");
			strSql.Append("DoUserID=@DoUserID,");
            strSql.Append("Status=@Status,");
            strSql.Append("SFOrderID=@SFOrderID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CardName", SqlDbType.VarChar,100),
					new SqlParameter("@CardholderID", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@LimitNums", SqlDbType.Float,8),
					new SqlParameter("@ApproverIDs", SqlDbType.VarChar,50),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@SendUserID", SqlDbType.VarChar,50),
					new SqlParameter("@Notes", SqlDbType.VarChar,1000),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@DoNotes", SqlDbType.VarChar,1000),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@SFOrderID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.CardName;
			parameters[2].Value = model.CardholderID;
			parameters[3].Value = model.DepartmentID;
			parameters[4].Value = model.ProjectID;
			parameters[5].Value = model.LimitNums;
			parameters[6].Value = model.ApproverIDs;
			parameters[7].Value = model.DATETIME;
			parameters[8].Value = model.SendUserID;
			parameters[9].Value = model.Notes;
			parameters[10].Value = model.IsRead;
			parameters[11].Value = model.ReadTime;
			parameters[12].Value = model.DoNotes;
			parameters[13].Value = model.DoUserID;
			parameters[14].Value = model.Status;
            parameters[15].Value = model.SFOrderID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cash_Message ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Cash_Message GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,CardName,CardholderID,DepartmentID,ProjectID,LimitNums,ApproverIDs,DATETIME,SendUserID,Notes,IsRead,ReadTime,DoNotes,DoUserID,Status,SFOrderID from Cash_Message ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Cash_Message model=new Dianda.Model.Cash_Message();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.CardName=ds.Tables[0].Rows[0]["CardName"].ToString();
				model.CardholderID=ds.Tables[0].Rows[0]["CardholderID"].ToString();
				model.DepartmentID=ds.Tables[0].Rows[0]["DepartmentID"].ToString();
				if(ds.Tables[0].Rows[0]["ProjectID"].ToString()!="")
				{
					model.ProjectID=int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
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
				model.SendUserID=ds.Tables[0].Rows[0]["SendUserID"].ToString();
				model.Notes=ds.Tables[0].Rows[0]["Notes"].ToString();
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReadTime"].ToString()!="")
				{
					model.ReadTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReadTime"].ToString());
				}
				model.DoNotes=ds.Tables[0].Rows[0]["DoNotes"].ToString();
				model.DoUserID=ds.Tables[0].Rows[0]["DoUserID"].ToString();
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
                if (ds.Tables[0].Rows[0]["SFOrderID"].ToString() != "")
                {
                    model.SFOrderID = int.Parse(ds.Tables[0].Rows[0]["SFOrderID"].ToString());
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
            strSql.Append("select ID,CardName,CardholderID,DepartmentID,ProjectID,LimitNums,ApproverIDs,DATETIME,SendUserID,Notes,IsRead,ReadTime,DoNotes,DoUserID,Status,SFOrderID ");
			strSql.Append(" FROM Cash_Message ");
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
            strSql.Append(" ID,CardName,CardholderID,DepartmentID,ProjectID,LimitNums,ApproverIDs,DATETIME,SendUserID,Notes,IsRead,ReadTime,DoNotes,DoUserID,Status,SFOrderID ");
			strSql.Append(" FROM Cash_Message ");
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
			parameters[0].Value = "Cash_Message";
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

