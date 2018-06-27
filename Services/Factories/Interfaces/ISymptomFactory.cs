using Domain;
using Services.DTO;

namespace Services.Factories
{
    public interface ISymptomFactory
    {
        SymptomDTO Transform(Symptom s);
        Symptom Transform(SymptomDTO dto);
        SymptomDTO TransformWithDiseases(Symptom s);
    }
}
