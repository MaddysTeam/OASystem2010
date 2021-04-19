using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dianda.BLL
{
    public class YYJEHZ
    {
        DAL.YYJEHZ dYYJEHZ = new Dianda.DAL.YYJEHZ();
        public DataTable GetYYJEHZ()
        {
            return dYYJEHZ.GetYYJEHZ();
        }

        public DataTable GetYYJEHZ(string _RQ)
        {
            return dYYJEHZ.GetYYJEHZ(_RQ);
        }
    }
}
