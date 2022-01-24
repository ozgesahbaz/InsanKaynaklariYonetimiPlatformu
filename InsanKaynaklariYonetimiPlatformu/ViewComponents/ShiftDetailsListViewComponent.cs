using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using Microsoft.AspNetCore.Mvc;
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

    }

}
