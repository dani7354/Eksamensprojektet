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
        [TestMethod]
        public void TestAlgorithmDifferentialInPercent()
        {
            DifferenceInPercent d = new DifferenceInPercent();
            var result = d.CalculateDifference();
            Assert.AreEqual(0, result);

        }

        [TestMethod]
        public void TestGrowthInPercent()
        {
            Algorithms a = new Algorithms();

            int LastYearsSale = 100;
            double GrowthForPeriod = 1.10;
            double ExpectedSaleForThisYearsSale = LastYearsSale * GrowthForPeriod;
            double result = ExpectedSaleForThisYearsSale * GrowthForPeriod;
           
           double resultNow = a.GrowthInPercentPerPeriod(LastYearsSale, GrowthForPeriod);

            Assert.AreEqual(result, resultNow);
        }
    }
}
