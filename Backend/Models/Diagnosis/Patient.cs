using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models.Diagnosis
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        public User UserProfile { get; set; }

        public List<Condition> Conditions { get; set; }

        public List<Allergy> Allergies { get; set; }

        public List<Surgery> Surgeries { get; set; }

        public List<Medication> CurrentMedications { get; set; }

        public List<Diagnosis> Diagnoses { get; set; }

        public EmployeeInformation Doctor { get; set; }
    }
}
