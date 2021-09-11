using System;
using System.Windows.Input;

namespace FlickrClient.Components.Commands
{
    public class ParametrizedCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecuteHandler;
        private readonly Action<T> _executeHandler;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ParametrizedCommand(Func<T, bool> canExecuteHandler, Action<T> executeHandler)
        {
            _canExecuteHandler = canExecuteHandler;
            _executeHandler = executeHandler;
        }

        public ParametrizedCommand(Action<T> executeHandler) : this(null, executeHandler)
        {
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteHandler == null)
            {
                return true;
            }

            T convertedParameter = (T)parameter;
            return _canExecuteHandler(convertedParameter);
        }

        public void Execute(object parameter)
        {
            T convertedParameter = (T)parameter;
            _executeHandler(convertedParameter);
        }
    }
}