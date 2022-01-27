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
    public class DocumentConfig : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Dokumanlar");
            builder.HasKey(a => a.DocumentID);
            builder.Property(a => a.DocumentPath).IsRequired();
            builder.HasIndex(a => a.DocumentPath).IsUnique();
            builder.Property(a => a.EmployeeID).IsRequired();
        }
    }
}
