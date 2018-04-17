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
        public static List<Product> SearchItemName(string searchText)
        {
            List<Product> ListOfItems = new List<Product>();
            using (SqlConnection con = DBConnection.Connect())
            {

                con.Open();
                SqlCommand cmd1 = new SqlCommand("Search_ItemName", con);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@ItemName", searchText));

                SqlDataReader reader = cmd1.ExecuteReader();


                while (reader.Read())
                { }
            }
            return null;
        }
    }
}
