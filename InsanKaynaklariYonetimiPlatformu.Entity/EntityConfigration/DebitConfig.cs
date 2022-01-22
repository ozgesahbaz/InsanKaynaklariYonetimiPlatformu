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
    public class DebitConfig : IEntityTypeConfiguration<Debit>
    {
        public void Configure(EntityTypeBuilder<Debit> builder)
        {

            builder.ToTable("Zimmetler");
            builder.Property(a => a.DebitName).HasMaxLength(100).IsRequired();
            builder.Property(a => a.StartedDate).HasColumnType("date").IsRequired();

        }
    }
}
