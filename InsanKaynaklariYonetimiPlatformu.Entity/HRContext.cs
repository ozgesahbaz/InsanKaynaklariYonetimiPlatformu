using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Entity
{
    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> options) : base(options)
        {
#if DEBUG

#endif
            if (Database.GetPendingMigrations().Count()>0)
            {
                Database.Migrate();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name = ConnectionStrings:DefaultConnection");
            }

          
        }
    }
}
