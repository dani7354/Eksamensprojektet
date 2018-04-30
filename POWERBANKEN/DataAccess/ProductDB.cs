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
    public  class ProductDB : IDataStorage
    {
        public List<Product> GetAllProducts()
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
                    string productName = (string)reader["PRODUCTNAME"];
                    string sku = reader["SKU"].ToString();
                    double purchasePrice = (double)reader["PURCHASEPRICE"];
                    int amount = (int)reader["AMOUNT"];
                    int minStock = (int)reader["MINSTOCK"];
                    ProductType productType = new ProductType((string)reader["PRODUCTTYPE"]);
                    Brand brand = new Brand((string)reader["BRANDNAME"]);
                    int leadtimeInDays = (int)reader["LEADTIMEDAYS"];
                    bool isActive = (bool)reader["ISACTIVE"];

                    Product product = new Product(productName, sku, purchasePrice, amount, minStock, productType, brand,leadtimeInDays, isActive);
                    ProductList.Add(product);

                }
                return ProductList;
            }
        }
        public void UpdateProducts(List<Product> products)
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
                    cmd1.Parameters.Add(new SqlParameter("@name", p.Name));
                    cmd1.Parameters.Add(new SqlParameter("@sku", p.SKU));
                    cmd1.Parameters.Add(new SqlParameter("@purchaseprice", p.PurchasePrice));
                    cmd1.Parameters.Add(new SqlParameter("@amount", p.StockAmount));
                    cmd1.Parameters.Add(new SqlParameter("@minstock", p.MinStock));
                    cmd1.Parameters.Add(new SqlParameter("@leadtimeInDays", p.LeadTimeDays));
                    cmd1.Parameters.Add(new SqlParameter("@isactive", p.IsActive));
                    cmd1.ExecuteNonQuery();
                }
            }
        }
        public void InsertProductSale(List<SalesStatistics> pProductSales)
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
                    cmd1.Parameters.Add(new SqlParameter("@date", p.PeriodEnd));

                    cmd1.ExecuteNonQuery();
                }
            }
        }
        public List<SalesStatistics> GetProductSales()
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
                        QuantitySold = (int)reader["quantity"],
                        PeriodEnd = (DateTime)reader["periodend"]
                    };
                    stat.PeriodStart = new DateTime(stat.PeriodEnd.Year, stat.PeriodEnd.Month, 1);
                    if(allProducts.Exists(p => p.SKU == (string)reader["sku"]))
                    {
                        stat.Product = allProducts.Where((p => p.SKU == (string)reader["sku"])).Single();
                    }
                    else
                    {
                        stat.Product = new Product()
                        {
                            SKU = (string)reader["sku"],
                            Name = "Ukendt"
                        };
                    }
                    salesStatisticsList.Add(stat);
                }
            }
            return salesStatisticsList;
        }

        public void InsertProduct(Product product)
        {
            using (SqlConnection con = DBConnection.Connect)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("POWERBANKEN.INSERT_PRODUCT", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd1.Parameters.Add(new SqlParameter("@sku", product.SKU));
                cmd1.Parameters.Add(new SqlParameter("@name", product.Name));
                cmd1.Parameters.Add(new SqlParameter("@purchaseprice", product.PurchasePrice));
                cmd1.Parameters.Add(new SqlParameter("@amount", product.StockAmount));
                cmd1.Parameters.Add(new SqlParameter("@minstock", product.MinStock));
                cmd1.Parameters.Add(new SqlParameter("@producttypeid", product.Type.TypeID));
                cmd1.Parameters.Add(new SqlParameter("@brandid", product.Brand.BrandID));
                cmd1.Parameters.Add(new SqlParameter("@leadtime", product.LeadTimeDays));
                cmd1.Parameters.Add(new SqlParameter("@isactive", product.IsActive));
                cmd1.ExecuteNonQuery();
                con.Close();
            }
        }
        public void GetProductTypes()
        {
            List<ProductType> productTypes = new List<ProductType>();
            using (SqlConnection con = DBConnection.Connect)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("POWERBANKEN.GET_PRODUCT_TYPES", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    ProductType productType = new ProductType()
                    {
                        TypeID = (int) reader["TYPEID"],
                        TypeName = (string)reader["PRODUCTTYPE"]
                    };
                    productTypes.Add(productType);

                }
            }

        }
        public void GetBrands()
        {
            List<Brand> brands = new List<Brand>();
            using (SqlConnection con = DBConnection.Connect)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("POWERBANKEN.GET_BRANDS", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    Brand brand = new Brand()
                    {
                        BrandID = (int)reader["BRANDID"],
                        Name = (string)reader["BRANDNAME"]
                    };
                    brands.Add(brand);

                }
            }

        }

    }
}
