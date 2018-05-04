using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels
{
    public class CommandHandler : ICommand
    {
        private readonly bool _canExecute;
        private readonly Action _execute;
        public event EventHandler CanExecuteChanged;

        public CommandHandler(Action action, bool canExecute)
        {
            this._execute = action;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
