using DAL.Interfaces;
using Domain;
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
            return _diseaseFactory.Transform(await _diseaseRepository.FindWithSymptomsAsync(d.Id));
        }

        public async Task<List<DiseaseDTO>> FindPossibleDiseases(List<SymptomDTO> symptoms)
        {
            #region Code that needs refactoring
            var allDiseases = (await GetallDiseasesAsync());
            var findResults = new List<FindResult>();

            foreach (var disease in allDiseases)
            {
                var numberOfPresentSymptoms = 0;

                foreach (var symptom in symptoms)
                {
                    if (disease.Symptoms.Select(s => s.Id).Contains(symptom.Id))
                    {
                        numberOfPresentSymptoms++;
                    }
                    else
                    {
                        numberOfPresentSymptoms = 0;
                        break;
                    }

                }

                findResults.Add(new FindResult
                {
                    Disease = disease,
                    Ratio = (decimal)numberOfPresentSymptoms / disease.Symptoms.Count

                });
            }

            return findResults
                .Where(fr => fr.Ratio > 0)
                .OrderByDescending(fr => fr.Ratio)
                .Select(fr => fr.Disease)
                .ToList();
            #endregion //TODO: Refactor
        }

        public async Task<List<DiseaseDTO>> GetallDiseasesAsync()
        {
            return (await _diseaseRepository.AllAsync()).Select(d => _diseaseFactory.Transform(d)).ToList();

        }

        public async Task<List<DiseaseDTO>> GetGreatestDiseasesAsync()
        {
            return (await _diseaseRepository.GreatestDiseasesAsync()).Select(d => _diseaseFactory.Transform(d)).ToList();
        }

        private class FindResult
        {
            public DiseaseDTO Disease { get; set; }
            public decimal Ratio { get; set; }
        }
    }
}
