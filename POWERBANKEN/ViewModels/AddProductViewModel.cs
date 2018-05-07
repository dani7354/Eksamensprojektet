using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Windows.Input; 

namespace ViewModels
{
    public class AddProductViewModel : BaseViewModel
    {
		
		public ICommand AddProduct
		{
		get
			{
				return new CommandHandler(() => AddAProduct(SKU, Name, PurchasePrice, StockAmount, MinStock,
				Type.TypeID, Brand.ID, LeadTimeDays, IsActive), true); //ICommand klassen 
			}
		}
        public AddProductViewModel()
        {
            ProductTypes = controller.GetProductTypes();
            Brands = controller.GetBrands();
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
        public bool IsActive { get; private set; } = true; // Kan ikke ændres i UI.

		
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

		public void AddProducts()
		{
			if (Name != string.Empty && SKU != string.Empty && Type != null && Brand != null)
			{
				Product prod = new Product(Name, SKU, PurchasePrice, StockAmount, MinStock, Type, Brand, LeadTimeDays, IsActive);
				controller.AddProduct(prod);
			}
			else
			{
				throw new Exception("Produktet blev ikke gemt - tjek din indstatning");
			}
		}
	}
}
