using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public Product(int productID, string productName, string sku, double purchasePrice, int stockAmount, int minStock,
            int maxStock,double productionTimeInHours, ProductType type, Brand brand)
        {
            productID = ID;
            productName = Name;
            sku = SKU;
            purchasePrice = PurchasePrice;
            stockAmount = StockAmount;
            minStock = MinStock;
            maxStock = MaxStock;
            productionTimeInHours = ProductionTimeInHours;
            type = Type;
            brand = Brand;

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public double PurchasePrice { get; set; }
        public int StockAmount { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public int ProductionTimeInHours { get; set; }

        public ProductType Type { get; set; }
        public Brand Brand { get; set; }

 
    }
}
