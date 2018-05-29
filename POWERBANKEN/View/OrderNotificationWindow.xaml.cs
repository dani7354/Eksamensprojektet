using System.Windows;
using ViewModels;

namespace View
{
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
