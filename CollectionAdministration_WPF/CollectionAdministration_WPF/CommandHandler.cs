using System;
using System.Windows.Input;

namespace CollectionAdministration_WPF
{
    public class CommandHandler : ICommand
    {
        private readonly Action _action;

        public CommandHandler(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
