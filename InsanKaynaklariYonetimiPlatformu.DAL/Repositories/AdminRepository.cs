using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories
{
    public class AdminRepository
    {
        HRDataBaseContext dbContext;

        public AdminRepository()
        {
            dbContext = new HRDataBaseContext();
        }
        public List<Company> GetListPassiveCompanies()
        {
            return dbContext.Companies.Include("Manager").Where(a => a.Manager.IsActive == false).ToList() ;
        }

        public Manager ActivateManager(int id)
        {
           Manager manager= dbContext.Managers.SingleOrDefault(a => a.CompanyId == id);
           manager.IsActive = true;
            if (dbContext.SaveChanges() > 0)
            {
                return manager;
            }
            else
            {
                return null;
            }
            
        }
    }
}
