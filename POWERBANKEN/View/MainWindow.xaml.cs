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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window w;
        public MainWindow()
        {
            w = new Window();
            InitializeComponent();
        }

        private void Btn_Order_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();
            w.Close();
        }

        private void Btn_Statestic_Click(object sender, RoutedEventArgs e)
        {
            StatesticWindow statesticWindow = new StatesticWindow();
            statesticWindow.Show();
            w.Close();
        }

        private void StockView_Click(object sender, RoutedEventArgs e)
        {
            StockWindow swindow = new StockWindow();
            swindow.Show();
        }

        private void ImportFromCSV_Click(object sender, RoutedEventArgs e)
        {
            CSVImportWindow csvImportWindow = new CSVImportWindow();
            csvImportWindow.Show();
        }
    }
}
