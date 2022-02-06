using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.AdminVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class CompaniesEmployeesViewComponent : ViewComponent
    {
        IAdminService adminService;

        public CompaniesEmployeesViewComponent(IAdminService _adminService)
        {
            adminService = _adminService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<EmployeeOfCompanyVM> employees = adminService.GetEmployeesByManagerId(id);

                if (employees != null)
                {
                    return View(employees);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }

            return View();

        }
    }
}
