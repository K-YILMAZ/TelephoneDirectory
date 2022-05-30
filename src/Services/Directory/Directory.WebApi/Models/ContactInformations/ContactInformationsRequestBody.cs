using Directory.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Directory.Entities.Concrete.ContactInformations
{
    public class ContactInformationsRequestBody
    {
        public int TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public Guid PersonUUID { get; set; }

    }
}
