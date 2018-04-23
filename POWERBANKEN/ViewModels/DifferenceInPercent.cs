using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;

namespace ViewModels
{
    public class DifferenceInPercent
    {
        
        private int _expectedSale;
        private int _actualSale;
        public int ExpectedSale
        {
            get { return _expectedSale; }
            set { _expectedSale = value; }
        }
        public int ActualSale
        {
            get { return _actualSale; }
            set { _actualSale = value; }
        }

        public List<SalesStatistics> ForeCastCalculation(double GrowthInPercent, DateTime month)
        {
            GrowthInPercent = (GrowthInPercent / 100) + 1;
            List<SalesStatistics> ForecastList = new List<SalesStatistics>();
            List<SalesStatistics> monthOftheYear = ProductDB.ReadProductSale().Where(x => x.Start.Month == month.Month).ToList();
            foreach (var stat in monthOftheYear)
            {
                int result = (int)Math.Ceiling(stat.QuantitySold * GrowthInPercent);
                ForecastList.Add(new SalesStatistics()
                {
                    QuantitySold = result,
                    Start = stat.Start.AddYears(1),
                    End = stat.End.AddYears(1),
                    Product = stat.Product
                });
            }
            return ForecastList;
        }

        //public double DifferantialInPercent(int expectedSale, int actualSale)
        //{
        //    var a = ProductDB.ReadProductSale();
        //    ExpectedSale = expectedSale;
        //    ActualSale = actualSale;
        //    double result;
        //    double r;
        //    result = ActualSale - ExpectedSale;
        //    r = result / ExpectedSale;
        //    result = r * 100;
        //    return result;
        //}

        //public double GrowthInPercentPerPeriod(int LastYearssale, double growthForPeriod)
        //{
        //    double ExpectedSaleForThisYearsPeriod = LastYearssale * growthForPeriod;

        //    double result = ExpectedSaleForThisYearsPeriod * growthForPeriod;

        //    return result;
        //}
    }
}
