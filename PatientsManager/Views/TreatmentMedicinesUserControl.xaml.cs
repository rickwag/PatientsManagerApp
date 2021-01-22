using System.Windows.Controls;
using System.Windows.Input;

using PatientsManager.ViewModels;

namespace PatientsManager.Views
{
    /// <summary>
    /// Interaction logic for TreatmentMedicinesUserControl.xaml
    /// </summary>
    public partial class TreatmentMedicinesUserControl : UserControl
    {
        public TreatmentMedicinesUserControl()
        {
            InitializeComponent();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (DataContext as PatientsViewModel).ShowPatientTreatmentDetailCommand.Execute(null);
        }
    }
}
