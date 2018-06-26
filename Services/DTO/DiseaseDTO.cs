using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class DiseaseDTO
    {
        public int? Id { get; set; }
        public String Name { get; set; }
        public List<SymptomDTO> Symptoms { get; set; }


    }
}
