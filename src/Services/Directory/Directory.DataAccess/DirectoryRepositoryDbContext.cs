

using Directory.Entities.Concrete.ContactInformations;
using Directory.Entities.Concrete.Persons;
using Microsoft.EntityFrameworkCore;

namespace Directory.DataAccesss
{
    public class DirectoryRepositoryDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=directoryDataBase;User Id=postgres;Password=1;");
        }
        DbSet<PersonsEntity> personsEntities { get; set; }
        DbSet<ContactInformationsEntity> contactInformationsEntities { get; set; }
    }
}
