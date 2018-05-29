using System.Runtime.CompilerServices;
using System.ComponentModel;


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