using Directory.Entities.Concrete.Persons;

namespace Directory.Bussiness.Abstract.Persons
{
    public interface IPersonsService: IDirectoryRepositoryService<PersonsEntity> {
    }
}
