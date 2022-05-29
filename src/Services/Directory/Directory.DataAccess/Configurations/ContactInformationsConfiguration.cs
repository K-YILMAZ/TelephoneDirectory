using Directory.Entities.Concrete.ContactInformations;
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
    public class ContactInformationsConfiguration : IEntityTypeConfiguration<ContactInformationsEntity>
    {
        public void Configure(EntityTypeBuilder<ContactInformationsEntity> builder)
        {
            builder.Property(s => s.Email).HasMaxLength(50);
            builder.Property(s => s.Location).HasMaxLength(300);
            builder.Property(s => s.Description).HasMaxLength(200);
        }
    }
}
