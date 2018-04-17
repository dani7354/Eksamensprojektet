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
            int maxStock,double productionTimeInHours, ProductType type, Brand brand, bool isActive)
        {
            ID = productID;
            Name = productName;
            SKU = sku;
            PurchasePrice = purchasePrice;
            StockAmount = stockAmount;
            MinStock = minStock;
            MaxStock = maxStock;
            ProductionTimeInHours = productionTimeInHours;
            Type = type;
            Brand = brand;
            IsActive = isActive;
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
        public bool IsActive { get; set; }

 
    }
}
