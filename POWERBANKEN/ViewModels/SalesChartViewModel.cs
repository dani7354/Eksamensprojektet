using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Controller;


namespace ViewModels
{
   public class SalesChartViewModel : BaseViewModel
    {
        public SalesChartViewModel()
        {
            StatistikPDB = mc.GetProductSales();
            PDName = mc.GetProducts();
            Brands = mc.GetBrands();
            Setproduct();
        }
            
        public List<SalesStatistics> StatistikPDB
        {
            get { return _statistikPDB; }
            set
            {
                _statistikPDB = value; NotifyPropertyChanged("StatistikPDB");
            }
        }

        private void Setproduct()
        {
            foreach (var item in StatistikPDB.Where(S=>PDName.Exists(p=>p.SKU == S.Product.SKU)))
            {
                var SKU = item.Product.SKU;
                item.Product = PDName.Where(p => p.SKU == SKU).First();
            }
        }

        public List<Product>PDName { get; set; }

        public List<Brand>Brands { get; set; }
        
        public Brand SelectedBrand {
            get { return _selectedBrand; }
            set { _selectedBrand = value;SetStat(); NotifyPropertyChanged("SelectedBrand"); }

        }
        public void SetStat() { StatistikPDB = mc.GetProductSales().Where(S => S.Product.Brand != null && S.Product.Brand.Name == SelectedBrand.Name).ToList(); 
    }
        public MainController mc = MainController.Instance;
        private Brand _selectedBrand;
        private List<SalesStatistics> _statistikPDB;

    }
}
