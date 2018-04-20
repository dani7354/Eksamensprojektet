using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using Domain;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestAlgorithmDifferentialInPercent()
        {
            Algorithms algorithms = new Algorithms();
            CSVReader reader = new CSVReader();
            DateTime d = new DateTime(2015, 1, 1);
            var query = reader.ReadProductsSalesInfoFromCSV(@"C:\Users\Simon\source\repos\Eksamensprojektet\Dokumenter\Testdata\Product Sales - 2018-04-19_Jan 2017.csv", d, d).Any(x => );
                //reader.ReadProductsSalesInfoFromCSV(@"C:\Users\Simon\source\repos\Eksamensprojektet\Dokumenter\Testdata\Product Sales - 2018-04-19_Jan 2017", 
                //d, d).Where(x => x.QuantiySold);
            int saleForJan = 100;
            int expForJan = 1000;

            Assert.AreEqual(-90, query);
        }
    }
}
