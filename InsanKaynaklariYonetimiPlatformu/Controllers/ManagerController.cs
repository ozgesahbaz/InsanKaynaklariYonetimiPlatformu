using InsanKaynaklariYonetimiPlatformu.BLL.Services;
using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.Controllers
{
    public class ManagerController : Controller
    {
        IManagerService managerService;
        IEmployeeService employeeService;

        public ManagerController(IManagerService _managerService, IEmployeeService _employeeService)
        {
            managerService = _managerService;
            employeeService = _employeeService;
        }
     
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagersEmployees(int id)
        {
            try
            {
                List<Employee> employees = employeeService.GetListEmployees(id);
                if (employees!=null)
                {
                    List<EmployeeVM> employeeVMs = new List<EmployeeVM>();
                    foreach (Employee employee in employees)
                    {
                        EmployeeVM employeeVM = new EmployeeVM
                        {
                            FullName = employee.FullName,
                            Status = employee.Status,
                            Email = employee.Email,
                            BirtDay = employee.BirthDay,
                            StartDate = employee.StartDate
                        };
                        employeeVMs.Add(employeeVM);

                    }
                    return View(employeeVMs);
                }
                else
                {
                    throw new Exception("Henüz onaylanmış çalışanınız bulunmamaktadır.");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }
           return View();
        }

        [HttpGet]
        public IActionResult Register(/*ManagerRegisterVM register*/)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(ManagerRegisterVM register)
        {
            //Vm buraya gelecek isvalid kontrolü yapılacak

            if (ModelState.IsValid)
            {

                try
                {
                    Company company = managerService.AddCompany(register.CompanyName, register.ManagerMail,register.Membership,register.Address);
                    Manager manager;
                    if (company.CompanyId > 0)
                    {
                        manager = managerService.AddManager(register, company);
                        if (manager.ManagerId > 0)
                        {
                           
                                throw new Exception("Kayıdınız onaylandığında mail adresinize doğrulama linki gönderilecektir. Linke tıklayarak mailinizi doğrulayabilirsiniz.");
                            
                        }
                    }

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("exception", ex.Message);
                }
            }

            return View(register);
        }
        public IActionResult ApprovalPage(int id)
        {
            
            try
            {
                if (managerService.ManagerApproval(id))
                {
                    return RedirectToAction();
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
