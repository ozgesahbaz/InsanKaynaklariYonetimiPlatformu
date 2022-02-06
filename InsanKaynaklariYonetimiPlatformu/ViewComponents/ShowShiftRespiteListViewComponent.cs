using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.ViewComponents
{
    public class ShowShiftRespiteListViewComponent : ViewComponent
    {
        IManagerService managerService;
        IEmployeeService employeeService;

        public ShowShiftRespiteListViewComponent(IManagerService _managerService, IEmployeeService _employeeService)
        {
            managerService = _managerService;
            employeeService = _employeeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
                List<Employee> employees = employeeService.GetListEmployees(id);
                ShiftDateVM shiftDateVm = new ShiftDateVM();
                List<ShiftDateVM> shiftDateVms = new List<ShiftDateVM>();
                foreach (Employee item in employees)
                {
                    shiftDateVm.FullName = item.FullName;
                    shiftDateVm.EmployeeID = item.EmployeeId;
                    List<Shift> shifts = managerService.GetShiftDetailbyEmployeeId(item.EmployeeId);
                    foreach (Shift shift in shifts)
                    {
                        shiftDateVm.ShiftStartTime = shift.ShiftStartTime;
                        shiftDateVm.ShiftFinishTime = shift.ShiftFinishTime;
                        List<Respite> respites = managerService.GetRespitebyShiftId(shift.ShiftId);
                        foreach (Respite respite in respites)
                        {
                            shiftDateVm.RespiteStartTime = respite.RespiteStartTime;
                            shiftDateVm.RespiteFinishTime = respite.RespiteFinishTime;
                        }
                    }
                    shiftDateVms.Add(shiftDateVm);
                };



                return View(shiftDateVms);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }
            return View();

        }

    }
}
