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
    /// <summary>
    /// Interaction logic for StockWindow.xaml
    /// </summary>
    public partial class StockWindow : Window
    {
        StockViewModel _viewModel = null;
        public StockWindow()
        {
            _viewModel = new StockViewModel();
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void btn_SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.UpdateProducts();
                this.Close();
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

        private void mItem_SaleForecast_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
