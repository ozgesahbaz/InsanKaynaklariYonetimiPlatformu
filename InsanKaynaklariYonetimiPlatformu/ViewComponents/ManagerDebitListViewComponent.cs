using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class ManagerDebitListViewComponent : ViewComponent
    {
        IManagerService managerService;

        public ManagerDebitListViewComponent(IManagerService _managerService)
        {
            managerService = _managerService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<DebitVM> debits = managerService.GetListDebit(id);
                if (debits != null)
                {

                    return View(debits);
                }
                else
                {
                    throw new Exception("Henüz zimmet bulunmamaktadır.");
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
