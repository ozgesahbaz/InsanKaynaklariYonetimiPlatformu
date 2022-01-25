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
public    class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("İzinler");
            builder.HasKey(a => a.PermissionId);
            builder.Property(a => a.StartDate).HasColumnType("date").IsRequired();
            builder.Property(a => a.FinishDate).HasColumnType("date").IsRequired();
            builder.Property(a => a.PermissionType).IsRequired();
            
          
        }
    }
}
