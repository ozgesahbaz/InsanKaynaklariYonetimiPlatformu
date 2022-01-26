using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class GetListDocumentByEmployeeViewComponent:ViewComponent
    {
        IEmployeeService employeeService;

        public GetListDocumentByEmployeeViewComponent(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<DocumentVM> documents = employeeService.GetDocument(id);

                if (documents != null)
                {

                    return View(documents);
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
