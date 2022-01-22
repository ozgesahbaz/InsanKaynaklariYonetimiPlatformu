using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.DAL.Repositories.Abstract
{
    public interface IManagerRepository
    {

        bool AnyMailExtension(string mailextension);


        int InsertCompany(Company company);


        bool AnyMail(string managerMail);


        int InsertManager(Manager manager);


        bool managerApproval(int id);


        Manager CheckLogin(string email, string password);


        int InsertMemberShip(Membership membershipp);


        Company FindComapny(int companyId);


        Manager FindManager(int managerId);
        Company FindCompany(int id);
        List<Debit> GetListDebit(int id);
        int AddEmployeePermission(Permission permission);
        Permission GetPermissionById(int permissionId);
        int PermissionAdmited(Permission permission);
        int PermissionDeleted(Permission permission);
    }
}
