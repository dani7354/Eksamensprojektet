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
        public static SqlConnection Connect => new SqlConnection(connectionString);

       // public void TestMe()
       // {
       // CSVReader reader = new CSVReader();
       // DateTime d = new DateTime(2015, 1, 1);
       ////     List<> myList = new List<T>();
       // var query = reader.ReadProductsSalesInfoFromCSV(@"C:\Users\Simon\source\repos\Eksamensprojektet\Dokumenter\Testdata\Product Sales - 2018-04-19_Jan 2017.csv", d, d);
       //     foreach (var item in query)
       //     {
       //         myList = item;
       //     }
       // }
    }
}
