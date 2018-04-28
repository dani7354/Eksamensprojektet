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
    /// Interaction logic for StatesticWindow.xaml
    /// </summary>
    public partial class StatesticWindow : Window
    {

        ForeCastViewModel fm;
        public StatesticWindow()
        {
            InitializeComponent();
            fm = new ForeCastViewModel();
            DataContext = fm;

        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            fm.CalculateForeCast();
        }
    }
}
