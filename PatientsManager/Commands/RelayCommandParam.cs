using System;
using System.Windows.Input;

namespace PatientsManager.Commands
{
    public class RelayCommandParam : ICommand
    {
        #region fields
        public event EventHandler CanExecuteChanged;

        private Action<Object> myDelegate;
        #endregion

        #region methods
        public RelayCommandParam(Action<Object> action)
        {
            myDelegate = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            myDelegate(parameter);
        }
        #endregion
    }
}
