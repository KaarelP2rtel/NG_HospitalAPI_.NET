using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    [Route("api/upload")]
    
    public class UploadController : ControllerBase
    {

        [HttpPost, ActionName("multipart/form-data")]
        public async Task<IActionResult> Post()
        {

            return  Ok();
        }
    }
}