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
        List<ManagersPermissionVM> GetPermissionListManagers(int id);
        List<DebitVM> GetListDebit(int id);

        Manager FindManager(int managerId);
        Company FindCompanyByManagerID(int id);
        int AddPermissionEmployee(AddEmployeesPermissionVM permissionVM, int id);
        PermissionVM GetPermissionById(int id);
        int UpdatePermission(PermissionVM permissionVM);
        int RemovePermission(int id);
        List<ShiftDetailsVM> GetShiftDetail(int managerID);
        void AddShiftDetails(ShiftDetailsVM shiftDetailsVm, int managerID);
        int AddManagersPermission(int id, ManagersPermissionVM permissionVM);
        ManagersPermissionVM UpdatePermissionManager(int id);
        int UpdatePermissionManager(int id, ManagersPermissionVM permissionVM);
        int RemoveDebit(int id);
        int AddEmployeesDebit(int id, AddEmployeesDebitVM debitVM);
    }
}
