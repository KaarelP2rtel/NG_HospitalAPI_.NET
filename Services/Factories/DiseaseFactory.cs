using Domain;
using Services.DTO;
using Services.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Factories
{
    public class DiseaseFactory : IDiseaseFactory
    {
        private readonly ISymptomFactory _symptomFactory;

        public DiseaseFactory(ISymptomFactory symptomFactory)
        {
            _symptomFactory = symptomFactory;
        }

        public Disease Transform(DiseaseDTO dto)
        {
            return new Disease
            {
                Id = dto.Id ?? 0,
                Name = dto.Name,
                DiseaseSymptoms = dto.Symptoms.Select(s => new DiseaseSymptom { DiseaseId=dto.Id??0,SymptomId=s.Id??0 }).ToList()
            };
        }

        public DiseaseDTO Transform(Disease d)
        {
            return new DiseaseDTO
            {
                Id = d.Id,
                Name = d.Name,
                Symptoms = d.DiseaseSymptoms.Select(ds => _symptomFactory.Transform(ds.Symptom)).ToList()
            };
        }
    }
}
