using Directory.DataAccess.Abstract.Persons;
using Directory.DataAccesss;
using Directory.Entities.Concrete.Persons;

namespace Directory.DataAccess.Concrete.Persons
{
    public class PersonDataAccess : DirectoryRepository<PersonsEntity, DirectoryRepositoryDbContext>, IPersonsDataAccess  { }
}
