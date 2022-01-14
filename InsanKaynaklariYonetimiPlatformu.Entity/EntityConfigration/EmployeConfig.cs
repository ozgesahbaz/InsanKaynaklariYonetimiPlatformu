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
    public class EmployeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Personeller");
            builder.HasKey(a => a.EmployeeId);
            builder.Property(a => a.FullName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Status).IsRequired().HasMaxLength(100);
            builder.HasIndex(a => a.Email).IsUnique();
            builder.Property(a => a.Email).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Password).IsRequired().HasMaxLength(20);
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.ManagerId).IsRequired();
            builder.Property(a => a.Salary).HasMaxLength(10);
            builder.Property(a => a.Photo).HasColumnType("image");
        }
    }
}
