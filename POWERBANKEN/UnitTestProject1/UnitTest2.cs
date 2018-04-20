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
    public class UnitTest2
    {
        [TestMethod]
        public void TestAlgorithmDifferentialInPercent()
        {
            DifferenceInPercent d = new DifferenceInPercent();
            var result = d.CalculateDifference();
            Assert.AreEqual(0, result);
            //Algorithms algorithms = new Algorithms();
            //CSVReader reader = new CSVReader();
            //DateTime d = new DateTime(2015, 1, 1);
            //List<int> quantSoldOfAll = new List<int>();
            //List<int> actualSoldTrue = new List<int>();
            //var query = reader.ReadProductsSalesInfoFromCSV(@"C:\Users\Simon\source\repos\Eksamensprojektet\Dokumenter\Testdata\Product Sales - 2018-04-19_Jan 2017.csv", d, d).Where(x => x.QuantiySold == 31);
            //foreach (var item in query)
            //{
             
            //}
            //Assert.AreEqual(0, algorithms.DifferantialInPercent(31, 0));
        }
    }
}
