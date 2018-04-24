using System;
using DataAccess;
using ViewModels;
using Domain;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        StockViewModel _stockViewModel;
        [TestInitialize]
        public void Init()
        {
            _stockViewModel = new StockViewModel();
        }
        [TestMethod]
        public void ReadFromCSVWorksSeptember()
        {
            // test
            CSVReader reader = new CSVReader();
            int totalProducts = 76;
            string filePath = @"Product Sales - 2018-04-19-Sep. 2017.csv";
            List<SalesStatistics> saleStatistics = reader.ReadProductsSalesInfoFromCSV(filePath);

            Assert.AreEqual(totalProducts, saleStatistics.Count); // Er alle produkter indlæst fra filen.
            Assert.AreEqual(saleStatistics.First().Start, new DateTime(2017, 9, 1));
            Assert.AreEqual(saleStatistics.First().End, new DateTime(2017, 9, 30));
        }
        [TestMethod]
        public void ReadFromCSVWorksMay() //opdateres, når læser-metoden er færdiglavet. 
        {
            // test
            CSVReader reader = new CSVReader();
            int totalProducts = 66;
            string filePath = @"Product Sales - 2018-04-19-Maj 2017.csv";
            List<SalesStatistics> saleStatistics = reader.ReadProductsSalesInfoFromCSV(filePath);

            Assert.AreEqual(totalProducts, saleStatistics.Count); // Er alle produkter indlæst fra filen.
            Assert.AreEqual(saleStatistics.First().Start, new DateTime(2017, 5, 1));
            Assert.AreEqual(saleStatistics.First().End, new DateTime(2017, 5, 31));
        }

        [TestMethod]
        public void GetActiveProductsFromDB()
        {
            int totalActiveProducts = 33;
            List<Product> product = ProductDB.GetAllProducts().Where(p => p.IsActive == true).ToList<Product>();
            Assert.AreEqual(totalActiveProducts, product.Count);
        }
        [TestMethod]
        public void GetInactiveProductsFromDB()
        {
            int totalInActiveProducts = 1;
            List<Product> product = ProductDB.GetAllProducts().Where(p => p.IsActive == false).ToList<Product>();
            Assert.AreEqual(totalInActiveProducts, product.Count);
        }
        [TestMethod]
        public void SwitchBetweenDeactivatedAndActivatedProducts()
        {
            // Aktive varer skal vises by default
            Assert.AreEqual(true, _stockViewModel.SelectedProducts.Last().IsActive);
            Assert.AreEqual(true, _stockViewModel.SelectedProducts.First().IsActive);

            // Vi beder om at få vist de inaktive varer
            _stockViewModel.ShowDeactivatedProducts();

            // Skulle nu være false.
            Assert.AreEqual(false, _stockViewModel.SelectedProducts.Last().IsActive);
            Assert.AreEqual(false, _stockViewModel.SelectedProducts.First().IsActive);
        }
        [TestMethod]
        public void CalculateFutureProductSalesForMonth()
        {
            ForeCastModel vm = new ForeCastModel();

            vm.SelectedMonth = vm.Months.First(); // choosing month
            vm.GrowthInPercent = 23.45; // typing for future month 

            vm.CalculateForeCast();

            int expquantitySold = 69; // aflæst i excel
            int expfutureQuantitySold = (int)Math.Ceiling(expquantitySold * ((vm.GrowthInPercent / 100) + 1));
            Assert.AreEqual(expquantitySold, vm.ForeCast.First().QuantitySold);
            Assert.AreEqual(expfutureQuantitySold,  vm.ForeCast.First().ForeCastExpected);




        }

        


    }
}
