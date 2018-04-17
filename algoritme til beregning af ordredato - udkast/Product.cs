using System;
namespace Udkast_til_algoritme
{
    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public double StockPrice { get; set; }

        public int CurrentQuantity { get; set; }
        public int MinQuantity { get; set; }

        public SalesPeriodInfo PreviousSalesPeriodInfo { get; set; }

        //type osv er udeladt, eftersom de ikke er relevante for mit eksempel.
    }
}
