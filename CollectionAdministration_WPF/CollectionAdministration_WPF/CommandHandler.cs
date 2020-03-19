using System;
using System.Windows.Input;

namespace CollectionAdministration_WPF
{
    public class CommandHandler : ICommand
    {
        private readonly Action Action;

        public CommandHandler(Action action)
        {
            Action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action();
        }
    }
}
