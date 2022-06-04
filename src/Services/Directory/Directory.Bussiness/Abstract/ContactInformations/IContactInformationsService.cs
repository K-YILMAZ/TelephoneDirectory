using Directory.Entities.Concrete.ContactInformations;
using System;
using System.Collections.Generic;

namespace Directory.Bussiness.Abstract.ContactInformations
{
    public interface IContactInformationsService: IDirectoryRepositoryService<ContactInformationsEntity>  {
        ContactInformationsEntity GetByPersonuuid(Guid Personuuids);
        List<ContactInformationsEntity> GetAllPersonuuid(Guid Personuuids);
    }
}
