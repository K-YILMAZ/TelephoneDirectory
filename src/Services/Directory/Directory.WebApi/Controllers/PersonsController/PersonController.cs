

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
                var ApiModels = new List<ApiModels>();
                persons.ForEach(person =>
                {
                    ApiModels.Add(new ApiModels
                    {
                        firstName = person.firstName,
                        lastName = person.lastName,
                        company = person.company,
                        contactInformationsList = IntanceContactInformations().GetAllPersonuuid(person.uuid)
                    });
                });
                return ApiModels;
            }
            catch (Exception ex)
            {

                throw (ex);
            }


        }
        //Bir kişinin detaylı Bilgisini Listeleme
        [HttpGet]
        [Route("GetDetail/{uuid}")]
        public List<ApiModels> GetDetail(Guid uuid)
        {
            try
            {
                var person = IntancePerson().GetByUUID(uuid) ?? new PersonsEntity();
                var contactInformation = IntanceContactInformations().GetByPersonuuid(uuid) ?? new ContactInformationsEntity();
                var ApiModels = new List<ApiModels>();

                ApiModels.Add(new ApiModels
                {
                    firstName = person.firstName,
                    lastName = person.lastName,
                    company = person.company,
                    contactInformationsList = IntanceContactInformations().GetAllPersonuuid(uuid)
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
                    firstName = personsRequestBody.FirstName,
                    lastName = personsRequestBody.LastName,
                    company = personsRequestBody.Company,
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
                var IntanceContactInformation = IntanceContactInformations().GetByPersonuuid(uuid);

                IntancePerson().Delete(new PersonsEntity { uuid = uuid });
                if (IntanceContactInformation != null)
                    IntanceContactInformations().Delete(new ContactInformationsEntity { uuid = IntanceContactInformation.uuid });
                return "successful";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
