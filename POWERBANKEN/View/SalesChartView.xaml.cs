using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ViewModels;
using Syncfusion.UI.Xaml.Charts;

namespace View
{

    public partial class SalesChartView : Window
    {

        private SalesChartViewModel Salesview;
        public SalesChartView()
        {
            InitializeComponent();
            Salesview = new SalesChartViewModel();
            DataContext = Salesview;
        }
        private void StartupChart()
        {
            foreach (var item in Salesview.ProductName.Where(p=>p.Brand.Name==Salesview.SelectedBrand.Name))
            {
                Chartseries.Legend = new ChartLegend()
                {
                    ToggleSeriesVisibility = true,
                    DockPosition = ChartDock.Left,
                    CheckBoxVisibility = Visibility.Visible
                };
                SplineSeries spline = new SplineSeries()
                {
                    Label = item.Name,
                    ItemsSource = Salesview.ProductStatistics.Where(s=>s.Product.Equals(item) && s.PeriodStart.Month <= Slider.RangeEnd && s.PeriodEnd.Month >= Slider.RangeStart).ToList(),
                    XBindingPath = "PeriodStart",
                    YBindingPath = "QuantitySold",
                    ShowTooltip=true,
                    ShowEmptyPoints = true
                };
    
                Chartseries.Series.Add(spline);
            }
             
        }
        private void StartBrandChart()
        {
           
            foreach (var item in Salesview.Brands)
            {
                Chartseries.Legend = new ChartLegend()
                {
                    ToggleSeriesVisibility = true,
                    DockPosition = ChartDock.Left,
                    CheckBoxVisibility = Visibility.Visible
                };
                SplineSeries spline = new SplineSeries()
                {
                    Label = item.Name,
                    ItemsSource = Salesview.BrandSaleList.Where(x => x.Product.Brand.Name == item.Name && x.PeriodStart.Month <= Slider.RangeEnd && x.PeriodStart.Month >= Slider.RangeStart).ToList(),
                    XBindingPath = "PeriodStart",
                    YBindingPath = "QuantitySold",
                    ShowTooltip = true,
                   ShowEmptyPoints = true
                };

                Chartseries.Series.Add(spline);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Chartseries.Series.Clear();
            StartupChart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Chartseries.Series.Clear();
            Salesview.CalculateBrandSale();
            StartBrandChart();
        }

        private void SfRangeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }



    }


}

