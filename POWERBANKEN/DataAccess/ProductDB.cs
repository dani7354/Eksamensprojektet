using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Domain;

namespace DataAccess
{
    public static class ProductDB
    {
        public static List<Product> GetAllProducts(string searchText)
        {
            List<Product> ProductList = new List<Product>();
            using (SqlConnection con = DBConnection.Connect())
            {

                con.Open();
                SqlCommand cmd1 = new SqlCommand("See_Stock", con);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@PRODUCTNAME", searchText));

                SqlDataReader reader = cmd1.ExecuteReader();


                while (reader.Read())
                {
                }
            }
            return null;
        }
    }
}
