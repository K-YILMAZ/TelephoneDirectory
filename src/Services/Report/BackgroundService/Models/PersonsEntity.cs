using System;
using System.ComponentModel.DataAnnotations;

namespace ReportBackgroundService.Models
{
    public class PersonsEntity {
        public Guid uuid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string company { get; set; }
    }
}
