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
    public class ManagersPermissionListViewComponent : ViewComponent
    {
        IManagerService managerService;

        public ManagersPermissionListViewComponent(IManagerService _managerService)
        {
            managerService = _managerService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<ManagersPermissionVM> permissions = managerService.GetPermissionListManagers(id);

                if (permissions != null)
                {
                    
                    return View(permissions);
                }
                else
                {
                    throw new Exception("Daha önce eklenen izin yok.");
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
