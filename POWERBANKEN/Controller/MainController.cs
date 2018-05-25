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
        private IDataStorage _dataStorage;
        private TxtAccess _txtAccess;
        private List<Product> _products;
        private List<SalesStatistics> _productSales;
        private List<Brand> _brands;
        private List<ProductType> _productTypes;
        private List<Currency> _currencies;
        private MainController()
		{
			_dataStorage = new ProductDB(); _productSales = _dataStorage.GetProductSales();
			_products = _dataStorage.GetAllProducts(); _txtAccess = new TxtAccess();
            _currencies = new CurrencyHttpAccess().GetCurrencies();
		}
        public static MainController Instance { get; } = new MainController();

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
			CSVReader csv = new CSVReader();
			return csv.ReadProductsSalesInfoFromCSV(filePath);		
		}

		public void UpdateProducts()
        {
            _dataStorage.UpdateProducts(_products);
        }

		public double GetGrowthInPercent()
		{
			if (double.TryParse(_txtAccess.ReadFile(), out double percent))
			{
				return percent;
			}
			else
			{
				throw new Exception("Den læste streng kunne ikke konverteres til den påkrævede type.");
			}
		}

		public List<Product> GetOrderDatesForProducts(double growthInPercent)
        {
            List<SalesStatistics> futureMonthlySales = Order.CalculateProductSalesForMonth(growthInPercent, _products, _productSales);

            foreach (Product product in _products.Where(p => p.IsActive == true))
            {
                if (futureMonthlySales.Exists(s => s.Product.Equals(product)))
                {
                    List<SalesStatistics> salesForProduct = futureMonthlySales.Where(s => s.Product.Equals(product)).ToList();
                    product.OrderDates = new Order();
                    product.OrderDates.CalculateOrderDateForProduct(product, salesForProduct);
                }
            }
            return _products;
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

		public void WriteGrowthToFile(double percent)
		{
			_txtAccess.WriteToFile(percent.ToString());
		}

        public List<Currency> GetCurrencies() => _currencies;
       
	}
}
