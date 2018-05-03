using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Domain;

namespace Controller
{
    public class MainController
    {
        private static readonly MainController _instance = new MainController();
        private IDataStorage _dataStorage;
        private TxtAccess _txtAccess;
        private List<Product> _products;
        private List<SalesStatistics> _productSales;
        private List<Brand> _brands;
        private List<ProductType> _productTypes;
        private MainController()
		{
			_dataStorage = new ProductDB(); _productSales = _dataStorage.GetProductSales();
			_products = _dataStorage.GetAllProducts(); _txtAccess = new TxtAccess();
		}
        public static MainController Instance
        {
            get
            {
                return _instance;
            }
        }

		public void AddProduct(Product product)
        {
            _dataStorage.InsertProduct(product);
            _products.Add(product);
            _products = _dataStorage.GetAllProducts();
        }

        public List<Product> GetProducts()
        {
            if(_products == null)
            {
                _products = _dataStorage.GetAllProducts();
            }
            return _products;
        }
        public List<SalesStatistics> GetProductSales()
        {
            if(_productSales == null)
            {
                _productSales = _dataStorage.GetProductSales();
            }
            return _productSales;
        }

		public List<SalesStatistics> ReadProductsSalesInfoFromCSV(string filePath)
		{
			throw new NotImplementedException(); //TO DO!!
		}

		public void UpdateProducts()
        {
            _dataStorage.UpdateProducts(_products);
        }
        public Dictionary<Product, DateTime> GetOrderDatesForProducts(double growthInPercent)
        {
            OrderDateCalculator orderCalc = new OrderDateCalculator();
            Dictionary<Product, DateTime> orderDates =  orderCalc.GetOrderDatesForAllProducts(_products, _productSales, growthInPercent);
            if(orderDates.Count > 0)
            {
                return orderDates;
            }
            else
            {
                throw new Exception("Ingen ordredatoer kunne beregnes");
            }
        }

        public void InsertProductSale(List<SalesStatistics> sales)
        {
            _dataStorage.InsertProductSale(sales);
            _productSales = _dataStorage.GetProductSales();
        }

        public List<Brand> GetBrands()
        {
            if(_brands == null)
            {
                _brands = _dataStorage.GetBrands();
            }
            return _brands;
        }
        public List<ProductType> GetProductTypes()
        {
            if(_productTypes == null)
            {
                _productTypes = _dataStorage.GetProductTypes();
            }
            return _productTypes;
        }

        public double GetGrowthInPercent()
        {
            if(double.TryParse(_txtAccess.ReadFile(), out double percent))
            {
                return percent;
            }
            else
            {
                throw new Exception("Den læste streng kunne ikke konverteres til den påkrævede type.");
            }
        }

        public void WriteGrowthToFile(double percent)
        {
            _txtAccess.WriteToFile(percent.ToString());
        }
    }
}
