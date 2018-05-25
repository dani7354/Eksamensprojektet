using System.Windows;
using ViewModels;

namespace View
{
  
    public partial class AddProductWindow : Window
    {
        AddProductViewModel _viewModel;
        public AddProductWindow()
        {
            InitializeComponent();
            _viewModel = new AddProductViewModel();
            DataContext = _viewModel;
            _viewModel.ProductAdded += (sender, e) => MessageBox.Show( sender + " er tilføjet");
        }
    }
}
