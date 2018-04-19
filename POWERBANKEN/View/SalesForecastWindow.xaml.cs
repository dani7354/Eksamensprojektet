﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ViewModels;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for SalesForecastWindow.xaml
    /// </summary>
    public partial class SalesForecastWindow : Window
    {
        private ProductForecastViewModel _viewModel;
        public SalesForecastWindow()
        {
            InitializeComponent();
            _viewModel = new ProductForecastViewModel();
            DataContext = _viewModel;
        }
    }
}