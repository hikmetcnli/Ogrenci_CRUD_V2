using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci.CRUD
{
    public class Baglanti
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Server=GDKTP-NB-000;Database=OGRENCI_DB;Trusted_Connection=True;");
        }
    }
}
