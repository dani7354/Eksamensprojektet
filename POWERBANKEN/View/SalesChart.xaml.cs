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
    /// Interaction logic for SalesChart.xaml
    /// </summary>
    public partial class SalesChart : Window
    {
        public SalesChart()
        {
            InitializeComponent();

            DataContext = new SalesChartViewModel();
        }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
