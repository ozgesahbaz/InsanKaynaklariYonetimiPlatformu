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
    public class ShiftConfig : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.ToTable("Vardiyalar");
            builder.Property(a => a.ShiftName).HasMaxLength(20).IsRequired();
            builder.Property(a => a.ShiftTimeSlot).HasMaxLength(11).IsRequired(); /*zaman aralığı girip onu string olarak alalım (örn: 07:00-15:00 arası)*/
            
        }
    }
}
