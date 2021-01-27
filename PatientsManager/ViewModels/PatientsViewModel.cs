using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.IO;
using PatientsManager.Models;
using PatientsManager.Commands;
using PatientsManager.Views;
using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;

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
	    private ObservableCollection<Medicine> selectedTreatmentMedicines = new ObservableCollection<Medicine>();
	    private bool inPatientDetails = true;	

        private RelayCommandParamAwait saveNewPatientCommand;
        private RelayCommandAwait showPatientDetailCommand;
        private RelayCommandAwait showPatientTreatmentDetailCommand;
        private RelayCommandAwait showPatientMedicineDetailCommand;
	    private RelayCommandAwait showTreatmentMedicineDetailCommand;
        private RelayCommandParamAwait showEditPatientWindowCommand;
        private RelayCommandParamAwait deleteSelectedPatientCommand;
        private RelayCommandParamAwait deleteSelectedTreatmentCommand;
        private RelayCommandParamAwait deleteSelectedMedicineCommand;
        private RelayCommandParamAwait showEditTreatmentWindowCommand;
        private RelayCommandParamAwait showEditMedicineWindowCommand;
        private RelayCommand importPatientsCommand;
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
        public ObservableCollection<Medicine> SelectedTreatmentMedicines
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
            get
            {
                return inPatientDetails == true ? SelectedPatientMedicines[SelectedMedicineIndex] : SelectedTreatmentMedicines[SelectedMedicineIndex];
            }
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
	    public RelayCommandAwait ShowTreatmentMedicineDetailCommand
        {
            get { return showTreatmentMedicineDetailCommand; }
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
        public RelayCommand ImportPatientsCommand
        {
            get { return importPatientsCommand; }
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
	        showTreatmentMedicineDetailCommand = new RelayCommandAwait(ShowTreatmentMedicineDetailAsync);					
            showEditPatientWindowCommand = new RelayCommandParamAwait(ShowEditPatientAsync);
            deleteSelectedPatientCommand = new RelayCommandParamAwait(DeletePatientAsync);
            showEditTreatmentWindowCommand = new RelayCommandParamAwait(ShowEditTreatmentAsync);
            deleteSelectedTreatmentCommand = new RelayCommandParamAwait(DeleteTreatmentAsync);
            showEditMedicineWindowCommand = new RelayCommandParamAwait(ShowEditMedicineAsync);
            deleteSelectedMedicineCommand = new RelayCommandParamAwait(DeleteMedicineAsync);
            importPatientsCommand = new RelayCommand(ImportPatients);
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
	    inPatientDetails = true;
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
	    public async Task ShowTreatmentMedicineDetailAsync()
        {
            inPatientDetails = false;
            var patientMedicineWindow = new PatientMedicineWindow();
            patientMedicineWindow.DataContext = this;

            await Task.Delay(TimeSpan.FromSeconds(.5));

            patientMedicineWindow.ShowDialog();
        }

        public void SavePatientsToCSV(string fileName, List<Patient> patients)
        {
            var titles = "FirstName, LastName, DateOfBirth, MaritalStatus, PhoneNumber, EmailAddress, PhysicalAddress";
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            using (var streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(titles);

                foreach (var patient in patients)
                {
                    streamWriter.WriteLine($"{patient.FirstName}, {patient.LastName}, " +
                        $"{((DateTime)patient.DateOfBirth).ToShortDateString()}, {patient.MaritalStatus}, {patient.PhoneNumber}, " +
                        $"{patient.EmailAddress}, {patient.PhysicalAddress}");
                }
            }
        }
        public void ExportPatients(List<Patient> patients)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Comma Separated Files(*.csv)|*.csv"
            };

            var dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == true)
            {
                SavePatientsToCSV(saveFileDialog.FileName, patients);
                MessageBox.Show($"{saveFileDialog.FileName} created");
            }
        }
        public void ImportPatients()
        {
            string fileName = "";

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Comma Separated File(*.csv)|*.csv"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                fileName = openFileDialog.FileName;

                var patients = GetPatientsFromCSV(fileName);
                SaveImportedPatients(patients);

                MessageBox.Show($"imported {patients.Count} patient(s)");
                PopulatePatients();
            }

        }
        public List<Patient> GetPatientsFromCSV(string fileName)
        {
            List<Patient> patients = new List<Patient>();

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream))
            {
                var currentLine = streamReader.ReadLine();
                while (currentLine != null)
                {
                    currentLine = streamReader.ReadLine();

                    if (currentLine != null)
                    {
                        var patient = StringLineToPatient(currentLine);
                        patients.Add(patient);
                    }
                }
            }

            return patients;
        }
        public Patient StringLineToPatient(string line)
        {
            char[] separators = new[] { ',' };
            var subStrings = line.Split(separators);
            
            Patient patient = new Patient()
            {
                FirstName = subStrings[0].Trim(),
                LastName = subStrings[1].Trim(),
                DateOfBirth = DateTime.Parse(subStrings[2]),
                MaritalStatus = subStrings[3].Trim(),
                PhoneNumber = subStrings[4].Trim(),
                EmailAddress = subStrings[5].Trim(),
                PhysicalAddress = subStrings[6].Trim()
            };

            return patient;
        }
        public void SaveImportedPatients(List<Patient> patients)
        {
            using (var context = new HospitalDBEntities())
            {
                foreach (var patient in patients)
                {
                    context.Patients.Add(new Patient()
                    {
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        MaritalStatus = patient.MaritalStatus,
                        EmailAddress = patient.EmailAddress,
                        DateOfBirth = patient.DateOfBirth,
                        PhoneNumber = patient.PhoneNumber,
                        PhysicalAddress = patient.PhysicalAddress
                    });
                }

                context.SaveChanges();
            }
        }

        public void GenerateReports(List<Patient> patients)
        {
            using (var document = new PdfDocument())
            {
                var fileName = GetReportSavingFile();

                PdfFont mainHeadingFont = new PdfStandardFont(PdfFontFamily.Helvetica, 18, PdfFontStyle.Bold);
                PdfFont alternateHeadingFont = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
                PdfFont smallHeadingFont = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Italic);
                PdfFont normalFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Regular);

                float leftPosX = 50f;
                float rightPosX = 400f;
                float startingPosY = 50f;
                float posYIncrement = 30f;

                var defaultBrush = PdfBrushes.Black;

                foreach (var patient in patients)
                {
                    float currentPosY = 0f;

                    PdfPage page = document.Pages.Add();
                    PdfGraphics graphics = page.Graphics;

                    graphics.DrawString($"Patient {patient.FirstName} {patient.LastName} Report", mainHeadingFont, defaultBrush, new PointF(graphics.ClientSize.Width / 2 - 100, currentPosY));

                    currentPosY += startingPosY;

                    //patient personal details
                    graphics.DrawString("First Name", normalFont, defaultBrush, new PointF(leftPosX, currentPosY));
                    graphics.DrawString(patient.FirstName, normalFont, defaultBrush, new PointF(rightPosX, currentPosY));

                    currentPosY += posYIncrement;

                    graphics.DrawString("Last Name", normalFont, defaultBrush, new PointF(leftPosX, currentPosY));
                    graphics.DrawString(patient.LastName, normalFont, defaultBrush, new PointF(rightPosX, currentPosY));

                    currentPosY += posYIncrement;

                    graphics.DrawString("Date of Birth", normalFont, defaultBrush, new PointF(leftPosX, currentPosY));
                    graphics.DrawString(((DateTime)patient.DateOfBirth).ToShortDateString(), normalFont, defaultBrush, new PointF(rightPosX, currentPosY));

                    currentPosY += posYIncrement;

                    graphics.DrawString("Marital Status", normalFont, defaultBrush, new PointF(leftPosX, currentPosY));
                    graphics.DrawString(patient.MaritalStatus, normalFont, defaultBrush, new PointF(rightPosX, currentPosY));

                    currentPosY += posYIncrement;

                    graphics.DrawString("Phone Number", normalFont, defaultBrush, new PointF(leftPosX, currentPosY));
                    graphics.DrawString(patient.PhoneNumber, normalFont, defaultBrush, new PointF(rightPosX, currentPosY));

                    currentPosY += posYIncrement;

                    graphics.DrawString("Email Address", normalFont, defaultBrush, new PointF(leftPosX, currentPosY));
                    graphics.DrawString(patient.EmailAddress, normalFont, defaultBrush, new PointF(rightPosX, currentPosY));

                    currentPosY += posYIncrement;

                    graphics.DrawString("Physical Address", normalFont, defaultBrush, new PointF(leftPosX, currentPosY));
                    graphics.DrawString(patient.PhysicalAddress, normalFont, defaultBrush, new PointF(rightPosX, currentPosY));

                    currentPosY += posYIncrement + 10;

                    //patient treatment details
                    graphics.DrawString("Treatment Details", mainHeadingFont, defaultBrush, new PointF(graphics.ClientSize.Width / 2 - 100, currentPosY));

                    Dictionary<Treatment, List<Medicine>> treatmentMeds = new Dictionary<Treatment, List<Medicine>>();

                    using (var context = new HospitalDBEntities())
                    {
                        foreach (var treatment in context.Patients.First(p => p.PatientID == patient.PatientID).Treatments)
                        {
                            treatmentMeds.Add(treatment, treatment.Medicines.ToList());
                        }
                    }

                    currentPosY += posYIncrement;

                    foreach (var treatment in treatmentMeds.Keys)
                    {
                        graphics.DrawString($"diagnosis {treatment.Diagnosis}", alternateHeadingFont, defaultBrush, new PointF(leftPosX, currentPosY));

                        currentPosY += posYIncrement;

                        graphics.DrawString("symptoms", smallHeadingFont, defaultBrush, new PointF(leftPosX, currentPosY));

                        currentPosY += posYIncrement;

                        graphics.DrawString(treatment.Symptoms, normalFont, defaultBrush, new PointF(leftPosX, currentPosY));

                        currentPosY += posYIncrement;

                        graphics.DrawString("medicines", smallHeadingFont, defaultBrush, new PointF(leftPosX, currentPosY));

                        currentPosY += posYIncrement;

                        foreach (var medicine in treatmentMeds[treatment])
                        {
                            graphics.DrawString(medicine.MedicineName, normalFont, defaultBrush, new PointF(leftPosX, currentPosY));
                            currentPosY += posYIncrement;
                        }
                    }
                }

                if (fileName != "")
                    document.Save(fileName);
            }
        }
        public string GetReportSavingFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files(*.pdf)|*.pdf";

            if (saveFileDialog.ShowDialog() == true)
                return saveFileDialog.FileName;
            else
                return "";
        }
        #endregion
    }
}
