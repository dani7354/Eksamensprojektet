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
        private List<Brand> _brands;
        private List<ProductType> _productTypes;
		public static TestDB Instance { get; } = new TestDB();

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
            if(!_products.Contains(product)) _products.Add(product);
        }

        public List<Brand> GetBrands()
        {
            return _brands;
        }

        public List<ProductType> GetProductTypes()
        {
            return _productTypes;
        }
    }
}
