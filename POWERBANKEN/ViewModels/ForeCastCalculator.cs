using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;
namespace ViewModels
{
    public class ForeCastCalculator
    {
        
        public Dictionary<DateTime, Product> GetOrderDatesForProducts()
        {
            return null;
        }


        public List<SalesStatistics> CalculateProductSalesForMonth(double GrowthInPercent, DateTime month)
        {
            GrowthInPercent = (GrowthInPercent / 100) + 1;
            List<SalesStatistics> ForecastList = new List<SalesStatistics>();
            List<SalesStatistics> monthOftheYear = ProductDB.ReadProductSale().AsParallel().Where(x => x.Start.Month == month.Month).ToList();
            foreach (var stat in monthOftheYear)
            {
                int result = (int)Math.Ceiling(stat.QuantitySold * GrowthInPercent);
                ForecastList.Add(new SalesStatistics()
                {
                    QuantitySold = stat.QuantitySold,
                    ForeCastExpected = result,
                    Start = stat.Start.AddYears(1),
                    End = stat.End.AddYears(1),
                    Product = stat.Product
                });
            }
            return ForecastList;
        }
    }
}
