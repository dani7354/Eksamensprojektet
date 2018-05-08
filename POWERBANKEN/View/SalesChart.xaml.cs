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
using Domain;
using Syncfusion.UI.Xaml.Charts;

namespace View
{
    /// <summary>
    /// Interaction logic for SalesChart.xaml
    /// </summary>
    public partial class SalesChart : Window
    {
        private SalesChartViewModel Salesview;
        public SalesChart()
        {
            InitializeComponent();

            Salesview = new SalesChartViewModel();
            DataContext = Salesview;
        }
        private void StartupChar()
        {
            foreach (var item in Salesview.PDName.Where(p=>p.Brand.Name==Salesview.SelectedBrand.Name))
            {
                Chartseries.Legend = new ChartLegend()
                {
                    ToggleSeriesVisibility = true,
                    DockPosition = ChartDock.Left
                };
                SplineSeries spline = new SplineSeries()
                {
                    Label = item.Name,
                    ItemsSource = Salesview.StatistikPDB.Where(s=>s.Product.Equals(item)).ToList(),
                    XBindingPath = "PeriodStart.Month",
                    YBindingPath = "QuantitySold"
                   
                };
                
                Chartseries.Series.Add(spline);
            }
            //    
        }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StartupChar();
        }
    }
}
