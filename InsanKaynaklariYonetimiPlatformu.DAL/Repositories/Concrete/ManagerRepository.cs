using InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Concrete
{
    public class ManagerRepository: IManagerRepository
    {
        HRDataBaseContext dbContext;

        public ManagerRepository(HRDataBaseContext dataBaseContext)
        {
            dbContext = dataBaseContext;
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

        public  Manager CheckLogin(string email, string password) 
        {
            
            
           return dbContext.Managers.SingleOrDefault(a => a.Email == email && a.Password == password);

        }

        public int InsertMemberShip(Membership membershipp)
        {
            dbContext.Memberships.Add(membershipp);
            return dbContext.SaveChanges();
        }

        public Company FindComapny(int companyId)
        {
            Company company = dbContext.Companies.Where(a => a.CompanyId == companyId).SingleOrDefault();
            return company;
        }

        public Manager FindManager(int managerId)
        {
            Manager manager = dbContext.Managers.Where(a => a.ManagerId == managerId).SingleOrDefault();
            return manager;
        }

        public Company FindCompany(int id)
        {
            Company company = dbContext.Companies.Where(a => a.Manager.ManagerId == id).SingleOrDefault();
            return company;
        }

        public List<Debit> GetListDebit(int id)
        {
            //Listelerken include ile employee de yanında getirecek.
            return dbContext.Debits.Include("Employee").Where(a => a.ManagerID == id).ToList();
        }

        public int AddEmployeePermission(Permission permission)
        {
            dbContext.Permissions.Add(permission);
            return dbContext.SaveChanges();
        }

        public Permission GetPermissionById(int permissionId)
        {
            return dbContext.Permissions.Include("Employee").Where(a => a.PermissionId == permissionId).SingleOrDefault();
        }

        public int UpdatePermission(Permission permission)
        {
            return dbContext.SaveChanges();
        }

        public int DeletedPermission(Permission permission)
        {
            dbContext.Permissions.Remove(permission);
            return dbContext.SaveChanges();
        }
    }
}
