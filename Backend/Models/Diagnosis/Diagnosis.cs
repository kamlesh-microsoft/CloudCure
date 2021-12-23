using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models.Diagnosis
{
    public class Diagnosis
    {
        public int Id { get; set; }

        //Date and time of the encounter.  
        [Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EncounterDate { get; set; }

        [JsonIgnore]
        public Patient Patient { get; set; }
        public Vitals Vitals { get; set; }
        public Assessment Assessment { get; set; }

        public string DoctorDiagnosis { get; set; }
        public string RecommendedTreatment { get; set; }
        public bool IsFinalized { get; set; }
    }
}