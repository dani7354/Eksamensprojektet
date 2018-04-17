using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;


namespace ViewModels
{
    public class StockViewModel : BaseViewModel
    {
        private List<Product> _products;

        public StockViewModel()
        {
            Products = ProductDB.GetAllProducts();
        }
        public List<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                NotifyPropertyChanged("Products");
            }
        }
    }
}
