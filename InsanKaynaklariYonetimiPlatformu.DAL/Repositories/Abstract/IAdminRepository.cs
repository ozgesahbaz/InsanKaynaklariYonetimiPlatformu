using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract
{
    public interface IAdminRepository
    {
        List<Company> GetListPassiveCompanies();


        Manager ActivateManager(int id);
        Admin CheckLogin(string email, string password);
        List<Comment> GetComments();
        List<Company> GetListActiveCompanies();
        int Save();
        Manager GetManagerByID(int managerID);
        List<Employee> GetEmployeeByManagerID(int managerID);
        Company GetCompanyById(int id);
        List<Debit> GetDebitByManagerID(int managerId);
        int DebitRemove(Debit debit);

        List<Expenditure> GetExpenditureByManagerID(int managerId);
        List<ExpenditureDocument> GetExpenditureDocumentByexpenditureID(int id);
        List<Permission> GetPermissionByManagerID(int managerId);
        int PermissionRemove(Permission permission);
        List<Shift> GetShiftByEmployeeID(int employeeId);
        int RespiteRemove(Respite respite);
        List<Respite> GetRespiteByShiftID(int shiftId);
        int ShiftRemove(Shift shift);
        int DocumentRemove(Document document);
        List<Document> GetDocumentByEmployeeID(int employeeId);
        int EmployeeRemove(Employee employee);
        List<Comment> GetCommentByManagerId(int managerId);
        int CommentRemove(Comment comment);
        int ManagerRemove(Manager manager);
        int CompanyRemove(Company company);
      
        int ExpenditureRemove(Expenditure expenditure);
        int expenditureDocumentsRemove(ExpenditureDocument document);
        Manager GetManagerByCompanyId(int id);
    }
}
