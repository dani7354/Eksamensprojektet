
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;
namespace ViewModels
{
   
    public class ForeCastModel : BaseViewModel
    {
        private double _growthInPercent;
        private List<DateTime> _months;
        private Dictionary<DateTime, Product>_foreCastGrid;
        private List<Product> products;

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

        public List<DateTime> Months
        {
            get
            {
                return _months;
            }
            set
            {
                _months = value;
                NotifyPropertyChanged("Months");
            }

        }

        public DateTime SelectedMonth
        {
            get; set;
        }

        public Dictionary<DateTime,Product> ForeCast
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

        public ForeCastModel()
        {
            Months = new List<DateTime>()
            { new DateTime(DateTime.Now.Year, 1, 1),
            new DateTime(DateTime.Now.Year, 2, 1),
            new DateTime(DateTime.Now.Year, 3, 1),
            new DateTime(DateTime.Now.Year, 4, 1),
            new DateTime(DateTime.Now.Year, 5, 1),
            new DateTime(DateTime.Now.Year, 6, 1),
            new DateTime(DateTime.Now.Year, 7, 1),
            new DateTime(DateTime.Now.Year, 8, 1),
            new DateTime(DateTime.Now.Year, 9, 1),
            new DateTime(DateTime.Now.Year, 10, 1),
            new DateTime(DateTime.Now.Year, 11, 1),
            new DateTime(DateTime.Now.Year, 12, 1)
            }; 
            
        }

        public void CalculateForeCast()
        {
            OrderDateCalculator orderDateCalc = new OrderDateCalculator();

            ForeCast = orderDateCalc.OrderDatesForAllProducts(products);

        }
    }
}
