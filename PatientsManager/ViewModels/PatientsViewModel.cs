using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using PatientsManager.Models;
using PatientsManager.Commands;
using PatientsManager.Views;

namespace PatientsManager.ViewModels
{
    public class PatientsViewModel : BaseViewModel
    {
        #region fields
        private int selectedPatientIndex;
        private int selectedTreatmentIndex;
        private int selectedMedicineIndex;
        private ObservableCollection<Treatment> selectedPatientTreatments = new ObservableCollection<Treatment>();
        private ObservableCollection<Medicine> selectedPatientMedicines = new ObservableCollection<Medicine>();
        private UserControl currentTreatmentInfoControl;
        private List<Medicine> selectedTreatmentMedicines = new List<Medicine>();

        private RelayCommandParamAwait saveNewPatientCommand;
        private RelayCommandAwait showPatientDetailCommand;
        private RelayCommandAwait showPatientTreatmentDetailCommand;
        private RelayCommandAwait showPatientMedicineDetailCommand;
        private RelayCommandParamAwait showEditPatientWindowCommand;
        private RelayCommandParamAwait deleteSelectedPatientCommand;
        private RelayCommandParamAwait deleteSelectedTreatmentCommand;
        private RelayCommandParamAwait deleteSelectedMedicineCommand;
        private RelayCommandParamAwait showEditTreatmentWindowCommand;
        private RelayCommandParamAwait showEditMedicineWindowCommand;
        #endregion

        #region properties
        public Patient NewPatient { get; set; } = new Patient();
        public string[] MaritalStatuses { get; set; } = new string[] { "single", "married", "divorced" };
        public ObservableCollection<Patient> Patients { get; set; } = new ObservableCollection<Patient>();
        public int SelectedPatientIndex
        { 
            get { return selectedPatientIndex; }
            set
            {
                selectedPatientIndex = value;

                InitialiseSelectedPatientTreatments();
                InitialiseSelectedPatientMedicines();
            }
        }
        public Patient SelectedPatient
        {
            get { return Patients[SelectedPatientIndex]; }
        }
        public ObservableCollection<Treatment> SelectedPatientTreatments
        {
            get { return selectedPatientTreatments; }
            set
            {
                selectedPatientTreatments = value;

                OnPropertyChanged("SelectedPatientTreatments");
            }
        }
        public ObservableCollection<Medicine> SelectedPatientMedicines
        {
            get { return selectedPatientMedicines; }
            set
            {
                selectedPatientMedicines = value;

                OnPropertyChanged("SelectedPatientTreatments");
            }
        }
        public int SelectedTreatmentIndex
        {
            get { return selectedTreatmentIndex; }
            set
            {
                selectedTreatmentIndex = value;
                InitialiseSelectedTreatmentMedicines();
            }
        }
        public Treatment SelectedTreatment
        {
            get { return SelectedPatientTreatments[SelectedTreatmentIndex]; }
        }
        public List<Medicine> SelectedTreatmentMedicines
        {
            get { return selectedTreatmentMedicines; }
            set
            {
                selectedTreatmentMedicines = value;

                OnPropertyChanged("SelectedTreatmentMedicines");
            }
        }
        public int SelectedMedicineIndex
        {
            get { return selectedMedicineIndex; }
            set { selectedMedicineIndex = value; }
        }
        public Medicine SelectedMedicine
        {
            get { return SelectedPatientMedicines[SelectedMedicineIndex]; }
        }

        public UserControl CurrentTreatmentInfoControl
        { 
            get { return currentTreatmentInfoControl; }
            set
            {
                currentTreatmentInfoControl = value;

                OnPropertyChanged("CurrentTreatmentInfoControl");
            }
        }
        public UserControl CurrentMedicineInfoControl { get; set; }

