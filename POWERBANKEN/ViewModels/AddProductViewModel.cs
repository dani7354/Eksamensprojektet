using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ViewModels
{
    public class AddProductViewModel : BaseViewModel
    {

        public AddProductViewModel()
        {
            ProductTypes = controller.GetProductTypes();
            Brands = controller.GetBrands();
        }
        Controller.MainController controller = Controller.MainController.Instance;

        public List<ProductType> ProductTypes { get; private set; } 
        public List<Brand> Brands { get; private set; }

        public string Name { get; set; }
        public string SKU { get; set; }
        public double PurchasePrice { get; set; }
        public int StockAmount { get; set; }
        public int MinStock { get; set; }
        public int LeadTimeDays { get; set; }
        public ProductType Type { get; set; }
        public Brand Brand { get; set; }
        public bool IsActive { get; set; } = true;


        public void AddAProduct(string sku, string name, double purchasePrice, int amount, int minAmount, int productTypeID, int brandID, int leadTime, bool isActive)
        {
         
            Product product = new Product(name, sku, purchasePrice, amount, minAmount, new ProductType(productTypeID), new Brand(brandID), leadTime, isActive);
            
            controller.AddProduct(product);
        }

        public void AddProduct()
        {
            if(Name != string.Empty && SKU != string.Empty && Type != null && Brand != null)
            {
                Product prod = new Product(Name, SKU, PurchasePrice, StockAmount, MinStock, Type, Brand, LeadTimeDays, IsActive);
                controller.AddProduct(prod);
            }
            else
            {
                throw new Exception("Produkted blev ikke gemt - tjek din indstatning");
            }
        }
    }
}
