using Microsoft.AspNetCore.Mvc;
using Services.DTO;

namespace HospitalApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return Ok(new FeedbackDTO("Api is up :D"));
        }
    }
}