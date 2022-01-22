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
        List<DebitVM> GetListDebit(int id);

        Manager FindManager(int managerId);
        Company FindCompanyByManagerID(int id);
        int AddPermissionEmployee(AddEmployeesPermissionVM permissionVM, int id);
        int PermissionAdmited(int permissionId);
        int PermissionDeleted(int permissionId);
    }
}
