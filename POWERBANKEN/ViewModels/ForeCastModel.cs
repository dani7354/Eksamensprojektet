﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using ViewModels;

namespace ViewModels
{
    public class ForeCastModel : BaseViewModel
    {
        public ForeCastModel()
        {
            Months = new List<DateTime>()
            { new DateTime(DateTime.Now.Year, 1, 1),
            new DateTime(DateTime.Now.Year, 2, 1),
            new DateTime(DateTime.Now.Year, 3, 1),
            new DateTime(DateTime.Now.Year, 4, 1),
            new DateTime(DateTime.Now.Year, 5, 1),
            new DateTime(DateTime.Now.Year, 6, 1),
            new DateTime(DateTime.Now.Year, 7, 1),
            new DateTime(DateTime.Now.Year, 8, 1),
            new DateTime(DateTime.Now.Year, 9, 1),
            new DateTime(DateTime.Now.Year, 10, 1),
            new DateTime(DateTime.Now.Year, 11, 1),
            new DateTime(DateTime.Now.Year, 12, 1)
            }; 
            
        }
        private double _GrowthInPercent;
        private List<DateTime> _months;
        private List<SalesStatistics> _foreCastGrid;

        public double GrowthInPercent
        {
            get
            {
                return _GrowthInPercent;
            }
            set
            {
                _GrowthInPercent = value;
                NotifyPropertyChanged("GrowthInPercent");
            }
        }

        public List<DateTime> Months
        {
            get
            {
                return _months;
            }
            set
            {
                _months = value;
                NotifyPropertyChanged("Months");
            }
            
        }

        public DateTime SelectedMonth
        {
            get; set; 
        }

        public List<SalesStatistics> ForeCast
        {
            get
            {
                return _foreCastGrid;
            }
            set
            {
                _foreCastGrid = value;
                NotifyPropertyChanged("ForeCast");
            }
        }

        public void CalculateForeCast()
        {
            DifferenceInPercent differenceInPercent = new DifferenceInPercent();
            ForeCast = differenceInPercent.ForeCastCalculation(GrowthInPercent, SelectedMonth).OrderByDescending(x => x.QuantitySold).ToList();

        }
    }
}
