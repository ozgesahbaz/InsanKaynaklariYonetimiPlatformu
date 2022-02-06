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
    public class EmployeeExpenditureListForManagersListViewComponent: ViewComponent 
    {
        IEmployeeService employeeService;
        public EmployeeExpenditureListForManagersListViewComponent (IEmployeeService _employeeService) 
        {
            employeeService = _employeeService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id) 
        {
            try
            {
                List<Expenditure> expenditures = employeeService.GetExpenditureListForManager(id);
                if (expenditures!=null)
                {
                    List<EmployeesExpenditureVM> employeesExpenditureVMs = new List<EmployeesExpenditureVM>();
                    foreach (Expenditure expenditure in expenditures)
                    {
                        EmployeesExpenditureVM employeesExpenditureVM = new EmployeesExpenditureVM()
                        {
                            ID = expenditure.ID,
                            ExpenditureName = expenditure.ExpenditureName,
                            ExpenditureAmount = expenditure.ExpenditureAmount,
                            Details = expenditure.Details,
                            isAproved = expenditure.isAproved
                        };
                        employeesExpenditureVMs.Add(employeesExpenditureVM);
                    }
                    return View(employeesExpenditureVMs);

                }
                else
                {
                    throw new Exception("Harcama isteği bulunmamaktadır.");
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
