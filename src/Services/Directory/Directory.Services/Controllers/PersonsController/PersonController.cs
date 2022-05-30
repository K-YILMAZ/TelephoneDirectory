using Directory.Bussiness.Abstract.ContactInformations;
using Directory.Bussiness.Abstract.Persons;
using Directory.Bussiness.Concrete.ContactInformations;
using Directory.Bussiness.Concrete.Persons;
using Directory.DataAccess.Concrete.ContactInformations;
using Directory.DataAccess.Concrete.Persons;
using Directory.Entities.Concrete.ContactInformations;
using Directory.Entities.Concrete.Persons;
using Directory.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Directory.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
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
        // Kişileri Listeleme
        [HttpGet]
        public List<PersonsEntity> GetAllPersons()
        {
            return IntancePerson().GetAll();
        }
        // Kişileri Detaylı Listeleme
        [HttpGet]
        public List<ApiModels> GetAllDetailPersons()
        {
            var persons = IntancePerson().GetAll();
            var contactInformations = IntanceContactInformations().GetAll();
            var ApiModels = new List<ApiModels>();
            persons.ForEach(person =>
          {
              var contactInformation = contactInformations.Where(p => p.PersonUUID == person.UUID).ToList().FirstOrDefault();
              ApiModels.Add(new ApiModels
              {
                  FirstName = person.FirstName,
                  LastName = person.LastName,
                  Company = person.Company,
                  TelephoneNumber = contactInformation.TelephoneNumber,
                  Email = contactInformation.Email,
                  Location = contactInformation.Location,
                  Description = contactInformation.Description
              });
          });
            return ApiModels;

        }
        // Kişi Oluşturma
        [HttpPost]
        public string AddPerson(ApiModels entity)
        {
            try
            {
                Guid Personuuid = Guid.NewGuid();
                Guid ContactInformationuuid = Guid.NewGuid();

                IntancePerson().Add(new PersonsEntity
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Company = entity.Company,
                    UUID = Personuuid
                });
                return "successful";
            }
            catch (System.Exception ex)
            {
                return "An error occurred. Error : " + ex.Message;
            }
        }

        // Kişi Kaldırma
        [HttpDelete]
        public string PersonDelete(Guid UUID)
        {
            try
            {
                var person = IntancePerson().GetByUUID(UUID);
                var IntanceContactInformation = IntanceContactInformations().GetByPersonUUId(UUID);
                IntancePerson().Delete(new PersonsEntity { UUID = UUID });
                IntanceContactInformations().Delete(new ContactInformationsEntity { UUID = IntanceContactInformation.UUID });
                return "successful";
            }
            catch (System.Exception ex)
            {
                return "An error occurred. Error : " + ex.Message;
            }
        }
    }
}
