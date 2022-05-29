using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.WebApi.Models
{
    public class ApiModels
    {
        public long UUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public int TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
