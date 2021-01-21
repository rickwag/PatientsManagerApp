using PatientsManager.Models;
using PatientsManager.Commands;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;

namespace PatientsManager.ViewModels
{
    public class TreatmentsViewModel : BaseViewModel
    {
        #region fields
        private RelayCommandParamAwait saveNewTreatmentCommand;
        #endregion

        #region properties
        public Treatment NewTreatment { get; set; } = new Treatment();
        public List<Patient> ExistingPatients
        {
            get { return GetPatients(); }
        }

        public RelayCommandParamAwait SaveNewTreatmentCommand
        {
            get { return saveNewTreatmentCommand; }
        }
        #endregion

        #region methods
        public TreatmentsViewModel()
        {
            InitialiseCommands();
        }

        public override void InitialiseCommands()
        {
            base.InitialiseCommands();
            
            saveNewTreatmentCommand = new RelayCommandParamAwait(SaveNewTreatmentAsync);
        }

        private async Task SaveNewTreatmentAsync(object windowObject)
        {
            await Task.Delay(TimeSpan.FromSeconds(.5));

            if (NewTreatment.TreatmentID != 0)
            {
                await EditTreatmentAsync(windowObject);
                return;
            }

            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                var patient = context.Patients.FirstOrDefault(p => p.PatientID == NewTreatment.PatientID);
                if (patient == null)
                {
                    MessageBox.Show($"Sorry, Patient with ID {NewTreatment.PatientID} doesn't exist!!",
                        "incorrect patient ID", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }

                NewTreatment.TreatmentDate = DateTime.Today;
                context.Treatments.Add(NewTreatment);

                try
                {
                    await context.SaveChangesAsync();

                    MessageBox.Show($"Treatment successfully added to {NewTreatment.Patient.FirstName} {NewTreatment.Patient.LastName}",
                        "success", MessageBoxButton.OK, MessageBoxImage.Information);

                    (windowObject as Window).Close();
                    //access AddNewPatient from MainViewModel, DataContext of MainWindow
                    (App.Current.MainWindow.DataContext as MainViewModel).AddNewTreatment();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            NewTreatment.TreatmentID = 0;
        }
        private async Task EditTreatmentAsync(object windowObject)
        {
            using (HospitalDBEntities context = new HospitalDBEntities())
            {
                var existingTreatment = context.Treatments.FirstOrDefault(treatment => treatment.TreatmentID == NewTreatment.TreatmentID);

                if (NewTreatment.PatientID != 0)
                    existingTreatment.PatientID = NewTreatment.PatientID;

                if (!string.IsNullOrEmpty(NewTreatment.Symptoms))
                    existingTreatment.Symptoms = NewTreatment.Symptoms;

                if (!string.IsNullOrEmpty(NewTreatment.Diagnosis))
                    existingTreatment.Diagnosis = NewTreatment.Diagnosis;

                try
                {
                    await context.SaveChangesAsync();

                    MessageBox.Show("Treatment Changes Saved", "saving changes", MessageBoxButton.OK, MessageBoxImage.Information);
                    (windowObject as Window).Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public List<Patient> GetPatients()
        {
            List<Patient> patients;

            using (var context = new HospitalDBEntities())
            {
                patients = context.Patients.ToList();
            }

            return patients;
        }
        #endregion
    }
}
