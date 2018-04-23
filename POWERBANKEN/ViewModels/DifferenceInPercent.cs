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
        public double DifferantialInPercent(int expectedSale, int actualSale)
        {
            var a = ProductDB.ReadProductSale();
            ExpectedSale = expectedSale;
            ActualSale = actualSale;
            double result;
            double r;
            result = ActualSale - ExpectedSale;
            r = result / ExpectedSale;
            result = r * 100;
            return result;
        }

        public double GrowthInPercentPerPeriod(int LastYearssale, double growthForPeriod)
        {
            double ExpectedSaleForThisYearsPeriod = LastYearssale * growthForPeriod;

            double result = ExpectedSaleForThisYearsPeriod * growthForPeriod;

            return result;
        }
    }
}
