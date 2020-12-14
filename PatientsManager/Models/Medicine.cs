//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatientsManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medicine
    {
        public int MedicineID { get; set; }
        public int TreatmentID { get; set; }
        public int PatientID { get; set; }
        public string MedicineName { get; set; }
        public string MedicineType { get; set; }
        public Nullable<int> DosageDays { get; set; }
        public Nullable<int> TimesPerDay { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}