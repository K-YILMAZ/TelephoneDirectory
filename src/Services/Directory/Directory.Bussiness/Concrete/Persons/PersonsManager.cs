using Directory.Bussiness.Abstract.Persons;
using Directory.DataAccess.Abstract.Persons;
using Directory.Entities.Concrete.Persons;
using System;
using System.Collections.Generic;

namespace Directory.Bussiness.Concrete.Persons
{
    public class PersonsManager : IPersonsService
    {
        private IPersonsDataAccess _personsDataAccess;

        public PersonsManager(IPersonsDataAccess personsDataAccess)
        {
            _personsDataAccess = personsDataAccess;
        }
        public void Add(PersonsEntity entity)
        {
            _personsDataAccess.Add(entity);
        }

        public void Delete(PersonsEntity entity)
        {
            _personsDataAccess.Delete(entity);
        }
        public List<PersonsEntity> GetAll()
        {
            return _personsDataAccess.GetAll();
        }

        public PersonsEntity GetByUUID(Guid guid)
        {
            return _personsDataAccess.Get(p => p.UUID == guid);
        }

        public void Update(PersonsEntity entity)
        {
            _personsDataAccess.Update(entity);
        }
    }
}
