using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Controller;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Input;

namespace ViewModels
{
   public class SalesChartViewModel : BaseViewModel
    {
        public SalesChartViewModel()
        {
            ProductStatistics = Controller.GetProductSales();
            ProductName = Controller.GetProducts().Where(p=>p.IsActive ==true).ToList();
            Brands = Controller.GetBrands();
            SelectedBrand = Brands[0];
            Setproduct();
            CustomCollection = new ObservableCollection<Items>();
            AddMonths();
        }

        public MainController Controller = MainController.Instance;

        private List<SalesStatistics> _productStatistics;
        public List<SalesStatistics> ProductStatistics
        {
            get
            {
                return _productStatistics;
            }
            set
            {
                _productStatistics = value; NotifyPropertyChanged("StatistikPDB");
            }
        }

        public List<Product>ProductName { get; set; }

        public List<Brand>Brands { get; set; }

        private Brand _selectedBrand;
        public Brand SelectedBrand {
            get { return _selectedBrand; }
            set { _selectedBrand = value; NotifyPropertyChanged("SelectedBrand"); }
           
        }

        public List<SalesStatistics> BrandSaleList { get; } = new List<SalesStatistics>();
            

        private void Setproduct()
        {
            foreach (var item in ProductStatistics.Where(S=>ProductName.Exists(p=>p.SKU == S.Product.SKU)))
            {
                var SKU = item.Product.SKU;
                item.Product = ProductName.Where(p => p.SKU == SKU).First();
            }
        }

        public void CalculateBrandSale()
        {
            BrandSaleList.Clear();
            foreach (var item in Brands)
            {
                for (int i = 0; i < 12; i++)
                {

                    SalesStatistics s = new SalesStatistics
                    {
                        Product = new Product(),
                        PeriodStart = new DateTime(2017, i + 1, 1)
                    };
                    s.Product.Brand = item;
                    s.QuantitySold = ProductStatistics.Where(x => x.Product.Brand != null && x.Product.Brand.Name ==item.Name && x.PeriodStart.Month == i+1).Sum(x => x.QuantitySold);
                    BrandSaleList.Add(s);
                }
            }
        }
        public void SetStatistics()
        {

           ProductStatistics = Controller.GetProductSales().Where(S => S.Product.Brand != null && S.Product.Brand.Name == SelectedBrand.Name).ToList(); 
        }
        public ObservableCollection<Items> CustomCollection { get; set; }
        public void AddMonths()
        {
            CustomCollection.Add(new Items() { label = "Jan", value = 1 });

            CustomCollection.Add(new Items() { label = "Feb", value = 2 });

            CustomCollection.Add(new Items() { label = "Mar", value = 3 });

            CustomCollection.Add(new Items() { label = "Apr", value = 4 });

            CustomCollection.Add(new Items() { label = "Maj", value = 5 });

            CustomCollection.Add(new Items() { label = "Jun", value = 6 });

            CustomCollection.Add(new Items() { label = "Jul", value = 7 });

            CustomCollection.Add(new Items() { label = "Aug", value = 8 });

            CustomCollection.Add(new Items() { label = "Sep", value = 9 });

            CustomCollection.Add(new Items() { label = "Okt", value = 10 });

            CustomCollection.Add(new Items() { label = "Nov", value = 11 });

            CustomCollection.Add(new Items() { label = "Dec", value = 12 });
        }
    }


}
