using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class EmployeeListViewComponent : ViewComponent
    {
        IEmployeeService employeeService;

        public EmployeeListViewComponent( IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<Employee> employees = employeeService.GetListEmployees(id);
                if (employees != null)
                {
                    
                    return View(employees);
                }
                else
                {
                    throw new Exception("Henüz çalışanınız bulunmamaktadır.");
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
