using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Domain;
namespace ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Controller.MainController _controller;
        private List<Product> _allProducts;
        private List<Product> _selectedProducts;
        private bool activatedProductsShown = true;
        private string _searchText;
        private Thread _calculatorThread;
        private static List<Product> _productNotifications;
        private bool _calcThreadRunning;
        public event EventHandler OrderDatesAdded;
        public Object myKey = new Object();

        private double _growthInPercent;
        private int _daysInAdvance;
        private int _calcInterval;
        private string _filterButtonText = "Vis inaktive varer";

        public string FilterButtonText
        {
            get
            {
                return _filterButtonText;
            }
            private set
            {
                _filterButtonText = value;
                NotifyPropertyChanged("ShowButtonText");
            }
        }
        public int CalcInterval
        {
            get
            {
                return _calcInterval;
            }
            set
            {
                if(value != _calcInterval)
                {
                    _calcInterval = value;
                    StartBackgroundCalc();
                    NotifyPropertyChanged("CalcInterval");
                }
                
            }
        }
        public bool CalcThreadRunning
        {
            get
            {
                return _calcThreadRunning;
            }
            set
            {
                if (value)
                {         
                    StartBackgroundCalc();
                }
                _calcThreadRunning = value;
                NotifyPropertyChanged("CalcThreadRunning");
            }
        }
        public List<Product> ProductNotifications
        {
            get
            {
                return _productNotifications;
            }
            set
            {
                int oldOrderDateAmount = 0;
                if (_productNotifications != null)
                {
                    oldOrderDateAmount = _productNotifications.Count;
                }
                if (value.Count > 0)
                {
                    _productNotifications = value.Where(p => p.OrderDates?.OrderDate > new DateTime(1, 1, 1) && p.OrderDates?.OrderDate < DateTime.Now.AddDays(DaysInAdvance)).ToList();
                    _productNotifications.OrderBy(o => o.OrderDates?.OrderDate).ToList();
                    NotifyPropertyChanged("ProductNotifications");

                    if (_productNotifications.Count > oldOrderDateAmount && OrderDatesAdded != null)
                    {
                        OrderDatesAdded?.Invoke((_productNotifications.Count - oldOrderDateAmount), null);
                    }
                }
            }
        }
        public List<Product> SelectedProducts
        {
            get
            {
                return _selectedProducts.Where(p => p.SKU != "" || p.SKU != null).ToList();
            }
            set
            {
                _selectedProducts = value;
                NotifyPropertyChanged("SelectedProducts");
            }
        }
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (!value.Equals(_searchText))
                {
                    _searchText = value;
                    NotifyPropertyChanged("SearchText");
                }
            }
        }
        public double GrowthInPercent
        {
            get
            {
                return _growthInPercent;
            }
            set
            {
                _growthInPercent = value;
                NotifyPropertyChanged("GrowthInPercent");
                _controller.WriteGrowthToFile(_growthInPercent);
            }
        }
        public int DaysInAdvance
        {
            get
            {
                return _daysInAdvance;
            }
            set
            {
                if (value < 0)
                {
                    _daysInAdvance = 0;
                }
                else
                {
                    _daysInAdvance = value;
                }
                NotifyPropertyChanged("DaysInAdvance");
            }
        }
        public MainViewModel()
        {
            _controller = Controller.MainController.Instance;
            _allProducts = _controller.GetOrderDatesForProducts(GrowthInPercent);
            SelectedProducts = _allProducts.Where(p => p.IsActive == activatedProductsShown).ToList<Product>();
            GrowthInPercent = _controller.GetGrowthInPercent();
            DaysInAdvance = 7;
            CalcInterval = 3;
            CalcThreadRunning = true;
            StartBackgroundCalc();
        }
        public void Search()
        {
            SelectedProducts = _allProducts.Where(p => p.ToString().ToLower().Contains(_searchText.ToLower()) && p.IsActive == activatedProductsShown).ToList();
        }
        public void UpdateProducts()
        {
            _controller.UpdateProducts();
        }
        public void ShowDeactivatedProducts()
        {
            if (!activatedProductsShown)
            {
                SelectedProducts = _allProducts.Where(p => p.IsActive == true).ToList<Product>();
                activatedProductsShown = true;
                FilterButtonText = "Vis inaktive varer";
            }
            else
            {
                SelectedProducts = _allProducts.Where(p => p.IsActive == false).ToList<Product>();
                activatedProductsShown = false;
                FilterButtonText = "Vis aktive varer";
            }
        }
        public void GetProducts()
        {
            SelectedProducts = _allProducts.Where(p => p.IsActive == activatedProductsShown).ToList<Product>();
        }
        private void StartBackgroundCalc()
        {
            _calculatorThread = new Thread(BackgroundCalc);
            _calculatorThread.Start();
        }

        private void BackgroundCalc()
        {
            while (_calcThreadRunning)
            {
              
                ProductNotifications = _controller.GetOrderDatesForProducts(GrowthInPercent);
                Thread.Sleep(CalcInterval * 1000);
            }
        }
    }
}
