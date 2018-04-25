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
        public static List<Product> GetAllProducts()
        {
            List<Product> ProductList = new List<Product>();
            using (SqlConnection con = DBConnection.Connect)
            {

                con.Open();
                SqlCommand cmd1 = new SqlCommand("See_Stock", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlDataReader reader = cmd1.ExecuteReader();

                while (reader.Read())
                {
                    int productID = (int)reader[0];
                    string productName = (string)reader[1];
                    string sku = reader[2].ToString();
                    double purchasePrice = (double)reader[3];
                    int amount = (int)reader[4];
                    int minStock = (int)reader[5];
                    int maxStock = (int)reader[6];
                    double productionInHours = (double)reader[7];
                    ProductType productType = new ProductType((string)reader[8]);
                    Brand brand = new Brand((string)reader[9]);
                    bool isActive = (bool)reader[10];

                    Product product = new Product(productID, productName, sku, purchasePrice, amount, minStock, maxStock,
                            productionInHours, productType, brand, isActive);
                    ProductList.Add(product);

                }
                return ProductList;
            }
        }
        public static void UpdateProducts(List<Product> products)
        {
            using (SqlConnection con = DBConnection.Connect)
            {
                con.Open();
                foreach (Product p in products)
                {
                    SqlCommand cmd1 = new SqlCommand("POWERBANKEN.UPDATE_PRODUCT", con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd1.Parameters.Add(new SqlParameter("@id", p.ID));
                    cmd1.Parameters.Add(new SqlParameter("@name", p.Name));
                    cmd1.Parameters.Add(new SqlParameter("@sku", p.SKU));
                    cmd1.Parameters.Add(new SqlParameter("@price", p.PurchasePrice));
                    cmd1.Parameters.Add(new SqlParameter("@stockamount", p.StockAmount));
                    cmd1.Parameters.Add(new SqlParameter("@minstock", p.MinStock));
                    cmd1.Parameters.Add(new SqlParameter("@maxstock", p.MaxStock));
                    cmd1.Parameters.Add(new SqlParameter("@productionhours", p.ProductionTimeInHours));
                    cmd1.Parameters.Add(new SqlParameter("@isactive", p.IsActive));
                    cmd1.ExecuteNonQuery();
                }
            }
        }
        public static void InsertProductSale(List<SalesStatistics> pProductSales)
        {
            using (SqlConnection con = DBConnection.Connect)
            {
                con.Open();
                foreach (SalesStatistics p in pProductSales)
                {
                    SqlCommand cmd1 = new SqlCommand("POWERBANKEN.Insert_ProductSales", con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd1.Parameters.Add(new SqlParameter("@sku", p.Product.SKU));
                    cmd1.Parameters.Add(new SqlParameter("@quantity", p.QuantitySold));
                    cmd1.Parameters.Add(new SqlParameter("@date", p.End));

                    cmd1.ExecuteNonQuery();
                }
            }
        }

      
        public static List<SalesStatistics> ReadProductSale()
        {
            List<SalesStatistics> salesStatisticsList = new List<SalesStatistics>();
            List<Product> allProducts = GetAllProducts();
            using (SqlConnection con = DBConnection.Connect)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("PRODUCT_SALES", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    SalesStatistics stat = new SalesStatistics()
                    {
                        QuantitySold = (int)reader[1],
                        End = (DateTime)reader[2]
                    };
                    stat.Start = new DateTime(stat.End.Year, stat.End.Month, 1);
                    if(allProducts.Exists(p => p.SKU == (string)reader[0]))
                    {
                        stat.Product = allProducts.Where((p => p.SKU == (string)reader[0])).Single();
                    }
                    else
                    {
                        stat.Product = new Product()
                        {
                            SKU = (string)reader[0],
                            Name = "Ukendt"
                        };
                    }
                    salesStatisticsList.Add(stat);
                }
            }
            return salesStatisticsList;
        }


    }
}
