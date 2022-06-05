using System;

namespace ReportBackgroundService.Models
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
