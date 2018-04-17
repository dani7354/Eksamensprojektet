﻿using System;
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
        private List<Product> _allProducts;
        private List<Product> _selectedProducts;
        private bool _deaktivatedProductsShown = false;
        private string _searchText;

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
                    Search();
                }
            }
        }
        public StockViewModel()
        {
            _allProducts = ProductDB.GetAllProducts();
            SelectedProducts = _allProducts.Where(p => p.IsActive == true).ToList<Product>();
        }
        private void Search()
        {
            SelectedProducts = _allProducts.Where(p => p.ToString().ToLower().Contains(SearchText.ToLower())).ToList<Product>();
        }
        public void UpdateProducts()
        {
            ProductDB.UpdateProducts(_allProducts);
        }
        public void ShowDeactivatedProducts()
        {
            //UpdateProducts();
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

    }
}
