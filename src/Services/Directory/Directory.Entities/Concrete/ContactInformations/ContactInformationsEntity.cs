using Directory.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Directory.Entities.Concrete.ContactInformations
{
    public class ContactInformationsEntity : IEntity
    {
        [Key]
        public Guid UUID { get; set; }
        public int TelephoneNumber { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(300)]
        public string Location { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        public Guid PersonUUID { get; set; }

    }
}
