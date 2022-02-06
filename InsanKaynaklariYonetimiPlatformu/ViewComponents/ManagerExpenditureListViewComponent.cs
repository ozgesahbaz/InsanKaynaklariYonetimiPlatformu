using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class ManagerExpenditureListViewComponent: ViewComponent
    {
        IManagerService managerService;

        public ManagerExpenditureListViewComponent (IManagerService _managerService) 
        {
            managerService = _managerService;
        
        }

        public async Task<IViewComponentResult> InvokeAsync(int id) 
        {
            try
            {
                List<ManagerExpenditureVM> managerExpenditureVMs = managerService.GetListManagerExpenditure(id);
                if (managerExpenditureVMs != null)
                {
                    return View(managerExpenditureVMs);
                }
                else
                {
                    throw new Exception("Henüz Harcaman Kaydı Gerçekleştirmediniz");
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
