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
    [Route("api/symptoms")]
    [ApiController]
    public class SymptomsController : Controller
    {
        private readonly ISymptomService _symptomService;
     

        public SymptomsController(ISymptomService symptomService)
        {
            _symptomService = symptomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _symptomService.GetAllSymptomsAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SymptomDTO symptom)
        {
            
            if (symptom?.Id != null) return BadRequest(new FeedbackDTO("Id Can not be set when posting"));
            if (symptom.Name == null) return BadRequest(new FeedbackDTO("Symptom must have a name"));
            
            return Ok(await _symptomService.AddSymptomAsync(symptom));
        }
        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> GetCount() => Ok(new { Count= await _symptomService.GetSymptomsCountAsync() });
        [HttpGet]
        [Route("withdiseases")]
        public async Task<IActionResult> GetWithDiseases() => Ok( await _symptomService.GetSymptomsWithDiseasesAsync());
        [HttpGet]
        [Route("greatest")]
        public async Task<IActionResult> GetGreatestSymptoms() => Ok(await _symptomService.GetGreatestSymptomsAsync());
    }
}