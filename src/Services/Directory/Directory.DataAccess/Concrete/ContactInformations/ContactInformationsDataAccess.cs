using Directory.DataAccess.Abstract.ContactInformations;
using Directory.DataAccesss;
using Directory.Entities.Concrete.ContactInformations;

namespace Directory.DataAccess.Concrete.ContactInformations
{
   public class ContactInformationsDataAccess:DirectoryRepository<ContactInformationsEntity, DirectoryRepositoryDbContext>, IContactInformationsDataAccess { }
}
