using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity.EntityConfigration
{
    public class ExpendituresConfig : IEntityTypeConfiguration<Expenditure>
    {
       

        public void Configure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable("Harcamalar");
            builder.Property(a => a.ExpenditureName).HasMaxLength(250).IsRequired();
            builder.Property(a => a.ExpenditureAmount).IsRequired().HasPrecision(10,2);


        }
    }
}
