using Microsoft.AspNetCore.Mvc;
using Report.WebApi.Messages;
using Report.WebApi.Models;
using System;
using System.Threading.Tasks;

namespace Report.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {



        [HttpGet("GetAllReport")]
        public async Task<ReportMessageCommand> GetAllReport()
        {
            //Kuyruk tanımlama işlemi gerçekleştirdim. Adı : directory-report-service olarak tanımladım.
            ReportMessageCommand reportMessage = new ReportMessageCommand {
                reportStatus = reportStatus.Preparing,
                requestDate = DateTime.Now,
                uuid = Guid.NewGuid()
            };
            Message.publish(reportMessage);
            return reportMessage;
        }
    }
}
