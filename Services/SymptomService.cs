using DAL.Interfaces;
using Services.DTO;
using Services.Factories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SymptomService : ISymptomService
    {
        private readonly ISymptomRepository _symptomRepository;
        private readonly ISymptomFactory _symptomFactory;

        public SymptomService(ISymptomRepository symptomRepository, ISymptomFactory symptomFactory)
        {
            _symptomRepository = symptomRepository;
            _symptomFactory = symptomFactory;
        }

        public async Task<SymptomDTO> AddSymptomAsync(SymptomDTO s)
        {
            var symptom = _symptomFactory.Transform(s);
            await _symptomRepository.AddAsync(symptom);
            return _symptomFactory.Transform(symptom);
        }

        public async Task<List<SymptomDTO>> GetAllSymptomsAsync()
        {
            return (await _symptomRepository.AllAsync()).Select(s => _symptomFactory.Transform(s)).ToList();
        }
    }
}
