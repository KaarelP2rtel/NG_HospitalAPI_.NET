using DAL;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class IndexController : Controller
    {
        private readonly AppDbContext _context;

        public IndexController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Ok(new FeedbackDTO("Api is up :D"));
        }
        [Route("clear")]
        public async Task<IActionResult> Clear()
        {
            _context.Symptoms.RemoveRange(_context.Symptoms.ToArray());
            await _context.SaveChangesAsync();
            _context.Diseases.RemoveRange(_context.Diseases.ToArray());
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}