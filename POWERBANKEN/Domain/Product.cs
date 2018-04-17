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
            this.ID = productID;
            this.Name = productName;
            this.SKU = sku;
            this.PurchasePrice = purchasePrice;
            this.StockAmount = stockAmount;
            this.MinStock = minStock;
            this.MaxStock = maxStock;
            this.ProductionTimeInHours = productionTimeInHours;
            this.Type = type;
            this.Brand = brand;

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public double PurchasePrice { get; set; }
        public int StockAmount { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public double ProductionTimeInHours { get; set; }

        public ProductType Type { get; set; }
        public Brand Brand { get; set; }

 
    }
}
