
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.Controllers
{
    public class EmployeController
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

       
        private IActionResult View()
        {
          
            return View();
        }

        [HttpPost]
        private IActionResult View(LoginVM employe)
        {
            //loginvm gelecek ve isvalid kontrolü yapılacak
            //böyle bir kullanıcı var mı konrolü yapılacak 
            //true ise kullanıcı is active mi kontrolü yapılacak
            //true ise kullanıcı employeeindex'e yönlendirilecek
            //false ise kullanıcıya uyarı gönderilecek

            return View();
        }

        
    }

}
