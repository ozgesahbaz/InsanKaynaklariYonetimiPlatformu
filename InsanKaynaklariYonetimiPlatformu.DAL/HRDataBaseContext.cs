
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
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Respite> Respites { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ExpenditureDocument> ExpenditureDocuments { get; set; }
      



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new AdminConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new CompanyConfig());
            modelBuilder.ApplyConfiguration(new EmployeConfig());
            modelBuilder.ApplyConfiguration(new ManagerConfig());
            modelBuilder.ApplyConfiguration(new MembershipConfig());
            modelBuilder.ApplyConfiguration(new PermissionConfig());
            modelBuilder.ApplyConfiguration(new ExpendituresConfig());
            modelBuilder.ApplyConfiguration(new DebitConfig());
            modelBuilder.ApplyConfiguration(new ShiftConfig());
            modelBuilder.ApplyConfiguration(new RespiteConfig());
            modelBuilder.ApplyConfiguration(new DocumentConfig());
            modelBuilder.ApplyConfiguration(new ExpenditureDocumentConfig());
            





        }

    }
}

