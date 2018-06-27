using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;

namespace HospitalApi.Controllers
{
    [Route("api/diseases")]
    [ApiController]
    public class DiseasesController : Controller
    {
        private readonly IDiseaseService _diseaseService;

        public DiseasesController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _diseaseService.GetallDiseasesAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DiseaseDTO disease)
        {
            if (disease?.Id != null) return BadRequest(new FeedbackDTO("ID can not be set when posting"));
            
            if (disease?.Symptoms == null || disease.Symptoms.Count < 1) return BadRequest(new FeedbackDTO("Disease must have symptoms"));
            if (!disease.Symptoms.TrueForAll(s => s.Id!=null)) return BadRequest(new FeedbackDTO("Symptoms must have IDs"));
           
            

            return Ok(await _diseaseService.AddDiseaseAsync(disease));
        }
        [HttpGet]
        [Route("greatest")]
        public async Task<IActionResult> GetGreatest() => Ok(await _diseaseService.GetGreatestDiseasesAsync());

        [HttpPost]
        [Route("find")]
        public async Task<IActionResult> Find([FromBody] List<SymptomDTO> symptoms)
        {
            if (!symptoms.TrueForAll(s => s.Id != null)) return BadRequest(new FeedbackDTO("Id must be set when posting"));
            return Ok(await _diseaseService.FindPossibleDiseases(symptoms));
        }
    }
}