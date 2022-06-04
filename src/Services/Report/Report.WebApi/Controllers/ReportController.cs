using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult>  GetAllReport()
        {
            ///return new Task<ActionResult>();;
            return Ok(new { id = "" });
        }
    }
}
