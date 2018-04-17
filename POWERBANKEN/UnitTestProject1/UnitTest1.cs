using System;
using DataAccess;
using Domain;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReadFromCSVWorks() //opdateres, når læser-metoden er færdiglavet. 
        {
            int totalProducts = 211;
            CSVReader reader = new CSVReader();
            DateTime start = new DateTime(2018, 1, 1);
            DateTime end = new DateTime(2018, 4, 9);
            List<Statistic> info =  reader.ReadProductsSalesInfoFromCSV("products.csv", start, end);
            Assert.AreEqual(totalProducts, info.Count);

            
        }
    }
}
