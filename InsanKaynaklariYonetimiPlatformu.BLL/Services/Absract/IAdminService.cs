using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.AdminVM;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract
{
   public interface IAdminService
    {
        List<Company> GetListPassiveCompanies();


        Manager ActivateManager(int id);
        Admin CheckLogin(LoginVM login);
        List<CommentVM> GetComments();
        List<ActiveCompanyVM> GetActiveCompanyList();
        int DeactivateCompanies(ActiveCompanyVM companyVM);
        int DeleteCompany(int id);
        ManagerOfCompanyVM GetManagerandCompany(int id);
        List<EmployeeOfCompanyVM> GetEmployeesByManagerId(int id);
    }
}
