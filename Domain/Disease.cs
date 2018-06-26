using System;
using System.Collections.Generic;

namespace Domain
{
    public class Disease
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DiseaseSymptom> DiseaseSymptoms { get; set; }
    }
}
