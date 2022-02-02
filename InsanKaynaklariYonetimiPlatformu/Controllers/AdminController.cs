using InsanKaynaklariYonetimiPlatformu.BLL.Services;
using InsanKaynaklariYonetimiPlatformu.BLL.Services.Absract;
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
        IAdminService adminService;

        public AdminController(IAdminService adminserv)
        {
            adminService =adminserv;
        }
        public IActionResult Index()
        {
            return View();
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
                    ManagerMail = company.Manager.Email,
                    membershipType = company.Membership.MembershipType
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
                msg.Subject = "Üyeliğinizi doğrulayın.";
                msg.From = new MailAddress("redteamproje@outlook.com");
                msg.To.Add(new MailAddress(manager.Email));
                msg.IsBodyHtml = true;
                msg.Body ="<div style='background-color:#422222;margin:0;padding:30px 0;width:100%'>"
                + "<table border='0' cellpadding='0' cellspacing='0' height ='100%' width ='100%'>" +
                "<tbody><tr><td align='center'><div><p><img alt='RedTeam' src = 'https://images-workbench.99static.com/esuZwLTC22_Jl0Q7BUlzmr_NHFI=/99designs-contests-attachments/83/83773/attachment_83773038' style ='width:100px; transform:  rotate(90deg; height:20;'></p></div>" +
                  $"<table border='0' cellpadding='0' cellspacing ='0' width='600'  style='background-color:#ffffff;border:1px solid #d8e2ef;border-radius:10px; padding-bottom:5%;'><tbody><tr><td align ='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%' style='background-image: linear-gradient(to bottom right, red, white);border-bottom:0;font-weight:bold;line-height:100%;vertical-align:middle;border-radius:10px 10px 0 0'><tbody><tr><td style='padding:25px 48px;display:block'><h1 style='font-size:28px;font-weight:300;line-height:150%;margin:0;text-align:center;color:black;background-color:inherit'>Hoşgeldiniz!</h1></td></tr></tbody></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='0' cellspacing='0' id='m_8132288392641734257template_body' style ='background-color:#ffffff;border-radius:10px'><tbody><tr><td valign='top' id='m_8132288392641734257body_content'><table border='0' cellpadding='20' cellspacing='0' width='100%'><tbody><tr><td valign='top' style='padding:48px 48px 48px'><div style='color:#636363;font-size:14px;line-height:150%;text-align:left'><p style='margin:0 0 16px;text-align:center'>Sayın {manager.FullName} Kayıt olduğunuz için teşekkür ederiz. Aşağıdaki butona tıkladığınızda hesabınız aktif edilecek ve hizmetlerimizden yararlanmaya başlayacaksınız.<strong></strong></p><div style='text-align:center'><a href='http://localhost:8021/Manager/ApprovalPage/{id}' style='background:red;color:BLACK;text-align:center;padding:6px 20px;font-size:19px;line-height:28px;display:inline-block;text-decoration:none;border-radius:5px;border:1px solid burlywood;background-image:linear-gradient(180deg,rgba(255,255,255,0.15),rgba(255,255,255,0))'>Aktivasyon İçin Tıklayın</a></div></div></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align='center' valign='top'><table border='0' cellpadding='10' cellspacing='0' width='200'><tbody><tr><td valign='top' style='padding:0;border-radius:6px'><table border='0' cellpadding='10' cellspacing ='0' width='100%'><tbody><tr><td colspan='2' valign='middle' style='border-radius:6px;border:0;color:#8a8a8a;font-size:12px;text-align:center;padding:24px 0'><p style='margin:0 0 16px'><strong>Red Team</strong><br>Kadıköy<br>via Bilge Adam<br></p></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></div>";

                SmtpClient smtp = new SmtpClient("smtp.office365.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
                NetworkCredential AccountInfo = new NetworkCredential("redteamproje@outlook.com", "123toci123");
                smtp.UseDefaultCredentials = false; //Standart doğrulama kullanılsın mı? -> Yalnızca gönderici özellikle istiyor ise TRUE işaretlenir.
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = true;

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
        public IActionResult ActiveCompany()
        {
            try
            {
                List<ActiveCompanyVM> companyVMs = adminService.GetActiveCompanyList();

                if (companyVMs!=null)
                {
                    return View(companyVMs);
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }
            return View();
        }
        public IActionResult DeleteCompany(int id)
        {
            try
            {
                if (adminService.DeleteCompany(id)<0)
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);

            }
            return RedirectToAction("passivecompany");
        }
        public IActionResult DeActivate(int id)
        {
            try
            {
                ActiveCompanyVM companyVM = new ActiveCompanyVM()
                {
                    CompanyId = id
                };
                if (adminService.DeactivateCompanies(companyVM)<1)
                {
                    throw new Exception("Bir hata oluştu");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("ActiveCompany");
        }

        public IActionResult EmployeesOfCompany(int id)
        {
            try
            {
                ManagerOfCompanyVM managerOfCompany = adminService.GetManagerandCompany(id);
                if (managerOfCompany!=null)
                {
                    return View(managerOfCompany);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("exception", ex.Message);
            }
            return RedirectToAction("ActiveCompany");

        }



    }
}
