using System.Windows;
using System.Windows.Input;
using PatientsManager.ViewModels;

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
        }
    }
}
