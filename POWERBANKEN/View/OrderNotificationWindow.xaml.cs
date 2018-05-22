using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using ViewModels;

namespace View
{
    /// <summary>
    /// Interaction logic for OrderNotificationWindow.xaml
    /// </summary>
    public partial class OrderNotificationWindow : Window
    {
        private OrderNotificationViewModel _viewModel;
        public OrderNotificationWindow(MainViewModel viewModel)
        {
            _viewModel = new OrderNotificationViewModel(viewModel);
            DataContext = _viewModel;
            InitializeComponent();
        }
	}
}
