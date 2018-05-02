using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{
    public partial class StockWindow : Window
    {
        StockViewModel _viewModel = null;
        public StockWindow()
        {
            _viewModel = new StockViewModel();
            InitializeComponent();
            DataContext = _viewModel;
            this.Closing += StockWindow_Closing;
        }

        private void StockWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) => Environment.Exit(1); // Lukker alle øvrige vinduer, hvis Mainvinduet lukkes
       
        private void btn_SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.UpdateProducts();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ChangeGridSource_Click(object sender, RoutedEventArgs e)
        {
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

        private void Btn_VareStatistic_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_Notifications_Click(object sender, RoutedEventArgs e)
        {
            OrderNotificationWindow ordernotificationwindow = new OrderNotificationWindow(_viewModel);
            ordernotificationwindow.Show();
        }
    }
}
