using Directory.DataAccess.Abstract.Persons;
using Directory.Entities.Concrete.ContactInformations;

namespace Directory.DataAccess.Abstract.ContactInformations
{
    public interface IContactInformationsDataAccess : IDirectoryRepository<ContactInformationsEntity>  { }
}
