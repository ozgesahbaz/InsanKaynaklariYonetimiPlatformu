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
   public class MembershipConfig : IEntityTypeConfiguration<Membership>
    {
    
public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.ToTable("ÜyelikTürleri");
            builder.HasKey(a => a.MembershipId);
            builder.Property(a => a.CompanyId).IsRequired();
            builder.Property(a => a.MembershipType).IsRequired();

        }
    }
}
