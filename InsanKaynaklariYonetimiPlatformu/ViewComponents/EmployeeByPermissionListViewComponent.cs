using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class EmployeeByPermissionListViewComponent: ViewComponent
    {

        IEmployeeService employeeService;

        public EmployeeByPermissionListViewComponent(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<EmployeePermissionVM> permissions = employeeService.GetPermissionListEmployeeByID(id);

                if (permissions != null)
                {

                    return View(permissions);
                }
                else
                {
                    throw new Exception("Daha önce eklenen izin yok.");
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
