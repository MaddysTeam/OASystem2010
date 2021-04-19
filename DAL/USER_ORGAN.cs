using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace Dianda.DAL
{
	/// <summary>
	/// ���ݷ�����USER_ORGAN��
	/// </summary>
	public class USER_ORGAN
	{
		public USER_ORGAN()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
        public bool Exists(string NAME)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from USER_ORGAN");
            strSql.Append(" where NAME=@NAME and delflag=0 ");
			SqlParameter[] parameters = {
					new SqlParameter("@NAME", SqlDbType.VarChar,100)};
            parameters[0].Value = NAME;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Dianda.Model.USER_ORGAN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into USER_ORGAN(");
			strSql.Append("ID,NAME,PID,ISMAIN,DELFLAG,PATH,TYPES,INFOR,INFOR2)");
			strSql.Append(" values (");
			strSql.Append("@ID,@NAME,@PID,@ISMAIN,@DELFLAG,@PATH,@TYPES,@INFOR,@INFOR2)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@PID", SqlDbType.VarChar,50),
					new SqlParameter("@ISMAIN", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@PATH", SqlDbType.VarChar,500),
					new SqlParameter("@TYPES", SqlDbType.VarChar,50),
					new SqlParameter("@INFOR", SqlDbType.Text),
					new SqlParameter("@INFOR2", SqlDbType.Text)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.PID;
			parameters[3].Value = model.ISMAIN;
			parameters[4].Value = model.DELFLAG;
			parameters[5].Value = model.PATH;
			parameters[6].Value = model.TYPES;
			parameters[7].Value = model.INFOR;
			parameters[8].Value = model.INFOR2;
            if (model.ISMAIN == 1)                  //�������У���޸�����ismainΪ0
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("update USER_ORGAN set ");
                strSql1.Append("ISMAIN=0 where delflag=0");
                SqlParameter[] parameters1 = {
					};
                DbHelperSQL.ExecuteSql(strSql1.ToString(), parameters1);
            }

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Dianda.Model.USER_ORGAN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update USER_ORGAN set ");
			strSql.Append("NAME=@NAME,");
			strSql.Append("PID=@PID,");
			strSql.Append("ISMAIN=@ISMAIN,");
			strSql.Append("DELFLAG=@DELFLAG,");
			strSql.Append("PATH=@PATH,");
			strSql.Append("TYPES=@TYPES,");
			strSql.Append("INFOR=@INFOR,");
			strSql.Append("INFOR2=@INFOR2");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@PID", SqlDbType.VarChar,50),
					new SqlParameter("@ISMAIN", SqlDbType.Int,4),
					new SqlParameter("@DELFLAG", SqlDbType.Int,4),
					new SqlParameter("@PATH", SqlDbType.VarChar,500),
					new SqlParameter("@TYPES", SqlDbType.VarChar,50),
					new SqlParameter("@INFOR", SqlDbType.Text),
					new SqlParameter("@INFOR2", SqlDbType.Text)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.PID;
			parameters[3].Value = model.ISMAIN;
			parameters[4].Value = model.DELFLAG;
			parameters[5].Value = model.PATH;
			parameters[6].Value = model.TYPES;
			parameters[7].Value = model.INFOR;
			parameters[8].Value = model.INFOR2;

            if (model.ISMAIN == 1)                  //�������У���޸�����ismainΪ0
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("update USER_ORGAN set ");
                strSql1.Append("ISMAIN=0 where delflag=0");
                SqlParameter[] parameters1 = {
					};
                DbHelperSQL.ExecuteSql(strSql1.ToString(), parameters1);
            }

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
        /// ɾ����֯�����Լ���������
		/// </summary>
		public void Delete(string path)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USER_ORGAN set delflag=1 ");           
            if (path.Trim() != "")
            {
                strSql.Append(" where path like '" +path+"%'and DELFLAG='0' " );
            }
            SqlParameter[] parameters = {
					};
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Dianda.Model.USER_ORGAN GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,NAME,PID,ISMAIN,DELFLAG,PATH,TYPES,INFOR,INFOR2 from USER_ORGAN ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
			parameters[0].Value = ID;

			Dianda.Model.USER_ORGAN model=new Dianda.Model.USER_ORGAN();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ID=ds.Tables[0].Rows[0]["ID"].ToString();
				model.NAME=ds.Tables[0].Rows[0]["NAME"].ToString();
				model.PID=ds.Tables[0].Rows[0]["PID"].ToString();
				if(ds.Tables[0].Rows[0]["ISMAIN"].ToString()!="")
				{
					model.ISMAIN=int.Parse(ds.Tables[0].Rows[0]["ISMAIN"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DELFLAG"].ToString()!="")
				{
					model.DELFLAG=int.Parse(ds.Tables[0].Rows[0]["DELFLAG"].ToString());
				}
				model.PATH=ds.Tables[0].Rows[0]["PATH"].ToString();
				model.TYPES=ds.Tables[0].Rows[0]["TYPES"].ToString();
				model.INFOR=ds.Tables[0].Rows[0]["INFOR"].ToString();
				model.INFOR2=ds.Tables[0].Rows[0]["INFOR2"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,NAME,PID,ISMAIN,DELFLAG,PATH,TYPES,INFOR,INFOR2 ");
			strSql.Append(" FROM USER_ORGAN ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// �������õ�������֯����
        /// </summary>
        public DataSet GetDropDownListAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NAME,PID,ISMAIN,DELFLAG,PATH,TYPES,INFOR,INFOR2 ");
            strSql.Append(" FROM USER_ORGAN where delflag='0' order by path");
            
            return DbHelperSQL.Query(strSql.ToString());
        }        		

       

		#endregion  ��Ա����
	}
}

