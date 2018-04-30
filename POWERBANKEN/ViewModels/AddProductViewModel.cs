using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ViewModels
{
    public class AddProductViewModel
    {
        Controller.MainController controller = Controller.MainController.Instance;



        public void AddAProduct(string sku, string name, double purchasePrice, int amount, int minAmount, int productTypeID, int brandID, int leadTime, bool isActive)
        {

            Product product = new Product(name, sku, purchasePrice, amount, minAmount, new ProductType(productTypeID), new Brand(brandID), leadTime, isActive);
            
            controller.AddProduct(product);
        }
    }
}
