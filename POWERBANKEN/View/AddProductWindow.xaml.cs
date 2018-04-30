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
  
    public partial class AddProductWindow : Window
    {
        AddProductViewModel _viewModel;
        public AddProductWindow()
        {
            InitializeComponent();
            _viewModel = new AddProductViewModel();
            DataContext = _viewModel;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
