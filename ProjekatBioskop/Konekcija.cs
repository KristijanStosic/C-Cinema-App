using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBioskop
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()//static za pozivanje nad klasom bez pravljenja objekata
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder();
            ccnSb.DataSource = @"PC NAME";
            ccnSb.InitialCatalog = "DataBaseName";
            ccnSb.IntegratedSecurity = true;

            string con = ccnSb.ToString();

            SqlConnection konekcija = new SqlConnection(con);

            return konekcija;
        }
    }
}
