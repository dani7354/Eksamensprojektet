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
    /// Vindue til at i importere månedlige salgstal for alle produkter.
    /// </summary>
    public partial class CSVImportWindow : Window
    {
        private ImportCSVViewModel _viewModel;
        public CSVImportWindow()
        {
            InitializeComponent();
            _viewModel = new ImportCSVViewModel();
            this.DataContext = _viewModel;
        }

        private void Btn_Browse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            _viewModel.ChooseCSVFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Import_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.ImportSalesInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_SaveToDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.WriteToDB();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
