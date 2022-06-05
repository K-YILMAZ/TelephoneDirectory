using System;
using System.ComponentModel;

namespace ReportBackgroundService.Models
{
    public class ContactInformationsEntity
    {
        public Guid uuid { get; set; }
        public string informationType { get; set; }
        public string informationContent { get; set; }
        public Guid personuuid { get; set; }
    }

    public enum ContactInformationEnum
    {
        [Description("TelephoneNumber")]
        TelephoneNumber = 0,
        [Description("Email")]
        Email = 1,
        [Description("Location")]
        Location = 2
    }
}
