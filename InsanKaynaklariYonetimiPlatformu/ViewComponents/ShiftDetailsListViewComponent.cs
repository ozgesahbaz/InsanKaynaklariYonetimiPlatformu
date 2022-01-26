using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
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
        IEmployeeService employeeService;

        public ShiftDetailsListViewComponent(IManagerService _managerService, IEmployeeService _employeeService)
        {
            managerService = _managerService;
            employeeService = _employeeService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            try
            {
               
                    List<Employee> employees = employeeService.GetListEmployees(id);
                    List<ShiftDetailsVM> shiftDetailsVMs = new List<ShiftDetailsVM>();
                    foreach (Employee item in employees)
                    {
                        List<Shift> shifts = managerService.GetShiftDetailbyEmployeeId(item.EmployeeId);
                        foreach (Shift shift in shifts)
                        {

                            List<Respite> respites = managerService.GetRespitebyShiftId(shift.ShiftId);
                            foreach (Respite respite in respites)
                            {
                                ShiftDetailsVM shiftDetailsVM = new ShiftDetailsVM()
                                {
                                    EmployeeID = item.EmployeeId,
                                    EmployeeFullName = item.FullName,
                                    ShiftFinishTime = shift.ShiftFinishTime,
                                    ShiftStartTime = shift.ShiftStartTime,
                                    RespiteFinishTime = respite.RespiteFinishTime,
                                    RespiteStartTime = respite.RespiteStartTime,
                                 
                                };
                                shiftDetailsVMs.Add(shiftDetailsVM);

                            }
                        }

                    }



                    return View(shiftDetailsVMs);
               

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }

    }

}
