using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class ShiftDetailsListViewComponent : ViewComponent
    {
        IManagerService managerService;

        public ShiftDetailsListViewComponent(IManagerService _managerService)
        {
            managerService = _managerService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<ShiftDetailsVM> ShiftDetailsVms = managerService.GetShiftDetail(id);
                if (ShiftDetailsVms==null)
                {
                    throw new Exception("Listelenecek mola ve vardiya bulunmamaktadır.");
                }

                return View(ShiftDetailsVms);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }

    }

}
