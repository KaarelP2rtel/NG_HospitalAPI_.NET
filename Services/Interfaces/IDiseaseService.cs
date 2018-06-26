using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDiseaseService
    {
        Task<List<DiseaseDTO>> GetallDiseasesAsync();
        Task<DiseaseDTO> AddDiseaseAsync(DiseaseDTO disease);
    }
}
