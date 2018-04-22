using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;
using Microsoft.Win32;

namespace ViewModels
{
    public class ImportCSVViewModel : BaseViewModel
    {
        private CSVReader _csvReader;
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
            _csvReader = new CSVReader();
            FilePath = "Vælg en filsti";
        }

        public void ImportSalesInfo()
        {
            Sales = _csvReader.ReadProductsSalesInfoFromCSV(_filePath);
        }

        public void ChooseCSVFile()
        {
            OpenFileDialog _openFileDialog = new OpenFileDialog();
            _openFileDialog.Multiselect = false;
            _openFileDialog.Filter = "CVS filer (*.csv)|*.csv|All files (*.*)|*.*";
            if (_openFileDialog.ShowDialog() == true)
            {
                FilePath = _openFileDialog.FileName;
            }
            FilePath = _openFileDialog.FileName;
        }





    }
}
