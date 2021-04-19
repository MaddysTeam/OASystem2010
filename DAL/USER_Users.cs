using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类USER_Users。
	/// </summary>
	public class USER_Users
	{
		public USER_Users()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from USER_Users");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Dianda.Model.USER_Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into USER_Users(");
			strSql.Append("ID,USERNAME,PASSWORD,REALNAME,SEX,DepartMentID,StationID,TEL,EMAIL,Holidays,WorkStats,DatesEmployed,LeaveDates,BIRTHDAY,NativePlace,EducationLevel,ADDRESS,GraduateSchool,Major,TrackRecord,DATETIME,GROUPS,DELFLAG,IMAGES,IsManager,TEMP1,TEMP2,TEMP3,TEMP4,DepartMentName)");
			strSql.Append(" values (");
			strSql.Append("@ID,@USERNAME,@PASSWORD,@REALNAME,@SEX,@DepartMentID,@StationID,@TEL,@EMAIL,@Holidays,@WorkStats,@DatesEmployed,@LeaveDates,@BIRTHDAY,@NativePlace,@EducationLevel,@ADDRESS,@GraduateSchool,@Major,@TrackRecord,@DATETIME,@GROUPS,@DELFLAG,@IMAGES,@IsManager,@TEMP1,@TEMP2,@TEMP3,@TEMP4,@DepartMentName)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@USERNAME", SqlDbType.VarChar,50),
					new SqlParameter("@PASSWORD", SqlDbType.VarChar,50),
					new SqlParameter("@REALNAME", SqlDbType.VarChar,50),
					new SqlParameter("@SEX", SqlDbType.VarChar,10),
					new SqlParameter("@DepartMentID", SqlDbType.VarChar,5000),
					new SqlParameter("@StationID", SqlDbType.VarChar,50),
					new SqlParameter("@TEL", SqlDbType.VarChar,50),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,50),
					new SqlParameter("@Holidays", SqlDbType.Int,4),
					new SqlParameter("@WorkStats", SqlDbType.NVarChar,50),
					new SqlParameter("@DatesEmployed", SqlDbType.DateTime),
					new SqlParameter("@LeaveDates", SqlDbType.DateTime),
					new SqlParameter("@BIRTHDAY", SqlDbType.VarChar,50),
					new SqlParameter("@NativePlace", SqlDbType.VarChar,100),
					new SqlParameter("@EducationLevel", SqlDbType.VarChar,100),
					new SqlParameter("@ADDRESS", SqlDbType.VarChar,100),
					new SqlParameter("@GraduateSchool", SqlDbType.VarChar,100),
					new SqlParameter("@Major", SqlDbType.VarChar,100),
					new SqlParameter("@TrackRecord", SqlDbType.Text),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@GROUPS", SqlDbType.Text),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@IMAGES", SqlDbType.VarChar,100),
					new SqlParameter("@IsManager", SqlDbType.Int,4),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,50),
					new SqlParameter("@DepartMentName", SqlDbType.Text)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.USERNAME;
			parameters[2].Value = model.PASSWORD;
			parameters[3].Value = model.REALNAME;
			parameters[4].Value = model.SEX;
			parameters[5].Value = model.DepartMentID;
			parameters[6].Value = model.StationID;
			parameters[7].Value = model.TEL;
			parameters[8].Value = model.EMAIL;
			parameters[9].Value = model.Holidays;
			parameters[10].Value = model.WorkStats;
			parameters[11].Value = model.DatesEmployed;
			parameters[12].Value = model.LeaveDates;
			parameters[13].Value = model.BIRTHDAY;
			parameters[14].Value = model.NativePlace;
			parameters[15].Value = model.EducationLevel;
			parameters[16].Value = model.ADDRESS;
			parameters[17].Value = model.GraduateSchool;
			parameters[18].Value = model.Major;
			parameters[19].Value = model.TrackRecord;
			parameters[20].Value = model.DATETIME;
			parameters[21].Value = model.GROUPS;
			parameters[22].Value = model.DELFLAG;
			parameters[23].Value = model.IMAGES;
			parameters[24].Value = model.IsManager;
			parameters[25].Value = model.TEMP1;
			parameters[26].Value = model.TEMP2;
			parameters[27].Value = model.TEMP3;
			parameters[28].Value = model.TEMP4;
			parameters[29].Value = model.DepartMentName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Dianda.Model.USER_Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update USER_Users set ");
			strSql.Append("USERNAME=@USERNAME,");
			strSql.Append("PASSWORD=@PASSWORD,");
			strSql.Append("REALNAME=@REALNAME,");
			strSql.Append("SEX=@SEX,");
			strSql.Append("DepartMentID=@DepartMentID,");
			strSql.Append("StationID=@StationID,");
			strSql.Append("TEL=@TEL,");
			strSql.Append("EMAIL=@EMAIL,");
			strSql.Append("Holidays=@Holidays,");
			strSql.Append("WorkStats=@WorkStats,");
			strSql.Append("DatesEmployed=@DatesEmployed,");
			strSql.Append("LeaveDates=@LeaveDates,");
			strSql.Append("BIRTHDAY=@BIRTHDAY,");
			strSql.Append("NativePlace=@NativePlace,");
			strSql.Append("EducationLevel=@EducationLevel,");
			strSql.Append("ADDRESS=@ADDRESS,");
			strSql.Append("GraduateSchool=@GraduateSchool,");
			strSql.Append("Major=@Major,");
			strSql.Append("TrackRecord=@TrackRecord,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("GROUPS=@GROUPS,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("IMAGES=@IMAGES,");
			strSql.Append("IsManager=@IsManager,");
			strSql.Append("TEMP1=@TEMP1,");
			strSql.Append("TEMP2=@TEMP2,");
			strSql.Append("TEMP3=@TEMP3,");
			strSql.Append("TEMP4=@TEMP4,");
			strSql.Append("DepartMentName=@DepartMentName");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@USERNAME", SqlDbType.VarChar,50),
					new SqlParameter("@PASSWORD", SqlDbType.VarChar,50),
					new SqlParameter("@REALNAME", SqlDbType.VarChar,50),
					new SqlParameter("@SEX", SqlDbType.VarChar,10),
					new SqlParameter("@DepartMentID", SqlDbType.VarChar,5000),
					new SqlParameter("@StationID", SqlDbType.VarChar,50),
					new SqlParameter("@TEL", SqlDbType.VarChar,50),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,50),
					new SqlParameter("@Holidays", SqlDbType.Int,4),
					new SqlParameter("@WorkStats", SqlDbType.NVarChar,50),
					new SqlParameter("@DatesEmployed", SqlDbType.DateTime),
					new SqlParameter("@LeaveDates", SqlDbType.DateTime),
					new SqlParameter("@BIRTHDAY", SqlDbType.VarChar,50),
					new SqlParameter("@NativePlace", SqlDbType.VarChar,100),
					new SqlParameter("@EducationLevel", SqlDbType.VarChar,100),
					new SqlParameter("@ADDRESS", SqlDbType.VarChar,100),
					new SqlParameter("@GraduateSchool", SqlDbType.VarChar,100),
					new SqlParameter("@Major", SqlDbType.VarChar,100),
					new SqlParameter("@TrackRecord", SqlDbType.Text),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@GROUPS", SqlDbType.Text),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@IMAGES", SqlDbType.VarChar,100),
					new SqlParameter("@IsManager", SqlDbType.Int,4),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,50),
					new SqlParameter("@DepartMentName", SqlDbType.Text)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.USERNAME;
			parameters[2].Value = model.PASSWORD;
			parameters[3].Value = model.REALNAME;
			parameters[4].Value = model.SEX;
			parameters[5].Value = model.DepartMentID;
			parameters[6].Value = model.StationID;
			parameters[7].Value = model.TEL;
			parameters[8].Value = model.EMAIL;
			parameters[9].Value = model.Holidays;
			parameters[10].Value = model.WorkStats;
			parameters[11].Value = model.DatesEmployed;
			parameters[12].Value = model.LeaveDates;
			parameters[13].Value = model.BIRTHDAY;
			parameters[14].Value = model.NativePlace;
			parameters[15].Value = model.EducationLevel;
			parameters[16].Value = model.ADDRESS;
			parameters[17].Value = model.GraduateSchool;
			parameters[18].Value = model.Major;
			parameters[19].Value = model.TrackRecord;
			parameters[20].Value = model.DATETIME;
			parameters[21].Value = model.GROUPS;
			parameters[22].Value = model.DELFLAG;
			parameters[23].Value = model.IMAGES;
			parameters[24].Value = model.IsManager;
			parameters[25].Value = model.TEMP1;
			parameters[26].Value = model.TEMP2;
			parameters[27].Value = model.TEMP3;
			parameters[28].Value = model.TEMP4;
			parameters[29].Value = model.DepartMentName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from USER_Users ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.USER_Users GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,USERNAME,PASSWORD,REALNAME,SEX,DepartMentID,StationID,TEL,EMAIL,Holidays,WorkStats,DatesEmployed,LeaveDates,BIRTHDAY,NativePlace,EducationLevel,ADDRESS,GraduateSchool,Major,TrackRecord,DATETIME,GROUPS,DELFLAG,IMAGES,IsManager,TEMP1,TEMP2,TEMP3,TEMP4,DepartMentName from USER_Users ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			Dianda.Model.USER_Users model=new Dianda.Model.USER_Users();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ID=ds.Tables[0].Rows[0]["ID"].ToString();
				model.USERNAME=ds.Tables[0].Rows[0]["USERNAME"].ToString();
				model.PASSWORD=ds.Tables[0].Rows[0]["PASSWORD"].ToString();
				model.REALNAME=ds.Tables[0].Rows[0]["REALNAME"].ToString();
				model.SEX=ds.Tables[0].Rows[0]["SEX"].ToString();
				model.DepartMentID=ds.Tables[0].Rows[0]["DepartMentID"].ToString();
				model.StationID=ds.Tables[0].Rows[0]["StationID"].ToString();
				model.TEL=ds.Tables[0].Rows[0]["TEL"].ToString();
				model.EMAIL=ds.Tables[0].Rows[0]["EMAIL"].ToString();
				if(ds.Tables[0].Rows[0]["Holidays"].ToString()!="")
				{
					model.Holidays=int.Parse(ds.Tables[0].Rows[0]["Holidays"].ToString());
				}
				model.WorkStats=ds.Tables[0].Rows[0]["WorkStats"].ToString();
				if(ds.Tables[0].Rows[0]["DatesEmployed"].ToString()!="")
				{
					model.DatesEmployed=DateTime.Parse(ds.Tables[0].Rows[0]["DatesEmployed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LeaveDates"].ToString()!="")
				{
					model.LeaveDates=DateTime.Parse(ds.Tables[0].Rows[0]["LeaveDates"].ToString());
				}
				model.BIRTHDAY=ds.Tables[0].Rows[0]["BIRTHDAY"].ToString();
				model.NativePlace=ds.Tables[0].Rows[0]["NativePlace"].ToString();
				model.EducationLevel=ds.Tables[0].Rows[0]["EducationLevel"].ToString();
				model.ADDRESS=ds.Tables[0].Rows[0]["ADDRESS"].ToString();
				model.GraduateSchool=ds.Tables[0].Rows[0]["GraduateSchool"].ToString();
				model.Major=ds.Tables[0].Rows[0]["Major"].ToString();
				model.TrackRecord=ds.Tables[0].Rows[0]["TrackRecord"].ToString();
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				model.GROUPS=ds.Tables[0].Rows[0]["GROUPS"].ToString();
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				model.IMAGES=ds.Tables[0].Rows[0]["IMAGES"].ToString();
				if(ds.Tables[0].Rows[0]["IsManager"].ToString()!="")
				{
					model.IsManager=int.Parse(ds.Tables[0].Rows[0]["IsManager"].ToString());
				}
				model.TEMP1=ds.Tables[0].Rows[0]["TEMP1"].ToString();
				model.TEMP2=ds.Tables[0].Rows[0]["TEMP2"].ToString();
				model.TEMP3=ds.Tables[0].Rows[0]["TEMP3"].ToString();
				model.TEMP4=ds.Tables[0].Rows[0]["TEMP4"].ToString();
				model.DepartMentName=ds.Tables[0].Rows[0]["DepartMentName"].ToString();
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
			strSql.Append("select ID,USERNAME,PASSWORD,REALNAME,SEX,DepartMentID,StationID,TEL,EMAIL,Holidays,WorkStats,DatesEmployed,LeaveDates,BIRTHDAY,NativePlace,EducationLevel,ADDRESS,GraduateSchool,Major,TrackRecord,DATETIME,GROUPS,DELFLAG,IMAGES,IsManager,TEMP1,TEMP2,TEMP3,TEMP4,DepartMentName ");
			strSql.Append(" FROM USER_Users ");
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
			strSql.Append(" ID,USERNAME,PASSWORD,REALNAME,SEX,DepartMentID,StationID,TEL,EMAIL,Holidays,WorkStats,DatesEmployed,LeaveDates,BIRTHDAY,NativePlace,EducationLevel,ADDRESS,GraduateSchool,Major,TrackRecord,DATETIME,GROUPS,DELFLAG,IMAGES,IsManager,TEMP1,TEMP2,TEMP3,TEMP4,DepartMentName ");
			strSql.Append(" FROM USER_Users ");
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
			parameters[0].Value = "USER_Users";
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

