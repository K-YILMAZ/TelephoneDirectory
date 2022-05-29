using Microsoft.VisualStudio.TestTools.UnitTesting;
using Directory.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using Directory.DataAccess.Concrete.ContactInformations;

namespace Directory.DataAccess.Concrete.Tests
{
    [TestClass()]
    public class DirectoryRepositoryTests
    {
        ContactInformationsDataAccess contactInformationsDataAccess = new ContactInformationsDataAccess();
        [TestMethod()]
        public void AddTest()
        {
            contactInformationsDataAccess.Add(new Entities.Concrete.ContactInformations.ContactInformationsEntity
            {
                Description="description",
                PersonUUID=1212,
                TelephoneNumber=030303030,
                Location="description",
                Email="description",
            });
        }
        [TestMethod()]
        public void GetAllTest()
        {
            var data=contactInformationsDataAccess.GetAll();
            
        }
    }
}