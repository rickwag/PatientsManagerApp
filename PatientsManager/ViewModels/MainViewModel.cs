using System;
using System.Threading.Tasks;
using PatientsManager.Commands;
using PatientsManager.Views;

namespace PatientsManager.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region fields
        private RelayCommand exitCommand;
        private RelayCommandAwait newPatientCommand;
        private RelayCommandAwait newTreatmentCommand;
        private RelayCommandAwait newMedicineCommand;
        private RelayCommandAwait viewPatientsCommand;
        #endregion

        #region properties
        public PatientsViewModel PatientsViewModel { get; set; } = new PatientsViewModel();

        public RelayCommand ExitCommand
        {
            get { return exitCommand; }
        }
        public RelayCommandAwait NewPatientCommand
        {
            get { return newPatientCommand; }
        }
        public RelayCommandAwait NewTreatmentCommand
        {
            get { return newTreatmentCommand; }
        }
        public RelayCommandAwait NewMedicineCommand
        {
            get { return newMedicineCommand; }
        }
        public RelayCommandAwait ViewPatientsCommand
        {
            get { return viewPatientsCommand; }
        }
        #endregion

        #region methods
        public MainViewModel()
        {
            InitialiseCommands();
        }

        public override void InitialiseCommands()
        {
            base.InitialiseCommands();

            exitCommand = new RelayCommand(Exit);
            newPatientCommand = new RelayCommandAwait(AddNewPatientAsync);
            newTreatmentCommand = new RelayCommandAwait(AddNewTreatmentAsync);
            newMedicineCommand = new RelayCommandAwait(AddNewMedicineAsync);
            viewPatientsCommand = new RelayCommandAwait(ViewPatientsAsync);
        }

        public void Exit()
        {
            App.Current.MainWindow.Close();
        }
        public void AddNewPatient()
        {
            NewPatientWindow newPatientWindow = new NewPatientWindow();
            newPatientWindow.DataContext = PatientsViewModel;
            newPatientWindow.ShowDialog();
        }
        public async Task AddNewPatientAsync()
        {
            NewPatientWindow newPatientWindow = new NewPatientWindow();
            newPatientWindow.DataContext = PatientsViewModel;

            await Task.Delay(TimeSpan.FromSeconds(.5));

            newPatientWindow.ShowDialog();
        }
        public void AddNewTreatment()
        {
            NewTreatmentWindow newTreatmentWindow = new NewTreatmentWindow();
            newTreatmentWindow.DataContext = new TreatmentsViewModel();
            newTreatmentWindow.ShowDialog();
        }
        public async Task AddNewTreatmentAsync()
        {
            NewTreatmentWindow newTreatmentWindow = new NewTreatmentWindow();
            newTreatmentWindow.DataContext = new TreatmentsViewModel();

            await Task.Delay(TimeSpan.FromSeconds(.5));

            newTreatmentWindow.ShowDialog();
        }
        public void AddNewMedicine()
        {
            NewMedicineWindow newMedicineWindow = new NewMedicineWindow();
            newMedicineWindow.ShowDialog();
        }
        public async Task AddNewMedicineAsync()
        {
            NewMedicineWindow newMedicineWindow = new NewMedicineWindow();

            await Task.Delay(TimeSpan.FromSeconds(.5));

            newMedicineWindow.ShowDialog();
        }
        public async Task ViewPatientsAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            PatientsViewModel.PopulatePatients();

            ViewPatientsWindow viewPatientsWindow = new ViewPatientsWindow();
            viewPatientsWindow.DataContext = PatientsViewModel;


            viewPatientsWindow.ShowDialog();
        }
        #endregion
    }
}
