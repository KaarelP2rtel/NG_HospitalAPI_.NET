using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISymptomService
    {
        Task<List<SymptomDTO>> GetAllSymptomsAsync();
        Task<SymptomDTO> AddSymptomAsync(SymptomDTO s);
        Task<int> GetSymptomsCountAsync();
    }
}
