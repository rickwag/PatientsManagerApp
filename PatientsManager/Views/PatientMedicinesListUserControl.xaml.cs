using System.Windows.Controls;
using System.Windows.Input;
using PatientsManager.ViewModels;

namespace PatientsManager.Views
{
    /// <summary>
    /// Interaction logic for PatientMedicinesListUserControl.xaml
    /// </summary>
    public partial class PatientMedicinesListUserControl : UserControl
    {
        public PatientMedicinesListUserControl()
        {
            InitializeComponent();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (DataContext as PatientsViewModel).ShowPatientMedicineDetailCommand.Execute(null);
        }
    }
}
