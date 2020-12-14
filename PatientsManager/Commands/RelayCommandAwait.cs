using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientsManager.Commands
{
    public class RelayCommandAwait : ICommand
    {
        #region fields
        public event EventHandler CanExecuteChanged;

        private delegate Task MyDelegate();
        private MyDelegate myDelegate;
        #endregion

        #region methods
        public RelayCommandAwait(Func<Task> func)
        {
            myDelegate = new MyDelegate(func);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            myDelegate.Invoke();
        }
        #endregion
    }
}
