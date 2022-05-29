using Directory.Entities.Concrete.Persons;
using System;

namespace Directory.Bussiness.Abstract.Persons
{
    public interface IPersonsService: IDirectoryRepositoryService<PersonsEntity> {
        PersonsEntity GetByUUID(Guid guid);
    }
}
