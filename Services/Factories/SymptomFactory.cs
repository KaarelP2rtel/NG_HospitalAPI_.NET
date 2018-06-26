using Domain;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Factories
{
    public class SymptomFactory : ISymptomFactory
    {
        
        public SymptomDTO Transform(Symptom s)
        {
            return new SymptomDTO
            {
                Id=s.Id,
                Name=s.Name,
            };
        }

        public Symptom Transform(SymptomDTO dto)
        {
            return new Symptom
            {
                Id=dto.Id ?? 0,
                Name=dto.Name
            };
        }
    }
}
