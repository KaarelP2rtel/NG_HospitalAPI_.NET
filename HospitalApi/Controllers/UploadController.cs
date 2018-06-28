using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;

namespace HospitalApi.Controllers
{
    [Route("api/upload")]

    public class UploadController : ControllerBase
    {
        private readonly ISymptomService _symptomService;
        private readonly IDiseaseService _diseaseService;

        public UploadController(ISymptomService symptomService, IDiseaseService diseaseService)
        {
            _symptomService = symptomService;
            _diseaseService = diseaseService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile()
        {
            #region Code that needs a better place
            if (Request.Form.Files.Count != 1)
            {
                return BadRequest(new FeedbackDTO("only one file allowed at a time"));
            }
            var file = Request.Form.Files.First();

            var streamReader = new StreamReader(file.OpenReadStream());



            var symptomList = new List<string>();
            while (!streamReader.EndOfStream)
            {
                var strings = (await streamReader.ReadLineAsync()).Split(',').ToList().Skip(1).ToList();
                symptomList.AddRange(strings);
            }
            streamReader.Close();
            symptomList = symptomList.GroupBy(s => s).Select(x => x.First()).ToList();
            var symptomsDictionary = new Dictionary<string, SymptomDTO>();
            foreach (string symptomName in symptomList)
            {
                symptomsDictionary.Add(symptomName, await _symptomService.AddSymptomAsync(new SymptomDTO { Name = symptomName }));
            }



            streamReader = new StreamReader(file.OpenReadStream());
            while (!streamReader.EndOfStream)
            {
                var line = (await streamReader.ReadLineAsync()).Split(',');

                var newDisease = new DiseaseDTO { Name = line.First(), Symptoms = new List<SymptomDTO>() };

                var diseaseSymptoms = line.Skip(1).ToList();
                foreach (var symptom in diseaseSymptoms)
                {
                    SymptomDTO foundSymptom;
                    if (symptomsDictionary.TryGetValue(symptom, out foundSymptom))
                    {
                        newDisease.Symptoms.Add(foundSymptom);
                    }
                }
                await _diseaseService.AddDiseaseAsync(newDisease);

            }
            streamReader.Close();
            #endregion

            return Ok();
        }

    }


}