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
   public class ManagerConfig : IEntityTypeConfiguration<Manager>
    {
    
public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.ToTable("Yöneticiler");
            builder.HasKey(a => a.ManagerId);
            builder.Property(a => a.FullName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(a => a.Email).IsUnique();
            builder.Property(a => a.Password).IsRequired().HasMaxLength(20);
            builder.Property(a => a.Photo).HasColumnType("image");
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsApproved).IsRequired();           
            builder.Property(a => a.CompanyId).IsRequired();

        //builder.HasData(new Manager { ManagerId=1,FullName = "Test",Email="test@gmail.com",Password="1234",IsActive=true,IsApproved=true,CompanyId=1 }); //test manager olsun

        }
     
    }
}
