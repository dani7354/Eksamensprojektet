using System;
using System.Windows;

using ViewModels;

namespace View
{

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
                MessageBox.Show("Der er opstået en fejl, da filen allerede er blevet importeret" + ex.Message);
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
