using Directory.Bussiness.Abstract.ContactInformations;
using Directory.Bussiness.Abstract.Persons;
using Directory.Bussiness.Concrete.ContactInformations;
using Directory.Bussiness.Concrete.Persons;
using Directory.DataAccess.Concrete.ContactInformations;
using Directory.DataAccess.Concrete.Persons;
using Directory.Entities.Concrete.ContactInformations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        [HttpGet]
        [Route("GetAll")]
        public List<ContactInformationsEntity> GetAll()
        {
            try
            {
                return IntanceContactInformations().GetAll();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        // İletişim bilgisi Oluşturma
        [HttpPost]
        [Route("Add")]
        public string Add(Guid Personuuid,  ContactInformationEnum InformationType, string InformationContent)
        {
            try
            {
                IntanceContactInformations().Add(new ContactInformationsEntity
                {
                    informationContent=InformationContent,
                    informationType=InformationType.ToString(),
                    personuuid=Personuuid
                });
                return "successful";
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        // İletişim bilgisi Kaldırma
        [HttpDelete]
        [Route("Delete/{UUID}")]
        public string Delete(Guid UUID)
        {
            try
            {
                IntanceContactInformations().Delete(new ContactInformationsEntity { uuid = UUID });
                return "successful";
            }
            catch (System.Exception ex)
            {
                return "An error occurred. Error : " + ex.Message;
            }
        }
    }
}
