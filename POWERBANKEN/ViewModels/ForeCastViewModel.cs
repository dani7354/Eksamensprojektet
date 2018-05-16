
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Domain;

namespace ViewModels
{
   
    public class ForeCastViewModel : BaseViewModel
    {
        private Controller.MainController _controller;
        private double _growthInPercent;
        private Dictionary<Product, DateTime>_foreCastGrid;


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
            }
        }

        public Dictionary<Product, DateTime> ForeCast
        {
            get
            {
                return _foreCastGrid;
            }
            set
            {
                _foreCastGrid = value;
                NotifyPropertyChanged("ForeCast");
            }
        }

        public ForeCastViewModel()
        {
            _controller = MainController.Instance;
            GrowthInPercent = _controller.GetGrowthInPercent();
        }

        public void CalculateForeCast()
        {
            ForeCast = _controller.GetOrderDatesForProducts(GrowthInPercent).OrderBy(d => d.Value).ToDictionary(d => d.Key, d => d.Value); //2. lambda er nødvendig pga. dictionary
        }
    }
}
