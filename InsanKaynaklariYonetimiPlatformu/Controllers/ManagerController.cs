using InsanKaynaklariYonetimiPlatformu.BLL.Services;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.Controllers
{
    public class ManagerController : Controller
    {
        ManagerService managerService;

        public ManagerController()
        {
            managerService = new ManagerService();
        }

        public IActionResult Index()
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
                    Company company = managerService.AddCompany(register.CompanyName, register.ManagerMail);
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
                managerService.ManagerApproval(id);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("Login");
        }

    }
}
