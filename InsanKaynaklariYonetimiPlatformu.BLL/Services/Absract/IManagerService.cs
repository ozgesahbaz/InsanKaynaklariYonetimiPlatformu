using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract
{
    public interface IManagerService
    {
        Company AddCompany(string companyName, string managerMail, MembershipType membership, string address);

        string GetMailExtension(string managerMail);


        Manager CheckLogin(LoginVM Login);


        Manager AddManager(ManagerRegisterVM register, Company company);


        bool ManagerApproval(int id);
        Company FindCompany(int companyId);
        List<ManagersDebitVM> GetListManagersDebit(int id);
        List<ManagersPermissionVM> GetPermissionListManagers(int id);
        List<DebitVM> GetListDebit(int id);

        Manager FindManager(int managerId);
        Company FindCompanyByManagerID(int id);
        int AddPermissionEmployee(AddEmployeesPermissionVM permissionVM, int id);
        List<Shift> GetShiftDetailbyEmployeeId(int employeeId);
        PermissionVM GetPermissionById(int id);
        int UpdatePermission(PermissionVM permissionVM);
        List<Respite> GetRespitebyShiftId(int shiftId);
        int RemovePermission(int id);
        List<ShiftDetailsVM> GetShiftDetail(int managerID);
       
        int AddManagersPermission(int id, ManagersPermissionVM permissionVM);
        ManagersPermissionVM UpdatePermissionManager(int id);
        int UpdatePermissionManager(int id, ManagersPermissionVM permissionVM);
        int RemoveDebit(int id);
        int AddEmployeesDebit(int id, AddEmployeesDebitVM debitVM);
      
        int AddManagersPersonelDebit(int id, ManagersDebitVM managersDebitVM);
        int RemoveDocument(int id);
        bool AddShiftDetails(ShiftDetailsVM ShiftDetailsVM, int ManagerID);
        bool DeleteShiftDetails(int shiftId);
        bool EditShiftDetails(ShiftDetailsVM shiftDetailsVM, int emloyeeID);
        ShiftDetailsVM GetShiftDetailbyRespiteID(ShiftDetailsVM shiftDetailsVM, int id);
        int ChangePassword(int id, PasswordVM passwordVM);
        int ChangeAccount(int id, AccountSettingsVM settingsVM, string documentPath);
        int ChangeCompanySettings(int id, CompanySettingsVM settingsVM, string documentPath);
        Manager GetCommentByManagerId(int id);
        bool AddComment(CommentVM commentVM, int id);
        int RemoveComment(int id);
    }
}
