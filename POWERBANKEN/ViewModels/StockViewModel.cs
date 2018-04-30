﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public StockViewModel()
        {
            _controller = Controller.MainController.Instance;
            _allProducts = _controller.GetProducts();
            SelectedProducts = _allProducts.Where(p => p.IsActive == true).ToList<Product>();
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
            _allProducts = _controller.GetProducts();
            SelectedProducts = _allProducts.Where(p => p.IsActive == true).ToList<Product>();
        }

    }
}
