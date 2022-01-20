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
                    List<EmployeeVM> employeeVMs = new List<EmployeeVM>();
                    foreach (Employee employee in employees)
                    {
                        EmployeeVM employeeVM = new EmployeeVM
                        {
                            FullName = employee.FullName,
                            Status = employee.Status,
                            Email = employee.Email,
                            BirtDay = employee.BirthDay,
                            StartDate = employee.StartDate,
                            IsActive = employee.IsActive
                        };
                        employeeVMs.Add(employeeVM);

                    }
                    return View(employeeVMs);
                }
                else
                {
                    throw new Exception("Henüz onaylanmış çalışanınız bulunmamaktadır.");
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
