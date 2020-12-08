using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlickrClient.Components.Commands
{
    public class Command : ICommand
    {
        private readonly Func<bool> _canExecuteHandler;
        private readonly Action _executeHandler;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Command(Func<bool> canExecuteHandler, Action executeHandler)
        {
            _canExecuteHandler = canExecuteHandler;
            _executeHandler = executeHandler;
        }

        public Command(Action executeHandler) : this(null, executeHandler)
        {
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteHandler == null)
            {
                return true;
            }

            return _canExecuteHandler();
        }

        public void Execute(object parameter)
        {
            _executeHandler();
        }
    }
}
