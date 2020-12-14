using System.ComponentModel;
using System.Windows;
using PatientsManager.Commands;

namespace PatientsManager.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region fields
        public event PropertyChangedEventHandler PropertyChanged;

        private RelayCommandParam closeWindowCommand;
        #endregion

        #region properties
        public RelayCommandParam CloseWindowCommand
        {
            get { return closeWindowCommand; }
        }
        #endregion

        #region methods
        public BaseViewModel()
        {
            InitialiseCommands();
        }

        public virtual void InitialiseCommands()
        {
            closeWindowCommand = new RelayCommandParam(CloseWindow);
        }

        public void CloseWindow(object windowObject)
        {
            (windowObject as Window).Close();
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
