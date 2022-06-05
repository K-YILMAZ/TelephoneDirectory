using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.WebApi.Models
{
    public class ReportMessageCommand
    {
        public Guid uuid { get; set; }
        public DateTime requestDate { get; set; }
        public reportStatus reportStatus { get; set; }
    }
    public enum reportStatus
    {
        Preparing=0,

        Completed=1
    }
}
