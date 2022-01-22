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
   public class AdminConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Adminler");
            builder.HasKey(a => a.AdminId);
            builder.Property(a => a.FullName).IsRequired().HasMaxLength(100);
            builder.HasData(new Admin { AdminId = 1, FullName = "Red Team", UserName="admin@admin.com",Password="admin" }); // tek admin olsun  fullname yada  username ile  yakalanıp  admin sayfasına yönelendirsin???
        }
    }
}
