using PatientsManager.Commands;
using PatientsManager.Models;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;

namespace PatientsManager.ViewModels
{
    public class MedicinesViewModel : BaseViewModel
    {
        #region fields
        private RelayCommandParamAwait saveMedicineCommand;
        #endregion

        #region properties
        public Medicine NewMedicine { get; set; } = new Medicine();

        public RelayCommandParamAwait SaveMedicineCommand
        {
            get { return saveMedicineCommand; }
        }
        #endregion

        #region methods
        public MedicinesViewModel()
        {
            InitialiseCommands();
        }

        public override void InitialiseCommands()
        {
            base.InitialiseCommands();

            saveMedicineCommand = new RelayCommandParamAwait(SaveMedicineAsync);
        }

        private async Task SaveMedicineAsync(object windowObject)
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            if (NewMedicine.MedicineID != 0)
            {
                await EditMedicineAsync(windowObject);

                return;
            }

            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                var patient = context.Patients.FirstOrDefault(p => p.PatientID == NewMedicine.PatientID);
                if (patient == null)
                {
                    MessageBox.Show($"Sorry, Patient with ID {NewMedicine.PatientID} doesn't exist!!",
                        "incorrect patient ID", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }
                
                var treatment = context.Treatments.FirstOrDefault(t => t.TreatmentID == NewMedicine.TreatmentID);
                if (treatment == null)
                {
                    MessageBox.Show($"Sorry, Treatment with ID {NewMedicine.TreatmentID} doesn't exist!!",
                        "incorrect patient ID", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }

                context.Medicines.Add(NewMedicine);

                try
                {
                    await context.SaveChangesAsync();

                    MessageBox.Show($"Medicine successfully added to {NewMedicine.Patient.FirstName} {NewMedicine.Patient.LastName}" +
                        $" to treat {NewMedicine.Treatment.Diagnosis}",
                        "success", MessageBoxButton.OK, MessageBoxImage.Information);

                    (windowObject as Window).Close();
                    //access AddNewPatient from MainViewModel, DataContext of MainWindow
                    (App.Current.MainWindow.DataContext as MainViewModel).AddNewMedicine();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            NewMedicine.MedicineID = 0;
        }
        private async Task EditMedicineAsync(object windowObject)
        {
            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                var existingMedicine = context.Medicines.FirstOrDefault(medicine => medicine.MedicineID == NewMedicine.MedicineID);

                if (NewMedicine.PatientID != 0)
                    existingMedicine.PatientID = NewMedicine.PatientID;
                
                if (NewMedicine.TreatmentID != 0)
                    existingMedicine.TreatmentID = NewMedicine.TreatmentID;

                if (!string.IsNullOrEmpty(NewMedicine.MedicineType))
                    existingMedicine.MedicineType = NewMedicine.MedicineType;

                if (!string.IsNullOrEmpty(NewMedicine.MedicineName))
                    existingMedicine.MedicineName = NewMedicine.MedicineName;

                if (NewMedicine.DosageDays != null)
                    existingMedicine.DosageDays = NewMedicine.DosageDays;

                if (NewMedicine.TimesPerDay != null)
                    existingMedicine.TimesPerDay = NewMedicine.TimesPerDay;

                try
                {
                    await context.SaveChangesAsync();

                    MessageBox.Show("Medicine Changes Saved", "saving changes", MessageBoxButton.OK, MessageBoxImage.Information);
                    (windowObject as Window).Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion
    }
}
