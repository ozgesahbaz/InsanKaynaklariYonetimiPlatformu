using InsanKaynaklariYonetimiPlatformu.BLL.Services;
using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.ViewModels.AdminVM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.UI.Controllers
{
    public class AdminController : Controller
    {
        AdminService adminService;

        public AdminController()
        {
            adminService = new AdminService();
        }
        public IActionResult PassiveCompany()
        {
            List<Company> pasifCompanyler;
            pasifCompanyler = adminService.GetListPassiveCompanies();
            List<AdminPassiveCompanyVM> passiveCompanyVM = new List<AdminPassiveCompanyVM>();

            foreach (Company company in pasifCompanyler)
            {
                AdminPassiveCompanyVM companyVM = new AdminPassiveCompanyVM()
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName,
                    Mailextension = company.MailExtension,
                    ManagerFullName = company.Manager.FullName,
                    ManagerMail = company.Manager.Email
                };

                passiveCompanyVM.Add(companyVM);
            }

            return View(passiveCompanyVM);

        }
        public IActionResult Activate(int id)
        {
            Manager manager = adminService.ActivateManager(id);
            if (manager.IsActive)
            {
                MailMessage msg = new MailMessage();
                msg.Subject = "....... SİTESİ ONAY LİNKİ";
                msg.From = new MailAddress("insankaynaklariyonetimiprojesi@outlook.com");
                msg.To.Add(new MailAddress("ozgeesahbazz@gmail.com"));
                msg.IsBodyHtml = true;
                msg.Body ="<h1>Merhaba</h1>"+
                "<h4> Üyeliğiniz onaylanmıştır.Lütfen aşağıdaki linke tıklayarak mailinizi doğrulayın</h4>" +
                $"<a href='http://localhost:8021/Manager/ApprovalPage/{id}'></a>";

                SmtpClient smtp = new SmtpClient("smtp.office365.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
                NetworkCredential AccountInfo = new NetworkCredential("insankaynaklariyonetimiprojesi@outlook.com", "123toci123");
                smtp.UseDefaultCredentials = false; //Standart doğrulama kullanılsın mı? -> Yalnızca gönderici özellikle istiyor ise TRUE işaretlenir.
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = false;

                try
                {
                    smtp.Send(msg);
                    
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("exception", ex.Message);
                }
            }

            return RedirectToAction("passivecompany");

        }

        
    }
}
