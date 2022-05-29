using Directory.Entities.Concrete.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory.DataAccess.Configurations
{
    public class PersonsConfiguration:IEntityTypeConfiguration<PersonsEntity>
    {
        public void Configure(EntityTypeBuilder<PersonsEntity> builder)
        {
            builder.Property(s => s.FirstName).HasMaxLength(20);
            builder.Property(s => s.LastName).HasMaxLength(50);
            builder.Property(s => s.Company).HasMaxLength(100);
        }
    }
}
