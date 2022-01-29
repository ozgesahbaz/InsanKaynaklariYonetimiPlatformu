using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class EmployeeExpenditureListViewComponent:ViewComponent
    {
        IEmployeeService employeeService;

        public EmployeeExpenditureListViewComponent (IEmployeeService _employeeService) 
        {
            employeeService = _employeeService;
                
        }
        public async Task<IViewComponentResult> InvokeAsync(int id) 
        {
            try
            {
                List<ExpenditureVM> expenditureVMs = employeeService.GetListExpenditure(id);
                if (expenditureVMs!= null)
                {
                    return View(expenditureVMs);
                }
                else
                {
                    throw new Exception("Henüz harcama kaydınız bulunmamaktadır");
                     
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exeption", ex.Message);
                
            }
            return View();
        
        
        }
    }
}
