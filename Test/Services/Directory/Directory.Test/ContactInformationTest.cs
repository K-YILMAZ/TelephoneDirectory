using Directory.Bussiness.Abstract.ContactInformations;
using Directory.Bussiness.Concrete.ContactInformations;
using Directory.DataAccess.Concrete.ContactInformations;
using Directory.Entities.Concrete.ContactInformations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Directory.Test
{
    [TestClass]
    public class ContactInformationTest
    {

        private IContactInformationsService _contactInformationsService ;

        private IContactInformationsService IntanceContactInformation()
        {
          return _contactInformationsService ?? new ContactInformationsManager(new ContactInformationsDataAccess());
        }
        [TestMethod]
        public void Add()
        {
            IntanceContactInformation().Add(new ContactInformationsEntity
            {
                informationType="Location",
                informationContent= "Ankara",
                personuuid=new System.Guid("8583704f-2524-4602-a141-a4434f3f29d2"),
            });
        }
        [TestMethod]
        public void Delete()
        {
            IntanceContactInformation().Delete(new ContactInformationsEntity
            {
                uuid=new System.Guid("9b92c5d5-e3d0-4612-bbaf-7491df7d2191"),
            });
        }

        [TestMethod]
        public List<ContactInformationsEntity> GetAll()
        {
           return IntanceContactInformation().GetAll();
        }
    }
}
