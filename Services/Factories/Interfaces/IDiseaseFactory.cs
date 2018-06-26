using Domain;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Factories.Interfaces
{
    public interface IDiseaseFactory
    {
        Disease Transform(DiseaseDTO dto);
        DiseaseDTO Transform(Disease d);
    }
}
