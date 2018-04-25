using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}