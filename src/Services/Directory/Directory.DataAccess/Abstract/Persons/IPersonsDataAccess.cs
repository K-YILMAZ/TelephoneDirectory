using Directory.Entities.Concrete.Persons;
using System;
using System.Collections.Generic;
using System.Text;
namespace Directory.DataAccess.Abstract.Persons
{
    public interface IPersonsDataAccess : IDirectoryRepository<PersonsEntity> { }
}
