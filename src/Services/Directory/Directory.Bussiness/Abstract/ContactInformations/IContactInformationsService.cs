using Directory.Entities.Concrete.ContactInformations;

namespace Directory.Bussiness.Abstract.ContactInformations
{
    public interface IContactInformationsService: IDirectoryRepositoryService<ContactInformationsEntity>  {
        ContactInformationsEntity GetById(long uuid);
    }
}
