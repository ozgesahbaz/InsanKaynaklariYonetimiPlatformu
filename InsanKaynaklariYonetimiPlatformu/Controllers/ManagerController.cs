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
using System.Net;
using System.Net.Mail;
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
            return View();
        }
        [HttpPost]
        public IActionResult ManagersEmployees(AddEmployeeVM employeeVM, int id)
        {
            try
            {
                //mail uzantısı controlü için şirket manager id(layouttaki sessiondan geldi) ile bulundu.
                Company company = managerService.FindCompanyByManagerID(id);
                //çalışan eklendi. kontroller employee servicede (controller->services->repository)
                Employee employee=employeeService.AddEmployee(employeeVM,id,company.MailExtension);
                //oluştuysa employee dolu gelecek.
                if (employee!=null)
                {
                    //dolu geldiyse yani dbye kayıt olduysa mail gönderilecek.
                    SendMail(employee);
                }
            }
            catch (Exception ex)
            {

                 ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }

        private static void SendMail(Employee employee)
        {
            MailMessage msg = new MailMessage();
            msg.Subject = "Üyeliğinizi doğrulayın.";
            msg.From = new MailAddress("kirmizitakim1@hotmail.com");
            msg.To.Add(new MailAddress(employee.Email));
            msg.IsBodyHtml = true;
            msg.Body = $"<h3>Merhaba {employee.FullName}</h1>" +
            "<h4>Üyeliğinizi tamamlamak için linke tıklayınız.</h4>" +
            $"<a href='http://localhost:8021/Employee/CreatePasswordByEmployeeMail/{employee.EmployeeId}'>Buraya tıklayınız.</a>";

            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
            NetworkCredential AccountInfo = new NetworkCredential("kirmizitakim1@hotmail.com", "123toci123");
            smtp.UseDefaultCredentials = false; //Standart doğrulama kullanılsın mı? -> Yalnızca gönderici özellikle istiyor ise TRUE işaretlenir.
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true;


            smtp.Send(msg);
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
                    return RedirectToAction("Index","Home");
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
