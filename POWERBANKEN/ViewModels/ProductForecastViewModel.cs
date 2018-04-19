using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using DataAccess;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductForecastViewModel
    {
        private CSVReader _csvReader;
        private SalesStatistics _statsForProduct;
        public DateTime periodStart { get; set; }
        public DateTime periodEnd { get; set; }
        public double expGrowth { get; set; }
        public ProductForecastViewModel()
        {
            _csvReader = new CSVReader();
        }


        //private void CalculateOrderDate( double pGrowth, DateTime periodStart, DateTime periodEnd)
        //{
        //    Dictionary<DateTime, Product> orderdatesForProducts = new Dictionary<DateTime, Product>();
   
        //        int previousPeriodDays = (stat.End - stat.Start).Days;
        //        double dailyQuantitySold = stat.QuantiySold / previousPeriodDays;

        //        int futurePeriodDays = (periodEnd - periodStart).Days;
        //        double expectedDailySales = ((dailyQuantitySold / 100) * pGrowth) + dailyQuantitySold;
        //        int expectedDailySalesRounded = (int)Math.Ceiling(expectedDailySales); // Vi er interesseret i at have hele tal, og vi runder op for en sikkerhds skyld!

        //        if (expectedDailySales == 0)
        //        {
        //            throw new Exception("Der sælges for lidt af denne vare til, at man kan beregne dagligt salg!");
        //        }

        //        // Udregnes med udgangspunkt i en lineær sammenhæng 
        //        double daysBeforeOutOfStock = (stat.Product.StockAmount - stat.Product.MinStock) / expectedDailySalesRounded;
        //        DateTime OutOfStockDay = periodStart.AddDays((int)daysBeforeOutOfStock);

        //        DateTime SuggestedOrderDate = OutOfStockDay.AddHours(-stat.Product.ProductionTimeInHours);
        //        orderdatesForProducts.Add(SuggestedOrderDate, stat.Product);
            
          
        //}
    }
}
