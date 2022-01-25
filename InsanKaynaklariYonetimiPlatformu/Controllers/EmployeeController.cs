
using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreatePasswordByEmployeeMail(int id)
        {
            RegisterEmployeeVM register = new RegisterEmployeeVM()
            {
                ID = id
            };
            return View(register);
        }
        [HttpPost]
        public IActionResult CreatePasswordByEmployeeMail(RegisterEmployeeVM register)
        {
            try
            {
                if (register.Password == register.AgainPassword)
                {
                    Employee employee = employeeService.GetEmployeeById(register.ID);
                    if (employee!=null)
                    {
                        int AffectedRows= employeeService.ChangesPassword(employee, register.Password);
                        if (AffectedRows<=0)
                        {
                            throw new Exception("Bir hata oluştu.");
                        }
                    }
                }
                else
                {
                    throw new Exception("Parolalar uyuşmuyor.");
                }
            }
            catch (Exception ex)
            {
                 ModelState.AddModelError("exception", ex.Message);

            }

            return RedirectToAction("Index","Home");
        }





    }

}
