using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiseaseRepository
    {
        Task<List<Disease>> AllAsync();
        Task<Disease> AddAsync(Disease d);
        Task<Disease> FindWithSymptomsAsync(int id);
    }
}
