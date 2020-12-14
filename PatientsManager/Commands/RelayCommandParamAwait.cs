using System;
using System.Windows.Input;
using System.Threading.Tasks;

namespace PatientsManager.Commands
{
    public class RelayCommandParamAwait : ICommand
    {
        #region fields
        public event EventHandler CanExecuteChanged;

        private delegate Task MyDelegate(Object obj);
        private MyDelegate myDelegate;
        #endregion

        #region methods
        public RelayCommandParamAwait(Func<Object, Task> func)
        {
            myDelegate = new MyDelegate(func);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            myDelegate.Invoke(parameter);
        }
        #endregion
    }
}
