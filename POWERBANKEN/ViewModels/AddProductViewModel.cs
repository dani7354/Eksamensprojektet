using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace ViewModels
{
    public class AddProductViewModel : BaseViewModel
    {
		
		public ICommand AddProduct
		{
		get
			{
				return new CommandHandler(() => AddProducts(), true); //ICommand klassen 
			}
		}
        public AddProductViewModel()
        {
            ProductTypes = controller.GetProductTypes();
            Brands = controller.GetBrands();
            _brand = Brands[0];
            _type = ProductTypes[0];
            Currencies = controller.GetCurrencies();
            SelectedCurrency = Currencies?.First();
            PurchasePrice = 0;
            PropertyChanged += UpdatePrice;
        }

        private void UpdatePrice(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedCurrency" || e.PropertyName == "PurchasePrice")  PurchasePriceDKK = _purchasePrice * SelectedCurrency.ExchangeRateDKK; 
        }

        Controller.MainController controller = Controller.MainController.Instance;
        private List<ProductType> _productTypes;
        private List<Brand> _brands;
        private string _sku;
        private string _name;
        private double _purchasePrice;


        private int _stockAmount;
        private int _minStock;
        private int _leadTimeDays;
        private ProductType _type;
        private Brand _brand;
        private Currency _selectedCurrency;
        public event EventHandler ProductAdded;

        public double PurchasePriceDKK { get; private set; }

        public List<ProductType> ProductTypes
        {
            get
            {
                return _productTypes;
            }
            private set
            {
                _productTypes = value.OrderBy(t => t.Name).ToList();
                NotifyPropertyChanged("ProductTypes");
            }
        } 
        public List<Brand> Brands
        {
            get
            {
                return _brands;
            }
            private set
            {
                _brands = value.OrderBy(b => b.Name).ToList();
                NotifyPropertyChanged("Brands");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public string SKU
        {
            get
            {
                return _sku;
            }
            set
            {
                _sku = value;
                NotifyPropertyChanged("SKU");
            }
        }
        public double PurchasePrice
        {
            get
            {
                return _purchasePrice;
            }
            set
            {
                if(value < 0)
                {
                    _purchasePrice = 0;
                }
                else
                {
                    _purchasePrice = value;
                }
                NotifyPropertyChanged("PurchasePrice");
            }
        }
        public List<Currency> Currencies { get; private set; }

        public Currency SelectedCurrency
        {
            get
            {
                return _selectedCurrency;
            }
            set
            {
                _selectedCurrency = value;
                NotifyPropertyChanged("SelectedCurrency");
            }
        }
        public int StockAmount
        {
            get
            {
                return _stockAmount;
            }
            set
            {
                if (value < 0)
                {
                    _stockAmount = 0;
                }
                else
                {
                    _stockAmount = value;
                }
                NotifyPropertyChanged("StockAmount");
            }
            
        }
        public int MinStock
        {
            get
            {
                return _minStock;
            }
            set
            {
                if (value < 0)
                {
                    _minStock = 0;
                }
                else
                {
                    _minStock = value;
                }
                NotifyPropertyChanged("MinStock");
            }
        }
        public int LeadTimeDays
        {
            get
            {
                return _leadTimeDays;
            }
            set
            {
                if(value < 0)
                {
                    _leadTimeDays = 0;
                }
                else
                {
                    _leadTimeDays = value;
                }
                NotifyPropertyChanged("LeadTimeDays");
            }
        }
        public ProductType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                NotifyPropertyChanged("Type");
            }
        }
        public Brand Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
                NotifyPropertyChanged("Brand");
            }
        }
        public bool IsActive { get; private set; } = true; 

		
        public void AddAProduct(string sku, string name, double purchasePrice, int amount, int minAmount, int productTypeID, int brandID, int leadTime, bool isActive)
        {
			try
			{
				Product product = new Product(name, sku, purchasePrice, amount, minAmount, new ProductType(productTypeID), new Brand(brandID), leadTime, isActive);

				controller.AddProduct(product);
			}
			catch (Exception)
			{

			}
        }

        public void ClearAddProductTable()
        {
            Type = ProductTypes[0];
            SKU = "";
            Name = "";
            PurchasePrice = 0;
            StockAmount = 0;
            Brand = Brands[0];
            LeadTimeDays = 0;
            SelectedCurrency = Currencies[0];

        }

		public void AddProducts()
		{

            try
            {
                
                if (Name != string.Empty && SKU != string.Empty && Type != null && Brand != null)
                {
                    Product prod = new Product(Name, SKU, PurchasePriceDKK, StockAmount, MinStock, Type, Brand, LeadTimeDays, IsActive);
                    controller.AddProduct(prod);
                    ProductAdded.Invoke(Name, null);
                    ClearAddProductTable();

                }
                else
                {
                    throw new Exception("Produktet blev ikke gemt - tjek din indstatning");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
			
		}
	}
}
