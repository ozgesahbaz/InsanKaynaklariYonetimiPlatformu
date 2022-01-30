using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class ListDocumentByExpenditure : ViewComponent
    {
        IEmployeeService employeeService;
        public ListDocumentByExpenditure(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;

        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<DocumentsVM> documentsVMs = employeeService.GetExpenditureDocument(id);

                if (documentsVMs != null)
                {

                    return View(documentsVMs);
                }
                else
                {
                    throw new Exception("Daha önce eklenen dosya bulunamadı.");
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
