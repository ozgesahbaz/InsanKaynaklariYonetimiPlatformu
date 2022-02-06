using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class ManagerListDocumentByExpenditure: ViewComponent
    {
        IManagerService managerService;
        public ManagerListDocumentByExpenditure (IManagerService _managerService) 
        {
            managerService = _managerService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id) 
        {
            try
            {
                List<ManagerExpenditureDocumentVM> managerExpenditureDocumentVMs = managerService.GetExpenditureDocument(id);
                if (managerExpenditureDocumentVMs!=null)
                {
                    return View(managerExpenditureDocumentVMs);
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
