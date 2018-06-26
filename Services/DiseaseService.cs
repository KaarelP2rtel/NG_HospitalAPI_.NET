using DAL.Interfaces;
using Services.DTO;
using Services.Factories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _diseaseRepository;
        private readonly IDiseaseFactory _diseaseFactory;

        public DiseaseService(IDiseaseRepository diseaseRepository, IDiseaseFactory diseaseFactory)
        {
            _diseaseRepository = diseaseRepository;
            _diseaseFactory = diseaseFactory;
        }

        public async Task<DiseaseDTO> AddDiseaseAsync(DiseaseDTO disease)
        {
            var d = _diseaseFactory.Transform(disease);
            await _diseaseRepository.AddAsync(d);
            return _diseaseFactory.Transform( await _diseaseRepository.FindWithSymptomsAsync(d.Id));
        }

        public async Task<List<DiseaseDTO>> GetallDiseasesAsync()
        {
            return (await _diseaseRepository.AllAsync()).Select(d => _diseaseFactory.Transform(d)).ToList();
            
        }
    }
}
