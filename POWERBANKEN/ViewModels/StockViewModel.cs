using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;
using System.Windows.Input;

namespace ViewModels
{
    public class StockViewModel : BaseViewModel
    {
        private List<Product> _products;
        private bool _deaktivatedProductsShown = false;

        public StockViewModel()
        {
            Products = ProductDB.GetAllProducts().Where(p => p.IsActive == true).ToList<Product>();
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
        public void UpdateProducts()
        {
            ProductDB.UpdateProducts(Products);
        }
        public void ShowDeactivatedProducts()
        {
            UpdateProducts();
            if (!_deaktivatedProductsShown)
            {
                Products = ProductDB.GetAllProducts().Where(p => p.IsActive == false).ToList<Product>();
                _deaktivatedProductsShown = true;
            }
            else
            {
                Products = ProductDB.GetAllProducts().Where(p => p.IsActive == true).ToList<Product>();
                _deaktivatedProductsShown = false;
            }
         
        }

    }
}
