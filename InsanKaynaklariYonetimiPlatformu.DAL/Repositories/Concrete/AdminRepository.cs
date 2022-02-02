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
    public class AdminRepository : IAdminRepository
    {
        HRDataBaseContext dbContext;

        public AdminRepository(HRDataBaseContext Db)
        {
            dbContext = Db;
        }
        public List<Company> GetListPassiveCompanies()
        {
            return dbContext.Companies.Include("Manager").Include("Membership").Where(a => a.Manager.IsActive == false).ToList();
        }

        public Manager ActivateManager(int id)
        {
            Manager manager = dbContext.Managers.SingleOrDefault(a => a.CompanyId == id);
            manager.IsActive = true;
            Company company = GetCompanyByManagerID(id);
            company.RegisterDate = DateTime.Now;
            if (dbContext.SaveChanges() > 0)
            {
                return manager;
            }
            else
            {
                return null;
            }

        }

        private Company GetCompanyByManagerID(int id)
        {
            return dbContext.Companies.Where(a => a.CompanyId == id).SingleOrDefault();
        }

        public Admin CheckLogin(string email, string password)
        {
            return dbContext.Admins.SingleOrDefault(a => a.UserName == email && a.Password == password);
        }

        public List<Comment> GetComments()
        {
            return dbContext.Comments.Include("Manager").OrderByDescending(a => a.CommentId).Take(10).ToList();
        }

        public List<Company> GetListActiveCompanies()
        {
            return dbContext.Companies.Include("Manager").Include("Membership").Where(a => a.Manager.IsActive == true).ToList();

        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public Manager GetManagerByID(int companyID)
        {
            return dbContext.Managers.Where(a => a.CompanyId == companyID).SingleOrDefault();
        }

        public List<Employee> GetEmployeeByManagerID(int managerID)
        {
            return dbContext.Employees.Where(a => a.ManagerId == managerID).ToList();

        }

        public Company GetCompanyById(int id)
        {
            return dbContext.Companies.Include("Manager").Where(a => a.CompanyId == id).SingleOrDefault();
        }

        public List<Debit> GetDebitByManagerID(int managerId)
        {
            return dbContext.Debits.Where(a => a.ManagerID == managerId).ToList();
        }

        public int DebitRemove(Debit debit)
        {
            dbContext.Debits.Remove(debit);
            return dbContext.SaveChanges();
        }



        public List<Expenditure> GetExpenditureByManagerID(int managerId)
        {
            return dbContext.Expenditures.Where(a => a.ManagerID == managerId).ToList();
        }

        public List<ExpenditureDocument> GetExpenditureDocumentByexpenditureID(int id)
        {
            return dbContext.ExpenditureDocuments.Where(a => a.ExpenditureId == id).ToList();

        }

        public List<Permission> GetPermissionByManagerID(int managerId)
        {
            return dbContext.Permissions.Where(a => a.ManagerId == managerId).ToList();

        }

        public int PermissionRemove(Permission permission)
        {
            dbContext.Permissions.Remove(permission);
            return dbContext.SaveChanges();
        }

        public List<Shift> GetShiftByEmployeeID(int employeeId)
        {
            return dbContext.Shifts.Where(a => a.EmployeeID == employeeId).ToList();

        }

        public int RespiteRemove(Respite respite)
        {
            dbContext.Respites.Remove(respite);
            return dbContext.SaveChanges();
        }

        public List<Respite> GetRespiteByShiftID(int shiftId)
        {
            return dbContext.Respites.Where(a => a.ShiftId == shiftId).ToList();
        }

        public int ShiftRemove(Shift shift)
        {
            dbContext.Shifts.Remove(shift);
            return dbContext.SaveChanges();
        }

        public int DocumentRemove(Document document)
        {
            dbContext.Documents.Remove(document);
            return dbContext.SaveChanges();
        }

        public List<Document> GetDocumentByEmployeeID(int employeeId)
        {
            return dbContext.Documents.Where(a => a.EmployeeID == employeeId).ToList();

        }

        public int EmployeeRemove(Employee employee)
        {
            dbContext.Employees.Remove(employee);
            return dbContext.SaveChanges();
        }

        public List<Comment> GetCommentByManagerId(int managerId)
        {
            return dbContext.Comments.Where(a => a.ManagerId == managerId).ToList();

        }

        public int CommentRemove(Comment comment)
        {
            dbContext.Comments.Remove(comment);
            return dbContext.SaveChanges();
        }

        public int ManagerRemove(Manager manager)
        {
            dbContext.Managers.Remove(manager);
            return dbContext.SaveChanges();
        }

        public int CompanyRemove(Company company)
        {
            dbContext.Companies.Remove(company);
            return dbContext.SaveChanges();
        }



        public int ExpenditureRemove(Expenditure expenditure)
        {
            dbContext.Expenditures.Remove(expenditure);
            return dbContext.SaveChanges();
        }

        public int expenditureDocumentsRemove(ExpenditureDocument document)
        {
            dbContext.ExpenditureDocuments.Remove(document);
            return dbContext.SaveChanges();
        }

        public Manager GetManagerByCompanyId(int id)
        {
          return dbContext.Managers.Where(a => a.CompanyId == id).SingleOrDefault();
        }
    }
}
