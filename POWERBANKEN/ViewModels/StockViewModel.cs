using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Domain;
using System.Windows.Input;

namespace ViewModels
{
    public class StockViewModel : BaseViewModel
    {
        private Controller.MainController _controller;
        private List<Product> _allProducts;
        private List<Product> _selectedProducts;
        private bool _deaktivatedProductsShown = false;
        private string _searchText;
        private static Dictionary<Product, DateTime> _orderDates;
        private bool running = true;

        private double _growthInPercent;
        private int _daysInAdvance;

        private readonly CommandHandler<string> _commandHandler;


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
                return _selectedProducts;
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
        public StockViewModel()
        {
            _controller = Controller.MainController.Instance;
            _allProducts = _controller.GetProducts();
            SelectedProducts = _allProducts.Where(p => p.IsActive == true).ToList<Product>();
            GrowthInPercent = _controller.GetGrowthInPercent();
            DaysInAdvance = 7;
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
            Thread calcThread = new Thread(BackgroundCalc);
            calcThread.Start();
        }

        private void BackgroundCalc()
        {
            while (running)
            {
                OrderDates = _controller.GetOrderDatesForProducts(GrowthInPercent);
                Thread.Sleep(3000);
            }
        }

        public CommandHandler<string> ButtonClickCommand
        {
            get{ return _commandHandler; }
        }
    }
}
