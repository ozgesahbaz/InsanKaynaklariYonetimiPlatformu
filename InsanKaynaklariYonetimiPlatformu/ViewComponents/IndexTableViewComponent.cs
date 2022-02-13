using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class IndexTableViewComponent : ViewComponent
    {
        IEmployeeService employeeService;
        public IndexTableViewComponent(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                ManagerIndexVM vm = new ManagerIndexVM()
                {
                    employees = employeeService.GetListEmployees(id),
                    expenditures = employeeService.GetListExpenditureByManagerID(id),

                };
                return View(vm);
            }
            catch (System.Exception)
            {

                throw;
            }
            return View();
        }
    }
}