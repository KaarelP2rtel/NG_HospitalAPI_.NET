using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISymptomRepository
    {
        Task<List<Symptom>> AllAsync();
        Task<Symptom> AddAsync(Symptom symptom);
        Task<int> SymptomsCount();
    }
}
