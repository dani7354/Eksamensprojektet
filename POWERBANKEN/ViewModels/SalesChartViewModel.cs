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
        public List<SalesStatistics> ProductStatistics
        {
            get { return _productStatistics; }
            set
            {
                _productStatistics = value; NotifyPropertyChanged("StatistikPDB");
            }
        }
        public List<Product>ProductName { get; set; }
        public List<Brand>Brands { get; set; }
        public Brand SelectedBrand {
            get { return _selectedBrand; }
            set { _selectedBrand = value; NotifyPropertyChanged("SelectedBrand"); }
           
        }
        public List<SalesStatistics> BrandSaleList { get; } = new List<SalesStatistics>();
        public MainController Controller = MainController.Instance;
        private Brand _selectedBrand;
        private List<SalesStatistics> _productStatistics;
        public SalesChartViewModel()
        {
            ProductStatistics = Controller.GetProductSales();
            ProductName = Controller.GetProducts().Where(p=>p.IsActive ==true).ToList();
            Brands = Controller.GetBrands();
            SelectedBrand = Brands[0];
            Setproduct();
        }
            

        private void Setproduct()
        {
            foreach (var item in ProductStatistics.Where(S=>ProductName.Exists(p=>p.SKU == S.Product.SKU)))
            {
                var SKU = item.Product.SKU;
                item.Product = ProductName.Where(p => p.SKU == SKU).First();
            }
        }


        

        public void CalulateBrandSale()
        {
            BrandSaleList.Clear();
            foreach (var item in Brands)
            {
                for (int i = 0; i < 12; i++)
                {

                    var s = new SalesStatistics();
                    s.Product = new Product();
                    s.PeriodStart = new DateTime(2017,i+1,1);
                    s.Product.Brand = item;
                    s.QuantitySold = ProductStatistics.Where(x => x.Product.Brand != null&& x.Product.Brand.Name ==item.Name && x.PeriodStart.Month == i+1).Sum(x => x.QuantitySold);
                    BrandSaleList.Add(s);
                }
            }
        }
        public void SetStatistics() { ProductStatistics = Controller.GetProductSales().Where(S => S.Product.Brand != null && S.Product.Brand.Name == SelectedBrand.Name).ToList(); 
    }
    }


}
