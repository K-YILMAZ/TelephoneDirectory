using Directory.Entities.Concrete.ContactInformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.WebApi.Models
{
    public class ApiModels
    {
        public long uuid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string company { get; set; }
        public List<ContactInformationsEntity> contactInformationsList { get; set; }
    }
}
