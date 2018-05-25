using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Order
    {
        public DateTime OrderDate { get; private set; }
        public DateTime SoldOutDate { get; private set; }
        public void CalculateOrderDateForProduct(Product product, List<SalesStatistics> futureSalesForProduct)
        {
            const int YEAR_LIMIT = 3000;
            DateTime currentDate = DateTime.Today;
            int dailySale = GetDailySaleForMonth(currentDate, futureSalesForProduct);
            Product productCopy = new Product(product.Name, product.SKU, product.PurchasePrice, product.StockAmount, product.MinStock, product.Type, product.Brand,product.LeadTimeDays, product.IsActive);
            while (productCopy.StockAmount > 0) //simulerer salg.
            {
                if (!currentDate.Month.Equals(currentDate.AddDays(-1).Month)) // hvis måneden er skiftet.
                {
                dailySale = GetDailySaleForMonth(currentDate, futureSalesForProduct);
                }
                productCopy.StockAmount -= dailySale; // fratrækker det daglige antal salg fra lagerbeholdningen. 

                if(productCopy.StockAmount == productCopy.MinStock)
                {
                    this.OrderDate = currentDate.AddDays(-product.LeadTimeDays);
                    if (this.OrderDate < DateTime.Now) this.OrderDate = DateTime.Now;
                }
                if(currentDate.Year < YEAR_LIMIT) currentDate = currentDate.AddDays(1); // vi tæller frem med én dag, hvis ikke tidsgrænsen er nået.
                else break;                
            }
               this.SoldOutDate = currentDate;
        }

        private int GetDailySaleForMonth(DateTime currentDate, List<SalesStatistics> futureSalesForProduct)
        {
            int dailySale = 0;
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            if (futureSalesForProduct.Exists(s => s.PeriodEnd.Month.Equals(currentDate.Month)))
            {
                SalesStatistics productSalesForMonth = futureSalesForProduct.Where(s => s.PeriodEnd.Month.Equals(currentDate.Month)).First();
                dailySale = productSalesForMonth.ExpectedSales / daysInMonth;
            }
            
            return dailySale;
        }
        public static List<SalesStatistics> CalculateProductSalesForMonth(double GrowthInPercent, List<Product> products, List<SalesStatistics> productSales)
        {
           
            GrowthInPercent = (GrowthInPercent / 100) + 1;
            List<SalesStatistics> ForecastList = new List<SalesStatistics>();
            foreach (var stat in productSales)
            {
                if(products.Any(p => p.Equals(stat.Product)))
                {
                    int result = (int)Math.Ceiling(stat.QuantitySold * GrowthInPercent);
                    ForecastList.Add(new SalesStatistics()
                    {
                        QuantitySold = stat.QuantitySold,
                        ExpectedSales = result,
                        PeriodStart = stat.PeriodStart.AddYears(1),
                        PeriodEnd = stat.PeriodEnd.AddYears(1),
                        Product = stat.Product
                    });
                }
            }
            return ForecastList;
        }
    }
}
