using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories
{
    public class ManagerRepository
    {
        HRDataBaseContext dbContext;

        public ManagerRepository()
        {
            dbContext = new HRDataBaseContext();
        }
        public bool AnyMailExtension(string mailextension)
        {
            return dbContext.Companies.Any(a => a.MailExtension == mailextension);
        }

        public int InsertCompany(Company company)
        {
            dbContext.Companies.Add(company);
            return dbContext.SaveChanges();
        }
         
        public bool AnyMail(string managerMail)
        {
            return dbContext.Managers.Any(a => a.Email == managerMail);
        }

        public int InsertManager(Manager manager)
        {
            dbContext.Managers.Add(manager);
            return dbContext.SaveChanges();
        }

        public bool managerApproval(int id)
        {
            Manager manager=dbContext.Managers.SingleOrDefault(a => a.CompanyId == id);
            manager.IsApproved = true;
            return dbContext.SaveChanges() > 0;
        }

        public static Manager CheckLogin(string email, string password)
        {
            HRDataBaseContext dbContext = new HRDataBaseContext();
           return dbContext.Managers.SingleOrDefault(a => a.Email == email && a.Password == password);

        }

        public int InsertMemberShip(Membership membershipp)
        {
            dbContext.Memberships.Add(membershipp);
            return dbContext.SaveChanges();
        }

       
    }
}
