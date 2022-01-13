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
   public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Şirketler");
            builder.HasKey(a => a.CompanyId);
        }
    }
}
