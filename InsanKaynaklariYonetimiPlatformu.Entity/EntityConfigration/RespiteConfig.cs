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
    public class RespiteConfig : IEntityTypeConfiguration<Respite>
    {
        public void Configure(EntityTypeBuilder<Respite> builder)
        {
            builder.ToTable("Molalar");
            builder.Property(a => a.RespiteTimeSlot).IsRequired().HasMaxLength(11); // zaman aralığı girip onu string olarak alalım (örn: 15:00-15:15 arası)
        }
    }
}
