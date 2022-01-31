using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class HomeManagerCommentListViewComponent:ViewComponent
    {
        IAdminService adminService;

        public HomeManagerCommentListViewComponent(IAdminService _adminService)
        {
            adminService = _adminService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                List<CommentVM> commentVMs = adminService.GetComments();

                return View(commentVMs);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
    }
}