        public RelayCommandParamAwait SaveNewPatientCommand
        {
            get { return saveNewPatientCommand; }
        }
        public RelayCommandAwait ShowPatientDetailCommand
        {
            get { return showPatientDetailCommand; }
        }
        public RelayCommandAwait ShowPatientMedicineDetailCommand
        {
            get { return showPatientMedicineDetailCommand; }
        }
        public RelayCommandAwait ShowPatientTreatmentDetailCommand
        {
            get { return showPatientTreatmentDetailCommand; }
        }
        public RelayCommandParamAwait ShowEditPatientWindowCommand
        {
            get { return showEditPatientWindowCommand; }
        }
        public RelayCommandParamAwait DeleteSelectedPatientCommand
        {
            get { return deleteSelectedPatientCommand; }
        }
        public RelayCommandParamAwait DeleteSelectedTreatmentCommand
        {
            get { return deleteSelectedTreatmentCommand; }
        }
        public RelayCommandParamAwait DeleteSelectedMedicineCommand
        {
            get { return deleteSelectedMedicineCommand; }
        }
        public RelayCommandParamAwait ShowEditTreatmentWindowCommand
        {
            get { return showEditTreatmentWindowCommand; }
        }
        public RelayCommandParamAwait ShowEditMedicineWindowCommand
        {
            get { return showEditMedicineWindowCommand; }
        }
        #endregion

        #region methods
        public PatientsViewModel()
        {
            InitialiseCommands();
        }

