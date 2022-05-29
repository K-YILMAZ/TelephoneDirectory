using Directory.Bussiness.Abstract.ContactInformations;
using Directory.DataAccess.Abstract.ContactInformations;
using Directory.Entities.Concrete.ContactInformations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Directory.Bussiness.Concrete.ContactInformations
{
    public class ContactInformationsManager : IContactInformationsService
    {
        private IContactInformationsDataAccess _contactInformationsDataAccess;
        public ContactInformationsManager(IContactInformationsDataAccess  contactInformationsDataAccess)
        {
            _contactInformationsDataAccess = contactInformationsDataAccess;
        }
        public void Add(ContactInformationsEntity entity)
        {
            _contactInformationsDataAccess.Add(entity);
        }

        public void Delete(ContactInformationsEntity entity)
        {
            _contactInformationsDataAccess.Delete(entity);
        }
        public List<ContactInformationsEntity> GetAll()
        {
            return _contactInformationsDataAccess.GetAll();
        }

        public ContactInformationsEntity GetById(long uuid)
        {
            throw new NotImplementedException();
        }

        public void Update(ContactInformationsEntity entity)
        {
            _contactInformationsDataAccess.Update(entity);
        }
    }
}
