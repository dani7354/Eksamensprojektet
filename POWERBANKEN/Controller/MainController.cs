﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Domain;

namespace Controller
{
    public class MainController
    {
        private static readonly MainController _instance = new MainController();
        private IDataStorage _dataStorage;
        private List<Product> _products;
        private List<SalesStatistics> _productSales;
        private MainController() { _dataStorage = new ProductDB(); _productSales = _dataStorage.GetProductSales(); _products = _dataStorage.GetAllProducts(); }
        public static MainController Instance
        {
            get
            {
                return _instance;
            }
        }

        public void AddProduct(Product product)
        {
            _dataStorage.InsertProduct(product);
        }

        public List<Product> GetProducts()
        {
            if(_products == null)
            {
                _products = _dataStorage.GetAllProducts();
            }
            return _products;
        }
        public List<SalesStatistics> GetProductSales()
        {
            if(_productSales == null)
            {
                _productSales = _dataStorage.GetProductSales();
            }
            return _productSales;
        }

        public List<SalesStatistics> ReadProductsSalesInfoFromCSV(string filePath)
        {
            throw new NotImplementedException();
        }

        public void UpdateProducts()
        {
            _dataStorage.UpdateProducts(_products);
        }
        public Dictionary<Product, DateTime> GetOrderDatesForProducts(double growthInPercent)
        {
            OrderDateCalculator orderCalc = new OrderDateCalculator();
            Dictionary<Product, DateTime> orderDates =  orderCalc.GetOrderDatesForAllProducts(_products, _productSales, growthInPercent);
            if(orderDates.Count > 0)
            {
                return orderDates;
            }
            else
            {
                throw new Exception("Ingen ordredatoer kunne beregnes");
            }
        }

        public void InsertProductSale(List<SalesStatistics> sales)
        {
            _dataStorage.InsertProductSale(sales);
            _productSales = _dataStorage.GetProductSales();
        }
    }
}
