using System.Windows.Controls;
using System.Windows.Input;
using PatientsManager.ViewModels;

namespace PatientsManager.Views
{
    /// <summary>
    /// Interaction logic for PatientTreatmentsListUserControl.xaml
    /// </summary>
    public partial class PatientTreatmentsListUserControl : UserControl
    {
        public PatientTreatmentsListUserControl()
        {
            InitializeComponent();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (DataContext as PatientsViewModel).ShowPatientTreatmentDetailCommand.Execute(null);
        }
    }
}
