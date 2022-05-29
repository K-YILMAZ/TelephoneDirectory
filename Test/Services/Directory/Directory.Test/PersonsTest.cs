using Directory.Bussiness.Abstract.Persons;
using Directory.Bussiness.Concrete.Persons;
using Directory.DataAccess.Concrete.Persons;
using Directory.Entities.Concrete.Persons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Directory.Test
{
    [TestClass]
    public class PersonsTest
    {

        private IPersonsService _personsService ;

        private IPersonsService IntancePerson()
        {
          return _personsService??new PersonsManager(new PersonDataAccess());
        }
        [TestMethod]
        public void Add()
        {
            IntancePerson().Add(new PersonsEntity
            {
                FirstName="Kanber",
                LastName="YILMAZ",
                Company="ky",
            });
        }
        [TestMethod]
        public void Update()
        {
            IntancePerson().Update(new PersonsEntity
            {
                
                UUID=new System.Guid("817aa2c6-3d33-4b79-a74a-f61604315f3e"),
                FirstName = "Kanber",
                LastName = "YILMAZ",
                Company = "kyilmaz", //GŁncellenen bilgi
            });
        }

        [TestMethod]
        public List<PersonsEntity> GetAll()
        {
           return IntancePerson().GetAll();
        }
    }
}
