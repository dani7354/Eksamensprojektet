using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModels;

namespace View
{
    /// <summary>
    /// Interaction logic for OrderNotificationWindow.xaml
    /// </summary>
    public partial class OrderNotificationWindow : Window
    {
        private StockViewModel _viewModel;
        public OrderNotificationWindow(StockViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}
