using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Dianda.DAL
{
	/// <summary>
	/// 数据访问类Project_Projects。
	/// </summary>
	public class Project_Projects
	{
		public Project_Projects()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Project_Projects"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Project_Projects");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Dianda.Model.Project_Projects model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Project_Projects(");
			strSql.Append("NAMES,DELFLAG,Status,LeaderID,DepartmentID,DepartmentNames,StartTime,EndTime,CashTotal,CashCardID,Overviews,Attachments,DATETIME,SendUserID,DoUserID,ReadTime,DoNote,ColumnsID,CashDw,ProjectType,BudgetList,TEMP1,TEMP2,TEMP3,TEMP4)");
			strSql.Append(" values (");
			strSql.Append("@NAMES,@DELFLAG,@Status,@LeaderID,@DepartmentID,@DepartmentNames,@StartTime,@EndTime,@CashTotal,@CashCardID,@Overviews,@Attachments,@DATETIME,@SendUserID,@DoUserID,@ReadTime,@DoNote,@ColumnsID,@CashDw,@ProjectType,@BudgetList,@TEMP1,@TEMP2,@TEMP3,@TEMP4)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NAMES", SqlDbType.VarChar,50),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@LeaderID", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,5000),
					new SqlParameter("@DepartmentNames", SqlDbType.VarChar,5000),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@CashTotal", SqlDbType.Float,8),
					new SqlParameter("@CashCardID", SqlDbType.Int,4),
					new SqlParameter("@Overviews", SqlDbType.Text),
					new SqlParameter("@Attachments", SqlDbType.VarChar,200),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@SendUserID", SqlDbType.VarChar,50),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@DoNote", SqlDbType.VarChar,5000),
					new SqlParameter("@ColumnsID", SqlDbType.Int,4),
					new SqlParameter("@CashDw", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectType", SqlDbType.Int,4),
					new SqlParameter("@BudgetList", SqlDbType.VarChar,5000),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,100),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,100),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,100),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,100)};
			parameters[0].Value = model.NAMES;
			parameters[1].Value = model.DELFLAG;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.LeaderID;
			parameters[4].Value = model.DepartmentID;
			parameters[5].Value = model.DepartmentNames;
			parameters[6].Value = model.StartTime;
			parameters[7].Value = model.EndTime;
			parameters[8].Value = model.CashTotal;
			parameters[9].Value = model.CashCardID;
			parameters[10].Value = model.Overviews;
			parameters[11].Value = model.Attachments;
			parameters[12].Value = model.DATETIME;
			parameters[13].Value = model.SendUserID;
			parameters[14].Value = model.DoUserID;
			parameters[15].Value = model.ReadTime;
			parameters[16].Value = model.DoNote;
			parameters[17].Value = model.ColumnsID;
			parameters[18].Value = model.CashDw;
			parameters[19].Value = model.ProjectType;
			parameters[20].Value = model.BudgetList;
			parameters[21].Value = model.TEMP1;
			parameters[22].Value = model.TEMP2;
			parameters[23].Value = model.TEMP3;
			parameters[24].Value = model.TEMP4;

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
		public void Update(Dianda.Model.Project_Projects model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Project_Projects set ");
			strSql.Append("NAMES=@NAMES,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("Status=@Status,");
			strSql.Append("LeaderID=@LeaderID,");
			strSql.Append("DepartmentID=@DepartmentID,");
			strSql.Append("DepartmentNames=@DepartmentNames,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("CashTotal=@CashTotal,");
			strSql.Append("CashCardID=@CashCardID,");
			strSql.Append("Overviews=@Overviews,");
			strSql.Append("Attachments=@Attachments,");
			strSql.Append("DATETIME=@DATETIME,");
			strSql.Append("SendUserID=@SendUserID,");
			strSql.Append("DoUserID=@DoUserID,");
			strSql.Append("ReadTime=@ReadTime,");
			strSql.Append("DoNote=@DoNote,");
			strSql.Append("ColumnsID=@ColumnsID,");
			strSql.Append("CashDw=@CashDw,");
			strSql.Append("ProjectType=@ProjectType,");
			strSql.Append("BudgetList=@BudgetList,");
			strSql.Append("TEMP1=@TEMP1,");
			strSql.Append("TEMP2=@TEMP2,");
			strSql.Append("TEMP3=@TEMP3,");
			strSql.Append("TEMP4=@TEMP4");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@NAMES", SqlDbType.VarChar,50),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@LeaderID", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,5000),
					new SqlParameter("@DepartmentNames", SqlDbType.VarChar,5000),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@CashTotal", SqlDbType.Float,8),
					new SqlParameter("@CashCardID", SqlDbType.Int,4),
					new SqlParameter("@Overviews", SqlDbType.Text),
					new SqlParameter("@Attachments", SqlDbType.VarChar,200),
					new SqlParameter("@DATETIME", SqlDbType.DateTime),
					new SqlParameter("@SendUserID", SqlDbType.VarChar,50),
					new SqlParameter("@DoUserID", SqlDbType.VarChar,50),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@DoNote", SqlDbType.VarChar,5000),
					new SqlParameter("@ColumnsID", SqlDbType.Int,4),
					new SqlParameter("@CashDw", SqlDbType.VarChar,50),
					new SqlParameter("@ProjectType", SqlDbType.Int,4),
					new SqlParameter("@BudgetList", SqlDbType.VarChar,5000),
					new SqlParameter("@TEMP1", SqlDbType.VarChar,100),
					new SqlParameter("@TEMP2", SqlDbType.VarChar,100),
					new SqlParameter("@TEMP3", SqlDbType.VarChar,100),
					new SqlParameter("@TEMP4", SqlDbType.VarChar,100)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAMES;
			parameters[2].Value = model.DELFLAG;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.LeaderID;
			parameters[5].Value = model.DepartmentID;
			parameters[6].Value = model.DepartmentNames;
			parameters[7].Value = model.StartTime;
			parameters[8].Value = model.EndTime;
			parameters[9].Value = model.CashTotal;
			parameters[10].Value = model.CashCardID;
			parameters[11].Value = model.Overviews;
			parameters[12].Value = model.Attachments;
			parameters[13].Value = model.DATETIME;
			parameters[14].Value = model.SendUserID;
			parameters[15].Value = model.DoUserID;
			parameters[16].Value = model.ReadTime;
			parameters[17].Value = model.DoNote;
			parameters[18].Value = model.ColumnsID;
			parameters[19].Value = model.CashDw;
			parameters[20].Value = model.ProjectType;
			parameters[21].Value = model.BudgetList;
			parameters[22].Value = model.TEMP1;
			parameters[23].Value = model.TEMP2;
			parameters[24].Value = model.TEMP3;
			parameters[25].Value = model.TEMP4;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Project_Projects ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dianda.Model.Project_Projects GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,NAMES,DELFLAG,Status,LeaderID,DepartmentID,DepartmentNames,StartTime,EndTime,CashTotal,CashCardID,Overviews,Attachments,DATETIME,SendUserID,DoUserID,ReadTime,DoNote,ColumnsID,CashDw,ProjectType,BudgetList,TEMP1,TEMP2,TEMP3,TEMP4 from Project_Projects ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Dianda.Model.Project_Projects model=new Dianda.Model.Project_Projects();
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
				model.LeaderID=ds.Tables[0].Rows[0]["LeaderID"].ToString();
				model.DepartmentID=ds.Tables[0].Rows[0]["DepartmentID"].ToString();
				model.DepartmentNames=ds.Tables[0].Rows[0]["DepartmentNames"].ToString();
				if(ds.Tables[0].Rows[0]["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CashTotal"].ToString()!="")
				{
					model.CashTotal=decimal.Parse(ds.Tables[0].Rows[0]["CashTotal"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CashCardID"].ToString()!="")
				{
					model.CashCardID=int.Parse(ds.Tables[0].Rows[0]["CashCardID"].ToString());
				}
				model.Overviews=ds.Tables[0].Rows[0]["Overviews"].ToString();
				model.Attachments=ds.Tables[0].Rows[0]["Attachments"].ToString();
				if(ds.Tables[0].Rows[0]["DATETIME"].ToString()!="")
				{
					model.DATETIME=DateTime.Parse(ds.Tables[0].Rows[0]["DATETIME"].ToString());
				}
				model.SendUserID=ds.Tables[0].Rows[0]["SendUserID"].ToString();
				model.DoUserID=ds.Tables[0].Rows[0]["DoUserID"].ToString();
				if(ds.Tables[0].Rows[0]["ReadTime"].ToString()!="")
				{
					model.ReadTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReadTime"].ToString());
				}
				model.DoNote=ds.Tables[0].Rows[0]["DoNote"].ToString();
				if(ds.Tables[0].Rows[0]["ColumnsID"].ToString()!="")
				{
					model.ColumnsID=int.Parse(ds.Tables[0].Rows[0]["ColumnsID"].ToString());
				}
				model.CashDw=ds.Tables[0].Rows[0]["CashDw"].ToString();
				if(ds.Tables[0].Rows[0]["ProjectType"].ToString()!="")
				{
					model.ProjectType=int.Parse(ds.Tables[0].Rows[0]["ProjectType"].ToString());
				}
				model.BudgetList=ds.Tables[0].Rows[0]["BudgetList"].ToString();
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
			strSql.Append("select ID,NAMES,DELFLAG,Status,LeaderID,DepartmentID,DepartmentNames,StartTime,EndTime,CashTotal,CashCardID,Overviews,Attachments,DATETIME,SendUserID,DoUserID,ReadTime,DoNote,ColumnsID,CashDw,ProjectType,BudgetList,TEMP1,TEMP2,TEMP3,TEMP4 ");
			strSql.Append(" FROM Project_Projects ");
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
			strSql.Append(" ID,NAMES,DELFLAG,Status,LeaderID,DepartmentID,DepartmentNames,StartTime,EndTime,CashTotal,CashCardID,Overviews,Attachments,DATETIME,SendUserID,DoUserID,ReadTime,DoNote,ColumnsID,CashDw,ProjectType,BudgetList,TEMP1,TEMP2,TEMP3,TEMP4 ");
			strSql.Append(" FROM Project_Projects ");
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
			parameters[0].Value = "Project_Projects";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        /// <summary>
        /// 得到项目人员
        /// </summary>
        /// <param name="Pro_ID">项目人员</param>
        /// <returns></returns>
        public DataTable GetAllRY(string Pro_ID)
        {
            DataTable RY_dt = new DataTable();
            RY_dt.Columns.Add("UserID", System.Type.GetType("System.String"));
            RY_dt.Columns.Add("UserInfos", System.Type.GetType("System.String"));
            try
            {
                string sql = "select b.UserID,b.UserInfos from Project_Projects a left outer join Project_Columns b on a.ColumnsID = b.ID where b.UserID is not null and b.UserInfos is not null and a.ID=" + Pro_ID;

                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                string[] UserID = dt.Rows[0]["UserID"].ToString().Split(',');
                string[] UserInfos = dt.Rows[0]["UserInfos"].ToString().Split(',');


                int Len = 0;
                if (UserID.Length > UserInfos.Length)
                {
                    Len = UserInfos.Length;
                }
                else
                {
                    Len = UserID.Length;
                }
                for (int i = 0; i < Len; i++)
                {
                    RY_dt.Rows.Add(new object[] { UserID[i], UserInfos[i] });
                }
                return RY_dt;
            }
            catch
            {
                return RY_dt;
            }

        }
		#endregion  成员方法
	}
}

