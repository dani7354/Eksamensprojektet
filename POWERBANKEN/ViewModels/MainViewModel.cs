using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Domain;
using System.Windows.Input;

namespace ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Controller.MainController _controller;
        private List<Product> _allProducts;
        private List<Product> _selectedProducts;
        private bool _deaktivatedProductsShown = false;
        private string _searchText;
        private Thread _calculatorThread;
        private static Dictionary<Product, DateTime> _orderDates;
        private bool _calcThreadRunning;

        private double _growthInPercent;
        private int _daysInAdvance;
        private int _calcInterval;

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
        public Dictionary<Product, DateTime> OrderDates
        {
            get
            {
                return _orderDates;
            }
            set
            {
                if (value.Count > 0)
                {
                    _orderDates = value.Where(o => o.Value < DateTime.Now.AddDays(DaysInAdvance)).ToDictionary(d => d.Key, d => d.Value);
                    _orderDates.OrderBy(o => o.Value).ToDictionary(d => d.Key, d => d.Value);
                    NotifyPropertyChanged("OrderDates");
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
            _allProducts = _controller.GetProducts();
            SelectedProducts = _allProducts.Where(p => p.IsActive == true).ToList<Product>();
            GrowthInPercent = _controller.GetGrowthInPercent();
            DaysInAdvance = 7;
            CalcInterval = 3;
            CalcThreadRunning = true;
            StartBackgroundCalc();
        }
        public void Search()
        {
            SelectedProducts = _allProducts.Where(p => p.ToString().ToLower().Contains(_searchText.ToLower())).ToList();
        }
        public void UpdateProducts()
        {
            _controller.UpdateProducts();
        }
        public void ShowDeactivatedProducts()
        {
            if (!_deaktivatedProductsShown)
            {
                SelectedProducts = _allProducts.Where(p => p.IsActive == false).ToList<Product>();
                _deaktivatedProductsShown = true;
            }
            else
            {
                SelectedProducts = _allProducts.Where(p => p.IsActive == true).ToList<Product>();
                _deaktivatedProductsShown = false;
            }
        }
        public void GetProducts()
        {
            SelectedProducts = _allProducts.Where(p => p.IsActive == true).ToList<Product>();
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
                OrderDates = _controller.GetOrderDatesForProducts(GrowthInPercent);
                Thread.Sleep(CalcInterval * 1000);
            }
        }
    }
}
