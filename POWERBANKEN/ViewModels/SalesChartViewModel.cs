using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Controller;
using Syncfusion.UI.Xaml.Charts;

namespace ViewModels
{
   public class SalesChartViewModel : BaseViewModel
    {
        public List<SalesStatistics> StatistikPDB
        {
            get { return _statistikPDB; }
            set
            {
                _statistikPDB = value; NotifyPropertyChanged("StatistikPDB");
            }
        }

        public List<Product>PDName { get; set; }

        public List<Brand>Brands { get; set; }
        
        public Brand SelectedBrand {
            get { return _selectedBrand; }
            set { _selectedBrand = value;SetStat(); NotifyPropertyChanged("SelectedBrand"); }

        }
        public void SetStat() { StatistikPDB = mc.GetProductSales().Where(S => S.Product.Brand.Name == SelectedBrand.Name).ToList(); 
    }
        public MainController mc = MainController.Instance;
        private Brand _selectedBrand;
        private List<SalesStatistics> _statistikPDB;

        public SalesChartViewModel()
        {
            StatistikPDB = mc.GetProductSales();
            PDName = mc.GetProducts();
            Brands = mc.GetBrands();
        }
            
    }
}
