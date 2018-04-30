using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using DataAccess;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class TestDB : IDataStorage
    {
        private List<Product> _products = new List<Product>();
        private List<SalesStatistics> _productSales = new List<SalesStatistics>();
        private static readonly TestDB _instance = new TestDB();
        public static TestDB Instance
        {
            get
            {
                return _instance;
            }
        }
        private TestDB(){}

        public List<Product> GetAllProducts() => _products;



        public void UpdateProducts(List<Product> products)
        {
            _products.Clear();
            _products.AddRange(products);
        }

        public void InsertProductSale(List<SalesStatistics> pProductSales) => _productSales.AddRange(pProductSales);

        public List<SalesStatistics> GetProductSales() => _productSales;

        public void InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
