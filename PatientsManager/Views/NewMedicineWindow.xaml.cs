using System.Windows;
using System.Windows.Controls;

using PatientsManager.ViewModels;

namespace PatientsManager.Views
{
    /// <summary>
    /// Interaction logic for NewMedicineWindow.xaml
    /// </summary>
    public partial class NewMedicineWindow : Window
    {
        public NewMedicineWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (this.DataContext as MedicinesViewModel).UpdateSelectedPatientTreatmentsCommand.Execute(null);
        }
    }
}
