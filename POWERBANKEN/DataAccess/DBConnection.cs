using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DBConnection
    {
        private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_C12; User Id=USER_C12; Password=SesamLukOp_12;";
        public static SqlConnection Connect() => new SqlConnection(connectionString);
    }
}
