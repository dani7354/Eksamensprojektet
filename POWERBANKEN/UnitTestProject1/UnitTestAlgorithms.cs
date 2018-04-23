using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using Domain;
using System.Linq;
using System.Collections.Generic;
using ViewModels;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestAlgorithms
    {

        //[TestMethod]
        //public void TestGrowthInPercent()
        //{
        //    Algorithms a = new Algorithms();

        //    int LastYearsSale = 100;
        //    double GrowthForPeriod = 1.10;
        //    double ExpectedSaleForThisYearsSale = LastYearsSale * GrowthForPeriod;
        //    double result = ExpectedSaleForThisYearsSale * GrowthForPeriod;
           
        //   double resultNow = a.GrowthInPercentPerPeriod(LastYearsSale, GrowthForPeriod);

        //    Assert.AreEqual(result, resultNow);
        //}

        [TestMethod]

        public void TestForeCast()
        {
            ForeCastModel fm = new ForeCastModel();
            var result = fm.ForeCastCalculation(10, new DateTime(2017, 1, 1));
            
            Assert.AreEqual(6, result.Last().QuantitySold);
            Assert.AreEqual(69, result.OrderBy(x => x.QuantitySold).Last().QuantitySold);
        }


    }
}
