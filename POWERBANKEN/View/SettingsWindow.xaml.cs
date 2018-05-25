using System.Windows;
using ViewModels;

namespace View
{
    public partial class SettingsWindow : Window
    {
        private MainViewModel _viewModel;
        public SettingsWindow(MainViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            DataContext = _viewModel;
        }
        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
