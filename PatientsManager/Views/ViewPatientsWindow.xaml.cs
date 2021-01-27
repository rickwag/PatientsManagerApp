using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using PatientsManager.ViewModels;
using PatientsManager.Models;

namespace PatientsManager.Views
{
    /// <summary>
    /// Interaction logic for ViewPatientsWindow.xaml
    /// </summary>
    public partial class ViewPatientsWindow : Window
    {
        public ViewPatientsWindow()
        {
            InitializeComponent();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (DataContext as PatientsViewModel).ShowPatientDetailCommand.Execute(null);
            listBox.SelectedItems.Clear();
        }

        private void OnExportClicked(object sender, RoutedEventArgs e)
        {
            var patients = new List<Patient>();

            foreach (var item in listBox.SelectedItems)
            {
                patients.Add(item as Patient);
            }

            (DataContext as PatientsViewModel).ExportPatients(patients);
        }

        private void OnGenerateReportsClicked(object sender, RoutedEventArgs e)
        {
            var patients = new List<Patient>();

            foreach (var item in listBox.SelectedItems)
            {
                patients.Add(item as Patient);
            }

            (DataContext as PatientsViewModel).GenerateReports(patients);
        }
    }
}
