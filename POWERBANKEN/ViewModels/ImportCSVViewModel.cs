using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.Win32;

namespace ViewModels
{
    public class ImportCSVViewModel : BaseViewModel
    {
        private Controller.MainController _controller;
        private List<SalesStatistics> _sales;
        private string _filePath;
        public List<SalesStatistics> Sales
        {
            get
            {
                return _sales;
            }
            set
            {
                _sales = value;
                NotifyPropertyChanged("Sales");
            }
        }
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                NotifyPropertyChanged("FilePath");
            }
        }
        public ImportCSVViewModel()
        {
            _controller = Controller.MainController.Instance;
            FilePath = "Vælg en filsti";
        }

        public void ImportSalesInfo()
        {
            Sales = _controller.ReadProductsSalesInfoFromCSV(_filePath);
        }

        public void ChooseCSVFile()
        {
            OpenFileDialog _openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "CVS filer (*.csv)|*.csv"
            };
            if (_openFileDialog.ShowDialog() == true)
            {
                FilePath = _openFileDialog.FileName;
            }
            FilePath = _openFileDialog.FileName;
        }
        public void WriteToDB()
        {
            _controller.InsertProductSale(_sales);
        }
    }
}
