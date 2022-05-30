

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
        [Route("GetAll")]
        public List<PersonsEntity> GetAll()
        {
            return IntancePerson().GetAll();
        }
        // Kişileri Detaylı Listeleme
        [HttpGet]
        [Route("GetAllDetail/")]
        public List<ApiModels> GetAllDetail()
        {
            try
            {
                var persons = IntancePerson().GetAll();
                var contactInformations = IntanceContactInformations().GetAll();
                var ApiModels = new List<ApiModels>();

                persons.ForEach(person =>
                {
                    var contactInformationLoad = contactInformations.Where(p => p.PersonUUID == person.UUID).ToList();
                    ContactInformationsEntity ContactInformation = new ContactInformationsEntity();
                    if (contactInformations.Count > 0)
                    {
                        ContactInformation = contactInformationLoad.FirstOrDefault();
                    }

                    ApiModels.Add(new ApiModels
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Company = person.Company,
                        TelephoneNumber = ContactInformation.TelephoneNumber,
                        Email = ContactInformation.Email,
                        Location = ContactInformation.Location,
                        Description = ContactInformation.Description
                    });
                });
                return ApiModels;
            }
            catch (Exception ex)
            {

                throw (ex);
            }


        }
        [HttpGet]
        [Route("GetDetail/{uuid}")]
        public List<ApiModels> GetDetail(Guid uuid)
        {
            try
            {
                var person = IntancePerson().GetByUUID(uuid) ?? new PersonsEntity();
                var contactInformation = IntanceContactInformations().GetByPersonUUId(uuid) ?? new ContactInformationsEntity();
                var ApiModels = new List<ApiModels>();

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
                return ApiModels;
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }
        // Kişi Oluşturma
        [HttpPost]
        [Route("Add")]
        public string Add([FromBody] PersonsRequestBody personsRequestBody)
        {
            try
            {
                IntancePerson().Add(new PersonsEntity
                {
                    FirstName = personsRequestBody.FirstName,
                    LastName = personsRequestBody.LastName,
                    Company = personsRequestBody.Company,
                });
                return "successful";
            }
            catch (Exception ex)
            {
                return "An error occurred. Error : " + ex.Message;
            }
        }

        // Kişi Kaldırma
        [HttpDelete]
        [Route("Delete/{uuid}")]
        public string Delete(Guid uuid)
        {
            try
            {
                var person = IntancePerson().GetByUUID(uuid);
                var IntanceContactInformation = IntanceContactInformations().GetByPersonUUId(uuid);

                IntancePerson().Delete(new PersonsEntity { UUID = uuid });
                if (IntanceContactInformation != null)
                    IntanceContactInformations().Delete(new ContactInformationsEntity { UUID = IntanceContactInformation.UUID });
                return "successful";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
