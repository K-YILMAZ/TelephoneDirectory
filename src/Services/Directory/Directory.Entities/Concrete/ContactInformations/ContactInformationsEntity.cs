using Directory.Entities.Abstract;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Directory.Entities.Concrete.ContactInformations
{
    public class ContactInformationsEntity : IEntity
    {
        [Key]
        public Guid uuid { get; set; }
        [StringLength(20)]
        public string informationType { get; set; }
        [StringLength(300)]
        public string informationContent { get; set; }
        public Guid personuuid { get; set; }
    }
    public enum ContactInformationEnum
    {
        [Description("TelephoneNumber")]
        TelephoneNumber=0,
        [Description("Email")]
        Email=1,
        [Description("Location")]
        Location=2
    }
}
