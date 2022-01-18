
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.Entity.EntityConfigration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL
{
    public class HRDataBaseContext : DbContext
    {
        //public HRDataBaseContext()
        //{

        //}
        public HRDataBaseContext(DbContextOptions<HRDataBaseContext> options) : base(options)
        {
#if DEBUG

#endif
            if (Database.GetPendingMigrations().Count() > 0)
            {
                Database.Migrate();
            }
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Admin> Admins { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Server=MONSTER;Database=HRContextDb;Trusted_Connection=True;");
        //    //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HRContextDb;Trusted_Connection=True;");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new AdminConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new CompanyConfig());
            modelBuilder.ApplyConfiguration(new EmployeConfig());
            modelBuilder.ApplyConfiguration(new ManagerConfig());
            modelBuilder.ApplyConfiguration(new MembershipConfig());
            modelBuilder.ApplyConfiguration(new PermissionConfig());
            
        }
    }
}

