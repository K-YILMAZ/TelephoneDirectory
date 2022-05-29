using Directory.Bussiness.Abstract.ContactInformations;
using Directory.Bussiness.Abstract.Persons;
using Directory.Bussiness.Concrete.ContactInformations;
using Directory.Bussiness.Concrete.Persons;
using Directory.DataAccess.Concrete.ContactInformations;
using Directory.DataAccess.Concrete.Persons;
using Directory.Entities.Concrete.ContactInformations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ContactInformationController : ControllerBase
    {
        private IPersonsService _personsService;
        private IContactInformationsService _contactInformationsService;

        private IPersonsService IntancePerson()
        {
            return _personsService ?? new PersonsManager(new PersonDataAccess());
        }
        private IContactInformationsService IntanceContactInformations()
        {
            return _contactInformationsService ?? new ContactInformationsManager(new ContactInformationsDataAccess());
        }


        [HttpPost]
        public string AddContactInformation(ContactInformationsEntity entity)
        {
            try
            {
                entity.UUID = Guid.NewGuid();
                IntanceContactInformations().Add(entity);
                return "successful";
            }
            catch (System.Exception ex)
            {
                return "An error occurred. Error : " + ex.Message;
            }
        }
        [HttpDelete]
        public string ContactInformationDelete(Guid UUID)
        {
            try
            {
                IntanceContactInformations().Delete(new ContactInformationsEntity { UUID = UUID });
                return "successful";
            }
            catch (System.Exception ex)
            {
                return "An error occurred. Error : " + ex.Message;
            }
        }
    }
}
