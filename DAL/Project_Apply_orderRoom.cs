using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Project_Apply_orderRoom。
	/// </summary>
	public class Project_Apply_orderRoom
	{
		public Project_Apply_orderRoom()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Project_Apply_orderRoom"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Project_Apply_orderRoom");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Project_Apply_orderRoom model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Project_Apply_orderRoom(");
			strSql.Append("ApplyID,RoomID,StartTime,EndTime,PeopleNum,MeetName,Address)");
			strSql.Append(" values (");
			strSql.Append("@ApplyID,@RoomID,@StartTime,@EndTime,@PeopleNum,@MeetName,@Address)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ApplyID", SqlDbType.Int,4),
					new SqlParameter("@RoomID", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@PeopleNum", SqlDbType.Int,4),
					new SqlParameter("@MeetName", SqlDbType.VarChar,100),
					new SqlParameter("@Address", SqlDbType.VarChar,500)};
			parameters[0].Value = model.ApplyID;
			parameters[1].Value = model.RoomID;
			parameters[2].Value = model.StartTime;
			parameters[3].Value = model.EndTime;
			parameters[4].Value = model.PeopleNum;
			parameters[5].Value = model.MeetName;
			parameters[6].Value = model.Address;

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
		public void Update(Dianda.Model.Project_Apply_orderRoom model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Project_Apply_orderRoom set ");
			strSql.Append("ApplyID=@ApplyID,");
			strSql.Append("RoomID=@RoomID,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("PeopleNum=@PeopleNum,");
			strSql.Append("MeetName=@MeetName,");
			strSql.Append("Address=@Address");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ApplyID", SqlDbType.Int,4),
					new SqlParameter("@RoomID", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@PeopleNum", SqlDbType.Int,4),
					new SqlParameter("@MeetName", SqlDbType.VarChar,100),
					new SqlParameter("@Address", SqlDbType.VarChar,500)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ApplyID;
			parameters[2].Value = model.RoomID;
			parameters[3].Value = model.StartTime;
			parameters[4].Value = model.EndTime;
			parameters[5].Value = model.PeopleNum;
			parameters[6].Value = model.MeetName;
			parameters[7].Value = model.Address;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Project_Apply_orderRoom ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Project_Apply_orderRoom GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ApplyID,RoomID,StartTime,EndTime,PeopleNum,MeetName,Address from Project_Apply_orderRoom ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Project_Apply_orderRoom model=new Dianda.Model.Project_Apply_orderRoom();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApplyID"].ToString()!="")
				{
					model.ApplyID=int.Parse(ds.Tables[0].Rows[0]["ApplyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RoomID"].ToString()!="")
				{
					model.RoomID=int.Parse(ds.Tables[0].Rows[0]["RoomID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PeopleNum"].ToString()!="")
				{
					model.PeopleNum=int.Parse(ds.Tables[0].Rows[0]["PeopleNum"].ToString());
				}
				model.MeetName=ds.Tables[0].Rows[0]["MeetName"].ToString();
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
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
			strSql.Append("select ID,ApplyID,RoomID,StartTime,EndTime,PeopleNum,MeetName,Address ");
			strSql.Append(" FROM Project_Apply_orderRoom ");
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
			strSql.Append(" ID,ApplyID,RoomID,StartTime,EndTime,PeopleNum,MeetName,Address ");
			strSql.Append(" FROM Project_Apply_orderRoom ");
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
			parameters[0].Value = "Project_Apply_orderRoom";
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

