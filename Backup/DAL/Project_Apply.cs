using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Project_Apply。
	/// </summary>
	public class Project_Apply
	{
		public Project_Apply()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Project_Apply"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Project_Apply");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Project_Apply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Project_Apply(");
			strSql.Append("ProjectID,DELFLAG,Status,AppType,Overviews,DATETIME,SendUserID,DepartmentID,ReadTime,DoUserID,CheckNote,TelNum,DoNote,Attachments,ApplyUserID,TEMP1,TEMP2,TEMP3,TEMP4)");
			strSql.Append(" values (");
			strSql.Append("@ProjectID,@DELFLAG,@Status,@AppType,@Overviews,@DATETIME,@SendUserID,@DepartmentID,@ReadTime,@DoUserID,@CheckNote,@TelNum,@DoNote,@Attachments,@ApplyUserID,@TEMP1,@TEMP2,@TEMP3,@TEMP4)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@AppType", SqlDbType.VarChar,50),
					new SqlParameter("@Overviews", SqlDbType.Text),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@SendUserID", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,150),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@CheckNote", SqlDbType.Text),
					new SqlParameter("@TelNum", SqlDbType.VarChar,50),
					new SqlParameter("@DoNote", SqlDbType.VarChar,5000),
					new SqlParameter("@Attachments", SqlDbType.VarChar,200),
					new SqlParameter("@ApplyUserID", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ProjectID;
			parameters[1].Value = model.DELFLAG;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.AppType;
			parameters[4].Value = model.Overviews;
			parameters[5].Value = model.DATETIME;
			parameters[6].Value = model.SendUserID;
			parameters[7].Value = model.DepartmentID;
			parameters[8].Value = model.ReadTime;
			parameters[9].Value = model.DoUserID;
			parameters[10].Value = model.CheckNote;
			parameters[11].Value = model.TelNum;
			parameters[12].Value = model.DoNote;
			parameters[13].Value = model.Attachments;
			parameters[14].Value = model.ApplyUserID;
			parameters[15].Value = model.TEMP1;
			parameters[16].Value = model.TEMP2;
			parameters[17].Value = model.TEMP3;
			parameters[18].Value = model.TEMP4;

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
		public void Update(Dianda.Model.Project_Apply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Project_Apply set ");
			strSql.Append("ProjectID=@ProjectID,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("Status=@Status,");
			strSql.Append("AppType=@AppType,");
			strSql.Append("Overviews=@Overviews,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("SendUserID=@SendUserID,");
			strSql.Append("DepartmentID=@DepartmentID,");
			strSql.Append("ReadTime=@ReadTime,");
			strSql.Append("DoUserID=@DoUserID,");
			strSql.Append("CheckNote=@CheckNote,");
			strSql.Append("TelNum=@TelNum,");
			strSql.Append("DoNote=@DoNote,");
			strSql.Append("Attachments=@Attachments,");
			strSql.Append("ApplyUserID=@ApplyUserID,");
			strSql.Append("TEMP1=@TEMP1,");
			strSql.Append("TEMP2=@TEMP2,");
			strSql.Append("TEMP3=@TEMP3,");
			strSql.Append("TEMP4=@TEMP4");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@AppType", SqlDbType.VarChar,50),
					new SqlParameter("@Overviews", SqlDbType.Text),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@SendUserID", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,150),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@CheckNote", SqlDbType.Text),
					new SqlParameter("@TelNum", SqlDbType.VarChar,50),
					new SqlParameter("@DoNote", SqlDbType.VarChar,5000),
					new SqlParameter("@Attachments", SqlDbType.VarChar,200),
					new SqlParameter("@ApplyUserID", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,50),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ProjectID;
			parameters[2].Value = model.DELFLAG;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.AppType;
			parameters[5].Value = model.Overviews;
			parameters[6].Value = model.DATETIME;
			parameters[7].Value = model.SendUserID;
			parameters[8].Value = model.DepartmentID;
			parameters[9].Value = model.ReadTime;
			parameters[10].Value = model.DoUserID;
			parameters[11].Value = model.CheckNote;
			parameters[12].Value = model.TelNum;
			parameters[13].Value = model.DoNote;
			parameters[14].Value = model.Attachments;
			parameters[15].Value = model.ApplyUserID;
			parameters[16].Value = model.TEMP1;
			parameters[17].Value = model.TEMP2;
			parameters[18].Value = model.TEMP3;
			parameters[19].Value = model.TEMP4;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Project_Apply ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Project_Apply GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ProjectID,DELFLAG,Status,AppType,Overviews,DATETIME,SendUserID,DepartmentID,ReadTime,DoUserID,CheckNote,TelNum,DoNote,Attachments,ApplyUserID,TEMP1,TEMP2,TEMP3,TEMP4 from Project_Apply ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Project_Apply model=new Dianda.Model.Project_Apply();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProjectID"].ToString()!="")
				{
					model.ProjectID=int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.AppType=ds.Tables[0].Rows[0]["AppType"].ToString();
				model.Overviews=ds.Tables[0].Rows[0]["Overviews"].ToString();
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				model.SendUserID=ds.Tables[0].Rows[0]["SendUserID"].ToString();
				model.DepartmentID=ds.Tables[0].Rows[0]["DepartmentID"].ToString();
				if(ds.Tables[0].Rows[0]["ReadTime"].ToString()!="")
				{
					model.ReadTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReadTime"].ToString());
				}
				model.DoUserID=ds.Tables[0].Rows[0]["DoUserID"].ToString();
				model.CheckNote=ds.Tables[0].Rows[0]["CheckNote"].ToString();
				model.TelNum=ds.Tables[0].Rows[0]["TelNum"].ToString();
				model.DoNote=ds.Tables[0].Rows[0]["DoNote"].ToString();
				model.Attachments=ds.Tables[0].Rows[0]["Attachments"].ToString();
				model.ApplyUserID=ds.Tables[0].Rows[0]["ApplyUserID"].ToString();
				model.TEMP1=ds.Tables[0].Rows[0]["TEMP1"].ToString();
				model.TEMP2=ds.Tables[0].Rows[0]["TEMP2"].ToString();
				model.TEMP3=ds.Tables[0].Rows[0]["TEMP3"].ToString();
				model.TEMP4=ds.Tables[0].Rows[0]["TEMP4"].ToString();
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
			strSql.Append("select ID,ProjectID,DELFLAG,Status,AppType,Overviews,DATETIME,SendUserID,DepartmentID,ReadTime,DoUserID,CheckNote,TelNum,DoNote,Attachments,ApplyUserID,TEMP1,TEMP2,TEMP3,TEMP4 ");
			strSql.Append(" FROM Project_Apply ");
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
			strSql.Append(" ID,ProjectID,DELFLAG,Status,AppType,Overviews,DATETIME,SendUserID,DepartmentID,ReadTime,DoUserID,CheckNote,TelNum,DoNote,Attachments,ApplyUserID,TEMP1,TEMP2,TEMP3,TEMP4 ");
			strSql.Append(" FROM Project_Apply ");
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
			parameters[0].Value = "Project_Apply";
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

