using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用

namespace Dianda.DAL
{
    public class YYJEHZ
    {
        public DataTable GetYYJEHZ()
        {
            string sql = "select tab1.GetDateTime,isnull(tab2.Tol,0) DSH,isnull(tab3.Tol,0) SHTG,isnull(tab4.Tol,0) SHBTG " +
                " from " +
                    " (select convert(varchar(10),GetDateTime,120) GetDateTime " +
                    " from vCash_Apply where PDEL=0 group by convert(varchar(10),GetDateTime,120)) tab1 " +
                    " left outer join (select convert(varchar(10),GetDateTime,120) GetDateTime, sum(ApplyCount) Tol " +
                    " from vCash_Apply " +
                    " where statas='0' group by convert(varchar(10),GetDateTime,120)) tab2 on tab1.GetDateTime=tab2.GetDateTime " +
                    " left outer join (select convert(varchar(10),GetDateTime,120) GetDateTime, sum(ApplyCount) Tol " +
                    " from vCash_Apply " +
                    " where statas='1' group by convert(varchar(10),GetDateTime,120)) tab3 on tab1.GetDateTime=tab3.GetDateTime " +
                    " left outer join (select convert(varchar(10),GetDateTime,120) GetDateTime, sum(ApplyCount) Tol " +
                    " from vCash_Apply " +
                    " where statas='2' group by convert(varchar(10),GetDateTime,120)) tab4 on tab1.GetDateTime=tab4.GetDateTime" +
                    " order by tab1.GetDateTime desc";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            dt.Columns.Add(new DataColumn("Tol", System.Type.GetType("System.Double")));
            double Tol_DSH = 0;
            double Tol_SHTG = 0;
            double Tol_SHBTG = 0;
            foreach (DataRow _Row in dt.Rows)
            {
                _Row["Tol"] = Convert.ToDouble(_Row["DSH"].ToString()) + Convert.ToDouble(_Row["SHTG"].ToString()) + Convert.ToDouble(_Row["SHBTG"].ToString());
                Tol_DSH += Convert.ToDouble(_Row["DSH"].ToString());
                Tol_SHTG += Convert.ToDouble(_Row["SHTG"].ToString());
                Tol_SHBTG += Convert.ToDouble(_Row["SHBTG"].ToString());

            }

            dt.Rows.Add(new object[] { "合计", Tol_DSH, Tol_SHTG, Tol_SHBTG, Tol_DSH + Tol_SHTG + Tol_SHBTG });
            return dt;
        }

        public DataTable GetYYJEHZ(string _RQ)
        {
            string sql = "select tab1.GetDateTime,isnull(tab2.Tol,0) DSH,isnull(tab3.Tol,0) SHTG,isnull(tab4.Tol,0) SHBTG " +
                " from " +
                    " (select convert(varchar(10),GetDateTime,120) GetDateTime " +
                    " from vCash_Apply where convert(varchar(10),GetDateTime,120)='" + _RQ + "' and PDEL=0 group by convert(varchar(10),GetDateTime,120)) tab1 " +
                    " left outer join (select convert(varchar(10),GetDateTime,120) GetDateTime, sum(ApplyCount) Tol " +
                    " from vCash_Apply " +
                    " where statas='0' and convert(varchar(10),GetDateTime,120)='" + _RQ + "' group by convert(varchar(10),GetDateTime,120)) tab2 on tab1.GetDateTime=tab2.GetDateTime " +
                    " left outer join (select convert(varchar(10),GetDateTime,120) GetDateTime, sum(ApplyCount) Tol " +
                    " from vCash_Apply " +
                    " where statas='1' and convert(varchar(10),GetDateTime,120)='" + _RQ + "' group by convert(varchar(10),GetDateTime,120)) tab3 on tab1.GetDateTime=tab3.GetDateTime " +
                    " left outer join (select convert(varchar(10),GetDateTime,120) GetDateTime, sum(ApplyCount) Tol " +
                    " from vCash_Apply " +
                    " where statas='2' and convert(varchar(10),GetDateTime,120)='" + _RQ + "' group by convert(varchar(10),GetDateTime,120)) tab4 on tab1.GetDateTime=tab4.GetDateTime" +
                    " order by tab1.GetDateTime desc";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            dt.Columns.Add(new DataColumn("Tol", System.Type.GetType("System.Double")));
            double Tol_DSH = 0;
            double Tol_SHTG = 0;
            double Tol_SHBTG = 0;
            foreach (DataRow _Row in dt.Rows)
            {
                _Row["Tol"] = Convert.ToDouble(_Row["DSH"].ToString()) + Convert.ToDouble(_Row["SHTG"].ToString()) + Convert.ToDouble(_Row["SHBTG"].ToString());
                Tol_DSH += Convert.ToDouble(_Row["DSH"].ToString());
                Tol_SHTG += Convert.ToDouble(_Row["SHTG"].ToString());
                Tol_SHBTG += Convert.ToDouble(_Row["SHBTG"].ToString());

            }

            dt.Rows.Add(new object[] { "合计", Tol_DSH, Tol_SHTG, Tol_SHBTG, Tol_DSH + Tol_SHTG + Tol_SHBTG });
            return dt;
        }
    }
}
