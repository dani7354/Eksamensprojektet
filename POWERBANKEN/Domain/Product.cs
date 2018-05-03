using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public Product(string productName, string sku, double purchasePrice, int stockAmount, int minStock,
          ProductType type, Brand brand, int leadtimeInDays , bool isActive)
        {
            Name = productName;
            SKU = sku;
            PurchasePrice = purchasePrice;
            StockAmount = stockAmount;
            MinStock = minStock;
            Type = type;
            Brand = brand;
            LeadTimeDays = leadtimeInDays;
            IsActive = isActive;
        }
        public Product(){}
        public string Name { get; set; }
        public string SKU { get; set; }
        public double PurchasePrice { get; set; }
        public int StockAmount { get; set; } 
        public int MinStock { get; set; } 
        public int LeadTimeDays { get; set; }
        public ProductType Type { get; set; }
        public Brand Brand { get; set; }
		public bool IsActive { get; set; }

        public override string ToString()
        {
            return string.Format($"{SKU};{Name}");
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                Product p = (Product)obj;
                return this.SKU.Equals(p.SKU);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return this.SKU.GetHashCode();
        }
    }
}
