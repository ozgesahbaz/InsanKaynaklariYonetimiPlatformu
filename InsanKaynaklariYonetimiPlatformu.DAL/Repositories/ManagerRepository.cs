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
    }
}