        public override void InitialiseCommands()
        {
            base.InitialiseCommands();
            saveNewPatientCommand = new RelayCommandParamAwait(SaveNewPatientAsync);
            showPatientDetailCommand = new RelayCommandAwait(ShowPatientDetailAsync);
            showPatientTreatmentDetailCommand = new RelayCommandAwait(ShowPatientTreatmentDetailAsync);
            showPatientMedicineDetailCommand = new RelayCommandAwait(ShowPatientMedicineDetailAsync);
            showEditPatientWindowCommand = new RelayCommandParamAwait(ShowEditPatientAsync);
            deleteSelectedPatientCommand = new RelayCommandParamAwait(DeletePatientAsync);
            showEditTreatmentWindowCommand = new RelayCommandParamAwait(ShowEditTreatmentAsync);
            deleteSelectedTreatmentCommand = new RelayCommandParamAwait(DeleteTreatmentAsync);
            showEditMedicineWindowCommand = new RelayCommandParamAwait(ShowEditMedicineAsync);
            deleteSelectedMedicineCommand = new RelayCommandParamAwait(DeleteMedicineAsync);
        }
        public void InitialiseCurrentTreatmentInfoControl()
        {
            var currentTreatmentInfoControl = new PatientTreatmentsListUserControl();

            CurrentTreatmentInfoControl = currentTreatmentInfoControl;
        }
        public void InitialiseCurrentMedicineInfoControl()
        {
            CurrentMedicineInfoControl = new PatientMedicinesListUserControl();
        }
        public void InitialiseSelectedPatientTreatments()
        {
            SelectedPatientTreatments.Clear();

            if (SelectedPatientIndex == -1) return;

            var id = Patients[SelectedPatientIndex].PatientID;
            Patient patient;

            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                patient = context.Patients.FirstOrDefault(p => p.PatientID == id);

                foreach (var treatment in patient.Treatments)
                {
                    SelectedPatientTreatments.Add(treatment);
                }
            }
        }
        public void InitialiseSelectedPatientMedicines()
        {
            SelectedPatientMedicines.Clear();

            if (SelectedPatientIndex == -1) return;

            var id = Patients[SelectedPatientIndex].PatientID;
            Patient patient;

            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                patient = context.Patients.FirstOrDefault(p => p.PatientID == id);

                foreach (var medicine in patient.Medicines)
                {
                    SelectedPatientMedicines.Add(medicine);
                }
            }
        }
        public void InitialiseSelectedTreatmentMedicines()
        {
            SelectedTreatmentMedicines.Clear();

            if (SelectedTreatmentIndex == -1) return;

            var id = SelectedPatientTreatments[SelectedTreatmentIndex].TreatmentID;
            Treatment treatment;

            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                treatment = context.Treatments.FirstOrDefault(t => t.TreatmentID == id);

                foreach (var medicine in treatment.Medicines)
                {
                    SelectedTreatmentMedicines.Add(medicine);
                }
            }
        }

        public void PopulatePatients()
        {
            Patients.Clear();

            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                foreach (var patient in context.Patients)
                {
                    Patients.Add(patient);
                }
            }
        }

        public async Task SaveNewPatientAsync(object windowObject)
        {
            if (NewPatient.PatientID != 0)
            {
                await EditPatientAsync(windowObject);
                return;
            }

            await Task.Delay(TimeSpan.FromSeconds(.5));

            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                context.Patients.Add(NewPatient);

                try
                {
                    await context.SaveChangesAsync();

                    MessageBox.Show($"{NewPatient.FirstName} {NewPatient.LastName}" +
                     $" added successfully.", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);

                    (windowObject as Window).Close();
                    //access AddNewPatient from MainViewModel, DataContext of MainWindow
                    (App.Current.MainWindow.DataContext as MainViewModel).AddNewPatient();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            NewPatient.PatientID = 0;
        }
        public async Task EditPatientAsync(object windowObject)
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                var existingPatient = context.Patients.FirstOrDefault(patient => patient.PatientID == NewPatient.PatientID);
                
                if (!string.IsNullOrEmpty(NewPatient.FirstName))
                    existingPatient.FirstName = NewPatient.FirstName;

                if (!string.IsNullOrEmpty(NewPatient.LastName))
                    existingPatient.LastName = NewPatient.LastName;

                if (NewPatient.DateOfBirth != null)
                    existingPatient.DateOfBirth = NewPatient.DateOfBirth;

                if (NewPatient.MaritalStatus != null)
                    existingPatient.MaritalStatus = NewPatient.MaritalStatus;

                if (!string.IsNullOrEmpty(NewPatient.PhoneNumber))
                    existingPatient.PhoneNumber = NewPatient.PhoneNumber;

                if (!string.IsNullOrEmpty(NewPatient.PhysicalAddress))
                    existingPatient.PhysicalAddress = NewPatient.PhysicalAddress;

                if (!string.IsNullOrEmpty(NewPatient.EmailAddress))
                    existingPatient.EmailAddress = NewPatient.EmailAddress;

                try
                {
                    await context.SaveChangesAsync();

                    MessageBox.Show("Patient Changes Saved", "saving changes", MessageBoxButton.OK, MessageBoxImage.Information);
                    (windowObject as Window).Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            PopulatePatients();
        }
        public async Task ShowEditPatientAsync(object windowObject)
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            NewPatient.PatientID = SelectedPatient.PatientID;

            (windowObject as Window).Close();

            var editPatientWindow = new NewPatientWindow();
            editPatientWindow.DataContext = this;
            editPatientWindow.ShowDialog();
        }
        public async Task DeletePatientAsync(object windowObject)
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            var messageBoxResult = MessageBox.Show($"Delete " +
                    $"{SelectedPatient.FirstName} {SelectedPatient.LastName} " +
                    $"from Database", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (messageBoxResult == MessageBoxResult.No)
                return;


            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                var patientToDelete = context.Patients.FirstOrDefault(patient => patient.PatientID == SelectedPatient.PatientID);

                foreach (var medicine in SelectedPatientMedicines)
                {
                    var medicineToDelete = context.Medicines.FirstOrDefault(m => m.MedicineID == medicine.MedicineID);
                    patientToDelete.Medicines.Remove(medicineToDelete);
                    context.Medicines.Remove(medicineToDelete);
                }
                foreach (var treatment in SelectedPatientTreatments)
                {
                    var treatmentToDelete = context.Treatments.FirstOrDefault(t => t.TreatmentID == treatment.TreatmentID);
                    patientToDelete.Treatments.Remove(treatmentToDelete);
                    context.Treatments.Remove(treatmentToDelete);
                }

                context.Patients.Remove(patientToDelete);

                try
                {
                    await context.SaveChangesAsync();

                    MessageBox.Show($"{SelectedPatient.FirstName} {SelectedPatient.LastName} " +
                        $"deleted from database.", "deleted", MessageBoxButton.OK, MessageBoxImage.Information);

                    (windowObject as Window).Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            PopulatePatients();
        }
        public async Task ShowPatientDetailAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            PatientDetailWindow patientDetailWindow = new PatientDetailWindow();
            patientDetailWindow.DataContext = this;

            InitialiseCurrentTreatmentInfoControl();
            InitialiseCurrentMedicineInfoControl();

            patientDetailWindow.ShowDialog();
        }
        public async Task ShowPatientTreatmentDetailAsync()
        {
            var patientTreatmentWindow = new PatientTreatmentWindow();
            patientTreatmentWindow.DataContext = this;

            await Task.Delay(TimeSpan.FromSeconds(.5));

            patientTreatmentWindow.ShowDialog();
        }
        public async Task ShowPatientMedicineDetailAsync()
        {
            var patientMedicineWindow = new PatientMedicineWindow();
            patientMedicineWindow.DataContext = this;

            await Task.Delay(TimeSpan.FromSeconds(.5));

            patientMedicineWindow.ShowDialog();
        }
        public async Task ShowEditTreatmentAsync(object windowObject)
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            var editTreatmentWindow = new NewTreatmentWindow();
            var treatmentsViewModel = new TreatmentsViewModel();
            treatmentsViewModel.NewTreatment.TreatmentID = SelectedTreatment.TreatmentID;

            editTreatmentWindow.DataContext = treatmentsViewModel;

            (windowObject as Window).Close();

            editTreatmentWindow.ShowDialog();

            InitialiseSelectedPatientTreatments();
        }
        public async Task ShowEditMedicineAsync(object windowObject)
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            var editMedicineWindow = new NewMedicineWindow();
            var medicinessViewModel = new MedicinesViewModel();
            medicinessViewModel.NewMedicine.MedicineID = SelectedMedicine.MedicineID;

            editMedicineWindow.DataContext = medicinessViewModel;

            (windowObject as Window).Close();

            editMedicineWindow.ShowDialog();

            InitialiseSelectedPatientMedicines();
        }
        public async Task DeleteTreatmentAsync(object windowObject)
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            var messageBoxResult = MessageBox.Show($"Delete " +
                    $"treatment with diagnosis {SelectedTreatment.Diagnosis}" +
                    $" from Database", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (messageBoxResult == MessageBoxResult.No)
                return;


            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                var treatmentToDelete = context.Treatments.FirstOrDefault(treatment => treatment.TreatmentID == SelectedTreatment.TreatmentID);

                context.Medicines.RemoveRange(treatmentToDelete.Medicines);

                treatmentToDelete.Medicines.Clear();

                context.Treatments.Remove(treatmentToDelete);

                try
                {
                    await context.SaveChangesAsync();

                    MessageBox.Show($"Treatment with diagnosis {SelectedTreatment.Diagnosis} " +
                        $"deleted from database.", "deleted", MessageBoxButton.OK, MessageBoxImage.Information);

                    (windowObject as Window).Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            InitialiseSelectedPatientTreatments();
        }
        public async Task DeleteMedicineAsync(object windowObject)
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            var messageBoxResult = MessageBox.Show($"Delete " +
                    $"{SelectedMedicine.MedicineName}" +
                    $" from Database", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (messageBoxResult == MessageBoxResult.No)
                return;


            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                var medicineToBeDeleted = context.Medicines.FirstOrDefault(medicine => medicine.MedicineID == SelectedMedicine.MedicineID);

                context.Medicines.Remove(medicineToBeDeleted);

                try
                {
                    await context.SaveChangesAsync();

                    MessageBox.Show($"{SelectedMedicine.MedicineName} " +
                        $"deleted from database.", "deleted", MessageBoxButton.OK, MessageBoxImage.Information);

                    (windowObject as Window).Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            InitialiseSelectedPatientMedicines();
            InitialiseSelectedTreatmentMedicines();
        }
        #endregion
    }
}
