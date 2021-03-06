﻿using System;
using ViewModels;
using System.Windows;
using System.Windows.Controls;


namespace View
{
    public partial class MainWindow : Window
    {
        MainViewModel _viewModel = null;
        public MainWindow()
        {
            _viewModel = new MainViewModel();
            InitializeComponent();
            DataContext = _viewModel;
            _viewModel.OrderDatesAdded += (OrderDatesAdded, e) => MessageBox.Show($"{OrderDatesAdded} nye varer skal bestilles inden for de næste {_viewModel.DaysInAdvance} dage - se vinduet med bestillingsdatoer.");
            Closing += StockWindow_Closing;
        }

        private void StockWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) => Environment.Exit(1); // Lukker alle øvrige vinduer, hvis Mainvinduet lukkes
       
        private void Btn_SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.UpdateProducts();
                MessageBox.Show("Ændringer gemt!");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_ChangeGridSource_Click(object sender, RoutedEventArgs e)
        {
            if(btn_ChangeGridSource.Content.ToString() == "Vis deaktiverede varer")
            {
                btn_ChangeGridSource.Content = "Vis aktiverede varer";
            }
            else
            {
                btn_ChangeGridSource.Content = "Vis deaktiverede varer";
            }
            try
            {
                _viewModel.ShowDeactivatedProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tb_SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.Search();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addprodWin = new AddProductWindow();
            addprodWin.Show();
            addprodWin.Closing += AddprodWin_Closing;
        }

        private void AddprodWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _viewModel.GetProducts();
            dGrid_products.Items.Refresh();
        }

        private void dGrid_products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Btn_Graph_Click(object sender, RoutedEventArgs e)
        {
			SalesChartView sta = new SalesChartView();
			sta.Show();
		}

        private void Btn_Notifications_Click(object sender, RoutedEventArgs e)
        {
            OrderNotificationWindow ordernotificationwindow = new OrderNotificationWindow(_viewModel);
            ordernotificationwindow.Show();
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow setwindow = new SettingsWindow(_viewModel);
            setwindow.Show();
        }

        private void btn_ImportProductSales(object sender, RoutedEventArgs e)
        {
            CSVImportWindow csvWindow = new CSVImportWindow();
            csvWindow.Show();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Btn_SaveAndClose_Click(sender, e);
            Close();
        }
    }
}
