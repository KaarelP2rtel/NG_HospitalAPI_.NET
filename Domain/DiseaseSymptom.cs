using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class DiseaseSymptom
    {
        public int Id { get; set; }
        public int SymptomId { get; set; }
        public int DiseaseId { get; set; }
        public Symptom Symptom { get; set; }
        public Disease Disease { get; set; }

    }
}
