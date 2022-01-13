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
        

        }
    }
}
