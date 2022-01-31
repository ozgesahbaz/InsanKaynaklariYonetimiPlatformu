using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class EmployeeDebitListViewComponent: ViewComponent
    {
        IEmployeeService employeeService;
        public EmployeeDebitListViewComponent(IEmployeeService _employeeService) 
        {
            employeeService = _employeeService;
        
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<EmployeeDebitVM> debitVMs = employeeService.GetEmployeeDebitList(id);
                if (debitVMs!= null)
                {
                    return View(debitVMs);
                }
                else
                {
                    throw new Exception("Henüz zimmetiniz bulunmamaktadır.");
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
