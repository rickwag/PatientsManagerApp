using System;
using System.Windows.Input;

namespace PatientsManager.Commands
{
    public class RelayCommand : ICommand
    {
        #region fields
        public event EventHandler CanExecuteChanged;

        private Action myDelegate;
        #endregion

        #region methods
        public RelayCommand(Action action)
        {
            myDelegate = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            myDelegate();
        }
        #endregion
    }
}
