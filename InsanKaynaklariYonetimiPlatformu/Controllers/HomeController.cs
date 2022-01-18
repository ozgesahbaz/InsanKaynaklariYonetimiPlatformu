using InsanKaynaklariYonetimiPlatformu.BLL.Services;
using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.Models;
using InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IManagerService managerService;
        IEmployeeService employeeService;
        public HomeController(ILogger<HomeController> logger, IManagerService _managerService, IEmployeeService _employeeService)
        {
            _logger = logger;
            managerService = _managerService;
            employeeService = _employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerComment()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Request.Cookies.ContainsKey("E-mail") && HttpContext.Request.Cookies.ContainsKey("Password"))
            {
                //Oturum açan kullanıcı tekrar tekrar oturum açmak zorunda kalmayacak. Cooki tarafından bilgiler direk girilebilecek.
                //if (HttpContext.Request.Cookies.Any("Statü", "Manager"))
                //{

                //}
                //ManagerService managerService = new ManagerService();
                string Email = HttpContext.Request.Cookies["E-mail"];
                string Password = HttpContext.Request.Cookies["Password"];
                Manager manager = managerService.CheckLogin(new LoginVM() { Password = Password, Email=Email });

                if (manager==null)
                {
                    //EmployeeService employeeService = new EmployeeService();
                    Employee employee = employeeService.CheckLogin(new LoginVM() { Password = Password, Email = Email });
                    if (employee!=null)
                    {
                        Manager employeeinManager = managerService.FindManager(employee.ManagerId);
                        Company company = managerService.FindCompany(employeeinManager.CompanyId);
                        HttpContext.Session.SetString("CompanyName", company.CompanyName);
                        HttpContext.Session.SetString("FullName", employee.FullName);
                        HttpContext.Session.SetInt32("ID", employee.EmployeeId);
                        HttpContext.Session.SetString("Statü", "Employee");
                        return RedirectToAction("Index", "Employee");
                    }
                }
                else
                {
                    Company company = managerService.FindCompany(manager.CompanyId);
                    HttpContext.Session.SetString("CompanyName", company.CompanyName);
                    HttpContext.Session.SetString("FullName", manager.FullName);
                    HttpContext.Session.SetInt32("ID", manager.ManagerId);
                    HttpContext.Session.SetString("Statü", "Manager");
                    return RedirectToAction("Index", "Manager");
                }
               
            }
            return View();
        }

      
        [HttpPost]
        public IActionResult Login(LoginVM Login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ManagerService managerService = new ManagerService();

                    Manager manager = managerService.CheckLogin(Login);
                    

                    if (manager != null)
                    {
                        if (Login.IsRemember)
                        {
                            CookieOptions cookieOptions = new CookieOptions();
                            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddMonths(1)); //Burada kullanıcılın üyelik süresi tercihine göre cookie saklaması yaparız o süreyi geçtikten sonra kullanıcı kaydı cookiden silinir.

                            //Cooki devreye giriyor.
                            HttpContext.Response.Cookies.Append("E-Mail", manager.Email, cookieOptions);
                            HttpContext.Response.Cookies.Append("Password", manager.Password, cookieOptions);

                        }
                        Company company = managerService.FindCompany(manager.CompanyId);
                        HttpContext.Session.SetString("CompanyName", company.CompanyName);
                        HttpContext.Session.SetString("FullName", manager.FullName);
                        HttpContext.Session.SetInt32("ID", manager.ManagerId);
                        HttpContext.Session.SetString("Statü", "Manager");

                        return RedirectToAction("Index", "Manager"); //Oluşturulan Manager Sayfasına gidilecek
                    }
                    else
                    {
                        //EmployeeService employeeService = new EmployeeService();
                        Employee employee = employeeService.CheckLogin(Login);
                        if (employee != null)
                        {
                            if (Login.IsRemember)
                            {
                                CookieOptions cookieOptions = new CookieOptions();
                                cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddMonths(1)); //Burada kullanıcılın üyelik süresi tercihine göre cookie saklaması yaparız o süreyi geçtikten sonra kullanıcı kaydı cookiden silinir.

                                //Cooki devreye giriyor.
                                HttpContext.Response.Cookies.Append("E-Mail", Login.Email, cookieOptions);
                                HttpContext.Response.Cookies.Append("Password", Login.Password, cookieOptions);

                            }
                            Manager employeeinManager = managerService.FindManager(employee.ManagerId);
                            Company company = managerService.FindCompany(employeeinManager.CompanyId);
                            HttpContext.Session.SetString("CompanyName", company.CompanyName);
                            HttpContext.Session.SetString("FullName", employee.FullName);
                            HttpContext.Session.SetInt32("ID", employee.EmployeeId);
                            HttpContext.Session.SetString("Statü", "Employee");


                            return RedirectToAction("Index","Employee"); //Oluşturulan  Sayfasına gidilecek
                        }
                        else
                        {
                            throw new Exception("Böyle bir kullanıcı bulunamadı.");
                        }

                    }
                }
                }
            catch (Exception ex)
            {

                ModelState.AddModelError("exception", ex.Message);
            }
                     

            return View();
                   
                      
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
